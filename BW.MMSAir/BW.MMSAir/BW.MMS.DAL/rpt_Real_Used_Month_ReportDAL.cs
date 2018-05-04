using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BW.MMS.DBUtility;

namespace BW.MMS.DAL
{
    public class rpt_Real_Used_Month_ReportDAL
    {
        public DataSet  getTab(string date)
        {
            int n = 3000;
            DataSet  ds= DbHelperSQL.RunProcedure("p_real_used_month_report",new SqlParameter[]{ new SqlParameter("@date",date)},"tab", n);
            return ds;
        }
    }
}
