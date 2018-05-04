using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.BLL;
using BW.MMS.Web.Filters;
using BW.MMS.Model;
using BW.MMS.Web.Common;

namespace BW.MMS.Web.Controllers.BasicInfo
{
    public class PLCController : BaseController
    {
        private readonly m_PLCBLL bll = new m_PLCBLL();
       

        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "vc_name", title = "PLC名称", columnAttributes = new { align = "left", width = 180, sortable = true } });
            column.Add(new DataGridColumn { field = "vc_IP", title = "IP地址", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { field = "vc_remark", title = "备注", columnAttributes = new { align = "center", width = 100 } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }
        /// <summary>
        /// 首页视图
        /// </summary>
        /// <returns></returns>
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
            m_PLCEntity entity = bll.GetModel(id);
            return View(entity);
        }

        /// <summary>
        /// 获取PLC类型DataGrid数据
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
            string PLCName = Request["txtName"];
            string PLCIP = Request["txtIP"];
            string strWhere = string.Empty;
            if (!string.IsNullOrEmpty(PLCName))
            {
                strWhere += " and vc_name like '%" + Texthelper.SqlFilter(PLCName.Trim()) + "%'";
            }
            if (!string.IsNullOrEmpty(PLCIP))
            {
                strWhere += " and vc_IP like '%" + Texthelper.SqlFilter(PLCIP.Trim()) + "%'";
            }
            int records = 0;
            List<m_PLCEntity> list = bll.GetPagingList(strWhere, page, rows, sort, order, out records);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("total", records);
            data.Add("rows", list);
            return Json(data);
        }
       
        /// <summary>
        /// 编辑PLC
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Edit(m_PLCEntity entity)
        {
           
            if (entity.id == 0)
            {
                if (bll.GetModelList(string.Format("vc_Name='{0}' ", entity.vc_name)).Count > 0)
                {
                    return Json(new { success = false, message = "PLC名称已存在！" });
                }
                if (bll.GetModelList(string.Format("vc_IP='{0}' ", entity.vc_IP)).Count > 0)
                {
                    return Json(new { success = false, message = "IP已存在！" });
                }
                if (bll.Add(entity) > 0)
                {
                    return Json(new { success = true, message = "添加成功！" });
                }
                else
                {
                    return Json(new { success = false, message = "添加失败！" });
                }
            }
            else
            {
                if (bll.GetModelList(string.Format("vc_Name='{0}' AND ID<>{1} and i_flag<>1 ", entity.vc_name, entity.id)).Count > 0)
                {
                    return Json(new { success = false, message = "PLC名称已存在！" });
                }
                if (bll.GetModelList(string.Format("vc_IP='{0}' AND ID<>{1} and i_flag<>1 ", entity.vc_name, entity.id)).Count > 0)
                {
                    return Json(new { success = false, message = "IP已存在！" });
                }
                if (bll.Update(entity))
                {
                    return Json(new { success = true, message = "修改成功！" });
                }
                else
                {
                    return Json(new { success = false, message = "修改失败！" });
                }
            }
        }
        /// <summary>
        /// 删除PLC
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Delete(string id)
        {
            m_SensorBLL sensorbll=new m_SensorBLL();
            if (sensorbll.GetModelList(string.Format("PLCAdress='{0}' and i_Flag <>1 ", id)).Count > 0)
            {
                return Json(new { success = false, message = "该PLC正在使用！" });
            }
            if (bll.Delete(Convert.ToInt32(id)))
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
