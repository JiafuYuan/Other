using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BW.MMS.DBUtility;
using System.Data.SqlClient;

namespace BW.MMS.DAL
{
    public class p_actualEnergyDAL
    {
        /// <summary>
        /// 返回月统计量
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetactualEnergyReport(string month)
        {

            DataSet ds = DbHelperSQL.RunProcedure("p_actualEnergyReport", new SqlParameter[] { new SqlParameter("@dt_date", month) }, "table", 1000);
            return ds.Tables[0];
        }
    }
}
