//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2014
// Software Developers @ Learun 2014
//=====================================================================================

using LeaRun.DataAccess;
using LeaRun.Entity;
using LeaRun.Repository;
using LeaRun.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace LeaRun.Business
{
    /// <summary>
    /// ��ͼ���ñ�
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.09.04 10:09</date>
    /// </author>
    /// </summary>
    public class Base_ViewBll : RepositoryFactory<Base_View>
    {
        /// <summary>
        /// ����ģ��Id��ȡ��ͼ�б�
        /// </summary>
        /// <param name="ModuleId"></param>
        /// <returns></returns>
        public List<Base_View> GetViewList(string ModuleId)
        {
            StringBuilder WhereSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            WhereSql.Append(" AND ModuleId = @ModuleId order by sortcode asc");
            parameter.Add(DbFactory.CreateDbParameter("@ModuleId", ModuleId));
            return Repository().FindList(WhereSql.ToString(), parameter.ToArray());
        }
        /// <summary>
        /// ��ͼ�ύ���������༭��ɾ����
        /// </summary>
        /// <param name="KeyValue">�ж��������޸�</param>
        /// <param name="ModuleId">ģ��Id</param>
        /// <param name="ViewJson">��ͼJson</param>
        /// <param name="ViewWhereJson">��ͼ����Json</param>
        /// <returns></returns>
        public int SubmitForm(string KeyValue, string ModuleId, string ViewJson, string ViewWhereJson)
        {
            IDatabase database = DataFactory.Database();
            DbTransaction isOpenTrans = database.BeginTrans();
            try
            {
                List<Base_View> ViewList = ViewJson.JonsToList<Base_View>();
                List<Base_ViewWhere> ViewWhereList = ViewWhereJson.JonsToList<Base_ViewWhere>();
                if (!string.IsNullOrEmpty(KeyValue))
                {
                    database.Delete<Base_View>("ModuleId", ModuleId, isOpenTrans);
                    database.Delete<Base_ViewWhere>("ModuleId", ModuleId, isOpenTrans);
                }
                foreach (Base_View base_view in ViewList)
                {
                    if (string.IsNullOrEmpty(base_view.ViewId))
                        base_view.ViewId = CommonHelper.GetGuid;
                    base_view.ModuleId = ModuleId;
                    base_view.ParentId = "0";
                    database.Insert(base_view, isOpenTrans);
                }
                foreach (Base_ViewWhere base_viewwhere in ViewWhereList)
                {
                    if (string.IsNullOrEmpty(base_viewwhere.ViewWhereId))
                        base_viewwhere.ViewWhereId = CommonHelper.GetGuid;
                    base_viewwhere.ModuleId = ModuleId;
                    database.Insert(base_viewwhere, isOpenTrans);
                }
                database.Commit();
                return 1;
            }
            catch
            {
                database.Rollback();
                return -1;
            }
        }
    }
}