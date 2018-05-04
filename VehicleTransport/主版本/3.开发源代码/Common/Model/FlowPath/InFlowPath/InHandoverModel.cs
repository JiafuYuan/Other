using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.FlowPath.InFlowPath
{
    public class InHandoverModel : InBaseModel
    {
        public List<DB_VehicleTransportManage.Model.m_Plan_Handover> ListM_Plan_Handover = new List<DB_VehicleTransportManage.Model.m_Plan_Handover>();

        public List<DB_VehicleTransportManage.Model.m_Plan_HandoverMaterie> ListM_Plan_HandoverMaterie = new List<DB_VehicleTransportManage.Model.m_Plan_HandoverMaterie>();
    }
}
