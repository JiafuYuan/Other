using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_VehicleMaintain
    {
        public void setMaintainEnd(int VehicleID, string dt_End)
        {
           DataSet dsDataSet= dal.GetList("i_Flag=0 and dt_EndDateTime is null and VehicleID="+VehicleID);
            if (dsDataSet != null && dsDataSet.Tables[0].Rows.Count > 0)
            {
                Model.m_VehicleMaintain _model = dal.DataRowToModel(dsDataSet.Tables[0].Rows[0]);
                _model.dt_EndDateTime = dt_End;
                Update(_model);
            }
        }
}
}
