/**  版本信息模板在安装目录下，可自行修改。
* m_RuleDetail.cs
*
* 功 能： N/A
* 类 名： m_RuleDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-11 11:08:36   N/A    初版
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

namespace DB_VehicleTransportManage.DAL
{
	/// <summary>
	/// 数据访问类:m_RuleDetail
	/// </summary>
	public partial class m_RuleDetail
	{
		public m_RuleDetail()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DB_VehicleTransportManage.Model.m_RuleDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.RuleID != null)
			{
				strSql1.Append("RuleID,");
				strSql2.Append(""+model.RuleID+",");
			}
			if (model.vc_ModuleName != null)
			{
				strSql1.Append("vc_ModuleName,");
				strSql2.Append("'"+model.vc_ModuleName+"',");
			}
			if (model.vc_Memo != null)
			{
				strSql1.Append("vc_Memo,");
				strSql2.Append("'"+model.vc_Memo+"',");
			}
			if (model.i_Flag != null)
			{
				strSql1.Append("i_Flag,");
				strSql2.Append(""+model.i_Flag+",");
			}
			strSql.Append("insert into m_RuleDetail(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
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
		/// 更新一条数据
		/// </summary>
		public bool Update(DB_VehicleTransportManage.Model.m_RuleDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_RuleDetail set ");
			if (model.RuleID != null)
			{
				strSql.Append("RuleID="+model.RuleID+",");
			}
			else
			{
				strSql.Append("RuleID= null ,");
			}
			if (model.vc_ModuleName != null)
			{
				strSql.Append("vc_ModuleName='"+model.vc_ModuleName+"',");
			}
			else
			{
				strSql.Append("vc_ModuleName= null ,");
			}
			if (model.vc_Memo != null)
			{
				strSql.Append("vc_Memo='"+model.vc_Memo+"',");
			}
			else
			{
				strSql.Append("vc_Memo= null ,");
			}
			if (model.i_Flag != null)
			{
				strSql.Append("i_Flag="+model.i_Flag+",");
			}
			else
			{
				strSql.Append("i_Flag= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ID="+ model.ID+"");
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
		public bool Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_RuleDetail ");
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
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_RuleDetail ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		/// 得到一个对象实体
		/// </summary>
		public DB_VehicleTransportManage.Model.m_RuleDetail GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,RuleID,vc_ModuleName,vc_Memo,i_Flag ");
			strSql.Append(" from m_RuleDetail ");
			strSql.Append(" where ID="+ID+"" );
			DB_VehicleTransportManage.Model.m_RuleDetail model=new DB_VehicleTransportManage.Model.m_RuleDetail();
            
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
		public DB_VehicleTransportManage.Model.m_RuleDetail DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.m_RuleDetail model=new DB_VehicleTransportManage.Model.m_RuleDetail();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["RuleID"]!=null && row["RuleID"].ToString()!="")
				{
					model.RuleID=int.Parse(row["RuleID"].ToString());
				}
				if(row["vc_ModuleName"]!=null)
				{
					model.vc_ModuleName=row["vc_ModuleName"].ToString();
				}
				if(row["vc_Memo"]!=null)
				{
					model.vc_Memo=row["vc_Memo"].ToString();
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
			strSql.Append("select ID,RuleID,vc_ModuleName,vc_Memo,i_Flag ");
			strSql.Append(" FROM m_RuleDetail ");
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
			strSql.Append(" ID,RuleID,vc_ModuleName,vc_Memo,i_Flag ");
			strSql.Append(" FROM m_RuleDetail ");
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
			strSql.Append("select count(1) FROM m_RuleDetail ");
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
			strSql.Append(")AS Row, T.*  from m_RuleDetail T ");
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

