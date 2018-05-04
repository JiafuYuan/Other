using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.DataCommand.OutDataCommand
{
    public class OutGetVehicleTypeModel : BaseDataCommandModel
    {
        public List<DB_VehicleTransportManage.Model.m_VehicleType> Listm_VehicleType = new List<DB_VehicleTransportManage.Model.m_VehicleType>();
    }
}
