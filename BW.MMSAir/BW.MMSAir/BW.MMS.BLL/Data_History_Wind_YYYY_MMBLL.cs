﻿using System;
using System.Data;
using System.Collections.Generic;

using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// 风量历史数据表
	/// </summary>
	public partial class Data_History_Wind_YYYY_MMBLL
	{
		private readonly BW.MMS.DAL.Data_History_Wind_YYYY_MMDAL dal=new BW.MMS.DAL.Data_History_Wind_YYYY_MMDAL();
		public Data_History_Wind_YYYY_MMBLL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(DateTime dt_DateTime)
		{
			return dal.Exists(dt_DateTime);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BW.MMS.Model.Data_History_Wind_YYYY_MMEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.Data_History_Wind_YYYY_MMEntity model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(DateTime dt_DateTime)
		{
			
			return dal.Delete(dt_DateTime);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.Data_History_Wind_YYYY_MMEntity GetModel(int ID)
		{
			
			return dal.GetModel(ID);
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
		public List<BW.MMS.Model.Data_History_Wind_YYYY_MMEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.Data_History_Wind_YYYY_MMEntity> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.Data_History_Wind_YYYY_MMEntity> modelList = new List<BW.MMS.Model.Data_History_Wind_YYYY_MMEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.Data_History_Wind_YYYY_MMEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BW.MMS.Model.Data_History_Wind_YYYY_MMEntity();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["dt_DateTime"]!=null && dt.Rows[n]["dt_DateTime"].ToString()!="")
					{
						model.dt_DateTime=DateTime.Parse(dt.Rows[n]["dt_DateTime"].ToString());
					}
					if(dt.Rows[n]["SensorID"]!=null && dt.Rows[n]["SensorID"].ToString()!="")
					{
						model.SensorID=int.Parse(dt.Rows[n]["SensorID"].ToString());
					}
					if(dt.Rows[n]["f_Traffic"]!=null && dt.Rows[n]["f_Traffic"].ToString()!="")
					{
						model.f_Traffic=decimal.Parse(dt.Rows[n]["f_Traffic"].ToString());
					}
					if(dt.Rows[n]["f_CumulativeTraffic"]!=null && dt.Rows[n]["f_CumulativeTraffic"].ToString()!="")
					{
						model.f_CumulativeTraffic=decimal.Parse(dt.Rows[n]["f_CumulativeTraffic"].ToString());
					}
					if(dt.Rows[n]["f_Temperature"]!=null && dt.Rows[n]["f_Temperature"].ToString()!="")
					{
						model.f_Temperature=decimal.Parse(dt.Rows[n]["f_Temperature"].ToString());
					}
					if(dt.Rows[n]["f_Pressure"]!=null && dt.Rows[n]["f_Pressure"].ToString()!="")
					{
						model.f_Pressure=decimal.Parse(dt.Rows[n]["f_Pressure"].ToString());
					}
					if(dt.Rows[n]["AreaID"]!=null && dt.Rows[n]["AreaID"].ToString()!="")
					{
						model.AreaID=int.Parse(dt.Rows[n]["AreaID"].ToString());
					}
					if(dt.Rows[n]["DeptID"]!=null && dt.Rows[n]["DeptID"].ToString()!="")
					{
						model.DeptID=int.Parse(dt.Rows[n]["DeptID"].ToString());
					}
					if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
					{
					model.vc_Memo=dt.Rows[n]["vc_Memo"].ToString();
					}
					if(dt.Rows[n]["i_Flag"]!=null && dt.Rows[n]["i_Flag"].ToString()!="")
					{
						model.i_Flag=int.Parse(dt.Rows[n]["i_Flag"].ToString());
					}
					if(dt.Rows[n]["dt_Now"]!=null && dt.Rows[n]["dt_Now"].ToString()!="")
					{
						model.dt_Now=DateTime.Parse(dt.Rows[n]["dt_Now"].ToString());
					}
					modelList.Add(model);
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

		#endregion  Method
	}
}

