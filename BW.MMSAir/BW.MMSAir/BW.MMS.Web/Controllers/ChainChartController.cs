using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Web.Filters;

namespace BW.MMS.Web.Controllers
{
    public class ChainChartController : Controller
    {
        //
        // GET: /MonthWhole/
        private readonly BLL.HistoryRecord bllHistoryRecord = new HistoryRecord();


        /// <summary>
        /// 首页视图
        /// </summary>
        /// <returns></returns>
        [ExceptionFilter]
        public ActionResult Index()
        {

            return View();
        }



        /// <summary>
        /// 获取DataGrid数据
        /// </summary>
        /// <param name="page">起始页</param>
        /// <param name="rows">每页条数</param>
        /// <param name="sort">排序字段</param>
        /// <param name="order">排序方式(DESC/ASC)</param>
        /// <returns></returns>
        /// <summary>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetGridList()
        {
            string paramDate = Request["beginDate"].Replace("年", "");
            string beginDate = paramDate + "-01-01 00:00:00";
            string endDate = paramDate + "-12-31 23:59:59";
            DataSet ds = bllHistoryRecord.GetYearReport(beginDate, endDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0].Clone();
                foreach (DataColumn item in dt.Columns)
                {
                    if (item.DataType == typeof(double))
                    {
                        item.DataType = typeof(decimal);
                    }
                }
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn column in dt.Columns)
                    {
                        dr[column.ColumnName] = row[column.ColumnName];
                    }
                    dt.Rows.Add(dr);
                }
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult getxAxis()
        {
            //string beginDate = (DateTime.Parse(Request["beginDate"].ToString())).ToString("yyyy-MM-01 00:00:00");
            //string endDate = LastDayOfMonth(DateTime.Parse(Request["beginDate"].ToString())).ToString("yyyy-MM-dd 23:59:59");
            //DataSet ds = bllHistoryRecord.GetList(string.Format("  recordtime between '{0}' and '{1}'", beginDate, endDate));
            //string[] strDate = null;
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    DataTable dt = bllHistoryRecord.GetYearReport(beginDate, endDate).Tables[0];
            //    strDate = new string[dt.Rows.Count];
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    //strDate[i] = dt.Rows[i]["Datetitle"].ToString();//.Substring(5,5);
            //    strDate[i] = dt.Rows[i]["RecordMonth"].ToString() + "月";
            //}
            //}
            string[] strDate = new string[12];
            for (int i = 0; i < 12; i++)
            {
                //strDate[i] = dt.Rows[i]["Datetitle"].ToString();//.Substring(5,5);
                strDate[i] = (i + 1).ToString() + "月";
            }
            return Json(strDate);
        }
        /// 取得某月的最后一天
        /// </summary>
        /// <param name="datetime">要取得月份最后一天的时间</param>
        /// <returns></returns>
        private DateTime LastDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult getSeries()
        {
            List<float> listCurrentMonth = new List<float>();
            string paramDate = Request["beginDate"].Replace("年", "");
            string beginDate = paramDate + "-01-01 00:00:00";
            string endDate = paramDate + "-12-31 23:59:59";
            string sensorType = "NuoFangSensorControl1." + Request["sensorType"].ToString();
            DataSet ds = bllHistoryRecord.GetYearReport(beginDate, endDate);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                //foreach (DataColumn col in dt.Columns)
                //{
                //    if (col.ColumnName == sensorType)
                //    {
                //        b = true;
                //    }
                //}
                //if (b)
                //{
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][sensorType] != null)
                    {
                        listCurrentMonth.Add(
                            float.Parse(dt.Rows[i][sensorType].ToString() == ""
                                ? "0"
                                : dt.Rows[i][sensorType].ToString()));

                    }

                }
            }

            else
            {
                listCurrentMonth.Add(0);
            }
            List<YoyChartController.SeriesData> seriesdata = new List<YoyChartController.SeriesData>();
            YoyChartController.SeriesData s2 = new YoyChartController.SeriesData();
            s2.name = DateTime.Parse(beginDate).Year.ToString();
            s2.data = listCurrentMonth;
            seriesdata.Add(s2);
            return Json(seriesdata);
        }

       
        [Serializable]
        public class SeriesData
        {
            public string name;
            public List<float> data;
        }
    }
}
