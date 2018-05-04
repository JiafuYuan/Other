using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;
using System.Data;

namespace BW.MMS.Web.Controllers.EfficiencyAppraisals
{
    public class EfficiencyAccountingController : Controller
    {
        private readonly ReportBLL bll = new ReportBLL();
        private List<List<DataGridColumn>> GetColumns()
        {
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { title = "部门", field = "Dept", columnAttributes = new { align = "center", width = 120, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "班组", field = "SubDept", columnAttributes = new { align = "center", width = 100, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "预算产量(T)", field = "PreProduction", columnAttributes = new { align = "center", width = 100, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "实际产量(T)", field = "RealProduction", columnAttributes = new { align = "center", width = 100, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "预算能耗", field = "" });
            //column.Add(new DataGridColumn { title = "实际能耗", field = "" });
            columns.Add(column);
            
            List<DataGridColumn> column1 = new List<DataGridColumn>();
            column.Add(new DataGridColumn { title = "风(m³)", field = "PreWind", columnAttributes = new { align = "center", width = 50 } });
            column.Add(new DataGridColumn { title = "水(m³)", field = "PreWater", columnAttributes = new { align = "center", width = 50 } });
            column.Add(new DataGridColumn { title = "电(kW‧h)", field = "PrePower", columnAttributes = new { align = "center", width = 50 } });
            //column.Add(new DataGridColumn { title = "风", field = "RealWind", columnAttributes = new { align = "center", width = 50 } });
            //column.Add(new DataGridColumn { title = "水", field = "RealWater", columnAttributes = new { align = "center", width = 50 } });
            //column.Add(new DataGridColumn { title = "电", field = "RealPower", columnAttributes = new { align = "center", width = 50 } });
            columns.Add(column1);
            return columns;
        }
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
        /// <summary>
        /// 获取对比数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetCompareRealAndPlan()
        {
            string dtdate = DateTime.Parse(Request["dtdate"].ToString()).ToString("yyyy-MM");
            DataTable dt = bll.GetExpendCompareRealAndPlan(dtdate).Tables[0];
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
        }
    }
}
