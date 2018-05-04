using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BW.MMS.DBUtility;
using System.Data.SqlClient;

namespace BW.MMS.DAL
{
    public class p_Year_StatisticalDAL
    {
        /// <summary>
        /// 返回年统计量
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataSet getYearData(string year)
        {

            DataSet ds = DbHelperSQL.RunProcedure("p_Year_Statistical", new SqlParameter[] { new SqlParameter("@dt_Year", year) }, "table", 1000);
            return ds;
        }
    }
}
