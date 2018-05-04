using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial  class m_Address
    {
        public bool IsAreaUsed(int AreaID)
        {
          
            DataSet dataSet = dal.GetList(" i_Flag=0 and AreaID=" + AreaID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据地点ID取反向基站ID
        /// </summary>
        /// <param name="addressID"></param>
        /// <returns></returns>
        public int GetFXLocalizerIDByAddressID(int addressID)
        {
            Model.m_Address model = dal.GetModel(addressID);
            if (model != null)
            {
                return model.DirectionLocalizerStationID.Value;
            }
            return 0;
        }

        /// <summary>
        /// 根据地点ID取基站ID
        /// </summary>
        /// <param name="addressID"></param>
        /// <returns></returns>
        public int GetLocalizerIDByAddressID(int addressID)
        {
            Model.m_Address model = dal.GetModel(addressID);
            if (model != null)
            {
                return model.LocalizerStationID.Value;
            }
            return 0;
        }

        /// <summary>
        /// 根据地点ID取地点名称
        /// </summary>
        /// <param name="addressID"></param>
        /// <returns></returns>
        public string GetAddressNameByAddressID(int addressID)
        {
            Model.m_Address model = dal.GetModel(addressID);
            if (model != null)
            {
                return model.vc_Name;
            }
            return "";
        }

        /// <summary>
        /// 得到一个对象实体(KJ222基站)
        /// </summary>
        public string GetLocalizerStationName(int LocalizerStationID)
        {
            DataSet dataSet = dal.GetList(" i_Flag=0 and LocalizerStationID=" + LocalizerStationID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return dataSet.Tables[0].Rows[0]["vc_Name"].ToString();
            }
            return "";
        }

        ///// <summary>
        ///// 根据基站ID取反向基站的ID
        ///// </summary>
        ///// <param name="LocalizerStationID"></param>
        ///// <returns></returns>
        //public int GetFIDByLocalizerID(int LocalizerStationID)
        //{
        //    DataSet dataSet = dal.GetList(" i_Flag=0 and LocalizerStationID=" + LocalizerStationID);
        //    if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
        //    {
        //        return Convert.ToInt32( dataSet.Tables[0].Rows[0]["DirectionLocalizerStationID"].ToString());
        //    }
        //    return 0;
        //}

        public bool IsLocalizerStationUsed(int ID)
        {
            DataSet dataSet = dal.GetList(" i_Flag=0 and DirectionLocalizerStationID=" + ID);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

       
        public DataSet DropDownSource()
        {
            string sql = "SELECT   ID,vc_Name as '地点名称',vc_Memo as '备注' FROM m_Address  where i_Flag=0";

            return DB.OleDbHelper.GetDataSet(sql);
        }
        /// <summary>
        /// 根据基站ID取区域ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetAreaIDByLocalizerID(int localizerStationID)
        {
            List<DB_VehicleTransportManage.Model.m_Address> lstAddress = new List<DB_VehicleTransportManage.Model.m_Address>();
            lstAddress = new DB_VehicleTransportManage.BLL.m_Address().GetModelList("i_flag=0 and LocalizerStationID=" + localizerStationID);
            if (lstAddress != null && lstAddress.Count == 1)
            {
                return lstAddress[0].AreaID.Value;
            }
            return 0;
        }

        /// <summary>
        /// 根据基站ID得到地点ID
        /// </summary>
        /// <param name="localizerStationID"></param>
        /// <returns></returns>
        public int GetAddressIDByLocalizerID(int localizerStationID)
        {
            List<DB_VehicleTransportManage.Model.m_Address> lstAddress = new List<DB_VehicleTransportManage.Model.m_Address>();
            lstAddress = new DB_VehicleTransportManage.BLL.m_Address().GetModelList("i_flag=0 and LocalizerStationID=" + localizerStationID);
            if (lstAddress != null && lstAddress.Count == 1)
            {
                return lstAddress[0].ID;
            }
            return 0;
        }

        /// <summary>
        /// 根据区域ID取基站ID集合
        /// </summary>
        /// <param name="areaID"></param>
        /// <returns></returns>
        public string GetLocalizerIDsByAreaID(int areaID)
        {
            List<DB_VehicleTransportManage.Model.m_Address> lstAddress = new DB_VehicleTransportManage.BLL.m_Address().GetModelList("i_Flag=0 and areaID=" + areaID);
            StringBuilder localizerIDs = new StringBuilder();
            foreach (DB_VehicleTransportManage.Model.m_Address itemAddress in lstAddress)
            {
                localizerIDs.Append(itemAddress.LocalizerStationID + ",");
            }

            if (localizerIDs.Length > 0)
            {
                return localizerIDs.ToString().Substring(0, localizerIDs.Length - 1);
            }
            else
            {
                return "";
            }

        }

        public bool IsOnLine(int localid)
        {
            return dal.IsOnLine(localid);
        }
    }
}
