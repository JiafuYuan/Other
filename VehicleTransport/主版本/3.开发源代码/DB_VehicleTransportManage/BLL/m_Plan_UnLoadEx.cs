using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Plan_UnLoad
    {
        public List<int> GetCars(int planid)
        {
            return dal.GetCars(planid);
        }
    }
}
