using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Controls;
using Common.Enum;
using DB_VehicleTransportManage;
using DevExpress.XtraBars.ViewInfo;
using DevExpress.XtraDataLayout;
using VehicleTransportClient.Com;
using DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Common.MessageBoxEx;
using m_SystemConfig = DB_VehicleTransportManage.Model.m_SystemConfig;

namespace VehicleTransportClient
{
    public partial class FormAlarmSet : Common.frmBase
    {
        private DB_VehicleTransportManage.BLL.m_SystemConfig bllSystemConfig = new DB_VehicleTransportManage.BLL.m_SystemConfig();
        public FormAlarmSet()
        {
            InitializeComponent();
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.FormTitle = "系统设置";
            if (Pub.FlowPath.Back == false)
            {
                txtBackVehicle.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
            }
         
            ShowConfig();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (UpdateConfig())
            {
                MessageBoxEx.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public bool UpdateConfig()
        {
            bool bState = true;
            if (bllSystemConfig.SetValue(EnumSystemConfigKeys.LoadVehicleTimeOut, txtLoadVehicle.Text.Trim()))
            {
                OperationLog.InsertSqlLog(EnumActionType.Update, "修改系统配置项",
                    "【装车超时设置】为【" + txtLoadVehicle.Text.Trim() + "】", "");
            }
            else
            {
                bState = false;
            }
            if (bllSystemConfig.SetValue(EnumSystemConfigKeys.UnLoadVehicleTimeOut, txtUnLoadVehicle.Text.Trim()))
            {
                OperationLog.InsertSqlLog(EnumActionType.Update, "修改系统配置项",
                                 "【卸车超时设置】为【" + txtUnLoadVehicle.Text.Trim() + "】", "");
            }
            else
            {
                bState = false;
            }
            if (bllSystemConfig.SetValue(EnumSystemConfigKeys.BackVehicleTimeOut, txtBackVehicle.Text.Trim()))
            {
                OperationLog.InsertSqlLog(EnumActionType.Update, "修改系统配置项",
                       "【还车超时设置】为【" + txtBackVehicle.Text.Trim() + "】", "");
            }
            else
            {
                bState = false;
            }
            if (bllSystemConfig.SetValue(EnumSystemConfigKeys.UnUsedVehicleTimeOutAlarm, txtUnusedVehicleTime.Text.Trim()))
            {

                OperationLog.InsertSqlLog(EnumActionType.Update, "修改系统配置项",
                      "【车辆闲置告警】为【" + txtUnusedVehicleTime.Text.Trim() + "】", "");
            }
            else
            {
                bState = false;
            }
            if (bllSystemConfig.SetValue(EnumSystemConfigKeys.PDAOffLineTimeOut, txtPDAOffLine.Text.Trim()))
            {

                OperationLog.InsertSqlLog(EnumActionType.Update, "修改系统配置项",
                       "【PDA离线数据处理设置】为【" + txtPDAOffLine.Text.Trim() + "】", "");
            }
            else
            {
                bState = false;
            }
            string strHaveKJ222Client = cbTrue.Checked?"1":"0";
            if (bllSystemConfig.SetValue(EnumSystemConfigKeys.HaveKJ222Client, strHaveKJ222Client))
            {

                OperationLog.InsertSqlLog(EnumActionType.Update, "修改系统配置项",
                       "【是否存在KJ222客户程序】为【" + strHaveKJ222Client + "】", "");
            }
            else
            {
                bState = false;
            }

            return bState;
        }

        public void ShowConfig()
        {
            txtLoadVehicle.Text = bllSystemConfig.GetValue(EnumSystemConfigKeys.LoadVehicleTimeOut);

            txtUnLoadVehicle.Text = bllSystemConfig.GetValue(EnumSystemConfigKeys.UnLoadVehicleTimeOut);

            txtBackVehicle.Text = bllSystemConfig.GetValue(EnumSystemConfigKeys.BackVehicleTimeOut);

            txtUnusedVehicleTime.Text = bllSystemConfig.GetValue(EnumSystemConfigKeys.UnUsedVehicleTimeOutAlarm);

            txtPDAOffLine.Text = bllSystemConfig.GetValue(EnumSystemConfigKeys.PDAOffLineTimeOut);

            cbTrue.Checked = bllSystemConfig.GetValue(EnumSystemConfigKeys.HaveKJ222Client) == "0" ? false : true;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLoadVehicle_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtBackVehicle_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtUnLoadVehicle_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtUnusedVehicleTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtPDAOffLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }



    }
}
