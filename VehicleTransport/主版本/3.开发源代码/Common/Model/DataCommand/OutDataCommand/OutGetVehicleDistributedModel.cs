using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.DataCommand.OutDataCommand
{
    /// <summary>
    /// 车辆分布信息，按区域
    /// </summary>
    public class OutGetVehicleDistributedModel
    {
        public List<DB_VehicleTransportManage.Model.v_AreaVehicle> Listv_AreaVehicle = new List<DB_VehicleTransportManage.Model.v_AreaVehicle>();
    }


}
