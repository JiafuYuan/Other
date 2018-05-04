using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread.BackWork.Alarm
{
    /// <summary>
    /// 闲置告警（在基站下停留超时）1
    /// 开始：
    ///     1、运输过程中在基站下停留超时
    /// 结束：
    ///     1、车辆动了
    ///     2、计划全部完成
    /// </summary>
    public class UnUseAlarm
    {
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _data_VehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();
        public void DoWork()
        {
            try
            {
                if (Pub._isDBOnline == true)
                {
                    List<DB_VehicleTransportManage.Model.m_Vehicle> lst = new DB_VehicleTransportManage.BLL.m_Vehicle().GetModelList(
                       string.Format("i_Flag<>1 and (i_State={0} or i_State={1})", 
                       Common.Enum.EnumVehicleState.Normal.GetHashCode(), 
                       Common.Enum.EnumVehicleState.Using.GetHashCode()));
                    if (lst != null)
                    {
                        int UnUsedTimeOut = Convert.ToInt32(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.UnUsedVehicleTimeOutAlarm));
                        if (UnUsedTimeOut > 0)
                        {
                            foreach (DB_VehicleTransportManage.Model.m_Vehicle item in lst)
                            {
                                if (item.dt_InLocalizerStationDateTime.Value.AddHours(UnUsedTimeOut) < DateTime.Now)
                                {
                                    OpenAlarm(item.ID);
                                }
                                else
                                {
                                    CloseAlarm(item.ID);
                                }
                            }
                        }
                        else
                        {
                            new DB_VehicleTransportManage.BLL.data_VehicleAlarm().EndCurrentAlarm(Common.Enum.EnumAlarmType.NoUseAlarm.GetHashCode());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "闲置告警出错：" + ex.Message, null, true));
            }
        }

        public void OpenAlarm(int vehicleID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByVehicle(Common.Enum.EnumAlarmType.NoUseAlarm.GetHashCode(), vehicleID) == false)
            {
                _data_VehicleAlarmBLL.Add(new DB_VehicleTransportManage.Model.data_VehicleAlarm()
                {
                    i_AlarmType = Common.Enum.EnumAlarmType.NoUseAlarm.GetHashCode(),
                    i_IsPreAlarm = 0,
                    dt_Start = DateTime.Now,
                    VehicleID = vehicleID
                });
                new SendAlarmCommand().DoWork();
            }
        }

        public void CloseAlarm(int vehicleID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByVehicle(Common.Enum.EnumAlarmType.NoUseAlarm.GetHashCode(), vehicleID) == true)
            {
                DB_VehicleTransportManage.Model.data_VehicleAlarm alarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelAlarmByVehicleID(
                    Common.Enum.EnumAlarmType.NoUseAlarm.GetHashCode(), vehicleID);
                if (alarm != null)
                {
                    alarm.dt_End = DateTime.Now;
                    new DB_VehicleTransportManage.BLL.data_VehicleAlarm().Update(alarm);
                    new SendAlarmCommand().DoWork();
                }
            }
        }
    }
}
