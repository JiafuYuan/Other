/**  版本信息模板在安装目录下，可自行修改。
* v_PlanVehicleDetail.cs
*
* 功 能： N/A
* 类 名： v_PlanVehicleDetail
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
	/// 数据访问类:v_PlanVehicleDetail
	/// </summary>
	public partial class v_PlanVehicleDetail
	{
		public v_PlanVehicleDetail()
		{}
		#region  Method



		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DB_VehicleTransportManage.Model.v_PlanVehicleDetail GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" VehicleID,vc_Code,VehicleName,VehicleTypeID,DepartmentID,VehicleState,i_SafeLoad,i_LocalizerStationID,dt_InLocalizerStationDateTime,i_MaintainInterval,dt_ScrapDateTime,dt_CreateDateTime,dt_LastMaintainDateTIme,vc_Memo,i_Flag,PlanID,dt_ArriveDestinationDateTime,ArriveDestinationAddressID,PlanState,ApplyID,i_IsTemPlan,vc_PlanCode,CheckPersonID,dt_CheckDateTime,PlanGiveCarDepartmentID,dt_PlanGiveCarDateTime,PlanGiveCarAddressID,PlanUnLoadDepartmentID,PlanBackDepartmentID,dt_PlanBackDateTime,PlanBackAddressID,PlanLoadDepartmentID,PlanLoadAddressID,RealGiveCarDepartmentID,dt_RealGiveCarDateTime,RealGiveCarAddressID,RealLoadDepartmentID,dt_RealLoadDateTime,RealLoadAddressID,dt_RealArriveDestinationDateTime,i_LastLocalizerStationID,LastAddressID ");
			strSql.Append(" from v_PlanVehicleDetail ");
			strSql.Append(" where " );
			DB_VehicleTransportManage.Model.v_PlanVehicleDetail model=new DB_VehicleTransportManage.Model.v_PlanVehicleDetail();
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
		public DB_VehicleTransportManage.Model.v_PlanVehicleDetail DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.v_PlanVehicleDetail model=new DB_VehicleTransportManage.Model.v_PlanVehicleDetail();
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
				if(row["DepartmentID"]!=null && row["DepartmentID"].ToString()!="")
				{
					model.DepartmentID=int.Parse(row["DepartmentID"].ToString());
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
				if(row["dt_InLocalizerStationDateTime"]!=null && row["dt_InLocalizerStationDateTime"].ToString()!="")
				{
					model.dt_InLocalizerStationDateTime=DateTime.Parse(row["dt_InLocalizerStationDateTime"].ToString());
				}
				if(row["i_MaintainInterval"]!=null && row["i_MaintainInterval"].ToString()!="")
				{
					model.i_MaintainInterval=int.Parse(row["i_MaintainInterval"].ToString());
				}
				if(row["dt_ScrapDateTime"]!=null && row["dt_ScrapDateTime"].ToString()!="")
				{
					model.dt_ScrapDateTime=DateTime.Parse(row["dt_ScrapDateTime"].ToString());
				}
				if(row["dt_CreateDateTime"]!=null && row["dt_CreateDateTime"].ToString()!="")
				{
					model.dt_CreateDateTime=DateTime.Parse(row["dt_CreateDateTime"].ToString());
				}
				if(row["dt_LastMaintainDateTIme"]!=null && row["dt_LastMaintainDateTIme"].ToString()!="")
				{
					model.dt_LastMaintainDateTIme=DateTime.Parse(row["dt_LastMaintainDateTIme"].ToString());
				}
				if(row["vc_Memo"]!=null)
				{
					model.vc_Memo=row["vc_Memo"].ToString();
				}
				if(row["i_Flag"]!=null && row["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(row["i_Flag"].ToString());
				}
				if(row["PlanID"]!=null && row["PlanID"].ToString()!="")
				{
					model.PlanID=int.Parse(row["PlanID"].ToString());
				}
				if(row["dt_ArriveDestinationDateTime"]!=null && row["dt_ArriveDestinationDateTime"].ToString()!="")
				{
					model.dt_ArriveDestinationDateTime=DateTime.Parse(row["dt_ArriveDestinationDateTime"].ToString());
				}
				if(row["ArriveDestinationAddressID"]!=null && row["ArriveDestinationAddressID"].ToString()!="")
				{
					model.ArriveDestinationAddressID=int.Parse(row["ArriveDestinationAddressID"].ToString());
				}
				if(row["PlanState"]!=null && row["PlanState"].ToString()!="")
				{
					model.PlanState=int.Parse(row["PlanState"].ToString());
				}
				if(row["ApplyID"]!=null && row["ApplyID"].ToString()!="")
				{
					model.ApplyID=int.Parse(row["ApplyID"].ToString());
				}
				if(row["i_IsTemPlan"]!=null && row["i_IsTemPlan"].ToString()!="")
				{
					model.i_IsTemPlan=int.Parse(row["i_IsTemPlan"].ToString());
				}
				if(row["vc_PlanCode"]!=null)
				{
					model.vc_PlanCode=row["vc_PlanCode"].ToString();
				}
				if(row["CheckPersonID"]!=null && row["CheckPersonID"].ToString()!="")
				{
					model.CheckPersonID=int.Parse(row["CheckPersonID"].ToString());
				}
				if(row["dt_CheckDateTime"]!=null && row["dt_CheckDateTime"].ToString()!="")
				{
					model.dt_CheckDateTime=DateTime.Parse(row["dt_CheckDateTime"].ToString());
				}
				if(row["PlanGiveCarDepartmentID"]!=null && row["PlanGiveCarDepartmentID"].ToString()!="")
				{
					model.PlanGiveCarDepartmentID=int.Parse(row["PlanGiveCarDepartmentID"].ToString());
				}
				if(row["dt_PlanGiveCarDateTime"]!=null && row["dt_PlanGiveCarDateTime"].ToString()!="")
				{
					model.dt_PlanGiveCarDateTime=DateTime.Parse(row["dt_PlanGiveCarDateTime"].ToString());
				}
				if(row["PlanGiveCarAddressID"]!=null && row["PlanGiveCarAddressID"].ToString()!="")
				{
					model.PlanGiveCarAddressID=int.Parse(row["PlanGiveCarAddressID"].ToString());
				}
				if(row["PlanUnLoadDepartmentID"]!=null && row["PlanUnLoadDepartmentID"].ToString()!="")
				{
					model.PlanUnLoadDepartmentID=int.Parse(row["PlanUnLoadDepartmentID"].ToString());
				}
				if(row["PlanBackDepartmentID"]!=null && row["PlanBackDepartmentID"].ToString()!="")
				{
					model.PlanBackDepartmentID=int.Parse(row["PlanBackDepartmentID"].ToString());
				}
				if(row["dt_PlanBackDateTime"]!=null && row["dt_PlanBackDateTime"].ToString()!="")
				{
					model.dt_PlanBackDateTime=DateTime.Parse(row["dt_PlanBackDateTime"].ToString());
				}
				if(row["PlanBackAddressID"]!=null && row["PlanBackAddressID"].ToString()!="")
				{
					model.PlanBackAddressID=int.Parse(row["PlanBackAddressID"].ToString());
				}
				if(row["PlanLoadDepartmentID"]!=null && row["PlanLoadDepartmentID"].ToString()!="")
				{
					model.PlanLoadDepartmentID=int.Parse(row["PlanLoadDepartmentID"].ToString());
				}
				if(row["PlanLoadAddressID"]!=null && row["PlanLoadAddressID"].ToString()!="")
				{
					model.PlanLoadAddressID=int.Parse(row["PlanLoadAddressID"].ToString());
				}
				if(row["RealGiveCarDepartmentID"]!=null && row["RealGiveCarDepartmentID"].ToString()!="")
				{
					model.RealGiveCarDepartmentID=int.Parse(row["RealGiveCarDepartmentID"].ToString());
				}
				if(row["dt_RealGiveCarDateTime"]!=null && row["dt_RealGiveCarDateTime"].ToString()!="")
				{
					model.dt_RealGiveCarDateTime=DateTime.Parse(row["dt_RealGiveCarDateTime"].ToString());
				}
				if(row["RealGiveCarAddressID"]!=null && row["RealGiveCarAddressID"].ToString()!="")
				{
					model.RealGiveCarAddressID=int.Parse(row["RealGiveCarAddressID"].ToString());
				}
				if(row["RealLoadDepartmentID"]!=null && row["RealLoadDepartmentID"].ToString()!="")
				{
					model.RealLoadDepartmentID=int.Parse(row["RealLoadDepartmentID"].ToString());
				}
				if(row["dt_RealLoadDateTime"]!=null && row["dt_RealLoadDateTime"].ToString()!="")
				{
					model.dt_RealLoadDateTime=DateTime.Parse(row["dt_RealLoadDateTime"].ToString());
				}
				if(row["RealLoadAddressID"]!=null && row["RealLoadAddressID"].ToString()!="")
				{
					model.RealLoadAddressID=int.Parse(row["RealLoadAddressID"].ToString());
				}
				if(row["dt_RealArriveDestinationDateTime"]!=null && row["dt_RealArriveDestinationDateTime"].ToString()!="")
				{
					model.dt_RealArriveDestinationDateTime=DateTime.Parse(row["dt_RealArriveDestinationDateTime"].ToString());
				}
				if(row["i_LastLocalizerStationID"]!=null && row["i_LastLocalizerStationID"].ToString()!="")
				{
					model.i_LastLocalizerStationID=int.Parse(row["i_LastLocalizerStationID"].ToString());
				}
				if(row["LastAddressID"]!=null && row["LastAddressID"].ToString()!="")
				{
					model.LastAddressID=int.Parse(row["LastAddressID"].ToString());
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
			strSql.Append("select VehicleID,vc_Code,VehicleName,VehicleTypeID,DepartmentID,VehicleState,i_SafeLoad,i_LocalizerStationID,dt_InLocalizerStationDateTime,i_MaintainInterval,dt_ScrapDateTime,dt_CreateDateTime,dt_LastMaintainDateTIme,vc_Memo,i_Flag,PlanID,dt_ArriveDestinationDateTime,ArriveDestinationAddressID,PlanState,ApplyID,i_IsTemPlan,vc_PlanCode,CheckPersonID,dt_CheckDateTime,PlanGiveCarDepartmentID,dt_PlanGiveCarDateTime,PlanGiveCarAddressID,PlanUnLoadDepartmentID,PlanBackDepartmentID,dt_PlanBackDateTime,PlanBackAddressID,PlanLoadDepartmentID,PlanLoadAddressID,RealGiveCarDepartmentID,dt_RealGiveCarDateTime,RealGiveCarAddressID,RealLoadDepartmentID,dt_RealLoadDateTime,RealLoadAddressID,dt_RealArriveDestinationDateTime,i_LastLocalizerStationID,LastAddressID ");
			strSql.Append(" FROM v_PlanVehicleDetail ");
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
			strSql.Append(" VehicleID,vc_Code,VehicleName,VehicleTypeID,DepartmentID,VehicleState,i_SafeLoad,i_LocalizerStationID,dt_InLocalizerStationDateTime,i_MaintainInterval,dt_ScrapDateTime,dt_CreateDateTime,dt_LastMaintainDateTIme,vc_Memo,i_Flag,PlanID,dt_ArriveDestinationDateTime,ArriveDestinationAddressID,PlanState,ApplyID,i_IsTemPlan,vc_PlanCode,CheckPersonID,dt_CheckDateTime,PlanGiveCarDepartmentID,dt_PlanGiveCarDateTime,PlanGiveCarAddressID,PlanUnLoadDepartmentID,PlanBackDepartmentID,dt_PlanBackDateTime,PlanBackAddressID,PlanLoadDepartmentID,PlanLoadAddressID,RealGiveCarDepartmentID,dt_RealGiveCarDateTime,RealGiveCarAddressID,RealLoadDepartmentID,dt_RealLoadDateTime,RealLoadAddressID,dt_RealArriveDestinationDateTime,i_LastLocalizerStationID,LastAddressID ");
			strSql.Append(" FROM v_PlanVehicleDetail ");
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
			strSql.Append(")AS Row, T.*  from v_PlanVehicleDetail T ");
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

