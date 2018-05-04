using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class data_VehicleAlarm
    {
        /// <summary>
        /// 查询当前告警是否存在
        /// </summary>
        /// <returns></returns>
        public bool IsExistCurrentAlarmByVehicle(int alarmType, int vehicleID)
        {
            List<DB_VehicleTransportManage.Model.data_VehicleAlarm> lstAlarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelList(
                               string.Format("i_AlarmType={0} and VehicleID={1} and i_IsPreAlarm=0 and dt_End is null", alarmType,
                               vehicleID));
            if (lstAlarm != null && lstAlarm.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsExistCurrentAlarmByVehicleIDPlanID(int alarmType,int planID, int vehicleID)
        {
            List<DB_VehicleTransportManage.Model.data_VehicleAlarm> lstAlarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelList(
                               string.Format("i_AlarmType={0} and VehicleID={1} and planid={2} and i_IsPreAlarm=0 and dt_End is null", alarmType,
                               vehicleID,planID));
            if (lstAlarm != null && lstAlarm.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 查询当前告警是否存在
        /// </summary>
        /// <returns></returns>
        public bool IsExistCurrentAlarmByPlan(int alarmType, int planID)
        {
            List<DB_VehicleTransportManage.Model.data_VehicleAlarm> lstAlarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelList(
                               string.Format("i_AlarmType={0} and PlanID={1} and i_IsPreAlarm=0 and dt_End is null", alarmType,
                               planID));
            if (lstAlarm != null && lstAlarm.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 查询当前告警
        /// </summary>
        /// <returns></returns>
        public DB_VehicleTransportManage.Model.data_VehicleAlarm GetModelAlarmByPlan(int alarmType, int planID)
        {
            List<DB_VehicleTransportManage.Model.data_VehicleAlarm> lstAlarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelList(
                             string.Format("i_AlarmType={0} and PlanID={1} and i_IsPreAlarm=0 and dt_End is null", alarmType,
                             planID));
            if (lstAlarm != null && lstAlarm.Count > 0)
            {
                return lstAlarm[0];
            }
            return null;
        }

        /// <summary>
        /// 线束当前告警
        /// </summary>
        public void EndCurrentAlarm(int alarmTypeID)
        {
            DB.OleDbHelper.ExecuteSql("update  data_VehicleAlarm set dt_End=GETDATE() where i_AlarmType=" + alarmTypeID + " and dt_End is null ");
        }
        /// <summary>
        /// 查询当前告警By车辆ID
        /// </summary>
        /// <returns></returns>
        public DB_VehicleTransportManage.Model.data_VehicleAlarm GetModelAlarmByVehicleID(int alarmType, int vehicleID)
        {
            List<DB_VehicleTransportManage.Model.data_VehicleAlarm> lstAlarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelList(
                             string.Format("i_AlarmType={0} and VehicleID={1} and i_IsPreAlarm=0 and dt_End is null", alarmType,
                             vehicleID));
            if (lstAlarm != null && lstAlarm.Count > 0)
            {
                return lstAlarm[0];
            }
            return null;
        }

        /// <summary>
        /// 根据计划ID车辆ID查询
        /// </summary>
        /// <param name="alarmType"></param>
        /// <param name="vehicleID"></param>
        /// <returns></returns>
        public DB_VehicleTransportManage.Model.data_VehicleAlarm GetModelAlarmByPlanIDVehicleID(int alarmType,int planID, int vehicleID)
        {
            List<DB_VehicleTransportManage.Model.data_VehicleAlarm> lstAlarm = new DB_VehicleTransportManage.BLL.data_VehicleAlarm().GetModelList(
                             string.Format("i_AlarmType={0} and VehicleID={1} and PlanID={2} and i_IsPreAlarm=0 and dt_End is null", alarmType,
                             vehicleID,planID));
            if (lstAlarm != null && lstAlarm.Count > 0)
            {
                return lstAlarm[0];
            }
            return null;
        }

        ///// <summary>
        ///// 结束告警
        ///// </summary>
        ///// <returns></returns>
        //public bool EndAlarmByPlan()
        //{
        //    return false;
        //}

        /// <summary>执行存储过程
        /// 执行存储过程
        /// </summary>
        /// <param name="CallingNum"></param>
        /// <param name="CalledNum"></param>
        /// <param name="PathTime"></param>
        /// <param name="recpath"></param>
        /// <returns></returns>
        public DataSet RunProUpdate(string dtStart, string dtEnd)
        {
            OleDbParameter[] parameters = new OleDbParameter[2];
            parameters[0] = new OleDbParameter("@startDate", OleDbType.VarChar);
            parameters[0].Value = dtStart;
            parameters[1] = new OleDbParameter("@stopDate", OleDbType.VarChar);
            parameters[1].Value = dtEnd;

            try
            {
                DataSet ds = DB.OleDbHelper.GetDataSet("VehicleNoUseMonth", CommandType.StoredProcedure, parameters);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
    }
}
