﻿/**  版本信息模板在安装目录下，可自行修改。
* v_PlanVehicleDetail.cs
*
* 功 能： N/A
* 类 名： v_PlanVehicleDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-10-30 10:51:35   N/A    初版
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

using DB_VehicleTransportManage.Model;
namespace DB_VehicleTransportManage.BLL
{
	/// <summary>
	/// v_PlanVehicleDetail
	/// </summary>
	public partial class v_PlanVehicleDetail
	{
		private readonly DB_VehicleTransportManage.DAL.v_PlanVehicleDetail dal=new DB_VehicleTransportManage.DAL.v_PlanVehicleDetail();
		public v_PlanVehicleDetail()
		{}
		#region  BasicMethod

		

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DB_VehicleTransportManage.Model.v_PlanVehicleDetail GetModel()
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
        public List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            if (ds == null) { return null; }
            return DataTableToList(ds.Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> DataTableToList(DataTable dt)
		{
			List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail> modelList = new List<DB_VehicleTransportManage.Model.v_PlanVehicleDetail>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_VehicleTransportManage.Model.v_PlanVehicleDetail model;
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

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

