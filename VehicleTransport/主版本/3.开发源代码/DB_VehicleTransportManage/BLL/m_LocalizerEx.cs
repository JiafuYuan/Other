using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DB_VehicleTransportManage.BLL
{
    public partial class m_Localizer
    {
        public bool IsExitCode(string vc_Code,int ID)
        {
            DataSet dataSet = dal.GetList("i_Flag=0 and id<>+" + ID + "and vc_Code='" + vc_Code + "'");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public bool IsExitName(string vc_Name, int ID)
        {
            DataSet dataSet = dal.GetList("i_Flag=0 and id<>+" + ID + "and vc_Name='" + vc_Name + "'");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsExitHID(int HID, int ID)
        {
            DataSet dataSet = dal.GetList("i_Flag=0 and id<>+"+ID+"and i_HID=" + HID );
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public DataTable GetCarLocal(string carid, DateTime dtstart, DateTime dtend,string tabname)
        {
            string sql = "select * from dbo.sysobjects where id = object_id(N'[dbo].[" + tabname + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            DataTable dt = DB.OleDbHelper.GetDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                sql = "select * from " + tabname + " where VehicleCarID=" + carid + " and dt_InTime between '" + dtstart + "' and '" + dtend+"'";
                return DB.OleDbHelper.GetDataTable(sql);
            }
            else
            {
                return null;
            }
        }
    }
}
