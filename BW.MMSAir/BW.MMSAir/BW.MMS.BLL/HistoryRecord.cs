﻿/**  版本信息模板在安装目录下，可自行修改。
* HistoryRecord.cs
*
* 功 能： N/A
* 类 名： HistoryRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/8 15:32:21   N/A    初版
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
	/// HistoryRecord
	/// </summary>
	public partial class HistoryRecord
	{
		private readonly BW.MMS.DAL.HistoryRecord dal=new BW.MMS.DAL.HistoryRecord();
		public HistoryRecord()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BW.MMS.Model.HistoryRecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.HistoryRecord model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.HistoryRecord GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
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
		public List<BW.MMS.Model.HistoryRecord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.HistoryRecord> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.HistoryRecord> modelList = new List<BW.MMS.Model.HistoryRecord>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.HistoryRecord model;
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
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="page">当前页</param>
        /// <param name="rows">每页显示条数</param>
        /// <param name="sort">提序字段</param>
        /// <param name="order">排序方式</param>
        /// <param name="total">返回总条数</param>
        /// <returns></returns>
        public List<BW.MMS.Model.HistoryRecord> GetPagingList(string name, int page, int rows, string sort, string order, out int total)
        {
            DataTable dt = dal.GetPagingList(name, page, rows, sort, order, out total);
            return DataTableToList(dt);
        }
        /// <summary>
        /// 得到日报表
        /// </summary>
        public DataSet GetDayReport(string startDate, string endDate)
        {
            return dal.GetDayReport(startDate, endDate);
        }
        /// <summary>
        /// 得到月报表
        /// </summary>
        public DataSet GetMonthReport(string startDate, string endDate)
        {
            return dal.GetMonthReport(startDate, endDate);
        }
        /// <summary>
        /// 得到年报表
        /// </summary>
        public DataSet GetYearReport(string startDate, string endDate)
        {
            return dal.GetYearReport(startDate, endDate);
        }
        /// <summary>
        /// 根据区域得到月报表
        /// </summary>
        public DataSet GetAreaMonthReport(string startDate, string endDate,string areaName)
        {
            return dal.GetAreaMonthReport(startDate, endDate,areaName);
        }
        /// <summary>
        /// 根据区域得到年报表
        /// </summary>
        public DataSet GetAreaYearReport(string startDate, string endDate,string areaName)
        {
            return dal.GetAreaYearReport(startDate, endDate,areaName);
        }

		#endregion  BasicMethod


		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

