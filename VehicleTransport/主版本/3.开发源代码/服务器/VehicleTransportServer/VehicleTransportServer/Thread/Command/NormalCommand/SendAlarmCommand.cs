using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using Common.Model.InCommandModel;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;

namespace VehicleTransportServer.Thread.Command.NormalCommand
{
    /// <summary>
    /// 发送新告警，通知PC
    /// </summary>
    public class SendAlarmCommand
    {
        public void DoWork()
        {
            if (Pub._isDBOnline)
            {
                List<DB_VehicleTransportManage.Model.m_User> lstUser = new DB_VehicleTransportManage.BLL.m_User().GetOnLinePCUserList();
                if (lstUser != null)
                {
                    try
                    {
                        foreach (DB_VehicleTransportManage.Model.m_User item in lstUser)
                        {
                            CommandObjectModel cm = new CommandObjectModel();
                            cm.Result = true;
                            cm.ClientIP = item.vc_IP;
                            cm.ClientPort = item.i_Port;
                            cm.CmdType = Common.Enum.EnumCommandType.SendAlarm;
                            cm.DateTime = DateTime.Now;
                            string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                            bool b = SocketManage.Current.Send(item.vc_IP, item.i_Port, xml);
                            Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, 
                                item.vc_Name, cm, b));
                        }
                    }
                    catch (Exception ex)
                    {
                        Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "发送告警命令出错：" + ex.Message, null, true));
                    }

                }
            }
        }
    }
}
