using System;
using System.Data;
using System.Collections.Generic;

using DB_VehicleTransportManage.Model;
namespace DB_VehicleTransportManage.BLL
{
	/// <summary>
	/// m_GisMapFiles
	/// </summary>
	public partial class m_GisMapFiles
	{
        private readonly DB_VehicleTransportManage.DAL.m_GisMapFiles dal = new DB_VehicleTransportManage.DAL.m_GisMapFiles();
		public m_GisMapFiles()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(DB_VehicleTransportManage.Model.m_GisMapFiles model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DB_VehicleTransportManage.Model.m_GisMapFiles model)
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
		public DB_VehicleTransportManage.Model.m_GisMapFiles GetModel()
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
		public List<DB_VehicleTransportManage.Model.m_GisMapFiles> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DB_VehicleTransportManage.Model.m_GisMapFiles> DataTableToList(DataTable dt)
		{
			List<DB_VehicleTransportManage.Model.m_GisMapFiles> modelList = new List<DB_VehicleTransportManage.Model.m_GisMapFiles>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_VehicleTransportManage.Model.m_GisMapFiles model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DB_VehicleTransportManage.Model.m_GisMapFiles();
					if(dt.Rows[n]["File_Name"]!=null && dt.Rows[n]["File_Name"].ToString()!="")
					{
					model.File_Name=dt.Rows[n]["File_Name"].ToString();
					}
					if(dt.Rows[n]["File_Data"]!=null && dt.Rows[n]["File_Data"].ToString()!="")
					{
						model.File_Data=(byte[])dt.Rows[n]["File_Data"];
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

