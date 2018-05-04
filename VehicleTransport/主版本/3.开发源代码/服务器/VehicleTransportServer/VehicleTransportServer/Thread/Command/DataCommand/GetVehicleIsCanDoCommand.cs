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
    /// 查询车辆在某个环节是否可提交
    /// </summary>
    public class GetVehicleIsCanDoCommand : ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InGetVehicleIsCanDoModel indep = Common.XmlManage<InGetVehicleIsCanDoModel>.XmlToModel(cmdModel.CmdModelXml);

                if (indep.FlowType == Common.Enum.EnumFlowPathType.Load)
                {
                    List<DB_VehicleTransportManage.Model.m_Vehicle> lstV = new DB_VehicleTransportManage.BLL.m_Vehicle().GetModelList("i_State=0 and ID=" + indep.VehicleID);
                    if (lstV != null && lstV.Count > 0)
                    {
                        cm.Result = true;
                    }
                    else
                    {
                        cm.Result = false;
                    }
                }
                else
                {
                    StringBuilder sbSQL = new StringBuilder();

                    sbSQL.Append(string.Format("VehicleID={0} and ", indep.VehicleID));
                    switch (indep.FlowType)
                    {
                        case Common.Enum.EnumFlowPathType.Load:
                            sbSQL.Append(string.Format(" VehicleState={0}",
                                //Common.Enum.EnumPlanState.Checked.GetHashCode(),
                                Common.Enum.EnumVehicleState.Normal.GetHashCode()));
                            break;
                        case Common.Enum.EnumFlowPathType.Handover:
                            sbSQL.Append(string.Format("(PlanState={0} or PlanState={1}) and VehicleState={2}",
                                Common.Enum.EnumPlanState.Loaded.GetHashCode(),
                                Common.Enum.EnumPlanState.Transporting.GetHashCode(),
                                Common.Enum.EnumVehicleState.Using.GetHashCode()));
                            break;
                        case Common.Enum.EnumFlowPathType.UnLoad:
                            sbSQL.Append(string.Format("(PlanState={0} or PlanState={1}) and VehicleState={2}",
                                Common.Enum.EnumPlanState.Loaded.GetHashCode(),
                                Common.Enum.EnumPlanState.Transporting.GetHashCode(),
                                Common.Enum.EnumVehicleState.Using.GetHashCode()));
                            break;
                        case Common.Enum.EnumFlowPathType.Back:
                            sbSQL.Append(string.Format("(PlanState={0} ) and VehicleState={1}",
                                Common.Enum.EnumPlanState.UnLoaded.GetHashCode(),
                                //Common.Enum.EnumPlanState.Transporting.GetHashCode(),
                                Common.Enum.EnumVehicleState.Using.GetHashCode()));
                            break;
                        default:
                            break;
                    }

                    List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> lstPD = new DB_VehicleTransportManage.BLL.v_PlanVehicleDetail().GetModelList(sbSQL.ToString());
                    if (lstPD != null && lstPD.Count > 0)
                    {
                        if (indep.FlowType == Common.Enum.EnumFlowPathType.Back)
                        {
                            if (new DB_VehicleTransportManage.BLL.m_Plan_BackVehicle().IsExist(lstPD[0].PlanID, lstPD[0].VehicleID))
                            {
                                cm.Result = false;
                            }
                            else
                            {
                                cm.Result = true;
                            }
                        }
                        else
                        {
                            cm.Result = true;
                        }
                    }
                    else
                    {
                        cm.Result = false;
                    }
                }
               
                cm.CmdType = Common.Enum.EnumCommandType.Data_GetVehicleIsCanDo;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "查询车辆在环节中是否可用出错：" + ex.Message, null, true));
            }
        }
    }
}
