using System;
using System.Data;
using System.Collections.Generic;
using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// m_ClassBLL
	/// </summary>
	public partial class m_ClassBLL
	{
		private readonly BW.MMS.DAL.m_ClassDAL dal=new BW.MMS.DAL.m_ClassDAL();
		public m_ClassBLL()
		{}
		#region  Method

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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BW.MMS.Model.m_ClassEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.m_ClassEntity model)
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
        public bool Delete(string where)
        {

            return dal.Delete(where);
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
		public BW.MMS.Model.m_ClassEntity GetModel(int ID)
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
		public List<BW.MMS.Model.m_ClassEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.m_ClassEntity> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.m_ClassEntity> modelList = new List<BW.MMS.Model.m_ClassEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.m_ClassEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BW.MMS.Model.m_ClassEntity();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["classTypeID"]!=null && dt.Rows[n]["classTypeID"].ToString()!="")
					{
						model.classTypeID=int.Parse(dt.Rows[n]["classTypeID"].ToString());
					}
					if(dt.Rows[n]["nvc_name"]!=null && dt.Rows[n]["nvc_name"].ToString()!="")
					{
					model.nvc_name=dt.Rows[n]["nvc_name"].ToString();
					}
					if(dt.Rows[n]["nvc_shortname"]!=null && dt.Rows[n]["nvc_shortname"].ToString()!="")
					{
					model.nvc_shortname=dt.Rows[n]["nvc_shortname"].ToString();
					}
					if(dt.Rows[n]["d_start"]!=null && dt.Rows[n]["d_start"].ToString()!="")
					{
					model.d_start=dt.Rows[n]["d_start"].ToString();
					}
					if(dt.Rows[n]["d_End"]!=null && dt.Rows[n]["d_End"].ToString()!="")
					{
					model.d_End=dt.Rows[n]["d_End"].ToString();
					}
					if(dt.Rows[n]["nvc_descripe"]!=null && dt.Rows[n]["nvc_descripe"].ToString()!="")
					{
					model.nvc_descripe=dt.Rows[n]["nvc_descripe"].ToString();
					}
					if(dt.Rows[n]["nvc_remark"]!=null && dt.Rows[n]["nvc_remark"].ToString()!="")
					{
					model.nvc_remark=dt.Rows[n]["nvc_remark"].ToString();
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

