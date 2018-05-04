using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Area
    {
        public string GetName(int ID)
        {
            Model.m_Area modelArea = GetModel(ID);
            if (modelArea != null && modelArea.i_Flag == 0)
            {
                return modelArea.vc_Name;
            }
            return "";
        
        }
    }
}
