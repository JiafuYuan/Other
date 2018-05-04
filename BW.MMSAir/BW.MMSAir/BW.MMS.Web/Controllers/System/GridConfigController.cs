using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Web.Filters;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.BLL;
using BW.MMS.Model;
using BW.MMS.Web.Common;
using System.Data;

namespace BW.MMS.Web.Controllers
{
    public class GridConfigController : BaseController
    {
        private readonly GridConfigBLL bll = new GridConfigBLL();
        private readonly GridColumnConfigBLL column = new GridColumnConfigBLL();
        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
            column.Add(new DataGridColumn { title = "Grid标识", field = "GridKeyName", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "显示名称", field = "ChineseName", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "数据源类型", field = "Type", columnAttributes = new { align = "center", width = 120, formatter = new { function = "formatType" } } });
            column.Add(new DataGridColumn { title = "数据源名称", field = "TVName", columnAttributes = new { align = "center", width = 180, } });
            column.Add(new DataGridColumn { title = "所属子系统", field = "ApplicationCode", columnAttributes = new { align = "center", width = 150 } });
            column.Add(new DataGridColumn { title = "是否显示选择列", field = "ischk", columnAttributes = new { align = "center", width = 120, formatter = new { function = "formatter" } } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }
        [ExceptionFilter]
        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            return View();
        }
        /// <summary>
        /// 编辑视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ExceptionFilter]
        public ActionResult Edit(int id = 0)
        {
            return View(bll.GetModel(id));
        }
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
        public JsonResult GetGridList(int page, int rows, string sort, string order)
        {
            int record = 0;
            List<GridConfigEntity> list = bll.GetPagingList(Texthelper.SqlFilter(Request["name"]), page, rows, sort, order, out record);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("total", record);
            data.Add("rows", list);
            return Json(data);
        }
        /// <summary>
        /// 获取系统表与视图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetTableViews()
        {
            DataTable dt = bll.GetTableViews(Request["type"]);
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Edit(GridConfigEntity entity)
        {
            if (entity.ID == 0)
            {
                List<GridConfigEntity> grid = bll.GetModelList(string.Format("GridKeyName='{0}'", entity.GridKeyName));
                if (grid.Count > 0)
                {
                    return Json(new { success = false, message = "Grid标识已经存在！" });
                }
                if (bll.Add(entity) > 0)
                {
                    return Json(new { success = true, message = "添加成功！" });
                }
                else
                {
                    return Json(new { success = true, message = "添加失败！" });
                }
            }
            else
            {
                List<GridConfigEntity> grid = bll.GetModelList(string.Format("GridKeyName='{0}' and ID<>{1}", entity.GridKeyName, entity.ID));
                if (grid.Count > 0)
                {
                    return Json(new { success = false, message = "Grid标识已经存在！" });
                }
                GridConfigEntity model = bll.GetModel(entity.ID);
                if (model.TVName != entity.TVName)
                {
                    column.DeleteByGridID(model.ID.ToString());
                }
                if (bll.Update(entity))
                {
                    return Json(new { success = true, message = "修改成功！" });
                }
                else
                {
                    return Json(new { success = true, message = "修改失败！" });
                }
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Delete(string id)
        {
            if (bll.DeleteList(id))
            {
                column.DeleteByGridID(id);
                return Json(new { success = true, message = "删除成功！" });
            }
            else
            {
                return Json(new { success = false, message = "删除失败！" });
            }
        }
        /// <summary>
        /// 配置列视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Column(int id = 0)
        {
            ViewData["GridID"] = id;
            ViewData["ParentID"] = Request["ParentID"] == null ? 0 : int.Parse(Request["ParentID"]);
            return View();
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetColumn(int id = 0)
        {
            int parentID = Convert.ToInt32(Request["ParentID"]);
            GridConfigEntity entity = bll.GetModel(id);
            DataTable dt = bll.GetTVField(id, parentID, entity.TVName, entity.Type);
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetColumnList(string sort, string order)
        {
            return Json(column.GetModelList(string.Format("gridconfigID={0} and ParentID=0 order by {1} {2}", Request["GridID"], sort, order)));
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GridColumnEdit()
        {
            string parentID = Request["parentID"] == null ? "0" : Request["parentID"];
            List<GridColumnConfigEntity> columns = column.GetModelList(string.Format("gridconfigID={0} and ParentID={1}", Request["gridID"], parentID));
            List<GridColumnConfigEntity> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GridColumnConfigEntity>>(Request["columns"]);
            foreach (GridColumnConfigEntity entity in columns)
            {
                GridColumnConfigEntity model = list.FirstOrDefault(m => m.ID == entity.ID);
                if (model == null)
                {
                    column.Delete(entity.ID);
                    column.DeleteByParentID(entity.ID);
                }
            }
            foreach (GridColumnConfigEntity model in list)
            {
                if (model.ID == 0)
                {
                    column.Add(model);
                }
                else
                {
                    column.Update(model);
                }
            }
            return Json(new { success = true, message = "保存成功！" });
        }

        [ExceptionFilter]
        public ActionResult PreviewGrid(int id = 0)
        {

            ViewData["GridColumn"] = GridHelper.GetGridColumns(bll.GetModel(id).GridKeyName);
            return View();
        }
    }
}
