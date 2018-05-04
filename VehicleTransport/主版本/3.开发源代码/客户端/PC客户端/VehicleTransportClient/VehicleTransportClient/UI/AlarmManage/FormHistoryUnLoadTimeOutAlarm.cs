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
    public partial class FormHistoryUnLoadTimeOutAlarm : Form
    {
        private EnumAlarmType _type;
        private string _tableName = "FormHistoryUnLoadTimeOutAlarm";
        private int _selectIndex = -1;
        public FormHistoryUnLoadTimeOutAlarm(EnumAlarmType type)
        {
            InitializeComponent();
            _type = type;
          
            this.Text = "卸车不及时告警";
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvListHistory_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormHistoryUnLoadTimeOutAlarm_Load);
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
        void FormHistoryUnLoadTimeOutAlarm_Load(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        /// <summary>双击历史告警Grid行事件
        /// 双击历史告警Grid行事件
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

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
         
            foreach (DB_VehicleTransportManage.Model.v_VehicleAlarm item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_PlanCode,item.ApplyDepartmentName, item.ArriveDestinationAddressName,
                    item.dt_Start == null ? "" : item.dt_Start.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"), item.dt_End == null ? "" : item.dt_End.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒"));
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

        /// <summary>历史告警刷新
        /// 历史告警刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnSearch_Click(null,null);
        }

        /// <summary>历史告警Grid样式
        /// 历史告警Grid样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }

       
    }
}
