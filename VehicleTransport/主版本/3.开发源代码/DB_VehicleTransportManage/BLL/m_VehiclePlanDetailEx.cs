using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace DB_VehicleTransportManage.BLL
{
    public partial class m_VehiclePlanDetail
    {
        public DataTable GetPlanCar(int planid)
        {
            string sql = "select a.PlanID,a.VehicleID,b.vc_code as carcode from m_VehiclePlanDetail a , m_Vehicle b where a.VehicleID=b.ID and PlanID=" + planid;
            return DB.OleDbHelper.GetDataTable(sql);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsCanAdd(Model.m_VehiclePlanDetail model)
        {
            DataSet ds = dal.GetList(string.Format("PlanID={0} and VehicleID={1}",model.PlanID,model.VehicleID));
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
