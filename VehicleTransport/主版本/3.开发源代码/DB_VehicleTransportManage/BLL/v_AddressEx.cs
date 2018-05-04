using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class v_Address
    {
        public string GetLocalizerStationName(int ID)
        {
            Model.v_Address _model = GetModel(ID);
            if (_model != null && _model.i_Flag == 0)
            {
                return _model.vc_Name;
            }
            return "";
        }
        public string GetLocalizerStationNamebyLocalizerStationID(int LocalizerStationID)
        {
            string sql = "SELECT  LocalizerStationID, vc_Name FROM v_Address where i_Flag=0 and LocalizerStationID=" + LocalizerStationID;

            DataSet dataSet= DB.OleDbHelper.GetDataSet(sql);

            if (dataSet != null && dataSet.Tables[0].Rows.Count>0)
            {
                return dataSet.Tables[0].Rows[0]["vc_Name"].ToString();
            }
            return "";
        }
        public DataSet DropDownSource()
        {
            string sql = "SELECT  ID,vc_Code as '基站编号', vc_Name as '基站名称' FROM v_Address where i_Flag=0";

            return DB.OleDbHelper.GetDataSet(sql);
        }

        public DataSet DropDownSource(string Where)
        {
            string sql = "SELECT  ID,vc_Code as '基站编号', vc_Name as '基站名称' FROM v_Address where " + Where;

            return DB.OleDbHelper.GetDataSet(sql);
        }

        public DataSet DropDownSourceLocalizerStationName(string Where)
        {
            string sql = "SELECT  LocalizerStationID,vc_Code as '基站编号', vc_Name as '基站名称' FROM v_Address where " + Where;

            return DB.OleDbHelper.GetDataSet(sql);
        }
    }
}
