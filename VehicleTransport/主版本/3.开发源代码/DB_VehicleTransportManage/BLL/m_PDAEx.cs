
using System;
using System.Data;
using System.Collections.Generic;

using DB_VehicleTransportManage.Model;
namespace DB_VehicleTransportManage.BLL
{
	/// <summary>
	/// m_PDA
	/// </summary>
	public partial class m_PDA
	{
        public Model.m_PDA GetModelByMac(string mac)
        {
            List<Model.m_PDA> lst = new BLL.m_PDA().GetModelList("vc_macAddress='" + mac + "' and i_Flag=0");
            if (lst != null && lst.Count > 0)
            {
                return lst[0];
            }
            else
            {
                return null;
            }
        }
	}
}

