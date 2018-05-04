using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.FlowPath.InFlowPath
{
    public class InUnLoadModel : InBaseModel
    {
        public List<DB_VehicleTransportManage.Model.m_Plan_UnLoad> ListM_Plan_UnLoad = new List<DB_VehicleTransportManage.Model.m_Plan_UnLoad>();

        public List<DB_VehicleTransportManage.Model.m_Plan_UnLoadMaterie> Listm_Plan_UnLoadMaterie = new List<DB_VehicleTransportManage.Model.m_Plan_UnLoadMaterie>();
    }
}
