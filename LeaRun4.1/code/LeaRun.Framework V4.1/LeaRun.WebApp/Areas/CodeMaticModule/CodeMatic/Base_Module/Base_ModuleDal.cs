//=====================================================================================
// All Rights Reserved , Copyright ? Learun 2014
// Software Developers ? Learun 2014
//=====================================================================================

using LeaRun.Kernel;
using LeaRun.Utilities;
using System.Collections;
using System.Text;

namespace LeaRun.Business
{
    /// <summary>
    /// ģ�����ñ�
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.06.22 19:28</date>
    /// </author>
    /// </summary>
    public class Base_ModuleDal : Repository<Base_Module>
    {
        /// <summary>
        /// ��ȡ��ģ�����ñ������б�
        /// </summary>
        /// <param name="where">����</param>
        /// <param name="param">������</param>
        /// <param name="orderField">�����ֶ�</param>
        /// <param name="orderType">��������</param>
        /// <param name="pageIndex">��ǰҳ</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="count">������</param>
        /// <returns></returns>
        public IList GetListWhere(StringBuilder where, SqlParam[] param,string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
							FROM Base_Module WHERE 1=1");
            strSql.Append(where);
            return DataFactory.SqlHelper().GetPageList<Base_Module>(strSql.ToString(), param, CommonHelper.ToOrderField("SortCode", orderField), orderType, pageIndex, pageSize, ref count);
        }
    }
}