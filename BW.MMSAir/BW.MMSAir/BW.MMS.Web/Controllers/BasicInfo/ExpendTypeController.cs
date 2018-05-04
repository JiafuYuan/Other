using System.Collections.Generic;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Model;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;
using BW.MMS.Web.Common;
using System.IO;

namespace BW.MMS.Web.Controllers
{
    public class ExpendTypeController : Controller
    {
        //
        // GET: /ExpendType/

        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            return View();
        }


        private readonly m_EnergyTypeBLL bll = new m_EnergyTypeBLL();

        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
            //column.Add(new DataGridColumn { title = "编号", field = "ID", columnAttributes = new { align = "center", width = 50, sortable = true } });
            column.Add(new DataGridColumn { title = "类型名称", field = "vc_EnergyTypeName", columnAttributes = new { align = "center", width = 100, sortable = true } });
            column.Add(new DataGridColumn { title = "备注", field = "vc_Memo", columnAttributes = new { align = "center", width = 100, sortable = true } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }

        [ExceptionFilter]
        public JsonResult GetEnergyTypeList()
        {
            List<m_EnergyTypeEntity> list = bll.GetModelList(Request["name"].ToString().Trim() == "" ? "" : "vc_EnergyTypeName like '%" + Request["name"].ToString() + "%'");
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("total", list.Count);
            data.Add("rows", list);
            return Json(data);
        }

        [ExceptionFilter]
        public ActionResult Edit(int id = 0)
        {
            return View(bll.GetModel(id));
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Delete(string id)
        {
            m_SensorBLL sensor = new m_SensorBLL();
            if (sensor.GetModelList(string.Format("EnergyType in({0})", id)).Count > 0)
            {
                return Json(new { success = false, message = "能耗类型已使用，无法删除！" });
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
        public JsonResult Edit(m_EnergyTypeEntity entity)
        {
            entity.i_Flag = 0;//新增时，默认删除标志为0
            if (entity.ID == 0)
            {
                List<m_EnergyTypeEntity> energyType = bll.GetModelList(string.Format("vc_EnergyTypeName='{0}'", entity.vc_EnergyTypeName));
                if (energyType.Count > 0)
                {
                    return Json(new { success = false, message = "该能耗类型名称已经存在！" });
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
                List<m_EnergyTypeEntity> energyType = bll.GetModelList(string.Format("vc_EnergyTypeName='{0}' and ID<>{1}", entity.vc_EnergyTypeName, entity.ID));
                if (energyType.Count > 0)
                {
                    return Json(new { success = false, message = "该能耗类型名称已经存在！" });
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
