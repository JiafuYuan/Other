using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.DAL
{
    public partial class m_Plan_Handover
    {
        public int GetHandnumber(int planid)
        {
            string sql = "select MAX(i_handovercount) from m_Plan_Handover where PlanID=" + planid;
            object o=DB.OleDbHelper.ExecuteScale(sql);
            if (o != null)
                return int.Parse(o.ToString());
            else
                return 0;
        }

    }
}
