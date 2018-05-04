using LeaRun.Business;
using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.CommonModule.Controllers
{
    /// <summary>
    /// ��˾���������
    /// </summary>
    public class CompanyController : PublicController<Base_Company>
    {
        Base_CompanyBll base_companybll = new Base_CompanyBll();
        /// <summary>
        /// ����˾����������JONS
        /// </summary>
        /// <returns></returns>
        public ActionResult TreeJson()
        {
            List<Base_Company> list = base_companybll.GetList();
            List<TreeJsonEntity> TreeList = new List<TreeJsonEntity>();
            foreach (Base_Company item in list)
            {
                bool hasChildren = false;
                IList childnode = list.FindAll(t => t.ParentId == item.CompanyId);
                if (childnode.Count > 0)
                {
                    hasChildren = true;
                }
                TreeJsonEntity tree = new TreeJsonEntity();
                tree.id = item.CompanyId;
                tree.text = item.FullName;
                tree.value = item.CompanyId;
                tree.Attribute = "Category";
                tree.AttributeValue = item.Category;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                tree.parentId = item.ParentId;
                if (item.ParentId == "0")
                {
                    tree.img = "/Content/Images/Icon16/molecule.png";
                }
                else
                {
                    tree.img = "/Content/Images/Icon16/hostname.png";
                }
                TreeList.Add(tree);
            }
            return Content(TreeList.TreeToJson());
        }
        /// <summary>
        /// ����˾�������ع�˾�б�JONS
        /// </summary>
        /// <returns></returns>
        public ActionResult TreeGridListJson()
        {
            List<Base_Company> ListData = base_companybll.GetList();
            StringBuilder sb = new StringBuilder();
            sb.Append("{ \"rows\": [");
            sb.Append(TreeGridJson(ListData, -1));
            sb.Append("]}");
            return Content(sb.ToString());
        }
        int lft = 1, rgt = 1000000;
        public string TreeGridJson(List<Base_Company> ListData, int index, string ParentId = "0")
        {
            StringBuilder sb = new StringBuilder();
            List<Base_Company> ChildNodeList = ListData.FindAll(t => t.ParentId == ParentId);
            if (ChildNodeList.Count > 0) { index++; }
            foreach (Base_Company entity in ChildNodeList)
            {
                string strJson = entity.ToJson();
                strJson = strJson.Insert(1, "\"level\":" + index + ",");
                strJson = strJson.Insert(1, "\"isLeaf\":" + (ListData.Count<Base_Company>(t => t.ParentId == entity.CompanyId) == 0 ? true : false).ToString().ToLower() + ",");
                strJson = strJson.Insert(1, "\"expanded\":true,");
                strJson = strJson.Insert(1, "\"lft\":" + lft++ + ",");
                strJson = strJson.Insert(1, "\"rgt\":" + rgt-- + ",");
                sb.Append(strJson);
                sb.Append(TreeGridJson(ListData, index, entity.CompanyId));
            }
            return sb.ToString().Replace("}{", "},{");
        }
        /// <summary>
        /// ����˾���������б�JONS
        /// </summary>
        /// <returns></returns>
        public ActionResult ListJson(string ParentId)
        {
            List<Base_Company> list = base_companybll.GetList();
            if (!string.IsNullOrEmpty(ParentId))
            {
                list = list.FindAll(t => t.ParentId == ParentId);
            }
            return Content(list.ToJson());
        }
        /// <summary>
        /// ����˾����ɾ������
        /// </summary>
        /// <param name="KeyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        [ManagerPermission(PermissionMode.Enforce)]
        public ActionResult DeleteCompany(string KeyValue)
        {
            try
            {
                var Message = "ɾ��ʧ�ܡ�";
                int IsOk = 0;
                int DepartmentCount = DataFactory.Database().FindCount<Base_Department>("CompanyId", KeyValue);
                if (DepartmentCount == 0)
                {
                    IsOk = repositoryfactory.Repository().Delete(KeyValue);
                    if (IsOk > 0)
                    {
                        Message = "ɾ���ɹ���";
                    }
                }
                else
                {
                    Message = "��˾���в��ţ�����ɾ����";
                }
                WriteLog(IsOk, KeyValue, Message);
                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
            }
            catch (Exception ex)
            {
                WriteLog(-1, KeyValue, "����ʧ�ܣ�" + ex.Message);
                return Content(new JsonMessage { Success = false, Code = "-1", Message = "����ʧ�ܣ�" + ex.Message }.ToString());
            }
        }
        /// <summary>
        /// ����˾��������ֵ
        /// </summary>
        /// <param name="KeyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult SetCompanyForm(string KeyValue)
        {
            Base_Company entity = repositoryfactory.Repository().FindEntity(KeyValue);
            string strJson = entity.ToJson();
            //�Զ���
            strJson = strJson.Insert(1, Base_FormAttributeBll.Instance.GetBuildForm(KeyValue));
            return Content(strJson);
        }
        /// <summary>
        /// ����˾�����ύ��
        /// </summary>
        /// <param name="entity">ʵ�����</param>
        /// <param name="KeyValue">����ֵ</param>
        /// <param name="BuildFormJson">�Զ����</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public virtual ActionResult SubmitCompanyForm(Base_Company entity, string KeyValue, string BuildFormJson)
        {
            string ModuleId = DESEncrypt.Decrypt(CookieHelper.GetCookie("ModuleId"));
            IDatabase database = DataFactory.Database();
            DbTransaction isOpenTrans = database.BeginTrans();
            try
            {
                int IsOk = 0;
                string Message = KeyValue == "" ? "�����ɹ���" : "�༭�ɹ���";
                if (!string.IsNullOrEmpty(KeyValue))
                {
                    Base_Company Oldentity = repositoryfactory.Repository().FindEntity(KeyValue);//��ȡû����֮ǰʵ�����
                    entity.Modify(KeyValue);
                    IsOk = database.Update(entity, isOpenTrans);
                    this.WriteLog(IsOk, entity, Oldentity, KeyValue, Message);
                }
                else
                {
                    entity.Create();
                    IsOk = database.Insert(entity, isOpenTrans);
                    this.WriteLog(IsOk, entity, null, KeyValue, Message);
                }
                Base_FormAttributeBll.Instance.SaveBuildForm(BuildFormJson, entity.CompanyId, ModuleId, isOpenTrans);
                return Content(new JsonMessage { Success = true, Code = IsOk.ToString(), Message = Message }.ToString());
            }
            catch (Exception ex)
            {
                this.WriteLog(-1, entity, null, KeyValue, "����ʧ�ܣ�" + ex.Message);
                return Content(new JsonMessage { Success = false, Code = "-1", Message = "����ʧ�ܣ�" + ex.Message }.ToString());
            }
        }
    }
}