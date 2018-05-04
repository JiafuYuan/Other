using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Web.Filters;
using BW.MMS.Web.HtmlExtension.Easyui;

namespace BW.MMS.Web.Controllers
{
    public class MonthReportController : Controller
    {
        BLL.HistoryRecord bllHistoryRecord=new HistoryRecord();
        /// <summary>
        /// 首页视图
        /// </summary>
        /// <returns></returns>
        [ExceptionFilter]
        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            return View();
        }

        private List<List<DataGridColumn>> GetColumns()
        {
           

            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            List<DataGridColumn> column1 = new List<DataGridColumn>();
           
            column1.Add(new DataGridColumn { title = "日期", field = "RecordDay", columnAttributes = new { align = "center", width = 120, sortable = false } });
            column1.Add(new DataGridColumn { title = "在线状态", field = "NuoFangSensorControl1.OnLineState", columnAttributes = new { align = "center", width = 100, sortable = false } });
            column1.Add(new DataGridColumn { title = "温度", field = "NuoFangSensorControl1.Temperature", columnAttributes = new { align = "center", width = 100, sortable = false } });
            column1.Add(new DataGridColumn { title = "PM2.5", field = "NuoFangSensorControl1.PM2.5", columnAttributes = new { align = "center", width = 100, sortable = false } });
            column1.Add(new DataGridColumn { title = "PM10", field = "NuoFangSensorControl1.PM10", columnAttributes = new { align = "center", width = 100, sortable = false } });
            column1.Add(new DataGridColumn { title = "TVOC", field = "NuoFangSensorControl1.TVOC", columnAttributes = new { align = "center", width = 100, sortable = false } });
            column1.Add(new DataGridColumn { title = "Humidity", field = "NuoFangSensorControl1.Humidity", columnAttributes = new { align = "center", width = 100, sortable = false } });
            columns.Add(column1);
            return columns;
        }

        /// <summary>
        /// 获取DataGrid数据
        /// </summary>
        /// <param name="page">起始页</param>
        /// <param name="rows">每页条数</param>
        /// <param name="sort">排序字段</param>
        /// <param name="order">排序方式(DESC/ASC)</param>
        /// <returns></returns>
        ///   /**//// <summary>
        /// 取得某月的最后一天
        /// </summary>
        /// <param name="datetime">要取得月份最后一天的时间</param>
        /// <returns></returns>
        private DateTime LastDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetGridList()
        {
            string beginDate = (DateTime.Parse(Request["beginDate"].ToString())).ToString("yyyy-MM-01 00:00:00");
            string endDate=LastDayOfMonth(DateTime.Parse(Request["beginDate"].ToString())).ToString("yyyy-MM-dd 23:59:59");
            DataSet ds = bllHistoryRecord.GetMonthReport(beginDate, endDate);
          
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0].Clone();
                foreach (DataColumn item in dt.Columns)
                {
                    if (item.DataType == typeof(double))
                    {
                        item.DataType = typeof(decimal);
                    }
                    if (item.ColumnName == "RecordDay")
                    {
                        item.DataType = typeof(string);
                    }
                }
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn column in dt.Columns)
                    {
                        dr[column.ColumnName] = row[column.ColumnName];
                        if (column.ColumnName == "RecordDay")
                        {
                            dr[column.ColumnName] = (DateTime.Parse(Request["beginDate"].ToString())).ToString("yyyy年MM月") + dr[column.ColumnName].ToString().PadLeft(2,'0')+"日";
                        }
                    }
                   
                    dt.Rows.Add(dr);
                }
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
            }
            return null;
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

        [HttpPost]
        public JsonResult GetReportData()
        {
            string beginDate = (DateTime.Parse(Request["beginDate"].ToString())).ToString("yyyy-MM-01 00:00:00");
            string endDate = LastDayOfMonth(DateTime.Parse(Request["beginDate"].ToString())).ToString("yyyy-MM-dd 23:59:59");
            DataTable dt = bllHistoryRecord.GetMonthReport(beginDate, endDate).Tables[0]; ;
            return DataTableToReportJson(dt, "MonthReport");
        }

       
    }
}
