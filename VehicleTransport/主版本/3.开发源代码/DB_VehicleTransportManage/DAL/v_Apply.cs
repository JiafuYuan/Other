/**  版本信息模板在安装目录下，可自行修改。
* v_Apply.cs
*
* 功 能： N/A
* 类 名： v_Apply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/28 16:41:43   N/A    初版
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
	/// 数据访问类:v_Apply
	/// </summary>
	public partial class v_Apply
	{
		public v_Apply()
		{}
		#region  Method



	
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DB_VehicleTransportManage.Model.v_Apply GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,dt_ApplyDateTime,deptname,ApplyDepartmentID,ApplyPersonID,username,vc_PlanUse,ArriveDestinationAddressID,addressname,dt_arrive,statename,i_State,i_IsUseMaterieApply,vc_remark ");
			strSql.Append(" from v_Apply ");
            strSql.Append(" where ID=" + ID + "");
			DB_VehicleTransportManage.Model.v_Apply model=new DB_VehicleTransportManage.Model.v_Apply();
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
		public DB_VehicleTransportManage.Model.v_Apply DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.v_Apply model=new DB_VehicleTransportManage.Model.v_Apply();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dt_ApplyDateTime"]!=null && row["dt_ApplyDateTime"].ToString()!="")
				{
					model.dt_ApplyDateTime=DateTime.Parse(row["dt_ApplyDateTime"].ToString());
				}
				if(row["deptname"]!=null)
				{
					model.deptname=row["deptname"].ToString();
				}
				if(row["ApplyDepartmentID"]!=null && row["ApplyDepartmentID"].ToString()!="")
				{
					model.ApplyDepartmentID=int.Parse(row["ApplyDepartmentID"].ToString());
				}
				if(row["ApplyPersonID"]!=null && row["ApplyPersonID"].ToString()!="")
				{
					model.ApplyPersonID=int.Parse(row["ApplyPersonID"].ToString());
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["vc_PlanUse"]!=null)
				{
					model.vc_PlanUse=row["vc_PlanUse"].ToString();
				}
				if(row["ArriveDestinationAddressID"]!=null && row["ArriveDestinationAddressID"].ToString()!="")
				{
					model.ArriveDestinationAddressID=int.Parse(row["ArriveDestinationAddressID"].ToString());
				}
				if(row["addressname"]!=null)
				{
					model.addressname=row["addressname"].ToString();
				}
				if(row["dt_arrive"]!=null && row["dt_arrive"].ToString()!="")
				{
					model.dt_arrive=DateTime.Parse(row["dt_arrive"].ToString());
				}
				if(row["statename"]!=null)
				{
					model.statename=row["statename"].ToString();
				}
				if(row["i_State"]!=null && row["i_State"].ToString()!="")
				{
					model.i_State=int.Parse(row["i_State"].ToString());
				}
				if(row["i_IsUseMaterieApply"]!=null && row["i_IsUseMaterieApply"].ToString()!="")
				{
					model.i_IsUseMaterieApply=int.Parse(row["i_IsUseMaterieApply"].ToString());
				}
				if(row["vc_remark"]!=null)
				{
					model.vc_remark=row["vc_remark"].ToString();
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
			strSql.Append("select ID,dt_ApplyDateTime,deptname,ApplyDepartmentID,ApplyPersonID,username,vc_PlanUse,ArriveDestinationAddressID,addressname,dt_arrive,statename,i_State,i_IsUseMaterieApply,vc_remark ");
			strSql.Append(" FROM v_Apply ");
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
			strSql.Append(" ID,dt_ApplyDateTime,deptname,ApplyDepartmentID,ApplyPersonID,username,vc_PlanUse,ArriveDestinationAddressID,addressname,dt_arrive,statename,i_State,i_IsUseMaterieApply,vc_remark ");
			strSql.Append(" FROM v_Apply ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

