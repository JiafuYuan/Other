using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Controls;
using Common.Enum;
using Common.MessageBoxEx;
using BLL=DB_VehicleTransportManage.BLL;
using DevComponents.DotNetBar;

namespace VehicleTransportClient
{
    public partial class FormSendMessage : Form
    {
        private string _tableName = "FormSendMessage";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_Message _model = new DB_VehicleTransportManage.Model.m_Message();
        private BLL.m_User bllUserEx = new BLL.m_User();
        private BLL.m_Person bllPerson = new BLL.m_Person();
        private int _sendPersonID = 0;
        private int _receivePersonID = 0;
        Bestway.Windows.Controls.InputPromptDialog inputPromptSend = new InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptReceive = new InputPromptDialog();
        public FormSendMessage()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormSystemLog_Load);
            dtInputStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            dtInputStop.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            InitLoad();
        }

        void FormSystemLog_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData(string dtStart, string dtStop, int receivePersonID, int sendPersonID)
        {
            List<DB_VehicleTransportManage.Model.m_User> lstUsers =
              new DB_VehicleTransportManage.BLL.m_User().GetModelList("i_Flag=0");
            List<DB_VehicleTransportManage.Model.m_Person> lstPersonss =
                new DB_VehicleTransportManage.BLL.m_Person().GetModelList("i_Flag=0");
            StringBuilder stringBuilder = new StringBuilder();
            if (bllUserEx.GetUserIDByPersonID(sendPersonID) > 0)
            {
                stringBuilder.AppendFormat(" FromUserID={0} and ", bllUserEx.GetUserIDByPersonID(sendPersonID));
            }

            if (bllUserEx.GetUserIDByPersonID(receivePersonID) > 0)
            {
                stringBuilder.AppendFormat("  ToUserID={0} and ", bllUserEx.GetUserIDByPersonID(receivePersonID));
            }
           
            stringBuilder.Append(" i_flag=0 and dt_SendDateTime>='" + dtInputStart.Value + "' and dt_SendDateTime<='" + dtInputStop.Value + "' order by dt_SendDateTime desc");
            List<DB_VehicleTransportManage.Model.m_Message> lst = new BLL.m_Message().GetModelList(stringBuilder.ToString());

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            string messageTypeName = "";
            foreach (DB_VehicleTransportManage.Model.m_Message item in lst)
            {
                switch ((EnumMessageType)item.i_MessageType)
                {
                    case EnumMessageType.CheckResul:
                        messageTypeName = "审核结果";
                        break;
                    case EnumMessageType.AriveArea:
                        messageTypeName = "到达区域";
                        break;
                    case EnumMessageType.NoChanageState:
                        messageTypeName = "未置换状态";
                        break;
                    default:
                        messageTypeName = "";
                        break;
                }
                var userModelFrom = lstUsers.Find(p => p.ID == item.FromUserID);
                string FromPersonName = "";
                if (userModelFrom != null)
                {
                    var personId = userModelFrom.PersonID;
                    var tt = lstPersonss.Find(p => p.ID == personId);
                    if (tt != null)
                    {
                        FromPersonName = tt.vc_Name;
                    }
                }

                var userModelTo = lstUsers.Find(p => p.ID == item.ToUserID);
                string ToPersonName = "";
                if (userModelTo != null)
                {
                    var personId = userModelTo.PersonID;
                    var tt = lstPersonss.Find(p => p.ID == personId);
                    if (tt != null)
                    {
                        ToPersonName = tt.vc_Name;
                    }
                }

                int i = dgvList.Rows.Add(messageTypeName, FromPersonName, ToPersonName, item.vc_Message,
                    item.dt_SendDateTime == null ? "" : item.dt_SendDateTime.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"),
                    (item.dt_ReceiveDateTime != null && item.dt_ReceiveDateTime.Value.Year != 1900) ? item.dt_ReceiveDateTime.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒") : "",
                    item.vc_Memo);
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条记录";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();

            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (_sendPersonID == 0)
            {
                txtSendPerson.Text = "";
            }
            if (_receivePersonID == 0)
            {
                txtReceivePerson.Text = "";
            }
            if (dtInputStart.Value >= dtInputStop.Value)
            {
                Common.MessageBoxEx.MessageBoxEx.Show("开始日期应在结束日期之前", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadData(dtInputStart.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtInputStop.Value.ToString("yyyy-MM-dd HH:mm:ss"),_receivePersonID,_sendPersonID);

        }
        private void InitLoad()
        {
            inputPromptSend.ClearBind();
            inputPromptReceive.ClearBind();
            DataSet dataSet = bllPerson.DropDownSource();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptSend.Bind(txtSendPerson, dataSet.Tables[0], 3, new int[] { 1 });
                inputPromptSend.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPrompt_OnTextChangedEx);
                inputPromptReceive.Bind(txtReceivePerson, dataSet.Tables[0], 3, new int[] { 1 });
                inputPromptReceive.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptReceive_OnTextChangedEx);
            }

        }

        void inputPromptReceive_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                _receivePersonID = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _receivePersonID = 0;
               
            }
        }

        void inputPrompt_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                _sendPersonID = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _sendPersonID = 0;
              
            }
        }

        private void txtReceivePerson_Click(object sender, EventArgs e)
        {
            inputPromptReceive.ShowDropDown();
        }

        private void txtSendPerson_Click(object sender, EventArgs e)
        {
            inputPromptSend.ShowDropDown();
        }


    }


}
