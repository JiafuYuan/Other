using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.FlowPath.InFlowPath
{
    /// <summary>
    /// 申请输入参数
    /// </summary>
    public class InApplyModel : InBaseModel
    {
        public DB_VehicleTransportManage.Model.m_Apply M_Apply;

        public List<DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie> ListM_Plan_ApplyMaterie;

        public List<DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle> ListM_Plan_ApplyVehicle;
    }
}
