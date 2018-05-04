
using System;
using System.Data;
using System.Collections.Generic;

using DB_VehicleTransportManage.Model;
using System.Text;
namespace DB_VehicleTransportManage.BLL
{
	/// <summary>
	/// m_WifiBaseStation
	/// </summary>
	public partial class m_WifiBaseStation
	{
        public Model.m_WifiBaseStation GetModelByMac(string mac)
        {
            List<Model.m_WifiBaseStation> lst = new BLL.m_WifiBaseStation().GetModelList("vc_macAddress='" + mac + "' and i_Flag=0");
            if (lst != null && lst.Count > 0)
            {
                return lst[0];
            }
            else
            {
                return null;
            }
        }

        public string GetWifiIDsByLocalizerIDs(string localizerIDs)
        {
            List<DB_VehicleTransportManage.Model.m_WifiBaseStation> lstWifi = new List<DB_VehicleTransportManage.Model.m_WifiBaseStation>();
            if (localizerIDs=="")
            {
                return "";
            }
            lstWifi = new DB_VehicleTransportManage.BLL.m_WifiBaseStation().GetModelList("i_flag=0 and  LocalizerStationID in (" + localizerIDs+")");
            StringBuilder wifiIDs = new StringBuilder();
            foreach (DB_VehicleTransportManage.Model.m_WifiBaseStation itemWifi in lstWifi)
            {
                wifiIDs.Append(itemWifi.ID + ",");
            }
            if (wifiIDs.Length > 0)
            {
                return wifiIDs.ToString().Substring(0, wifiIDs.Length - 1);
            }
            else
            {
                return "";
            }
            
        }

        public bool IsAddressUsed(int ID)
        {
            DataSet dataSet = dal.GetList(" i_Flag=0 and LocalizerStationID=" + ID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
	}
}

