using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Manage;
using Common.Model.FlowPath.InFlowPath;
using Common.Interface;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread.FlowPath
{
    class HandoverCommand : ICommand
    {
        private DB_VehicleTransportManage.BLL.m_Plan_Handover _plan_HandoverBLL = new DB_VehicleTransportManage.BLL.m_Plan_Handover();
        private DB_VehicleTransportManage.BLL.m_Plan_HandoverMaterie _plan_HandoverMaterieBLL = new DB_VehicleTransportManage.BLL.m_Plan_HandoverMaterie();


        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                InHandoverModel lg = Common.XmlManage<InHandoverModel>.XmlToModel(cmdModel.CmdModelXml);
                CommandObjectModel cm = new CommandObjectModel();
                DB_VehicleTransportManage.DB.OleDbHelper.BeginTransaction();
                cm.Result = true;
                if (UserManage.Current.IsOnLine(lg.UserID) == true)
                {
                    if (lg.ListM_Plan_Handover==null || lg.ListM_Plan_Handover.Count==0)
                    {
                        cm.Result = false;
                        cm.ErrorDetail = "没有提供交接车信息";
                    }
                    foreach (DB_VehicleTransportManage.Model.m_Plan_Handover item in lg.ListM_Plan_Handover)
                    {
                        if (cm.Result == false)//item.VehicleID
                        {
                            break;
                        }
                        //根据车号取计划ID

                        List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> lstPD = new List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail>();
                        lstPD = new DB_VehicleTransportManage.BLL.v_PlanVehicleDetail().GetModelList(
                           string.Format("(PlanState={0} or PlanState={1} ) and vehicleID={2} order by dt_RealLoadDateTime desc"
                           , Common.Enum.EnumPlanState.Loaded.GetHashCode(), Common.Enum.EnumPlanState.Transporting.GetHashCode(), item.VehicleID));
                        if (lstPD != null && lstPD.Count > 0)
                        {
                            item.PlanID = lstPD[0].PlanID;
                            lg.PlanID = item.PlanID.Value;
                        }
                        else
                        {
                            cm.Result = false;
                            cm.ErrorDetail = "没有查询到相关的计划";
                            break;
                        }
                        if (lg.PersonID == 0)
                        {
                            item.ReceiveVehiclePersonID = new DB_VehicleTransportManage.BLL.m_User().GetPersonID(lg.UserID);
                        }
                        else
                        {
                            item.ReceiveVehiclePersonID = lg.PersonID;
                        }

                        if (lg.AddressID != 0)
                        {
                            item.AddressID = lg.AddressID;
                        }
                        else
                        {
                            item.AddressID = new DB_VehicleTransportManage.BLL.m_User().GetAddressIDByUserID(lg.UserID);
                        }

                        //这里要算交接次数
                        List<DB_VehicleTransportManage.Model.m_Plan_Handover> lstHandover = new List<DB_VehicleTransportManage.Model.m_Plan_Handover>();
                        lstHandover = new DB_VehicleTransportManage.BLL.m_Plan_Handover().GetModelList(string.Format("planid={0} and vehicleID={1} order by i_HandoverCount desc", item.PlanID, item.VehicleID));

                        if ( lstHandover.Count > 0)
                        {
                            item.i_HandoverCount = lstHandover[0].i_HandoverCount + 1;
                        }
                        else
                        {
                            item.i_HandoverCount = 1;
                        }

                        int plan_HandoverID = _plan_HandoverBLL.Add(item);
                        if (plan_HandoverID <= 0)
                        {
                            cm.Result = false;
                            cm.ErrorDetail = "写入交接车信息失败";
                            break;
                        }
                        foreach (DB_VehicleTransportManage.Model.m_Plan_HandoverMaterie dditem in lg.ListM_Plan_HandoverMaterie)
                        {
                            if (item.ID == dditem.PlanHandoverID)
                            {
                                dditem.PlanHandoverID = plan_HandoverID;
                                if (_plan_HandoverMaterieBLL.Add(dditem) <= 0)
                                {
                                    cm.Result = false;
                                    cm.ErrorDetail = "写入交接物料信息失败";
                                    break;
                                }
                            }
                        }
                        cm.Result = new DB_VehicleTransportManage.BLL.m_Plan().UpdatePlanState(lg.PlanID, Common.Enum.EnumPlanState.Transporting.GetHashCode());
                    }
                }
                else
                {
                    cm.Result = false;
                    cm.ErrorDetail = "没有查询到相关的计划";
                }

                if (cm.Result == false)
                {
                    DB_VehicleTransportManage.DB.OleDbHelper.Rollback();
                }
                else
                {
                    DB_VehicleTransportManage.DB.OleDbHelper.Commit();
                }
                
                cm.CmdType = Common.Enum.EnumCommandType.Flow_Handover;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
                if (cm.Result == true) new SendRefreshCommand().DoWork();
            }
            catch (Exception ex)
            {
                DB_VehicleTransportManage.DB.OleDbHelper.Rollback();
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "交接车出错：" + ex.Message, null, true));
            }
        }
    }
}
