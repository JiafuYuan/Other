using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Model;
using VehicleTransportServer.Manage;
using VehicleTransportServer.BLL;
using Common.Model.FlowPath.InFlowPath;
using Common.Interface;
using VehicleTransportServer.Thread.Command.NormalCommand;
using VehicleTransportServer.Thread.BackWork.Alarm;

namespace VehicleTransportServer.Thread.FlowPath
{
    /// <summary>
    /// 供车
    /// </summary>
    public class GiveCommand : ICommand
    {
        private DB_VehicleTransportManage.BLL.m_Plan _planBLL = new DB_VehicleTransportManage.BLL.m_Plan();
        private DB_VehicleTransportManage.BLL.m_Plan_GiveVehicle _plan_GiveVehicle = new DB_VehicleTransportManage.BLL.m_Plan_GiveVehicle();
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _data_VehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();

        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                DB_VehicleTransportManage.DB.OleDbHelper.BeginTransaction();
                InGiveModel lg = Common.XmlManage<InGiveModel>.XmlToModel(cmdModel.CmdModelXml);
                CommandObjectModel cm = new CommandObjectModel();

                cm.Result = true;
                if (UserManage.Current.IsOnLine(lg.UserID) == true)
                {
                    if (lg.ListM_Plan_GiveVehicle.Count > 0)
                    {
                        DB_VehicleTransportManage.Model.m_Plan planModel = _planBLL.GetModel(lg.PlanID);
                        if (planModel != null)
                        {
                            planModel.dt_RealGiveCarDateTime = lg.DateTime;
                            if (lg.AddressID != 0)
                            {
                                planModel.RealGiveCarAddressID = lg.AddressID;
                            }
                            else
                            {
                                //为0时说明是PDA传过来的
                                planModel.RealGiveCarAddressID = new DB_VehicleTransportManage.BLL.m_User().GetAddressIDByUserID(lg.UserID);
                            }

                            if (lg.PersonID == 0)
                            {
                                planModel.RealGiveCarPersonID = new DB_VehicleTransportManage.BLL.m_User().GetPersonID(lg.UserID);
                            }
                            else
                            {
                                planModel.RealGiveCarPersonID = lg.PersonID;
                            }
                            planModel.RealGiveCarDepartmentID = new DB_VehicleTransportManage.BLL.m_Person().GetDeptID(planModel.RealGiveCarPersonID.Value);

                            if (_planBLL.Update(planModel) == true)
                            {
                                foreach (DB_VehicleTransportManage.Model.m_Plan_GiveVehicle item in lg.ListM_Plan_GiveVehicle)
                                {
                                    item.PlanID = planModel.ID;
                                    if (_plan_GiveVehicle.Add(item) <= 0)
                                    {
                                        cm.Result = false;
                                        cm.ErrorDetail = "写入供车信息失败";
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                cm.Result = false;
                                cm.ErrorDetail = "更新计划信息失败";
                            }
                            //结束告警
                            new GiveTimeOutAlarm().CloseAlarm(lg.PlanID);
                            cm.Result = _planBLL.UpdatePlanState(planModel.ID, Common.Enum.EnumPlanState.Gived.GetHashCode());
                        }
                        else
                        {
                            cm.Result = false;
                            cm.ErrorDetail = "找不到相应的计划信息";
                        }
                    }
                    else
                    {
                        cm.Result = false;
                        cm.ErrorDetail = "没有供车信息";
                    }
                }
                else
                {
                    cm.Result = false;
                    cm.ErrorDetail = "用户不在线";
                }
                if (cm.Result == true)
                {
                    DB_VehicleTransportManage.DB.OleDbHelper.Commit();
                }
                else
                {
                    DB_VehicleTransportManage.DB.OleDbHelper.Rollback();
                }
                cm.CmdType = Common.Enum.EnumCommandType.Flow_Give;
                cm.DateTime = DateTime.Now;
                cm.CmdID = cmdModel.CmdID;
                string xml = Common.XmlManage<CommandObjectModel>.ModelToXml(cm);
                bool b = SocketManage.Current.Send(cmdModel.ClientIP, cmdModel.ClientPort, xml);
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Send, "", cm, b));
                if (cm.Result == true) new SendRefreshCommand().DoWork();
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "供车出错：" + ex.Message, null, true));
                DB_VehicleTransportManage.DB.OleDbHelper.Rollback();
            }
        }
    }
}


