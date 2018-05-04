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
    public class ExpendCompareRealAndPlanController : BaseController
    {
        //
        // GET: /ExpendCompareRealAndPlan/
        private readonly ReportBLL bll = new ReportBLL();
        private List<List<DataGridColumn>> GetColumns()
        {
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { title = "部门", field = "Dept", columnAttributes = new { align = "center", width = 120, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "班组", field = "SubDept", columnAttributes = new { align = "center", width = 100, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "预算产量(T)", field = "PreProduction", columnAttributes = new { align = "center", width = 100, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "实际产量(T)", field = "RealProduction", columnAttributes = new { align = "center", width = 100, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "预算能耗", columnAttributes = new { align = "center", colspan = 3 } });
            column.Add(new DataGridColumn { title = "实际能耗", columnAttributes = new { align = "center", colspan = 3 } });
            columns.Add(column);

            List<DataGridColumn> column1 = new List<DataGridColumn>();
            column1.Add(new DataGridColumn { title = "风(m³)", field = "PreWind", columnAttributes = new { align = "center", width = 50 } });
            column1.Add(new DataGridColumn { title = "水(m³)", field = "PreWater", columnAttributes = new { align = "center", width = 50 } });
            column1.Add(new DataGridColumn { title = "电(kW‧h)", field = "PrePower", columnAttributes = new { align = "center", width = 50 } });
            column1.Add(new DataGridColumn { title = "风(m³)", field = "RealWind", columnAttributes = new { align = "center", width = 50 } });
            column1.Add(new DataGridColumn { title = "水(m³)", field = "RealWater", columnAttributes = new { align = "center", width = 50 } });
            column1.Add(new DataGridColumn { title = "电(kW‧h)", field = "RealPower", columnAttributes = new { align = "center", width = 50 } });
            columns.Add(column1);
            return columns;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            string clientIp = Request.UserHostAddress;
            string serverIp = Request.ServerVariables["LOCAL_ADDR"];
            ViewData["Designer"] = clientIp == serverIp;
            return View();
        }


        [HttpPost]
        public JsonResult GetReportData()
        {
            string dtdate = DateTime.Parse(Request["dtdate"]).ToString("yyyy-MM");

            DataSet ds= bll.GetExpendCompareRealAndPlan(dtdate);
            return DataTableToReportJson(ds.Tables[0], "ExpendCompareRealAndPlan");
        }

        /// <summary>
        /// 获取对比数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetCompareRealAndPlan()
        {
            string dtdate = DateTime.Parse(Request["dtdate"]).ToString("yyyy-MM");
            DataSet ds = bll.GetExpendCompareRealAndPlan(dtdate);
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
        /// highCharts视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ExceptionFilter]
        public ActionResult CompareRealAndPlanChartShow()
        {
            ViewData["dt_Date"] = DateTime.Parse(Request["dt_Date"]).ToString("yyyy-MM");
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtDate"></param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult getxAxis()
        {
            DataTable dt = bll.GetExpendCompareRealAndPlan(Request["dt_Date1"]).Tables[0];
            string[] dept = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dept[i] = dt.Rows[i]["SubDept"].ToString();
            }
            return Json(dept);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtDate"></param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult getSeries()
        {
            List<float> listRealWind = new List<float>();
            List<float> listRealWater = new List<float>();
            List<float> listRealPower = new List<float>();
            List<float> listRealProduction = new List<float>();
            List<float> listPreWind = new List<float>();
            List<float> listPreWater = new List<float>();
            List<float> listPrePower = new List<float>();
            List<float> listPreProduction = new List<float>();
            DataTable dt = bll.GetExpendCompareRealAndPlan(Request["dt_Date2"]).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listRealWind.Add(float.Parse(dt.Rows[i]["RealWind"].ToString()));
                listRealWater.Add(float.Parse(dt.Rows[i]["RealWater"].ToString()));
                listRealPower.Add(float.Parse(dt.Rows[i]["RealPower"].ToString()));
                listRealProduction.Add(float.Parse(dt.Rows[i]["RealProduction"].ToString()));
                listPreWind.Add(float.Parse(dt.Rows[i]["PreWind"].ToString()));
                listPreWater.Add(float.Parse(dt.Rows[i]["PreWater"].ToString()));
                listPrePower.Add(float.Parse(dt.Rows[i]["PrePower"].ToString()));
                listPreProduction.Add(float.Parse(dt.Rows[i]["PreProduction"].ToString()));
            }
            List<SeriesData> seriesdata = new List<SeriesData>();
            SeriesData s1 = new SeriesData();
            s1.name = "预算风量";
            s1.data = listPreWind;
            seriesdata.Add(s1);

            SeriesData s2 = new SeriesData();
            s2.name = "预算水量";
            s2.data = listPreWater;
            seriesdata.Add(s2);

            SeriesData s3 = new SeriesData();
            s3.name = "预算电量";
            s3.data = listPrePower;
            seriesdata.Add(s3);

            SeriesData s4 = new SeriesData();
            s4.name = "预算产量";
            s4.data = listPreProduction;
            seriesdata.Add(s4);

            SeriesData s5 = new SeriesData();
            s5.name = "实际风量";
            s5.data = listRealWind;
            seriesdata.Add(s5);

            SeriesData s6 = new SeriesData();
            s6.name = "实际水量";
            s6.data = listRealWater;
            seriesdata.Add(s6);

            SeriesData s7 = new SeriesData();
            s7.name = "实际电量";
            s7.data = listRealPower;
            seriesdata.Add(s7);

            SeriesData s8 = new SeriesData();
            s8.name = "实际产量";
            s8.data = listRealProduction;
            seriesdata.Add(s8);
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
