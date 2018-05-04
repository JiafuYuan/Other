using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread.BackWork.Alarm
{
    /// <summary>
    /// 装车不及时告警（供车后（接车）的一段时间后）1
    /// 开始：
    ///     1、实际供车时间+装车超时设置 小于 当前时间
    ///     2、如果没有供车环节，计划装车时间 小于 当前时间
    ///     3、如果计划装车时间没填不告警
    /// 结束：
    ///     1、计划全部完成
    ///     2、完成实际装车操作
    /// </summary>
    public class LoadTimeOutAlarm 
    {
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _data_VehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();
        public void DoWork()
        {
            try
            {
                if (Pub._isDBOnline == true)
                {
                    int loadTimeOut = Convert.ToInt32(new DB_VehicleTransportManage.BLL.m_SystemConfig().GetValue(DB_VehicleTransportManage.BLL.EnumSystemConfigKeys.LoadVehicleTimeOut));
                    if (loadTimeOut > 0)
                    {
                        List<DB_VehicleTransportManage.Model.m_Plan> lstV = null;//
                        if (Pub.FlowPathModel.Give == true)
                        {
                            lstV = new DB_VehicleTransportManage.BLL.m_Plan().GetModelList(
                                   "i_State=" + Common.Enum.EnumPlanState.Gived.GetHashCode());
                        }
                        else
                        {
                            lstV = new DB_VehicleTransportManage.BLL.m_Plan().GetModelList(
                           "i_State=" + Common.Enum.EnumPlanState.Checked.GetHashCode());
                        }
                        if (lstV != null)
                        {
                            foreach (DB_VehicleTransportManage.Model.m_Plan item in lstV)
                            {
                                if (Pub.FlowPathModel.Give == true)
                                {
                                    if (item.dt_RealGiveCarDateTime.Value.AddHours(loadTimeOut) < DateTime.Now)
                                    {
                                        OpenAlarm(item.ID);
                                    }
                                }
                                else
                                {
                                    if (item.dt_PlanLoadDateTime > Convert.ToDateTime("1901-1-1"))
                                    {
                                        if (item.dt_PlanLoadDateTime.Value.AddHours(loadTimeOut) < DateTime.Now)
                                        {
                                            OpenAlarm(item.ID);
                                        }
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        new DB_VehicleTransportManage.BLL.data_VehicleAlarm().EndCurrentAlarm(Common.Enum.EnumAlarmType.LoadTimeOutAlarm.GetHashCode());
                    }
                }
              
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "装车不及时告警出错：" + ex.Message, null, true));
            }
        }

        public void OpenAlarm(int planID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.LoadTimeOutAlarm.GetHashCode(), planID) == false)
            {
                _data_VehicleAlarmBLL.Add(new DB_VehicleTransportManage.Model.data_VehicleAlarm()
                {
                    i_AlarmType = Common.Enum.EnumAlarmType.LoadTimeOutAlarm.GetHashCode(),
                    i_IsPreAlarm = 0,
                    dt_Start = DateTime.Now,
                    PlanID = planID
                });
                new SendAlarmCommand().DoWork();
            }
        }

        public void CloseAlarm(int planID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.LoadTimeOutAlarm.GetHashCode(), planID) == true)
            {
                DB_VehicleTransportManage.Model.data_VehicleAlarm alarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelAlarmByPlan(
                    Common.Enum.EnumAlarmType.LoadTimeOutAlarm.GetHashCode(), planID);
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
