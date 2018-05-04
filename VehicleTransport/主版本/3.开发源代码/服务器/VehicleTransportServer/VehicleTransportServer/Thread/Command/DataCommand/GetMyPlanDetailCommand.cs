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
    //我的运单
    public class GetMyPlanDetailCommand : ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InGetMyPlanDetailModel indep = Common.XmlManage<InGetMyPlanDetailModel>.XmlToModel(cmdModel.CmdModelXml);
                OutGetMyPlanDetailModel oModel = new OutGetMyPlanDetailModel();
                
                int departmentID = new DB_VehicleTransportManage.BLL.m_User().GetDepartmentIDByUserID(indep.UserID);

                List<DB_VehicleTransportManage.Model.v_ApplyPlanVehicleDetail> lstA =
                    new DB_VehicleTransportManage.BLL.v_ApplyPlanVehicleDetail().GetModelList("planstate<>"+Common.Enum.EnumPlanState.Complete.GetHashCode()+" and  ApplyDepartmentID=" + departmentID);

                List<DB_VehicleTransportManage.Model.v_Plan> lstPlan = new DB_VehicleTransportManage.BLL.v_Plan().GetModelList(
                    string.Format("ApplyDepartmentID={0} and i_State<>{1} ",departmentID,Common.Enum.EnumPlanState.Complete.GetHashCode()));

                foreach (DB_VehicleTransportManage.Model.v_Plan item in lstPlan)
                {
                    if (item.i_State==Common.Enum.EnumPlanState.Checked.GetHashCode() ||
                        item.i_State==Common.Enum.EnumPlanState.Gived.GetHashCode()
                        )
                    {
                        lstA.Add(new DB_VehicleTransportManage.Model.v_ApplyPlanVehicleDetail()
                        {
                             PlanID=item.ID,
                             vc_PlanCode=item.vc_PlanCode,
                             ApplyDepartmentID=item.ApplyDepartmentID,
                              ArriveDestinationAddressID=item.ArriveDestinationAddressID,
                              PlanState= item.i_State
                        });
                    }
                }

                oModel.Listm_ApplyPlanDetail = lstA;

                cm.CmdModelXml = Common.XmlManage<OutGetMyPlanDetailModel>.ModelToXml(oModel);

                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.Data_GetMyPlanDetail;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "查询我的运单出错：" + ex.Message, null, true));
            }
        }
    }
}
