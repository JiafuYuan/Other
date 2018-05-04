using System;
using System.Data;
using System.Collections.Generic;

using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// 传感器关系表
	/// </summary>
	public partial class m_SensorRelationshipBLL
	{
		private readonly BW.MMS.DAL.m_SensorRelationshipDAL dal=new BW.MMS.DAL.m_SensorRelationshipDAL();
		public m_SensorRelationshipBLL()
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
		public bool Exists(int SensorID)
		{
			return dal.Exists(SensorID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BW.MMS.Model.m_SensorRelationshipEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.m_SensorRelationshipEntity model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SensorID)
		{
			
			return dal.Delete(SensorID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SensorIDlist )
		{
			return dal.DeleteList(SensorIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.m_SensorRelationshipEntity GetModel(int SensorID)
		{
			
			return dal.GetModel(SensorID);
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
		public List<BW.MMS.Model.m_SensorRelationshipEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.m_SensorRelationshipEntity> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.m_SensorRelationshipEntity> modelList = new List<BW.MMS.Model.m_SensorRelationshipEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.m_SensorRelationshipEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BW.MMS.Model.m_SensorRelationshipEntity();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["SensorID"]!=null && dt.Rows[n]["SensorID"].ToString()!="")
					{
						model.SensorID=int.Parse(dt.Rows[n]["SensorID"].ToString());
					}
					if(dt.Rows[n]["ParentSensorID"]!=null && dt.Rows[n]["ParentSensorID"].ToString()!="")
					{
						model.ParentSensorID=int.Parse(dt.Rows[n]["ParentSensorID"].ToString());
					}
					if(dt.Rows[n]["i_Flag"]!=null && dt.Rows[n]["i_Flag"].ToString()!="")
					{
						model.i_Flag=int.Parse(dt.Rows[n]["i_Flag"].ToString());
					}
					if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
					{
					model.vc_Memo=dt.Rows[n]["vc_Memo"].ToString();
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

