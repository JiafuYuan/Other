using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Manage;
using Common.Model.NormalCommand.OutCommandModel;

namespace VehicleTransportServer.Thread.Command.NormalCommand
{
    /// <summary>
    ///车辆位置变化， 发送刷新，通知PC
    /// </summary>
    public class SendVehiclePostionChangedCommand
    {
        public void DoWork(OutSendVehiclePostionChangedModel arg)
        {
            List<DB_VehicleTransportManage.Model.m_User> lstUser = new DB_VehicleTransportManage.BLL.m_User().GetOnLinePCUserList();
            foreach (DB_VehicleTransportManage.Model.m_User item in lstUser)
            {
                try
                {
                    CommandObjectModel cm = new CommandObjectModel();
                    cm.Result = true;
                    cm.CmdType = Common.Enum.EnumCommandType.SendVehiclePostionChanged;
                    cm.DateTime = DateTime.Now;
                    cm.CmdModelXml = Common.XmlManage<OutSendVehiclePostionChangedModel>.ModelToXml(arg);
                    string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                    bool b = SocketManage.Current.Send(item.vc_IP, item.i_Port, xml);
                    cm.ClientIP = item.vc_IP;
                    cm.ClientPort = item.i_Port;

                    Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
                }
                catch (Exception ex)
                {
                    Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "发送车辆位置变化刷新命令出错：" + ex.Message, null, true));
                }
            }
        }
    }
}
