using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BW.MMS.BLL
{
    public class p_actualEnergyDLL
    {
        private readonly BW.MMS.DAL.p_actualEnergyDAL dal = new BW.MMS.DAL.p_actualEnergyDAL();
        /// <summary>
        /// 得到DataSet
        /// </summary>
        public DataTable GetactualEnergyReport(string month)
        {
            return dal.GetactualEnergyReport(month);
        }
    }
}
