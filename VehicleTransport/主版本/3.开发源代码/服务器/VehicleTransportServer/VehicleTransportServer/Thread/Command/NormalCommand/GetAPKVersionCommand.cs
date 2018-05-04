using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;
using Common.Model.OutCommandModel;
using Common.Interface;

namespace VehicleTransportServer.Thread.Command
{
    /// <summary>
    /// PDA取APK版本号
    /// </summary>
    public class GetAPKVersionCommand : ICommand
    {
        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                OutApkVersionModel fpModel = new OutApkVersionModel();
                fpModel.Version = Config.GetModel().ApkVersion;
                cm.CmdModelXml = Common.XmlManage<OutApkVersionModel>.ModelToXml(fpModel);

                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.GetAPKVersion;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                // WriteLog.AppendErrorLog(ex.Message);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取APK版本出错：" + ex.Message, null, true));
            }
        }
    }
}
