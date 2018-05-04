using System;
using System.Data;
using System.Collections.Generic;
using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// m_ClassTypeBLL
	/// </summary>
	public partial class m_ClassTypeBLL
	{
		private readonly BW.MMS.DAL.m_ClassTypeDAL dal=new BW.MMS.DAL.m_ClassTypeDAL();
		public m_ClassTypeBLL()
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
		public int  Add(BW.MMS.Model.m_ClassTypeEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.m_ClassTypeEntity model)
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
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.m_ClassTypeEntity GetModel(int ID)
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
		public List<BW.MMS.Model.m_ClassTypeEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.m_ClassTypeEntity> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.m_ClassTypeEntity> modelList = new List<BW.MMS.Model.m_ClassTypeEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.m_ClassTypeEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BW.MMS.Model.m_ClassTypeEntity();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["nvc_name"]!=null && dt.Rows[n]["nvc_name"].ToString()!="")
					{
					model.nvc_name=dt.Rows[n]["nvc_name"].ToString();
					}
					if(dt.Rows[n]["nvc_shortname"]!=null && dt.Rows[n]["nvc_shortname"].ToString()!="")
					{
					model.nvc_shortname=dt.Rows[n]["nvc_shortname"].ToString();
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
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere">条件语句</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">显示条数</param>
        /// <param name="sort">排序字段</param>
        /// <param name="dir">升/降序(DESC、ASC)</param>
        /// <param name="records">输出总条数</param>
        /// <returns></returns>
        public List<BW.MMS.Model.m_ClassTypeEntity> GetPagingList(string strWhere, int PageIndex, int PageSize, string sort, string dir, out int records)
        {
            DataTable dt=dal.GetPagingList(strWhere, PageIndex, PageSize, sort, dir, out records);
            return DataTableToList(dt);
        }
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteClassList(string IDlist)
        {
            return dal.DeleteClassList(IDlist);
        }
        /// <summary>
        /// 检查是否存在此班次
        /// </summary>
        /// <param name="ClassTypeName"></param>
        /// <returns></returns>
        public DataTable CheckClassTypeByName(string ClassTypeName)
        {
            return dal.CheckClassTypeByName(ClassTypeName).Tables[0];
        }
        /// <summary>
        /// 检查是否存在此班次
        /// </summary>
        /// <param name="ClassTypeID"></param>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        public DataTable CheckClassTypeByName(int ClassTypeID, string ClassTypeName)
        {
            return dal.CheckClassTypeByName(ClassTypeID, ClassTypeName).Tables[0];
        }
		#endregion  Method
	}
}

