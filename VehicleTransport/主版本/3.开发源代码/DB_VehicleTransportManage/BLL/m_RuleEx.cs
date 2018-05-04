using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Rule
    {
      
        public string GetName(int ID)
        {
            DataSet dataSet = new DataSet();
            dataSet = dal.GetList("i_Flag=0 and ID=" + ID.ToString());
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return dataSet.Tables[0].Rows[0]["vc_Name"].ToString();
            }
            return "";
        }
    }
}
