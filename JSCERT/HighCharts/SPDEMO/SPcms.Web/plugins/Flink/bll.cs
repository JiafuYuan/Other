using System;
using System.Data;
using System.Collections.Generic;
using SPcms.Common;

namespace SPcms.Web.Plugin.FLink.BLL
{
	/// <summary>
	/// Flink
	/// </summary>
	public partial class Flink
	{
        private readonly SPcms.Model.siteconfig siteConfig = new SPcms.BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.Flink dal;
		public Flink()
		{
            dal = new DAL.Flink(siteConfig.sysdatabaseprefix);
        }

		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Flink model)
		{
			return dal.Add(model);
		}
        /// <summary>
		/// 增加一条数据
		/// </summary>
        public void UpdateField(int id,string strValue)
		{
             dal.UpdateField(id, strValue);
		}
        
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(Model.Flink model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Model.Flink GetModel(int id)
		{
			
			return dal.GetModel(id);
		}
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public Model.Flink GetModel(int id, bool t)
        {

            return dal.GetModel(id, t);


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
		public List<Model.Flink> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<Model.Flink> DataTableToList(DataTable dt)
		{
            List<Model.Flink> modelList = new List<Model.Flink>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                Model.Flink model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

