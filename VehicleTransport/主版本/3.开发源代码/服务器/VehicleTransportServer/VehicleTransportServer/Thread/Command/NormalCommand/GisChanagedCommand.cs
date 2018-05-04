using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Common.Model;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;
using Common.Model.NormalCommand.InCommandModel;

namespace VehicleTransportServer.Thread.Command.NormalCommand
{
    /// <summary>
    /// PC通知服务器GIS有变化
    /// </summary>
    class GisChanagedCommand : ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InGisChanagedModel inModel = Common.XmlManage<InGisChanagedModel>.XmlToModel(cmdModel.CmdModelXml);
                new SendGisRefreshCommand().DoWork(inModel.UserID);
                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.GisChanaged;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "PC通知服务器地图更新失败：" + ex.Message, null, true));
            }
        }
    }
}
