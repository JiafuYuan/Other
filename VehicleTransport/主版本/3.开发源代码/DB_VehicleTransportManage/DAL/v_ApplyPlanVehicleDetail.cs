/**  版本信息模板在安装目录下，可自行修改。
* v_ApplyPlanVehicleDetail.cs
*
* 功 能： N/A
* 类 名： v_ApplyPlanVehicleDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-10-30 10:51:35   N/A    初版
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
	/// 数据访问类:v_ApplyPlanVehicleDetail
	/// </summary>
	public partial class v_ApplyPlanVehicleDetail
	{
		public v_ApplyPlanVehicleDetail()
		{}
		#region  Method


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DB_VehicleTransportManage.Model.v_ApplyPlanVehicleDetail DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.v_ApplyPlanVehicleDetail model=new DB_VehicleTransportManage.Model.v_ApplyPlanVehicleDetail();
			if (row != null)
			{
				if(row["VehicleID"]!=null && row["VehicleID"].ToString()!="")
				{
					model.VehicleID=int.Parse(row["VehicleID"].ToString());
				}
				if(row["vc_Code"]!=null)
				{
					model.vc_Code=row["vc_Code"].ToString();
				}
				if(row["VehicleName"]!=null)
				{
					model.VehicleName=row["VehicleName"].ToString();
				}
				if(row["VehicleTypeID"]!=null && row["VehicleTypeID"].ToString()!="")
				{
					model.VehicleTypeID=int.Parse(row["VehicleTypeID"].ToString());
				}
				if(row["VehicleState"]!=null && row["VehicleState"].ToString()!="")
				{
					model.VehicleState=int.Parse(row["VehicleState"].ToString());
				}
				if(row["i_SafeLoad"]!=null && row["i_SafeLoad"].ToString()!="")
				{
					model.i_SafeLoad=int.Parse(row["i_SafeLoad"].ToString());
				}
				if(row["i_LocalizerStationID"]!=null && row["i_LocalizerStationID"].ToString()!="")
				{
					model.i_LocalizerStationID=int.Parse(row["i_LocalizerStationID"].ToString());
				}
				if(row["PlanID"]!=null && row["PlanID"].ToString()!="")
				{
					model.PlanID=int.Parse(row["PlanID"].ToString());
				}
				if(row["PlanState"]!=null && row["PlanState"].ToString()!="")
				{
					model.PlanState=int.Parse(row["PlanState"].ToString());
				}
				if(row["vc_PlanCode"]!=null)
				{
					model.vc_PlanCode=row["vc_PlanCode"].ToString();
				}
				if(row["ArriveDestinationAddressID"]!=null && row["ArriveDestinationAddressID"].ToString()!="")
				{
					model.ArriveDestinationAddressID=int.Parse(row["ArriveDestinationAddressID"].ToString());
				}
				if(row["dt_ArriveDestinationDateTime"]!=null && row["dt_ArriveDestinationDateTime"].ToString()!="")
				{
					model.dt_ArriveDestinationDateTime=DateTime.Parse(row["dt_ArriveDestinationDateTime"].ToString());
				}
				if(row["ApplyDepartmentID"]!=null && row["ApplyDepartmentID"].ToString()!="")
				{
					model.ApplyDepartmentID=int.Parse(row["ApplyDepartmentID"].ToString());
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
			strSql.Append("select VehicleID,vc_Code,VehicleName,VehicleTypeID,VehicleState,i_SafeLoad,i_LocalizerStationID,PlanID,PlanState,vc_PlanCode,ArriveDestinationAddressID,dt_ArriveDestinationDateTime,ApplyDepartmentID ");
			strSql.Append(" FROM v_ApplyPlanVehicleDetail ");
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
			strSql.Append(" VehicleID,vc_Code,VehicleName,VehicleTypeID,VehicleState,i_SafeLoad,i_LocalizerStationID,PlanID,PlanState,vc_PlanCode,ArriveDestinationAddressID,dt_ArriveDestinationDateTime,ApplyDepartmentID ");
			strSql.Append(" FROM v_ApplyPlanVehicleDetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DB.OleDbHelper.GetDataSet(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from v_ApplyPlanVehicleDetail T ");
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

