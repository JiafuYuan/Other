using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Plan_Handover
    {
        public int GetHandOverCount(int planid)
        {
            return dal.GetHandnumber(planid);
        }
    }
}
