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
using Common.Enum;
using VehicleTransportServer.Thread.BackWork.Alarm;
using VehicleTransportServer.Thread.BackWork;

namespace VehicleTransportServer.Thread.FlowPath
{
    public class BackCommand : ICommand
    {
        private DB_VehicleTransportManage.BLL.m_Plan _planBLL = new DB_VehicleTransportManage.BLL.m_Plan();
        private DB_VehicleTransportManage.BLL.m_Plan_BackVehicle _plan_BackVehicleBLL = new DB_VehicleTransportManage.BLL.m_Plan_BackVehicle();

        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                CommandObjectModel cm = new CommandObjectModel();
                cm.Result = true;
                DB_VehicleTransportManage.DB.OleDbHelper.BeginTransaction();
                InBackModel lg = Common.XmlManage<InBackModel>.XmlToModel(cmdModel.CmdModelXml);

                if (UserManage.Current.IsOnLine(lg.UserID) == true)
                {
                    if (lg.ListM_Plan_BackVehicle.Count == 0)
                    {
                        cm.Result = false;
                        cm.ErrorDetail = "没有提供还车信息";
                    }
                    else
                    {
                        //分次还车，全完状态变
                        foreach (DB_VehicleTransportManage.Model.m_Plan_BackVehicle item in lg.ListM_Plan_BackVehicle)
                        {
                            if (cm.Result == false)//item.VehicleID
                            {
                                break;
                            }
                            //根据车号取计划ID

                            List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> lstPD = new List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail>();
                            lstPD = new DB_VehicleTransportManage.BLL.v_PlanVehicleDetail().GetModelList(
                               string.Format("(PlanState={0} or PlanState={1}) and vehicleID={2} order by dt_RealLoadDateTime desc"
                               , Common.Enum.EnumPlanState.UnLoaded.GetHashCode(),
                                Common.Enum.EnumPlanState.Transporting.GetHashCode(),
                               item.VehicleID));
                            if (lstPD != null && lstPD.Count > 0)
                            {
                                item.PlanID = lstPD[0].PlanID;
                                lg.PlanID = item.PlanID.Value;
                            }
                            else
                            {
                                cm.Result = false;
                                cm.ErrorDetail = "没有可以还车的计划";
                                break;
                            }
                            if (item.PersonID == 0)
                            {
                                item.PersonID = new DB_VehicleTransportManage.BLL.m_User().GetPersonID(lg.UserID);
                            }

                            if (item.AddressID == 0)
                            {
                                item.AddressID = new DB_VehicleTransportManage.BLL.m_User().GetAddressIDByUserID(lg.UserID);
                            }

                            if (_plan_BackVehicleBLL.IsExist(item.PlanID.Value,item.VehicleID.Value) == false)
                            {
                                if (_plan_BackVehicleBLL.Add(item) <= 0)
                                {
                                    cm.Result = false;
                                    cm.ErrorDetail = "写入还车信息失败";
                                    break;
                                }
                            }
                            //cm.Result = new DB_VehicleTransportManage.BLL.m_Vehicle().UpdateVehicleState(item.VehicleID.Value, Common.Enum.EnumVehicleState.Normal.GetHashCode());
                            //new SendGisPointStateChangedCommand().DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel()
                            //{
                            //    EquipmentType = EnumEquipmentType.Vehicle,
                            //    ID = item.VehicleID.Value
                            //});
                            //if (cm.Result == false)
                            //{
                            //    cm.ErrorDetail = "更新车辆状态失败";
                            //    break;
                            //}

                            if (cm.Result == true)
                            {
                                List<DB_VehicleTransportManage.Model.m_Plan_Load> lstLoad = new DB_VehicleTransportManage.BLL.m_Plan_Load().GetModelList("planID=" + lg.PlanID);

                                if (lstLoad.Count > 1)
                                {
                                    DB_VehicleTransportManage.Model.m_Plan_Load lm = lstLoad[lstLoad.Count - 1];
                                    for (int i = lstLoad.Count - 2; i >= 0; i--)
                                    {
                                        if (lm.VehicleID == lstLoad[i].VehicleID)
                                        {
                                            lstLoad.Remove(lm);
                                        }
                                        lm = lstLoad[i];
                                    }
                                }

                                List<DB_VehicleTransportManage.Model.m_Plan_BackVehicle> lstBack = new DB_VehicleTransportManage.BLL.m_Plan_BackVehicle().GetModelList("planID=" + lg.PlanID);


                                //判断都还完改变状态
                                if (IsCanBack(lstLoad, lstBack))
                                {
                                    cm.Result = new DB_VehicleTransportManage.BLL.m_Plan().UpdatePlanState(lg.PlanID, Common.Enum.EnumPlanState.Complete.GetHashCode());
                                    if (cm.Result == false)
                                    {
                                        cm.ErrorDetail = "更新计划状态失败";
                                    }
                                    new BackTimeOutAlarm().CloseAlarm(lg.PlanID);
                                    foreach (DB_VehicleTransportManage.Model.m_Plan_BackVehicle ii in lstBack)
                                    {
                                        new AlarmThread().CloseAllAlarm(lg.PlanID, ii.VehicleID.Value);
                                    }

                                    if (cm.Result == true)
                                    {
                                        foreach (DB_VehicleTransportManage.Model.m_Plan_Load lm in lstLoad)
                                        {
                                            cm.Result = new DB_VehicleTransportManage.BLL.m_Vehicle().UpdateVehicleState(lm.VehicleID.Value, Common.Enum.EnumVehicleState.Normal.GetHashCode());
                                            new SendGisPointStateChangedCommand().DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel()
                                            {
                                                EquipmentType = EnumEquipmentType.Vehicle,
                                                ID = lm.VehicleID.Value
                                            });
                                        }
                                    }
                                }
                            }
                        }
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

                cm.CmdType = Common.Enum.EnumCommandType.Flow_Back;
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
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "还车出错：" + ex.Message, null, true));
            }
        }

        /// <summary>
        /// 匹配所有是否都完成，根据装车的判断
        /// </summary>
        /// <param name="lstLoad"></param>
        /// <param name="lstUnLoad"></param>
        /// <returns></returns>
        private bool IsCanBack(List<DB_VehicleTransportManage.Model.m_Plan_Load> lstLoad, List<DB_VehicleTransportManage.Model.m_Plan_BackVehicle> lstBack)
        {
            if (lstLoad != null && lstBack != null && lstLoad.Count == lstBack.Count)
            {
                foreach (DB_VehicleTransportManage.Model.m_Plan_Load item in lstLoad)
                {
                    if (lstBack.Exists(p => p.VehicleID == item.VehicleID) == false)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

