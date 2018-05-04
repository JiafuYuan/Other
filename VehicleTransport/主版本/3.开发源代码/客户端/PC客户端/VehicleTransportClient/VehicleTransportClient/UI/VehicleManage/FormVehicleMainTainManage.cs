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
using BLL=DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;

namespace VehicleTransportClient
{
    public partial class FormVehicleMainTainManage : Form
    {
        private string _tableName = "FormVehicleMainTainManage";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_VehicleMaintain _model = new DB_VehicleTransportManage.Model.m_VehicleMaintain();
        private BLL.m_Person bllPersonEx = new BLL.m_Person();
        private BLL.m_Vehicle bllVehicle = new BLL.m_Vehicle();
        public FormVehicleMainTainManage()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormVehicleMainTainManage_Load);
        }

        void FormVehicleMainTainManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
            if (_selectIndex >= 0)
            {
                if (dgvList.Rows[_selectIndex].Cells["OverTime"].Value.ToString().Length > 0)
                {
                    btnEdit.Visible = false;
                }
                else
                {
                    btnEdit.Visible = true;
                }
            }
        }

        public void LoadData()
        {
            List<DB_VehicleTransportManage.Model.m_VehicleMaintain> lst = new DB_VehicleTransportManage.BLL.m_VehicleMaintain().GetModelList("i_flag=0");

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            foreach (DB_VehicleTransportManage.Model.m_VehicleMaintain item in lst)
            {
                DateTime dateTime=new DateTime();
                string strEndTime = "";
                if (DateTime.TryParse(item.dt_EndDateTime, out dateTime))
                {
                    strEndTime = dateTime.ToString("yyyy年MM月dd日 HH时mm分ss秒");
                }

                int i = dgvList.Rows.Add(bllVehicle.GetVehicleName((int)item.VehicleID)[0], bllVehicle.GetVehicleName((int)item.VehicleID)[1], item.dt_BeginDateTime == null ? "" : item.dt_BeginDateTime.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"),
                     strEndTime, bllPersonEx.GetName((int)item.RecordPersonID), item.vc_PersonName, item.vc_Content, item.vc_Memo);
                    dgvList.Rows[i].Tag = item;
                
            }
            lblCount.Text = "共有" + dgvList.Rows.Count + "条车辆维护记录";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataSet dataSet = bllVehicle.DropDownSource("i_state in (0) ");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                new FormVehicleMainTain(null).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("未找到可以维护的车辆", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
           
        }

       

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_VehicleMaintain)dgvList.Rows[_selectIndex].Tag;
                new FormVehicleMainTainStop( _model).ShowDialog();
                LoadData();
               
            }
            else
            {
                MessageBoxEx.Show("请选择要结束维护的车辆", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();
            
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }

     
    }
}
