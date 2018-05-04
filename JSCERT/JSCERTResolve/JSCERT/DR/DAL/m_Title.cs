/**  版本信息模板在安装目录下，可自行修改。
* m_Title.cs
*
* 功 能： N/A
* 类 名： m_Title
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/4/13 11:24:32   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Data.SqlClient;
namespace JSCERT.DAL
{
	/// <summary>
	/// 数据访问类:m_Title
	/// </summary>
	public partial class m_Title
	{
		public m_Title()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(JSCERT.Model.m_Title model)
		{
            OleDbParameter[] parameters = new OleDbParameter[7];
            parameters[0] = new OleDbParameter("@TypeID", model.TypeID);
            parameters[1] = new OleDbParameter("@dt_Date", model.dt_Date);
            parameters[2] = new OleDbParameter("@vc_Title", model.vc_Title);
            parameters[3] = new OleDbParameter("@vc_Href", model.vc_Href);
            parameters[4] = new OleDbParameter("@vc_Md5", model.vc_Md5);
            parameters[5] = new OleDbParameter("@i_Content", model.i_Content);
            parameters[6] = new OleDbParameter("@i_Flag", model.i_Flag);
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.TypeID != null)
			{
				strSql1.Append("TypeID,");
                strSql2.Append("?,");
			}
			if (model.dt_Date != null)
			{
				strSql1.Append("dt_Date,");
                strSql2.Append("?,");
			}
			if (model.vc_Title != null)
			{
				strSql1.Append("vc_Title,");
                strSql2.Append("?,");
			}
			if (model.vc_Href != null)
			{
				strSql1.Append("vc_Href,");
                strSql2.Append("?,");
			}
			if (model.vc_Md5 != null)
			{
				strSql1.Append("vc_Md5,");
                strSql2.Append("?,");
			}
			if (model.i_Content != null)
			{
				strSql1.Append("i_Content,");
                strSql2.Append("?,");
			}
			if (model.i_Flag != null)
			{
				strSql1.Append("i_Flag,");
                strSql2.Append("?,");
			}
			strSql.Append("insert into m_Title(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
            object obj = DB.OleDbHelper.ExecuteSql(strSql.ToString(), parameters, CommandType.Text);
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
		public bool Update(JSCERT.Model.m_Title model)
		{
            OleDbParameter[] parameters = new OleDbParameter[7];
            parameters[0] = new OleDbParameter("@TypeID", model.TypeID);
            parameters[1] = new OleDbParameter("@dt_Date", model.dt_Date);
            parameters[2] = new OleDbParameter("@vc_Title", model.vc_Title);
            parameters[3] = new OleDbParameter("@vc_Href", model.vc_Href);
            parameters[4] = new OleDbParameter("@vc_Md5", model.vc_Md5);
            parameters[5] = new OleDbParameter("@i_Content", model.i_Content);
            parameters[6] = new OleDbParameter("@i_Flag", model.i_Flag);
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_Title set ");
			if (model.TypeID != null)
			{
				strSql.Append("TypeID=?,");
			}
			if (model.dt_Date != null)
			{
				strSql.Append("dt_Date=?,");
			}
			if (model.vc_Title != null)
			{
                strSql.Append("vc_Title=?,");
			}
			if (model.vc_Href != null)
			{
                strSql.Append("vc_Href=?,");
			}
			if (model.vc_Md5 != null)
			{
                strSql.Append("vc_Md5=?,");
			}
			if (model.i_Content != null)
			{
                strSql.Append("i_Content=?,");
			}
			if (model.i_Flag != null)
			{
                strSql.Append("i_Flag=?,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ID="+ model.ID+"");
            int rowsAffected = DB.OleDbHelper.ExecuteSql(strSql.ToString(), parameters, CommandType.Text);
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
		public bool Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_Title ");
			strSql.Append(" where ID="+ID+"" );
			int rowsAffected=DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
		public JSCERT.Model.m_Title GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,TypeID,dt_Date,vc_Title,vc_Href,vc_Md5,i_Content,i_Flag ");
			strSql.Append(" from m_Title ");
			strSql.Append(" where ID="+ID+"" );
			JSCERT.Model.m_Title model=new JSCERT.Model.m_Title();
			DataSet ds=DB.OleDbHelper.GetDataSet(strSql.ToString());
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
		public JSCERT.Model.m_Title DataRowToModel(DataRow row)
		{
			JSCERT.Model.m_Title model=new JSCERT.Model.m_Title();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["TypeID"]!=null && row["TypeID"].ToString()!="")
				{
					model.TypeID=int.Parse(row["TypeID"].ToString());
				}
				if(row["dt_Date"]!=null && row["dt_Date"].ToString()!="")
				{
					model.dt_Date=DateTime.Parse(row["dt_Date"].ToString());
				}
				if(row["vc_Title"]!=null)
				{
					model.vc_Title=row["vc_Title"].ToString();
				}
				if(row["vc_Href"]!=null)
				{
					model.vc_Href=row["vc_Href"].ToString();
				}
				if(row["vc_Md5"]!=null)
				{
					model.vc_Md5=row["vc_Md5"].ToString();
				}
				if(row["i_Content"]!=null && row["i_Content"].ToString()!="")
				{
					model.i_Content=int.Parse(row["i_Content"].ToString());
				}
				if(row["i_Flag"]!=null && row["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(row["i_Flag"].ToString());
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
			strSql.Append("select ID,TypeID,dt_Date,vc_Title,vc_Href,vc_Md5,i_Content,i_Flag ");
			strSql.Append(" FROM m_Title ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DB.OleDbHelper.GetDataSet(strSql.ToString());
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
			strSql.Append(" ID,TypeID,dt_Date,vc_Title,vc_Href,vc_Md5,i_Content,i_Flag ");
			strSql.Append(" FROM m_Title ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM m_Title ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from m_Title T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

