using LeaRun.Utilities;
using LeaRun.Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using LeaRun.WebApp;
using LeaRun.Entity;
using System.Data.Common;
using LeaRun.DataAccess;
using System.Data;

namespace LeaRun.WebApp.Areas.CommonModule.Controllers
{
    /// <summary>
    /// ��ͼ���ÿ�����
    /// </summary>
    public class ViewController : PublicController<Base_View>
    {
        private Base_ModuleBll base_modulebll = new Base_ModuleBll();
        private Base_ViewBll base_viewbll = new Base_ViewBll();
        private Base_ViewWhereBll base_viewwherebll = new Base_ViewWhereBll();
        /// <summary>
        /// ����ͼ���á�ģ��Ŀ¼
        /// </summary>
        /// <returns></returns>
        public ActionResult TreeJson()
        {
            List<Base_Module> list = base_modulebll.GetList();
            List<TreeJsonEntity> TreeList = new List<TreeJsonEntity>();
            foreach (Base_Module item in list)
            {
                string ModuleId = item.ModuleId;
                bool hasChildren = false;
                List<Base_Module> childnode = list.FindAll(t => t.ParentId == ModuleId);
                if (childnode.Count > 0)
                {
                    hasChildren = true;
                }
                else
                {
                    if (item.Category == "Ŀ¼")
                    {
                        continue;
                    }
                }
                if (item.Category == "ҳ��")
                    if (item.AllowView != 1)
                        continue;
                TreeJsonEntity tree = new TreeJsonEntity();
                tree.id = ModuleId;
                tree.text = item.FullName;
                tree.value = ModuleId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                tree.img = item.Icon != null ? "/Content/Images/Icon16/" + item.Icon : item.Icon;
                TreeList.Add(tree);
            }
            return Content(TreeList.TreeToJson());
        }
        /// <summary>
        /// ����ͼ���á����ر��JONS
        /// </summary>
        /// <param name="CompanyId">ģ������</param>
        /// <returns></returns>
        public ActionResult GridListJson(string ModuleId)
        {
            if (!string.IsNullOrEmpty(ModuleId))
            {
                List<Base_View> ListData = base_viewbll.GetViewList(ModuleId);
                var JsonData = new
                {
                    rows = ListData,
                };
                return Content(JsonData.ToJson());
            }
            return null;
        }
        /// <summary>
        /// ����ͼ���á���ʾ�����ֶΡ������б�JSON
        /// </summary>
        /// <param name="ModuleId">ģ������</param>
        /// <returns></returns>
        public JsonResult GetViewJson(string ModuleId)
        {
            List<Base_View> list = base_viewbll.GetViewList(ModuleId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// ����ͼ���á���ѯ�����ֶΡ������б�JSON
        /// </summary>
        /// <param name="ModuleId">ģ������</param>
        /// <returns></returns>
        public JsonResult GetViewWhereJson(string ModuleId)
        {
            List<Base_ViewWhere> list = base_viewwherebll.GetViewWhereList(ModuleId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// ����ͼ���á����ύ�¼�
        /// </summary>
        /// <param name="KeyValue">����ֵ</param>
        /// <param name="ModuleId">ģ��Id</param>
        /// <param name="ViewJson">��ͼJson</param>
        /// <param name="ViewWhereJson">��ͼ����Json</param>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult ViewSubmitForm(string KeyValue, string ModuleId, string ViewJson, string ViewWhereJson)
        {
            try
            {
                int IsOk = 0;
                IsOk = base_viewbll.SubmitForm(KeyValue, ModuleId, ViewJson, ViewWhereJson);
                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "�����ɹ���" }.ToString());
            }
            catch (Exception ex)
            {
                return Content(new JsonMessage { Success = false, Code = "-1", Message = "����ʧ�ܣ�����" + ex.Message }.ToString());
            }
        }
    }
}