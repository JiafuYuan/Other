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
    /// ��ɫ����
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.08.07 15:34</date>
    /// </author>
    /// </summary>
    public class Base_RolesBll : RepositoryFactory<Base_Roles>
    {
        /// <summary>
        /// ���ݹ�˾id��ȡ��ɫ �б�
        /// </summary>
        /// <param name="CompanyId">��˾ID</param>
        /// <param name="jqgridparam">��ҳ����</param>
        /// <returns></returns>
        public DataTable GetPageList(string CompanyId, ref JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT  *
                            FROM    ( SELECT    r.RoleId ,					--����
                                                r.CompanyId ,				--������˾Id
                                                c.FullName AS CompanyName ,	--������˾
                                                r.Code ,					--����
                                                r.FullName ,				--����
                                                isnull(U.Qty,0) AS MemberCount,--��Ա����
                                                r.Category ,			    --����
                                                r.Enabled ,					--��Ч
                                                r.SortCode ,				--������
                                                r.Remark					--˵��
                                      FROM      Base_Roles r
                                                LEFT JOIN Base_Company c ON c.CompanyId = r.CompanyId
                                                LEFT JOIN ( SELECT  COUNT(1) AS Qty ,
                                                                    ObjectId
                                                            FROM    Base_ObjectUserRelation
                                                            WHERE   Category = '2'
                                                            GROUP BY ObjectId
                                                          ) U ON U.ObjectId = R.RoleId
                                    ) T WHERE 1=1 ");
            if (!string.IsNullOrEmpty(CompanyId))
            {
                strSql.Append(" AND CompanyId = @CompanyId");
                parameter.Add(DbFactory.CreateDbParameter("@CompanyId", CompanyId));
            }
            if (!ManageProvider.Provider.Current().IsSystem)
            {
                strSql.Append(" AND ( RoleId IN ( SELECT ResourceId FROM Base_DataScopePermission WHERE");
                strSql.Append(" ObjectId IN ('" + ManageProvider.Provider.Current().ObjectId.Replace(",", "','") + "') ");
                strSql.Append(" ) )");
            }
            return Repository().FindTablePageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }
    }
}