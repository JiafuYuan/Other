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
    public class YearReportController : Controller
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
            string paramYear = Request["paramYear"].Replace("年", "");
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
                    if (item.ColumnName == "RecordMonth")
                    {
                        item.DataType = typeof (string);
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
                            dr[column.ColumnName] = paramYear+"年" + dr[column.ColumnName].ToString().PadLeft(2, '0') + "月";
                        }
                    }

                    dt.Rows.Add(dr);
                }
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
            }
            return null;
        }
    }
}
