using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.BLL;
using BW.MMS.Web.Filters;
using BW.MMS.Model;
using BW.MMS.Web.Common;
using System.IO;

namespace BW.MMS.Web.Controllers
{
    public class SensorTypeManagerController : BaseController
    {
        private readonly m_SensorTypeBLL bll = new m_SensorTypeBLL();

        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
            //column.Add(new DataGridColumn { title = "ID", field = "ID", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "类型编号", field = "vc_Code", columnAttributes = new { align = "center", width = 80, sortable = true } });
            column.Add(new DataGridColumn { title = "类型名称", field = "vc_Name", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { title = "备注", field = "vc_Memo", columnAttributes = new { align = "center", width = 120, sortable = true } });
            // column.Add(new DataGridColumn { title = "状态", field = "i_Flag", columnAttributes = new { align = "center", width = 100, formatter = new { function = "formatFlag" } } });

            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }

        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            return View();
        }

        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetSensorTypeList(int page, int rows, string sort, string order)
        {
            int record = 0;
            List<m_SensorTypeEntity> list = bll.GetPagingList(Texthelper.SqlFilter(Request["name"]), page, rows, sort, order, out record);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("total", record);
            data.Add("rows", list);
            return Json(data);
        }

        [ExceptionFilter]
        public ActionResult Edit(int id = 0)
        {
            return View(bll.GetModel(id));
        }

        public JsonResult Delete(string id)
        {
            m_SensorBLL sensor = new m_SensorBLL();
            if (sensor.GetModelList(string.Format("TypeID in({0})", id)).Count > 0)
            {
                return Json(new { success = false, message = "传感器类型已使用，无法删除！" });
            }

            if (bll.DeleteList(id))
            {
                return Json(new { success = true, message = "删除成功！" });
            }
            else
            {
                return Json(new { success = false, message = "删除失败！" });
            }
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Edit(m_SensorTypeEntity entity)
        {
            if (entity.ID == 0)
            {
                List<m_SensorTypeEntity> sensors = bll.GetModelList(string.Format("vc_Code='{0}'", entity.vc_Code));
                if (sensors.Count > 0)
                {
                    return Json(new { success = false, message = "传感器类型编号已经存在！" });
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
                List<m_SensorTypeEntity> sensors = bll.GetModelList(string.Format("vc_Code='{0}' and ID<>{1}", entity.vc_Code, entity.ID));
                if (sensors.Count > 0)
                {
                    return Json(new { success = false, message = "传感器类型编号已经存在！" });
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
    }
}
