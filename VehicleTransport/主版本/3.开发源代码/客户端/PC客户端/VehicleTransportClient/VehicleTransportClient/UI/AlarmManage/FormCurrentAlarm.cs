using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Controls;
using Common.Enum;
using DevExpress.XtraBars.ViewInfo;
using DevExpress.XtraDataLayout;
using VehicleTransportClient.Com;
using BLL=DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Common.MessageBoxEx;
using VehicleTransportClient.Tools;

namespace VehicleTransportClient
{
    public partial class FormCurrentAlarm : Common.frmBase
    {
        private string _tableNameMaintainTimeOutAlarm = "FormMaintainTimeOutAlarm";
        private string _tableNameScrapTimeOutAlarm = "FormScrapTimeOutAlarm";
        private string _tableNameBackTimeOutAlarm = "FormBackTimeOutAlarm";
        private string _tableNameGiveTimeOutAlarm = "FormGiveTimeOutAlarm";
        private string _tableNameLoadTimeOutAlarm = "FormLoadTimeOutAlarm";
        private string _tableNameNoChanageStateAlarm = "FormNoChanageStateAlarm";
        private string _tableNameNoUseAlarm = "FormNoUseAlarm";
        private string _tableNameRunDerictionAlarm = "FormRunDerictionAlarm";
        private string _tableNameTransportTimeOutAlarm = "FormTransportTimeOutAlarm";
        private string _tableNameUnLoadTimeOutAlarm = "FormUnLoadTimeOutAlarm";

        public FormCurrentAlarm()
        {
            InitializeComponent();
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.FormTitle = "当前告警";
            Pub.StyleManager.SetGridStyle(_tableNameMaintainTimeOutAlarm, this.dgvListMaintainTimeOutAlarm);
            Pub.StyleManager.SetGridStyle(_tableNameScrapTimeOutAlarm, this.dgvListScrapTimeOutAlarm);
            Pub.StyleManager.SetGridStyle(_tableNameBackTimeOutAlarm, this.dgvListBackTimeOutAlarm);
            Pub.StyleManager.SetGridStyle(_tableNameGiveTimeOutAlarm, this.dgvListGiveTimeOutAlarm);
            Pub.StyleManager.SetGridStyle(_tableNameLoadTimeOutAlarm, this.dgvListLoadTimeOutAlarm);
            Pub.StyleManager.SetGridStyle(_tableNameNoChanageStateAlarm, this.dgvListNoChanageStateAlarm);
            Pub.StyleManager.SetGridStyle(_tableNameNoUseAlarm, this.dgvListNoUseAlarm);
            Pub.StyleManager.SetGridStyle(_tableNameRunDerictionAlarm, this.dgvListRunDerictionAlarm);
            Pub.StyleManager.SetGridStyle(_tableNameTransportTimeOutAlarm, this.dgvListTransportTimeOutAlarm);
            Pub.StyleManager.SetGridStyle(_tableNameUnLoadTimeOutAlarm, this.dgvListUnLoadTimeOutAlarm);
            this.Load += new EventHandler(FormCurrentAlarm_Load);
        }

        List<int> listIndex=new List<int>(); 
        /// <summary> 窗体初始化
        /// 窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormCurrentAlarm_Load(object sender, EventArgs e)
        {
           
            #region//隐藏无告警数据的Tab页
           
            // 未置换状态告警
            if (CurrentAlarmDataNoPlan(10))
            {
                TabItemNoChanageStateAlarm.Visible = false;
            }
            else
            {
                TabItemNoChanageStateAlarm_Click(null, null);
                listIndex.Add(9);
            }
            //运行方向不正确告警
            if (CurrentAlarmDataNoPlan(9))
            {
                TabItemRunDerictionAlarm.Visible = false;
            }
            else
            {
                TabItemRunDerictionAlarm_Click(null, null);
                listIndex.Add(8);
            }
            //闲置告警
            if (CurrentAlarmDataNoPlan(8))
            {
                TabItemNoUseAlarm.Visible = false;
            }
            else
            {
                TabItemNoUseAlarm_Click(null, null);
                listIndex.Add(7);
            }
            //还车不及时告警
            if (CurrentAlarmDataNoPlan(7) || Pub.FlowPath.Back == false)
            {
                TabItemBackTimeOutAlarm.Visible = false;
            }
            else
            {
                TabItemBackTimeOutAlarm_Click(null, null);
                listIndex.Add(6);
            }
            //卸车不及时告警
            if (CurrentAlarmDataNoPlan(6))
            {
                TabItemUnLoadTimeOutAlarm.Visible = false;
            }
            else
            {
                TabItemUnLoadTimeOutAlarm_Click(null, null);
                listIndex.Add(5);
            }
            //未按时运送告警
            if (CurrentAlarmDataNoPlan(5))
            {
                TabItemTransportTimeOutAlarm.Visible = false;
            }
            else
            {
                TabItemTransportTimeOutAlarm_Click(null, null);
                listIndex.Add(4);
            }
            //装车不及时告警
            if (CurrentAlarmDataNoPlan(4))
            {
                TabItemLoadTimeOutAlarm.Visible = false;
            }
            else
            {
                TabItemLoadTimeOutAlarm_Click(null, null);
                listIndex.Add(3);
            }
            //供车不及时告警
            if (CurrentAlarmDataNoPlan(3) || Pub.FlowPath.Give == false)
            {
                TabItemGiveTimeOutAlarm.Visible = false;
            }
            else
            {
                TabItemGiveTimeOutAlarm_Click(null, null);
                listIndex.Add(2);
            }

            //报废超期告警
            if (CurrentAlarmDataNoPlan(2))
            {
                TabItemScrapTimeOutAlarm.Visible = false;
            }
            else
            {
                TabItemScrapTimeOutAlarm_Click(null, null);
                listIndex.Add(1);
            }
            //检修超期告警
            if (CurrentAlarmDataNoPlan(1))
            {
                TabItemMaintainTimeOutAlarm.Visible = false;
            }
            else
            {
                TabItemMaintainTimeOutAlarm_Click(null, null);
                listIndex.Add(0);
            }
            if (listIndex.Count > 0)
            {
                listIndex.Sort();
                TabControlCurrentAlarm.SelectedTabIndex = listIndex[0];
            }
            #endregion
        }

        /// <summary>获取当前告警数据
        /// 获取当前告警数据
        /// </summary>
        public bool CurrentAlarmDataNoPlan(int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                    GetModelList(
                        "i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" +
                        iAlarmType);
            if (lst.Count > 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>获取当前告警数据
        /// 获取当前告警数据
        /// </summary>
        public void LoadCurrentAlarmDataNoPlan(DataGridViewEx dgvList, int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + iAlarmType);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = 0;
               
                    i = dgvList.Rows.Add(item.vc_Code, item.vc_Name, item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
        }

        /// <summary>获取当前报废超期告警数据
        /// 获取当前报废超期告警数据
        /// </summary>
        public void LoadCurrentAlarmDataScrapTimeOutAlarm(DataGridViewEx dgvList, int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + iAlarmType);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = 0;

                i = dgvList.Rows.Add(item.vc_Code, item.vc_Name,item.dt_ScrapDateTime == null ? "" : item.dt_ScrapDateTime.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"),item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
        }
        /// <summary>获取检修超期告警数据
        /// 获取检修超期告警数据
        /// </summary>
        public void LoadCurrentAlarmDataMaintainTimeOutAlarm(DataGridViewEx dgvList, int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + iAlarmType);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = 0;

                i = dgvList.Rows.Add(item.vc_Code, item.vc_Name, item.i_MaintainInterval, item.dt_LastMaintainDateTIme == null ? "" : item.dt_LastMaintainDateTIme.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"), item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
        }
        //供车不及时告警
        public void LoadCurrentAlarmDataGiveTimeOutAlarm(DataGridViewEx dgvList, int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + iAlarmType);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_PlanCode,item.ApplyDepartmentName,item.ArriveDestinationAddressName,
                item.PlanGiveCarDepartmentName, item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
        }
        //装车不及时
        public void LoadCurrentAlarmDataLoadTimeOutAlarm(DataGridViewEx dgvList, int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + iAlarmType);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_PlanCode, item.ApplyDepartmentName, item.ArriveDestinationAddressName,
                item.PlanLoadDepartmentName,  item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
        }

        //未按时运送
        public void LoadCurrentAlarmDataTransportTimeOutAlarm(DataGridViewEx dgvList, int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + iAlarmType);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_PlanCode, item.ApplyDepartmentName, item.ArriveDestinationAddressName,
                item.dt_ArriveDestinationDateTime == null ? "" : item.dt_ArriveDestinationDateTime.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"), item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
        }
        //卸车不及时告警
        public void LoadCurrentAlarmDataUnLoadTimeOutAlarm(DataGridViewEx dgvList, int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + iAlarmType);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_PlanCode, item.ApplyDepartmentName, item.ArriveDestinationAddressName,
                 item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
        }
        //还车不及时
        public void LoadCurrentAlarmDataBackTimeOutAlarm(DataGridViewEx dgvList, int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + iAlarmType);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_PlanCode, item.ApplyDepartmentName, item.ArriveDestinationAddressName,
                item.PlanBackDepartmentName, item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
        }
           
        //未置换状态告警
        public void LoadCurrentAlarmDataNoChanageStateAlarm(DataGridViewEx dgvList, int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + iAlarmType);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_PlanCode, item.ApplyDepartmentName, item.ArriveDestinationAddressName,
                 item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
        }
        public void LoadCurrentAlarmDataNoUseAlarm(DataGridViewEx dgvList, int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + iAlarmType);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_Code, item.vc_Name,item.LocalizerStationName, item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
        }
        public void LoadCurrentAlarmData(DataGridViewEx dgvList, int iAlarmType)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + iAlarmType);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;
            dgvList.Rows.Clear();
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_PlanCode, item.vc_Code, item.vc_Name, item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
        }


        /// <summary>检修超期告警
        /// 检修超期告警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemMaintainTimeOutAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataMaintainTimeOutAlarm(dgvListMaintainTimeOutAlarm, 1);
        }

        /// <summary>当前告警刷新
        /// 当前告警刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataMaintainTimeOutAlarm(dgvListMaintainTimeOutAlarm, 1);
        }

        /// <summary>当前告警Grid样式
        /// 当前告警Grid样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameMaintainTimeOutAlarm, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableNameMaintainTimeOutAlarm, this.dgvListMaintainTimeOutAlarm);
        }


        /// <summary>报废超期告警
        /// 报废超期告警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemScrapTimeOutAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataScrapTimeOutAlarm(dgvListScrapTimeOutAlarm, 2);
        }

        private void btnSxCq_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataScrapTimeOutAlarm(dgvListScrapTimeOutAlarm, 2);
        }

        private void btnYsCq_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameScrapTimeOutAlarm, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableNameScrapTimeOutAlarm, this.dgvListScrapTimeOutAlarm);
        }
        /// <summary>供车不及时告警
        /// 供车不及时告警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemGiveTimeOutAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataGiveTimeOutAlarm(dgvListGiveTimeOutAlarm, 3);
        }
        private void btnSxGcAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataGiveTimeOutAlarm(dgvListGiveTimeOutAlarm, 3);
        }

        private void btnYsGcAlarm_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameGiveTimeOutAlarm, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableNameGiveTimeOutAlarm, this.dgvListGiveTimeOutAlarm);
        }
        /// <summary>装车不及时告警
        /// 装车不及时告警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemLoadTimeOutAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataLoadTimeOutAlarm(dgvListLoadTimeOutAlarm, 4);
        }

        private void btnSxLoadTimeOutAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataLoadTimeOutAlarm(dgvListLoadTimeOutAlarm, 4);
        }

        private void btnYsLoadTimeOutAlarm_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameLoadTimeOutAlarm, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableNameLoadTimeOutAlarm, this.dgvListLoadTimeOutAlarm);
        }
        /// <summary>未按时运送告警
        /// 未按时运送告警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemTransportTimeOutAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataTransportTimeOutAlarm(dgvListTransportTimeOutAlarm, 5);
        }

        private void btnSxTransportTimeOutAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataTransportTimeOutAlarm(dgvListTransportTimeOutAlarm, 5);
        }

        private void btnYsTransportTimeOutAlarm_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameTransportTimeOutAlarm, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableNameTransportTimeOutAlarm, this.dgvListTransportTimeOutAlarm);
        }
        /// <summary>卸车不及时告警
        /// 卸车不及时告警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemUnLoadTimeOutAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataUnLoadTimeOutAlarm(dgvListUnLoadTimeOutAlarm, 6);
        }
        private void btnSxUnLoadTimeOutAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataUnLoadTimeOutAlarm(dgvListUnLoadTimeOutAlarm, 6);
        }

        private void btnYsUnLoadTimeOutAlarm_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameUnLoadTimeOutAlarm, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableNameUnLoadTimeOutAlarm, this.dgvListUnLoadTimeOutAlarm);
        }
        /// <summary>还车不及时告警
        /// 还车不及时告警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemBackTimeOutAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataBackTimeOutAlarm(dgvListBackTimeOutAlarm, 7);
        }

        private void btnSxBackTimeOutAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataBackTimeOutAlarm(dgvListBackTimeOutAlarm, 7);
        }

        private void btnYsBackTimeOutAlarm_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameBackTimeOutAlarm, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableNameBackTimeOutAlarm, this.dgvListBackTimeOutAlarm);
        }

        /// <summary>闲置告警
        /// 闲置告警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemNoUseAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataNoUseAlarm(dgvListNoUseAlarm, 8);
        }


        private void btnSxNoUseAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataNoUseAlarm(dgvListNoUseAlarm, 8);
        }

        private void btnYsNoUseAlarm_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameNoUseAlarm, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableNameNoUseAlarm, this.dgvListNoUseAlarm);
        }
        /// <summary>运行方向不正确告警
        /// 运行方向不正确告警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemRunDerictionAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmData(dgvListRunDerictionAlarm, 9);
        }

        private void btnYsRunDerictionAlarm_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameRunDerictionAlarm, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableNameRunDerictionAlarm, this.dgvListRunDerictionAlarm);
        }

        private void btnSxRunDerictionAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmData(dgvListRunDerictionAlarm, 9);
        }
        /// <summary>未置换状态告警
        /// 未置换状态告警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemNoChanageStateAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataNoChanageStateAlarm(dgvListNoChanageStateAlarm, 10);
        }

        private void btnReNoChanageStateAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmDataNoChanageStateAlarm(dgvListNoChanageStateAlarm, 10);
        }

        private void btnNoChanageStateAlarm_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableNameNoChanageStateAlarm, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableNameNoChanageStateAlarm, this.dgvListNoChanageStateAlarm);
        }

        //private void TabControlCurrentAlarm_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        //{
        //    int TabCount = 0;
        //    if (TabControlCurrentAlarm.SelectedTabIndex == 0)
        //    {
        //        TabCount = dgvListMaintainTimeOutAlarm.Rows.Count;
        //    }
        //    if (TabControlCurrentAlarm.SelectedTabIndex == 1)
        //    {
        //        TabCount = dgvListScrapTimeOutAlarm.Rows.Count;
        //    }
        //    if (TabControlCurrentAlarm.SelectedTabIndex == 2)
        //    {
        //        TabCount = dgvListGiveTimeOutAlarm.Rows.Count;
        //    }
        //    if (TabControlCurrentAlarm.SelectedTabIndex == 3)
        //    {
        //        TabCount = dgvListLoadTimeOutAlarm.Rows.Count;
        //    }
        //    if (TabControlCurrentAlarm.SelectedTabIndex == 4)
        //    {
        //        TabCount = dgvListTransportTimeOutAlarm.Rows.Count;
        //    }
        //    if (TabControlCurrentAlarm.SelectedTabIndex == 5)
        //    {
        //        TabCount = dgvListUnLoadTimeOutAlarm.Rows.Count;
        //    }
        //    if (TabControlCurrentAlarm.SelectedTabIndex == 6)
        //    {
        //        TabCount = dgvListBackTimeOutAlarm.Rows.Count;
        //    }
        //    if (TabControlCurrentAlarm.SelectedTabIndex == 7)
        //    {
        //        TabCount = dgvListNoUseAlarm.Rows.Count;
        //    }
        //    if (TabControlCurrentAlarm.SelectedTabIndex == 8)
        //    {
        //        TabCount = dgvListRunDerictionAlarm.Rows.Count;
        //    }
        //    if (TabControlCurrentAlarm.SelectedTabIndex == 9)
        //    {
        //        TabCount = dgvListNoChanageStateAlarm.Rows.Count;
        //    }
           
        //    lblCount.Text = "共有" + TabCount.ToString() + "条告警记录";
        //}


    }
}
