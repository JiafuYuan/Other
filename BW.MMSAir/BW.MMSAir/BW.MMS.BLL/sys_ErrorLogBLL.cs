using System;
using System.Data;
using System.Collections.Generic;

using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// 系统异常日志表
	/// </summary>
	public partial class sys_ErrorLogBLL
	{
		private readonly BW.MMS.DAL.sys_ErrorLogDAL dal=new BW.MMS.DAL.sys_ErrorLogDAL();
		public sys_ErrorLogBLL()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(DateTime dt_DataTime)
		{
			return dal.Exists(dt_DataTime);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BW.MMS.Model.sys_ErrorLogEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.sys_ErrorLogEntity model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(DateTime dt_DataTime)
		{
			
			return dal.Delete(dt_DataTime);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string dt_DataTimelist )
		{
			return dal.DeleteList(dt_DataTimelist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.sys_ErrorLogEntity GetModel(DateTime dt_DataTime)
		{
			
			return dal.GetModel(dt_DataTime);
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
		public List<BW.MMS.Model.sys_ErrorLogEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.sys_ErrorLogEntity> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.sys_ErrorLogEntity> modelList = new List<BW.MMS.Model.sys_ErrorLogEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.sys_ErrorLogEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BW.MMS.Model.sys_ErrorLogEntity();
					if(dt.Rows[n]["vc_Message"]!=null && dt.Rows[n]["vc_Message"].ToString()!="")
					{
					model.vc_Message=dt.Rows[n]["vc_Message"].ToString();
					}
					if(dt.Rows[n]["vc_Source"]!=null && dt.Rows[n]["vc_Source"].ToString()!="")
					{
					model.vc_Source=dt.Rows[n]["vc_Source"].ToString();
					}
					if(dt.Rows[n]["StackTrace"]!=null && dt.Rows[n]["StackTrace"].ToString()!="")
					{
					model.StackTrace=dt.Rows[n]["StackTrace"].ToString();
					}
					if(dt.Rows[n]["OprationPersonID"]!=null && dt.Rows[n]["OprationPersonID"].ToString()!="")
					{
						model.OprationPersonID=int.Parse(dt.Rows[n]["OprationPersonID"].ToString());
					}
					if(dt.Rows[n]["dt_DataTime"]!=null && dt.Rows[n]["dt_DataTime"].ToString()!="")
					{
						model.dt_DataTime=DateTime.Parse(dt.Rows[n]["dt_DataTime"].ToString());
					}
					if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
					{
					model.vc_Memo=dt.Rows[n]["vc_Memo"].ToString();
					}
					if(dt.Rows[n]["i_Flag"]!=null && dt.Rows[n]["i_Flag"].ToString()!="")
					{
						model.i_Flag=int.Parse(dt.Rows[n]["i_Flag"].ToString());
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

