using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Common.Model;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;
using Common.Model.NormalCommand.OutCommandModel;

namespace VehicleTransportServer.Thread.Command.NormalCommand
{
    /// <summary>
    /// PC取数据库连接信息
    /// </summary>
    class GetDBInfoCommand : ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                OutGetDBInfoModel fpModel = new OutGetDBInfoModel();
                fpModel.DBName = Pub.ConfigModel.DBName;
                fpModel.DBServer = Pub.ConfigModel.DBServer;
                fpModel.UID = Pub.ConfigModel.DBUserName;
                fpModel.Psw = Pub.ConfigModel.DBPassword;
                cm.CmdModelXml = Common.XmlManage<OutGetDBInfoModel>.ModelToXml(fpModel);

                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.GetDBInfo;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                // WriteLog.AppendErrorLog(ex.Message);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取数据库信息出错：" + ex.Message, null, true));
            }

        }
    }
}
