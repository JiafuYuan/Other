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
        object gridLocker = new object();

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
                t.Text = (listBox3.SelectedItem as StationModel).Name;
                if (t.Name == "textBox2")
                    startCode = (listBox3.SelectedItem as StationModel).LetterCode;
                else
                    endCode = (listBox3.SelectedItem as StationModel).LetterCode;
                listBox3.Visible = false;
            }
        }

        private void setStationText(string str, TextBox tb)
        {
            List<StationModel> list = stationList.FindAll((station) => { return station.PYString.IndexOf(str) == 0 || station.ShortPYString.IndexOf(str) == 0 || station.Name.IndexOf(str) > -1; });
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
            HttpHelper helper = new HttpHelper(LinkAddress.TICKETSEARCH_ADDRESS);
            //helper.GetResponse();
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

        private void startSearch(object args)
        {
            string[] strs = args as string[];
            int i = 1;
            while (true)
            {
                bindTrainList(strs[0], strs[1], strs[2]);
                setPromptText(string.Format("第{0}次查询结束", i));
                Thread.Sleep(5000);
                setPromptText(string.Format("开始第{0}次查询", ++i));
            }

        }

        private void bindTrainList(string fromStation, string toStation, string trainDate)
        {
            AnalysisSearchData analysis = new AnalysisSearchData();
            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("method", "queryLeftTicket");
            dic.Add("orderRequest.train_no", "");//车次，组合代码
            dic.Add("seatTypeAndNum", "");// 席别、数量的集合，采用席别#数量@-------订票查询时为空

            dic.Add("includeStudent", "00");// 查询中是否包含学生票,00默认值，0X00是
            dic.Add("orderRequest.start_time_str", "00:00--24:00");//开车时间段00:00--24:00，00:00--06:00，06:00--12:00，12:00--18:00，18:00--24:00
            dic.Add("orderRequest.train_date", trainDate);//发车日期，格式：2013-01-23
            dic.Add("trainClass", "QB#D#Z#T#K#QT#");// 列车类别，为多选框，#号分隔，取值:QB(全部)、D(D字头)、Z(Z字头)、T(T字头)、K(K字头)、QT(其他)
            dic.Add("trainPassType", "QB");// 列车路过的类型，取值:GL(过路)、SF(始发)、QB(全部)

            dic.Add("orderRequest.from_station_telecode", fromStation);//起始站字母代码
            dic.Add("orderRequest.to_station_telecode", toStation);//到站字母代码
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
            return;
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
            //lock (gridLocker)
            //{
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new SetContralText(setGridView), new object[] { list });
            }
            else
            {
                dataGridView1.DataSource = list as List<TrainModel>;
            }
            //}
        }
        #endregion

        #region 订票设置
        private void checkBox1_Click(object sender, EventArgs e)
        {
            isOrder = (sender as CheckBox).Checked;
            if (isOrder)
            {
                HttpHelper helper = new HttpHelper(LinkAddress.LOGINIMG_ADDRESS);
                helper.Request.Method = "GET";
                this.pictureBox1.Image = helper.GetResponseIMG();
            }
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

        private void getPassengers()
        {
            AnalysisSearchData analysis = new AnalysisSearchData();
            List<PassengerModel> list = analysis.GetPassengers();
            this.checkedListBox1.DataSource = list;
            this.checkedListBox1.DisplayMember = "Name";
        }

        private void setSeatType()
        {
            checkedListBox2.Items.Clear();
            foreach (var s in Enum.GetNames(typeof(SeatType)))
            {
                this.checkedListBox2.Items.Add(s);
            }
        }

        private void creatOrderArg()
        {
            if (this.listBox2.Items.Count == 0)
                return;
            if (this.checkedListBox2.CheckedItems.Count == 0)
                return;
            if (this.checkedListBox1.CheckedItems.Count == 0)
                return;

            List<TrainModel> list = new List<TrainModel>();
            //lock (gridLocker)
            //{
            List<TrainModel> gridData = dataGridView1.DataSource as List<TrainModel>;
            foreach (TrainModel item in this.listBox2.Items)
            {
                TrainModel m = gridData.Find((train) => { return train.TrainNum == item.TrainNum; });
                if (m != null)
                    list.Add(m);
            }
            //}
            if (list.Count == 0)
                return;

            List<TrainModel> listBySeat = null;
            foreach (string item in checkedListBox2.CheckedItems)
            {
                switch (item)
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

            

            string[] args = listBySeat[0].BuyString.Split('#');
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

            string orderHTML = helper.GetResponseSTRING();

        }

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
        #endregion

        #region 字段
        TextBox t;
        string startCode, endCode;
        bool isOrder = false;
        bool isHaveTrainCode;
        Thread thread;
        List<TrainModel> trainList = new List<TrainModel>();
        #endregion
    }
}
