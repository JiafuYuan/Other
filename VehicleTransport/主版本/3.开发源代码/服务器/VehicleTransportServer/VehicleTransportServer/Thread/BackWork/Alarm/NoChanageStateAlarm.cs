using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread.BackWork.Alarm
{
    /// <summary>
    /// 未置换状态（到达目的地后，空重车状态没有变化就离开）
    /// </summary>
    public class NoChanageStateAlarm
    {
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _data_VehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();
        public void DoWork()
        {
            try
            {
                if (Pub._isDBOnline == true)
                {
                    List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> lstV = new List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail>();
                    lstV = new DB_VehicleTransportManage.BLL.v_PlanVehicleDetail().GetModelList("");
                    if (lstV != null)
                    {
                        foreach (DB_VehicleTransportManage.Model.v_PlanVehicleDetail item in lstV)
                        {
                            if (item.LastAddressID != null && item.ArriveDestinationAddressID == item.LastAddressID.Value)
                            {
                                ///不为空车状态
                                if (item.PlanState != Common.Enum.EnumPlanState.Complete.GetHashCode())
                                {
                                    OpenAlarm(item.PlanID, item.VehicleID);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "未置换状态告警出错：" + ex.Message, null, true));
            }
        }

        public void OpenAlarm(int planID,int vehicleID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.NoChanageStateAlarm.GetHashCode(), planID) == false)
            {
                _data_VehicleAlarmBLL.Add(new DB_VehicleTransportManage.Model.data_VehicleAlarm()
                {
                    i_AlarmType = Common.Enum.EnumAlarmType.NoChanageStateAlarm.GetHashCode(),
                    i_IsPreAlarm = 0,
                    dt_Start = DateTime.Now,
                    PlanID = planID,
                    VehicleID = vehicleID
                });
                new SendAlarmCommand().DoWork();
            }
        }

        public void CloseAlarm(int planID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.NoChanageStateAlarm.GetHashCode(), planID) == true)
            {
                DB_VehicleTransportManage.Model.data_VehicleAlarm alarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelAlarmByPlan(
                    Common.Enum.EnumAlarmType.NoChanageStateAlarm.GetHashCode(), planID);
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
