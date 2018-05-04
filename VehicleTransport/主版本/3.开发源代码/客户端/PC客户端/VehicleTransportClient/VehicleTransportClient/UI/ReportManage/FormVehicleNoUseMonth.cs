using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using Common.MessageBoxEx;
using DB_VehicleTransportManage;
using DB_VehicleTransportManage.BLL;
using DevComponents.DotNetBar;
using VehicleTransportClient.Com;

namespace VehicleTransportClient
{
    public partial class FormVehicleNoUseMonth : Form
    {
        private string _tableName = "FormVehicleNoUseMonth";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_Message _model = new DB_VehicleTransportManage.Model.m_Message();
        private DB_VehicleTransportManage.BLL.m_User bllUserEx = new m_User();
        private DataSet dataSet = null;
        AcNetUtilsManage acNetUtilsManage = new AcNetUtilsManage();
        private string _dtStart = "";
        private string _dtStop = "";
        public FormVehicleNoUseMonth()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            //Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormSystemLog_Load);

        }

        private void FormSystemLog_Load(object sender, EventArgs e)
        {
            dtInputStart.Value = DateTime.Parse(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00"));
            dtInputStop.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            btnSearch_Click(sender, e);
        }

       

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData(DateTime dtStart, DateTime dtEnd)
        {
            DB_VehicleTransportManage.BLL.data_VehicleAlarm bllVehicleAlarm = new data_VehicleAlarm();
            dataSet = bllVehicleAlarm.RunProUpdate(dtStart.ToString("yyyy-MM-dd 00:00:00"),
                dtEnd.ToString("yyyy-MM-dd 23:59:59"));

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                btnDesign.Enabled = true;
                btnPrint.Enabled = true;
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    dgvList.Rows.Add(dataSet.Tables[0].Rows[i]["vc_Code"], dataSet.Tables[0].Rows[i]["vc_Name"], dataSet.Tables[0].Rows[i]["Counts"]);
                }

                lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条记录";
                _dtStart = dtStart.ToString("yyyy-MM-dd");
                _dtStop = dtEnd.ToString("yyyy-MM-dd");
            }
            else
            {
                btnDesign.Enabled = false;
                btnPrint.Enabled = false;
            }
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
            if (dtInputStart.Value <= dtInputStop.Value)
            {
                if (dtInputStart.Value.AddMonths(2) >= dtInputStop.Value)
                {
                    LoadData(dtInputStart.Value, dtInputStop.Value);
                }
                else
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("只允许查询两个月内的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("开始时间必须在结束时间之前！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDesign_Click(object sender, EventArgs e)
        {
            acNetUtilsManage.Init(System.Windows.Forms.Application.StartupPath + "\\Report", "VehicleNoUseMonth.apt");
            acNetUtilsManage.FillDatasetToAC(dataSet, "VehicleNoUseMonth");
            acNetUtilsManage.AddVariable("dtStart", _dtStart);
            acNetUtilsManage.AddVariable("dtStop", _dtStop);
            acNetUtilsManage.ShowDesigner();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (acNetUtilsManage.Init(System.Windows.Forms.Application.StartupPath + "\\Report", "VehicleNoUseMonth.apt"))
            {
                acNetUtilsManage.AddVariable("dtStart", _dtStart);
                acNetUtilsManage.AddVariable("dtStop", _dtStop);
                acNetUtilsManage.FillDatasetToAC(dataSet, "VehicleNoUseMonth");
                acNetUtilsManage.Print();
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("未找到报表，请设计报表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



    }


}
