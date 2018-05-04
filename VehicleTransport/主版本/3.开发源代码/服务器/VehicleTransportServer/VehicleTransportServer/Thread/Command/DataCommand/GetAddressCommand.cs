using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Common.Model;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Manage;
using Common.Model.DataCommand.OutDataComand;
using Common.Model.DataCommand.InDataCommand;
using Common.Model.DataCommand.OutDataCommand;

namespace VehicleTransportServer.Thread.Command.DataCommand
{
    public class GetAddressCommand : ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InGetAddressModel indep = Common.XmlManage<InGetAddressModel>.XmlToModel(cmdModel.CmdModelXml);

                DateTime dt = DateTime.Now;
                try
                {
                    dt = Convert.ToDateTime(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.LastUpdateAddressTable));
                }
                catch (Exception)
                {
                }
                    
                if (dt != indep.LastUpdateTime)
                {
                    List<DB_VehicleTransportManage.Model.m_Address> lstAddress = new DB_VehicleTransportManage.BLL.m_Address().GetModelList("i_Flag=0");
                    OutGetAddressModel oModel = new OutGetAddressModel();
                    oModel.Listm_Address = lstAddress;
                    oModel.LastUpdateTime = dt;
                    cm.CmdModelXml = Common.XmlManage<OutGetAddressModel>.ModelToXml(oModel);
                }
                
                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.Data_GetAddress;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取地点列表出错：" + ex.Message, null, true));
            }
        }
    }
}
