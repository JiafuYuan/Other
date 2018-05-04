using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread.BackWork.Alarm
{
    /// <summary>
    /// 卸车不及时告警（到达后一定时间不卸车的）1
    /// 开始：
    ///     1、实际到达时间+超时设置 小于 当前时间
    /// 结束：
    ///     1、计划全部完成
    ///     2、完成实际卸车动作
    /// </summary>
    public class UnLoadTimeOutAlarm
    {
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _data_VehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();
        public void DoWork()
        {
            try
            {
                if (Pub._isDBOnline == true)
                {
                    //List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> lstV = new List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail>();
                    //lstV = new DB_VehicleTransportManage.BLL.v_PlanVehicleDetail().GetModelList("");
                    //if (lstV != null)
                    //{
                    //    int unLoadTimeOut = Convert.ToInt32(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.UnLoadVehicleTimeOut));
                    //    foreach (DB_VehicleTransportManage.Model.v_PlanVehicleDetail item in lstV)
                    //    {
                    //        if (item.i_LocalizerStationID == item.ArriveDestinationAddressID)
                    //        {
                    //            if (item.dt_InLocalizerStationDateTime.AddHours(unLoadTimeOut) < DateTime.Now)
                    //            {
                    //                OpenAlarm(item.PlanID);
                    //            }
                    //        }
                    //    }
                    //}
                    int unLoadTimeOut = Convert.ToInt32(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.UnLoadVehicleTimeOut));
                    if (unLoadTimeOut > 0)
                    {
                        List<DB_VehicleTransportManage.Model.m_Plan> lstV = new DB_VehicleTransportManage.BLL.m_Plan().GetModelList(
                            string.Format("i_State={0} or i_State={1}",
                            Common.Enum.EnumPlanState.Loaded.GetHashCode(),
                            Common.Enum.EnumPlanState.Transporting.GetHashCode()));
                        if (lstV != null && lstV.Count > 0)
                        {

                            foreach (DB_VehicleTransportManage.Model.m_Plan item in lstV)
                            {
                                if (item.dt_RealArriveDestinationDateTime.Value > Convert.ToDateTime("1900-1-1") && item.dt_RealArriveDestinationDateTime.Value.AddHours(unLoadTimeOut) < DateTime.Now)
                                {
                                    OpenAlarm(item.ID);
                                }
                            }
                        }
                    }
                    else
                    {
                        new DB_VehicleTransportManage.BLL.data_VehicleAlarm().EndCurrentAlarm(Common.Enum.EnumAlarmType.UnLoadTimeOutAlarm.GetHashCode());
                    }
                }
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "卸车不及时告警出错：" + ex.Message, null, true));
            }
        }

        public void OpenAlarm(int planID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.UnLoadTimeOutAlarm.GetHashCode(), planID) == false)
            {
                _data_VehicleAlarmBLL.Add(new DB_VehicleTransportManage.Model.data_VehicleAlarm()
                {
                    i_AlarmType = Common.Enum.EnumAlarmType.UnLoadTimeOutAlarm.GetHashCode(),
                    i_IsPreAlarm = 0,
                    dt_Start = DateTime.Now,
                    PlanID = planID
                });
                new SendAlarmCommand().DoWork();
            }
        }

        public void CloseAlarm(int planID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.UnLoadTimeOutAlarm.GetHashCode(), planID) == true)
            {
                DB_VehicleTransportManage.Model.data_VehicleAlarm alarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelAlarmByPlan(
                    Common.Enum.EnumAlarmType.UnLoadTimeOutAlarm.GetHashCode(), planID);
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
