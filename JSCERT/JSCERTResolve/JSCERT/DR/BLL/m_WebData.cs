/**  版本信息模板在安装目录下，可自行修改。
* m_WebData.cs
*
* 功 能： N/A
* 类 名： m_WebData
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/9 10:58:12   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.OleDb;
using JSCERT.Model;
namespace JSCERT.BLL
{
	/// <summary>
	/// m_WebData
	/// </summary>
	public partial class m_WebData
	{
		private readonly JSCERT.DAL.m_WebData dal=new JSCERT.DAL.m_WebData();
		public m_WebData()
		{}
		#region  BasicMethod


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(JSCERT.Model.m_WebData model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(JSCERT.Model.m_WebData model)
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
		public bool Delete(int TypeID,int ID)
		{
			
			return dal.Delete(TypeID,ID);
		}

     

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public JSCERT.Model.m_WebData GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

        ///
        public List<Model.m_WebData> DtToList<T>(DataTable dt)
        {
            JSCERT.Model.m_WebData model = new JSCERT.Model.m_WebData();
            Func<DataRow, Model.m_WebData> fun = x => new Model.m_WebData()
            {
                ID = Convert.ToInt32(x["ID"]),
                vc_Name = x["vc_name"].ToString(),
                TypeID = Convert.ToInt32(x["TypeID"]),
                i_Count = Convert.ToInt32(x["i_Count"]),
                dt_Time = DateTime.Parse(x["dt_Time"].ToString())
            };
            return dal.DtToList<Model.m_WebData>(dt, fun); ;
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
		public List<JSCERT.Model.m_WebData> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<JSCERT.Model.m_WebData> DataTableToList(DataTable dt)
		{
			List<JSCERT.Model.m_WebData> modelList = new List<JSCERT.Model.m_WebData>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				JSCERT.Model.m_WebData model;
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

        /// <summary>部门物料使用月报表
        /// MaterieTypeDept
        /// </summary>
        /// <param name="month"></param>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public DataSet RunProUpdateDept()
        {
            try
            {
                DataSet ds = DB.OleDbHelper.GetDataSet("CheckWebData", CommandType.StoredProcedure);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
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

