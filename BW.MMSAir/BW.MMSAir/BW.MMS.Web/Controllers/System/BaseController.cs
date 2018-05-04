using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Model;
using System.Data;
using BW.MMS.Web.Common;

namespace BW.MMS.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        public sys_UserEntity CurrentUser
        {
            get { return Session["UserInfo"] as sys_UserEntity; }
        }

        public ActionResult Error(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //身份验证
            if (CurrentUser == null)
            {
                string request = System.Web.HttpContext.Current.Request.Headers.Get("X-Requested-With");

                if (string.Compare(request, "XMLHttpRequest", true) == 0)
                {
                    filterContext.Result = new JsonResult { Data = "登录超时,请刷新页面！" };
                    filterContext.HttpContext.Response.ContentType = "text/plain;charset=UTF-8";
                    filterContext.HttpContext.Response.Status = "403 Internal Server Error";
                    filterContext.HttpContext.Response.StatusCode = 403;
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Login/SessionOutTime");
                }
            }
        }

        public JsonResult DataTableToReportJson(DataTable dt, string tableName)
        {
            List<object> columns = new List<object>();
            foreach (DataColumn column in dt.Columns)
            {
                string t = "string";
                int length = 0;
                if (column.DataType == typeof(string))
                {
                    length = 500;
                }
                if (column.DataType == typeof(int))
                {
                    t = "integer";
                }
                if (column.DataType == typeof(double))
                {
                    t = "float";
                }
                if (column.DataType == typeof(decimal))
                {
                    t = "float";
                }
                if (column.DataType == typeof(DateTime))
                {
                    t = "datetime";
                }
                columns.Add(new { name = column.ColumnName, type = t, length = column.MaxLength == -1 ? length : column.MaxLength });
            }
            List<object> records = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                string record = string.Empty;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        record += ",";
                    }
                    record += row[dt.Columns[i].ColumnName];
                }
                records.Add(new { values = record });
            }
            var data = new { name = tableName, titles = columns, records = records };
            return Json(data);
        }

        [HttpPost]
        public JsonResult ExistsReport()
        {
            string path = Request["path"];
            return Json(System.IO.File.Exists(Server.MapPath(path)));
        }

        public string mTempAcrFullFileName = string.Empty;

        public void OnDeleteTempTimer(Object sender, System.Timers.ElapsedEventArgs e)
        {
            if (System.IO.File.Exists(mTempAcrFullFileName))
            {
                System.IO.File.Delete(mTempAcrFullFileName);
            }
        }
    }
}
