/**  版本信息模板在安装目录下，可自行修改。
* m_PLC.cs
*
* 功 能： N/A
* 类 名： m_PLC
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-04-14 15:00:01   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;

using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// m_PLC
	/// </summary>
	public partial class m_PLCBLL
	{
		private readonly BW.MMS.DAL.m_PLCDAL dal=new BW.MMS.DAL.m_PLCDAL();
		public m_PLCBLL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BW.MMS.Model.m_PLCEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.m_PLCEntity model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.m_PLCEntity GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

	

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.m_PLCEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.m_PLCEntity> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.m_PLCEntity> modelList = new List<BW.MMS.Model.m_PLCEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.m_PLCEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere">条件语句</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">显示条数</param>
        /// <param name="sort">排序字段</param>
        /// <param name="dir">升/降序(DESC、ASC)</param>
        /// <param name="records">输出总条数</param>
        /// <returns></returns>
        public List<BW.MMS.Model.m_PLCEntity> GetPagingList(string strWhere, int PageIndex, int PageSize, string sort, string dir, out int records)
        {
            DataTable dt = dal.GetPagingList(strWhere, PageIndex, PageSize, sort, dir, out records);
            return DataTableToList(dt);
        }
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

