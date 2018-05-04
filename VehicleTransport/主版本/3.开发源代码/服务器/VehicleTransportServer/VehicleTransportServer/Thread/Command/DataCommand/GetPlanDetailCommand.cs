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
    /// 查询计划
    /// </summary>
    public class GetPlanDetailCommand : ICommand
    {
        public void DoWork(Common.Model.CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                InGetPlanDetailModel indep = Common.XmlManage<InGetPlanDetailModel>.XmlToModel(cmdModel.CmdModelXml);
                OutGetPlanDetailModel oModel = new OutGetPlanDetailModel();
                string sql = "";
                int departmentID = new DB_VehicleTransportManage.BLL.m_User().GetDepartmentIDByUserID(indep.UserID);
                if (indep.IsApplyDepartment == true)
                {
                    List<DB_VehicleTransportManage.Model.m_Apply> lstA = new DB_VehicleTransportManage.BLL.m_Apply().GetModelList("ApplyDepartmentID=" + departmentID);
                    StringBuilder sbAs = new StringBuilder();
                    foreach (DB_VehicleTransportManage.Model.m_Apply item in lstA)
                    {
                        sbAs.Append(item.ID + ",");
                    }
                    if (sbAs.Length > 0)
                    {
                        sbAs = sbAs.Remove(sbAs.Length - 1, 1);
                        sql = "ApplyID in (" + sbAs.ToString() + ")";
                    }
                }
                else
                {
                    switch (indep.FlowType)
                    {
                        case Common.Enum.EnumFlowPathType.Give:
                            sql = sql + string.Format(" (PlanGiveCarDepartmentID={0} or PlanGiveCarDepartmentID=0) and i_State={1}", departmentID, Common.Enum.EnumPlanState.Checked.GetHashCode());
                            break;
                        case Common.Enum.EnumFlowPathType.Load:
                            if (Pub.FlowPathModel.Give)
                            {
                                sql = sql + string.Format(" (PlanLoadDepartmentID={0} or PlanLoadDepartmentID=0) and i_State={1}", departmentID, Common.Enum.EnumPlanState.Gived.GetHashCode());
                            }
                            else
                            {
                                sql = sql + string.Format(" (PlanLoadDepartmentID={0} or PlanLoadDepartmentID=0) and i_State={1}", departmentID, Common.Enum.EnumPlanState.Checked.GetHashCode());
                            }
                            break;
                        default:
                            break;
                    }
                }
                //List<DB_VehicleTransportManage.Model.m_Plan> lstPlan = new DB_VehicleTransportManage.BLL.m_Plan().GetModelListByPageEx(
                //    sql, indep.StartIndex + 1, indep.StartIndex + indep.PageSize);

                List<DB_VehicleTransportManage.Model.m_Plan> lstPlan = new DB_VehicleTransportManage.BLL.m_Plan().GetModelListByPageEx(
                    sql, indep.StartIndex, indep.PageSize);

                if (indep.IsApplyDepartment == true)
                {

                }
                else
                {
                    StringBuilder sbApplyIDs = new StringBuilder();
                    StringBuilder sbPlanIDs = new StringBuilder();

                    foreach (DB_VehicleTransportManage.Model.m_Plan item in lstPlan)
                    {
                        sbApplyIDs.Append(item.ApplyID + ",");
                        sbPlanIDs.Append(item.ID + ",");
                    }
                    List<DB_VehicleTransportManage.Model.m_Apply> lstApply = new List<DB_VehicleTransportManage.Model.m_Apply>();
                    if (sbApplyIDs.Length > 0)
                    {
                        sbApplyIDs = sbApplyIDs.Remove(sbApplyIDs.Length - 1, 1);
                        lstApply = new DB_VehicleTransportManage.BLL.m_Apply().GetModelList("ID in (" + sbApplyIDs.ToString() + ")");
                    }

                    List<DB_VehicleTransportManage.Model.m_Plan_CheckVehicle> lstPlan_CheckVehicle = new List<DB_VehicleTransportManage.Model.m_Plan_CheckVehicle>();
                    if (sbPlanIDs.Length > 0)
                    {
                        sbPlanIDs = sbPlanIDs.Remove(sbPlanIDs.Length - 1, 1);
                        lstPlan_CheckVehicle = new DB_VehicleTransportManage.BLL.m_Plan_CheckVehicle().GetModelList("PlanID in (" + sbPlanIDs.ToString() + ")");
                    }

                    StringBuilder sbApply = new StringBuilder();
                    foreach (DB_VehicleTransportManage.Model.m_Apply item in lstApply)
                    {
                        sbApply.Append(item.ID + ",");
                    }
                    List<DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie> lstPlan_ApplyMaterie = new List<DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie>();
                    List<DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle> lstPlan_ApplyVehicle = new List<DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle>();


                    if (sbApply.Length > 0)
                    {
                        sbApply = sbApply.Remove(sbApply.Length - 1, 1);
                        lstPlan_ApplyMaterie = new DB_VehicleTransportManage.BLL.m_Plan_ApplyMaterie().GetModelList("ApplyID in (" + sbApply.ToString() + ")");
                        lstPlan_ApplyVehicle = new DB_VehicleTransportManage.BLL.m_Plan_ApplyVehicle().GetModelList("ApplyID in (" + sbApply.ToString() + ")");
                    }

                   
                    oModel.Listm_Plan = lstPlan;
                    oModel.Listm_Apply = lstApply;
                    oModel.Listm_Plan_CheckVehicle = lstPlan_CheckVehicle;
                    if (lstPlan_ApplyMaterie.Count > 0)
                    {
                        oModel.Listm_Plan_ApplyMaterie = lstPlan_ApplyMaterie;
                    }
                    else
                    {
                        oModel.Listm_Plan_ApplyMaterie = null;
                    }

                    if (lstPlan_ApplyVehicle.Count > 0)
                    {
                        oModel.Listm_Plan_ApplyVehicle = lstPlan_ApplyVehicle;
                    }
                    else
                    {
                        oModel.Listm_Plan_ApplyVehicle = null;
                    }
                }
                cm.CmdModelXml = Common.XmlManage<OutGetPlanDetailModel>.ModelToXml(oModel);

                cm.Result = true;
                cm.CmdType = Common.Enum.EnumCommandType.Data_GetPlanDetail;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "查询计划出错：" + ex.Message, null, true));
            }
        }
    }
}
