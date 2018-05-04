using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BW.MMS.BLL
{
    public class ReportBLL
    {
        private readonly BW.MMS.DAL.ReportDAL dal = new BW.MMS.DAL.ReportDAL();
        /// <summary>
        /// 获取日报表
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public DataTable GetDailyReport(string date)
        {
            DataSet ds = dal.GetDailyReport(date);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        /// <summary>
        /// 获取单位产量耗能日报表
        /// </summary>
        /// <param name="date">日期yyyy-mm-dd</param>
        /// <returns></returns>
        public DataTable GetProdutionDailyReport(string date)
        {
            DataSet ds = dal.GetProdutionDailyReport(date);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        /// <summary>
        /// 年统计
        /// </summary>
        public DataSet getYearData(string year)
        {
            return dal.getYearData(year);
        }
        /// <summary>
        /// 返回实际能耗与计划能耗对比表
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataSet GetExpendCompareRealAndPlan(string dtDate)
        {
            return dal.GetExpendCompareRealAndPlan(dtDate);
        }

        public DataTable GetDailyCapacity(string date)
        {
            return dal.GetDailyCapacity(date);
        }

        public DataTable GetDataByDept(int type, DateTime date)
        {
            return dal.GetDataByDept(type, date);
        }
    }
}
