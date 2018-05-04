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
using Common.Enum;
namespace VehicleTransportClient.UI
{
    public partial class FormSupplyCarMgr : Form
    {
        BLL.v_Plan bllplan = new BLL.v_Plan();
        public FormSupplyCarMgr()
        {
            InitializeComponent();
        }

    

        private void btnreview_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                Model.v_Plan modelPlan = (DB_VehicleTransportManage.Model.v_Plan)dgvList.SelectedRows[0].Tag;
                FormSupplyCar frmedit = new FormSupplyCar(modelPlan);
                DialogResult diaresult = frmedit.ShowDialog();
                if (diaresult == DialogResult.OK)
                {
                    LoadData(DateTime.Parse(dtStart.Value.ToString("yyyy-MM-dd 00:00:00")), DateTime.Parse(dtStop.Value.ToString("yyyy-MM-dd 23:59:59")), txtplancode.Text);
                }
              
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("请选择记录");
            }

           
        }
     
      

        private void FormSupplyCarMgr_Load(object sender, EventArgs e)
        {
            dtStart.Value = DateTime.Parse(DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd 00:00:00"));
            dtStop.Value = DateTime.Parse(DateTime.Now.AddDays(30).ToString("yyyy-MM-dd 23:59:59"));
            LoadData(dtStart.Value,dtStop.Value, txtplancode.Text);
        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            LoadData(DateTime.Parse(dtStart.Value.ToString("yyyy-MM-dd 00:00:00")), DateTime.Parse(dtStop.Value.ToString("yyyy-MM-dd 23:59:59")),txtplancode.Text);
        }
        public void LoadData(DateTime dateTimeStart, DateTime dateTimeStop, string plancode)
        {
            if (dateTimeStart <= dateTimeStop)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat(" dt_ArriveDestinationDateTime>='{0}' and dt_ArriveDestinationDateTime<='{1}' ",
                    dateTimeStart.ToString("yyyy-MM-dd 00:00:00"), dateTimeStop.ToString("yyyy-MM-dd 23:59:59"));
                stringBuilder.AppendFormat(" and (i_state={0})", (int)EnumPlanState.Checked);
                if (string.IsNullOrEmpty(plancode) == false)
                {
                    stringBuilder.AppendFormat(" and vc_plancode like '%{0}%'", plancode);
                }

                List<DB_VehicleTransportManage.Model.v_Plan> lst =
                   new DB_VehicleTransportManage.BLL.v_Plan().GetModelList(stringBuilder.ToString());
                lst = (from planentity in lst orderby planentity.ID descending select planentity).ToList<Model.v_Plan>();
                dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvList.AllowUserToAddRows = false;
                dgvList.ReadOnly = true;

                dgvList.Rows.Clear();
                foreach (DB_VehicleTransportManage.Model.v_Plan item in lst)
                {
                    string dt="";
                    if (item.dt_PlanGiveCarDateTime.Value.Year != 1900)
                        dt = item.dt_PlanGiveCarDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        
                    int i = dgvList.Rows.Add(false, item.vc_PlanCode, item.ApplyDepartmentName, item.ApplyPersonName, item.ArriveDestinationAddressName, item.dt_ArriveDestinationDateTime, item.PlanGiveCarDepartmentName, item.PlanGiveCarAddressName,dt);
                    dgvList.Rows[i].Tag = item;
                }
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("开始时间必须在结束时间之前", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

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
    struct CheckState
    {
        private object value;

        private string text;

        public CheckState(object _value, string _text)
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
