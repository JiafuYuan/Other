using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using Common.MessageBoxEx;
using DB_VehicleTransportManage.BLL;

namespace VehicleTransportClient
{
    public partial class FormHistoryAlarm : Form
    {
        private EnumAlarmType _type;
        private string _tableName = "FormHistoryAlarm";
        private int _selectIndex = -1;
        private string strAlarmType = "";
        public FormHistoryAlarm(EnumAlarmType type)
        {
            InitializeComponent();
            _type = type;
            switch (type)
            {
                case EnumAlarmType.MaintainTimeOutAlarm:
                    strAlarmType = "检修超期告警";
                    dgvList.Columns["Code"].Visible = false;
                    dgvListHistory.Columns["historyPlanCode"].Visible = false;
                    break;
                case EnumAlarmType.ScrapTimeOutAlarm:
                    strAlarmType = "报废超期告警";
                    dgvList.Columns["Code"].Visible = false;
                    dgvListHistory.Columns["historyPlanCode"].Visible = false;
                    break;
                case EnumAlarmType.GiveTimeOutAlarm:
                    strAlarmType = "供车不及时告警";
                    break;
                case EnumAlarmType.LoadTimeOutAlarm:
                     strAlarmType = "装车不及时告警";
                    break;
                case EnumAlarmType.TransportTimeOutAlarm:
                     strAlarmType = "未按时运送告警";
                    break;
                case EnumAlarmType.UnLoadTimeOutAlarm:
                     strAlarmType = "卸车不及时告警";
                    break;
                case EnumAlarmType.BackTimeOutAlarm:
                     strAlarmType = "还车不及时告警";
                    break;
                case EnumAlarmType.NoUseAlarm:
                     strAlarmType = "闲置告警";
                    break;
                case EnumAlarmType.RunDerictionAlarm:
                     strAlarmType = "运行方向不正确告警";
                    break;
                case EnumAlarmType.NoChanageStateAlarm:
                     strAlarmType = "未置换状态告警";
                    break;
                default:
                    break;
            }
            this.Text = strAlarmType;
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            dgvListHistory.CellClick += new DataGridViewCellEventHandler(dgvListHistory_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvListHistory);
            this.Load += new EventHandler(FormHistoryAlarm_Load);
            dtInputStart.Value = DateTime.Parse(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd 00:00:00"));
            dtInputStop.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
        }

        /// <summary>双击历史Grid事件
        /// 双击历史Grid事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dgvListHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        /// <summary> 窗体初始化
        /// 窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormHistoryAlarm_Load(object sender, EventArgs e)
        {
            LoadCurrentAlarmData();
        }

        /// <summary>双击当前告警Grid行事件
        /// 双击当前告警Grid行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        /// <summary>获取历史告警数据
        /// 获取历史告警数据
        /// </summary>
        /// <param name="dtStart">告警开始时间开始</param>
        /// <param name="dtStop">告警开始时间结束</param>
        public void LoadHistoryAlarmData(string dtStart, string dtStop)
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst =
                 new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                 GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start>='" + dtInputStart.Value + "' and dt_Start<='" + dtInputStop.Value + "' and dt_End is not null and i_AlarmType=" + (int)_type);

            dgvListHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListHistory.AllowUserToAddRows = false;
            dgvListHistory.ReadOnly = true;

            dgvListHistory.Rows.Clear();
            string actionTypeName = "";
            
            
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = dgvListHistory.Rows.Add(item.vc_PlanCode,item.vc_Code, item.vc_Name, item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"), item.dt_End == null ? "" : item.dt_End.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvListHistory.Rows[i].Tag = item;
            }
          
            lblCount.Text = "共有" + dgvListHistory.Rows.Count.ToString() + "条告警记录";
            dgvListHistory.ClearSelection();
            _selectIndex = -1;
        }

        /// <summary>获取当前告警数据
        /// 获取当前告警数据
        /// </summary>
        public void LoadCurrentAlarmData()
        {
            List<DB_VehicleTransportManage.Model.v_VehicleAlarm> lst = 
                new DB_VehicleTransportManage.BLL.v_VehicleAlarm().
                GetModelList("i_flag=0 and i_IsPreAlarm=0 and dt_Start is not null and dt_End is null and i_AlarmType=" + (int)_type);

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            string actionTypeName = "";
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_PlanCode,item.vc_Code, item.vc_Name, item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count.ToString() + "条告警记录";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        /// <summary>历史告警查询
        /// 历史告警查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (dtInputStart.Value >= dtInputStop.Value)
            {
                Common.MessageBoxEx.MessageBoxEx.Show("开始日期应在结束日期之前", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtInputStart.Value.AddMonths(2) < dtInputStop.Value)
            {
                Common.MessageBoxEx.MessageBoxEx.Show("只允许查询时间间隔在2个月内的历史数据", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadHistoryAlarmData(dtInputStart.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtInputStop.Value.ToString("yyyy-MM-dd HH:mm:ss"));

        }

        /// <summary>当前告警Tab页
        /// 当前告警Tab页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemCurrentAlarm_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmData();
        }

        /// <summary>历史告警Tab页
        /// 历史告警Tab页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItemHistoryAlarm_Click(object sender, EventArgs e)
        {
            LoadHistoryAlarmData(dtInputStart.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtInputStop.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        }


        /// <summary>当前告警刷新
        /// 当前告警刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCurrentAlarmData();
        }

        /// <summary>当前告警Grid样式
        /// 当前告警Grid样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }

        /// <summary>历史告警刷新
        /// 历史告警刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
         
        }

        /// <summary>历史告警Grid样式
        /// 历史告警Grid样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStyle2_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvListHistory);
        }

      

      

    }
}
