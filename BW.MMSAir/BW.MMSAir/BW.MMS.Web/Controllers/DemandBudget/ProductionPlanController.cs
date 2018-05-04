using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;
using System.Data;
using BW.MMS.Model;

namespace BW.MMS.Web.Controllers.DemandBudget
{
    public class ProductionPlanController :BaseController
    {
        //
        // GET: /EnergyPlan/
        m_ProductionPlanBLL bll = new m_ProductionPlanBLL();
        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            string editor = "{type:'numberbox',options:{max:9999999,precision:0}}";
            column.Add(new DataGridColumn { field = "ParentName", title = "部门", columnAttributes = new { align = "center", width = 160, sortable = true } });
            column.Add(new DataGridColumn { field = "deptID", title = "区队", columnAttributes = new { align = "center", width = 160, sortable = true, formatter = new { function = "formatDept" } } });
            column.Add(new DataGridColumn { field = "Years", title = "年份", columnAttributes = new { align = "center", width = 60, sortable = true } });
            column.Add(new DataGridColumn { field = "Jan", title = "1月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Feb", title = "2月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Mar", title = "3月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Apr", title = "4月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "May", title = "5月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Jun", title = "6月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Jul", title = "7月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Aug", title = "8月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Sep", title = "9月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Oct", title = "10月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Nov", title = "11月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Dec", title = "12月(T)", columnAttributes = new { align = "center", width = 60, MaxLenth = 4, editor = new { function = editor } } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }

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
            string dtdate = Request["dtdate"].ToString().Replace("年", "");
            DataTable dt = bll.GetList("m_ProductionPlan", dtdate).Tables[0];
            return DataTableToReportJson(dt, "ProductionPlan");
        }

        /// <summary>
        /// 获取DataGrid数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetGridList()
        {
            string dtdate = Request["dtdate"].ToString().Replace("年", "");
            DataTable dt = bll.GetList("m_ProductionPlan", dtdate).Tables[0];
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
        }
        /// <summary>
        /// 保存批量设置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult SaveGrid()
        {
            DataTable dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Request["grid"]);
            m_ProductionPlanBLL ePlan = new m_ProductionPlanBLL();
            for (int i = 0, count = dt.Rows.Count; i < count; i++)
            {
                m_ProductionPlanEntity entity = new m_ProductionPlanEntity();
                if (string.IsNullOrEmpty(dt.Rows[i]["ID"].ToString().Trim()))
                {
                    entity.ID = 0;
                }
                else
                {
                    entity.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                }
                entity.DeptID = int.Parse(dt.Rows[i]["DeptID"].ToString());
                entity.Years = int.Parse(dt.Rows[i]["Years"].ToString());
                entity.Jan = decimal.Parse(dt.Rows[i]["Jan"].ToString() != "" ? dt.Rows[i]["Jan"].ToString() : "0");
                entity.Feb = decimal.Parse(dt.Rows[i]["Feb"].ToString() != "" ? dt.Rows[i]["Feb"].ToString() : "0");
                entity.Mar = decimal.Parse(dt.Rows[i]["Mar"].ToString() != "" ? dt.Rows[i]["Mar"].ToString() : "0");
                entity.Apr = decimal.Parse(dt.Rows[i]["Apr"].ToString() != "" ? dt.Rows[i]["Apr"].ToString() : "0");
                entity.May = decimal.Parse(dt.Rows[i]["May"].ToString() != "" ? dt.Rows[i]["May"].ToString() : "0");
                entity.Jul = decimal.Parse(dt.Rows[i]["Jul"].ToString() != "" ? dt.Rows[i]["Jul"].ToString() : "0");
                entity.Jun = decimal.Parse(dt.Rows[i]["Jun"].ToString() != "" ? dt.Rows[i]["Jun"].ToString() : "0");
                entity.Aug = decimal.Parse(dt.Rows[i]["Aug"].ToString() != "" ? dt.Rows[i]["Aug"].ToString() : "0");
                entity.Sep = decimal.Parse(dt.Rows[i]["Sep"].ToString() != "" ? dt.Rows[i]["Sep"].ToString() : "0");
                entity.Oct = decimal.Parse(dt.Rows[i]["Oct"].ToString() != "" ? dt.Rows[i]["Oct"].ToString() : "0");
                entity.Nov = decimal.Parse(dt.Rows[i]["Nov"].ToString() != "" ? dt.Rows[i]["Nov"].ToString() : "0");
                entity.Dec = decimal.Parse(dt.Rows[i]["Dec"].ToString() != "" ? dt.Rows[i]["Dec"].ToString() : "0");
                if (string.IsNullOrEmpty(dt.Rows[i]["ID"].ToString().Trim()))
                {
                    bll.Add(entity);
                }
                else
                {
                    if (!bll.GetModel(entity.ID).Equals(null))
                    {
                        bll.Update(entity);
                    }
                    else
                    {
                        bll.Add(entity);
                    }
                }
            }
            return Json(new { success = true, message = "保存成功！" });
        }
    }
}
