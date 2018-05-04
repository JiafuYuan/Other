using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
namespace VehicleTransportClient.UI
{
    public partial class FormReviewMgr : Form
    {
        BLL.v_Apply bllapply = new BLL.v_Apply();
        BLL.m_Apply bllmapply = new BLL.m_Apply();
        BLL.m_Plan_ApplyMaterie bllapplymater = new BLL.m_Plan_ApplyMaterie();
        BLL.m_Plan_ApplyVehicle bllapplycar = new BLL.m_Plan_ApplyVehicle();

        public FormReviewMgr(bool showtime)
        {
            InitializeComponent();
            if (showtime)
            {
                dtStart.Value = DateTime.Parse(DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd 00:00:00"));
                dtStop.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            }
        }

        private void btnreview_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                Model.v_Apply applymodel = (Model.v_Apply)dgvList.SelectedRows[0].Tag;

                int id = applymodel.ID;
                int i_IsUseMaterieApply = applymodel.i_IsUseMaterieApply.Value;
                int i_state = applymodel.i_State.Value;
                if (i_state == (int)EnumApplyState.NoPass || i_state == (int)EnumApplyState.Checked)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("该单据已经完成审批", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Model.m_Apply mapply = bllmapply.GetModel(id);
                    if (i_IsUseMaterieApply == 1)
                    {
                        List<Model.m_Plan_ApplyMaterie> listdetail = bllapplymater.GetModelList("applyid=" + id.ToString());
                        bool canrefuse = true;
                        if (i_state == (int)EnumApplyState.CheckPart)
                            canrefuse = false;
                        FormReviewMaterEdit frmreviewmater = new FormReviewMaterEdit(listdetail, mapply, canrefuse);
                        if (frmreviewmater.ShowDialog() == DialogResult.OK)
                        {
                            frmreviewmater.Close();
                            LoadData(DateTime.Parse(dtStart.Value.ToString("yyyy-MM-dd 00:00:00")), DateTime.Parse(dtStop.Value.ToString("yyyy-MM-dd 23:59:59")), (EnumApplyState)((ApplyState)cmbState.SelectedItem).Value);
                        }
                    }
                    else
                    {
                        List<Model.m_Plan_ApplyVehicle> listdetail = bllapplycar.GetModelList("applyid=" + id.ToString());
                        bool canrefuse = true;
                        if (i_state == (int)EnumApplyState.CheckPart)
                            canrefuse = false;
                        FormReviewCarEdit frmreviewcar = new FormReviewCarEdit(listdetail, mapply, canrefuse);
                        if (frmreviewcar.ShowDialog() == DialogResult.OK)
                        {
                            frmreviewcar.Close();
                            LoadData(DateTime.Parse(dtStart.Value.ToString("yyyy-MM-dd 00:00:00")), DateTime.Parse(dtStop.Value.ToString("yyyy-MM-dd 23:59:59")), (EnumApplyState)((ApplyState)cmbState.SelectedItem).Value);
                        }
                    }
                }
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("请选择要审核的单据");
            }

        }

        private void FormReviewMgr_Load(object sender, EventArgs e)
        {
           
            InitComboBoxApplyState();
            cmbState.SelectedIndex = 0;
            LoadData(dtStart.Value, dtStop.Value, (EnumApplyState)((ApplyState)cmbState.SelectedItem).Value);
           
        }
        //private void InitGrid()
        //{
        //    dgvList.Refresh();
        //    DataSet ds = bllapply.GetList("1=1 and (i_state=" + (int)EnumApplyState.WaitCheck + " or i_state=" + (int)EnumApplyState.CheckPart+") or i_state="+(int)EnumApplyState.NoPass+" or i_State="+(int)EnumApplyState.Checked);
        //    dgvList.DataSource = ds.Tables[0];

        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(DateTime.Parse(dtStart.Value.ToString("yyyy-MM-dd 00:00:00")), DateTime.Parse(dtStop.Value.ToString("yyyy-MM-dd 23:59:59")), (EnumApplyState)((ApplyState)cmbState.SelectedItem).Value);
        }

        public void LoadData(DateTime dateTimeStart, DateTime dateTimeStop, EnumApplyState applyState)
        {
            if (dateTimeStart.Year == 1 && dateTimeStop.Year == 1)
            {
                StringBuilder stringBuilder = new StringBuilder();

                if ((int)applyState != -2)
                {
                    stringBuilder.AppendFormat(" i_state={0}", (int)applyState);
                }
                else
                {
                    stringBuilder.AppendFormat(" i_state={0} or i_state={1}", (int)EnumApplyState.CheckPart, (int)EnumApplyState.WaitCheck);
                }
                dgvList.Rows.Clear();
                List<Model.v_Apply> list = bllapply.GetModelList(stringBuilder.ToString());
                list = (from applyentity in list orderby applyentity.ID descending select applyentity).ToList<Model.v_Apply>();
                for (int i = 0; i < list.Count; i++)
                {
                    dgvList.Rows.Add(false, list[i].dt_ApplyDateTime, list[i].deptname, list[i].username, list[i].vc_PlanUse, list[i].addressname, list[i].dt_arrive, list[i].statename);
                    dgvList.Rows[i].Tag = list[i];
                }
            }
            else
            {
                if (dateTimeStart <= dateTimeStop)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendFormat(" dt_ApplyDateTime>='{0}' and dt_ApplyDateTime<='{1}' ",
                        dateTimeStart.ToString("yyyy-MM-dd 00:00:00"), dateTimeStop.ToString("yyyy-MM-dd 23:59:59"));
                    if ((int)applyState != -2)
                    {
                        stringBuilder.AppendFormat(" and i_state={0}", (int)applyState);
                    }
                    else
                    {
                        stringBuilder.AppendFormat(" and (i_state={0} or i_state={1})", (int)EnumApplyState.CheckPart, (int)EnumApplyState.WaitCheck);
                    }
                    dgvList.Rows.Clear();
                    List<Model.v_Apply> list = bllapply.GetModelList(stringBuilder.ToString());
                    list = (from applyentity in list orderby applyentity.ID descending select applyentity).ToList<Model.v_Apply>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        dgvList.Rows.Add(false, list[i].dt_ApplyDateTime, list[i].deptname, list[i].username, list[i].vc_PlanUse, list[i].addressname, list[i].dt_arrive, list[i].statename);
                        dgvList.Rows[i].Tag = list[i];
                    }
                }
                else
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("开始时间必须在结束时间之前", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            dgvList.ClearSelection();

        }

        public void InitComboBoxApplyState()
        {

            cmbState.Items.Add(new ApplyState((EnumApplyState)(-2), "==请选择单据状态=="));

            cmbState.Items.Add(new ApplyState(EnumApplyState.WaitCheck, "待审核"));

            cmbState.Items.Add(new ApplyState(EnumApplyState.CheckPart, "已审部分"));

          
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                if (i == n)
                {
                    dgvList.Rows[i].Cells[0].Value = true;
                }
                else
                {
                    dgvList.Rows[i].Cells[0].Value = false;
                }
            }
        }
    }

    struct ApplyState
    {

        private object value;

        private string text;

        public ApplyState(object _value, string _text)
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
