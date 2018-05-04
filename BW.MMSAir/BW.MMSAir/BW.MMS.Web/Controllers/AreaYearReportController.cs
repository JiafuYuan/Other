using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Web.Filters;
using BW.MMS.Web.HtmlExtension.Easyui;

namespace BW.MMS.Web.Controllers
{
    public class AreaYearReportController : Controller
    {
        BLL.HistoryRecord bllHistoryRecord = new HistoryRecord();
        BLL.v_HistoryRecord bllVHistoryRecord=new v_HistoryRecord();
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

            column1.Add(new DataGridColumn { title = "月份", field = "RecordMonth", columnAttributes = new { align = "center", width = 120, sortable = false } });
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
        /// <summary>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetGridList()
        {
            string beginDateTemp = Request["beginDate"].Replace("年", "");
            string beginDate = beginDateTemp + "-01-01 00:00:00";
            string endDate = beginDateTemp + "-12-31 23:59:59";
            string areaName = Request["AreaName"].ToString();
            DataSet ds = bllHistoryRecord.GetAreaYearReport(beginDate, endDate, areaName);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
               
                    DataTable dt = ds.Tables[0].Clone();
                    foreach (DataColumn item in dt.Columns)
                    {
                        if (item.DataType == typeof (double))
                        {
                            item.DataType = typeof (decimal);
                        }
                        if (item.ColumnName == "RecordMonth")
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
                            if (column.ColumnName == "RecordMonth")
                            {
                                dr[column.ColumnName] = Request["beginDate"] + dr[column.ColumnName].ToString().PadLeft(2, '0') + "月";
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
            string beginDate = Request["beginDate"] + "-01-01 00:00:00";
            string endDate = Request["beginDate"] + "-12-31 23:59:59";
            string areaName = Request["AreaName"].ToString();
            DataTable dt = bllHistoryRecord.GetAreaMonthReport(beginDate, endDate,areaName).Tables[0]; ;
            return DataTableToReportJson(dt, "AreaYearReport");
        }


    }
}
