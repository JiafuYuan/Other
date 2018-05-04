using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using Common.Model.InCommandModel;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Manage;
using Common.Model.OutCommandModel;
using Common.Interface;
using Common.Model.NormalCommand.InCommandModel;
using VehicleTransportServer.Thread.Command.NormalCommand;
using Common.Enum;

namespace VehicleTransportServer.Thread.Command
{
    /// <summary>
    /// 登出
    /// </summary>
    public class LoginOutCommand : ICommand
    {
        private DB_VehicleTransportManage.BLL.m_User _userBLL = new DB_VehicleTransportManage.BLL.m_User();

        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                
                InLoginOutModel lg = Common.XmlManage<InLoginOutModel>.XmlToModel(cmdModel.CmdModelXml);

                CommandObjectModel cm = new CommandObjectModel();
                DB_VehicleTransportManage.Model.m_User userModel = _userBLL.GetModel(lg.UserID);
                if (userModel != null)
                {
                    userModel.i_State=0;
                    cm.Result = _userBLL.Update(userModel);

                    if (userModel.PdaID != null)
                    {
                        DB_VehicleTransportManage.Model.m_PDA pdaModel = new DB_VehicleTransportManage.BLL.m_PDA().GetModel(userModel.PdaID.Value);
                        if (pdaModel != null)
                        {
                            pdaModel.i_State = Common.Enum.EnumPDAState.OffLine.GetHashCode();
                            new DB_VehicleTransportManage.BLL.m_PDA().Update(pdaModel);

                            new SendGisPointStateChangedCommand().DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel()
                            {
                                EquipmentType = EnumEquipmentType.PDA,
                                ID = pdaModel.ID
                            });
                        }
                    }
                }
                else
                {
                    cm.Result=false;
                }
                
              
                //cm.CmdModelXml = Common.XmlManage<OutLoginModel>.ModelToXml(oLoginModel);
                 
                cm.CmdType = Common.Enum.EnumCommandType.LoginOut;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                SystemLog.WriteLog(0, Common.Enum.EnumActionType.System, "用户登出", userModel.vc_Name + "登出" + (cm.Result == true ? "成功" : "失败"), "");
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "登出出错：" + ex.Message, null, true));

            }
        }
    }
}
