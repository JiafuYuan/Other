using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace DB_VehicleTransportManage.DAL
{
    public partial class m_Plan_UnLoad
    {
        public List<int> GetCars(int planid)
        {
            string sql = "select distinct VehicleID from m_Plan_UnLoad where PlanID=" + planid;
            DataTable dt = DB.OleDbHelper.GetDataTable(sql);
            List<int> listcar = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listcar.Add(int.Parse(dt.Rows[i]["VehicleID"].ToString()));
            }
            return listcar;
        }
    }
}
