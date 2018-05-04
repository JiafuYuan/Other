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

namespace VehicleTransportServer.Thread.Command
{
    public class LoginCommand : ICommand
    {
        private DB_VehicleTransportManage.BLL.m_User _userBLL = new DB_VehicleTransportManage.BLL.m_User();

        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                List<DB_VehicleTransportManage.Model.m_User> lst = new List<DB_VehicleTransportManage.Model.m_User>();
                InLoginModel lg = Common.XmlManage<InLoginModel>.XmlToModel(cmdModel.CmdModelXml);

                if (lg.IsPasswordLogin == true)
                {
                    lst = _userBLL.GetModelList(
                        string.Format("vc_name='{0}' and vc_Password='{1}' and i_Flag=0 ",
                        lg.UserName,
                        lg.PassWord
                        
                        ));
                }
                else
                {
                    lst = _userBLL.GetModelList(
                        string.Format("i_IdentificationCardHID='{0}'  and i_Flag=0 ",
                        lg.CardHID                    
                        
                        ));
                }
                CommandObjectModel cm = new CommandObjectModel();
                Common.Model.OutCommandModel.OutLoginModel oLoginModel = new Common.Model.OutCommandModel.OutLoginModel();
                if (lst != null && lst.Count >0)
                {
                    oLoginModel.UserID = lst[0].ID;
                    if (lst[0].i_State == Common.Enum.EnumUserState.OffLine.GetHashCode() ||
                        (lst[0].i_State == Common.Enum.EnumUserState.OnLine.GetHashCode() && lst[0].vc_IP == cmdModel.ClientIP))
                    {
                        lst[0].i_State = Common.Enum.EnumUserState.OnLine.GetHashCode();
                        lst[0].dt_LastActiveDateTime = DateTime.Now;
                        lst[0].vc_IP = cmdModel.ClientIP;
                        lst[0].i_Port = cmdModel.ClientPort;
                        lst[0].i_IsPDA = lg.UserType.GetHashCode();
                        cm.Result = _userBLL.Update(lst[0]);
                        oLoginModel.UserName = lst[0].vc_Name;
                        oLoginModel.PassWord = lst[0].vc_Password;
                    }
                    else
                    {
                        cm.Result= false;
                        cm.ErrorDetail = "用户已在线";
                    }
                }
                else
                {
                    cm.Result = false;
                    cm.ErrorDetail = "用户或密码错误";
                }
              
                SystemLog.WriteLog(0, Common.Enum.EnumActionType.System, "用户登录", lg.UserName + "登录"+(cm.Result==true?"成功":"失败"), "");

                cm.CmdModelXml = Common.XmlManage<OutLoginModel>.ModelToXml(oLoginModel);
                 //cm.CmdModelXml = cm.CmdModelXml.PadLeft(500000, 'a');
                cm.CmdType = Common.Enum.EnumCommandType.Login;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "登录出错：" + ex.Message, null, true));

            }
        }
    }
}
