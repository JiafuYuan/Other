using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Tools.Communication.Net;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using Common.Enum;
using Common.Model;
using Common;
using VehicleTransportServer.Thread.Command.NormalCommand;
using VehicleTransportServer.Model;
using VehicleTransportServer.Thread.Command;
using System.Reflection;

namespace VehicleTransportServer
{
    public partial class FormMain : Form
    {

        private bool _canExit = false;
        private int _logCount = 100;
        private DB_VehicleTransportManage.BLL.m_SystemConfig _systemConfigBLL = new DB_VehicleTransportManage.BLL.m_SystemConfig();
        private bool _isRun = false;
        private List<DB_VehicleTransportManage.Model.m_User> _userList = new List<DB_VehicleTransportManage.Model.m_User>();
        private int _index = 1;

        public FormMain()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer1.Enabled = true;

            timer2.Interval = 2000;
            timer2.Enabled = true;

            Pub._ms = new MainServer();
            _isRun = Pub._ms.Start();
            this.Text = "矿用机车运输管理系统服务器软件 V" + GetVersion();
            this.notifyIcon1.Text = this.Text;

            chkLog.Checked = Pub.ConfigModel.IsSaveLog;

            cboLogCount.Text = Pub.ConfigModel.LogCount.ToString();
            chkShowError.Checked = Pub.ConfigModel.IsHideError;
            chkShowHearbeat.Checked = Pub.ConfigModel.IsHideBreakheat;
            chkShowSend.Checked = Pub.ConfigModel.IsHideSend;
            //lblTime.Alignment = ToolStripItemAlignment.Right;

        }

        private string GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();

            Version ApplicationVersion = assemblyName.Version;
            string version = ApplicationVersion.Major.ToString() + "." + ApplicationVersion.Minor.ToString()
                + "." + ApplicationVersion.Build.ToString();
            return version;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            lblTime.Text = DateTime.Now.ToString();
            //if (chkPasueRoll.Checked)
            //{
            //    timer1.Enabled = true;
            //    return;
            //}
            if (_isRun)
            {
                lblServerInfo.Text = Pub.ConfigModel.ServerIP + ":" + Pub.ConfigModel.ServerPort + " 启动成功";
                lblServerInfo.ForeColor = Color.Green;
            }
            else
            {
                lblServerInfo.Text = Pub.ConfigModel.ServerIP + ":" + Pub.ConfigModel.ServerPort + " 启动失败";
                lblServerInfo.ForeColor = Color.Red;
            }

            if (Pub._isDBOnline == true)
            {
                lblDBInfo.Text = Pub.ConfigModel.DBServer + " 连接成功";
                lblDBInfo.ForeColor = Color.Green;
            }
            else
            {
                lblDBInfo.Text = Pub.ConfigModel.DBServer + " 连接失败";
                lblDBInfo.ForeColor = Color.Red;
            }

            // lblDataCount.Text = Pub.DataCount.ToString();
            lblSocketCount.Text = Pub.SocketCount.ToString();
            if (Pub.CommandLogList.Count > 0)
            {
                Model.LogMessageModel log = Pub.CommandLogList.Dequeue();

                while (dgvList.Rows.Count > _logCount)
                {
                    dgvList.Rows.RemoveAt(0);
                }


                if (chkShowHearbeat.Checked && log.cmdModel.CmdType == EnumCommandType.HeartBeat)
                {
                    //
                }
                else if (chkShowError.Checked && log.LogType == Model.EnumLogType.Server)
                {
                    //
                }
                else if (chkShowSend.Checked && log.LogType == Model.EnumLogType.Send)
                {
                    //
                }
                else
                {
                    if (chkPasueRoll.Checked == false)
                    {
                        dgvList.Rows.Add(_index++,
                            GetLogType(log.LogType),
                            log.LogText,
                            log.LogType == EnumLogType.Receive | log.LogType == EnumLogType.Server ? "" : log.SendResult == true ? "成功" : "失败",
                            GetCmdType(log.cmdModel.CmdType),
                            log.cmdModel.DateTime,
                            log.LogType == EnumLogType.Receive | log.LogType == EnumLogType.Server ? "" : log.cmdModel.Result == true ? "成功" : "失败",
                            log.cmdModel.ErrorDetail,
                            log.cmdModel.CmdModelXml,
                            log.cmdModel.ClientIP,
                            log.cmdModel.ClientPort
                            );
                        dgvList.Rows[dgvList.Rows.Count - 1].Selected = true;
                        dgvList.FirstDisplayedScrollingRowIndex = dgvList.Rows.Count - 1;
                    }
                    if (chkLog.Checked)
                    {
                        WriteLog.AppendRunLog(log.GetMessageBody(true));
                    }
                }
            }

            timer1.Enabled = true;
        }

        private string GetLogType(EnumLogType type)
        {
            //return type.ToString();
            switch (type)
            {
                case EnumLogType.Server:
                    return "服务消息";
                case EnumLogType.Receive:
                    return "接收";
                case EnumLogType.Send:
                    return "发送";
                default:
                    break;
            }
            return type.ToString();
        }

        private string GetCmdType(Common.Enum.EnumCommandType type)
        {
            //return type.ToString();
            switch (type)
            {
                case EnumCommandType.None:
                    break;
                case EnumCommandType.HeartBeat:
                    return "心跳";
                case EnumCommandType.Login:
                    return "登录";
                case EnumCommandType.GetFlowPath:
                    return "取流程节点";
                case EnumCommandType.GetTime:
                    return "取服务器时间";
                case EnumCommandType.GetAPKVersion:
                    return "取APK的版本号";
                case EnumCommandType.GetAPKFile:
                    return "取APK文件";
                case EnumCommandType.SendAlarm:
                    return "通知PC有新告警";
                case EnumCommandType.EndAlarm:
                    return "PC通知服务器结束告警";
                case EnumCommandType.GisChanaged:
                    return "PC通知服务器地图发生变化";
                case EnumCommandType.SendGisRefresh:
                    return "通知PC地图发生变化";
                case EnumCommandType.SendRefresh:
                    return "通知PC流程变化";
                case EnumCommandType.Flow_Apply:
                    return "申请";
                case EnumCommandType.Flow_Check:
                    return "审核";
                case EnumCommandType.Flow_Give:
                    return "供车";
                case EnumCommandType.Flow_Load:
                    return "装车";
                case EnumCommandType.Flow_Handover:
                    return "交接车";
                case EnumCommandType.Flow_UnLoad:
                    return "卸车";
                case EnumCommandType.Flow_Back:
                    return "还车";
                case EnumCommandType.Data_GetMessage:
                    return "PDA取消息";
                case EnumCommandType.Data_GetMaterielType:
                    return "取物料类型表";
                case EnumCommandType.Data_GetVehicle:
                    return "取车辆表";
                case EnumCommandType.Data_GetVehicleType:
                    return "取车辆类型表";
                case EnumCommandType.Data_GetDepartment:
                    return "取部门表";
                case EnumCommandType.Data_GetAddress:
                    return "取地点表";
                case EnumCommandType.Data_GetCard:
                    return "取卡表";
                case EnumCommandType.Data_GetPlanDetail:
                    return "查询计划";
                case EnumCommandType.Data_SendMessage:
                    return "发送消息";
                case EnumCommandType.Data_ReturnMessage:
                    return "PDA返回消息";
                case EnumCommandType.Data_GetPerson:
                    return "取人员表";
                case EnumCommandType.Data_GetMyPlanDetail:
                    return "取我的运单信息";
                case EnumCommandType.Data_GetVehicleIsCanDo:
                    return "获取车辆是否可用";
                case EnumCommandType.Data_GetVehicleDistributed:
                    return "取车辆分布信息";
                case EnumCommandType.GetDBInfo:
                    return "取数据库连接信息";
                case EnumCommandType.ChangePassword:
                    return "修改密码";
                case EnumCommandType.SendGisPointStateChanged:
                    return "发送设备改变通知";
                case EnumCommandType.LoginOut:
                    return "登出";
                case EnumCommandType.SendPDAPostionChanged:
                    return "发送DPA位置变化";
                case  EnumCommandType.SendVehiclePostionChanged:
                    return "发送车辆位置变化";
                default:
                    return type.ToString();
            }
            return type.ToString();
        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_canExit == true)
            {
                if (Pub._isDBOnline == true)
                {
                    _systemConfigBLL.SetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.LastServerRunTime, DateTime.Now.AddSeconds(-30).ToString());
                }
                Pub._ms.Stop();
            }
            else
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;//窗体不可见
                this.notifyIcon1.Visible = true;//托盘图标显示
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            _canExit = true;
            this.Close();
        }

        private void tsmiShow_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void cboLogCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            _logCount = int.Parse(cboLogCount.Text);
            Pub.ConfigModel.LogCount = _logCount;
            Config.WriteModel(Pub.ConfigModel);
        }

        private void chkShowHearbeat_CheckedChanged(object sender, EventArgs e)
        {
            Pub.ConfigModel.IsHideBreakheat = chkShowHearbeat.Checked;
            Config.WriteModel(Pub.ConfigModel);
        }

        private void chkLog_CheckedChanged_1(object sender, EventArgs e)
        {
            Pub.ConfigModel.IsSaveLog = chkLog.Checked;
            Config.WriteModel(Pub.ConfigModel);
        }

        private void chkShowError_CheckedChanged(object sender, EventArgs e)
        {
            Pub.ConfigModel.IsHideError = chkShowError.Checked;
            Config.WriteModel(Pub.ConfigModel);
        }

        private void chkShowSend_CheckedChanged(object sender, EventArgs e)
        {
            Pub.ConfigModel.IsHideSend = chkShowSend.Checked;
            Config.WriteModel(Pub.ConfigModel);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            //if (chkPasueRoll.Checked)
            //{
            //    timer2.Enabled = true;
            //    return;
            //}
            dgvUseList.Rows.Clear();
            try
            {
                if (Pub._isDBOnline == true)
                {
                    _userList = Manage.UserManage.Current.GetUserList();
                    lblUserCount.Text = _userList.Count.ToString();
                    foreach (DB_VehicleTransportManage.Model.m_User item in _userList)
                    {
                        dgvUseList.Rows.Add(item.i_IsPDA.Value == 1 ? "手机用户" : "PC用户", item.vc_Name, item.dt_LastActiveDateTime, item.vc_IP, item.i_Port);
                    }
                }
            }
            catch (Exception)
            {
            }
            if (Pub._isDBOnline == true)
            {
                _systemConfigBLL.SetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.LastServerRunTime, DateTime.Now.ToString());
            }

            timer2.Enabled = true;
        }


    }


}
