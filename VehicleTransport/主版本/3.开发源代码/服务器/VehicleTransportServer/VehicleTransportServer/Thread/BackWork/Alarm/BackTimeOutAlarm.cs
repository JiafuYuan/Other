using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.BLL;
using Common.Interface;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread.BackWork.Alarm
{
    /// <summary>
    /// 还车不及时告警（到达目的地后一定时间不还车的）1
    /// 开始：
    ///     1、实际到达时间+还车超时 小于当前时间
    /// 结束：
    ///     1、计划全部完成
    ///     2、完成实际还车操作
    /// </summary>
    public class BackTimeOutAlarm
    {

        private DB_VehicleTransportManage.BLL.m_Plan _planBLL = new DB_VehicleTransportManage.BLL.m_Plan();
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _dataVehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();

        public void DoWork()
        {
            try
            {
                if (Pub._isDBOnline == true)
                {
                    int backTimeOut = Convert.ToInt32(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.BackVehicleTimeOut));


                    List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> lstV =
                        new DB_VehicleTransportManage.BLL.v_PlanVehicleDetail().GetModelList(
                        "PlanState<>" + Common.Enum.EnumPlanState.Complete.GetHashCode());

                    if (lstV != null)
                    {
                        foreach (DB_VehicleTransportManage.Model.v_PlanVehicleDetail item in lstV)
                        {
                            int arriveDestinationAddressLocalizerID = new DB_VehicleTransportManage.BLL.m_Address().GetLocalizerIDByAddressID(item.ArriveDestinationAddressID.Value);
                            if (item.i_LocalizerStationID == arriveDestinationAddressLocalizerID)//到达目的地
                            {
                                //写实际到达时间
                                _planBLL.WriteArriveDateTime(item.PlanID, item.dt_InLocalizerStationDateTime);

                                //if (backTimeOut > 0 && item.dt_InLocalizerStationDateTime.AddHours(backTimeOut) < DateTime.Now)
                                //{
                                //    OpenAlarm(item.PlanID);
                                //}
                            }

                            if (backTimeOut > 0)
                            {
                                if (Pub.FlowPathModel.Back == true)
                                {
                                    if (item.dt_RealArriveDestinationDateTime.Value > Convert.ToDateTime("1900-1-1") && item.dt_RealArriveDestinationDateTime.Value.AddHours(backTimeOut) < DateTime.Now)
                                    {
                                        OpenAlarm(item.PlanID);
                                    }
                                }
                            }
                            else
                            {
                                new DB_VehicleTransportManage.BLL.data_VehicleAlarm().EndCurrentAlarm(Common.Enum.EnumAlarmType.BackTimeOutAlarm.GetHashCode());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "还车不及时告警出错：" + ex.Message, null, true));
            }
        }

        public void OpenAlarm(int planID)
        {
            if (new DB_VehicleTransportManage.BLL.data_VehicleAlarm().IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.BackTimeOutAlarm.GetHashCode(), planID) == false)
            {
                _dataVehicleAlarmBLL.Add(new DB_VehicleTransportManage.Model.data_VehicleAlarm()
                {
                    i_AlarmType = Common.Enum.EnumAlarmType.BackTimeOutAlarm.GetHashCode(),
                    i_IsPreAlarm = 0,
                    dt_Start = DateTime.Now,
                    PlanID = planID
                });
                new SendAlarmCommand().DoWork();
            }
        }

        public void CloseAlarm(int planID)
        {
            if (_dataVehicleAlarmBLL.IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.BackTimeOutAlarm.GetHashCode(), planID) == true)
            {
                DB_VehicleTransportManage.Model.data_VehicleAlarm alarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelAlarmByPlan(
                    Common.Enum.EnumAlarmType.BackTimeOutAlarm.GetHashCode(), planID);
                if (alarm != null)
                {
                    alarm.dt_End = DateTime.Now;
                }
                new DB_VehicleTransportManage.BLL.data_VehicleAlarm().Update(alarm);
                new SendAlarmCommand().DoWork();
            }
        }
    }
}
