using System;
using System.Data;
using System.Collections.Generic;
using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// v_ArrayClassBLL
	/// </summary>
	public partial class v_ArrayClassBLL
	{
		private readonly BW.MMS.DAL.v_ArrayClassDAL dal=new BW.MMS.DAL.v_ArrayClassDAL();
		public v_ArrayClassBLL()
		{}
		#region  Method

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.v_ArrayClassEntity GetModel()
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
		public List<BW.MMS.Model.v_ArrayClassEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.v_ArrayClassEntity> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.v_ArrayClassEntity> modelList = new List<BW.MMS.Model.v_ArrayClassEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.v_ArrayClassEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BW.MMS.Model.v_ArrayClassEntity();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["dt_Date"]!=null && dt.Rows[n]["dt_Date"].ToString()!="")
					{
						model.dt_Date=DateTime.Parse(dt.Rows[n]["dt_Date"].ToString());
					}
					if(dt.Rows[n]["DeptID"]!=null && dt.Rows[n]["DeptID"].ToString()!="")
					{
						model.DeptID=int.Parse(dt.Rows[n]["DeptID"].ToString());
					}
					if(dt.Rows[n]["DeptName"]!=null && dt.Rows[n]["DeptName"].ToString()!="")
					{
					model.DeptName=dt.Rows[n]["DeptName"].ToString();
					}
					if(dt.Rows[n]["ClassID"]!=null && dt.Rows[n]["ClassID"].ToString()!="")
					{
						model.ClassID=int.Parse(dt.Rows[n]["ClassID"].ToString());
					}
					if(dt.Rows[n]["ClassName"]!=null && dt.Rows[n]["ClassName"].ToString()!="")
					{
					model.ClassName=dt.Rows[n]["ClassName"].ToString();
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

