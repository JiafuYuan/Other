using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using Common.Model.InCommandModel;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;
using Common.Interface;

namespace VehicleTransportServer.Thread.Command
{
    /// <summary>
    /// 心跳，处理PDA与Wifi基站 的关系 
    /// </summary>
    public class HeartBeatCommand : ICommand
    {
        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InHeartBeatModel fpModel = new InHeartBeatModel();
               // Console.WriteLine(fpModel.ArrB);
              //  cmdModel.CmdModelXml = "  <?xml version=\"1.0\" encoding=\"gb2312\"?><InHeartBeatModel ><UserID>13</UserID><PDAMac>aabb:ccdd</PDAMac><WifiBaseStationMac>11:22:3344</WifiBaseStationMac></InHeartBeatModel>";
                fpModel = Common.XmlManage<InHeartBeatModel>.XmlToModel(cmdModel.CmdModelXml);
                //fpModel.DateTime = DateTime.Now;
                //  cm.CmdModelXml = Common.XmlManage<InHeartBeatModel>.ModelToXml(fpModel);
                cm.Result = UserManage.Current.HeartBeat(fpModel,cmdModel.ClientIP,cmdModel.ClientPort);
                if (cm.Result==false)
                {
                    cm.ErrorDetail = "用户不存在或已不在线";   
                }
                //cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.HeartBeat;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));

            }
            catch (Exception ex)
            {
                // WriteLog.AppendErrorLog(ex.Message);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取心跳xml出错：" + ex.Message, null, true));
            }

        }
    }
}
