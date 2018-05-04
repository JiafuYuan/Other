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
    public partial class FormPlanDetailQuery :Common.frmBase
    {
        private BLL.m_Plan_CheckVehicle bllcheck = new BLL.m_Plan_CheckVehicle();
        private BLL.m_MaterielType bllmater = new BLL.m_MaterielType();
        private BLL.m_VehicleType bllcartype = new BLL.m_VehicleType();
        private BLL.m_Plan_GiveVehicle bllgiven = new BLL.m_Plan_GiveVehicle();
        private BLL.m_Plan_Load bllload = new BLL.m_Plan_Load();
        private BLL.m_Vehicle bllcar = new BLL.m_Vehicle();
        BLL.v_handover bllhandover = new BLL.v_handover();
        BLL.v_unload bllunload = new BLL.v_unload();
        BLL.m_Plan_UnLoad bllmunload = new BLL.m_Plan_UnLoad();
        BLL.m_Plan_BackVehicle bllback = new BLL.m_Plan_BackVehicle();
        BLL.v_Plan bllplan = new BLL.v_Plan();
        BLL.m_Person bllperson = new BLL.m_Person();
        BLL.m_Apply bllapply = new BLL.m_Apply();
        BLL.m_Address blladress = new BLL.m_Address();
        private int _height=50;
        public FormPlanDetailQuery()
        {
            InitializeComponent();
        }
        
        int _planid = 0;

        public FormPlanDetailQuery(int planid)
        {
            InitializeComponent();
            _planid = planid;
            InitGrid();
        }

        private void InitGrid()
        {
            int k = 1;
            Model.v_Plan plan = bllplan.GetModel(_planid);
            this.FormTitle = "运单号:" + plan.vc_PlanCode+"    "+"当前状态:"+plan.statename;
            //审核
            List<Model.m_Plan_CheckVehicle> listcheck = bllcheck.GetModelList("PlanID=" + _planid);
            Model.m_Apply applyentity = bllapply.GetModel(plan.ApplyID.Value);
            if (applyentity.i_IsUseMaterieApply == (int)Common.Enum.EnumApplyType.Vehicle)
            {
                dgcheck.Columns.Remove("colname");
                dgcheck.Columns.Remove("colchecknumber");
                foreach (Model.m_Plan_CheckVehicle model in listcheck)
                {
                    panelCheckMain.TitleText = "审核人 :" + plan.CheckPersonName.Trim().PadRight(20, ' ') + "审核时间:" + plan.dt_CheckDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    int i = dgcheck.Rows.Add(
                        dgcheck.Rows.Count + 1,
                        bllcartype.GetModel(model.VehicleTypeID.Value) == null ? "" : bllcartype.GetModel(model.VehicleTypeID.Value).vc_Name,
                        model.i_Count
                        );
                }
            }
            else
            {
                foreach (Model.m_Plan_CheckVehicle model in listcheck)
                {
                    panelCheckMain.TitleText = "审核人 :" + plan.CheckPersonName.Trim().PadRight(20, ' ') + "审核时间:" + plan.dt_CheckDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    int i = dgcheck.Rows.Add(
                        dgcheck.Rows.Count + 1,
                        bllmater.GetModel(model.MaterieTypeID.Value) == null ? "" : bllmater.GetModel(model.MaterieTypeID.Value).vc_Name,
                        model.n_Count,
                        bllcartype.GetModel(model.VehicleTypeID.Value) == null ? "" : bllcartype.GetModel(model.VehicleTypeID.Value).vc_Name,
                        model.i_Count
                        );
                }
            }
            //供车
            List<Model.m_Plan_GiveVehicle> listgiven = bllgiven.GetModelList("PlanID=" + _planid);
            if (listgiven == null || listgiven.Count == 0)
            {
                panel02.Visible = false;
                panelSupplyMain.Visible = false;
            }
            else
            {
                panelSupplyMain.TitleText = "供车人:" + plan.RealGiveCarPersonName.Trim().PadRight(20, ' ') + "供车时间:" + plan.dt_RealGiveCarDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss").PadRight(30, ' ') + "供车地点:" + plan.RealGiveCarAddressName;
                k = k + 1;
                foreach (Model.m_Plan_GiveVehicle model in listgiven)
                {
                    int i = dggiven.Rows.Add(
                        dggiven.Rows.Count + 1,
                        bllcartype.GetModel(model.VehicleTypeID.Value).vc_Name,
                        model.i_Count
                        );
                }
            }
            //装车
            List<Model.m_Plan_Load> listload = bllload.GetModelList("PlanID=" + _planid);
            if (listload == null || listload.Count == 0)
            {
                panel03.Visible = false;
                panelLoadMain.Visible = false;
            }
            else
            {
                panelLoadMain.TitleText = "装车人:" + plan.RealLoadPersonName.Trim().PadRight(20, ' ') + "装车时间:" + plan.dt_RealLoadDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss").PadRight(30, ' ') + "装车地点:" + plan.RealLoadAddressName;
                k = k + 1;
                foreach (Model.m_Plan_Load model in listload)
                {
                    int i = dgload.Rows.Add(
                        dgload.Rows.Count + 1,
                        bllcar.GetModel(model.VehicleID.Value).vc_Code,
                        bllmater.GetModel(model.MaterieTypeID.Value).vc_Name,
                        model.n_Count
                        );
                }
            }
            //交接车
            List<Model.v_handover> listhandover = bllhandover.GetModelList("PlanID=" + _planid);
            listhandover = (from planentity in listhandover orderby planentity.i_HandoverCount ascending select planentity).ToList<Model.v_handover>();
            if (listhandover == null || listhandover.Count == 0)
            {
                panel04.Visible = false;
                panelTransMain.Visible = false;
            }
            else
            {
                k = k + 1;
                foreach (Model.v_handover model in listhandover)
                {
                    decimal modifycount = 0;
                    if (model.i_HandoverCount == 1)
                    {
                        List<Model.m_Plan_Load> listload2 = bllload.GetModelList("PlanID=" + model.PlanID + " and VehicleID=" + model.VehicleID + " and MaterieTypeID=" + model.MaterieTypeID);
                        if (listload2.Count > 0)
                        {
                            modifycount = model.n_Count.Value - listload2[0].n_Count.Value;
                        }
                        else
                        {
                            modifycount = model.n_Count.Value;
                        }
                    }
                    else
                    {
                        int oldcount = model.i_HandoverCount.Value - 1;
                        List<Model.v_handover> listold = bllhandover.GetModelList("PlanID=" + model.PlanID + " and VehicleID=" + model.VehicleID + " and i_HandoverCount=" + oldcount + " and MaterieTypeID="+model.MaterieTypeID);
                        if (listold.Count > 0)
                        {
                            modifycount = model.n_Count.Value - listold[0].n_Count.Value;
                        }
                        else
                        {
                            modifycount = model.n_Count.Value;
                        }
                    }
                    int i = dghandover.Rows.Add(
                        "第" + model.i_HandoverCount + "次交接",
                        model.personname,
                        model.dt_HandoverDateTime,
                        model.addressname,
                        model.carcode,
                        model.matername,
                        model.n_Count,
                        modifycount
                        );
                    if (modifycount != 0)
                    {
                        dghandover.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                dghandover.ClearSelection();
            }
            //卸车
            List<Model.v_unload> listunload = bllunload.GetModelList("PlanID=" + _planid);
            if (listunload == null || listunload.Count == 0)
            {
                panel05.Visible = false;
                panelUnloadMain.Visible = false;
            }
            else
            {

                panelUnloadMain.TitleText = "卸车";// +plan.RealUnLoadDepartmentName.Trim().PadRight(20, ' ') + "卸车时间:" + plan.dt_RealUnLoadDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss").PadRight(30, ' ') + "卸车地点:" + plan.RealUnLoadAddressName;
                k = k + 1;
                foreach (Model.v_unload model in listunload)
                {
                    string adderssname = "";
                    List<Model.m_Plan_UnLoad> unload = bllmunload.GetModelList("planid=" + model.PlanID + " and vehicleid=" + model.VehicleID);
                    if (unload == null || unload.Count == 0)
                        continue;
                    else
                    {

                        Model.m_Address entityadr = blladress.GetModel(unload[0].AddressID.Value);
                        if (entityadr != null && !string.IsNullOrEmpty(entityadr.vc_Name))
                        {
                            adderssname = entityadr.vc_Name;
                        }
 
                    }
                    int i = dgunload.Rows.Add(
                        dgunload.Rows.Count + 1,
                        model.personname,
                        model.dt_DateTime,
                        adderssname,
                        model.carcode,
                        model.matername,
                        model.n_Count
                        );
                }
            }
            //还车
            List<Model.m_Plan_BackVehicle> listback = bllback.GetModelList("PlanID=" + _planid);
            if (listback == null || listback.Count == 0)
            {
                panelBackMain.Visible = false;
            }
            else
            {

                panelBackMain.TitleText = "还车";//+ plan.RealBackDepartmentName.Trim().PadRight(20, ' ') + "还车时间:" + plan.dt_RealBackDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss").PadRight(30, ' ') + "还车地点:" + plan.RealBackAddressName;
                k = k + 1;
                foreach (Model.m_Plan_BackVehicle model in listback)
                {
                    string adderssname = "";
                    Model.m_Address entityadr = blladress.GetModel(model.AddressID.Value);
                    if (entityadr != null && !string.IsNullOrEmpty(entityadr.vc_Name))
                    {
                        adderssname = entityadr.vc_Name;
                    }
 
                    int i = dgback.Rows.Add(
                        dgback.Rows.Count + 1,
                        bllperson.GetModel(model.PersonID.Value).vc_Name,
                        model.dt_DateTime,
                        adderssname,
                        bllcar.GetModel(model.VehicleID.Value).vc_Code
                        );
                }
            }
            this.Height = 40 * k+40;
            _height = 40 * k + 40;
        }
        int i = 0;
        private void panelCheckMain_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelCheckMain.Expanded)
            {
                i = i + 1;
            }
            else
            {
                i = i - 1;
            }
            this.Height = _height+100*i;
        }

        private void panelSupplyMain_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelSupplyMain.Expanded)
            {
                i = i + 1;
            }
            else
            {
                i = i - 1;
            }
            this.Height = _height + 100 * i;
        }

        private void panelLoadMain_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelLoadMain.Expanded)
            {
                i = i + 1;
            }
            else
            {
                i = i - 1;
            }
            this.Height = _height + 100 * i;
        }

        private void panelTransMain_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelTransMain.Expanded)
            {
                i = i + 1;
            }
            else
            {
                i = i - 1;
            }
            this.Height = _height + 100 * i;
        }

        private void panelUnloadMain_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelUnloadMain.Expanded)
            {
                i = i + 1;
            }
            else
            {
                i = i - 1;
            }
            this.Height = _height + 100 * i;
        }

        private void panelBackMain_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelBackMain.Expanded)
            {
                i = i + 1;
            }
            else
            {
                i = i - 1;
            }
            this.Height = _height + 100 * i;
        }
    }
}
