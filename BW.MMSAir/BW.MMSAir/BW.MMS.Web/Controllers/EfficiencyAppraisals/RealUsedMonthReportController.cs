using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Model;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;
using BW.MMS.Web.Common;
using System.IO;
using System.Data;
using System.ComponentModel;

namespace BW.MMS.Web.Controllers.EfficiencyAppraisals
{
    public class RealUsedMonthReportController : Controller
    {
        //
        // GET: /RealUsedMonthReport/

        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            return View();
        }


        //private readonly sys_UserBLL bll = new sys_UserBLL();
        private readonly BW.MMS.BLL.rpt_Real_Used_Month_ReportBLL bll = new rpt_Real_Used_Month_ReportBLL();

        private List<List<DataGridColumn>> GetColumns()
        {
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            List<DataGridColumn> column = new List<DataGridColumn>();
            //column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "日期", field = "day", columnAttributes = new { align = "center", width = 50, sortable = true, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "区队", field = "dept", columnAttributes = new { align = "center", width = 170, sortable = true, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "班组", field = "subdept", columnAttributes = new { align = "center", width = 170, sortable = true, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "产量(T)", field = "production", columnAttributes = new { align = "center", width = 100, sortable = true, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "能耗累计", field = "", columnAttributes = new { align = "center", width = 100, sortable = true, colspan = 3 } });
            column.Add(new DataGridColumn { title = "单产能耗", field = "", columnAttributes = new { align = "center", width = 100, sortable = true, colspan = 3 } });
            columns.Add(column);


            List<DataGridColumn> column1 = new List<DataGridColumn>();
            column1.Add(new DataGridColumn { title = "风(m³)", field = "wind", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column1.Add(new DataGridColumn { title = "水(m³)", field = "water", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column1.Add(new DataGridColumn { title = "电(kW‧h)", field = "power", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column1.Add(new DataGridColumn { title = "风(m³)", field = "wind_per", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column1.Add(new DataGridColumn { title = "水(m³)", field = "water_per", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column1.Add(new DataGridColumn { title = "电(kW‧h)", field = "power_per", columnAttributes = new { align = "center", width = 100, sortable = true } });
            columns.Add(column1);
            return columns;
        }
        ///// <summary>
        ///// 编辑视图
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[ExceptionFilter]
        //public ActionResult Edit(int id = 0)
        //{
        //    return View(bll.GetModel(id));
        //}
        /// <summary>
        /// 获取DataGrid数据
        /// </summary>
        /// <param name="page">起始页</param>
        /// <param name="rows">每页条数</param>
        /// <param name="sort">排序字段</param>
        /// <param name="order">排序方式(DESC/ASC)</param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult  GetGridList()
        {
            string date=DateTime.Now.ToString("yyyy-MM-dd");
            if (Request["date"] != null && Request["date"].ToString().Trim() != "")
            {
                date = Request["date"].ToString();
            }
            DataSet ds = bll.getTab(date);
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(ds.Tables[0]));
        }
    }
}
