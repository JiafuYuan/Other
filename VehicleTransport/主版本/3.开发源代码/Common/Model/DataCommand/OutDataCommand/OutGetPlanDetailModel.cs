using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.DataCommand.OutDataCommand
{
    public class OutGetPlanDetailModel
    {
        public List<DB_VehicleTransportManage.Model.m_Plan> Listm_Plan = new List<DB_VehicleTransportManage.Model.m_Plan>();

        public List<DB_VehicleTransportManage.Model.m_Apply> Listm_Apply = new List<DB_VehicleTransportManage.Model.m_Apply>();

        public List<DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie> Listm_Plan_ApplyMaterie = new List<DB_VehicleTransportManage.Model.m_Plan_ApplyMaterie>();

        public List<DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle> Listm_Plan_ApplyVehicle = new List<DB_VehicleTransportManage.Model.m_Plan_ApplyVehicle>();

        public List<DB_VehicleTransportManage.Model.m_Plan_CheckVehicle> Listm_Plan_CheckVehicle = new List<DB_VehicleTransportManage.Model.m_Plan_CheckVehicle>();
    }
}
