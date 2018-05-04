using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;
using BW.MMS.Model;
using BW.MMS.BLL;
using System.Data;
using System.Text;

namespace BW.MMS.Web.Controllers.EfficiencyAppraisals
{
    public class ProductionDailyReportController : Controller
    {
        //
        // GET: /ProductionDailyReport/

        private readonly ReportBLL bll = new ReportBLL();


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
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "parentName", title = "部门名称", columnAttributes = new { align = "left", width = 180, sortable = false } });
            column.Add(new DataGridColumn { field = "vc_Name", title = "区队名称", columnAttributes = new { align = "center", width = 100, sortable = false } });
            column.Add(new DataGridColumn { field = "dt_date", title = "日期", columnAttributes = new { align = "center", width = 150 } });
            column.Add(new DataGridColumn { field = "wind", title = "风量(m³)", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { field = "water", title = "水量(m³)", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { field = "power", title = "电量(kW‧h)", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { field = "production", title = "产量(T)", columnAttributes = new { align = "center", width = 100 } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult getxAxis(string dtDate)
        {
            dtDate = DateTime.Parse(dtDate).ToString("yyyy-MM-dd");
            DataTable dt = bll.GetProdutionDailyReport(dtDate);
            string[] dept = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dept[i] = dt.Rows[i]["vc_name"].ToString();
            }
            return Json(dept);
        }

        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult getSeries(string dtDate)
        {
            List<float> listWind = new List<float>();
            List<float> listWater = new List<float>();
            List<float> listPower = new List<float>();
            List<float> listProduction = new List<float>();
            dtDate=DateTime.Parse(dtDate).ToString("yyyy-MM-dd");
            DataTable dt = bll.GetProdutionDailyReport(dtDate);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listWind.Add(float.Parse(dt.Rows[i]["wind"].ToString()));
                listWater.Add(float.Parse(dt.Rows[i]["water"].ToString()));
                listPower.Add(float.Parse(dt.Rows[i]["power"].ToString()));
                listProduction.Add(float.Parse(dt.Rows[i]["production"].ToString()));
            }
            List<SeriesData> seriesdata = new List<SeriesData>();
            SeriesData s1 = new SeriesData();
            s1.name = "风量";
            s1.data = listWind;
            seriesdata.Add(s1);

            SeriesData s2 = new SeriesData();
            s2.name = "水量";
            s2.data = listWater;
            seriesdata.Add(s2);

            SeriesData s3 = new SeriesData();
            s3.name = "电量";
            s3.data = listPower;
            seriesdata.Add(s3);

            SeriesData s4 = new SeriesData();
            s4.name = "产量";
            s4.data = listProduction;
            seriesdata.Add(s4);
            return Json(seriesdata);
        }

        [Serializable]
        public class SeriesData
        {
            public string name;
            public List<float> data;
        }

        /// <summary>
        /// 获取DataGrid数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetGridList()
        {
            //int record = 0;

            string dtdate = DateTime.Parse(Request["dtdate"].ToString()).ToString("yyyy-MM-dd");
            ViewData["dateView"] = dtdate;
            //ViewData["xAxis"] = getxAxis(dtdate);
            //ViewData["series"] = getSeries(dtdate);
            DataTable dt = bll.GetProdutionDailyReport(dtdate);
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
        }

    }
}