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
using DevComponents.AdvTree;

namespace VehicleTransportClient
{
    public partial class FormDeptMaterielTypeReport : Form
    {
        private string _tableName = "FormDeptMaterielTypeReport";
        private int _selectIndex = -1;
        DB_VehicleTransportManage.BLL.m_Department bllDepartment = new m_Department();
        private DB_VehicleTransportManage.Model.m_Message _model = new DB_VehicleTransportManage.Model.m_Message();
        private DB_VehicleTransportManage.BLL.m_User bllUserEx = new m_User();
        private DataSet dataSet = null;
        AcNetUtilsManage acNetUtilsManage = new AcNetUtilsManage();
        private int _deptID = 0;
        private string _deptName = "";
        private string _dtStart = "";
        private string _dtStop = "";
        public FormDeptMaterielTypeReport()
        {
            InitializeComponent();
            InitCmbDuty();
            cmbDept.SelectedIndex = 0;
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            //Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormSystemLog_Load);
            cmbDept.Nodes[0].Expand();
            
        }

        void FormSystemLog_Load(object sender, EventArgs e)
        {
            dtInputStart.Value = DateTime.Parse(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00"));
            dtInputStop.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            btnSearch_Click(sender, e);
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData(DateTime dtStart, DateTime dtEnd, int DeptID)
        {
            DB_VehicleTransportManage.BLL.m_MaterielType bllMaterielType=new m_MaterielType();
            dataSet = bllMaterielType.RunProUpdateDept(dtStart.ToString("yyyy-MM-dd 00:00:00"), dtEnd.ToString("yyyy-MM-dd 23:59:59"), DeptID);
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
                    dgvList.Rows.Add(dataSet.Tables[0].Rows[i]["ApplyDepartmentName"], dataSet.Tables[0].Rows[i]["MaterielTypeCode"], dataSet.Tables[0].Rows[i]["MaterielTypeName"], 
                        dataSet.Tables[0].Rows[i]["counts"], dataSet.Tables[0].Rows[i]["MaterielTypeUnit"]);
                }
                
                lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条记录";
                _deptName = _deptID == 0 ? "所有部门" : bllDepartment.GetName(_deptID);
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
            if (cmbDept.SelectedIndex!=0)
            {
                _deptID = ((Myobj) cmbDept.SelectedNode.Tag).Id;
            }
            else
            {
                _deptID = 0;
            }
            if (dtInputStart.Value <= dtInputStop.Value)
            {
                if (dtInputStart.Value.AddMonths(2) >= dtInputStop.Value)
                {
                    LoadData(dtInputStart.Value,dtInputStop.Value, _deptID);
                }
                else
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("只允许查询两个月内的数据！", "提示", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("开始时间必须在结束时间之前！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            if (acNetUtilsManage.Init(System.Windows.Forms.Application.StartupPath + "\\Report", "DeptMaterielTypeMonth.apt"))
            {
                acNetUtilsManage.AddVariable("dtStart", _dtStart);
                acNetUtilsManage.AddVariable("dtStop", _dtStop);
                acNetUtilsManage.AddVariable("DeptName", _deptName);          
                acNetUtilsManage.FillDatasetToAC(dataSet, "DeptMaterielTypeMonth");
                acNetUtilsManage.Print();
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("未找到报表，请设计报表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            acNetUtilsManage.Init(System.Windows.Forms.Application.StartupPath + "\\Report", "DeptMaterielTypeMonth.apt");
            acNetUtilsManage.AddVariable("dtStart", _dtStart);
            acNetUtilsManage.AddVariable("dtStop", _dtStop);
            acNetUtilsManage.AddVariable("DeptName", _deptName);
            acNetUtilsManage.FillDatasetToAC(dataSet, "DeptMaterielTypeMonth");
            acNetUtilsManage.ShowDesigner();
        }
        public void InitCmbDuty()
        {
            Myobj obj = new Myobj();
            obj.Id = 0;
            obj.Vc_Name = "所有部门";
            Node node1 = new Node();
            node1.Text = obj.Vc_Name;
            node1.Tag = obj;
            cmbDept.Nodes.Add(node1);
            LoadCmboTree(node1);
        }
        public void LoadCmboTree(Node nd)
        {
            DataSet ds = new DataSet();
            ds = bllDepartment.GetList(" i_Flag=0 and ParentID=" + ((Myobj)nd.Tag).Id);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Myobj obj = new Myobj();
                obj.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                obj.Vc_Name = dt.Rows[i]["vc_Name"].ToString();
                Node node1 = new Node();
                node1.Text = obj.Vc_Name;
                node1.Tag = obj;
                nd.Nodes.Add(node1);
                LoadCmboTree(node1);
            }
        }
        private void GetNode(int id, Node pNode)
        {
            foreach (Node node in pNode.Nodes)
            {
                if (((Myobj)node.Tag).Id == id)
                {
                    cmbDept.SelectedNode = node;
                    break;
                }
                GetNode(id, node);

            }
        }

    }

    
}
