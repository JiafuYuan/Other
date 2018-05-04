/**  版本信息模板在安装目录下，可自行修改。
* m_Plan_Handover.cs
*
* 功 能： N/A
* 类 名： m_Plan_Handover
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/16 13:27:32   N/A    初版
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
	/// 数据访问类:m_Plan_Handover
	/// </summary>
	public partial class m_Plan_Handover
	{
		public m_Plan_Handover()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DB_VehicleTransportManage.Model.m_Plan_Handover model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PlanID != null)
			{
				strSql1.Append("PlanID,");
				strSql2.Append(""+model.PlanID+",");
			}
			if (model.VehicleID != null)
			{
				strSql1.Append("VehicleID,");
				strSql2.Append(""+model.VehicleID+",");
			}
			if (model.dt_HandoverDateTime != null)
			{
				strSql1.Append("dt_HandoverDateTime,");
				strSql2.Append("'"+model.dt_HandoverDateTime+"',");
			}
			if (model.ReceiveVehiclePersonID != null)
			{
				strSql1.Append("ReceiveVehiclePersonID,");
				strSql2.Append(""+model.ReceiveVehiclePersonID+",");
			}
			if (model.i_HandoverCount != null)
			{
				strSql1.Append("i_HandoverCount,");
				strSql2.Append(""+model.i_HandoverCount+",");
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
			if (model.AddressID != null)
			{
				strSql1.Append("AddressID,");
				strSql2.Append(""+model.AddressID+",");
			}
			strSql.Append("insert into m_Plan_Handover(");
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
		public bool Update(DB_VehicleTransportManage.Model.m_Plan_Handover model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_Plan_Handover set ");
			if (model.PlanID != null)
			{
				strSql.Append("PlanID="+model.PlanID+",");
			}
			else
			{
				strSql.Append("PlanID= null ,");
			}
			if (model.VehicleID != null)
			{
				strSql.Append("VehicleID="+model.VehicleID+",");
			}
			else
			{
				strSql.Append("VehicleID= null ,");
			}
			if (model.dt_HandoverDateTime != null)
			{
				strSql.Append("dt_HandoverDateTime='"+model.dt_HandoverDateTime+"',");
			}
			else
			{
				strSql.Append("dt_HandoverDateTime= null ,");
			}
			if (model.ReceiveVehiclePersonID != null)
			{
				strSql.Append("ReceiveVehiclePersonID="+model.ReceiveVehiclePersonID+",");
			}
			else
			{
				strSql.Append("ReceiveVehiclePersonID= null ,");
			}
			if (model.i_HandoverCount != null)
			{
				strSql.Append("i_HandoverCount="+model.i_HandoverCount+",");
			}
			else
			{
				strSql.Append("i_HandoverCount= null ,");
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
			if (model.AddressID != null)
			{
				strSql.Append("AddressID="+model.AddressID+",");
			}
			else
			{
				strSql.Append("AddressID= null ,");
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
			strSql.Append("delete from m_Plan_Handover ");
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
			strSql.Append("delete from m_Plan_Handover ");
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
		public DB_VehicleTransportManage.Model.m_Plan_Handover GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,PlanID,VehicleID,dt_HandoverDateTime,ReceiveVehiclePersonID,i_HandoverCount,vc_Memo,i_Flag,AddressID ");
			strSql.Append(" from m_Plan_Handover ");
			strSql.Append(" where ID="+ID+"" );
			DB_VehicleTransportManage.Model.m_Plan_Handover model=new DB_VehicleTransportManage.Model.m_Plan_Handover();
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
		public DB_VehicleTransportManage.Model.m_Plan_Handover DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.m_Plan_Handover model=new DB_VehicleTransportManage.Model.m_Plan_Handover();
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
				if(row["VehicleID"]!=null && row["VehicleID"].ToString()!="")
				{
					model.VehicleID=int.Parse(row["VehicleID"].ToString());
				}
				if(row["dt_HandoverDateTime"]!=null && row["dt_HandoverDateTime"].ToString()!="")
				{
					model.dt_HandoverDateTime=DateTime.Parse(row["dt_HandoverDateTime"].ToString());
				}
				if(row["ReceiveVehiclePersonID"]!=null && row["ReceiveVehiclePersonID"].ToString()!="")
				{
					model.ReceiveVehiclePersonID=int.Parse(row["ReceiveVehiclePersonID"].ToString());
				}
				if(row["i_HandoverCount"]!=null && row["i_HandoverCount"].ToString()!="")
				{
					model.i_HandoverCount=int.Parse(row["i_HandoverCount"].ToString());
				}
				if(row["vc_Memo"]!=null)
				{
					model.vc_Memo=row["vc_Memo"].ToString();
				}
				if(row["i_Flag"]!=null && row["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(row["i_Flag"].ToString());
				}
				if(row["AddressID"]!=null && row["AddressID"].ToString()!="")
				{
					model.AddressID=int.Parse(row["AddressID"].ToString());
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
			strSql.Append("select ID,PlanID,VehicleID,dt_HandoverDateTime,ReceiveVehiclePersonID,i_HandoverCount,vc_Memo,i_Flag,AddressID ");
			strSql.Append(" FROM m_Plan_Handover ");
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
			strSql.Append(" ID,PlanID,VehicleID,dt_HandoverDateTime,ReceiveVehiclePersonID,i_HandoverCount,vc_Memo,i_Flag,AddressID ");
			strSql.Append(" FROM m_Plan_Handover ");
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
			strSql.Append("select count(1) FROM m_Plan_Handover ");
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
			strSql.Append(")AS Row, T.*  from m_Plan_Handover T ");
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

