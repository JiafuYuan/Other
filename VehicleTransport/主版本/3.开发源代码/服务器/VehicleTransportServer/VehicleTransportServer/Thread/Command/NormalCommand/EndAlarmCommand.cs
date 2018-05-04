using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Common.Model;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;

namespace VehicleTransportServer.Thread.Command.NormalCommand
{
    /// <summary>
    /// PC通知服务器有告警结束
    /// </summary>
    class EndAlarmCommand : ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                new SendAlarmCommand().DoWork();
                CommandObjectModel cm = new CommandObjectModel();

                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.EndAlarm;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "结束告警出错：" + ex.Message, null, true));
            }


        }
    }
}
