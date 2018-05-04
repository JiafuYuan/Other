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
    public partial class FormMaterielTypeMonth : Form
    {
        private string _tableName = "FormMaterielTypeMonth";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_Message _model = new DB_VehicleTransportManage.Model.m_Message();
        private DB_VehicleTransportManage.BLL.m_User bllUserEx = new m_User();
        private DataSet dataSet = null;
        AcNetUtilsManage acNetUtilsManage = new AcNetUtilsManage();
        public FormMaterielTypeMonth()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormSystemLog_Load);
            
        }

        void FormSystemLog_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 13; i++)
            {
                cmbYear.Items.Add(DateTime.Now.Year+1 - i);
                cmbMonth.Items.Add(i);
            }
           
            cmbYear.Text = DateTime.Now.Year.ToString();
            cmbMonth.Text = DateTime.Now.Month.ToString();
            btnSearch_Click(sender, e);
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData(string dtStart)
        {
            DB_VehicleTransportManage.BLL.m_MaterielType bllMaterielType=new m_MaterielType();
            dataSet = bllMaterielType.RunProUpdate(dtStart);
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
                    dgvList.Rows.Add(dataSet.Tables[0].Rows[i]["MaterielTypeCode"], dataSet.Tables[0].Rows[i]["MaterielTypeName"],
                         dataSet.Tables[0].Rows[i]["counts"], dataSet.Tables[0].Rows[i]["MaterielTypeUnit"]);
                }
                
                lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条记录";
               
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
            LoadData(String.Format("{0}-{1}-01 00:00:01", cmbYear.SelectedItem, cmbMonth.SelectedItem));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (acNetUtilsManage.Init(System.Windows.Forms.Application.StartupPath + "\\Report", "MaterielTypeMonth.apt"))
            {
                acNetUtilsManage.AddVariable("dataMonth", String.Format("{0}年{1}月", cmbYear.SelectedItem, cmbMonth.SelectedItem));
                acNetUtilsManage.FillDatasetToAC(dataSet, "MaterielTypeMonth");
                acNetUtilsManage.Print();
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("未找到报表，请设计报表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            acNetUtilsManage.Init(System.Windows.Forms.Application.StartupPath + "\\Report", "MaterielTypeMonth.apt");
            acNetUtilsManage.FillDatasetToAC(dataSet, "MaterielTypeMonth");
            acNetUtilsManage.AddVariable("dataMonth",
                String.Format("{0}年{1}月", cmbYear.SelectedItem, cmbMonth.SelectedItem));
            acNetUtilsManage.ShowDesigner();
        }

   

    }

    
}
