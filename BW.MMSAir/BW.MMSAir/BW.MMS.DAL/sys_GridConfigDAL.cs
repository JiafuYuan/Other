﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:sys_GridConfigDAL
	/// </summary>
	public partial class sys_GridConfigDAL
	{
		public sys_GridConfigDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "sys_GridConfig"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_GridConfig");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BW.MMS.Model.sys_GridConfigEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_GridConfig(");
			strSql.Append("vc_GridKey,vc_GridName,vc_Field,IsChk,vc_TableName,i_Flag)");
			strSql.Append(" values (");
			strSql.Append("@vc_GridKey,@vc_GridName,@vc_Field,@IsChk,@vc_TableName,@i_Flag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_GridKey", SqlDbType.VarChar,50),
					new SqlParameter("@vc_GridName", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_Field", SqlDbType.VarChar,50),
					new SqlParameter("@IsChk", SqlDbType.Bit,1),
					new SqlParameter("@vc_TableName", SqlDbType.VarChar,50),
					new SqlParameter("@i_Flag", SqlDbType.Int,4)};
			parameters[0].Value = model.vc_GridKey;
			parameters[1].Value = model.vc_GridName;
			parameters[2].Value = model.vc_Field;
			parameters[3].Value = model.IsChk;
			parameters[4].Value = model.vc_TableName;
			parameters[5].Value = model.i_Flag;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.sys_GridConfigEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_GridConfig set ");
			strSql.Append("vc_GridKey=@vc_GridKey,");
			strSql.Append("vc_GridName=@vc_GridName,");
			strSql.Append("vc_Field=@vc_Field,");
			strSql.Append("IsChk=@IsChk,");
			strSql.Append("vc_TableName=@vc_TableName,");
			strSql.Append("i_Flag=@i_Flag");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_GridKey", SqlDbType.VarChar,50),
					new SqlParameter("@vc_GridName", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_Field", SqlDbType.VarChar,50),
					new SqlParameter("@IsChk", SqlDbType.Bit,1),
					new SqlParameter("@vc_TableName", SqlDbType.VarChar,50),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.vc_GridKey;
			parameters[1].Value = model.vc_GridName;
			parameters[2].Value = model.vc_Field;
			parameters[3].Value = model.IsChk;
			parameters[4].Value = model.vc_TableName;
			parameters[5].Value = model.i_Flag;
			parameters[6].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_GridConfig ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_GridConfig ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.sys_GridConfigEntity GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,vc_GridKey,vc_GridName,vc_Field,IsChk,vc_TableName,i_Flag from sys_GridConfig ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			BW.MMS.Model.sys_GridConfigEntity model=new BW.MMS.Model.sys_GridConfigEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_GridKey"]!=null && ds.Tables[0].Rows[0]["vc_GridKey"].ToString()!="")
				{
					model.vc_GridKey=ds.Tables[0].Rows[0]["vc_GridKey"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vc_GridName"]!=null && ds.Tables[0].Rows[0]["vc_GridName"].ToString()!="")
				{
					model.vc_GridName=ds.Tables[0].Rows[0]["vc_GridName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vc_Field"]!=null && ds.Tables[0].Rows[0]["vc_Field"].ToString()!="")
				{
					model.vc_Field=ds.Tables[0].Rows[0]["vc_Field"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IsChk"]!=null && ds.Tables[0].Rows[0]["IsChk"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["IsChk"].ToString()=="1")||(ds.Tables[0].Rows[0]["IsChk"].ToString().ToLower()=="true"))
					{
						model.IsChk=true;
					}
					else
					{
						model.IsChk=false;
					}
				}
				if(ds.Tables[0].Rows[0]["vc_TableName"]!=null && ds.Tables[0].Rows[0]["vc_TableName"].ToString()!="")
				{
					model.vc_TableName=ds.Tables[0].Rows[0]["vc_TableName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["i_Flag"]!=null && ds.Tables[0].Rows[0]["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(ds.Tables[0].Rows[0]["i_Flag"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,vc_GridKey,vc_GridName,vc_Field,IsChk,vc_TableName,i_Flag ");
			strSql.Append(" FROM sys_GridConfig ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" ID,vc_GridKey,vc_GridName,vc_Field,IsChk,vc_TableName,i_Flag ");
			strSql.Append(" FROM sys_GridConfig ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM sys_GridConfig ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from sys_GridConfig T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "sys_GridConfig";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

