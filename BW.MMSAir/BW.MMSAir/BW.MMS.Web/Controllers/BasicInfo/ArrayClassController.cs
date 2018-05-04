using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.BLL;
using BW.MMS.Web.Filters;
using BW.MMS.Model;
using System.Text;
using System.Data;

namespace BW.MMS.Web.Controllers.BasicInfo
{
    public class ArrayClassController : BaseController
    {
        private readonly m_ArrayClassBLL bll = new m_ArrayClassBLL();
        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            List<DataGridColumn> column1 = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true, rowspan = 2 } });
            column.Add(new DataGridColumn { title = "日期", field = "dt_Date", columnAttributes = new { align = "center", width = 120, rowspan = 2 } });
            m_ClassTypeBLL classtypebll = new m_ClassTypeBLL();
            m_ClassBLL classbll = new m_ClassBLL();
            List<m_ClassTypeEntity> list = classtypebll.GetModelList("");
            for (int i = 0; i < list.Count; i++)
            {
                List<m_ClassEntity> classList = classbll.GetModelList(string.Format("classTypeID={0}", list[i].ID));
                column.Add(new DataGridColumn { title = list[i].nvc_name, columnAttributes = new { align = "center", colspan = classList.Count.ToString() } });
                for (int j = 0; j < classList.Count; j++)
                {
                    column1.Add(new DataGridColumn { title = classList[j].nvc_name, field = classList[j].ID.ToString() + "_DeptName", columnAttributes = new { align = "center", width = 120 } });
                }
            }
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            columns.Add(column1);
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
        /// 获取排班数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetArrayList()
        {
            DateTime startDate = Convert.ToDateTime(Request["startDate"]);
            DateTime endDate = Convert.ToDateTime(Request["endDate"]);
            DataTable dt = bll.GetArrayList(startDate, endDate);
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
        }
        private List<List<DataGridColumn>> GetArrayClassColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            string editor = "{type:'combotree',options:{url:'" + Url.Action("GetDeptTree", "Dept") + "',multiple:true}}";
            column.Add(new DataGridColumn { title = "班次类型", field = "classTypeName", columnAttributes = new { align = "center", width = 120 } });
            column.Add(new DataGridColumn { title = "班次名称", field = "ClassName", columnAttributes = new { align = "center", width = 120 } });
            column.Add(new DataGridColumn { title = "单位名称", field = "DeptID", columnAttributes = new { align = "center", width = 180, formatter = new { function = "formatDept" }, editor = new { function = editor } } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }
        /// <summary>
        /// 批量设置视图
        /// </summary>
        /// <returns></returns>
        [ExceptionFilter]
        public ActionResult Add()
        {
            ViewData["GridColumn"] = GetArrayClassColumns();
            return View();
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetArrayClass()
        {
            DataTable dt = bll.GetArrayClass();
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
        }
        /// <summary>
        /// 保存批量设置
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult SaveArrayClass()
        {
            DateTime startDate = DateTime.Parse(Request["startDate"]);
            DateTime endDate = DateTime.Parse(Request["endDate"]);
            bll.Delete(startDate, endDate);
            DataTable dt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Request["grid"]);
            m_DeptBLL dept = new m_DeptBLL();
            for (int i = 0, count = dt.Rows.Count; i < count; i++)
            {
                List<m_DeptEntity> depts = dept.GetModelList(string.Format("i_Flag=0 and ID not in (select ParentDeptID from m_Dept where i_Flag=0) and ID in({0})", dt.Rows[i]["DeptID"].ToString()));
                foreach (m_DeptEntity item in depts)
                {
                    for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
                    {
                        m_ArrayClassEntity entity = new m_ArrayClassEntity();
                        entity.dt_Date = d;
                        entity.DeptID = item.ID;
                        entity.ClassID = Convert.ToInt32(dt.Rows[i]["ClassID"]);
                        bll.Add(entity);
                    }
                }
            }

            return Json(new { success = true, message = "保存成功！" });
        }
        /// <summary>
        /// 修改视图
        /// </summary>
        /// <returns></returns>
        [ExceptionFilter]
        public ActionResult Edit()
        {
            ViewData["GridColumn"] = GetArrayClassColumns();
            ViewData["dt_Date"] = Convert.ToDateTime(Request["dt_Date"]).ToString("yyyy-MM-dd");
            return View();
        }
        /// <summary>
        /// 获取排班编辑数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetArrayClassEdit()
        {
            DateTime startDate = Convert.ToDateTime(Request["startDate"]);
            DateTime endDate = Convert.ToDateTime(Request["endDate"]);
            DataTable dt = bll.GetArrayList(startDate, endDate);
            DataTable data = bll.GetArrayClass();
            for (int i = 0, length = data.Rows.Count; i < length; i++)
            {
                string classID = data.Rows[i]["ClassID"].ToString();
                data.Rows[i]["DeptID"] = dt.Rows[0][classID + "_DeptID"].ToString();
                data.Rows[i]["DeptName"] = dt.Rows[0][classID + "_DeptName"].ToString(); ;
            }
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// 根据班次ID获取排班
        /// </summary>
        /// <param name="id">班次编号</param>
        /// <returns></returns>
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetArrayClasses(string id)
        {
            List<m_ArrayClassEntity> list = bll.GetModelList(string.Format("ClassID in({0})", id));
            return Json(list.Count == 0);
        }
    }
}
