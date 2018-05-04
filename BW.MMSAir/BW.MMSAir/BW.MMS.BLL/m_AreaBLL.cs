using System;
using System.Data;
using System.Collections.Generic;
using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// m_AreaBLL
	/// </summary>
	public partial class m_AreaBLL
	{
		private readonly BW.MMS.DAL.m_AreaDAL dal=new BW.MMS.DAL.m_AreaDAL();
		public m_AreaBLL()
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
		public int  Add(BW.MMS.Model.m_AreaEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.m_AreaEntity model)
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
		public BW.MMS.Model.m_AreaEntity GetModel(int ID)
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
		public List<BW.MMS.Model.m_AreaEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.m_AreaEntity> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.m_AreaEntity> modelList = new List<BW.MMS.Model.m_AreaEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.m_AreaEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BW.MMS.Model.m_AreaEntity();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["vc_Code"]!=null && dt.Rows[n]["vc_Code"].ToString()!="")
					{
					model.vc_Code=dt.Rows[n]["vc_Code"].ToString();
					}
					if(dt.Rows[n]["vc_Name"]!=null && dt.Rows[n]["vc_Name"].ToString()!="")
					{
					model.vc_Name=dt.Rows[n]["vc_Name"].ToString();
					}
					if(dt.Rows[n]["Point_X"]!=null && dt.Rows[n]["Point_X"].ToString()!="")
					{
						model.Point_X=decimal.Parse(dt.Rows[n]["Point_X"].ToString());
					}
					if(dt.Rows[n]["Point_Y"]!=null && dt.Rows[n]["Point_Y"].ToString()!="")
					{
						model.Point_Y=decimal.Parse(dt.Rows[n]["Point_Y"].ToString());
					}
					if(dt.Rows[n]["i_Flag"]!=null && dt.Rows[n]["i_Flag"].ToString()!="")
					{
						model.i_Flag=int.Parse(dt.Rows[n]["i_Flag"].ToString());
					}
					if(dt.Rows[n]["i_parentid"]!=null && dt.Rows[n]["i_parentid"].ToString()!="")
					{
						model.i_parentid=int.Parse(dt.Rows[n]["i_parentid"].ToString());
					}
					if(dt.Rows[n]["nvc_Type"]!=null && dt.Rows[n]["nvc_Type"].ToString()!="")
					{
					model.nvc_Type=dt.Rows[n]["nvc_Type"].ToString();
					}
					if(dt.Rows[n]["i_personcount"]!=null && dt.Rows[n]["i_personcount"].ToString()!="")
					{
						model.i_personcount=int.Parse(dt.Rows[n]["i_personcount"].ToString());
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

