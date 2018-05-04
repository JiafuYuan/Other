using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BW.MMS.DBUtility;
using System.Data.SqlClient;

namespace BW.MMS.DAL
{
    public class ReportDAL
    {
        /// <summary>
        /// 获取日报表
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public DataSet GetDailyReport(string date)
        {
            DataSet ds = DbHelperSQL.RunProcedure("p_DailyReport", new SqlParameter[] { new SqlParameter("@dt_Date", date) }, "table", 1000);
            return ds;
        }
        /// <summary>
        /// 获取单位产量耗能日报表
        /// </summary>
        /// <param name="date">日期yyyy-mm-dd</param>
        /// <returns></returns>
        public DataSet GetProdutionDailyReport(string date)
        {
            DataSet ds = DbHelperSQL.RunProcedure("p_Production_DailyReport", new SqlParameter[] { new SqlParameter("@dt_Date", date) }, "table", 1000);
            return ds;
        }

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
        /// <summary>
        /// 返回实际能耗与计划能耗对比表
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataSet GetExpendCompareRealAndPlan(string dtDate)
        {

            DataSet ds = DbHelperSQL.RunProcedure("p_Compare_Used_And_Plan_report", new SqlParameter[] { new SqlParameter("@date", dtDate) }, "table", 1000);
            return ds;
        }


        public DataTable GetDailyCapacity(string date)
        {
            DataSet ds = DbHelperSQL.RunProcedure("p_DailyCapacity", new SqlParameter[] { new SqlParameter("@dt_Date", date) }, "table", 1000);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        public DataTable GetDataByDept(int type, DateTime date)
        {
            string tableName = "Data_History_Production_" + date.ToString("yyyy_MM");
            string field = "f_RealCumulativeTraffic";
            string plan = date.ToString("r").Split(' ')[2].Substring(0, 3);
            int year = date.Year;
            switch (type)
            {
                case 1:
                    tableName = "Data_History_Wind_" + date.ToString("yyyy_MM");
                    field = "f_RealCumulativeTraffic";
                    break;
                case 2:
                    tableName = "Data_History_Water_" + date.ToString("yyyy_MM");
                    field = "f_RealPlusCumulativeFlowrate";
                    break;
                case 3:
                    tableName = "Data_History_Power_" + date.ToString("yyyy_MM");
                    field = "f_RealCumulativePower";
                    break;
            }
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select m.vc_Name,t.Total,isnull(e.{0},0) [Plan] from m_Dept m join ", plan);
            strSql.AppendFormat("(select SUM({0}) Total,DeptID from {1} group by DeptID) t ", field, tableName);
            if (type != 4)
            {
                strSql.AppendFormat("on m.ID=t.DeptID left join m_EnergyPlan e on e.Years={0} and e.[type]={1} ", year, type);
            }
            else
            {
                strSql.AppendFormat("on m.ID=t.DeptID left join m_ProductionPlan e on e.Years={0} ", year);
            }
            strSql.Append("and m.ID=e.DeptID");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
    }
}
