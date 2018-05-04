using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Common.Model;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;
using Common.Model.DataCommand.InDataCommand;

namespace VehicleTransportServer.Thread.Command.NormalCommand
{
    /// <summary>
    /// PDA接收到消息之后，返回
    /// </summary>
    public class ReturnMessageCommand:ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InReturnMessageModel inModel = Common.XmlManage<InReturnMessageModel>.XmlToModel(cmdModel.CmdModelXml);
                DB_VehicleTransportManage.Model.m_Message message = new DB_VehicleTransportManage.BLL.m_Message().GetModel(inModel.MessageID);
                if (message != null)
                {
                    message.dt_ReceiveDateTime = DateTime.Now;
                    message.i_State = 1;//已接收
                    cm.Result = new DB_VehicleTransportManage.BLL.m_Message().Update(message);
                }
                else
                {
                    cm.Result = false;
                }
                cm.CmdType = Common.Enum.EnumCommandType.Data_ReturnMessage;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "接收PDA返回消息出错：" + ex.Message, null, true));
            }
        }
    }
}
