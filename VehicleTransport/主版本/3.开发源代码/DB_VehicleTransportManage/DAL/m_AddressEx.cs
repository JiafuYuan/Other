using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace DB_VehicleTransportManage.DAL
{
    public partial class m_Address
    {
        public bool IsOnLine(int localid)
        {
            string sql = "select * from BW_KJ222.dbo.Alarm_Current where AlarmTypeID=1001 and EquipmentID=" + localid;
            DataTable dt = DB.OleDbHelper.GetDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
