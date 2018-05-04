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
using Common.Enum;
using VehicleTransportServer.Thread.BackWork.Alarm;

namespace VehicleTransportServer.Thread.FlowPath
{
    public class LoadCommand : ICommand
    {
        private DB_VehicleTransportManage.BLL.m_Plan _planBLL = new DB_VehicleTransportManage.BLL.m_Plan();
        private DB_VehicleTransportManage.BLL.m_Plan_Load _plan_LoadBLL = new DB_VehicleTransportManage.BLL.m_Plan_Load();
        private DB_VehicleTransportManage.BLL.m_VehiclePlanDetail _vehiclePlanDetailBLL = new DB_VehicleTransportManage.BLL.m_VehiclePlanDetail();
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _data_VehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();

        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                DB_VehicleTransportManage.DB.OleDbHelper.BeginTransaction();
                InLoadModel lg = Common.XmlManage<InLoadModel>.XmlToModel(cmdModel.CmdModelXml);
                CommandObjectModel cm = new CommandObjectModel();
                cm.Result = true;

                if (UserManage.Current.IsOnLine(lg.UserID) == true)
                {
                    if (lg.ListM_Plan_Load.Count > 0)
                    {
                        //PlanCode查ID
                        DB_VehicleTransportManage.Model.m_Plan planModel =  _planBLL.GetModel(lg.PlanID) ;//: _planBLL.GetModelByPlanCode(lg.PlanCode);
                       
                        planModel.dt_RealLoadDateTime = lg.DateTime;
                        if (lg.AddressID != 0)
                        {
                            planModel.RealLoadAddressID = lg.AddressID;
                        }
                        else
                        {
                            planModel.RealLoadAddressID = new DB_VehicleTransportManage.BLL.m_User().GetAddressIDByUserID(lg.UserID);
                        }

                        //if (lg.DepartmentID != 0)
                        //{
                        //    planModel.RealLoadDepartmentID = lg.DepartmentID;
                        //}
                        //else
                        //{
                        //    planModel.RealLoadDepartmentID =  new DB_VehicleTransportManage.BLL.m_User().GetDepartmentIDByUserID(lg.UserID);
                        //}
                        //if (lg.PersonID == 0)
                        //{
                        if (lg.PersonID == 0)
                        {
                            planModel.RealLoadPersonID = new DB_VehicleTransportManage.BLL.m_User().GetPersonID(lg.UserID);
                        }
                        else
                        {
                            planModel.RealLoadPersonID = lg.PersonID;
                        }
                        planModel.RealLoadDepartmentID = new DB_VehicleTransportManage.BLL.m_Person().GetDeptID(planModel.RealLoadPersonID.Value);
                      //  }

                        if (_planBLL.Update(planModel) == true)
                        {
                            DB_VehicleTransportManage.BLL.m_Vehicle vehicleBLL=new DB_VehicleTransportManage.BLL.m_Vehicle();

                            foreach (DB_VehicleTransportManage.Model.m_Plan_Load item in lg.ListM_Plan_Load)
                            {
                                if (vehicleBLL.IsVehicleUsed(item.VehicleID.Value) == true)
                                {
                                    cm.Result = false;
                                    cm.ErrorDetail = "车辆正在使用，无法装车";
                                    break;
                                }
                            }
                            if (cm.Result == true)
                            {


                                foreach (DB_VehicleTransportManage.Model.m_Plan_Load item in lg.ListM_Plan_Load)
                                {
                                    DB_VehicleTransportManage.Model.m_VehiclePlanDetail vpdModel = new DB_VehicleTransportManage.Model.m_VehiclePlanDetail();
                                    vpdModel.PlanID = item.PlanID;
                                    vpdModel.VehicleID = item.VehicleID;
                                    vpdModel.dt_DateTime = DateTime.Now;
                                    //if (vehicleBLL.IsVehicleUsed(item.VehicleID.Value) == true)
                                    //{
                                    //    cm.Result = false;
                                    //    cm.ErrorDetail = "车辆正在使用，无法装车";
                                    //    break;
                                    //}
                                    //else
                                    //{
                                    vehicleBLL.UpdateVehicleState(item.VehicleID.Value, Common.Enum.EnumVehicleState.Using.GetHashCode());
                                    vehicleBLL.ClearVehicleLastLociler(item.VehicleID.Value);
                                    new SendGisPointStateChangedCommand().DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel()
                                    {
                                        EquipmentType = EnumEquipmentType.Vehicle,
                                        ID = item.VehicleID.Value
                                    });
                                    //}

                                    //车计划关联
                                    if (_vehiclePlanDetailBLL.IsCanAdd(vpdModel) == true)
                                    {
                                        if (_vehiclePlanDetailBLL.Add(vpdModel) <= 0)
                                        {
                                            cm.Result = false;
                                            cm.ErrorDetail = "车辆关联计划失败";
                                            break;
                                        }
                                    }
                                    if (_plan_LoadBLL.Add(item) <= 0)
                                    {
                                        cm.Result = false;
                                        cm.ErrorDetail = "写入装车信息失败";
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            cm.ErrorDetail = "更新计划信息失败";
                            cm.Result = false;
                        }
                        if (cm.Result == true)
                        {


                            new LoadTimeOutAlarm().CloseAlarm(lg.PlanID);

                            cm.Result = _planBLL.UpdatePlanState(lg.PlanID, Common.Enum.EnumPlanState.Loaded.GetHashCode());
                        }
                    }
                    else
                    {
                        cm.Result = false;
                        cm.ErrorDetail = "缺少装车信息";
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
                cm.CmdType = Common.Enum.EnumCommandType.Flow_Load;
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
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "装车出错：" + ex.Message, null, true));
            }


        }

    }


}

