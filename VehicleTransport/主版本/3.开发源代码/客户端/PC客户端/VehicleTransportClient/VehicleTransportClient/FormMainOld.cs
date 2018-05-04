using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using DB_VehicleTransportManage;
using VehicleTransportClient.UI;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
using DevComponents.AdvTree;
namespace VehicleTransportClient
{
    public partial class FormMainOld :  Common.frmBase
    {
        System.Windows.Forms.Timer _servertime = new Timer();
        private BLL.m_Apply bllapply = new BLL.m_Apply();
        private BLL.m_User blluer = new BLL.m_User();
        public FormMainOld()
        {
            InitializeComponent();
            this.Width = 1024;
            this.Height = 768;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            Pub.GISForm = new FrmGIS(this);
            btngis_Click(null, null);
            //bargroupbaseinfo.Visible = false;
            //btnAddressManage.Visible = false;
            //btnCardManage.Visible = false;
            //btnCarTypeManage.Visible = false;
            this.Load += new EventHandler(FormMain_Load);
            _servertime.Tick += new EventHandler(_servertime_Tick);
            _servertime.Interval = 1000;
            _servertime.Enabled = true;
            GetMenuTree();
            FormMaxed();
        }
        public DevComponents.AdvTree.AdvTree advTree =new AdvTree();
       
        public void GetMenuTree()
        {
           
            int i = 0;
            foreach (Control item in panelLeftBar.Controls)
            {
                if (item is DevComponents.DotNetBar.ExpandablePanel)
                {
                    
                    int j = 0;
                    DevComponents.DotNetBar.ExpandablePanel pan = (DevComponents.DotNetBar.ExpandablePanel) item;
                    Node node1 = new Node();
                    node1.Text = pan.TitleText.ToString();
                    node1.Tag = i.ToString().PadRight(3, '0');
                    advTree.Nodes.Add(node1);
                   
                    foreach (Control itemPanels in pan.Controls)
                    {
                        if (itemPanels is DevComponents.DotNetBar.ItemPanel)
                        {
                            DevComponents.DotNetBar.ItemPanel itemPanel = itemPanels as DevComponents.DotNetBar.ItemPanel;

                            foreach (var buttonItem in itemPanel.Items)
                            {
                                if (buttonItem is DevComponents.DotNetBar.ButtonItem)
                                {
                                    j++;
                                    DevComponents.DotNetBar.ButtonItem bbbI = buttonItem as DevComponents.DotNetBar.ButtonItem;
                                    Node node11 = new Node();
                                    node11.Text = bbbI.Text;
                                    node11.Tag = i.ToString()+j.ToString().PadLeft(2, '0');
                                    node1.Nodes.Add(node11);
                                }

                            }
                        }
                    }
                    i++;
                }
            }

        }

        public void SetMenutree()
        {
            BLL.m_User bllSysUser = new BLL.m_User();
            BLL.m_RuleDetail bllRuleDetail = new BLL.m_RuleDetail();
            List<string> listModelName = new List<string>();
            List<Model.m_RuleDetail> list = bllRuleDetail.GetModelList(" RuleID= " + bllSysUser.GetRuleID(Pub.UserId));
           
            foreach (Model.m_RuleDetail mRuleDetail in list)
            {
                listModelName.Add(mRuleDetail.vc_ModuleName);
            }

            int i = 0;
            foreach (Control item in panelLeftBar.Controls)
            {

                if (item is DevComponents.DotNetBar.ExpandablePanel)
                {

                    int j = 0;
                    DevComponents.DotNetBar.ExpandablePanel pan = (DevComponents.DotNetBar.ExpandablePanel)item;

                    if (!listModelName.Contains(i.ToString().PadRight(3, '0')))
                    {
                        pan.Visible = false;
                    }

                    foreach (Control itemPanels in pan.Controls)
                    {
                        if (itemPanels is DevComponents.DotNetBar.ItemPanel)
                        {
                            DevComponents.DotNetBar.ItemPanel itemPanel = itemPanels as DevComponents.DotNetBar.ItemPanel;

                            foreach (var buttonItem in itemPanel.Items)
                            {
                                if (buttonItem is DevComponents.DotNetBar.ButtonItem)
                                {
                                    j++;
                                    DevComponents.DotNetBar.ButtonItem bbbI = buttonItem as DevComponents.DotNetBar.ButtonItem;
                                    if (!listModelName.Contains(i.ToString() + j.ToString().PadLeft(2, '0')))
                                    {
                                        bbbI.Visible = false;
                                    }
                                    else
                                    {
                                        pan.Visible = true;
                                    }
                                }

                            }
                        }
                    }
                    i++;
                }
            }
        }



        void _servertime_Tick(object sender, EventArgs e)
        {
            if (Pub.IsServerConnect == true)
            {
                lbstate.Text = "服务器连接状态：成功";
                lbstate.ForeColor = Color.Black;
            }
            else
            {
                lbstate.Text = "服务器连接状态：失败";
                lbstate.ForeColor = Color.Red;
            }
            if (Pub.IsDBOnline == true)
            {
                lbdbstate.Text = "数据库连接状态：成功";
                lbdbstate.ForeColor = Color.Black;
            }
            else
            {
                lbdbstate.Text = "数据库连接状态：失败";
                lbdbstate.ForeColor = Color.Red;
            }
            List<Model.m_Apply> listapply = bllapply.GetModelList("i_State in (" + (int)EnumApplyState.CheckPart + "," + (int)EnumApplyState.WaitCheck + ")");
            if (listapply != null)
            {
                labcheckstate.Text = "待审核:" + listapply.Count;
            }
        }


        void FormMain_Load(object sender, EventArgs e)
        {

            if (blluer.GetModel(Pub.UserId).PersonID == 0)
            {
                btnCheck.Visible = false;
            }
            Pub.IsKj602 = new DB_VehicleTransportManage.DAL.v_Kj222Localizer().IsKj602();

            if (Pub.FlowPath.Back == false)
            {
                btnbackcar.Visible = false;
            }
            if (Pub.FlowPath.Give == false)
            {
                btnSupply.Visible = false;
            }
            if (Pub.FlowPath.Handover == false)
            {
                btnTransfer.Visible = false;
            }
            if (Pub.ListFunRight.Contains(FunctionModel.BaseManage))
            {
                //权限
            }
            panelFlow.Expanded = true;
            panelAlarm.Expanded = false;
            panelAnaly.Expanded = false;
            panelBaseinfo.Expanded = false;
            panelConfig.Expanded = false;
            labuser.Text = "用户名:" + Pub.UserName;
            if (Pub.ListFunRight.Contains(FunctionModel.FormReviewMgr))
            {
                labcheckstate.Visible = true;
            }
            else
            {
                labcheckstate.Visible = false;
            }
            if(Pub.UserName!="admin")
            SetMenutree();
        }

        private void btngis_Click(object sender, EventArgs e)
        {
            lblNav.Text = "实时监测";

            LoadControl(Pub.GISForm);
        }

        //右边panel加载control
        private void LoadControl(Form frm)
        {
            frm.TopLevel = false;
            panRight.Controls.Clear();
            frm.Show();
            frm.Dock = DockStyle.Fill;
            panRight.Visible = false;
            panRight.Controls.Add(frm);
            System.Threading.Thread.Sleep(150);
            panRight.Visible = true;
        }

        private void btncuralarm_Click(object sender, EventArgs e)
        {
            lblNav.Text = "实时监测";
            FormAlarmSet frmgis = new FormAlarmSet();
            LoadControl(frmgis);
        }

        private void btnPersonManage_Click(object sender, EventArgs e)
        {
            FormPersonManage FormPersonManage=new FormPersonManage();
            lblNav.Text = FormPersonManage.Text;
            LoadControl(FormPersonManage);
        }

        private void btnDeptManage_Click(object sender, EventArgs e)
        {
            FormDeptManage FormDeptManage=new FormDeptManage();
            lblNav.Text = FormDeptManage.Text;
            LoadControl(FormDeptManage);
        }

       

        private void btnAreaManage_Click(object sender, EventArgs e)
        {
            FormAreaManage formAreaManage = new FormAreaManage();
            lblNav.Text = formAreaManage.Text;
            LoadControl(formAreaManage);
        }

        private void btnStationManage_Click(object sender, EventArgs e)
        {
            FormAddressManage formAddressManage = new FormAddressManage();
            lblNav.Text = formAddressManage.Text;
            LoadControl(formAddressManage);
        }
        private void btnWifiStation_Click(object sender, EventArgs e)
        {
            FormWifiBaseStation frmbs = new FormWifiBaseStation();
            lblNav.Text = frmbs.Text;
            LoadControl(frmbs);
        }

        private void btnPDAManage_Click(object sender, EventArgs e)
        {
            FormPDAManage formPdaManage=new FormPDAManage();
            lblNav.Text = formPdaManage.Text;
            LoadControl(formPdaManage);
        }

        private void btnCardManage_Click(object sender, EventArgs e)
        {
            FormCardManage formCardManage=new FormCardManage();
            lblNav.Text = formCardManage.Text;
            LoadControl(formCardManage);
        }

        private void btnMaterielType_Click(object sender, EventArgs e)
        {
            FormMaterielTypeManage formMaterielTypeManage=new FormMaterielTypeManage();
            lblNav.Text = formMaterielTypeManage.Text;
            LoadControl(formMaterielTypeManage);
        }

        private void btnPasswordEdit_Click(object sender, EventArgs e)
        {
            FormPasswordEdit formPasswordEdit=new FormPasswordEdit();
            formPasswordEdit.ShowDialog();
        }

        private void btnUserManage_Click(object sender, EventArgs e)
        {
            FormUserManage formUserManage=new FormUserManage();
            lblNav.Text = formUserManage.Text;
            LoadControl(formUserManage);
        }

        private void btnAlarmSet_Click(object sender, EventArgs e)
        {
            FormAlarmSet formAlarmSet = new FormAlarmSet();
            formAlarmSet.ShowDialog();
        }

        private void btnSystemLog_Click(object sender, EventArgs e)
        {
            FormSystemLog formSystemLog=new FormSystemLog();
            lblNav.Text = formSystemLog.Text;
            LoadControl(formSystemLog);
        }

        private void btnRuleManage_Click(object sender, EventArgs e)
        {
            FormRuleManage formRuleManage=new FormRuleManage(this);
            lblNav.Text = formRuleManage.Text;
            LoadControl(formRuleManage);
        }

        private void btnCarTypeManage_Click(object sender, EventArgs e)
        {
            FormVehicleTypeManage formVehicleTypeManage=new FormVehicleTypeManage();
            lblNav.Text = formVehicleTypeManage.Text;
            LoadControl(formVehicleTypeManage);
        }

        private void btnCarManage_Click(object sender, EventArgs e)
        {
            FormVehicleManage formVehicleManage=new FormVehicleManage();
            lblNav.Text = formVehicleManage.Text;
            LoadControl(formVehicleManage);
        }

        //车辆报废
        private void btnCarScraped_Click(object sender, EventArgs e)
        {
            FormVehicleScrapManage formVehicleScrapManage=new FormVehicleScrapManage();
            lblNav.Text = formVehicleScrapManage.Text;
            LoadControl(formVehicleScrapManage);
        }

        //车辆维护
        private void btnVehicleMaintain_Click(object sender, EventArgs e)
        {
            FormVehicleMainTainManage formVehicleMainTainManage=new FormVehicleMainTainManage();
            lblNav.Text = formVehicleMainTainManage.Text;
            LoadControl(formVehicleMainTainManage);
        }

        private void btnMaintainTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryAlarm FormHistoryAlarm=new FormHistoryAlarm(EnumAlarmType.MaintainTimeOutAlarm);
            lblNav.Text = FormHistoryAlarm.Text;
            LoadControl(FormHistoryAlarm);
        }

        private void btnScrapTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryAlarm FormHistoryAlarm = new FormHistoryAlarm(EnumAlarmType.ScrapTimeOutAlarm);
            lblNav.Text = FormHistoryAlarm.Text;
            LoadControl(FormHistoryAlarm);
        }

        private void btnGiveTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryAlarm FormHistoryAlarm = new FormHistoryAlarm(EnumAlarmType.GiveTimeOutAlarm);
            lblNav.Text = FormHistoryAlarm.Text;
            LoadControl(FormHistoryAlarm);
        }

        private void btnLoadTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryAlarm FormHistoryAlarm = new FormHistoryAlarm(EnumAlarmType.LoadTimeOutAlarm);
            lblNav.Text = FormHistoryAlarm.Text;
            LoadControl(FormHistoryAlarm);
        }

        private void btnTransportTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryAlarm FormHistoryAlarm = new FormHistoryAlarm(EnumAlarmType.TransportTimeOutAlarm);
            lblNav.Text = FormHistoryAlarm.Text;
            LoadControl(FormHistoryAlarm);
        }

        private void btnUnLoadTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryAlarm FormHistoryAlarm = new FormHistoryAlarm(EnumAlarmType.UnLoadTimeOutAlarm);
            lblNav.Text = FormHistoryAlarm.Text;
            LoadControl(FormHistoryAlarm);
        }

        private void btnBackTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryAlarm FormHistoryAlarm = new FormHistoryAlarm(EnumAlarmType.BackTimeOutAlarm);
            lblNav.Text = FormHistoryAlarm.Text;
            LoadControl(FormHistoryAlarm);
        }

        private void btnNoUseAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryAlarm FormHistoryAlarm = new FormHistoryAlarm(EnumAlarmType.NoUseAlarm);
            lblNav.Text = FormHistoryAlarm.Text;
            LoadControl(FormHistoryAlarm);
        }

        private void btnRunDerictionAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryAlarm FormHistoryAlarm = new FormHistoryAlarm(EnumAlarmType.RunDerictionAlarm);
            lblNav.Text = FormHistoryAlarm.Text;
            LoadControl(FormHistoryAlarm);
        }

        private void btnNoChanageStateAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryAlarm FormHistoryAlarm = new FormHistoryAlarm(EnumAlarmType.NoChanageStateAlarm);
            lblNav.Text = FormHistoryAlarm.Text;
            LoadControl(FormHistoryAlarm);
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            FormApplyMgrManage frmapply = new FormApplyMgrManage();
            DialogResult result=frmapply.ShowDialog() ;
            if (result== DialogResult.Yes)
            {
                frmapply.Close();
                if (Pub.ListFunRight.Contains(FunctionModel.FormReviewMgr))
                {
                    FormReviewMaterEdit frmreview = new FormReviewMaterEdit(frmapply.ListApplyMater, frmapply.Apply,true);

                    DialogResult fresult = frmreview.ShowDialog();
                    if (fresult == DialogResult.Cancel || fresult == DialogResult.OK)
                    {
                        frmreview.Close();
                    }
                }
             
            }
            if (result == DialogResult.OK)
            {
                frmapply.Close();
                if (Pub.ListFunRight.Contains(FunctionModel.FormReviewMgr))
                {
                    FormReviewCarEdit frmreview = new FormReviewCarEdit(frmapply.ListApplyCar, frmapply.Apply,true);
                    DialogResult fresult = frmreview.ShowDialog();
                    if (fresult == DialogResult.Cancel || fresult == DialogResult.OK)
                    {
                        frmreview.Close();
                    }
                }

            }
        }

        private void btnApplyMgr_Click(object sender, EventArgs e)
        {
            btnApply.PerformClick();
            //FormApplyMgrManage formApplyMgr = new FormApplyMgrManage();
            //formApplyMgr.ShowDialog();
        }


        private void btnReview_Click(object sender, EventArgs e)
        {
            FormReviewMgr frmreview = new FormReviewMgr(true);
            lblNav.Text = frmreview.Text;
            LoadControl(frmreview);
        }

        private void btnloadcar_Click(object sender, EventArgs e)
        {
            FormLoadCarMgr frmload = new FormLoadCarMgr();
            lblNav.Text = frmload.Text;
            LoadControl(frmload);
        }

        private void btnSupply_Click(object sender, EventArgs e)
        {

            FormSupplyCarMgr frmsupply = new FormSupplyCarMgr();
            lblNav.Text = frmsupply.Text;
            LoadControl(frmsupply);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            FormHandover frmhandover = new FormHandover();
            frmhandover.ShowDialog();
            //FormTransferCarMgr frmtransfer = new FormTransferCarMgr();
            //lblNav.Text = frmtransfer.Text;
            //LoadControl(frmtransfer);
        }

        private void btnunload_Click(object sender, EventArgs e)
        {
            FormUnload frmunload = new FormUnload();
            frmunload.ShowDialog();
            //FormUnloadCarMgr frmunload = new FormUnloadCarMgr();
            //lblNav.Text = frmunload.Text;
            //LoadControl(frmunload);
        }

        private void btnreview2_Click(object sender, EventArgs e)
        {
            FormReviewMgr frmreview = new FormReviewMgr(true);
            lblNav.Text = frmreview.Text;
            LoadControl(frmreview);
        }

        private void btnbackcar_Click(object sender, EventArgs e)
        {
            FormBackCar frmback = new FormBackCar();
            frmback.ShowDialog();
            //FormBackCarMgr frmback = new FormBackCarMgr();
            //lblNav.Text = frmback.Text;
            //LoadControl(frmback);

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            FormSendMessage formSendMessage=new FormSendMessage();
            lblNav.Text = formSendMessage.Text;
            LoadControl(formSendMessage);
        }

        private void btnWin_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            btnCheckMgr.PerformClick();
        }

        private void panelFlow_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelFlow.Expanded)
            {
                panelBaseinfo.Expanded = false;
                panelConfig.Expanded = false;
                panelAlarm.Expanded = false;
                panelAnaly.Expanded = false;
            }
        }

        private void panelBaseinfo_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelBaseinfo.Expanded)
            {
                panelFlow.Expanded = false;
                panelConfig.Expanded = false;
                panelAlarm.Expanded = false;
                panelAnaly.Expanded = false;
            }
        }

        private void panelAnaly_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelAnaly.Expanded)
            {
                panelFlow.Expanded = false;
                panelConfig.Expanded = false;
                panelAlarm.Expanded = false;
                panelBaseinfo.Expanded = false;
            }
        }

        private void panelAlarm_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelAlarm.Expanded)
            {
                panelFlow.Expanded = false;
                panelConfig.Expanded = false;
                panelAnaly.Expanded = false;
                panelBaseinfo.Expanded = false;
            }
        }

        private void panelConfig_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelConfig.Expanded)
            {
                panelFlow.Expanded = false;
                panelAlarm.Expanded = false;
                panelAnaly.Expanded = false;
                panelBaseinfo.Expanded = false;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnVehicleMonth_Click(object sender, EventArgs e)
        {

            FormVehicleMonth formVehicleMonth = new FormVehicleMonth();
            lblNav.Text = formVehicleMonth.Text;
            LoadControl(formVehicleMonth);
        }


        private void btnmyapply_Click(object sender, EventArgs e)
        {
            FormMyApply formMyapply = new FormMyApply();
            lblNav.Text = formMyapply.Text;
            LoadControl(formMyapply);
        }

        /// <summary>车辆闲置月报表
        /// 车辆闲置月报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoUseMonthReport_Click(object sender, EventArgs e)
        {
            FormVehicleNoUseMonth formVehicleNoUseMonth = new FormVehicleNoUseMonth();
            lblNav.Text = formVehicleNoUseMonth.Text;
            LoadControl(formVehicleNoUseMonth);
        }

        /// <summary>物料使用月报表
        /// 物料使用月报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMaterielReport_Click(object sender, EventArgs e)
        {
            FormMaterielTypeMonth formMaterielTypeMonth=new FormMaterielTypeMonth();
            lblNav.Text = formMaterielTypeMonth.Text;
            LoadControl(formMaterielTypeMonth);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            FormPlanQuery frmplan = new FormPlanQuery();
            lblNav.Text = frmplan.Text;
            LoadControl(frmplan);
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelX8_Click(object sender, EventArgs e)
        {
            FormCurrentAlarm formVehicleCurrentAlarm = new FormCurrentAlarm();
            formVehicleCurrentAlarm.ShowDialog();
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            LoadControl(Pub.GISForm);
        }
        public void ShowGis(FrmGIS frmgis)
        {

            panelWorkArea.Controls.Clear();
            frmgis.TopLevel = false;
            frmgis.Show();
            frmgis.Dock = DockStyle.Fill;
            panelWorkArea.Visible = false;
            panelWorkArea.Controls.Add(frmgis);
            panelWorkArea.Visible = true;
        }

        public void CloseGis(FrmGIS frmgis)
        {
            panelWorkArea.Controls.Clear();
            panelWorkArea.Visible = false;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panfull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWorkArea.Controls.Add(this.panfull);
            this.panelWorkArea.Controls.Add(this.panel5);
            this.panelWorkArea.Controls.Add(this.panel3);
            this.panelWorkArea.Controls.Add(this.panel1);
            LoadControl(frmgis);
            panelWorkArea.Visible = true;
        }


        private void btnVehicleDept_Click(object sender, EventArgs e)
        {
            FormDeptVehicleReport formDeptVehicleReport = new FormDeptVehicleReport();
            lblNav.Text = formDeptVehicleReport.Text;
            LoadControl(formDeptVehicleReport);
        }


        private void labcheckstate_Click(object sender, EventArgs e)
        {
            btnCheckMgr.PerformClick();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

        }

        private void btnDeptMaterielTypeReport_Click(object sender, EventArgs e)
        {
            FormDeptMaterielTypeReport formDeptMaterielTypeReport = new FormDeptMaterielTypeReport();
            lblNav.Text = formDeptMaterielTypeReport.Text;
            LoadControl(formDeptMaterielTypeReport);
        }


     
    }
}
