using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using VehicleTransportServer.BLL;
using Common.Model.InCommandModel;
using VehicleTransportServer.Manage;
using Common.Model.DataCommand.OutDataComand;
using Common.Interface;

namespace VehicleTransportServer.Thread.Command
{
    /// <summary>
    /// 向服务器取消息
    /// </summary>
    public class GetMessageCommand : ICommand
    {
        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InGetMessageModel fpModel = Common.XmlManage<InGetMessageModel>.XmlToModel(cmdModel.CmdModelXml);

                List<DB_VehicleTransportManage.Model.m_Message> lstMessage = new DB_VehicleTransportManage.BLL.m_Message().GetModelList("i_State=0 and toUserID=" + fpModel.UserID);
                OutGetMessageModel oModel = new OutGetMessageModel();
                oModel.ListMessage = lstMessage;
                cm.CmdModelXml = Common.XmlManage<OutGetMessageModel>.ModelToXml(oModel);
                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.Data_GetMessage;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                if (b == true)
                {
                    //把接收的消息更成已接收状态
                    b = new DB_VehicleTransportManage.BLL.m_Message().UpdateGetedMessage(fpModel.UserID);
                }
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取消息出错：" + ex.Message, null, true));
            }
        }
    }
}




