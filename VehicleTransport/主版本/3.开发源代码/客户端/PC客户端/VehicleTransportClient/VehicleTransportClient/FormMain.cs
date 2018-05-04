using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Forms;
using Common.Enum;
using Common.MessageBoxEx;
using DevComponents.AdvTree;
using VehicleTransportClient.UI;
using VehicleTransportClient.UI.SystemManage;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
namespace VehicleTransportClient
{
    public partial class FormMain : Form
    {
        Timer _servertime = new Timer();
        private BLL.m_Apply bllapply = new BLL.m_Apply();
        private BLL.m_User blluer = new BLL.m_User();
        private BLL.m_Message bllmsg = new BLL.m_Message();
        private Common.frmBase.EnumWindowState _windowState = Common.frmBase.EnumWindowState.Normal;
        public FormMain()
        {
            InitializeComponent();

            this.panelTopCenter.MouseEnter += new EventHandler(panelTopCenter_MouseEnter);
            this.panelTopCenter.MouseLeave += new EventHandler(panelTopCenter_MouseLeave);
            this.panelTopCenter.MouseDown += new MouseEventHandler(panelTopCenter_MouseDown);

            this.panelTopRight.MouseEnter += new EventHandler(panelTopRight_MouseEnter);
            this.panelTopRight.MouseLeave += new EventHandler(panelTopRight_MouseLeave);
            this.panelTopRight.MouseDown += new MouseEventHandler(panelTopRight_MouseDown);

            this.Width = 1024;
            this.Height = 768;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;

            //bargroupbaseinfo.Visible = false;
            //btnAddressManage.Visible = false;
            //btnCardManage.Visible = false;
            //btnCarTypeManage.Visible = false;
            Pub.GISForm = new FrmGIS(this);
            btngis_Click(null, null);
            this.Load += new EventHandler(FormMain_Load);
            _servertime.Tick += new EventHandler(_servertime_Tick);
            _servertime.Interval = 1000;
            _servertime.Enabled = true;
            GetMenuTree();
            btnmax_Click(null, null);
        }

        //初始化菜单&按钮权限
        public void SetUserPermission()
        {
            labuser.Text = "用户名:" + Pub.UserName;
            Pub.IsKj602 = new DB_VehicleTransportManage.DAL.v_Kj222Localizer().IsKj602();
            if (Pub.FlowPath.Back == false)
            {
                btnbackcar.Visible = false;
                btnBackTimeOutAlarm.Visible = false;
            }
            if (Pub.FlowPath.Give == false)
            {
                btnSupply.Visible = false;
                btnGiveTimeOutAlarm.Visible = false;
            }
            if (Pub.FlowPath.Handover == false)
            {
                btnTransfer.Visible = false;
                //btnTransportTimeOutAlarm.Visible = false;
            }


            //2014-11-12修改 限制admin账户权限
            if (Pub.UserName != "admin")
            {
                SetMenutree();
                if (panelFlow.Visible)
                    panelFlow.Expanded = true;
                else
                {
                    panelFlow.Expanded = false;
                }
                panelConfig.Expanded = false;
                panelCar.Expanded = false;
                panelAlarm.Expanded = false;
                panelAnaly.Expanded = false;
                panelBaseinfo.Expanded = false;
                panelLog.Expanded = false;
            }
            else
            {
                panelBaseinfo.Expanded = true;
                panelFlow.Expanded = false;
                panelConfig.Expanded = false;
                panelCar.Expanded = false;
                panelAlarm.Expanded = false;
                panelAnaly.Expanded = false;
                panelLog.Expanded = false;
                panelLog.Visible = false;
                panelConfig.Visible = true;
                panelFlow.Visible = false;
                panelAlarm.Visible = false;
                panelAnaly.Visible = false;
                panelBaseinfo.Visible = true;
                panelCar.Visible = true;
            }

            //隐藏申请和审核按钮
            if (!panelFlow.Visible)
            {
                btnApply.Visible = false;
                btnCheckMgr.Visible = false;
            }

            //主界面右上角提示信息显示
            if (Pub.ListFunRight.Contains("btnCheck"))
            {
                panelTwo.Visible = true;
                panelOne.Visible = false;
            }
            else
            {
                panelTwo.Visible = false;
                panelOne.Top = panelOne.Top + 30;
                if (Pub.UserName == "admin")
                {
                    panelOne.Visible = false;
                }
                else
                {
                    panelOne.Visible = true;
                }
            }

        }

        void FormMain_Load(object sender, EventArgs e)
        {
            SetUserPermission();
        }

        #region//移动窗体事件

        void panelTopCenter_MouseDown(object sender, MouseEventArgs e)
        {
            if (_windowState != Common.frmBase.EnumWindowState.Max)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Common.Win32.ReleaseCapture();
                    Common.Win32.SendMessage(Handle, 274, 61440 + 9, 0);
                }
            }
            if (e.Clicks == 2)
            {

                btnmax_Click(sender, e);

            }
        }

        void panelTopCenter_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        void panelTopCenter_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        void panelTopRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (_windowState != Common.frmBase.EnumWindowState.Max)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Common.Win32.ReleaseCapture();
                    Common.Win32.SendMessage(Handle, 274, 61440 + 9, 0);
                }
            }
            if (e.Clicks == 2)
            {

                btnmax_Click(sender, e);

            }
        }

        void panelTopRight_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        void panelTopRight_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        #endregion

        #region//获取设置菜单权限
        public DevComponents.AdvTree.AdvTree advTree = new AdvTree();

        public void GetMenuTree()
        {
            foreach (Control item in panelLeftBar.Controls)
            {
                if (item is DevComponents.DotNetBar.ExpandablePanel)
                {
                    DevComponents.DotNetBar.ExpandablePanel pan = (DevComponents.DotNetBar.ExpandablePanel)item;
                    Node node1 = new Node();
                    node1.Text = pan.TitleText.ToString();
                    node1.Tag = pan.Name.ToString();
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
                                    DevComponents.DotNetBar.ButtonItem bbbI = buttonItem as DevComponents.DotNetBar.ButtonItem;
                                    #region//根据配置,判断是否显示对应的流程模块
                                    if ((bbbI.Name.ToString() == "btnbackcar" || bbbI.Name.ToString() == "btnBackTimeOutAlarm") && Pub.FlowPath.Back == false)
                                    {
                                        continue;
                                    }
                                    if ((bbbI.Name.ToString() == "btnSupply" || bbbI.Name.ToString() == "btnGiveTimeOutAlarm") && Pub.FlowPath.Give == false)
                                    {
                                        continue;
                                    }
                                    if (bbbI.Name.ToString() == "btnTransfer" && Pub.FlowPath.Handover == false)
                                    {
                                        continue;
                                    }
                                    #endregion

                                    Node node11 = new Node();
                                    node11.Text = bbbI.Text.ToString();
                                    node11.Tag = bbbI.Name.ToString();
                                    node1.Nodes.Add(node11);
                                }

                            }
                        }
                    }
                }
            }
            //Node node2 = new Node();
            //node2.Text = "地图修改";
            //node2.Tag = "GisMapEdit";
            //advTree.Nodes.Add(node2);
        }

        public void SetMenutree()
        {
            BLL.m_User bllSysUser = new BLL.m_User();
            BLL.m_RuleDetail bllRuleDetail = new BLL.m_RuleDetail();
            List<string> listModelName = new List<string>();
            List<Model.m_RuleDetail> list = bllRuleDetail.GetModelList(" RuleID= " + bllSysUser.GetRuleID(Pub.UserId));

            foreach (Model.m_RuleDetail mRuleDetail in list)
            {
                #region//根据配置,判断是否显示对应的流程模块
                if ((mRuleDetail.vc_ModuleName == "btnbackcar" || mRuleDetail.vc_ModuleName == "btnBackTimeOutAlarm") && Pub.FlowPath.Back == false)
                {
                    continue;
                }
                if ((mRuleDetail.vc_ModuleName == "btnSupply" || mRuleDetail.vc_ModuleName == "btnGiveTimeOutAlarm") && Pub.FlowPath.Give == false)
                {
                    continue;
                }
                if (mRuleDetail.vc_ModuleName == "btnTransfer" && Pub.FlowPath.Handover == false)
                {
                    continue;
                }

                #endregion
                listModelName.Add(mRuleDetail.vc_ModuleName);
            }

            foreach (Control item in panelLeftBar.Controls)
            {

                if (item is DevComponents.DotNetBar.ExpandablePanel)
                {
                    DevComponents.DotNetBar.ExpandablePanel pan = (DevComponents.DotNetBar.ExpandablePanel)item;

                    if (!listModelName.Contains(pan.Name.ToString()))
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
                                    DevComponents.DotNetBar.ButtonItem bbbI = buttonItem as DevComponents.DotNetBar.ButtonItem;
                                    if (!listModelName.Contains(bbbI.Name.ToString()))
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
                    if (!btnCheck.Visible)
                    {
                        btnCheckMgr.Visible = false;
                    }
                }
            }
        }
        #endregion
        //定时器操作
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
            if (Pub.IsDBOnline)
            {
                List<Model.m_Apply> listapply = bllapply.GetModelList("i_State in (" + (int)EnumApplyState.CheckPart + "," + (int)EnumApplyState.WaitCheck + ")");
                if (listapply != null)
                {
                    labcheckstate.Text = listapply.Count.ToString();
                }
                List<Model.m_Message> listmsg = bllmsg.GetModelList("i_Flag=0 and i_state=0");
                if (listmsg != null)
                {
                    labmsg.Text = listmsg.Count.ToString();
                }
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" i_flag=0 and i_IsPreAlarm=0");
                if (Pub.FlowPath.Back == false)
                {
                    stringBuilder.Append("and i_AlarmType<>7");
                }
                if (Pub.FlowPath.Give == false)
                {
                    stringBuilder.Append("and i_AlarmType<>3");
                }
                stringBuilder.Append(" and dt_Start is not null and dt_End is null ");
                List<Model.v_VehicleAlarm> lst = new BLL.v_VehicleAlarm().
                GetModelList(stringBuilder.ToString());
                if (lst != null)
                {
                    lblAlarmCounts.Text = lst.Count.ToString();
                }
                List<Model.m_Message> listmymsg = bllmsg.GetModelList("i_Flag=0 and i_read=0 and ToUserID=" + Pub.UserId);
                if (listmymsg != null)
                {
                    labmymsg.Text = listmymsg.Count.ToString();
                }
                bllmsg.UpdateReceiveMessage(Pub.UserId);

            }



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
            FormPersonManage FormPersonManage = new FormPersonManage();
            lblNav.Text = FormPersonManage.Text;
            LoadControl(FormPersonManage);
        }

        private void btnDeptManage_Click(object sender, EventArgs e)
        {
            FormDeptManage FormDeptManage = new FormDeptManage();
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
            FormPDAManage formPdaManage = new FormPDAManage();
            lblNav.Text = formPdaManage.Text;
            LoadControl(formPdaManage);
        }

        private void btnCardManage_Click(object sender, EventArgs e)
        {
            FormCardManage formCardManage = new FormCardManage();
            lblNav.Text = formCardManage.Text;
            LoadControl(formCardManage);
        }

        private void btnMaterielType_Click(object sender, EventArgs e)
        {
            FormMaterielTypeManage formMaterielTypeManage = new FormMaterielTypeManage();
            lblNav.Text = formMaterielTypeManage.Text;
            LoadControl(formMaterielTypeManage);
        }

        private void btnPasswordEdit_Click(object sender, EventArgs e)
        {
            FormPasswordEdit formPasswordEdit = new FormPasswordEdit();
            formPasswordEdit.ShowDialog();
        }

        private void btnUserManage_Click(object sender, EventArgs e)
        {
            FormUserManage formUserManage = new FormUserManage();
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
            FormSystemLog formSystemLog = new FormSystemLog();
            lblNav.Text = formSystemLog.Text;
            LoadControl(formSystemLog);
        }

        private void btnRuleManage_Click(object sender, EventArgs e)
        {
            FormRuleManage formRuleManage = new FormRuleManage(this);
            lblNav.Text = formRuleManage.Text;
            LoadControl(formRuleManage);
        }

        private void btnCarTypeManage_Click(object sender, EventArgs e)
        {
            FormVehicleTypeManage formVehicleTypeManage = new FormVehicleTypeManage();
            lblNav.Text = formVehicleTypeManage.Text;
            LoadControl(formVehicleTypeManage);
        }

        private void btnCarManage_Click(object sender, EventArgs e)
        {
            FormVehicleManage formVehicleManage = new FormVehicleManage();
            lblNav.Text = formVehicleManage.Text;
            LoadControl(formVehicleManage);
        }

        //车辆报废
        private void btnCarScraped_Click(object sender, EventArgs e)
        {
            FormVehicleScrapManage formVehicleScrapManage = new FormVehicleScrapManage();
            lblNav.Text = formVehicleScrapManage.Text;
            LoadControl(formVehicleScrapManage);
        }

        //车辆维护
        private void btnVehicleMaintain_Click(object sender, EventArgs e)
        {
            FormVehicleMainTainManage formVehicleMainTainManage = new FormVehicleMainTainManage();
            lblNav.Text = formVehicleMainTainManage.Text;
            LoadControl(formVehicleMainTainManage);
        }

        //检修超期告警
        private void btnMaintainTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryMaintainTimeOutAlarm formHistoryMaintainTimeOutAlarm = new FormHistoryMaintainTimeOutAlarm(EnumAlarmType.MaintainTimeOutAlarm);
            lblNav.Text = formHistoryMaintainTimeOutAlarm.Text;
            LoadControl(formHistoryMaintainTimeOutAlarm);
        }

        //报废超期告警
        private void btnScrapTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryScrapTimeOutAlarm formHistoryScrapTimeOutAlarm = new FormHistoryScrapTimeOutAlarm(EnumAlarmType.ScrapTimeOutAlarm);
            lblNav.Text = formHistoryScrapTimeOutAlarm.Text;
            LoadControl(formHistoryScrapTimeOutAlarm);
        }

        //供车不及时告警
        private void btnGiveTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryGiveTimeOutAlarm formHistoryGiveTimeOutAlarm = new FormHistoryGiveTimeOutAlarm(EnumAlarmType.GiveTimeOutAlarm);
            lblNav.Text = formHistoryGiveTimeOutAlarm.Text;
            LoadControl(formHistoryGiveTimeOutAlarm);
        }

        //装车不及时告警
        private void btnLoadTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryLoadTimeOutAlarm formHistoryLoadTimeOutAlarm = new FormHistoryLoadTimeOutAlarm(EnumAlarmType.LoadTimeOutAlarm);
            lblNav.Text = formHistoryLoadTimeOutAlarm.Text;
            LoadControl(formHistoryLoadTimeOutAlarm);
        }

        //未按时运送告警
        private void btnTransportTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryTransportTimeOutAlarm formHistoryTransportTimeOutAlarm = new FormHistoryTransportTimeOutAlarm(EnumAlarmType.TransportTimeOutAlarm);
            lblNav.Text = formHistoryTransportTimeOutAlarm.Text;
            LoadControl(formHistoryTransportTimeOutAlarm);
        }
        
        //卸车不及时告警
        private void btnUnLoadTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryUnLoadTimeOutAlarm formHistoryUnLoadTimeOutAlarm = new FormHistoryUnLoadTimeOutAlarm(EnumAlarmType.UnLoadTimeOutAlarm);
            lblNav.Text = formHistoryUnLoadTimeOutAlarm.Text;
            LoadControl(formHistoryUnLoadTimeOutAlarm);
        }

        //还车不及时告警
        private void btnBackTimeOutAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryBackTimeOutAlarm formHistoryBackTimeOutAlarm = new FormHistoryBackTimeOutAlarm(EnumAlarmType.BackTimeOutAlarm);
            lblNav.Text = formHistoryBackTimeOutAlarm.Text;
            LoadControl(formHistoryBackTimeOutAlarm);
        }

        //闲置告警
        private void btnNoUseAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryNoUseAlarm formHistoryNoUseAlarm = new FormHistoryNoUseAlarm(EnumAlarmType.NoUseAlarm);
            lblNav.Text = formHistoryNoUseAlarm.Text;
            LoadControl(formHistoryNoUseAlarm);
        }

        //运行方向不正确告警
        private void btnRunDerictionAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryRunDerictionAlarm formHistoryRunDerictionAlarm = new FormHistoryRunDerictionAlarm(EnumAlarmType.RunDerictionAlarm);
            lblNav.Text = formHistoryRunDerictionAlarm.Text;
            LoadControl(formHistoryRunDerictionAlarm);
        }

        //未置换状态告警
        private void btnNoChanageStateAlarm_Click(object sender, EventArgs e)
        {
            FormHistoryNoChanageStateAlarm formHistoryNoChanageStateAlarm = new FormHistoryNoChanageStateAlarm(EnumAlarmType.NoChanageStateAlarm);
            lblNav.Text = formHistoryNoChanageStateAlarm.Text;
            LoadControl(formHistoryNoChanageStateAlarm);
        }

        //顶部申请按钮
        private void btnapply_Click(object sender, EventArgs e)
        {
            FormApplyMgrManage frmapply = new FormApplyMgrManage();
            DialogResult result = frmapply.ShowDialog();
            if (result == DialogResult.Yes)
            {
                frmapply.Close();
                if (Pub.ListFunRight.Contains("btnCheck"))
                {
                    FormReviewMaterEdit frmreview = new FormReviewMaterEdit(frmapply.ListApplyMater, frmapply.Apply, true);

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
                if (Pub.ListFunRight.Contains("btnCheck"))
                {
                    FormReviewCarEdit frmreview = new FormReviewCarEdit(frmapply.ListApplyCar, frmapply.Apply, true);
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

        //顶部审核按钮
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
            FormHandover frmtransfer = new FormHandover();
            frmtransfer.ShowDialog();
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
            FormSendMessage formSendMessage = new FormSendMessage();
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

        //物料运输管理Panel
        private void panelFlow_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelFlow.Expanded)
            {
                panelCar.Expanded = false;
                panelConfig.Expanded = false;
                panelAlarm.Expanded = false;
                panelAnaly.Expanded = false;
                panelBaseinfo.Expanded = false;
                panelLog.Expanded = false;
            }
        }

        //基础信息管理Panel
        private void panelBaseinfo_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelBaseinfo.Expanded)
            {
                panelCar.Expanded = false;
                panelConfig.Expanded = false;
                panelFlow.Expanded = false;
                panelAlarm.Expanded = false;
                panelAnaly.Expanded = false;
                panelLog.Expanded = false;
            }
        }

        //统计分析Panel
        private void panelAnaly_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelAnaly.Expanded)
            {
                panelCar.Expanded = false;
                panelConfig.Expanded = false;
                panelFlow.Expanded = false;
                panelAlarm.Expanded = false;
                panelBaseinfo.Expanded = false;
                panelLog.Expanded = false;
            }
        }

        //告警查询Panel
        private void panelAlarm_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelAlarm.Expanded)
            {
                panelCar.Expanded = false;
                panelConfig.Expanded = false;
                panelFlow.Expanded = false;
                panelAnaly.Expanded = false;
                panelBaseinfo.Expanded = false;
                panelLog.Expanded = false;
            }
        }

        //系统管理Panel
        private void panelConfig_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelConfig.Expanded)
            {
                panelCar.Expanded = false;
                panelFlow.Expanded = false;
                panelAlarm.Expanded = false;
                panelAnaly.Expanded = false;
                panelBaseinfo.Expanded = false;
                panelLog.Expanded = false;
            }
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
            FormMaterielTypeMonth formMaterielTypeMonth = new FormMaterielTypeMonth();
            lblNav.Text = formMaterielTypeMonth.Text;
            LoadControl(formMaterielTypeMonth);
        }

        //顶部关闭按钮
        private void btnclose_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否退出系统？", "提示", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Pub.BackServer.SendUnlogin();
                Application.Exit();
            }

        }

        //顶部地图按钮
        private void btnMap_Click(object sender, EventArgs e)
        {
            lblNav.Text = "地图";
            LoadControl(Pub.GISForm);
        }

        //顶部状态查询按钮
        private void btnquery_Click(object sender, EventArgs e)
        {
            FormPlanQuery frmplan = new FormPlanQuery();
            lblNav.Text = frmplan.Text;
            LoadControl(frmplan);
        }

        //日志查询pannel
        private void panelLog_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelLog.Expanded)
            {
                panelConfig.Expanded = false;
                panelFlow.Expanded = false;
                panelAlarm.Expanded = false;
                panelAnaly.Expanded = false;
                panelBaseinfo.Expanded = false;
                panelCar.Expanded = false;
            }
        }

        //车辆管理pannel
        private void panelCar_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
        {
            if (panelCar.Expanded)
            {
                panelConfig.Expanded = false;
                panelFlow.Expanded = false;
                panelAlarm.Expanded = false;
                panelAnaly.Expanded = false;
                panelBaseinfo.Expanded = false;
                panelLog.Expanded = false;
            }
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblTimes.Text = DateTime.Now.ToString("HH:mm:ss");
            lblWeeks.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
        }

        //退出系统
        private void btnpicclose_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("是否退出系统？", "提示", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                Pub.BackServer.SendUnlogin();
                Application.Exit();
            }
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.Location = new Point(100, 100);
                this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 200, Screen.PrimaryScreen.WorkingArea.Height - 200);
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnVehicleDept_Click(object sender, EventArgs e)
        {
            FormDeptVehicleReport formDeptVehicleReport = new FormDeptVehicleReport();
            lblNav.Text = formDeptVehicleReport.Text;
            LoadControl(formDeptVehicleReport);
        }

        private void btnDeptMaterielTypeReport_Click(object sender, EventArgs e)
        {
            FormDeptMaterielTypeReport formDeptMaterielTypeReport = new FormDeptMaterielTypeReport();
            lblNav.Text = formDeptMaterielTypeReport.Text;
            LoadControl(formDeptMaterielTypeReport);
        }

        public void ShowGis(FrmGIS frmgis)
        {
            panelMain.Controls.Clear();
            frmgis.TopLevel = false;
            frmgis.Show();
            frmgis.Dock = DockStyle.Fill;
            panelMain.Visible = false;
            panelMain.Controls.Add(frmgis);
            panelMain.Visible = true;
        }

        public void CloseGis(FrmGIS frmgis)
        {
            panelMain.Controls.Clear();
            panelMain.Visible = false;
            this.panRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelBorderLeft.Dock = System.Windows.Forms.DockStyle.Left;

            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelborder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;

            this.panelMain.Controls.Add(this.panRight);
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.panelLeftBar);
            this.panelMain.Controls.Add(this.panelBorderRight);
            this.panelMain.Controls.Add(this.panelBorderLeft);
            this.panelMain.Controls.Add(this.panelBottom);
            this.panelMain.Controls.Add(this.panelborder);
            this.panelMain.Controls.Add(this.panelTitle);
            this.panelMain.Controls.Add(this.panelTop);
            LoadControl(frmgis);
            panelMain.Visible = true;
        }
        #region//当前告警按钮
        private void lblAlarmCounts_Click(object sender, EventArgs e)
        {
            panelAlarms_Click(null, null);
        }

        private void lblCurrentAlarm_Click(object sender, EventArgs e)
        {
            panelAlarms_Click(null, null);
        }
        
        private void panelAlarms_Click(object sender, EventArgs e)
        {
            if (int.Parse(lblAlarmCounts.Text) != 0)
            {
                FormCurrentAlarm formVehicleCurrentAlarm = new FormCurrentAlarm();
                formVehicleCurrentAlarm.ShowDialog();
            }
            else
            {
                MessageBoxEx.Show("当前无告警！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

        }
        #endregion
        private void labcheckstate_Click(object sender, EventArgs e)
        {
            FormReviewMgr frmreview = new FormReviewMgr(false);
            lblNav.Text = frmreview.Text;
            LoadControl(frmreview);

        }

        private void labmsg_Click(object sender, EventArgs e)
        {
            UI.FrmQryMsg frmqry = new FrmQryMsg();
            lblNav.Text = frmqry.Text;
            LoadControl(frmqry);
        }

        private void labmymsg_Click(object sender, EventArgs e)
        {

            List<Model.m_Message> listmymsg = bllmsg.GetModelList("i_Flag=0 and i_read=0 and ToUserID=" + Pub.UserId);
            FrmMyMsg frmmsg = new FrmMyMsg(listmymsg);
            lblNav.Text = frmmsg.Text;
            bllmsg.UpdateReadMessage(Pub.UserId);
            LoadControl(frmmsg);
        }

        private void btnVehicleStatistics_Click(object sender, EventArgs e)
        {
            FormVehicleStatisticsReport formVehicleStatisticsReport = new FormVehicleStatisticsReport();
            lblNav.Text = formVehicleStatisticsReport.Text;
            LoadControl(formVehicleStatisticsReport);
        }

        private void btnCheckReport_Click(object sender, EventArgs e)
        {
            FormCheckReport formCheckReport = new FormCheckReport();
            lblNav.Text = formCheckReport.Text;
            LoadControl(formCheckReport);
        }

        //锁定系统
        private void btnLockSystem_Click(object sender, EventArgs e)
        {
            FormLockSystem formLockSystem = new FormLockSystem();
            formLockSystem.ShowDialog();
        }

        //切换用户按钮
        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show("确定切换用户？", "提示", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Pub.BackServer.SendUnlogin();
                Application.Exit();
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }

        }

    }
}
