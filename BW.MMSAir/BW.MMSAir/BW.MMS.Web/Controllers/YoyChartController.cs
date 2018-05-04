using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Web.Filters;
using BW.MMS.Web.HtmlExtension.Easyui;
using NPOI.POIFS.Storage;

namespace BW.MMS.Web.Controllers
{
    public class YoyChartController : Controller
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
            string paramYear = Request["beginDate"].Replace("年", "");
            string beginDate = paramYear + "-01-01 00:00:00";
            string endDate = paramYear + "-12-31 23:59:59";
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
            List<float> listHistoryMonth = new List<float>();
            string paramYear = Request["beginDate"].Replace("年", "");
            string beginDate = paramYear + "-01-01 00:00:00";
            string endDate = paramYear + "-12-31 23:59:59";
            string beginDateHistoryMonth = DateTime.Parse(beginDate).AddYears(-1).ToString("yyyy-MM-dd HH:mm:ss");
            string endDateHistoryMonth = DateTime.Parse(endDate).AddYears(-1).ToString("yyyy-MM-dd HH:mm:ss");
            if (Request["sensorType"].ToString().Length == 0)
            {
                listCurrentMonth.Add(0);
                listHistoryMonth.Add(0);
            }
            else
            {
                string sensorType = "NuoFangSensorControl1." + Request["sensorType"].ToString();
                DataSet ds = bllHistoryRecord.GetYearReport(beginDate, endDate);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];

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
                ds = bllHistoryRecord.GetYearReport(beginDateHistoryMonth, endDateHistoryMonth);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    DataTable dt2 = ds.Tables[0];

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        listHistoryMonth.Add(
                            float.Parse(dt2.Rows[i][sensorType].ToString() == ""
                                ? "0"
                                : dt2.Rows[i][sensorType].ToString()));
                    }
                }
                else
                {
                    listHistoryMonth.Add(0);
                }
            }
           
            List<SeriesData> seriesdata = new List<SeriesData>();
            SeriesData s1 = new SeriesData();
            s1.name = DateTime.Parse(beginDateHistoryMonth).Year.ToString();
            s1.data = listHistoryMonth;
            seriesdata.Add(s1);

            SeriesData s2 = new SeriesData();
            s2.name = DateTime.Parse(beginDate).Year.ToString();
            s2.data = listCurrentMonth;
            seriesdata.Add(s2);

            return Json(seriesdata);
        }

       
        public JsonResult DataTableToReportJson(DataTable dt, string tableName)
        {
            List<object> columns = new List<object>();
            foreach (DataColumn column in dt.Columns)
            {
                string t = "string";
                int length = 0;
                if (column.DataType == typeof(string))
                {
                    length = 500;
                }
                if (column.DataType == typeof(int))
                {
                    t = "integer";
                }
                if (column.DataType == typeof(double))
                {
                    t = "float";
                }
                if (column.DataType == typeof(decimal))
                {
                    t = "float";
                }
                if (column.DataType == typeof(DateTime))
                {
                    t = "datetime";
                }
                columns.Add(new { name = column.ColumnName, type = t, length = column.MaxLength == -1 ? length : column.MaxLength });
            }
            List<object> records = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                string record = string.Empty;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        record += ",";
                    }
                    record += row[dt.Columns[i].ColumnName];
                }
                records.Add(new { values = record });
            }
            var data = new { name = tableName, titles = columns, records = records };
            return Json(data);
        }
        [Serializable]
        public class SeriesData
        {
            public string name;
            public List<float> data;
        }
    }
}
