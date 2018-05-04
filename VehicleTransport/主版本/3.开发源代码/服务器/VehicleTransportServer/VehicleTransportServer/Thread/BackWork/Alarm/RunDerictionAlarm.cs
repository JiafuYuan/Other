using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleTransportServer.BLL;
using VehicleTransportServer.Thread.Command.NormalCommand;
using System.Data;

namespace VehicleTransportServer.Thread.BackWork.Alarm
{
    /// <summary>
    /// 运行方向不正确告警（见地点管理）1
    /// 开始：
    ///     1、DirectionLocalizerStationID(方向基站)   读到方向基站判断目的地的反向基站是否与方向基站一致，说明方向错误
    /// 结束：
    ///     1.计划全部完成
    /// </summary>
    public class RunDerictionAlarm
    {
        private DB_VehicleTransportManage.BLL.data_VehicleAlarm _data_VehicleAlarmBLL = new DB_VehicleTransportManage.BLL.data_VehicleAlarm();
        public  void DoWork()
        {
            try
            {
                if (Pub._isDBOnline == true)
                {
                    List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> lstPlanV = new List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail>();
                    lstPlanV = new DB_VehicleTransportManage.BLL.v_PlanVehicleDetail().GetModelList(
                        string.Format("VehicleState={0} and PlanState<>{1}",Common.Enum.EnumVehicleState.Using.GetHashCode()
                        ,Common.Enum.EnumPlanState.Complete.GetHashCode()));
                    if (lstPlanV != null && lstPlanV.Count > 0)
                    {
                        foreach (DB_VehicleTransportManage.Model.v_PlanVehicleDetail item in lstPlanV)
                        {
                            //当前车要去的目的地的反向基站的ID
                            int arriveFXID = new DB_VehicleTransportManage.BLL.m_Address().GetFXLocalizerIDByAddressID(item.ArriveDestinationAddressID.Value);

                            if (arriveFXID != 0 && arriveFXID == item.i_LocalizerStationID)
                            {
                                OpenAlarm(item.PlanID,item.VehicleID);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Pub.CommandLogList.Enqueue(LogMessageBLL.GetModel(Model.EnumLogType.Server, "运行方向不正确出错：" + ex.Message, null, true));
            }
        }

        public void OpenAlarm(int planID,int vehicleID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByVehicleIDPlanID(Common.Enum.EnumAlarmType.RunDerictionAlarm.GetHashCode(),planID, vehicleID) == false)
            {
                _data_VehicleAlarmBLL.Add(new DB_VehicleTransportManage.Model.data_VehicleAlarm()
                {
                    i_AlarmType = Common.Enum.EnumAlarmType.RunDerictionAlarm.GetHashCode(),
                    i_IsPreAlarm = 0,
                    dt_Start = DateTime.Now,
                    VehicleID = vehicleID,
                    PlanID=planID
                });
                new SendAlarmCommand().DoWork();
            }
        }

        public void CloseAlarm(int planID,int vehicleID)
        {
            if (_data_VehicleAlarmBLL.IsExistCurrentAlarmByVehicleIDPlanID(Common.Enum.EnumAlarmType.RunDerictionAlarm.GetHashCode(), planID,vehicleID) == true)
            {
                 
                DB_VehicleTransportManage.Model.data_VehicleAlarm alarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelAlarmByPlanIDVehicleID(
                    Common.Enum.EnumAlarmType.RunDerictionAlarm.GetHashCode(),planID, vehicleID);
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
