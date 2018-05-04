
using System;
using System.Data;
using System.Collections.Generic;

using DB_VehicleTransportManage.Model;
namespace DB_VehicleTransportManage.BLL
{
	/// <summary>
	/// m_Plan_BackVehicle
	/// </summary>
	public partial class m_Plan_BackVehicle
	{
        /// <summary>
        /// 查询同一计划的车辆是否重复还
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsExist(int planID,int vehicleID)
        {
            DataSet ds = dal.GetList(string.Format("planId={0} and vehicleID={1}", planID, vehicleID));
            if (ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
            {
                return true;
            }
            return false;
        }
	}
}

