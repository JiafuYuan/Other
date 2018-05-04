using LeaRun.Utilities;
using LeaRun.Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace LeaRun.Web.Areas.CodeMaticModule.Controllers
{
    /// <summary>
    /// ģ�����ñ������
    /// </summary>
    public class Base_ModuleController : Controller
    {
        /// <summary>
        /// ģ�����ñ�ҵ������
        /// </summary>
        Base_ModuleBll base_modulebll = new Base_ModuleBll();
        /// <summary>
        /// ģ�����ñ�ʵ������
        /// </summary>
        Base_Module base_module = new Base_Module();
        /// <summary>
        /// ģ�����ñ� �б�ҳ��
        /// </summary>
        /// <returns></returns>
        public ActionResult Base_ModuleIndex()
        {
            return View();
        }
        /// <summary>
        /// ģ�����ñ� ���б�
        /// </summary>
        /// <returns></returns>
        public ActionResult Base_ModuleGrid()
        {
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            Response.AddHeader("Pragma", "No-Cache");
            string orderField = Request["pqGrid_OrderField"];                            //�����ֶ�  
            string orderType = Request["pqGrid_OrderType"];                             //��������
            string pqGrid_Sort = Request["pqGrid_Sort"];                                //Ҫ��ʾ�ֶ�
            Hashtable where = new Hashtable();
            return Content(JsonHelper.PqGridJson<Base_Module>(base_modulebllGetList(where), pqGrid_Sort));
        }
        /// <summary>
        /// ģ�����ñ� ɾ����Ϣ
        /// </summary>
        /// <returns></returns>
        public ActionResult Base_ModuleDelete()
        {
            string key = Request["key"];                                                //����
            string[] array = key.Split(',');
            return Content(base_modulebll.DeleteEntity(array).ToString());
        }
        /// <summary>
        /// ģ�����ñ� ��ҳ��
        /// </summary>
        /// <returns></returns>
        public ActionResult Base_ModuleForm()
        {
            return View();
        }
        /// <summary>
        /// ģ�����ñ��ύ����Ϣ
        /// </summary>
        /// <param name="base_module">ģ�����ñ�ʵ��</param>
        /// <returns></returns>
        public ActionResult SubmitBase_ModuleForm(Base_Module base_module)
        {
            string key = Request["key"];                                                //����
            bool IsOk = false;
            if (!string.IsNullOrEmpty(key))//�ж��Ƿ�༭
            {
                base_module.ModuleId = key;
                base_module.ModifyDate = DateTime.Now;
                base_module.ModifyUserId = SessionHelper.GetSessionUser().UserId;
                base_module.ModifyUserName = SessionHelper.GetSessionUser().UserName;
                IsOk = base_modulebll.UpdateEntity(base_module);
            }
            else
            {
                base_module.ModuleId = CommonHelper.GetGuid;
                base_module.CreateUserId = SessionHelper.GetSessionUser().UserId;
                base_module.CreateUserName = SessionHelper.GetSessionUser().UserName;
                base_module.SortCode = CommonHelper.GetInt(base_modulebll.GetMaxCode());
                IsOk = base_modulebll.AddEntity(base_module);
            }
            return Content(IsOk.ToString());
        }
        /// <summary>
        /// ģ�����ñ��ȡ���󷵻�JSON
        /// </summary>
        /// <param name="key">����</param>
        /// <returns></returns>
        public ActionResult GetBase_ModuleForm(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                base_module = base_modulebll.GetEntity(key);
                string strJson = JsonHelper.ObjectToJson(base_module);
                return Content(strJson);
            }
            return null;
        }
    }
}