using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Thread.Command.NormalCommand;

namespace VehicleTransportServer.Thread.BackWork.Alarm
{
    /// <summary>
    /// 报废超期告警1
    /// </summary>
    public class ScrapTimeOutAlarm
    {
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _data_VehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();
        public  void DoWork()
        {
            try
            {
                if (Pub._isDBOnline == true)
                {
                    List<DB_VehicleTransportManage.Model.m_Vehicle> lst = new DB_VehicleTransportManage.BLL.m_Vehicle().GetModelList(
                       string.Format("i_Flag<>1 and (i_State={0} or i_State={1})", Common.Enum.EnumVehicleState.Normal.GetHashCode(), Common.Enum.EnumVehicleState.Using.GetHashCode()));
                    if (lst != null)
                    {
                        foreach (DB_VehicleTransportManage.Model.m_Vehicle item in lst)
                        {
                            if (item.dt_ScrapDateTime != null && 
                                item.dt_ScrapDateTime.Value < DateTime.Now && 
                                item.dt_ScrapDateTime.Value > Convert.ToDateTime("1901-1-1"))
                            {
                                OpenAlarm(item.ID);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "报废超期告警出错：" + ex.Message, null, true));
            }
        }

        public void OpenAlarm(int vehicleID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByVehicle(Common.Enum.EnumAlarmType.ScrapTimeOutAlarm.GetHashCode(), vehicleID) == false)
            {
                _data_VehicleAlarmBLL.Add(new DB_VehicleTransportManage.Model.data_VehicleAlarm()
                {
                    i_AlarmType = Common.Enum.EnumAlarmType.ScrapTimeOutAlarm.GetHashCode(),
                    i_IsPreAlarm = 0,
                    dt_Start = DateTime.Now,
                    VehicleID = vehicleID
                });
                new SendAlarmCommand().DoWork();
            }
        }
    }
}
