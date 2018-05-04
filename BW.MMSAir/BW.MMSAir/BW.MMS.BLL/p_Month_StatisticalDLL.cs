using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BW.MMS.BLL
{
    public class p_Month_StatisticalDLL
    {
        private readonly BW.MMS.DAL.p_Month_StatisticalDAL dal = new BW.MMS.DAL.p_Month_StatisticalDAL();
        /// <summary>
        /// 得到DataSet
        /// </summary>
        public DataSet getMonthData(string startmonth, string endmonth, string paramSearchDept)
        {
            return dal.getMonthData(startmonth,endmonth,paramSearchDept);
        }
    }
}
