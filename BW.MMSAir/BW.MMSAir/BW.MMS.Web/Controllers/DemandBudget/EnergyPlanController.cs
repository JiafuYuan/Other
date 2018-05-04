using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Web.Filters;
using BW.MMS.Web.Common;
using BW.MMS.Model;
using BW.MMS.BLL;
using System.Data;
using BW.MMS.Web.HtmlExtension.Easyui;

namespace BW.MMS.Web.Controllers.DemandBudget
{
    public class EnergyPlanController : BaseController
    {
        //
        // GET: /EnergyPlan/
        m_EnergyPlanBLL bll = new m_EnergyPlanBLL();
        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            string editor = "{type:'numberbox',options:{max:9999999,precision:0}}";
            column.Add(new DataGridColumn { field = "ParentName", title = "单位名称", columnAttributes = new { align = "center", width = 150, sortable = true } });
            column.Add(new DataGridColumn { field = "DeptID", title = "区队", columnAttributes = new { align = "center", width = 120, sortable = true, formatter = new { function = "formatDept" } } });
            column.Add(new DataGridColumn { field = "type", title = "类型", columnAttributes = new { align = "center", width = 100, formatter = new { function = "formatType" } } });
            column.Add(new DataGridColumn { field = "Years", title = "年份", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { field = "Jan", title = "1月", columnAttributes = new { align = "center", width = 50,MaxLenth=4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Feb", title = "2月", columnAttributes = new { align = "center", width = 50, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Mar", title = "3月", columnAttributes = new { align = "center", width = 50,MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Apr", title = "4月", columnAttributes = new { align = "center", width = 50, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "May", title = "5月", columnAttributes = new { align = "center", width = 50, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Jun", title = "6月", columnAttributes = new { align = "center", width = 50, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Jul", title = "7月", columnAttributes = new { align = "center", width = 50, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Aug", title = "8月", columnAttributes = new { align = "center", width = 50, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Sep", title = "9月", columnAttributes = new { align = "center", width = 50, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Oct", title = "10月", columnAttributes = new { align = "center", width = 50, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Nov", title = "11月", columnAttributes = new { align = "center", width = 50, MaxLenth = 4, editor = new { function = editor } } });
            column.Add(new DataGridColumn { field = "Dec", title = "12月", columnAttributes = new { align = "center", width = 50, MaxLenth = 4, editor = new { function = editor } } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }

        [ExceptionFilter]
        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            string clientIp = Request.UserHostAddress;
            string serverIp = Request.ServerVariables["LOCAL_ADDR"];
            ViewData["Designer"] = clientIp == serverIp;
            return View();
        }
       
        
        /// <summary>
        /// 获取DataGrid数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetGridList()
        {
            string dtdate = Request["dtdate"].ToString().Replace("年","");
            m_ProductionPlanBLL pBll = new m_ProductionPlanBLL();
            DataTable dt = pBll.GetList("m_EnergyPlan", dtdate).Tables[0];
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
        }

        /// <summary>
        /// 报表模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetReportData()
        {
            string dtdate = Request["dtdate"].ToString().Replace("年", "");
            m_ProductionPlanBLL pBll = new m_ProductionPlanBLL();
            DataTable dt = pBll.GetList("m_EnergyPlan", dtdate).Tables[0];
            return DataTableToReportJson(dt, "EnergyPlan");
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
            m_EnergyPlanBLL ePlan = new m_EnergyPlanBLL();
            for (int i = 0, count = dt.Rows.Count; i < count; i++)
            {

                m_EnergyPlanEntity entity = new m_EnergyPlanEntity();
                //if (string.IsNullOrEmpty( dt.Rows[i]["ID"].ToString().Trim()))
                //{
                //    entity.ID = 0;
                //}
                //else
                //{
                //    entity.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                //}
                entity.DeptID = int.Parse(dt.Rows[i]["DeptID"].ToString());
                entity.type = int.Parse(dt.Rows[i]["type"].ToString());
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
                    entity.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                    if (bll.Exists(entity.ID))
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
