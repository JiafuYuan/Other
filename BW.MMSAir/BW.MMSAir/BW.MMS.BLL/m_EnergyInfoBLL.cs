using System;
using System.Data;
using System.Collections.Generic;

using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// 能效信息表
	/// </summary>
	public partial class m_EnergyInfoBLL
	{
		private readonly BW.MMS.DAL.m_EnergyInfoDAL dal=new BW.MMS.DAL.m_EnergyInfoDAL();
		public m_EnergyInfoBLL()
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
		public bool Exists(DateTime dt_Date,int DeptID)
		{
			return dal.Exists(dt_Date,DeptID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BW.MMS.Model.m_EnergyInfoEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.m_EnergyInfoEntity model)
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
		public bool Delete(DateTime dt_Date,int DeptID)
		{
			
			return dal.Delete(dt_Date,DeptID);
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
		public BW.MMS.Model.m_EnergyInfoEntity GetModel(int ID)
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
		public List<BW.MMS.Model.m_EnergyInfoEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.m_EnergyInfoEntity> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.m_EnergyInfoEntity> modelList = new List<BW.MMS.Model.m_EnergyInfoEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.m_EnergyInfoEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BW.MMS.Model.m_EnergyInfoEntity();
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
					if(dt.Rows[n]["f_RateEnergy"]!=null && dt.Rows[n]["f_RateEnergy"].ToString()!="")
					{
						model.f_RateEnergy=decimal.Parse(dt.Rows[n]["f_RateEnergy"].ToString());
					}
					if(dt.Rows[n]["f_RealEnergy"]!=null && dt.Rows[n]["f_RealEnergy"].ToString()!="")
					{
						model.f_RealEnergy=decimal.Parse(dt.Rows[n]["f_RealEnergy"].ToString());
					}
					if(dt.Rows[n]["f_Production"]!=null && dt.Rows[n]["f_Production"].ToString()!="")
					{
						model.f_Production=decimal.Parse(dt.Rows[n]["f_Production"].ToString());
					}
					if(dt.Rows[n]["f_NetProduction"]!=null && dt.Rows[n]["f_NetProduction"].ToString()!="")
					{
						model.f_NetProduction=decimal.Parse(dt.Rows[n]["f_NetProduction"].ToString());
					}
					if(dt.Rows[n]["f_Energy"]!=null && dt.Rows[n]["f_Energy"].ToString()!="")
					{
						model.f_Energy=decimal.Parse(dt.Rows[n]["f_Energy"].ToString());
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

