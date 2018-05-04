using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.BLL;
using Common.Model;
using Common.Model.DataCommand.InDataCommand;
using VehicleTransportServer.Manage;
using Common.Interface;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread.Command
{
    /// <summary>
    /// 发给PDA
    /// </summary>
    public class SendMessageCommand 
    {

        /// <summary>
        /// 插入数据并发送
        /// </summary>
        /// <param name="fpModel"></param>
        public void SendMessage(DB_VehicleTransportManage.Model.m_Message message)
        {
            try
            {
                List<DB_VehicleTransportManage.Model.m_Message> lstMessage = new List<DB_VehicleTransportManage.Model.m_Message>();
                lstMessage = new DB_VehicleTransportManage.BLL.m_Message().GetModelList(
                    string.Format("ToUserID={0} and i_MessageType={1} and vc_Message='{2}' order by id desc"
                    , message.ToUserID.Value
                    , message.i_MessageType
                    ,message.vc_Message));

                if (lstMessage != null && lstMessage.Count > 0)
                {
                    //同样的消息一小时内不发送
                    if (lstMessage[0].dt_SendDateTime.Value.AddHours(1) < DateTime.Now)
                    {
                        AddMessage(message);
                    }
                }
                else
                {
                    AddMessage(message);
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 写入数据库，发并给在线的用户
        /// </summary>
        /// <param name="message"></param>
        private void AddMessage(DB_VehicleTransportManage.Model.m_Message message)
        {
            int messageID = new DB_VehicleTransportManage.BLL.m_Message().Add(message);
            if (messageID > 0)
            {
                message.ID = messageID;
                message.PlanID = 0;
                DB_VehicleTransportManage.Model.m_User userModel = new DB_VehicleTransportManage.BLL.m_User().GetModel(message.ToUserID.Value);

                ////在线时发送消息
                if (userModel != null && userModel.i_State == Common.Enum.EnumUserState.OnLine.GetHashCode())
                {   
                    SendToPDA(message, userModel.vc_IP, userModel.i_Port);
                }
            }
        }
        /// <summary>
        /// 发消息给PDA
        /// </summary>
        private void SendToPDA(DB_VehicleTransportManage.Model.m_Message message, string ip, int port)
        {
            CommandObjectModel cm = new CommandObjectModel();
            cm.CmdType = Common.Enum.EnumCommandType.Data_SendMessage;
            cm.Result = true;
            cm.CmdModelXml = Common.XmlManage<DB_VehicleTransportManage.Model.m_Message>.ModelToXml(message);
            cm.DateTime = DateTime.Now;
            //cm.CmdID = cmdModel.CmdID;
            string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
            bool b = SocketManage.Current.Send(ip, port, xml);
            Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
        }
    }
}
