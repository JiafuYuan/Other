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
    /// �ֻ����ű�
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.10.22 11:03</date>
    /// </author>
    /// </summary>
    public class Base_PhoneNoteBll : RepositoryFactory<Base_PhoneNote>
    {
        /// <summary>
        /// �ֻ����ż�¼�б�
        /// </summary>
        /// <param name="UserId">�û�Id</param>
        /// <param name="PhonenNumber">�ֻ�����</param>
        /// <param name="StartTime">��ʼʱ��</param>
        /// <param name="EndTime">����ʱ��</param>
        /// <param name="jqgridparam">��ҳ����</param>
        /// <returns></returns>
        public List<Base_PhoneNote> GetPageList(string UserId, string PhonenNumber, string StartTime, string EndTime, JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append("SELECT * FROM Base_PhoneNote WHERE 1=1");
            //�ֻ�����
            if (!string.IsNullOrEmpty(PhonenNumber))
            {
                strSql.Append(" AND PhonenNumber like @PhonenNumber ");
                parameter.Add(DbFactory.CreateDbParameter("@PhonenNumber", '%' + PhonenNumber + '%'));
            }
            //����ʱ��
            if (!string.IsNullOrEmpty(StartTime) && !string.IsNullOrEmpty(EndTime))
            {
                strSql.Append(" AND SendTime Between @StartTime AND @EndTime ");
                parameter.Add(DbFactory.CreateDbParameter("@StartTime", CommonHelper.GetDateTime(StartTime + " 00:00")));
                parameter.Add(DbFactory.CreateDbParameter("@EndTime", CommonHelper.GetDateTime(EndTime + " 23:59")));
            }
            strSql.Append(" AND CreateUserId = @UserId");
            parameter.Add(DbFactory.CreateDbParameter("@UserId", UserId));
            return Repository().FindListPageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }
    }
}