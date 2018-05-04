using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BW.MMS.BLL
{
    public class p_Year_StatisticalDLL
    {
        private readonly BW.MMS.DAL.p_Year_StatisticalDAL dal = new BW.MMS.DAL.p_Year_StatisticalDAL();
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public DataSet getYearData(string year)
        {
            return dal.getYearData(year);
        }
    }
}
