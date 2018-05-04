using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Web.Filters;
using BW.MMS.Model;
using BW.MMS.BLL;
using BW.MMS.Web.HtmlExtension.Easyui;
using System.Text;
using System.Data;
using BW.MMS.Web.Common;

namespace BW.MMS.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly sys_ModuleBLL bll = new sys_ModuleBLL();
        public ActionResult Index()
        {
            ViewBag.RealName = (Session["UserInfo"] as sys_UserEntity).vc_RealName;
            return View();
        }

        public ActionResult AdvancedSearch()
        {
            return View();
        }

        public ActionResult ComplexSearch()
        {
            return View();
        }

        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetIcons()
        {
            List<string> icons = new List<string>();
            System.Text.StringBuilder sb = new StringBuilder();
            if (System.IO.Directory.Exists(Server.MapPath("~/Content/icons/")))
            {
                System.IO.DirectoryInfo dic = new System.IO.DirectoryInfo(Server.MapPath("~/Content/icons/"));

                foreach (System.IO.FileSystemInfo fsi in dic.GetFileSystemInfos())
                {
                    if (fsi is System.IO.FileInfo)
                    {
                        string name = fsi.Name.Remove(fsi.Name.LastIndexOf('.'));
                        icons.Add("icon-" + name);
                    }
                }
            }
            return Json(icons);
        }

        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetMenu()
        {
            JsonResult json = new JsonResult();
            string where = string.Format("ID IN(SELECT ModuleID FROM sys_Authority WHERE UserID={0})", CurrentUser.ID);
            if (CurrentUser.vc_UserName.Equals("admin"))
            {
                where = string.Empty;
            }
            List<sys_Module> list = bll.GetModelList(where);
            List<sys_Module> Nodes = list.FindAll(delegate(sys_Module fun) { return fun.ParentID == 0; });
            json.Data = GeneraTreeMenu(list, Nodes, new List<sys_AuthorityEntity>());
            return json;
        }

        public JsonResult GetAuthority(int id = 0)
        {
            JsonResult json = new JsonResult();
            List<sys_Module> list = bll.GetModelList(string.Empty);
            List<sys_Module> Nodes = list.FindAll(delegate(sys_Module fun) { return fun.ParentID == 0; });
            sys_AuthorityBLL auth = new sys_AuthorityBLL();
            List<sys_AuthorityEntity> authority = auth.GetModelList(string.Format("UserID={0}", id));
            json.Data = GeneraTreeMenu(list, Nodes, authority);
            return json;
        }

        /// <summary>
        /// 递归生成树菜单
        /// </summary>
        /// <param name="list">模块集合</param>
        /// <param name="Menus">父级菜单</param>
        /// <returns>树结构菜单</returns>
        private List<TreeNode> GeneraTreeMenu(List<sys_Module> list, List<sys_Module> Menus, List<sys_AuthorityEntity> authority)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (sys_Module item in Menus)
            {
                TreeNode node = new TreeNode();
                node.id = item.ID.ToString();
                node.text = item.vc_ModuleName;
                node.iconCls = "icon-" + item.vc_Icon;
                if (item.ParentID != 0 && authority.FindAll(delegate(sys_AuthorityEntity fun) { return fun.ModuleID == item.ID; }).Count > 0)
                {
                    node.@checked = true;
                }
                List<sys_Module> ChildMenu = list.FindAll(delegate(sys_Module fun) { return fun.ParentID == item.ID; });
                if (ChildMenu.Count > 0)
                {
                    node.state = "closed";
                    node.children = GeneraTreeMenu(list, ChildMenu, authority);
                }
                else
                {
                    node.attributes = new { url = item.vc_URL };
                }
                nodes.Add(node);
            }
            return nodes;
        }

        public ActionResult AcReportPrintView()
        {
            ViewData["url"] = Url.Encode(Request["url"]);
            return View();
        }
    }
}
