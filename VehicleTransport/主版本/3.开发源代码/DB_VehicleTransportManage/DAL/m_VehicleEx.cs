using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace DB_VehicleTransportManage.DAL
{
    public partial class m_Vehicle
    {
        public DataTable GetLocalinfo()
        {
            string sql = "select a.LocalizerStationID,COUNT(b.ID) from m_Address a left join m_Vehicle b on a.LocalizerStationID=b.i_LocalizerStationID  and b.i_Flag=0 where a.i_Flag=0   group by a.LocalizerStationID";
            return DB_VehicleTransportManage.DB.OleDbHelper.GetDataTable(sql);

        }
      
    }
}
