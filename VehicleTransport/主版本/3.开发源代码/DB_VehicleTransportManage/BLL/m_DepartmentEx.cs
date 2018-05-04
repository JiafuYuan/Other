using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Department
    {
        public string GetName(int parentID)
        {
           
            Model.m_Department _model = GetModel(parentID);
            if (_model != null && _model.i_Flag == 0)
            {
                return _model.vc_Name;
            }
            return "";
        }

        public string GetNameByID(int id)
        {

            Model.m_Department _model = GetModel(id);
            if (_model != null && _model.i_Flag == 0)
            {
                return _model.vc_Name;
            }
            return "";
        }

    }
}
