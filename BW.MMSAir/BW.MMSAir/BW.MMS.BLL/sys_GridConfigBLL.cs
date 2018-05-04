using System;
using System.Data;
using System.Collections.Generic;

using BW.MMS.Model;
namespace BW.MMS.BLL
{
	/// <summary>
	/// Grid配置
	/// </summary>
	public partial class sys_GridConfigBLL
	{
		private readonly BW.MMS.DAL.sys_GridConfigDAL dal=new BW.MMS.DAL.sys_GridConfigDAL();
		public sys_GridConfigBLL()
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
		public int  Add(BW.MMS.Model.sys_GridConfigEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.sys_GridConfigEntity model)
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
		public BW.MMS.Model.sys_GridConfigEntity GetModel(int ID)
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
		public List<BW.MMS.Model.sys_GridConfigEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BW.MMS.Model.sys_GridConfigEntity> DataTableToList(DataTable dt)
		{
			List<BW.MMS.Model.sys_GridConfigEntity> modelList = new List<BW.MMS.Model.sys_GridConfigEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BW.MMS.Model.sys_GridConfigEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new BW.MMS.Model.sys_GridConfigEntity();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["vc_GridKey"]!=null && dt.Rows[n]["vc_GridKey"].ToString()!="")
					{
					model.vc_GridKey=dt.Rows[n]["vc_GridKey"].ToString();
					}
					if(dt.Rows[n]["vc_GridName"]!=null && dt.Rows[n]["vc_GridName"].ToString()!="")
					{
					model.vc_GridName=dt.Rows[n]["vc_GridName"].ToString();
					}
					if(dt.Rows[n]["vc_Field"]!=null && dt.Rows[n]["vc_Field"].ToString()!="")
					{
					model.vc_Field=dt.Rows[n]["vc_Field"].ToString();
					}
					if(dt.Rows[n]["IsChk"]!=null && dt.Rows[n]["IsChk"].ToString()!="")
					{
						if((dt.Rows[n]["IsChk"].ToString()=="1")||(dt.Rows[n]["IsChk"].ToString().ToLower()=="true"))
						{
						model.IsChk=true;
						}
						else
						{
							model.IsChk=false;
						}
					}
					if(dt.Rows[n]["vc_TableName"]!=null && dt.Rows[n]["vc_TableName"].ToString()!="")
					{
					model.vc_TableName=dt.Rows[n]["vc_TableName"].ToString();
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

