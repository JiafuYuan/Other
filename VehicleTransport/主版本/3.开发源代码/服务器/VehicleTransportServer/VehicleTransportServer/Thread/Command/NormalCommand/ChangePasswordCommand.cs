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
    public class ChangePasswordCommand : ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                //<?xml version=\"1.0\" encoding=\"gb2312\"?><InChangePasswordModel><Password>afag</Password><UserID>0</UserID></InChangePasswordModel>
                InChangePasswordModel inM = Common.XmlManage<InChangePasswordModel>.XmlToModel(cmdModel.CmdModelXml);
                DB_VehicleTransportManage.Model.m_User userModel = new DB_VehicleTransportManage.Model.m_User();
                userModel = new DB_VehicleTransportManage.BLL.m_User().GetModel(inM.UserID);
                if (userModel != null)
                {
                    userModel.vc_Password = inM.Password;
                    cm.Result = new DB_VehicleTransportManage.BLL.m_User().Update(userModel);
                }
                else
                {
                    cm.Result = false;
                }
                
                cm.CmdType = Common.Enum.EnumCommandType.ChangePassword;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "修改密码出错：" + ex.Message, null, true));
            }


        }
    }
}
