/**  版本信息模板在安装目录下，可自行修改。
* m_Message.cs
*
* 功 能： N/A
* 类 名： m_Message
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/29 11:29:39   N/A    初版
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
	/// 数据访问类:m_Message
	/// </summary>
	public partial class m_Message
	{
		public m_Message()
		{}
		#region  Method

		

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DB_VehicleTransportManage.Model.m_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PlanID != null)
			{
				strSql1.Append("PlanID,");
				strSql2.Append(""+model.PlanID+",");
			}
			if (model.i_MessageType != null)
			{
				strSql1.Append("i_MessageType,");
				strSql2.Append(""+model.i_MessageType+",");
			}
			if (model.FromUserID != null)
			{
				strSql1.Append("FromUserID,");
				strSql2.Append(""+model.FromUserID+",");
			}
			if (model.ToUserID != null)
			{
				strSql1.Append("ToUserID,");
				strSql2.Append(""+model.ToUserID+",");
			}
			if (model.vc_Message != null)
			{
				strSql1.Append("vc_Message,");
				strSql2.Append("'"+model.vc_Message+"',");
			}
			if (model.dt_SendDateTime != null)
			{
				strSql1.Append("dt_SendDateTime,");
				strSql2.Append("'"+model.dt_SendDateTime+"',");
			}
			if (model.dt_ReceiveDateTime != null)
			{
				strSql1.Append("dt_ReceiveDateTime,");
				strSql2.Append("'"+model.dt_ReceiveDateTime+"',");
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
			if (model.i_State != null)
			{
				strSql1.Append("i_State,");
				strSql2.Append(""+model.i_State+",");
			}
			strSql.Append("insert into m_Message(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
			object obj = DB.OleDbHelper.ExecuteScale(strSql.ToString());
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
		public bool Update(DB_VehicleTransportManage.Model.m_Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_Message set ");
			if (model.PlanID != null)
			{
				strSql.Append("PlanID="+model.PlanID+",");
			}
			else
			{
				strSql.Append("PlanID= null ,");
			}
			if (model.i_MessageType != null)
			{
				strSql.Append("i_MessageType="+model.i_MessageType+",");
			}
			else
			{
				strSql.Append("i_MessageType= null ,");
			}
			if (model.FromUserID != null)
			{
				strSql.Append("FromUserID="+model.FromUserID+",");
			}
			else
			{
				strSql.Append("FromUserID= null ,");
			}
			if (model.ToUserID != null)
			{
				strSql.Append("ToUserID="+model.ToUserID+",");
			}
			else
			{
				strSql.Append("ToUserID= null ,");
			}
			if (model.vc_Message != null)
			{
				strSql.Append("vc_Message='"+model.vc_Message+"',");
			}
			else
			{
				strSql.Append("vc_Message= null ,");
			}
			if (model.dt_SendDateTime != null)
			{
				strSql.Append("dt_SendDateTime='"+model.dt_SendDateTime+"',");
			}
			else
			{
				strSql.Append("dt_SendDateTime= null ,");
			}
			if (model.dt_ReceiveDateTime != null)
			{
				strSql.Append("dt_ReceiveDateTime='"+model.dt_ReceiveDateTime+"',");
			}
			else
			{
				strSql.Append("dt_ReceiveDateTime= null ,");
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
			if (model.i_State != null)
			{
				strSql.Append("i_State="+model.i_State+",");
			}
			else
			{
				strSql.Append("i_State= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ID="+ model.ID+"");
            int rowsAffected = DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
			strSql.Append("delete from m_Message ");
			strSql.Append(" where ID="+ID+"" );
            int rowsAffected = DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
			strSql.Append("delete from m_Message ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
            int rows = DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
		public DB_VehicleTransportManage.Model.m_Message GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,PlanID,i_MessageType,FromUserID,ToUserID,vc_Message,dt_SendDateTime,dt_ReceiveDateTime,vc_Memo,i_Flag,i_State ");
			strSql.Append(" from m_Message ");
			strSql.Append(" where ID="+ID+"" );
			DB_VehicleTransportManage.Model.m_Message model=new DB_VehicleTransportManage.Model.m_Message();
            DataSet ds = DB.OleDbHelper.GetDataSet(strSql.ToString());
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
		public DB_VehicleTransportManage.Model.m_Message DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.m_Message model=new DB_VehicleTransportManage.Model.m_Message();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["PlanID"]!=null && row["PlanID"].ToString()!="")
				{
					model.PlanID=int.Parse(row["PlanID"].ToString());
				}
				if(row["i_MessageType"]!=null && row["i_MessageType"].ToString()!="")
				{
					model.i_MessageType=int.Parse(row["i_MessageType"].ToString());
				}
				if(row["FromUserID"]!=null && row["FromUserID"].ToString()!="")
				{
					model.FromUserID=int.Parse(row["FromUserID"].ToString());
				}
				if(row["ToUserID"]!=null && row["ToUserID"].ToString()!="")
				{
					model.ToUserID=int.Parse(row["ToUserID"].ToString());
				}
				if(row["vc_Message"]!=null)
				{
					model.vc_Message=row["vc_Message"].ToString();
				}
				if(row["dt_SendDateTime"]!=null && row["dt_SendDateTime"].ToString()!="")
				{
					model.dt_SendDateTime=DateTime.Parse(row["dt_SendDateTime"].ToString());
				}
				if(row["dt_ReceiveDateTime"]!=null && row["dt_ReceiveDateTime"].ToString()!="")
				{
					model.dt_ReceiveDateTime=DateTime.Parse(row["dt_ReceiveDateTime"].ToString());
				}
				if(row["vc_Memo"]!=null)
				{
					model.vc_Memo=row["vc_Memo"].ToString();
				}
				if(row["i_Flag"]!=null && row["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(row["i_Flag"].ToString());
				}
				if(row["i_State"]!=null && row["i_State"].ToString()!="")
				{
					model.i_State=int.Parse(row["i_State"].ToString());
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
			strSql.Append("select ID,PlanID,i_MessageType,FromUserID,ToUserID,vc_Message,dt_SendDateTime,dt_ReceiveDateTime,vc_Memo,i_Flag,i_State ");
			strSql.Append(" FROM m_Message ");
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
			strSql.Append(" ID,PlanID,i_MessageType,FromUserID,ToUserID,vc_Message,dt_SendDateTime,dt_ReceiveDateTime,vc_Memo,i_Flag,i_State ");
			strSql.Append(" FROM m_Message ");
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
			strSql.Append("select count(1) FROM m_Message ");
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
			strSql.Append(")AS Row, T.*  from m_Message T ");
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

