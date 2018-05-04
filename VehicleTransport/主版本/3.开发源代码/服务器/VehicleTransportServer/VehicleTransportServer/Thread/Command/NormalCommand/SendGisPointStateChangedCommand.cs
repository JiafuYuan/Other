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
    ///GIS地图上点状态变化， 发送刷新，通知PC
    /// </summary>
    public class SendGisPointStateChangedCommand
    {
        public void DoWork(OutSendGisPointStateChangedModel arg)
        {
            try
            {
                List<DB_VehicleTransportManage.Model.m_User> lstUser = new DB_VehicleTransportManage.BLL.m_User().GetOnLinePCUserList();
                if (lstUser != null)
                {
                    foreach (DB_VehicleTransportManage.Model.m_User item in lstUser)
                    {
                        CommandObjectModel cm = new CommandObjectModel();
                        cm.Result = true;
                        cm.CmdType = Common.Enum.EnumCommandType.SendGisPointStateChanged;
                        cm.DateTime = DateTime.Now;
                        cm.CmdModelXml = Common.XmlManage<OutSendGisPointStateChangedModel>.ModelToXml(arg);
                        cm.ClientIP = item.vc_IP;
                        cm.ClientPort = item.i_Port;

                        string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                        bool b = SocketManage.Current.Send(item.vc_IP, item.i_Port, xml);
                        Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, 
                            arg.EquipmentType.ToString()+" "+arg.ID, cm, b));
                    }
                }
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "发送GIS地图上点状态变化刷新命令出错：" + ex.Message, null, true));
            }

        }
    }
}
