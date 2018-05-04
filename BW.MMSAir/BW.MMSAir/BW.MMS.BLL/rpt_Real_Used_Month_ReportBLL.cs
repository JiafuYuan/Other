using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.Model;
using System.Data;

namespace BW.MMS.BLL
{
    public class rpt_Real_Used_Month_ReportBLL
    {
        public BW.MMS.DAL.rpt_Real_Used_Month_ReportDAL dal = new DAL.rpt_Real_Used_Month_ReportDAL();
        public DataSet getTab(string date)
        {
            return dal.getTab(date);
        }
    }
}
