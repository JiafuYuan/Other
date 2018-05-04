using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Common.Model;
using Common.Model.DataCommand.InDataCommand;
using Common.Model.DataCommand.OutDataCommand;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;

namespace VehicleTransportServer.Thread.Command.DataCommand
{
    class GetPersonCommand:ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InGetPersonModel indep = Common.XmlManage<InGetPersonModel>.XmlToModel(cmdModel.CmdModelXml);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = Convert.ToDateTime(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.LastUpdatePersonTable));
                }
                catch (Exception)
                {
                }
                
                if (dt != indep.LastUpdateTime)
                {
                    List<DB_VehicleTransportManage.Model.m_Person> lstAddress = new DB_VehicleTransportManage.BLL.m_Person().GetModelList("i_Flag=0");
                    OutGetPersonModel oModel = new OutGetPersonModel();
                    oModel.Listm_Person = lstAddress;
                    oModel.LastUpdateTime = dt;
                    cm.CmdModelXml = Common.XmlManage<OutGetPersonModel>.ModelToXml(oModel);
                }

                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.Data_GetPerson;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取人员列表出错：" + ex.Message, null, true));
            }
        }
    }
}
