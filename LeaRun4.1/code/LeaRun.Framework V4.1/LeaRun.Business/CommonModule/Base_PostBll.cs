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
using System.Data;
using System.Data.Common;
using System.Text;

namespace LeaRun.Business
{
    /// <summary>
    /// ��λ����
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.08.07 15:34</date>
    /// </author>
    /// </summary>
    public class Base_PostBll : RepositoryFactory<Base_Post>
    {
        /// <summary>
        /// ��ȡ��λ�б�
        /// </summary>
        /// <param name="CompanyId">��˾ID</param>
        /// <param name="DepartmentId">����ID</param>
        /// <param name="jqgridparam">��ҳ����</param>
        /// <returns></returns>
        public DataTable GetPageList(string CompanyId, string DepartmentId, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT    post.PostId ,                   --��λID
                                                post.Code ,                     --��λ����
                                                post.FullName ,                 --��λ����
                                                post.DepartmentId ,             --���ڲ���Id
                                                dep.FullName AS DepartmentName ,--���ڲ���
                                                post.CompanyId ,                --���ڹ�˾Id
                                                cpy.FullName AS CompanyName ,   --���ڹ�˾
                                                post.Enabled ,                  --�Ƿ���Ч
                                                post.Remark ,                   --��λ����
                                                post.SortCode                   --������
                                      FROM      Base_Post post
                                                LEFT JOIN Base_Department dep ON dep.DepartmentId = post.DepartmentId
                                                LEFT JOIN Base_Company cpy ON cpy.CompanyId = post.CompanyId
                                    ) T
                            WHERE   1 = 1 ");
            if (!string.IsNullOrEmpty(CompanyId))
            {
                strSql.Append(" AND CompanyId = @CompanyId");
                parameter.Add(DbFactory.CreateDbParameter("@CompanyId", CompanyId));
            }
            if (!string.IsNullOrEmpty(DepartmentId))
            {
                strSql.Append(" AND DepartmentId = @DepartmentId");
                parameter.Add(DbFactory.CreateDbParameter("@DepartmentId", DepartmentId));
            }
            if (!ManageProvider.Provider.Current().IsSystem)
            {
                strSql.Append(" AND ( PostId IN ( SELECT ResourceId FROM Base_DataScopePermission WHERE");
                strSql.Append(" ObjectId IN ('" + ManageProvider.Provider.Current().ObjectId.Replace(",", "','") + "') ");
                strSql.Append(" ) )");
            }
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }
    }
}