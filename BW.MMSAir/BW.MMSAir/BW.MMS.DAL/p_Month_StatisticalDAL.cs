using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BW.MMS.DBUtility;
using System.Data.SqlClient;

namespace BW.MMS.DAL
{
    public class p_Month_StatisticalDAL
    {
        /// <summary>
        /// 返回月统计量
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataSet getMonthData(string startmonth, string endmonth, string paramSearchDept)
        {

            DataSet ds = DbHelperSQL.RunProcedure("p_Month_Statistical", new SqlParameter[] { new SqlParameter("@begin_date", startmonth), new SqlParameter("@end_date", endmonth), new SqlParameter("@deptID", paramSearchDept) }, "table", 1000);
            return ds;
        }
    }
}
