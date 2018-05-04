using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.DataCommand.OutDataCommand
{
    public class OutGetVehicleModel:BaseDataCommandModel
    {
        public List<DB_VehicleTransportManage.Model.m_Vehicle> ListVehicle = new List<DB_VehicleTransportManage.Model.m_Vehicle>();
    }
}
