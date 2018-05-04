using LeaRun.Business;
using LeaRun.Entity;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using LeaRun.DataAccess;
using LeaRun.Repository;

namespace LeaRun.WebApp.Areas.CommonModule.Controllers
{
    /// <summary>
    /// ����������������
    /// </summary>
    public class CodeRuleController : PublicController<Base_CodeRule>
    {
        Base_CodeRuleBll base_coderulebll = new Base_CodeRuleBll();

        #region �б�
        /// <summary>
        /// ��������򡿷����б�JONS
        /// </summary>
        /// <returns></returns>
        public ActionResult ListJson()
        {
            List<Base_CodeRule> list = base_coderulebll.GetList();
            return Content(list.ToJson());
        }

        /// <summary>
        /// ��������򡿷�������JSON
        /// </summary>
        /// <param name="ViewId">���� ����ֵ</param>
        /// <returns></returns>
        public JsonResult GetEntityJson(string CodeRuleId)
        {
            Base_CodeRule entity = repositoryfactory.Repository().FindEntity(CodeRuleId);
            return Json(entity, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// ��������򡿷����б�JSON
        /// </summary>
        /// <param name="ViewId">���� ����ֵ</param>
        /// <returns></returns>
        public JsonResult GetDetailsEntityJson(string CodeRuleId)
        {
            List<Base_CodeRuleDetail> list = DataFactory.Database().FindList<Base_CodeRuleDetail>("CodeRuleId", CodeRuleId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ��
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        public override ActionResult Form()
        {
            string KeyValue = Request["KeyValue"];//����
            if (!string.IsNullOrEmpty(KeyValue))
            {
                Base_CodeRule entity = repositoryfactory.Repository().FindEntity(KeyValue);
                ViewBag.ModuleName = DataFactory.Database().FindEntity<Base_Module>(entity.ModuleId).FullName;
            }
            return View();
        }
        /// <summary>
        /// �ύ��
        /// </summary>
        /// <param name="TableName">����</param>
        /// <param name="TableDescription">��˵��</param>
        /// <param name="TableFieldJson">���ֶ�</param>
        /// <param name="KeyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitForm_CodeRule(string KeyValue, Base_CodeRule base_coderule, string CodeRuleDetailJson)
        {
            try
            {
                int IsOk = 0;
                IsOk = base_coderulebll.SubmitForm(KeyValue, base_coderule, CodeRuleDetailJson);
                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = "�����ɹ���" }.ToString());
            }
            catch (Exception ex)
            {
                return Content(new JsonMessage { Success = false, Code = "-1", Message = "����ʧ�ܣ�����" + ex.Message }.ToString());
            }
        }
        #endregion

        #region ��ϸ
        #endregion
    }
}