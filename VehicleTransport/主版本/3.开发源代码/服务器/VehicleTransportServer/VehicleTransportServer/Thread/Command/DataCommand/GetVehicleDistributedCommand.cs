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
    /// <summary>
    /// 车辆分布
    /// </summary>
    public class GetVehicleDistributedCommand : ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                OutGetVehicleDistributedModel outModel = new OutGetVehicleDistributedModel();

                List<DB_VehicleTransportManage.Model.v_AreaVehicle> lst = new DB_VehicleTransportManage.BLL.v_AreaVehicle().GetModelList("");
                outModel.Listv_AreaVehicle = lst;
                cm.CmdModelXml = Common.XmlManage<OutGetVehicleDistributedModel>.ModelToXml(outModel);
                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.Data_GetVehicleDistributed;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取车辆分布列表出错：" + ex.Message, null, true));
            }
        }
    }
}
