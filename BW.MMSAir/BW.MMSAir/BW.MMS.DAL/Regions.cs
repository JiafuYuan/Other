/**  版本信息模板在安装目录下，可自行修改。
* Regions.cs
*
* 功 能： N/A
* 类 名： Regions
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/10 10:26:04   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;

namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:Regions
	/// </summary>
	public partial class Regions
	{
		public Regions()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BW.MMS.Model.Regions model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.GUID != null)
			{
				strSql1.Append("GUID,");
				strSql2.Append("'"+model.GUID+"',");
			}
			if (model.Display_Name != null)
			{
				strSql1.Append("Display_Name,");
				strSql2.Append("'"+model.Display_Name+"',");
			}
			if (model.Parent_GUID != null)
			{
				strSql1.Append("Parent_GUID,");
				strSql2.Append("'"+model.Parent_GUID+"',");
			}
			if (model.Code != null)
			{
				strSql1.Append("Code,");
				strSql2.Append("'"+model.Code+"',");
			}
			if (model.Description != null)
			{
				strSql1.Append("Description,");
				strSql2.Append("'"+model.Description+"',");
			}
			if (model.Status != null)
			{
				strSql1.Append("Status,");
				strSql2.Append(""+model.Status+",");
			}
			if (model.Create_Time != null)
			{
				strSql1.Append("Create_Time,");
				strSql2.Append("'"+model.Create_Time+"',");
			}
			if (model.Modify_Time != null)
			{
				strSql1.Append("Modify_Time,");
				strSql2.Append("'"+model.Modify_Time+"',");
			}
			strSql.Append("insert into Regions(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			int rows=DbHelperSQLGH_IMS.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.Regions model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Regions set ");
			if (model.Display_Name != null)
			{
				strSql.Append("Display_Name='"+model.Display_Name+"',");
			}
			if (model.Parent_GUID != null)
			{
				strSql.Append("Parent_GUID='"+model.Parent_GUID+"',");
			}
			else
			{
				strSql.Append("Parent_GUID= null ,");
			}
			if (model.Description != null)
			{
				strSql.Append("Description='"+model.Description+"',");
			}
			else
			{
				strSql.Append("Description= null ,");
			}
			if (model.Status != null)
			{
				strSql.Append("Status="+model.Status+",");
			}
			if (model.Create_Time != null)
			{
				strSql.Append("Create_Time='"+model.Create_Time+"',");
			}
			if (model.Modify_Time != null)
			{
				strSql.Append("Modify_Time='"+model.Modify_Time+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where GUID='"+ model.GUID+"' and Code='"+ model.Code+"' ");
			int rowsAffected=DbHelperSQLGH_IMS.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string GUID,string Code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Regions ");
			strSql.Append(" where GUID='"+GUID+"' and Code='"+Code+"' " );
			int rowsAffected=DbHelperSQLGH_IMS.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.Regions GetModel(string GUID,string Code)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" GUID,Display_Name,Parent_GUID,Code,Description,Status,Create_Time,Modify_Time ");
			strSql.Append(" from Regions ");
			strSql.Append(" where GUID='"+GUID+"' and Code='"+Code+"' " );
			BW.MMS.Model.Regions model=new BW.MMS.Model.Regions();
			DataSet ds=DbHelperSQLGH_IMS.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.Regions DataRowToModel(DataRow row)
		{
			BW.MMS.Model.Regions model=new BW.MMS.Model.Regions();
			if (row != null)
			{
				if(row["GUID"]!=null)
				{
					model.GUID=row["GUID"].ToString();
				}
				if(row["Display_Name"]!=null)
				{
					model.Display_Name=row["Display_Name"].ToString();
				}
				if(row["Parent_GUID"]!=null)
				{
					model.Parent_GUID=row["Parent_GUID"].ToString();
				}
				if(row["Code"]!=null)
				{
					model.Code=row["Code"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Create_Time"]!=null && row["Create_Time"].ToString()!="")
				{
					model.Create_Time=DateTime.Parse(row["Create_Time"].ToString());
				}
				if(row["Modify_Time"]!=null && row["Modify_Time"].ToString()!="")
				{
					model.Modify_Time=DateTime.Parse(row["Modify_Time"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select GUID,Display_Name,Parent_GUID,Code,Description,Status,Create_Time,Modify_Time ");
			strSql.Append(" FROM Regions ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLGH_IMS.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListASOtherName(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GUID as ID ,Display_Name as vc_Name,Parent_GUID,Code,Description,Status,Create_Time,Modify_Time ");
            strSql.Append(" FROM Regions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLGH_IMS.Query(strSql.ToString());
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" GUID,Display_Name,Parent_GUID,Code,Description,Status,Create_Time,Modify_Time ");
			strSql.Append(" FROM Regions ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQLGH_IMS.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Regions ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.ExecuteSql(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Code desc");
			}
			strSql.Append(")AS Row, T.*  from Regions T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLGH_IMS.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

