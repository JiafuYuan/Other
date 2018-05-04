using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Manage;

namespace VehicleTransportServer.Thread.Command.NormalCommand
{
    /// <summary>
    /// 发送GIS刷新，通知PC
    /// </summary>
    public class SendGisRefreshCommand
    {
        public void DoWork(int noSendUserID)
        {
            List<DB_VehicleTransportManage.Model.m_User> lstUser = new DB_VehicleTransportManage.BLL.m_User().GetOnLinePCUserList();
            foreach (DB_VehicleTransportManage.Model.m_User item in lstUser)
            {
                try
                {
                    if (item.ID != noSendUserID)
                    {
                        CommandObjectModel cm = new CommandObjectModel();
                        cm.Result = true;
                        cm.CmdType = Common.Enum.EnumCommandType.SendGisRefresh;
                        cm.DateTime = DateTime.Now;
                        string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                        bool b = SocketManage.Current.Send(item.vc_IP, item.i_Port, xml);
                        Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
                    }
                }
                catch (Exception ex)
                {
                    Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "发送GIS刷新命令出错：" + ex.Message, null, true));
                }
            }
        }
    }
}
