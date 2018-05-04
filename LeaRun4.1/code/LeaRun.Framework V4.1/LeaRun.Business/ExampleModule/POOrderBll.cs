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
    /// ��������
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.10.27 12:04</date>
    /// </author>
    /// </summary>
    public class POOrderBll : RepositoryFactory<POOrder>
    {
        /// <summary>
        /// �����б�
        /// </summary>
        /// <param name="BillNo">�Ƶ����</param>
        /// <param name="StartTime">�Ƶ���ʼʱ��</param>
        /// <param name="EndTime">�Ƶ�����ʱ��</param>
        /// <param name="jqgridparam">��ҳ����</param>
        /// <returns></returns>
        public List<POOrder> GetOrderList(string BillNo, string StartTime, string EndTime, JqGridParam jqgridparam)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT * FROM POOrder WHERE 1=1");
            //�Ƶ����
            if (!string.IsNullOrEmpty(BillNo))
            {
                strSql.Append(" AND BillNo like @BillNo ");
                parameter.Add(DbFactory.CreateDbParameter("@BillNo", '%' + BillNo + '%'));
            }
            //�Ƶ���ʼ
            if (!string.IsNullOrEmpty(StartTime) && !string.IsNullOrEmpty(EndTime))
            {
                strSql.Append(" AND BillDate Between @StartTime AND @EndTime ");
                parameter.Add(DbFactory.CreateDbParameter("@StartTime", CommonHelper.GetDateTime(StartTime + " 00:00")));
                parameter.Add(DbFactory.CreateDbParameter("@EndTime", CommonHelper.GetDateTime(EndTime + " 23:59")));
            }
            return Repository().FindListPageBySql(strSql.ToString(), parameter.ToArray(), ref jqgridparam);
        }
        /// <summary>
        /// ������ϸ�б�
        /// </summary>
        /// <param name="POOrderId">��������</param>
        /// <returns></returns>
        public List<POOrderEntry> GetOrderEntryList(string POOrderId)
        {
            StringBuilder strSql = new StringBuilder();
            List<DbParameter> parameter = new List<DbParameter>();
            strSql.Append(@"SELECT * FROM POOrderEntry WHERE 1=1");
            strSql.Append(" AND POOrderId = @POOrderId");
            parameter.Add(DbFactory.CreateDbParameter("@POOrderId", POOrderId));
            return DataFactory.Database().FindListBySql<POOrderEntry>(strSql.ToString(), parameter.ToArray());
        }
    }
}