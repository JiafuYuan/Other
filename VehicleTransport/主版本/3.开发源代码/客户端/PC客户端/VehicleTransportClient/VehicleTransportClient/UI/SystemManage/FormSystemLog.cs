using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using Common.MessageBoxEx;
using DB_VehicleTransportManage;
using BLL=DB_VehicleTransportManage.BLL;
using Model=DB_VehicleTransportManage.Model;

namespace VehicleTransportClient
{
    public partial class FormSystemLog : Form
    {
        private string _tableName = "FormSystemLog";
        private int _selectIndex = -1;
        private Model.m_SystemLog _model = new Model.m_SystemLog();

        public FormSystemLog()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormSystemLog_Load);
            dtInputStart.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            dtInputStop.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
        }

        void FormSystemLog_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData(string dtStart, string dtStop)
        {
            List<DB_VehicleTransportManage.Model.m_User> lstUsers =
                new DB_VehicleTransportManage.BLL.m_User().GetModelList("i_Flag=0");
            List<DB_VehicleTransportManage.Model.m_Person> lstPersonss =
                new DB_VehicleTransportManage.BLL.m_Person().GetModelList("i_Flag=0");

           // List<Model.v_SystemLog> lst = new BLL.v_SystemLog().GetModelList("i_flag=0 and dt_DateTime>='" + dtInputStart.Value + "' and dt_DateTime<='" + dtInputStop.Value + "'");
            List<Model.m_SystemLog> lst = new BLL.m_SystemLog().GetModelList("i_flag=0 and dt_DateTime>='" + dtInputStart.Value + "' and dt_DateTime<='" + dtInputStop.Value + "'");
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            string actionTypeName = "";
            foreach (DB_VehicleTransportManage.Model.m_SystemLog item in lst)
            {
                switch ((EnumActionType)item.i_ActionType)
                {
                    case EnumActionType.System:
                        actionTypeName = "系统操作";
                        break;
                    case EnumActionType.Add:
                        actionTypeName = "增加";
                        break;
                    case EnumActionType.Delete:
                        actionTypeName = "删除";
                        break;
                    case EnumActionType.Update:
                        actionTypeName = "修改";
                        break;
                    default:
                        break;
                }
                var userModel = lstUsers.Find(p => p.ID == item.UserID);
                string personName = "";
                if (userModel != null)
                {
                   var personId  = userModel.PersonID;
                    var tt = lstPersonss.Find(p => p.ID == personId);
                    if (tt!=null)
                    {
                        personName = tt.vc_Name;
                    }
                }
               
                int i = dgvList.Rows.Add(personName, actionTypeName, item.vc_Title, item.vc_Description, item.dt_DateTime == null ? "" : item.dt_DateTime.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"), item.vc_Memo);
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

            if (dtInputStart.Value >= dtInputStop.Value)
            {
                Common.MessageBoxEx.MessageBoxEx.Show("开始日期应在结束日期之前", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtInputStart.Value.AddMonths(2) < dtInputStop.Value)
            {
                Common.MessageBoxEx.MessageBoxEx.Show("只允许查询时间间隔在2个月内的数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadData(dtInputStart.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtInputStop.Value.ToString("yyyy-MM-dd HH:mm:ss"));

        }


    }
}
