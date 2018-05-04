using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
namespace VehicleTransportClient
{
    public partial class FormPlanQuery : Form
    {
        private string _tableName = "FormPlanQuery";
        BLL.v_Apply bllapply = new BLL.v_Apply();
        BLL.m_User blluser = new BLL.m_User();
        BLL.m_Person bllperson = new BLL.m_Person();
        BLL.m_Plan_ApplyMaterie bllapplymater = new BLL.m_Plan_ApplyMaterie();
        BLL.m_Plan_ApplyVehicle bllapplycar = new BLL.m_Plan_ApplyVehicle();
        BLL.m_MaterielType bllmater = new BLL.m_MaterielType();
        BLL.m_VehicleType bllcartype = new BLL.m_VehicleType();
        BLL.v_Plan bllplan = new BLL.v_Plan();
        BLL.m_Department blldept = new BLL.m_Department();
        public FormPlanQuery()
        {
            InitializeComponent();
            if (Pub.FlowPath.Give == false)
            {
                dgvList.DelColumns("ColGiveDt");
                dgvList.DelColumns("ColGiveDeptname");
                dgvList.DelColumns("ColGivePlace");
            }
            else
            {
                dgvList.DelColumns("ColLoaddt");
            }
            if (Pub.FlowPath.Back == false)
            {
                dgvList.DelColumns("ColBackDeptment");
                dgvList.DelColumns("ColBackAddress");
                dgvList.DelColumns("ColBackDt");
            }
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }
        private void InitGrid(DateTime dtstart, DateTime dtend,string plancode,Common.Enum.EnumPlanState planstate)
        {
            dgvList.Rows.Clear();
            string strwhere = string.Format("dt_ArriveDestinationDateTime>='{0}' and dt_ArriveDestinationDateTime<='{1}' ", dtstart, dtend);
            if (string.IsNullOrEmpty(plancode) == false)
            {
                strwhere = strwhere + " and vc_PlanCode like '%" + plancode + "%'";
            }
            if ((int)planstate != -2)
            {
                strwhere = strwhere + " and i_State=" + (int)planstate + "";
            }
            List<Model.v_Plan> lst = bllplan.GetModelList(strwhere);
            if (lst == null)
                return;
            lst = (from plan in lst orderby plan.ID descending select plan).ToList<Model.v_Plan>();
            foreach (Model.v_Plan plan in lst)
            {
                Model.v_Apply apply = bllapply.GetModel(plan.ApplyID.Value);
                StringBuilder strbuild = new StringBuilder();
                if (apply.i_IsUseMaterieApply == (int)Common.Enum.EnumApplyType.Materie)
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
                        strbuild.AppendFormat(" " + cartype.vc_Name + ":" + applycar.i_Count+"(辆)");
                    }
                }
                List<object> listobject = new List<object>();
                listobject.Add(dgvList.Rows.Count + 1);
                listobject.Add(plan.vc_PlanCode);
                listobject.Add(apply.username);
                listobject.Add(plan.ApplyDepartmentName);
                listobject.Add(strbuild.ToString());
                listobject.Add(apply.addressname);
                listobject.Add(plan.dt_ArriveDestinationDateTime);
                if (Pub.FlowPath.Give)
                {
                    if (plan.dt_PlanGiveCarDateTime.Value.Year == 1900)
                        listobject.Add("");
                    else
                    {
                        listobject.Add(plan.dt_PlanGiveCarDateTime);
                    }
                    listobject.Add(plan.PlanGiveCarAddressName);
                    listobject.Add(plan.PlanGiveCarDepartmentName);
                }
                if (Pub.FlowPath.Give == false)
                {
                    if (plan.dt_PlanLoadDateTime.Value.Year == 1900)
                        listobject.Add("");
                    else
                    {
                        listobject.Add(plan.dt_PlanLoadDateTime);
                    }
                }
                listobject.Add(plan.PlanLoadAddressName);
                listobject.Add(plan.PlanLoadDepartmentName);

                if (Pub.FlowPath.Back)
                {
                    if (plan.dt_PlanBackDateTime.Value.Year == 1900)
                        listobject.Add("");
                    else
                    {
                        listobject.Add(plan.dt_PlanBackDateTime);
                    }
                    listobject.Add(plan.PlanBackAddressName);
                    listobject.Add(plan.PlanBackDepartmentName);
                }
                listobject.Add(plan.statename);
                listobject.Add("详情");
                listobject.Add("运输路线");
                int i = dgvList.Rows.Add(
                   listobject.ToArray()
                );
                dgvList.Rows[i].Tag = plan;

            }
            lbcount.Text = "总记录" + dgvList.Rows.Count.ToString();
        }

        private void FormPlanQuery_Load(object sender, EventArgs e)
        {
            InitComboBoxState();
            dtStart.Value = DateTime.Parse(DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd 00:00:00"));
            dtStop.Value = DateTime.Parse(DateTime.Now.AddDays(30).ToString("yyyy-MM-dd 23:59:59"));
            InitGrid(DateTime.Parse(dtStart.Value.ToString("yyyy-MM-dd 00:00:00")), DateTime.Parse(dtStop.Value.ToString("yyyy-MM-dd 23:59:59")), txtplancode.Text, (Common.Enum.EnumPlanState)((PlanState)cmbState.SelectedItem).Value);
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.Columns[e.ColumnIndex].Name == "ColPlanDetail")
            {
                if (dgvList.SelectedRows.Count > 0)
                {
                    Model.v_Plan plan = (Model.v_Plan)dgvList.SelectedRows[0].Tag;

                    FormPlanDetailQuery frm1 = new FormPlanDetailQuery(plan.ID);
                    frm1.ShowDialog();
                }
            }
            if (dgvList.Columns[e.ColumnIndex].Name == "ColPlanTrans")
            {
                if (dgvList.SelectedRows.Count > 0)
                {
                    Model.v_Plan plan = (Model.v_Plan)dgvList.SelectedRows[0].Tag;
                    if (plan.i_State == (int)Common.Enum.EnumPlanState.Checked || plan.i_State == (int)Common.Enum.EnumPlanState.Gived)
                    {
                        Common.MessageBoxEx.MessageBoxEx.Show("该订单暂无车辆运输");
                        return;
                    }
                    else if (plan.i_State == (int)Common.Enum.EnumPlanState.Complete)
                    {
                        UI.FrmQueryPlanCar frmqry = new UI.FrmQueryPlanCar(plan.ID);
                        frmqry.ShowDialog();
                    }
                    else
                    {
                        UI.FrmQueryGIS frmgis = new UI.FrmQueryGIS(plan.ID);
                        DialogResult bresult=frmgis.ShowDialog();
                        if (bresult == DialogResult.Ignore)
                        {
                            Common.MessageBoxEx.MessageBoxEx.Show("该运单下的车辆暂时都无法定位");
                            frmgis.Close();
                            return;
                        }
                        else
                        {
                            frmgis.Close();
                            return;
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitGrid(DateTime.Parse(dtStart.Value.ToString("yyyy-MM-dd 00:00:00")), DateTime.Parse(dtStop.Value.ToString("yyyy-MM-dd 23:59:59")), txtplancode.Text, (Common.Enum.EnumPlanState)((PlanState)cmbState.SelectedItem).Value);
        }
        public void InitComboBoxState()
        {

            cmbState.Items.Add(new PlanState((Common.Enum.EnumPlanState)(-2), "==请选择单据状态=="));

            cmbState.Items.Add(new PlanState(Common.Enum.EnumPlanState.Checked, "已审核"));
            if (Pub.FlowPath.Give)
            {
                cmbState.Items.Add(new PlanState(Common.Enum.EnumPlanState.Gived, "已供车"));
            }
            if (Pub.FlowPath.Load)
            {
                cmbState.Items.Add(new PlanState(Common.Enum.EnumPlanState.Loaded, "已装车"));
            }
            if (Pub.FlowPath.Handover)
            {
                cmbState.Items.Add(new PlanState(Common.Enum.EnumPlanState.Transporting, "运输中"));
            }
            if (Pub.FlowPath.UnLoad && Pub.FlowPath.Back==true)
            {
                cmbState.Items.Add(new PlanState(Common.Enum.EnumPlanState.UnLoaded, "已卸车"));
            }
            cmbState.Items.Add(new PlanState(Common.Enum.EnumPlanState.Complete, "已完成"));
            cmbState.SelectedIndex = 0;


        }

        private void btnstyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }
    }
    struct PlanState
    {

        private object value;

        private string text;

        public PlanState(object _value, string _text)
        {

            value = _value;

            text = _text;

        }

        public string Text
        {

            get { return text; }

        }

        public object Value
        {

            get { return value; }

        }

        public override string ToString()
        {

            return text;

        }

    }
}
