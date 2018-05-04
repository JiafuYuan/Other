//=====================================================================================
// All Rights Reserved , Copyright ? Learun 2014
// Software Developers ? Learun 2014
//=====================================================================================

using LeaRun.Kernel;
using LeaRun.Utilities;
using System.Collections;
using System.Collections.Generic;
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
    public class Base_ModuleBll : IRepository<Base_Module>
    {
        private readonly Base_ModuleDal dal = new Base_ModuleDal();

        /// <summary>
        /// ��ȡ��ģ�����ñ������б�
        /// </summary>
        /// <param name="where">��������</param>
        /// <param name="orderField">�����ֶ�</param>
        /// <param name="orderType">��������</param>
        /// <param name="pageIndex">��ǰҳ</param>
        /// <param name="pageSize">ҳ��С</param>
        /// <param name="count">������</param>
        /// <returns></returns>
        public IList GetList(Hashtable where,string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            StringBuilder Sqlwhere = new StringBuilder();
            List<SqlParam> ListParam = new List<SqlParam>();
            return dal.GetListWhere(Sqlwhere, ListParam.ToArray(), orderField, orderType, pageIndex, pageSize, ref  count);
        }
    }
}