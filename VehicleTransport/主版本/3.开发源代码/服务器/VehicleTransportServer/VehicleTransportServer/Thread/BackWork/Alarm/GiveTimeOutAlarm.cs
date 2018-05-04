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
    /// 供车不及时告警（计划供车时间）1
    /// 开始：
    ///     1、实际时间大于计划供车时间
    ///     2、计划供车时间没有的，不产生告警
    /// 结束：
    ///     1、有实际还车时结束
    ///     2、计划全部完成
    /// </summary>
    public class GiveTimeOutAlarm
    {
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _data_VehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();

        public void DoWork()
        {
            try
            {
                if (Pub._isDBOnline == true)
                {
                    List<DB_VehicleTransportManage.Model.m_Plan> lstV = new DB_VehicleTransportManage.BLL.m_Plan().GetModelList(
                        string.Format("i_State={0}", Common.Enum.EnumPlanState.Checked.GetHashCode()));
                    if (lstV != null)
                    {
                        foreach (DB_VehicleTransportManage.Model.m_Plan item in lstV)
                        {
                            if (item.dt_PlanGiveCarDateTime < DateTime.Now && 
                                item.dt_PlanGiveCarDateTime > Convert.ToDateTime("1901-1-1 00:00:00"))
                            {
                                OpenAlarm(item.ID);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "供车不及时告警出错：" + ex.Message, null, true));
            }
        }

        /// <summary>
        /// 开始告警
        /// </summary>
        public void OpenAlarm(int planID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.GiveTimeOutAlarm.GetHashCode(), planID) == false)
            {
                _data_VehicleAlarmBLL.Add(new DB_VehicleTransportManage.Model.data_VehicleAlarm()
                {
                    i_AlarmType = Common.Enum.EnumAlarmType.GiveTimeOutAlarm.GetHashCode(),
                    i_IsPreAlarm = 0,
                    dt_Start = DateTime.Now,
                    PlanID = planID
                });

                new SendAlarmCommand().DoWork();
            }
        }

        /// <summary>
        /// 结束供车不及时告警
        /// </summary>
        public void CloseAlarm(int planID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.GiveTimeOutAlarm.GetHashCode(), planID) == true)
            {
                DB_VehicleTransportManage.Model.data_VehicleAlarm alarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelAlarmByPlan(
                    Common.Enum.EnumAlarmType.GiveTimeOutAlarm.GetHashCode(), planID);
                if (alarm != null)
                {
                    alarm.dt_End = DateTime.Now;//结束告警

                    new DB_VehicleTransportManage.BLL.data_VehicleAlarm().Update(alarm);
                    new SendAlarmCommand().DoWork();
                }
            }
        }
    }
}

    

