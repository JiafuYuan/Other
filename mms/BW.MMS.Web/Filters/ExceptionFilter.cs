using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Model;

namespace BW.MMS.Web.Filters
{
    /// <summary>
    /// 导常拦截器
    /// </summary>
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        private bool _isAjax = false;

        public bool IsAjax
        {
            get { return _isAjax; }
            set { _isAjax = value; }
        }

        //发生异常时会执行这段代码
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                if (_isAjax)
                {
                    filterContext.HttpContext.Response.Clear();
                    JsonResult json = new JsonResult();
                    json.Data = filterContext.Exception.Message;
                    json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    filterContext.Result = json;
                    filterContext.HttpContext.Response.ContentType = "text/plain;charset=UTF-8";
                    filterContext.HttpContext.Response.Status = "500 Internal Server Error";
                    filterContext.HttpContext.Response.StatusCode = 500;
                    filterContext.ExceptionHandled = true;
                }
                else
                {
                    string returnUrl = filterContext.HttpContext.Request.UrlReferrer.AbsolutePath;
                    filterContext.Result = new RedirectResult("~/Home/Error?returnUrl=" + returnUrl);
                    filterContext.ExceptionHandled = true;
                }
            }
        }
    }
}