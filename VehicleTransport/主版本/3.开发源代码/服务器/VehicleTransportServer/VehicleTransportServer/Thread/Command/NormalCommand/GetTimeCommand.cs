using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using Common.Model.OutCommandModel;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Manage;
using Common.Interface;

namespace VehicleTransportServer.Thread.Command.NormalCommand
{
    /// <summary>
    /// 对时
    /// </summary>
    public class GetTimeCommand : ICommand
    {
        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                OutGetTimeModel fpModel = new OutGetTimeModel();
                fpModel.DateTime = DateTime.Now;
                cm.CmdModelXml = Common.XmlManage<OutGetTimeModel>.ModelToXml(fpModel);

                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.GetTime;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));

            }
            catch (Exception ex)
            {
                // WriteLog.AppendErrorLog(ex.Message);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取时间出错：" + ex.Message, null, true));
            }
        }
    }
}
