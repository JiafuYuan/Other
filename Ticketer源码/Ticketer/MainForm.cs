using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace Ticketer
{
    public partial class MainForm : Form
    {
        internal List<StationModel> stationList = new List<StationModel>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            DialogResult result = login.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Visible = true;
                this.monthCalendar1.MaxDate = DateTime.Now.AddDays(19);
                this.monthCalendar1.MinDate = DateTime.Now;
            }
            else
            {
                this.Dispose();
                return;
            }
            getServerConnection();
            stationList = (new AnalysisSearchData()).StationList;
            getPassengers();
            setSeatType();
            isOrder = this.checkBox1.Checked;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (button1.Text != "查询")
            {
                thread.Abort();
            }
        }

        #region 查询设置

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.textBox1.Text = e.Start.ToString("yyyy-MM-dd");
            this.button1.Focus();
            this.monthCalendar1.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            setStationText(textBox2.Text, textBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            setStationText(textBox3.Text, textBox3);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void listBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (t != null)
            {
                if (t.Name == "textBox2")
                    startCode = (listBox3.SelectedItem as StationModel).LetterCode;
                else
                    endCode = (listBox3.SelectedItem as StationModel).LetterCode;
                t.Text = (listBox3.SelectedItem as StationModel).Name;
                listBox3.Visible = false;
            }
        }

        private void setStationText(string str, TextBox tb)
        {
            List<StationModel> list = stationList.FindAll((station) => { return station.PYString.IndexOf(str) == 0 || station.ShortPYString.IndexOf(str) == 0; });
            if (list == null || list.Count == 0)
            {
                list = stationList.FindAll((station) => { return station.Name.IndexOf(str) > -1; });
            }
            Point p = listBox3.Location;
            p.X = tb.Location.X;
            listBox3.Location = p;
            listBox3.DataSource = list;
            listBox3.DisplayMember = "Name";
            this.listBox3.Visible = true;
            t = tb;
        }
        #endregion

        /// <summary>
        /// 查询服务器连接情况
        /// </summary>
        private bool getServerConnection()
        {
            HttpHelper helper = new HttpHelper(LinkAddress.TICKETSEARCH_ADDRESS + "?method=init");
            string str = helper.GetResponseSTRING();
            if (str.IndexOf("isLogin= true") > -1 || str.IndexOf("isLogin=true") > -1 || str.IndexOf("isLogin = true") > -1)
            {
                Regex reg = new Regex(@"var\s?u_name\s?\=\s?\'(\w+)\'\;");
                Match match = reg.Match(str);
                if (match.Groups.Count == 2)
                {
                    this.Text = match.Groups[1].Value;
                }
                return true;
            }
            return false;
        }

        #region 查询
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "查询")
            {
                if (string.IsNullOrEmpty(startCode) || string.IsNullOrEmpty(endCode) || string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("出发地，目的地，出发时间不能为空");
                    return;
                }
                button1.Text = "停止";
                isHaveTrainCode = false;
                thread = new Thread(new ParameterizedThreadStart(startSearch));
                string[] args = new string[3] { startCode, endCode, textBox1.Text };
                thread.Start(args);
                setPromptText("开始车票查询");
            }
            else
            {
                thread.Abort();
                this.button1.Text = "查询";
                setPromptText("结束车票查询");
                isHaveTrainCode = false;
                listBox1.DataSource = null;
                listBox2.DataSource = null;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string str = e.Value.ToString();
            int n;
            object value = str;
            if (int.TryParse(str, out n))
            {
                if (n == 0)
                {
                    value = "无";
                }
                else if (n == -1)
                {
                    value = "--";
                }
                else if (n == 50)
                {
                    value = "有";
                }
            }
            e.Value = value;
        }

        private void startSearch(object args)
        {
            string[] strs = args as string[];
            int i = 1;
            while (true)
            {
                bindTrainList(strs[0], strs[1], strs[2]);
                setPromptText(string.Format("第{0}次查询结束,6秒后重新查询", i));
                Thread.Sleep(6000);
                setPromptText(string.Format("开始第{0}次查询...", ++i));
            }

        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="fromStation"></param>
        /// <param name="toStation"></param>
        /// <param name="trainDate"></param>
        private void bindTrainList(string fromStation, string toStation, string trainDate)
        {
            AnalysisSearchData analysis = new AnalysisSearchData();
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("method", "queryLeftTicket");
            dic.Add("orderRequest.train_date", trainDate);//发车日期，格式：2013-01-23
            dic.Add("orderRequest.from_station_telecode", fromStation);//起始站字母代码
            dic.Add("orderRequest.to_station_telecode", toStation);//到站字母代码

            dic.Add("orderRequest.train_no", "");//车次，组合代码
            dic.Add("trainPassType", "QB");// 列车路过的类型，取值:GL(过路)、SF(始发)、QB(全部)
            dic.Add("trainClass", "QB#D#Z#T#K#QT#");// 列车类别，为多选框，#号分隔，取值:QB(全部)、D(D字头)、Z(Z字头)、T(T字头)、K(K字头)、QT(其他)
            dic.Add("includeStudent", "00");// 查询中是否包含学生票,00默认值，0X00是
            dic.Add("seatTypeAndNum", "");// 席别、数量的集合，采用席别#数量@-------订票查询时为空

            dic.Add("orderRequest.start_time_str", "00:00--24:00");//开车时间段00:00--24:00，00:00--06:00，06:00--12:00，12:00--18:00，18:00--24:00

            List<TrainModel> list;
            try
            {
                list = analysis.GetSearchData(dic);
            }
            catch (Exception ex)
            {
                setPromptText(ex.Message);
                return;
            }
            if (checkBox2.Checked)
            {
                list.RemoveAll((train) => { return train != null && !train.IsAllowBuy; });
            }
            setGridView(list);
            setDisplayTrainList(list);
            setSelectTrainList(null);

            creatOrderArg();
        }

        private void setPromptText(object text)
        {
            if (textBox4.InvokeRequired)
            {
                textBox4.Invoke(new SetContralText(setPromptText), new object[] { text });
            }
            else
            {
                textBox4.Text = string.Format("{0}  {1}\r\n{2}", DateTime.Now.ToString("HH:mm:ss"), text, textBox4.Text);
            }
        }

        private void setGridView(object list)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new SetContralText(setGridView), new object[] { list });
            }
            else
            {
                dataGridView1.DataSource = list as List<TrainModel>;
            }
        }
        #endregion

        #region 订票设置
        private void checkBox1_Click(object sender, EventArgs e)
        {
            isOrder = this.checkBox1.Checked;
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((listBox2.DataSource as List<TrainModel>) != null)
            {
                List<TrainModel> list = listBox2.DataSource as List<TrainModel>;
                list.Add(listBox1.SelectedItem as TrainModel);
                listBox2.DataSource = null;
                listBox2.DataSource = list;
            }
            else
            {
                listBox2.DataSource = new List<TrainModel>() { listBox1.SelectedItem as TrainModel };
            }
            listBox2.DisplayMember = "TrainNum";

            List<TrainModel> list2 = listBox1.DataSource as List<TrainModel>;
            list2.Remove(listBox1.SelectedItem as TrainModel);
            listBox1.DataSource = null;
            listBox1.DataSource = list2;
            listBox1.DisplayMember = "TrainNum";
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if ((listBox1.DataSource as List<TrainModel>) != null)
            {
                List<TrainModel> list = listBox1.DataSource as List<TrainModel>;
                list.Add(listBox2.SelectedItem as TrainModel);
                listBox1.DataSource = null;
                listBox1.DataSource = list;
            }
            else
            {
                listBox1.DataSource = new List<TrainModel>() { listBox2.SelectedItem as TrainModel };
            }
            listBox1.DisplayMember = "TrainNum";

            List<TrainModel> list2 = listBox2.DataSource as List<TrainModel>;
            list2.Remove(listBox2.SelectedItem as TrainModel);
            listBox2.DataSource = null;
            listBox2.DataSource = list2;
            listBox2.DisplayMember = "TrainNum";
        }

        /// <summary>
        /// 加载联系人列表
        /// </summary>
        private void getPassengers()
        {
            AnalysisSearchData analysis = new AnalysisSearchData();
            List<PassengerModel> list = null;
            for (list = analysis.GetPassengers(); list == null; )
            {
                MessageBox.Show("加载乘车人信息失败，请重启系统", "数据错误");
                this.Close();
                return;
            }
            this.checkedListBox1.DataSource = list;
            this.checkedListBox1.DisplayMember = "Name";
        }

        private void setSeatType()
        {
            checkedListBox2.Items.Clear();
            this.checkedListBox2.DataSource = (new SeatClass()).GetSeatTypeList();
            this.checkedListBox2.DisplayMember = "Text";
        }
        /// <summary>
        /// 构造订票参数
        /// </summary>
        private void creatOrderArg()
        {
            if (this.listBox2.Items.Count == 0)
                return;
            if (this.checkedListBox2.CheckedItems.Count == 0)
                return;
            if (this.checkedListBox1.CheckedItems.Count == 0)
                return;
            //if (string.IsNullOrEmpty(textBox5.Text))
            //    return;

            List<TrainModel> list = new List<TrainModel>();
            List<TrainModel> gridData = dataGridView1.DataSource as List<TrainModel>;
            foreach (TrainModel item in this.listBox2.Items)
            {
                TrainModel m = gridData.Find((train) => { return train.TrainNum == item.TrainNum; });
                if (m != null)
                    list.Add(m);
            }
            if (list.Count == 0)
                return;

            List<TrainModel> listBySeat = null;
            foreach (SeatClass.KeyValue item in checkedListBox2.CheckedItems)
            {
                switch (item.Text)
                {
                    case "商务座":
                        listBySeat = list.FindAll((train) => { return train.BusinessSeat >= this.checkedListBox1.CheckedItems.Count; });
                        break;
                    case "一等座":
                        listBySeat = list.FindAll((train) => { return train.FirstSeat >= this.checkedListBox1.CheckedItems.Count; });
                        break;
                    case "二等座":
                        listBySeat = list.FindAll((train) => { return train.SecondSeat >= this.checkedListBox1.CheckedItems.Count; });
                        break;
                    case "高级软卧":
                        listBySeat = list.FindAll((train) => { return train.HighRankingSoftSleeper >= this.checkedListBox1.CheckedItems.Count; });
                        break;
                    case "软卧":
                        listBySeat = list.FindAll((train) => { return train.SoftSleeper >= this.checkedListBox1.CheckedItems.Count; });
                        break;
                    case "硬卧":
                        listBySeat = list.FindAll((train) => { return train.HardSleeper >= this.checkedListBox1.CheckedItems.Count; });
                        break;
                    case "软座":
                        listBySeat = list.FindAll((train) => { return train.SoftSeat >= this.checkedListBox1.CheckedItems.Count; });
                        break;
                    case "硬座":
                        listBySeat = list.FindAll((train) => { return train.HardSeat >= this.checkedListBox1.CheckedItems.Count; });
                        break;
                    case "无座":
                        listBySeat = list.FindAll((train) => { return train.NoSeat >= this.checkedListBox1.CheckedItems.Count; });
                        break;
                    case "其他":
                        listBySeat = list.FindAll((train) => { return train.Other >= this.checkedListBox1.CheckedItems.Count; });
                        break;
                }

                if (listBySeat != null && listBySeat.Count > 0)
                {
                    break;
                }
            }
            if (listBySeat == null || listBySeat.Count == 0)
                return;

            //setButtonText("查询");
            setPromptText(string.Format("开始预订{0}次列车车票...", listBySeat[0].BuyString.Split('#')[0]));
            confirmOrderTread = new Thread(new ParameterizedThreadStart(threahCheckOrder));
            confirmOrderTread.Start(listBySeat[0].BuyString);
            thread.Abort();
        }

        /// <summary>
        /// 设置可选车次
        /// </summary>
        /// <param name="list"></param>
        private void setDisplayTrainList(object list)
        {
            if (isOrder && !isHaveTrainCode)
            {
                if (listBox1.InvokeRequired)
                {
                    listBox1.Invoke(new SetContralText(setDisplayTrainList), new object[] { list });
                }
                else
                {
                    listBox1.DataSource = list as List<TrainModel>;
                    listBox1.DisplayMember = "TrainNum";
                    isHaveTrainCode = true;
                }
            }
        }

        private void setSelectTrainList(object list)
        {
            if (isOrder && !isHaveTrainCode)
            {
                if (listBox2.InvokeRequired)
                {
                    listBox2.Invoke(new SetContralText(setSelectTrainList), new object[] { list });
                }
                else
                {
                    listBox2.DataSource = list as List<TrainModel>;
                    listBox2.DisplayMember = "TrainNum";
                }
            }
        }

        private void setButtonText(object text)
        {
            if (button1.InvokeRequired)
                button1.Invoke(new SetContralText(setButtonText), new object[] { text });
            else
            {
                button1.Text = text.ToString();
                if (text == "查询")
                    button1.Enabled = true;
                else
                    button1.Enabled = false;
            }
        }
        #endregion

        #region 订票
        private void threahCheckOrder(object orderStr)
        {
            while (!checkOrder(orderStr, out orderPageResponse))
            {
                break;
            }
            string vcode = getVerificationCode();

            JsonObject json = getCheckOrderResult(vcode);

            if (!json["errMsg"].Value.ToLower().Equals("y"))
            {
                setButtonText("查询");
                setPromptText(json["errMsg"].Value);
                isOrderTiicketing = true;
                //confirmOrderTread.Abort();
                creatOrderArg();
            }
            else if (json["checkHuimd"].Value.ToLower().Equals("n"))
            {
                setButtonText("查询");
                setPromptText("铁道部说：由于您取消次数过多，今日将不能继续受理您的订票请求！");
                confirmOrderTread.Abort();
            }
            else if (json["check608"].Value.ToLower().Equals("n"))
            {
                setButtonText("查询");
                setPromptText("铁道部说：本车为实名制列车，实行一日一车一证一票制！");
                confirmOrderTread.Abort();
            }

            string[] args = orderStr.ToString().Split('#');
            HttpHelper helper = new HttpHelper(string.Format("{0}&train_date={1}&train_no={2}&station={3}&seat={4}&from={5}&to={6}&ticket={7}"
                , LinkAddress.CHECKNUMBEROFTICKET_ADDRESS
                , textBox1.Text
                , args[3]
                , args[0]
                , (this.checkedListBox2.CheckedItems[0] as SeatClass.KeyValue).Value
                , getInputHtmlContralValue(orderPageResponse, "from_station_telecode")
                , getInputHtmlContralValue(orderPageResponse, "to_station_telecode")
                , getInputHtmlContralValue(orderPageResponse, "left_ticket")));
            helper.Request.Method = "GET";
            JsonObject ticketCount = helper.GetResponseJSON();
            if (ticketCount["op_2"].Value != null && ticketCount["op_2"].Value.ToLower().Equals("true"))
            {
                setPromptText("铁道部说：目前排队人数已经超过余票张数，请您选择其他席别或车次");
                setPromptText(string.Format("有{0}人在你前面排队了", ticketCount["count"].Value));
                confirmOrderTread.Abort();
                return;
            }
            if (ticketCount["op_1"].Value != null && ticketCount["op_1"].Value.ToLower().Equals("true"))
            {
                setPromptText("铁道部说：目前排队人数已经超过余票张数");
                confirmOrderTread.Abort();
                return;
            }
            setPromptText(string.Format("有{0}人正在跟你挤着排队", ticketCount["countT"].Value));

            int seat_1 = -1;
            int seat_2 = -1;
            for (int i = 0; i < ticketCount["ticket"].Value.Length; i = i + 10)
            {
                string s = ticketCount["ticket"].Value.Substring(i, 10);
                string c_seat = s.Substring(0, 1);
                if (c_seat == (this.checkedListBox2.CheckedItems[0] as SeatClass.KeyValue).Value)
                {
                    string count = s.Substring(6, 4);
                    while (count.Length > 1 && count.Substring(0, 1) == "0")
                    {
                        count = count.Substring(1, count.Length - 1);
                    }
                    if (Convert.ToInt32(count) < 3000)
                    {
                        seat_1 = Convert.ToInt32(count);
                    }
                    else
                    {
                        seat_2 = (Convert.ToInt32(count) - 3000);
                    }
                }
            }
            Thread.Sleep(1000);
            submitOrder(vcode, orderStr);
        }

        private JsonObject getCheckOrderResult(string vcode)
        {
            HttpHelper helper = new HttpHelper(string.Format("{0}&rand={1}", LinkAddress.CONFIRMPASSENGERACTION_ADDRESS, vcode));
            helper.Request.Method = "POST";
            Dictionary<string, string[]> dics = getOrderRequestData(vcode);
            helper.RequestArrayData = dics;
            return helper.GetResponseJSON();
        }

        private string getVerificationCode()
        {
            DateTime startTime = DateTime.Now;
            Ticketer.Forms.VerificationCode code = new Forms.VerificationCode();
            code.ShowDialog();
            string vcode = code.Code;
            var longt = DateTime.Now - startTime;
            if (longt.Seconds <= 6)
                for (int i = longt.Seconds; i > 0; i--)
                {
                    setPromptText(string.Format("{0}秒后开始提交本次订单...", i));
                    Thread.Sleep(1000);
                }
            return vcode;
        }

        private Dictionary<string, string[]> getOrderRequestData(string vcode)
        {
            Dictionary<string, string[]> dics = new Dictionary<string, string[]>();
            List<string> strList = new List<string>();
            for (int i = 0; i < this.checkedListBox1.CheckedItems.Count; i++)
            {
                int n = checkedListBox1.Items.IndexOf(checkedListBox1.CheckedItems[i]);
                dics.Add(string.Format("checkbox{0}", n), new string[] { n.ToString() });
            }
            dics.Add("checkbox9", new string[] { "Y", "Y", "Y", "Y", "Y" });

            dics.Add("leftTicketStr", new string[] { getInputHtmlContralValue(orderPageResponse, "leftTicketStr") });
            for (int i = 0; i < this.checkedListBox1.CheckedItems.Count; i++)
            {
                PassengerModel pm = this.checkedListBox1.CheckedItems[i] as PassengerModel;
                strList.Add(string.Format("{0},{1},{2}", pm.Name, pm.PassengerIDType, pm.PassengerID));
            }
            for (; strList.Count < 5; )
            {
                strList.Add("");
            }
            dics.Add("oldPassengers", strList.ToArray());

            dics.Add("orderRequest.bed_level_order_num", new string[] { getInputHtmlContralValue(orderPageResponse, "bed_level_order_num") });
            dics.Add("orderRequest.cancel_flag", new string[] { getInputHtmlContralValue(orderPageResponse, "cancel_flag") });
            dics.Add("orderRequest.end_time", new string[] { getInputHtmlContralValue(orderPageResponse, "end_time") });
            dics.Add("orderRequest.from_station_name", new string[] { getInputHtmlContralValue(orderPageResponse, "from_station_name") });
            dics.Add("orderRequest.from_station_telecode", new string[] { getInputHtmlContralValue(orderPageResponse, "from_station_telecode") });
            dics.Add("orderRequest.id_mode", new string[] { getInputHtmlContralValue(orderPageResponse, "id_mode") });
            dics.Add("orderRequest.reserve_flag", new string[] { "A" });
            dics.Add("orderRequest.seat_type_code", new string[] { getInputHtmlContralValue(orderPageResponse, "seat_type_code") });
            dics.Add("orderRequest.start_time", new string[] { getInputHtmlContralValue(orderPageResponse, "start_time") });
            dics.Add("orderRequest.station_train_code", new string[] { getInputHtmlContralValue(orderPageResponse, "station_train_code") });
            dics.Add("orderRequest.ticket_type_order_num", new string[] { getInputHtmlContralValue(orderPageResponse, "ticket_type_order_num") });
            dics.Add("orderRequest.to_station_name", new string[] { getInputHtmlContralValue(orderPageResponse, "to_station_name") });
            dics.Add("orderRequest.to_station_telecode", new string[] { getInputHtmlContralValue(orderPageResponse, "to_station_telecode") });
            dics.Add("orderRequest.train_date", new string[] { getInputHtmlContralValue(orderPageResponse, "train_date") });
            dics.Add("orderRequest.train_no", new string[] { getInputHtmlContralValue(orderPageResponse, "train_no") });
            dics.Add("org.apache.struts.taglib.html.TOKEN", new string[] { getInputHtmlContralValue(orderPageResponse, "TOKEN") });

            for (int i = 0; i < this.checkedListBox1.CheckedItems.Count; i++)
            {
                PassengerModel pm = this.checkedListBox1.CheckedItems[i] as PassengerModel;
                dics.Add(string.Format("passenger_{0}_cardno", i), new string[] { pm.PassengerID });
                dics.Add(string.Format("passenger_{0}_cardtype", i), new string[] { pm.PassengerIDType });
                dics.Add(string.Format("passenger_{0}_mobileno", i), new string[] { pm.Telephone });
                dics.Add(string.Format("passenger_{0}_name", i), new string[] { pm.Name });
                dics.Add(string.Format("passenger_{0}_seat", i), new string[] { (this.checkedListBox2.CheckedItems[0] as SeatClass.KeyValue).Value });
                dics.Add(string.Format("passenger_{0}_ticket", i), new string[] { pm.PassengerType });
            }

            strList.Clear();
            for (int i = 0; i < this.checkedListBox1.CheckedItems.Count; i++)
            {
                PassengerModel pm = this.checkedListBox1.CheckedItems[i] as PassengerModel;
                strList.Add(string.Format("{0},0,{1},{2},{3},{4},{5},Y"
                    , (this.checkedListBox2.CheckedItems[0] as SeatClass.KeyValue).Value
                    , pm.PassengerType
                    , pm.Name
                    , pm.PassengerIDType
                    , pm.PassengerID
                    , pm.Telephone));
            }
            dics.Add("passengerTickets", strList.ToArray());

            dics.Add("randCode", new string[] { vcode });
            dics.Add("textfield", new string[] { getInputHtmlContralValue(orderPageResponse, "textfield") });
            dics.Add("tFlag", new string[] { "dc" });
            return dics;
        }

        private void submitOrder(string vcode, object arg)
        {
            HttpHelper helper = new HttpHelper(LinkAddress.SUBMITORDER_ADDRESS);
            helper.Request.Method = "POST";
            helper.RequestArrayData = getOrderRequestData(vcode);
            JsonObject ticketCount = helper.GetResponseJSON();
            if (ticketCount["errMsg"].Value == "Y")
            {
                MessageBox.Show("订票成功，快去12306付款吧...");
                setButtonText("查询");
                setPromptText("订票成功");
                isHaveTrainCode = false;
                listBox1.DataSource = null;
                listBox2.DataSource = null;
            }
            else
            {
                setPromptText(ticketCount["errMsg"].Value);
                DialogResult dr = MessageBox.Show(string.Format("铁道部说：{0}\r\n选\"是\"再次提交订单\r\n选\"否\"重新订票", ticketCount["errMsg"].Value), "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    threahCheckOrder(arg);
                else
                {
                    setButtonText("查询");
                    listBox1.DataSource = null;
                    listBox2.DataSource = null;
                }
            }
        }


        private bool checkOrder(object orderStr, out string responseDom)
        {
            responseDom = null;
            string[] args = orderStr.ToString().Split('#');
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("station_train_code", args[0]);
            dic.Add("train_date", this.textBox1.Text);
            dic.Add("seattype_num", "");//座位类型参数，暂未使用
            dic.Add("from_station_telecode", args[4]);
            dic.Add("to_station_telecode", args[5]);
            dic.Add("include_student", "00"); //暂不支持学生票购买
            dic.Add("from_station_telecode_name", this.textBox2.Text);
            dic.Add("to_station_telecode_name", this.textBox3.Text);
            dic.Add("round_train_date", Convert.ToDateTime(this.textBox1.Text).AddDays(3).ToString("yyyy-MM-dd"));
            dic.Add("round_start_time_str", "00:00--24:00"); //暂时只支持预订全天票
            dic.Add("start_time_str", "00:00--24:00");
            dic.Add("single_round_type", "1"); //暂时只支持单程票预订，往返票预订该参数值为2
            dic.Add("train_pass_type", "QB");//暂时只支持预订全部过路车类型，始发站车该值为SF，过路车该值为GL
            dic.Add("train_class_arr", "QB#D#Z#T#K#QT#");//暂时只支持预订全部类型车票
            dic.Add("lishi", args[1]);
            dic.Add("train_start_time", args[2]);
            dic.Add("trainno4", args[3]);
            dic.Add("arrive_time", args[6]);
            dic.Add("from_station_name", args[7]);
            dic.Add("to_station_name", args[8]);
            dic.Add("from_station_no", args[9]);
            dic.Add("to_station_no", args[10]);
            dic.Add("ypInfoDetail", args[11]);
            dic.Add("mmStr", args[12]);
            dic.Add("locationCode", args[13]);

            HttpHelper helper = new HttpHelper(LinkAddress.CREATEORDER_ADDRESS + "?method=submutOrderRequest");
            helper.Request.Method = "POST";
            helper.RequestData = dic;
            helper.Request.Referer = LinkAddress.CREATEORDER_ADDRESS + "?method=init";
            try
            {
                responseDom = helper.GetResponseSTRING();
            }
            catch (Exception ex)
            {
                setPromptText(string.Format("转入订单提交步骤出错，错误信息：", ex.Message));
                return false;
            }
            if (responseDom.IndexOf("org.apache.struts.taglib.html.TOKEN") > -1)
            {
                return true;
            }
            else
            {
                setPromptText("转入订单提交步骤出错,未返回有效数据。");
                return false;
            }
        }

        #endregion

        private string getInputHtmlContralValue(string docment, string inputName)
        {
            string result = string.Empty;
            Regex reg = new Regex(string.Format("<input[^>]+(({0}[^>]+value=[\'|\"](?<value>[^\'\"]+)[\'|\"])|(value=[\'|\"](?<value>[^\'\"]+)[\'|\"][^>]+{0}))[^>]*>", inputName));
            Match match = reg.Match(docment);
            if (match.Groups["value"] != null)
                result = match.Groups["value"].Value;
            return result;
        }

        #region 字段
        TextBox t;
        string startCode, endCode, orderPageResponse;
        bool isOrder = false;
        bool isHaveTrainCode;
        Thread thread, confirmOrderTread;
        List<TrainModel> trainList = new List<TrainModel>();
        /// <summary>
        /// 是否正在订票
        /// </summary>
        bool isOrderTiicketing = false;
        #endregion
    }
}
