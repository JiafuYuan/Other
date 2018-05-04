using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.DataCommand.InDataCommand
{
    public class InGetVehicleIsCanDoModel 
    {
        /// <summary>
        /// 流程点
        /// </summary>
        public Enum.EnumFlowPathType FlowType { get; set; }

        /// <summary>
        /// 车辆ID
        /// </summary>
        public int VehicleID { get; set; }

    }
}
