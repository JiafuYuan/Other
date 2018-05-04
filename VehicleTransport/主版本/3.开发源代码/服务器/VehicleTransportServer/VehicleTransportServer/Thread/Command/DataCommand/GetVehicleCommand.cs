using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Interface;
using Common.Model;
using Common.Model.DataCommand.OutDataComand;
using Common.Model.DataCommand.OutDataCommand;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;
using Common.Model.DataCommand.InDataCommand;

namespace VehicleTransportServer.Thread.Command.DataCommand
{
    public class GetVehicleCommand:ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InGetVehicleModel indep = Common.XmlManage<InGetVehicleModel>.XmlToModel(cmdModel.CmdModelXml);
                 List<DB_VehicleTransportManage.Model.m_Vehicle> lstAddress=new List<DB_VehicleTransportManage.Model.m_Vehicle>();
                if (indep.AreaID == 0)
                {
                    DateTime dt = DateTime.Now;
                    try
                    {
                        dt = Convert.ToDateTime(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.LastUpdateVehicleTable));
                    }
                    catch (Exception)
                    {
                    }
                    

                    if (dt != indep.LastUpdateTime)
                    {
                        lstAddress = new DB_VehicleTransportManage.BLL.m_Vehicle().GetModelList("i_Flag=0");
                    }
                }
                else
                {
                    lstAddress = new DB_VehicleTransportManage.BLL.m_Vehicle().GetModelListByAreaID(indep.AreaID);
                }
                
                OutGetVehicleModel oModel = new OutGetVehicleModel();
                oModel.ListVehicle = lstAddress;
                oModel.LastUpdateTime = DateTime.Now;
                cm.CmdModelXml = Common.XmlManage<OutGetVehicleModel>.ModelToXml(oModel);
                
                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.Data_GetVehicle;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "取车辆列表出错：" + ex.Message, null, true));
            }
        }
    }
}
