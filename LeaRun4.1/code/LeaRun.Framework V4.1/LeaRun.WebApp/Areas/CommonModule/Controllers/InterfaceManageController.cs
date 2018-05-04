using LeaRun.Business;
using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.CommonModule.Controllers
{
    /// <summary>
    /// �ӿڹ��������
    /// </summary>
    public class InterfaceManageController : PublicController<Base_InterfaceManage>
    {
        Base_InterfaceManageBll base_interfacemanagebll = new Base_InterfaceManageBll();
        /// <summary>
        /// ���ӿڹ������ؽӿ��б�JSON
        /// </summary>
        /// <param name="jqgridparam">��ҳ����</param>
        /// <returns></returns>
        public ActionResult GridPageListJson(JqGridParam jqgridparam)
        {
            Stopwatch watch = CommonHelper.TimerStart();
            List<Base_InterfaceManage> ListData = base_interfacemanagebll.GetPageList(ref jqgridparam);
            var JsonData = new
            {
                total = jqgridparam.total,
                page = jqgridparam.page,
                records = jqgridparam.records,
                costtime = CommonHelper.TimerEnd(watch),
                rows = ListData,
            };
            return Content(JsonData.ToJson());
        }
        /// <summary>
        /// ���ӿڹ������ؽӿڲ����б�JSON
        /// </summary>
        /// <param name="InterfaceId"></param>
        /// <returns></returns>
        public ActionResult GridInterfaceParameterListJson(string InterfaceId)
        {
            List<Base_InterfaceManageParameter> ListData = base_interfacemanagebll.GetInterfaceParameterList(InterfaceId);
            var JsonData = new
            {
                rows = ListData,
            };
            return Content(JsonData.ToJson());
        }
        /// <summary>
        /// �ύ�ӿڱ����������༭��
        /// </summary>
        /// <param name="KeyValue">����</param>
        /// <param name="entity">�ӿڶ���</param>
        /// <param name="ParameterJson">�ӿڲ���</param>
        /// <returns></returns>
        public ActionResult SubmitInterfaceForm(string KeyValue, Base_InterfaceManage entity, string ParameterJson)
        {
            try
            {
                string Message = KeyValue == "" ? "�����ɹ���" : "�༭�ɹ���";
                int IsOk = base_interfacemanagebll.SubmitInterfaceForm(KeyValue, entity, ParameterJson);
                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
            }
            catch (Exception ex)
            {
                return Content(new JsonMessage { Success = false, Code = "-1", Message = "����ʧ�ܣ�" + ex.Message }.ToString());
            }
        }
    }
}