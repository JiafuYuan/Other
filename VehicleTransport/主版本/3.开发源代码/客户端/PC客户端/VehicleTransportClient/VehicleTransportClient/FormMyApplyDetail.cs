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
    public partial class FormMyApplyDetail : Common.frmBase
    {
        private BLL.v_Plan bllplan = new BLL.v_Plan();
        public int planid = 0;
        public FormMyApplyDetail()
        {
            InitializeComponent();
        }
        public FormMyApplyDetail(int applyid)
        {
            InitializeComponent();
            List<Model.v_Plan> listplan = bllplan.GetModelList("applyid=" + applyid);
            foreach (Model.v_Plan plan in listplan)
            {
                int i=dgvList.Rows.Add(
                    dgvList.Rows.Count+1,
                    plan.vc_PlanCode,
                    plan.CheckPersonName,
                    plan.dt_CheckDateTime,
                    plan.statename,
                    "详情",
                    "运输路线"
                    );
                dgvList.Rows[i].Tag = plan;
            }
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (dgvList.SelectedRows.Count > 0)
                {
                    Model.v_Plan plan = (Model.v_Plan)dgvList.SelectedRows[0].Tag;
                    planid = plan.ID;
                    FormPlanDetailQuery frm1 = new FormPlanDetailQuery(planid);
                    //    //frmdetail.Close();
                        frm1.ShowDialog();

                }
            }
            else if (e.ColumnIndex == 6)
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
                    frmgis.ShowDialog();
                }
            }
        }
    }
}
