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
using VehicleTransportServer.Thread.BackWork;

namespace VehicleTransportServer.Thread.FlowPath
{
    public class UnLoadCommand : ICommand
    {
        private DB_VehicleTransportManage.BLL.m_Plan _planBLL = new DB_VehicleTransportManage.BLL.m_Plan();
        private DB_VehicleTransportManage.BLL.m_Plan_UnLoad _plan_UnLoadBLL = new DB_VehicleTransportManage.BLL.m_Plan_UnLoad();
        private DB_VehicleTransportManage.BLL.m_User _userBLL = new DB_VehicleTransportManage.BLL.m_User();
        private DB_VehicleTransportManage.BLL.m_Vehicle _vehicleBLL = new DB_VehicleTransportManage.BLL.m_Vehicle();
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _data_VehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();
        private DB_VehicleTransportManage.BLL.m_Plan_UnLoadMaterie _plan_UnLoadMaterieBLL = new DB_VehicleTransportManage.BLL.m_Plan_UnLoadMaterie();

        public void DoWork(CommandObjectModel cmdModel)
        {
            try
            {
                DB_VehicleTransportManage.DB.OleDbHelper.BeginTransaction();
                CommandObjectModel cm = new CommandObjectModel();
                InUnLoadModel lg = Common.XmlManage<InUnLoadModel>.XmlToModel(cmdModel.CmdModelXml);
                DB_VehicleTransportManage.Model.m_Plan planModel = new DB_VehicleTransportManage.Model.m_Plan();
                
                cm.Result = true;
                if (UserManage.Current.IsOnLine(lg.UserID) == true)
                {
                    //分次卸车，全完状态变
                    
                    foreach (DB_VehicleTransportManage.Model.m_Plan_UnLoad item in lg.ListM_Plan_UnLoad)
                    {
                        if (cm.Result == false)//item.VehicleID
                        {
                            break;
                        }

                        //根据车号取计划ID
                        List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> lstPD = new List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail>();
                        lstPD = new DB_VehicleTransportManage.BLL.v_PlanVehicleDetail().GetModelList(
                           string.Format("(PlanState={0} or PlanState={1} ) and vehicleID={2} order by dt_RealLoadDateTime desc"
                           , Common.Enum.EnumPlanState.Loaded.GetHashCode(),
                           Common.Enum.EnumPlanState.Transporting.GetHashCode(), item.VehicleID));
                        if (lstPD != null && lstPD.Count > 0)
                        {
                            item.PlanID = lstPD[0].PlanID;
                            lg.PlanID = item.PlanID.Value;

                            #region 判断些运单中已卸车的返回失败

                            List<DB_VehicleTransportManage.Model.m_Plan_UnLoad> lstUnLoad = new DB_VehicleTransportManage.BLL.m_Plan_UnLoad().GetModelList(
                                string.Format("planID={0} and VehicleID={1}", lg.PlanID, item.VehicleID));
                            if (lstUnLoad != null && lstUnLoad.Count > 0)
                            {
                                cm.Result = false;
                                DB_VehicleTransportManage.Model.m_Vehicle vModel = new DB_VehicleTransportManage.BLL.m_Vehicle().GetModel(item.VehicleID.Value);
                                if (vModel != null)
                                {
                                    cm.ErrorDetail = string.Format("车辆编号{0},车辆名称{1}的车已经卸过车了!",vModel.vc_Code,vModel.vc_Name);
                                }
                                break;
                            }

                            #endregion
                        }
                        else
                        {
                            cm.Result = false;
                            cm.ErrorDetail = "没有相关的计划";
                            break;
                        }
                        if (item.PersonID == 0)
                        {
                            item.PersonID = new DB_VehicleTransportManage.BLL.m_User().GetPersonID(lg.UserID);
                        }

                        if (lg.AddressID != 0)
                        {
                            item.AddressID = lg.AddressID;
                        }
                        else
                        {
                            item.AddressID = new DB_VehicleTransportManage.BLL.m_User().GetAddressIDByUserID(lg.UserID);
                        }

                        int plan_UnLoadID = _plan_UnLoadBLL.Add(item);
                        if (plan_UnLoadID <= 0)
                        {
                            cm.Result = false;
                            cm.ErrorDetail = "写入卸车信息失败";
                            break;
                        }
                        if (lg.Listm_Plan_UnLoadMaterie.Count==0)
                        {
                            cm.Result = false;
                            cm.ErrorDetail = "没有提供相关的物料信息";
                            break;
                        }
                        foreach (DB_VehicleTransportManage.Model.m_Plan_UnLoadMaterie dditem in lg.Listm_Plan_UnLoadMaterie)
                        {
                            if (item.ID == dditem.PlanUnloadID)
                            {
                                dditem.PlanUnloadID = plan_UnLoadID;
                                if (_plan_UnLoadMaterieBLL.Add(dditem) <= 0)
                                {
                                    cm.Result = false;
                                    cm.ErrorDetail = "写入卸车物料信息失败";
                                    break;
                                }
                            }
                        }
                        if (Pub.FlowPathModel.Back == false)//如果没有还车环节，将车辆置空
                        {
                            _vehicleBLL.UpdateVehicleState(item.VehicleID.Value, Common.Enum.EnumVehicleState.Normal.GetHashCode());
                            new SendGisPointStateChangedCommand().DoWork(new Common.Model.NormalCommand.OutCommandModel.OutSendGisPointStateChangedModel()
                            {
                                EquipmentType = EnumEquipmentType.Vehicle,
                                ID = item.VehicleID.Value
                            });
                        }
                        if (cm.Result == true)
                        {
                            List<DB_VehicleTransportManage.Model.m_Plan_Load> lstLoad = new DB_VehicleTransportManage.BLL.m_Plan_Load().GetModelList("planID=" + lg.PlanID);

                            if (lstLoad.Count > 1)
                            {
                                DB_VehicleTransportManage.Model.m_Plan_Load lm = lstLoad[lstLoad.Count - 1];
                                for (int i = lstLoad.Count - 2; i >= 0; i--)
                                {
                                    if (lm.VehicleID==lstLoad[i].VehicleID)
                                    {
                                        lstLoad.Remove(lm);
                                    }
                                    lm = lstLoad[i];
                                }
                            }
                            List<DB_VehicleTransportManage.Model.m_Plan_UnLoad> lstUnLoad = new DB_VehicleTransportManage.BLL.m_Plan_UnLoad().GetModelList("planID=" + lg.PlanID);

                            //判断都卸完改变状态
                            if(IsCanUnload(lstLoad,lstUnLoad))
                            {
                                new UnLoadTimeOutAlarm().CloseAlarm(lg.PlanID);

                                if (Pub.FlowPathModel.Back == true)
                                {
                                    cm.Result = new DB_VehicleTransportManage.BLL.m_Plan().UpdatePlanState(lg.PlanID, Common.Enum.EnumPlanState.UnLoaded.GetHashCode());
                                }
                                else
                                {
                                    foreach (DB_VehicleTransportManage.Model.m_Plan_UnLoad ii in lstUnLoad)
                                    {
                                        //结束所有的告警
                                        new AlarmThread().CloseAllAlarm(lg.PlanID, ii.VehicleID.Value);
                                    }
                                    //修改计划状态
                                    cm.Result = new DB_VehicleTransportManage.BLL.m_Plan().UpdatePlanState(lg.PlanID, Common.Enum.EnumPlanState.Complete.GetHashCode());
                                }
                            

                                if (cm.Result == false)
                                {
                                    cm.ErrorDetail = "更新计划状态失败";
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

                cm.CmdType = Common.Enum.EnumCommandType.Flow_UnLoad;
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
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "卸车出错：" + ex.Message, null, true));
            }

        }

        /// <summary>
        /// 匹配所有是否都完成
        /// </summary>
        /// <param name="lstLoad"></param>
        /// <param name="lstUnLoad"></param>
        /// <returns></returns>
        private bool IsCanUnload(List<DB_VehicleTransportManage.Model.m_Plan_Load> lstLoad ,List<DB_VehicleTransportManage.Model.m_Plan_UnLoad> lstUnLoad )
        {
            if (lstLoad != null && lstUnLoad != null && lstLoad.Count == lstUnLoad.Count)
            {
                foreach (DB_VehicleTransportManage.Model.m_Plan_Load item in lstLoad)
                {
                    if (lstUnLoad.Exists(p=>p.VehicleID==item.VehicleID)==false)
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
