using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Web.Filters;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Model;
using BW.MMS.Web.Common;

namespace BW.MMS.Web.Controllers.AlarmManage
{
    public class AlarmTypeController : Controller
    {
        /// <summary>
        /// 告警类型业务类对象
        /// </summary>
        private readonly m_AlarmTypeBLL bll = new m_AlarmTypeBLL();
        /// <summary>
        /// 创建DataGrid列
        /// </summary>
        /// <returns></returns>
        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
            column.Add(new DataGridColumn { title = "告警编号", field = "AlarmTypeID", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { title = "告警名称", field = "vc_AlarmName", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "告警描述", field = "vc_Description", columnAttributes = new { align = "center", width = 120 } });
            column.Add(new DataGridColumn { title = "备注", field = "vc_Memo", columnAttributes = new { align = "center", width = 150 } });
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
            List<m_AlarmTypeEntity> list = bll.GetPagingList(Texthelper.SqlFilter(Request["name"]), page, rows, sort, order, out record);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("total", record);
            data.Add("rows", list);
            return Json(data);
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetAlarmTypeList()
        {
            return Json(bll.GetModelList("i_Flag=0"));
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
        /// 编辑数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Edit(m_AlarmTypeEntity entity)
        {
            if (entity.ID == 0)
            {
                List<m_AlarmTypeEntity> list = bll.GetModelList(string.Format("AlarmTypeID='{0}' and i_Flag=0", entity.AlarmTypeID));
                if (list.Count > 0)
                {
                    return Json(new { success = false, message = "告警类型编号已经存在！" });
                }
                list = bll.GetModelList(string.Format("vc_AlarmName='{0}' and i_Flag=0", entity.vc_AlarmName));
                if (list.Count > 0)
                {
                    return Json(new { success = false, message = "告警类型名称已经存在！" });
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
                List<m_AlarmTypeEntity> list = bll.GetModelList(string.Format("ID<>{0} and AlarmTypeID='{1}' and i_Flag=0", entity.ID, entity.AlarmTypeID));
                if (list.Count > 0)
                {
                    return Json(new { success = false, message = "告警类型编号已经存在！" });
                }
                list = bll.GetModelList(string.Format("ID<>{0} and vc_AlarmName='{1}' and i_Flag=0", entity.ID, entity.vc_AlarmName));
                if (list.Count > 0)
                {
                    return Json(new { success = false, message = "告警类型名称已经存在！" });
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
                return Json(new { success = true, message = "删除成功！" });
            }
            else
            {
                return Json(new { success = false, message = "删除失败！" });
            }
        }
    }
}
