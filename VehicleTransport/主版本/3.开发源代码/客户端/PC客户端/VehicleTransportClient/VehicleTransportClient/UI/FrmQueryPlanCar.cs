using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL=DB_VehicleTransportManage.BLL;
using Model=DB_VehicleTransportManage.Model;
namespace VehicleTransportClient.UI
{
    public partial class FrmQueryPlanCar : Common.frmBase
    {
        int _Planid = 0;
        BLL.m_VehiclePlanDetail bllplancar = new BLL.m_VehiclePlanDetail();
        BLL.m_Plan bllplan = new BLL.m_Plan();
        BLL.m_Plan_Handover bllhandover = new BLL.m_Plan_Handover();
        BLL.m_Plan_UnLoad bllunload = new BLL.m_Plan_UnLoad();
        BLL.m_Plan_BackVehicle bllback = new BLL.m_Plan_BackVehicle();
        BLL.m_Localizer blllocal = new BLL.m_Localizer();
        BLL.m_Vehicle bllcar = new BLL.m_Vehicle();
        BLL.m_Address blladress = new BLL.m_Address();
        public FrmQueryPlanCar(int planid)
        {
            InitializeComponent();
            _Planid = planid;
        }
        private void InitGrid(int carid)
        {
                dgvList.Rows.Clear();
                DateTime dtstart = DateTime.Parse("1900-01-01");
                DateTime dtend=DateTime.Parse("1900-01-01");
                Model.m_Plan planentity = bllplan.GetModel(_Planid);
                if (planentity != null)
                {
                    dtstart = planentity.dt_RealLoadDateTime.Value;
                }
                //交接车
                List<Model.m_Plan_Handover> listhandentity = bllhandover.GetModelList("PlanID=" + _Planid + " and VehicleID="+carid);
                if (listhandentity != null && listhandentity.Count>0)
                {
                    listhandentity = (from handentity in listhandentity orderby handentity.dt_HandoverDateTime descending select handentity).ToList<Model.m_Plan_Handover>();
                    dtend = listhandentity[0].dt_HandoverDateTime.Value;
                }
                //卸车
                List<Model.m_Plan_UnLoad> listunload = bllunload.GetModelList("PlanID=" + _Planid + " and VehicleID=" +carid);
                if (listunload != null && listunload.Count > 0)
                {
                    listunload = (from unloadentity in listunload orderby unloadentity.dt_DateTime descending select unloadentity).ToList<Model.m_Plan_UnLoad>();
                    if (dtend<listunload[0].dt_DateTime)
                    {
                        dtend = listunload[0].dt_DateTime.Value;
                    }

                }
                //还车
                List<Model.m_Plan_BackVehicle> listback = bllback.GetModelList("PlanID=" + _Planid + " and VehicleID=" + carid);
                if (listback != null && listback.Count > 0)
                {
                    listback = (from backentity in listback orderby backentity.dt_DateTime descending select backentity).ToList<Model.m_Plan_BackVehicle>();
                    if (dtend < listback[0].dt_DateTime)
                    {
                        dtend = listback[0].dt_DateTime.Value;
                    }
                }
                int startmonth = dtstart.Month;
                int endmonth = dtend.Month;
                List<string> listtabname = new List<string>();
                if (dtstart.Year>dtend.Year)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("该车定位时间错误");
                }
                else if (dtstart.Year == dtend.Year)
                {
                    if (startmonth > endmonth)
                    {
                        Common.MessageBoxEx.MessageBoxEx.Show("该车定位时间错误");
                    }
                    else if (startmonth == endmonth)
                    {
                        listtabname.Add("VT_Track_" + dtstart.Year + "_" + startmonth.ToString().PadLeft(2, '0'));
                    }
                    else
                    {
                        for (int i = startmonth; i < endmonth + 1; i++)
                        {
                            string tmp = i.ToString().PadLeft(2, '0');
                            string tabname = "VT_Track_" + dtstart.Year + "_" + tmp;
                            listtabname.Add(tabname);
                        }
                    }
                }
                else
                {
                    int month = startmonth;
                    for (int i = dtstart.Year; i < dtend.Year + 1; i++)
                    {
                        int bmonth = 13;
                        if (i == dtend.Year)
                            bmonth = endmonth;
                        for (int j = month; j < bmonth; j++)
                        {
                            string tmp = j.ToString().PadLeft(2, '0');
                            string tabname = "VT_Track_" + i + "_" + tmp;
                            listtabname.Add(tabname);
                            if (j == 12)
                            {
                                month = 1;
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < listtabname.Count; i++)
                {
                    DataTable dt = blllocal.GetCarLocal(carid.ToString(), dtstart, dtend, listtabname[i]);
                    if (dt == null)
                        continue;
                    string carcode=bllcar.GetModel(carid).vc_Code;
                    for(int j=0;j<dt.Rows.Count;j++)
                    {
                        List<Model.m_Address> listaddress=blladress.GetModelList("LocalizerStationID="+dt.Rows[j]["KJ222LocalizerID"].ToString());
                        if (listaddress.Count==0)
                            continue;
                        dgvList.Rows.Add(dgvList.Rows.Count, carcode, listaddress[0].vc_Name, dt.Rows[j]["dt_InTime"]);
                    }
                }
        }
        private void InitCom()
        {
             List<int> listcar = new List<int>();
             cmbcar.SelectedIndex = -1;
             DataTable dt = bllplancar.GetPlanCar(_Planid);
             cmbcar.DataSource = dt;
             cmbcar.DisplayMember = "carcode";
             cmbcar.ValueMember = "VehicleID";
        }
        private void FrmQueryPlanCar_Load(object sender, EventArgs e)
        {
            InitCom();
        }

        private void cmbcar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView dr = (DataRowView)cmbcar.SelectedItem;
            if (dr!=null)
            {
                InitGrid(int.Parse(dr["VehicleID"].ToString()));
            }
         
        }
    

     
    }
}
