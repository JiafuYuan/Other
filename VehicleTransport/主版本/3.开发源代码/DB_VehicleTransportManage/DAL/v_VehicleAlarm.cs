/**  版本信息模板在安装目录下，可自行修改。
* v_VehicleAlarm.cs
*
* 功 能： N/A
* 类 名： v_VehicleAlarm
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/1 11:16:05   N/A    初版
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
	/// 数据访问类:v_VehicleAlarm
	/// </summary>
	public partial class v_VehicleAlarm
	{
		public v_VehicleAlarm()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DB_VehicleTransportManage.Model.v_VehicleAlarm model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ID != null)
			{
				strSql1.Append("ID,");
				strSql2.Append(""+model.ID+",");
			}
			if (model.i_AlarmType != null)
			{
				strSql1.Append("i_AlarmType,");
				strSql2.Append(""+model.i_AlarmType+",");
			}
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
			if (model.i_IsPreAlarm != null)
			{
				strSql1.Append("i_IsPreAlarm,");
				strSql2.Append(""+model.i_IsPreAlarm+",");
			}
			if (model.dt_Start != null)
			{
				strSql1.Append("dt_Start,");
				strSql2.Append("'"+model.dt_Start+"',");
			}
			if (model.dt_End != null)
			{
				strSql1.Append("dt_End,");
				strSql2.Append("'"+model.dt_End+"',");
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
			if (model.vc_Name != null)
			{
				strSql1.Append("vc_Name,");
				strSql2.Append("'"+model.vc_Name+"',");
			}
			if (model.vc_Code != null)
			{
				strSql1.Append("vc_Code,");
				strSql2.Append("'"+model.vc_Code+"',");
			}
			if (model.vc_PlanCode != null)
			{
				strSql1.Append("vc_PlanCode,");
				strSql2.Append("'"+model.vc_PlanCode+"',");
			}
			if (model.dt_LastMaintainDateTIme != null)
			{
				strSql1.Append("dt_LastMaintainDateTIme,");
				strSql2.Append("'"+model.dt_LastMaintainDateTIme+"',");
			}
			if (model.dt_ScrapDateTime != null)
			{
				strSql1.Append("dt_ScrapDateTime,");
				strSql2.Append("'"+model.dt_ScrapDateTime+"',");
			}
			if (model.i_MaintainInterval != null)
			{
				strSql1.Append("i_MaintainInterval,");
				strSql2.Append(""+model.i_MaintainInterval+",");
			}
			if (model.LocalizerStationName != null)
			{
				strSql1.Append("LocalizerStationName,");
				strSql2.Append("'"+model.LocalizerStationName+"',");
			}
			if (model.ApplyDepartmentName != null)
			{
				strSql1.Append("ApplyDepartmentName,");
				strSql2.Append("'"+model.ApplyDepartmentName+"',");
			}
			if (model.CheckPersonName != null)
			{
				strSql1.Append("CheckPersonName,");
				strSql2.Append("'"+model.CheckPersonName+"',");
			}
			if (model.PlanGiveCarDepartmentName != null)
			{
				strSql1.Append("PlanGiveCarDepartmentName,");
				strSql2.Append("'"+model.PlanGiveCarDepartmentName+"',");
			}
			if (model.dt_PlanGiveCarDateTime != null)
			{
				strSql1.Append("dt_PlanGiveCarDateTime,");
				strSql2.Append("'"+model.dt_PlanGiveCarDateTime+"',");
			}
			if (model.PlanLoadDepartmentName != null)
			{
				strSql1.Append("PlanLoadDepartmentName,");
				strSql2.Append("'"+model.PlanLoadDepartmentName+"',");
			}
			if (model.dt_PlanLoadDateTime != null)
			{
				strSql1.Append("dt_PlanLoadDateTime,");
				strSql2.Append("'"+model.dt_PlanLoadDateTime+"',");
			}
			if (model.ArriveDestinationAddressName != null)
			{
				strSql1.Append("ArriveDestinationAddressName,");
				strSql2.Append("'"+model.ArriveDestinationAddressName+"',");
			}
			if (model.dt_ArriveDestinationDateTime != null)
			{
				strSql1.Append("dt_ArriveDestinationDateTime,");
				strSql2.Append("'"+model.dt_ArriveDestinationDateTime+"',");
			}
			if (model.PlanBackDepartmentName != null)
			{
				strSql1.Append("PlanBackDepartmentName,");
				strSql2.Append("'"+model.PlanBackDepartmentName+"',");
			}
			if (model.dt_PlanBackDateTime != null)
			{
				strSql1.Append("dt_PlanBackDateTime,");
				strSql2.Append("'"+model.dt_PlanBackDateTime+"',");
			}
			strSql.Append("insert into v_VehicleAlarm(");
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
		public bool Update(DB_VehicleTransportManage.Model.v_VehicleAlarm model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update v_VehicleAlarm set ");
			if (model.ID != null)
			{
				strSql.Append("ID="+model.ID+",");
			}
			if (model.i_AlarmType != null)
			{
				strSql.Append("i_AlarmType="+model.i_AlarmType+",");
			}
			else
			{
				strSql.Append("i_AlarmType= null ,");
			}
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
			if (model.i_IsPreAlarm != null)
			{
				strSql.Append("i_IsPreAlarm="+model.i_IsPreAlarm+",");
			}
			else
			{
				strSql.Append("i_IsPreAlarm= null ,");
			}
			if (model.dt_Start != null)
			{
				strSql.Append("dt_Start='"+model.dt_Start+"',");
			}
			else
			{
				strSql.Append("dt_Start= null ,");
			}
			if (model.dt_End != null)
			{
				strSql.Append("dt_End='"+model.dt_End+"',");
			}
			else
			{
				strSql.Append("dt_End= null ,");
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
			if (model.vc_Name != null)
			{
				strSql.Append("vc_Name='"+model.vc_Name+"',");
			}
			else
			{
				strSql.Append("vc_Name= null ,");
			}
			if (model.vc_Code != null)
			{
				strSql.Append("vc_Code='"+model.vc_Code+"',");
			}
			else
			{
				strSql.Append("vc_Code= null ,");
			}
			if (model.vc_PlanCode != null)
			{
				strSql.Append("vc_PlanCode='"+model.vc_PlanCode+"',");
			}
			else
			{
				strSql.Append("vc_PlanCode= null ,");
			}
			if (model.dt_LastMaintainDateTIme != null)
			{
				strSql.Append("dt_LastMaintainDateTIme='"+model.dt_LastMaintainDateTIme+"',");
			}
			else
			{
				strSql.Append("dt_LastMaintainDateTIme= null ,");
			}
			if (model.dt_ScrapDateTime != null)
			{
				strSql.Append("dt_ScrapDateTime='"+model.dt_ScrapDateTime+"',");
			}
			else
			{
				strSql.Append("dt_ScrapDateTime= null ,");
			}
			if (model.i_MaintainInterval != null)
			{
				strSql.Append("i_MaintainInterval="+model.i_MaintainInterval+",");
			}
			else
			{
				strSql.Append("i_MaintainInterval= null ,");
			}
			if (model.LocalizerStationName != null)
			{
				strSql.Append("LocalizerStationName='"+model.LocalizerStationName+"',");
			}
			else
			{
				strSql.Append("LocalizerStationName= null ,");
			}
			if (model.ApplyDepartmentName != null)
			{
				strSql.Append("ApplyDepartmentName='"+model.ApplyDepartmentName+"',");
			}
			else
			{
				strSql.Append("ApplyDepartmentName= null ,");
			}
			if (model.CheckPersonName != null)
			{
				strSql.Append("CheckPersonName='"+model.CheckPersonName+"',");
			}
			else
			{
				strSql.Append("CheckPersonName= null ,");
			}
			if (model.PlanGiveCarDepartmentName != null)
			{
				strSql.Append("PlanGiveCarDepartmentName='"+model.PlanGiveCarDepartmentName+"',");
			}
			else
			{
				strSql.Append("PlanGiveCarDepartmentName= null ,");
			}
			if (model.dt_PlanGiveCarDateTime != null)
			{
				strSql.Append("dt_PlanGiveCarDateTime='"+model.dt_PlanGiveCarDateTime+"',");
			}
			else
			{
				strSql.Append("dt_PlanGiveCarDateTime= null ,");
			}
			if (model.PlanLoadDepartmentName != null)
			{
				strSql.Append("PlanLoadDepartmentName='"+model.PlanLoadDepartmentName+"',");
			}
			else
			{
				strSql.Append("PlanLoadDepartmentName= null ,");
			}
			if (model.dt_PlanLoadDateTime != null)
			{
				strSql.Append("dt_PlanLoadDateTime='"+model.dt_PlanLoadDateTime+"',");
			}
			else
			{
				strSql.Append("dt_PlanLoadDateTime= null ,");
			}
			if (model.ArriveDestinationAddressName != null)
			{
				strSql.Append("ArriveDestinationAddressName='"+model.ArriveDestinationAddressName+"',");
			}
			else
			{
				strSql.Append("ArriveDestinationAddressName= null ,");
			}
			if (model.dt_ArriveDestinationDateTime != null)
			{
				strSql.Append("dt_ArriveDestinationDateTime='"+model.dt_ArriveDestinationDateTime+"',");
			}
			else
			{
				strSql.Append("dt_ArriveDestinationDateTime= null ,");
			}
			if (model.PlanBackDepartmentName != null)
			{
				strSql.Append("PlanBackDepartmentName='"+model.PlanBackDepartmentName+"',");
			}
			else
			{
				strSql.Append("PlanBackDepartmentName= null ,");
			}
			if (model.dt_PlanBackDateTime != null)
			{
				strSql.Append("dt_PlanBackDateTime='"+model.dt_PlanBackDateTime+"',");
			}
			else
			{
				strSql.Append("dt_PlanBackDateTime= null ,");
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
			strSql.Append("delete from v_VehicleAlarm ");
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
		public DB_VehicleTransportManage.Model.v_VehicleAlarm GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,i_AlarmType,PlanID,VehicleID,i_IsPreAlarm,dt_Start,dt_End,vc_Memo,i_Flag,vc_Name,vc_Code,vc_PlanCode,dt_LastMaintainDateTIme,dt_ScrapDateTime,i_MaintainInterval,LocalizerStationName,ApplyDepartmentName,CheckPersonName,PlanGiveCarDepartmentName,dt_PlanGiveCarDateTime,PlanLoadDepartmentName,dt_PlanLoadDateTime,ArriveDestinationAddressName,dt_ArriveDestinationDateTime,PlanBackDepartmentName,dt_PlanBackDateTime ");
			strSql.Append(" from v_VehicleAlarm ");
			strSql.Append(" where " );
			DB_VehicleTransportManage.Model.v_VehicleAlarm model=new DB_VehicleTransportManage.Model.v_VehicleAlarm();
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
		public DB_VehicleTransportManage.Model.v_VehicleAlarm DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.v_VehicleAlarm model=new DB_VehicleTransportManage.Model.v_VehicleAlarm();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["i_AlarmType"]!=null && row["i_AlarmType"].ToString()!="")
				{
					model.i_AlarmType=int.Parse(row["i_AlarmType"].ToString());
				}
				if(row["PlanID"]!=null && row["PlanID"].ToString()!="")
				{
					model.PlanID=int.Parse(row["PlanID"].ToString());
				}
				if(row["VehicleID"]!=null && row["VehicleID"].ToString()!="")
				{
					model.VehicleID=int.Parse(row["VehicleID"].ToString());
				}
				if(row["i_IsPreAlarm"]!=null && row["i_IsPreAlarm"].ToString()!="")
				{
					model.i_IsPreAlarm=int.Parse(row["i_IsPreAlarm"].ToString());
				}
				if(row["dt_Start"]!=null && row["dt_Start"].ToString()!="")
				{
					model.dt_Start=DateTime.Parse(row["dt_Start"].ToString());
				}
				if(row["dt_End"]!=null && row["dt_End"].ToString()!="")
				{
					model.dt_End=DateTime.Parse(row["dt_End"].ToString());
				}
				if(row["vc_Memo"]!=null)
				{
					model.vc_Memo=row["vc_Memo"].ToString();
				}
				if(row["i_Flag"]!=null && row["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(row["i_Flag"].ToString());
				}
				if(row["vc_Name"]!=null)
				{
					model.vc_Name=row["vc_Name"].ToString();
				}
				if(row["vc_Code"]!=null)
				{
					model.vc_Code=row["vc_Code"].ToString();
				}
				if(row["vc_PlanCode"]!=null)
				{
					model.vc_PlanCode=row["vc_PlanCode"].ToString();
				}
				if(row["dt_LastMaintainDateTIme"]!=null && row["dt_LastMaintainDateTIme"].ToString()!="")
				{
					model.dt_LastMaintainDateTIme=DateTime.Parse(row["dt_LastMaintainDateTIme"].ToString());
				}
				if(row["dt_ScrapDateTime"]!=null && row["dt_ScrapDateTime"].ToString()!="")
				{
					model.dt_ScrapDateTime=DateTime.Parse(row["dt_ScrapDateTime"].ToString());
				}
				if(row["i_MaintainInterval"]!=null && row["i_MaintainInterval"].ToString()!="")
				{
					model.i_MaintainInterval=int.Parse(row["i_MaintainInterval"].ToString());
				}
				if(row["LocalizerStationName"]!=null)
				{
					model.LocalizerStationName=row["LocalizerStationName"].ToString();
				}
				if(row["ApplyDepartmentName"]!=null)
				{
					model.ApplyDepartmentName=row["ApplyDepartmentName"].ToString();
				}
				if(row["CheckPersonName"]!=null)
				{
					model.CheckPersonName=row["CheckPersonName"].ToString();
				}
				if(row["PlanGiveCarDepartmentName"]!=null)
				{
					model.PlanGiveCarDepartmentName=row["PlanGiveCarDepartmentName"].ToString();
				}
				if(row["dt_PlanGiveCarDateTime"]!=null && row["dt_PlanGiveCarDateTime"].ToString()!="")
				{
					model.dt_PlanGiveCarDateTime=DateTime.Parse(row["dt_PlanGiveCarDateTime"].ToString());
				}
				if(row["PlanLoadDepartmentName"]!=null)
				{
					model.PlanLoadDepartmentName=row["PlanLoadDepartmentName"].ToString();
				}
				if(row["dt_PlanLoadDateTime"]!=null && row["dt_PlanLoadDateTime"].ToString()!="")
				{
					model.dt_PlanLoadDateTime=DateTime.Parse(row["dt_PlanLoadDateTime"].ToString());
				}
				if(row["ArriveDestinationAddressName"]!=null)
				{
					model.ArriveDestinationAddressName=row["ArriveDestinationAddressName"].ToString();
				}
				if(row["dt_ArriveDestinationDateTime"]!=null && row["dt_ArriveDestinationDateTime"].ToString()!="")
				{
					model.dt_ArriveDestinationDateTime=DateTime.Parse(row["dt_ArriveDestinationDateTime"].ToString());
				}
				if(row["PlanBackDepartmentName"]!=null)
				{
					model.PlanBackDepartmentName=row["PlanBackDepartmentName"].ToString();
				}
				if(row["dt_PlanBackDateTime"]!=null && row["dt_PlanBackDateTime"].ToString()!="")
				{
					model.dt_PlanBackDateTime=DateTime.Parse(row["dt_PlanBackDateTime"].ToString());
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
			strSql.Append("select ID,i_AlarmType,PlanID,VehicleID,i_IsPreAlarm,dt_Start,dt_End,vc_Memo,i_Flag,vc_Name,vc_Code,vc_PlanCode,dt_LastMaintainDateTIme,dt_ScrapDateTime,i_MaintainInterval,LocalizerStationName,ApplyDepartmentName,CheckPersonName,PlanGiveCarDepartmentName,dt_PlanGiveCarDateTime,PlanLoadDepartmentName,dt_PlanLoadDateTime,ArriveDestinationAddressName,dt_ArriveDestinationDateTime,PlanBackDepartmentName,dt_PlanBackDateTime ");
			strSql.Append(" FROM v_VehicleAlarm ");
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
			strSql.Append(" ID,i_AlarmType,PlanID,VehicleID,i_IsPreAlarm,dt_Start,dt_End,vc_Memo,i_Flag,vc_Name,vc_Code,vc_PlanCode,dt_LastMaintainDateTIme,dt_ScrapDateTime,i_MaintainInterval,LocalizerStationName,ApplyDepartmentName,CheckPersonName,PlanGiveCarDepartmentName,dt_PlanGiveCarDateTime,PlanLoadDepartmentName,dt_PlanLoadDateTime,ArriveDestinationAddressName,dt_ArriveDestinationDateTime,PlanBackDepartmentName,dt_PlanBackDateTime ");
			strSql.Append(" FROM v_VehicleAlarm ");
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
			strSql.Append("select count(1) FROM v_VehicleAlarm ");
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
			strSql.Append(")AS Row, T.*  from v_VehicleAlarm T ");
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

