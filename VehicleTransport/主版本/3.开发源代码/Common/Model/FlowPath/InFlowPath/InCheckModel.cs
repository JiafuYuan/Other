using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.FlowPath.InFlowPath
{
    public class InCheckModel : InBaseModel
    {
        public DB_VehicleTransportManage.Model.m_Plan PlanModel;
        public DB_VehicleTransportManage.Model.m_Apply ApplyModel;
        public List<DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie> ListPlan_ApplyMaterie = new List<DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie>();
        public List<DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle> ListPlan_ApplyVehicle = new List<DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle>();
        public List<DB_VehicleTransportManage.Model.m_Plan_CheckVehicle> ListPlan_CheckVehicle = new List<DB_VehicleTransportManage.Model.m_Plan_CheckVehicle>();
    }
}
