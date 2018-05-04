using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread.BackWork.Alarm
{
    /// <summary>
    /// 未按时运送告警（计划到达时间）1
    /// 开始：
    ///     1、审核时确定的到达时间 小于 当前时间
    /// 结束：
    ///     1、计划全部完成
    ///    
    /// </summary>
    public class TransportTimeOutAlarm
    {
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _data_VehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();
        public  void DoWork()
        {
            try
            {
                if (Pub._isDBOnline == true)
                {
                    List<DB_VehicleTransportManage.Model.m_Plan> lstV = new DB_VehicleTransportManage.BLL.m_Plan().GetModelList(
                        string.Format("i_State<>{0} ",Common.Enum.EnumPlanState.Complete.GetHashCode() ));
                    if (lstV != null)
                    {
                        foreach (DB_VehicleTransportManage.Model.m_Plan item in lstV)
                        {
                            if (item.dt_ArriveDestinationDateTime < DateTime.Now)
                            {
                                OpenAlarm(item.ID);
                            }
                            //if (item.dt_RealArriveDestinationDateTime>Convert.ToDateTime("1900-1-1"))
                            //{
                            //    CloseAlarm(item.ID);
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "未按时运送告警出错：" + ex.Message, null, true));
            }
        }

        public void OpenAlarm(int planID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.TransportTimeOutAlarm.GetHashCode(), planID) == false)
            {
                _data_VehicleAlarmBLL.Add(new DB_VehicleTransportManage.Model.data_VehicleAlarm()
                {
                    i_AlarmType = Common.Enum.EnumAlarmType.TransportTimeOutAlarm.GetHashCode(),
                    i_IsPreAlarm = 0,
                    dt_Start = DateTime.Now,
                    PlanID = planID
                });
                new SendAlarmCommand().DoWork();
            }
        }

        public void CloseAlarm(int planID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByPlan(Common.Enum.EnumAlarmType.TransportTimeOutAlarm.GetHashCode(), planID) == true)
            {
                DB_VehicleTransportManage.Model.data_VehicleAlarm alarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelAlarmByPlan(
                    Common.Enum.EnumAlarmType.TransportTimeOutAlarm.GetHashCode(), planID);
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
