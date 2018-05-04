/**  版本信息模板在安装目录下，可自行修改。
* m_EventCode.cs
*
* 功 能： N/A
* 类 名： m_EventCode
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/16 16:21:59   N/A    初版
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
using JSCERT;


namespace JSCERT.DAL
{
	/// <summary>
	/// 数据访问类:m_EventCode
	/// </summary>
	public partial class m_EventCode
	{
		public m_EventCode()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(JSCERT.Model.m_EventCode model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.EventCode != null)
			{
				strSql1.Append("EventCode,");
				strSql2.Append("'"+model.EventCode+"',");
			}
			if (model.EventType != null)
			{
				strSql1.Append("EventType,");
				strSql2.Append("'"+model.EventType+"',");
			}
			if (model.ArtileCode != null)
			{
				strSql1.Append("ArtileCode,");
				strSql2.Append("'"+model.ArtileCode+"',");
			}
			if (model.FindDate != null)
			{
				strSql1.Append("FindDate,");
				strSql2.Append("'"+model.FindDate+"',");
			}
			if (model.UploadDate != null)
			{
				strSql1.Append("UploadDate,");
				strSql2.Append("'"+model.UploadDate+"',");
			}
			if (model.Admin != null)
			{
				strSql1.Append("Admin,");
				strSql2.Append("'"+model.Admin+"',");
			}
			strSql.Append("insert into m_EventCode(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			int rows=DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
		public bool Update(JSCERT.Model.m_EventCode model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_EventCode set ");
			if (model.EventCode != null)
			{
				strSql.Append("EventCode='"+model.EventCode+"',");
			}
			else
			{
				strSql.Append("EventCode= null ,");
			}
			if (model.EventType != null)
			{
				strSql.Append("EventType='"+model.EventType+"',");
			}
			else
			{
				strSql.Append("EventType= null ,");
			}
			if (model.ArtileCode != null)
			{
				strSql.Append("ArtileCode='"+model.ArtileCode+"',");
			}
			if (model.FindDate != null)
			{
				strSql.Append("FindDate='"+model.FindDate+"',");
			}
			if (model.UploadDate != null)
			{
				strSql.Append("UploadDate='"+model.UploadDate+"',");
			}
			if (model.Admin != null)
			{
				strSql.Append("Admin='"+model.Admin+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_EventCode ");
			strSql.Append(" where " );
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
		public JSCERT.Model.m_EventCode GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" EventCode,EventType,ArtileCode,FindDate,UploadDate,Admin ");
			strSql.Append(" from m_EventCode ");
			strSql.Append(" where " );
			JSCERT.Model.m_EventCode model=new JSCERT.Model.m_EventCode();
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
		public JSCERT.Model.m_EventCode DataRowToModel(DataRow row)
		{
			JSCERT.Model.m_EventCode model=new JSCERT.Model.m_EventCode();
			if (row != null)
			{
				if(row["EventCode"]!=null)
				{
					model.EventCode=row["EventCode"].ToString();
				}
				if(row["EventType"]!=null)
				{
					model.EventType=row["EventType"].ToString();
				}
				if(row["ArtileCode"]!=null)
				{
					model.ArtileCode=row["ArtileCode"].ToString();
				}
				if(row["FindDate"]!=null && row["FindDate"].ToString()!="")
				{
					model.FindDate=DateTime.Parse(row["FindDate"].ToString());
				}
				if(row["UploadDate"]!=null && row["UploadDate"].ToString()!="")
				{
					model.UploadDate=DateTime.Parse(row["UploadDate"].ToString());
				}
				if(row["Admin"]!=null)
				{
					model.Admin=row["Admin"].ToString();
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
			strSql.Append("select EventCode,EventType,ArtileCode,FindDate,UploadDate,Admin ");
			strSql.Append(" FROM m_EventCode ");
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
			strSql.Append(" EventCode,EventType,ArtileCode,FindDate,UploadDate,Admin ");
			strSql.Append(" FROM m_EventCode ");
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
			strSql.Append("select count(1) FROM m_EventCode ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from m_EventCode T ");
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

