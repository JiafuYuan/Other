using System;
using System.Data;
using System.Collections.Generic;

using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// 能耗类型表
	/// </summary>
	public partial class m_EnergyTypeBLL
	{
		private readonly BW.MMS.DAL.m_EnergyTypeDAL dal=new BW.MMS.DAL.m_EnergyTypeDAL();
		public m_EnergyTypeBLL()
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
		public int  Add(BW.MMS.Model.m_EnergyTypeEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.m_EnergyTypeEntity model)
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
		public BW.MMS.Model.m_EnergyTypeEntity GetModel(int ID)
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
		public List<BW.MMS.Model.m_EnergyTypeEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.m_EnergyTypeEntity> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.m_EnergyTypeEntity> modelList = new List<BW.MMS.Model.m_EnergyTypeEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.m_EnergyTypeEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BW.MMS.Model.m_EnergyTypeEntity();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["vc_EnergyTypeName"]!=null && dt.Rows[n]["vc_EnergyTypeName"].ToString()!="")
					{
					model.vc_EnergyTypeName=dt.Rows[n]["vc_EnergyTypeName"].ToString();
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

