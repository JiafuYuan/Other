using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Web.Filters;
using BW.MMS.Model;
using BW.MMS.BLL;
using BW.MMS.Web.Common;

namespace BW.MMS.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SessionOutTime()
        {
            return View();
        }

        public ActionResult LoginOut()
        {
            Session["UserInfo"] = null;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Login(string name, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Json(new { success = false, message = "用户名不能为空！" });
            }
            if (string.IsNullOrEmpty(password))
            {
                return Json(new { success = false, message = "密码名不能为空！" });
            }
            sys_UserBLL bll = new sys_UserBLL();
            List<sys_UserEntity> users = bll.GetModelList(string.Format("vc_UserName='{0}'", name));
            if (users == null || users.Count == 0)
            {
                return Json(new { success = false, message = "用户名不存在！" });
            }
            if (!Texthelper.VerifyMd5Hash(password, users[0].vc_Password))
            {
                return Json(new { success = false, message = "密码错误！" });
            }
            if (users[0].i_Flag == 1)
            {
                return Json(new { success = false, message = "用户已被删除！" });
            }
            if (users[0].i_Flag == 2)
            {
                return Json(new { success = false, message = "用户已被停用！" });
            }
            Session["UserInfo"] = users[0];
            return Json(new { success = true, message = "登陆成功！" }); ;
        }
    }
}
