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
    public partial class FormBackCarMgr : Form
    {
      
        BLL.v_Plan bllplan = new BLL.v_Plan();

        public FormBackCarMgr()
        {
            InitializeComponent();
        }

        private void btnreview_Click(object sender, EventArgs e)
        {
            FormBackCar frmedit = new FormBackCar();
            frmedit.ShowDialog();
            InitGrid(DateTime.Parse(dtStart.Value.ToString("yyyy-MM-dd 00:00:00")), DateTime.Parse(dtStop.Value.ToString("yyyy-MM-dd 23:59:59")), txtplancode.Text);
        }
        private void InitGrid(DateTime dateTimeStart, DateTime dateTimeStop, string plancode)
        {
            if (dateTimeStart <= dateTimeStop)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat(" dt_ArriveDestinationDateTime>='{0}' and dt_ArriveDestinationDateTime<='{1}' ",
                    dateTimeStart.ToString("yyyy-MM-dd 00:00:00"), dateTimeStop.ToString("yyyy-MM-dd 23:59:59"));
                stringBuilder.AppendFormat(" and (i_state=" + (int)Common.Enum.EnumPlanState.Complete +  ")");


                if (string.IsNullOrEmpty(plancode) == false)
                {
                    stringBuilder.AppendFormat(" and vc_plancode like '%{0}%'", plancode);
                }
                dgvList.Rows.Clear();
                List<Model.v_Plan> lst = bllplan.GetModelList(stringBuilder.ToString());
                lst = (from planentity in lst orderby planentity.ID descending select planentity).ToList<Model.v_Plan>();
                int index = 1;
                foreach (DB_VehicleTransportManage.Model.v_Plan item in lst)
                {
                    int i = dgvList.Rows.Add(index,item.vc_PlanCode, item.ApplyDepartmentName, item.ApplyPersonName, item.ArriveDestinationAddressName, item.dt_ArriveDestinationDateTime, item.statename);
                    dgvList.Rows[i].Tag = item;
                    index++;
                }
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("开始时间必须在结束时间之前", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
       
        private void FormTransferCarMgr_Load(object sender, EventArgs e)
        {
            try
            {
                dtStart.Value = DateTime.Parse(DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd 00:00:00"));
                dtStop.Value = DateTime.Parse(DateTime.Now.AddDays(30).ToString("yyyy-MM-dd 23:59:59"));
                if (Pub.IsDBOnline)
                {
                    InitGrid(dtStart.Value, dtStop.Value, txtplancode.Text);
                }
            }
            catch { }
        }

        private void btnquery_Click(object sender, EventArgs e)
        {
            InitGrid(DateTime.Parse(dtStart.Value.ToString("yyyy-MM-dd 00:00:00")), DateTime.Parse(dtStop.Value.ToString("yyyy-MM-dd 23:59:59")), txtplancode.Text);
        }

       
    }
}
