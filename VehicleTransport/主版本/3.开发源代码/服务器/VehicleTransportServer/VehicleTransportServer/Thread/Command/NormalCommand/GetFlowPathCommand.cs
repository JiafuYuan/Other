using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Manage;
using Common.Interface;

namespace VehicleTransportServer.Thread.Command.NormalCommand
{
    /// <summary>
    /// 取车辆管理配置的节点信息
    /// </summary>
    public class GetFlowPathCommand : ICommand
    {
        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                //Common.Model.OutCommandModel.OutFlowPathModel fpModel = new Common.Model.OutCommandModel.OutFlowPathModel();

                cm.CmdModelXml = Common.XmlManage<Common.Model.OutCommandModel.OutFlowPathModel>.ModelToXml(Pub.FlowPathModel);

                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.GetFlowPath;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));

            }
            catch (Exception ex)
            {
                // WriteLog.AppendErrorLog(ex.Message);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取流程节点出错：" + ex.Message, null, true));
            }
        }
    }
}
