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
    public partial class FormVehicleStatisticsReport : Form
    {
        private string _tableName = "FormVehicleStatisticsReport";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_Message _model = new DB_VehicleTransportManage.Model.m_Message();
        private DB_VehicleTransportManage.BLL.m_User bllUserEx = new m_User();
        private DataSet dataSet = null;
        AcNetUtilsManage acNetUtilsManage = new AcNetUtilsManage();
        public FormVehicleStatisticsReport()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            //Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormSystemLog_Load);
            
        }

        void FormSystemLog_Load(object sender, EventArgs e)
        {
           
            btnSearch_Click(sender, e);
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData()
        {
            DB_VehicleTransportManage.BLL.m_Vehicle bllVehicle=new m_Vehicle();
            dataSet = bllVehicle.RunProUpdateVehicleAddress();
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            this.dgvList.AutoGenerateColumns = true;
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                btnDesignreport.Enabled = true;
                btnPrintreport.Enabled = true;
                dgvList.DataSource = dataSet.Tables[0];
                lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条记录";
            }
            else
            {
                btnDesignreport.Enabled = false;
                btnPrintreport.Enabled = false;
                dgvList.DataSource = null;
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
            LoadData();
        }
        
        private void btnDesign_Click(object sender, EventArgs e)
        {
            acNetUtilsManage.Init(System.Windows.Forms.Application.StartupPath + "\\Report", "VehicleAddress.apt");
            acNetUtilsManage.AddVariable("dtTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            acNetUtilsManage.FillDatasetToAC(dataSet, "VehicleAddress");
            acNetUtilsManage.ShowDesigner();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (acNetUtilsManage.Init(System.Windows.Forms.Application.StartupPath + "\\Report", "VehicleAddress.apt"))
            {
                acNetUtilsManage.AddVariable("dtTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                acNetUtilsManage.FillDatasetToAC(dataSet, "VehicleAddress");
                acNetUtilsManage.Print();
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("未找到报表，请设计报表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

   

    }

    
}
