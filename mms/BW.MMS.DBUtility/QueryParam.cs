using System;
using System.Collections.Generic;
using System.Text;

namespace BW.MMS.DBUtility
{
    public class QueryParam
    {
        string orderfld;
        /// <summary>
        /// 排序字段名 最好为唯一主键
        /// </summary>
        public string Orderfld
        {
            get { return orderfld; }
            set { orderfld = value; }
        }


        int orderType;
        /// <summary>
        /// 排序类型  1.降序  其它为升序
        /// </summary>
        public int OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }


        int pageIndex;
        /// <summary>
        ///当前页码 
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }


        int pageSize;
        /// <summary>
        /// 分页条数
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }


        string returnFields;
        /// <summary>
        /// 返回的字段
        /// </summary>
        public string ReturnFields
        {
            get { return returnFields; }
            set { returnFields = value; }
        }


        string tableName;
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }


        string where;
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Where
        {
            get { return where; }
            set { where = value; }
        }

    }
}

