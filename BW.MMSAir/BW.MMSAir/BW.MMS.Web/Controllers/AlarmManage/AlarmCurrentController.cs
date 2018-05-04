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
using Newtonsoft.Json.Converters;

namespace BW.MMS.Web.Controllers.AlarmManage
{
    public class AlarmCurrentController : Controller
    {
        /// <summary>
        /// 实时告警业务类对象
        /// </summary>
        private readonly Alarm_CurrentBLL bll = new Alarm_CurrentBLL();
        /// <summary>
        /// 创建DataGrid列
        /// </summary>
        /// <returns></returns>
        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
            column.Add(new DataGridColumn { title = "名称", field = "vc_Code", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { title = "类型", field = "TypeName", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { title = "单位名称", field = "DeptName", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { title = "告警区域", field = "AreaName", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { title = "告警地点", field = "vc_Address", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { title = "状态", field = "vc_AlarmName", columnAttributes = new { align = "center", width = 120 } });
            column.Add(new DataGridColumn { title = "开始时间", field = "dt_BeginTime", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "累计时间", field = "CumulativeDate", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { title = "原因", field = "vc_AlarmReason", columnAttributes = new { align = "center", width = 150 } });
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
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetGridList(int page, int rows, string sort, string order)
        {
            int total = 0;
            DataTable dt = bll.GetPagingList(Request["id"], page, rows, sort, order, out total);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("total", total);
            data.Add("rows", dt);
            IsoDateTimeConverter itc = new IsoDateTimeConverter();
            itc.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data, itc));
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
        public JsonResult Edit(Alarm_CurrentEntity entity)
        {
            Alarm_CurrentEntity model = bll.GetModel(entity.ID);
            model.vc_AlarmReason = entity.vc_AlarmReason;
            if (bll.Update(model))
            {
                return Json(new { success = true, message = "添加成功！" });
            }
            else
            {
                return Json(new { success = false, message = "添加失败！" });
            }
        }
    }
}
