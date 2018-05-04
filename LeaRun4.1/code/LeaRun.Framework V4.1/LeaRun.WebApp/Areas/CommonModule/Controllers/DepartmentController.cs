using LeaRun.Business;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.WebApp.Areas.CommonModule.Controllers
{
    /// <summary>
    /// ���Ź��������
    /// </summary>
    public class DepartmentController : PublicController<Base_Department>
    {
        Base_DepartmentBll base_departmentbll = new Base_DepartmentBll();
        /// <summary>
        /// �����Ź������� ��˾������ ��JONS
        /// </summary>
        /// <returns></returns>
        public ActionResult TreeJson()
        {
            DataTable dt = base_departmentbll.GetTree();
            List<TreeJsonEntity> TreeList = new List<TreeJsonEntity>();
            if (!DataHelper.IsExistRows(dt))
            {
                foreach (DataRow row in dt.Rows)
                {
                    string DepartmentId = row["departmentid"].ToString();
                    bool hasChildren = false;
                    DataTable childnode = DataHelper.GetNewDataTable(dt, "parentid='" + DepartmentId + "'");
                    if (childnode.Rows.Count > 0)
                    {
                        hasChildren = true;
                    }
                    TreeJsonEntity tree = new TreeJsonEntity();
                    tree.id = DepartmentId;
                    tree.text = row["fullname"].ToString();
                    tree.value = row["code"].ToString();
                    tree.parentId = row["parentid"].ToString();
                    tree.Attribute = "Type";
                    tree.AttributeValue = row["sort"].ToString();
                    tree.AttributeA = "CompanyId";
                    tree.AttributeValueA = row["companyid"].ToString();
                    tree.isexpand = true;
                    tree.complete = true;
                    tree.hasChildren = hasChildren;
                    if (row["parentid"].ToString() == "0")
                    {
                        tree.img = "/Content/Images/Icon16/molecule.png";
                    }
                    else if (row["sort"].ToString() == "Company")
                    {
                        tree.img = "/Content/Images/Icon16/hostname.png";
                    }
                    else if (row["sort"].ToString() == "Department")
                    {
                        tree.img = "/Content/Images/Icon16/chart_organisation.png";
                    }
                    TreeList.Add(tree);
                }
            }
            return Content(TreeList.TreeToJson());
        }
        /// <summary>
        /// �����Ź������ر��JONS
        /// </summary>
        /// <param name="CompanyId">��˾ID</param>
        /// <returns></returns>
        public ActionResult GridListJson(string CompanyId)
        {
            DataTable ListData = base_departmentbll.GetList(CompanyId);
            var JsonData = new
            {
                rows = ListData,
            };
            return Content(JsonData.ToJson());
        }
        /// <summary>
        /// �����Ź������ݹ�˾id��ȡ�����б�����JONS
        /// </summary>
        /// <param name="CompanyId">��˾Id</param>
        /// <returns></returns>
        public ActionResult DepartmentTreeJson(string CompanyId)
        {
            DataTable ListData = base_departmentbll.GetList(CompanyId);
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (DataRow item in ListData.Rows)
            {
                sb.Append("{");
                sb.Append("\"id\":\"" + item["departmentid"] + "\",");
                sb.Append("\"text\":\"" + item["fullname"] + "\",");
                sb.Append("\"value\":\"" + item["departmentid"] + "\",");
                sb.Append("\"img\":\"/Content/Images/Icon16/chart_organisation.png\",");
                sb.Append("\"isexpand\":true,");
                sb.Append("\"hasChildren\":false");
                sb.Append("},");
            }
            sb = sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return Content(sb.ToString());
        }
        /// <summary>
        /// �����Ź��������б�JONS
        /// </summary>
        /// <param name="CompanyId">��˾ID</param>
        /// <returns></returns>
        public ActionResult ListJson(string CompanyId)
        {
            DataTable ListData = base_departmentbll.GetList(CompanyId);
            return Content(ListData.ToJson());
        }
        /// <summary>
        /// �����Ź���ɾ������
        /// </summary>
        /// <param name="KeyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        [ManagerPermission(PermissionMode.Enforce)]
        public ActionResult DeleteDepartment(string KeyValue)
        {
            try
            {
                var Message = "ɾ��ʧ�ܡ�";
                int IsOk = 0;
                int UserCount = DataFactory.Database().FindCount<Base_User>("DepartmentId", KeyValue);
                if (UserCount == 0)
                {
                    IsOk = repositoryfactory.Repository().Delete(KeyValue);
                    if (IsOk > 0)
                    {
                        Message = "ɾ���ɹ���";
                    }
                }
                else
                {
                    Message = "���������û�������ɾ����";
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
    }
}