using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Forms;
using Common.Enum;
using Common.MessageBoxEx;
using DB_VehicleTransportManage;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using VehicleTransportClient.Com;
using MessageBoxEx = Common.MessageBoxEx.MessageBoxEx;

namespace VehicleTransportClient
{
    public partial class FormCheckReport : Form
    {
        private string _tableName = "FormCheckReport";
        private int _selectIndex = -1;
        private string _planCode = "";
        private string _deptName = "";
        private string _dtStart = "";
        private string _dtStop = "";
        private BLL.m_Department bllDepartment = new BLL.m_Department();
        private BLL.v_Apply bllapply = new BLL.v_Apply();
        private BLL.m_Plan_ApplyMaterie bllapplymater = new BLL.m_Plan_ApplyMaterie();
        private BLL.m_Plan_ApplyVehicle bllapplycar = new BLL.m_Plan_ApplyVehicle();
        private BLL.m_MaterielType bllmater = new BLL.m_MaterielType();
        private BLL.m_VehicleType bllcartype = new BLL.m_VehicleType();
        private DataSet dataSet = null;
        AcNetUtilsManage acNetUtilsManage = new AcNetUtilsManage();
        private string reportPath = "";
        private int _deptID = 0;
        
        public FormCheckReport()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
          
            InitCmbDuty();
            cmbDept.SelectedIndex = 0;
            cmbDept.Nodes[0].Expand();
            dtInputStart.Value = DateTime.Parse(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00"));
            dtInputStop.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));

            if (Pub.FlowPath.Give == false)
            {
                dgvList.DelColumns("计划供车部门");
                dgvList.DelColumns("计划供车地点");
                dgvList.DelColumns("计划供车时间");
                reportPath = "CheckreportBase.apt";
                _tableName = "FormCheckReportNoGive";
            }
            else
            {
                reportPath = "Checkreport.apt";
            }
            Pub.StyleManager.SetGridStyle(_tableName, dgvList);
            btnSearch_Click(null,null);
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData(DateTime dateTimeStart, DateTime dateTimeStop, string plancode, int deptID)
        {
            if (dateTimeStart <= dateTimeStop)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat(" dt_CheckDateTime>='{0}' and dt_CheckDateTime<='{1}' ",
                    dateTimeStart.ToString("yyyy-MM-dd 00:00:00"), dateTimeStop.ToString("yyyy-MM-dd 23:59:59"));
                stringBuilder.AppendFormat(" and (i_state={0})", (int)EnumPlanState.Checked);
                if (string.IsNullOrEmpty(plancode) == false)
                {
                    stringBuilder.AppendFormat(" and vc_plancode like '%{0}%'", plancode);
                }
                if (deptID!=0)
                {
                    stringBuilder.AppendFormat(" and ApplyDepartmentID ={0}", deptID);
                }
                List<Model.v_Plan> lst =
                   new BLL.v_Plan().GetModelList(stringBuilder.ToString());
                lst = (from planentity in lst orderby planentity.dt_ArriveDestinationDateTime descending select planentity).ToList<Model.v_Plan>();
                dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvList.AllowUserToAddRows = false;
                dgvList.ReadOnly = true;

                dgvList.Rows.Clear();
                foreach (Model.v_Plan item in lst)
                {
                    Model.v_Apply apply = bllapply.GetModel(item.ApplyID.Value);
                    StringBuilder strbuild = new StringBuilder();
                    if (apply.i_IsUseMaterieApply == (int)EnumApplyType.Materie)
                    {
                        List<Model.m_Plan_ApplyMaterie> listmater = bllapplymater.GetModelList("applyid=" + apply.ID);
                        foreach (Model.m_Plan_ApplyMaterie applymater in listmater)
                        {
                            Model.m_MaterielType materentity = bllmater.GetModel(applymater.MaterieTypeID.Value);
                            strbuild.AppendFormat(" " + materentity.vc_Name + ":" + applymater.n_Count + "(" + materentity.vc_Unit + ")");
                        }
                    }
                    else
                    {
                        List<Model.m_Plan_ApplyVehicle> listcar = bllapplycar.GetModelList("applyid=" + apply.ID);
                        foreach (Model.m_Plan_ApplyVehicle applycar in listcar)
                        {
                            Model.m_VehicleType cartype = bllcartype.GetModel(applycar.VehicleTypeID.Value);
                            strbuild.AppendFormat(" " + cartype.vc_Name + ":" + applycar.i_Count + "(辆)");
                        }
                    }
                    string dt = "";
                    if (item.dt_PlanGiveCarDateTime.Value.Year != 1900)
                        dt = item.dt_PlanGiveCarDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                   
                    int i = dgvList.Rows.Add(item.vc_PlanCode, item.dt_CheckDateTime, item.ApplyDepartmentName, item.ApplyPersonName,strbuild.ToString(), item.ArriveDestinationAddressName, item.dt_ArriveDestinationDateTime, item.PlanGiveCarDepartmentName, item.PlanGiveCarAddressName, dt);
                    dgvList.Rows[i].Tag = item;
              
                }
                _planCode = plancode == "" ? "所有单号" : plancode;
                _deptName = _deptID == 0 ? "所有部门" : bllDepartment.GetName(_deptID);
                _dtStart = dateTimeStart.ToString("yyyy-MM-dd");
                _dtStop = dateTimeStop.ToString("yyyy-MM-dd");
                lblCount.Text = "共有" + dgvList.Rows.Count + "条已审核记录";
            }
            else
            {
                MessageBoxEx.Show("开始时间必须在结束时间之前", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
      
        private void btnStyle_Click(object sender, EventArgs e)
        {
            GridStyleForm gFrom = new GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();

            Pub.StyleManager.SetGridStyle(_tableName, dgvList);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbDept!=null&&cmbDept.SelectedIndex != 0)
            {
                _deptID = ((Myobj) cmbDept.SelectedNode.Tag).Id;
            }
            else
            {
                _deptID = 0;
            }
          
                if (dtInputStart.Value.AddMonths(2) >= dtInputStop.Value)
                {
                    LoadData(dtInputStart.Value, dtInputStop.Value, txtplancode.Text, _deptID);
                }
                else
                {
                    MessageBoxEx.Show("只允许查询两个月内的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           
            
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            acNetUtilsManage.Init(Application.StartupPath + "\\Report", reportPath);
            acNetUtilsManage.AddVariable("dtStart", _dtStart);
            acNetUtilsManage.AddVariable("dtStop", _dtStop);
            acNetUtilsManage.AddVariable("DeptName", _deptName);
            acNetUtilsManage.AddVariable("planCode", _planCode); 
            acNetUtilsManage.FillDataTableToAcFromGridView(dgvList, "Checkreport");
            acNetUtilsManage.ShowDesigner();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (acNetUtilsManage.Init(Application.StartupPath + "\\Report", reportPath))
            {
                acNetUtilsManage.AddVariable("dtStart", _dtStart);
                acNetUtilsManage.AddVariable("dtStop", _dtStop);
                acNetUtilsManage.AddVariable("DeptName", _deptName);
                acNetUtilsManage.AddVariable("planCode", _planCode); 
                acNetUtilsManage.FillDataTableToAcFromGridView(dgvList, "Checkreport");
                acNetUtilsManage.Print();
            }
            else
            {
                MessageBoxEx.Show("未找到报表，请设计报表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
