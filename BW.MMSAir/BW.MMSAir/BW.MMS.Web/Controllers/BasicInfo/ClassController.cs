using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;
using BW.MMS.Model;
using BW.MMS.Web.Common;
using System.Data;

namespace BW.MMS.Web.Controllers.BasicInfo
{
    public class ClassController : BaseController
    {
        private readonly m_ClassTypeBLL type = new m_ClassTypeBLL();
        private readonly m_ClassBLL bll = new m_ClassBLL();

        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
            column.Add(new DataGridColumn { title = "类型名称", field = "nvc_name", columnAttributes = new { align = "center", width = 150, sortable = true } });
            column.Add(new DataGridColumn { title = "简称", field = "nvc_shortname", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { title = "表示形式", field = "nvc_descripe", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { title = "描述", field = "nvc_remark", columnAttributes = new { align = "center", width = 200 } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
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
        /// 班次类型编辑视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ExceptionFilter]
        public ActionResult Edit(int id = 0)
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
            column.Add(new DataGridColumn { field = "nvc_name", title = "类型名称", columnAttributes = new { align = "center", width = 80 } });
            column.Add(new DataGridColumn { field = "nvc_shortname", title = "简称", columnAttributes = new { align = "center", width = 60 } });
            column.Add(new DataGridColumn { field = "d_start", title = "开始时间", columnAttributes = new { align = "center", width = 80 } });
            column.Add(new DataGridColumn { field = "d_End", title = "结束时间", columnAttributes = new { align = "center", width = 80 } });
            column.Add(new DataGridColumn { field = "nvc_descripe", title = "表示形式", columnAttributes = new { align = "center", width = 80 } });
            column.Add(new DataGridColumn { field = "nvc_remark", title = "备注", columnAttributes = new { align = "center", width = 100 } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            ViewData["GridColumn"] = columns;
            m_ClassTypeEntity model = type.GetModel(id);
            if (model == null)
            {
                model = new m_ClassTypeEntity();
            }
            return View(model);
        }
        /// <summary>
        /// 班次编辑视图
        /// </summary>
        /// <returns></returns>
        [ExceptionFilter]
        public ActionResult ClassEdit()
        {
            return View();
        }
        /// <summary>
        /// 编辑班次类型与班次
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Edit(m_ClassTypeEntity entity)
        {
            List<m_ClassEntity> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<m_ClassEntity>>(Request["ClassData"]);
            if (entity.ID > 0)
            {
                DataTable mydt = type.CheckClassTypeByName(entity.ID, entity.nvc_name);
                if (mydt.Rows.Count > 0)
                {
                    return Json(new { success = false, message = "此班次类型已经存在！" });
                }
                type.Update(entity);
                string id = string.Empty;
                foreach (m_ClassEntity item in list)
                {
                    if (item.ID == 0)
                    {
                        id += "," + bll.Add(item).ToString();
                    }
                    else
                    {
                        bll.Update(item);
                        id += "," + item.ID.ToString();
                    }
                }
                string where = string.Format("classTypeID={0} AND ID NOT IN({1})", entity.ID, id.Substring(1));
                bll.Delete(where);
            }
            else
            {
                DataTable mydt = type.CheckClassTypeByName(entity.nvc_name);
                if (mydt.Rows.Count > 0)
                {
                    return Json(new { success = false, message = "此班次类型已经存在！" });
                }
                int id = type.Add(entity);
                foreach (m_ClassEntity item in list)
                {
                    item.classTypeID = id;
                    bll.Add(item);
                }
            }
            return Json(new { success = true, message = "保存成功！" });
        }
        /// <summary>
        /// 删除班次类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult Delete(string id)
        {
            m_ArrayClassBLL arrayclass = new m_ArrayClassBLL();
            if (arrayclass.GetModelList(string.Format("ClassID in(select ID from m_Class where classTypeID={0})", id)).Count > 0)
            {
                return Json(new { success = false, message = "已经排班，无法删除！" });
            }
            type.DeleteList(id);
            type.DeleteClassList(id);
            return Json(new { success = true, message = "删除成功！" });
        }
        /// <summary>
        /// 获取班次类型DataGrid数据
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
            string typeName = Request["ClassTypeName"];
            string strWhere = string.Empty;
            if (!string.IsNullOrEmpty(typeName))
            {
                strWhere += " and nvc_name like '%" + Texthelper.SqlFilter(typeName.Trim()) + "%'";
            }
            int records = 0;
            List<m_ClassTypeEntity> list = type.GetPagingList(strWhere, page, rows, sort, order, out records);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("total", records);
            data.Add("rows", list);
            return Json(data);
        }
        /// <summary>
        /// 获取班次DataGrid数据
        /// </summary>
        /// <param name="sort">排序字段</param>
        /// <param name="order">排序方式(DESC/ASC)</param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetClassGridList(string sort, string order)
        {
            string where = string.Format("classTypeID={0} order by {1} {2}", Request["ClassTypeId"], sort, order);
            List<m_ClassEntity> list = bll.GetModelList(where);
            return Json(list);
        }
        /// <summary>
        /// 获取班次类型列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetClassTyeList()
        {
            return Json(type.GetModelList(""));
        }
        /// <summary>
        /// 获取班次列表
        /// </summary>
        /// <param name="id">班次类型ID</param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetClassList(int id = 0)
        {
            return Json(bll.GetModelList(string.Format("classTypeID={0}", id)));
        }
    }
}
