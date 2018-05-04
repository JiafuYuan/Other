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
    public class GetVehicleTypeCommand : ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InGetVehicleTypeModel indep = Common.XmlManage<InGetVehicleTypeModel>.XmlToModel(cmdModel.CmdModelXml);
                DateTime dt = DateTime.Now;
                try
                {
                    dt = Convert.ToDateTime(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.LastUpdateVehicleTypeTable));
                }
                catch (Exception)
                {
                }
                
                if (dt != indep.LastUpdateTime)
                {
                    List<DB_VehicleTransportManage.Model.m_VehicleType> lstAddress = new DB_VehicleTransportManage.BLL.m_VehicleType().GetModelList("i_Flag=0");
                    OutGetVehicleTypeModel oModel = new OutGetVehicleTypeModel();
                    oModel.Listm_VehicleType = lstAddress;
                    oModel.LastUpdateTime = dt;
                    cm.CmdModelXml = Common.XmlManage<OutGetVehicleTypeModel>.ModelToXml(oModel);
                }
                
                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.Data_GetVehicleType;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取车辆类型列表出错：" + ex.Message, null, true));
            }
        }
    }
}
