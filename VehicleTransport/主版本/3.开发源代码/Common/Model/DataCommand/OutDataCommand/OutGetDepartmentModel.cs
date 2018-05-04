using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.DataCommand.OutDataComand
{
    public class OutGetDepartmentModel:BaseDataCommandModel
    {
        public List<DB_VehicleTransportManage.Model.m_Department> ListMessage = new List<DB_VehicleTransportManage.Model.m_Department>();
    }
}
