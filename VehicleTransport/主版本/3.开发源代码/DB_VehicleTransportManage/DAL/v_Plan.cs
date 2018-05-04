/**  版本信息模板在安装目录下，可自行修改。
* v_Plan.cs
*
* 功 能： N/A
* 类 名： v_Plan
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/4 16:33:10   N/A    初版
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
	/// 数据访问类:v_Plan
	/// </summary>
	public partial class v_Plan
	{
		public v_Plan()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DB_VehicleTransportManage.Model.v_Plan model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ID != null)
			{
				strSql1.Append("ID,");
				strSql2.Append(""+model.ID+",");
			}
			if (model.dt_ArriveDestinationDateTime != null)
			{
				strSql1.Append("dt_ArriveDestinationDateTime,");
				strSql2.Append("'"+model.dt_ArriveDestinationDateTime+"',");
			}
			if (model.ArriveDestinationAddressID != null)
			{
				strSql1.Append("ArriveDestinationAddressID,");
				strSql2.Append(""+model.ArriveDestinationAddressID+",");
			}
			if (model.i_State != null)
			{
				strSql1.Append("i_State,");
				strSql2.Append(""+model.i_State+",");
			}
			if (model.ApplyID != null)
			{
				strSql1.Append("ApplyID,");
				strSql2.Append(""+model.ApplyID+",");
			}
			if (model.i_IsTemPlan != null)
			{
				strSql1.Append("i_IsTemPlan,");
				strSql2.Append(""+model.i_IsTemPlan+",");
			}
			if (model.vc_PlanCode != null)
			{
				strSql1.Append("vc_PlanCode,");
				strSql2.Append("'"+model.vc_PlanCode+"',");
			}
			if (model.CheckPersonID != null)
			{
				strSql1.Append("CheckPersonID,");
				strSql2.Append(""+model.CheckPersonID+",");
			}
			if (model.dt_CheckDateTime != null)
			{
				strSql1.Append("dt_CheckDateTime,");
				strSql2.Append("'"+model.dt_CheckDateTime+"',");
			}
			if (model.PlanGiveCarDepartmentID != null)
			{
				strSql1.Append("PlanGiveCarDepartmentID,");
				strSql2.Append(""+model.PlanGiveCarDepartmentID+",");
			}
			if (model.vc_PDAUserIDs != null)
			{
				strSql1.Append("vc_PDAUserIDs,");
				strSql2.Append("'"+model.vc_PDAUserIDs+"',");
			}
			if (model.dt_PlanGiveCarDateTime != null)
			{
				strSql1.Append("dt_PlanGiveCarDateTime,");
				strSql2.Append("'"+model.dt_PlanGiveCarDateTime+"',");
			}
			if (model.PlanGiveCarAddressID != null)
			{
				strSql1.Append("PlanGiveCarAddressID,");
				strSql2.Append(""+model.PlanGiveCarAddressID+",");
			}
			if (model.PlanUnLoadDepartmentID != null)
			{
				strSql1.Append("PlanUnLoadDepartmentID,");
				strSql2.Append(""+model.PlanUnLoadDepartmentID+",");
			}
			if (model.PlanBackDepartmentID != null)
			{
				strSql1.Append("PlanBackDepartmentID,");
				strSql2.Append(""+model.PlanBackDepartmentID+",");
			}
			if (model.dt_PlanBackDateTime != null)
			{
				strSql1.Append("dt_PlanBackDateTime,");
				strSql2.Append("'"+model.dt_PlanBackDateTime+"',");
			}
			if (model.PlanBackAddressID != null)
			{
				strSql1.Append("PlanBackAddressID,");
				strSql2.Append(""+model.PlanBackAddressID+",");
			}
			if (model.PlanLoadDepartmentID != null)
			{
				strSql1.Append("PlanLoadDepartmentID,");
				strSql2.Append(""+model.PlanLoadDepartmentID+",");
			}
			if (model.PlanLoadAddressID != null)
			{
				strSql1.Append("PlanLoadAddressID,");
				strSql2.Append(""+model.PlanLoadAddressID+",");
			}
			if (model.RealGiveCarDepartmentID != null)
			{
				strSql1.Append("RealGiveCarDepartmentID,");
				strSql2.Append(""+model.RealGiveCarDepartmentID+",");
			}
			if (model.dt_RealGiveCarDateTime != null)
			{
				strSql1.Append("dt_RealGiveCarDateTime,");
				strSql2.Append("'"+model.dt_RealGiveCarDateTime+"',");
			}
			if (model.RealGiveCarAddressID != null)
			{
				strSql1.Append("RealGiveCarAddressID,");
				strSql2.Append(""+model.RealGiveCarAddressID+",");
			}
			if (model.RealLoadDepartmentID != null)
			{
				strSql1.Append("RealLoadDepartmentID,");
				strSql2.Append(""+model.RealLoadDepartmentID+",");
			}
			if (model.RealGiveCarPersonID != null)
			{
				strSql1.Append("RealGiveCarPersonID,");
				strSql2.Append(""+model.RealGiveCarPersonID+",");
			}
			if (model.RealLoadPersonID != null)
			{
				strSql1.Append("RealLoadPersonID,");
				strSql2.Append(""+model.RealLoadPersonID+",");
			}
			if (model.ApplyDepartmentID != null)
			{
				strSql1.Append("ApplyDepartmentID,");
				strSql2.Append(""+model.ApplyDepartmentID+",");
			}
			if (model.ApplyPersonID != null)
			{
				strSql1.Append("ApplyPersonID,");
				strSql2.Append(""+model.ApplyPersonID+",");
			}
			if (model.dt_RealLoadDateTime != null)
			{
				strSql1.Append("dt_RealLoadDateTime,");
				strSql2.Append("'"+model.dt_RealLoadDateTime+"',");
			}
			if (model.RealLoadAddressID != null)
			{
				strSql1.Append("RealLoadAddressID,");
				strSql2.Append(""+model.RealLoadAddressID+",");
			}
			if (model.dt_RealArriveDestinationDateTime != null)
			{
				strSql1.Append("dt_RealArriveDestinationDateTime,");
				strSql2.Append("'"+model.dt_RealArriveDestinationDateTime+"',");
			}
			if (model.ApplyDepartmentName != null)
			{
				strSql1.Append("ApplyDepartmentName,");
				strSql2.Append("'"+model.ApplyDepartmentName+"',");
			}
			if (model.PlanLoadDepartmentName != null)
			{
				strSql1.Append("PlanLoadDepartmentName,");
				strSql2.Append("'"+model.PlanLoadDepartmentName+"',");
			}
			if (model.PlanGiveCarDepartmentName != null)
			{
				strSql1.Append("PlanGiveCarDepartmentName,");
				strSql2.Append("'"+model.PlanGiveCarDepartmentName+"',");
			}
			if (model.PlanUnLoadDepartmentName != null)
			{
				strSql1.Append("PlanUnLoadDepartmentName,");
				strSql2.Append("'"+model.PlanUnLoadDepartmentName+"',");
			}
			if (model.PlanBackDepartmentName != null)
			{
				strSql1.Append("PlanBackDepartmentName,");
				strSql2.Append("'"+model.PlanBackDepartmentName+"',");
			}
			if (model.vc_Name != null)
			{
				strSql1.Append("vc_Name,");
				strSql2.Append("'"+model.vc_Name+"',");
			}
			if (model.RealGiveCarDepartmentName != null)
			{
				strSql1.Append("RealGiveCarDepartmentName,");
				strSql2.Append("'"+model.RealGiveCarDepartmentName+"',");
			}
			if (model.RealLoadDepartmentName != null)
			{
				strSql1.Append("RealLoadDepartmentName,");
				strSql2.Append("'"+model.RealLoadDepartmentName+"',");
			}
			if (model.ApplyPersonName != null)
			{
				strSql1.Append("ApplyPersonName,");
				strSql2.Append("'"+model.ApplyPersonName+"',");
			}
			if (model.CheckPersonName != null)
			{
				strSql1.Append("CheckPersonName,");
				strSql2.Append("'"+model.CheckPersonName+"',");
			}
			if (model.RealGiveCarPersonName != null)
			{
				strSql1.Append("RealGiveCarPersonName,");
				strSql2.Append("'"+model.RealGiveCarPersonName+"',");
			}
			if (model.RealLoadPersonName != null)
			{
				strSql1.Append("RealLoadPersonName,");
				strSql2.Append("'"+model.RealLoadPersonName+"',");
			}
			if (model.ArriveDestinationAddressName != null)
			{
				strSql1.Append("ArriveDestinationAddressName,");
				strSql2.Append("'"+model.ArriveDestinationAddressName+"',");
			}
			if (model.PlanLoadAddressName != null)
			{
				strSql1.Append("PlanLoadAddressName,");
				strSql2.Append("'"+model.PlanLoadAddressName+"',");
			}
			if (model.PlanGiveCarAddressName != null)
			{
				strSql1.Append("PlanGiveCarAddressName,");
				strSql2.Append("'"+model.PlanGiveCarAddressName+"',");
			}
			if (model.PlanBackAddressName != null)
			{
				strSql1.Append("PlanBackAddressName,");
				strSql2.Append("'"+model.PlanBackAddressName+"',");
			}
			if (model.Expr1 != null)
			{
				strSql1.Append("Expr1,");
				strSql2.Append("'"+model.Expr1+"',");
			}
			if (model.RealGiveCarAddressName != null)
			{
				strSql1.Append("RealGiveCarAddressName,");
				strSql2.Append("'"+model.RealGiveCarAddressName+"',");
			}
			if (model.RealLoadAddressName != null)
			{
				strSql1.Append("RealLoadAddressName,");
				strSql2.Append("'"+model.RealLoadAddressName+"',");
			}
			if (model.statename != null)
			{
				strSql1.Append("statename,");
				strSql2.Append("'"+model.statename+"',");
			}
			strSql.Append("insert into v_Plan(");
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
		public bool Update(DB_VehicleTransportManage.Model.v_Plan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update v_Plan set ");
			if (model.ID != null)
			{
				strSql.Append("ID="+model.ID+",");
			}
			if (model.dt_ArriveDestinationDateTime != null)
			{
				strSql.Append("dt_ArriveDestinationDateTime='"+model.dt_ArriveDestinationDateTime+"',");
			}
			else
			{
				strSql.Append("dt_ArriveDestinationDateTime= null ,");
			}
			if (model.ArriveDestinationAddressID != null)
			{
				strSql.Append("ArriveDestinationAddressID="+model.ArriveDestinationAddressID+",");
			}
			else
			{
				strSql.Append("ArriveDestinationAddressID= null ,");
			}
			if (model.i_State != null)
			{
				strSql.Append("i_State="+model.i_State+",");
			}
			else
			{
				strSql.Append("i_State= null ,");
			}
			if (model.ApplyID != null)
			{
				strSql.Append("ApplyID="+model.ApplyID+",");
			}
			else
			{
				strSql.Append("ApplyID= null ,");
			}
			if (model.i_IsTemPlan != null)
			{
				strSql.Append("i_IsTemPlan="+model.i_IsTemPlan+",");
			}
			else
			{
				strSql.Append("i_IsTemPlan= null ,");
			}
			if (model.vc_PlanCode != null)
			{
				strSql.Append("vc_PlanCode='"+model.vc_PlanCode+"',");
			}
			else
			{
				strSql.Append("vc_PlanCode= null ,");
			}
			if (model.CheckPersonID != null)
			{
				strSql.Append("CheckPersonID="+model.CheckPersonID+",");
			}
			else
			{
				strSql.Append("CheckPersonID= null ,");
			}
			if (model.dt_CheckDateTime != null)
			{
				strSql.Append("dt_CheckDateTime='"+model.dt_CheckDateTime+"',");
			}
			else
			{
				strSql.Append("dt_CheckDateTime= null ,");
			}
			if (model.PlanGiveCarDepartmentID != null)
			{
				strSql.Append("PlanGiveCarDepartmentID="+model.PlanGiveCarDepartmentID+",");
			}
			else
			{
				strSql.Append("PlanGiveCarDepartmentID= null ,");
			}
			if (model.vc_PDAUserIDs != null)
			{
				strSql.Append("vc_PDAUserIDs='"+model.vc_PDAUserIDs+"',");
			}
			else
			{
				strSql.Append("vc_PDAUserIDs= null ,");
			}
			if (model.dt_PlanGiveCarDateTime != null)
			{
				strSql.Append("dt_PlanGiveCarDateTime='"+model.dt_PlanGiveCarDateTime+"',");
			}
			else
			{
				strSql.Append("dt_PlanGiveCarDateTime= null ,");
			}
			if (model.PlanGiveCarAddressID != null)
			{
				strSql.Append("PlanGiveCarAddressID="+model.PlanGiveCarAddressID+",");
			}
			else
			{
				strSql.Append("PlanGiveCarAddressID= null ,");
			}
			if (model.PlanUnLoadDepartmentID != null)
			{
				strSql.Append("PlanUnLoadDepartmentID="+model.PlanUnLoadDepartmentID+",");
			}
			else
			{
				strSql.Append("PlanUnLoadDepartmentID= null ,");
			}
			if (model.PlanBackDepartmentID != null)
			{
				strSql.Append("PlanBackDepartmentID="+model.PlanBackDepartmentID+",");
			}
			else
			{
				strSql.Append("PlanBackDepartmentID= null ,");
			}
			if (model.dt_PlanBackDateTime != null)
			{
				strSql.Append("dt_PlanBackDateTime='"+model.dt_PlanBackDateTime+"',");
			}
			else
			{
				strSql.Append("dt_PlanBackDateTime= null ,");
			}
			if (model.PlanBackAddressID != null)
			{
				strSql.Append("PlanBackAddressID="+model.PlanBackAddressID+",");
			}
			else
			{
				strSql.Append("PlanBackAddressID= null ,");
			}
			if (model.PlanLoadDepartmentID != null)
			{
				strSql.Append("PlanLoadDepartmentID="+model.PlanLoadDepartmentID+",");
			}
			else
			{
				strSql.Append("PlanLoadDepartmentID= null ,");
			}
			if (model.PlanLoadAddressID != null)
			{
				strSql.Append("PlanLoadAddressID="+model.PlanLoadAddressID+",");
			}
			else
			{
				strSql.Append("PlanLoadAddressID= null ,");
			}
			if (model.RealGiveCarDepartmentID != null)
			{
				strSql.Append("RealGiveCarDepartmentID="+model.RealGiveCarDepartmentID+",");
			}
			else
			{
				strSql.Append("RealGiveCarDepartmentID= null ,");
			}
			if (model.dt_RealGiveCarDateTime != null)
			{
				strSql.Append("dt_RealGiveCarDateTime='"+model.dt_RealGiveCarDateTime+"',");
			}
			else
			{
				strSql.Append("dt_RealGiveCarDateTime= null ,");
			}
			if (model.RealGiveCarAddressID != null)
			{
				strSql.Append("RealGiveCarAddressID="+model.RealGiveCarAddressID+",");
			}
			else
			{
				strSql.Append("RealGiveCarAddressID= null ,");
			}
			if (model.RealLoadDepartmentID != null)
			{
				strSql.Append("RealLoadDepartmentID="+model.RealLoadDepartmentID+",");
			}
			else
			{
				strSql.Append("RealLoadDepartmentID= null ,");
			}
			if (model.RealGiveCarPersonID != null)
			{
				strSql.Append("RealGiveCarPersonID="+model.RealGiveCarPersonID+",");
			}
			else
			{
				strSql.Append("RealGiveCarPersonID= null ,");
			}
			if (model.RealLoadPersonID != null)
			{
				strSql.Append("RealLoadPersonID="+model.RealLoadPersonID+",");
			}
			else
			{
				strSql.Append("RealLoadPersonID= null ,");
			}
			if (model.ApplyDepartmentID != null)
			{
				strSql.Append("ApplyDepartmentID="+model.ApplyDepartmentID+",");
			}
			else
			{
				strSql.Append("ApplyDepartmentID= null ,");
			}
			if (model.ApplyPersonID != null)
			{
				strSql.Append("ApplyPersonID="+model.ApplyPersonID+",");
			}
			else
			{
				strSql.Append("ApplyPersonID= null ,");
			}
			if (model.dt_RealLoadDateTime != null)
			{
				strSql.Append("dt_RealLoadDateTime='"+model.dt_RealLoadDateTime+"',");
			}
			else
			{
				strSql.Append("dt_RealLoadDateTime= null ,");
			}
			if (model.RealLoadAddressID != null)
			{
				strSql.Append("RealLoadAddressID="+model.RealLoadAddressID+",");
			}
			else
			{
				strSql.Append("RealLoadAddressID= null ,");
			}
			if (model.dt_RealArriveDestinationDateTime != null)
			{
				strSql.Append("dt_RealArriveDestinationDateTime='"+model.dt_RealArriveDestinationDateTime+"',");
			}
			else
			{
				strSql.Append("dt_RealArriveDestinationDateTime= null ,");
			}
			if (model.ApplyDepartmentName != null)
			{
				strSql.Append("ApplyDepartmentName='"+model.ApplyDepartmentName+"',");
			}
			else
			{
				strSql.Append("ApplyDepartmentName= null ,");
			}
			if (model.PlanLoadDepartmentName != null)
			{
				strSql.Append("PlanLoadDepartmentName='"+model.PlanLoadDepartmentName+"',");
			}
			else
			{
				strSql.Append("PlanLoadDepartmentName= null ,");
			}
			if (model.PlanGiveCarDepartmentName != null)
			{
				strSql.Append("PlanGiveCarDepartmentName='"+model.PlanGiveCarDepartmentName+"',");
			}
			else
			{
				strSql.Append("PlanGiveCarDepartmentName= null ,");
			}
			if (model.PlanUnLoadDepartmentName != null)
			{
				strSql.Append("PlanUnLoadDepartmentName='"+model.PlanUnLoadDepartmentName+"',");
			}
			else
			{
				strSql.Append("PlanUnLoadDepartmentName= null ,");
			}
			if (model.PlanBackDepartmentName != null)
			{
				strSql.Append("PlanBackDepartmentName='"+model.PlanBackDepartmentName+"',");
			}
			else
			{
				strSql.Append("PlanBackDepartmentName= null ,");
			}
			if (model.vc_Name != null)
			{
				strSql.Append("vc_Name='"+model.vc_Name+"',");
			}
			else
			{
				strSql.Append("vc_Name= null ,");
			}
			if (model.RealGiveCarDepartmentName != null)
			{
				strSql.Append("RealGiveCarDepartmentName='"+model.RealGiveCarDepartmentName+"',");
			}
			else
			{
				strSql.Append("RealGiveCarDepartmentName= null ,");
			}
			if (model.RealLoadDepartmentName != null)
			{
				strSql.Append("RealLoadDepartmentName='"+model.RealLoadDepartmentName+"',");
			}
			else
			{
				strSql.Append("RealLoadDepartmentName= null ,");
			}
			if (model.ApplyPersonName != null)
			{
				strSql.Append("ApplyPersonName='"+model.ApplyPersonName+"',");
			}
			else
			{
				strSql.Append("ApplyPersonName= null ,");
			}
			if (model.CheckPersonName != null)
			{
				strSql.Append("CheckPersonName='"+model.CheckPersonName+"',");
			}
			else
			{
				strSql.Append("CheckPersonName= null ,");
			}
			if (model.RealGiveCarPersonName != null)
			{
				strSql.Append("RealGiveCarPersonName='"+model.RealGiveCarPersonName+"',");
			}
			else
			{
				strSql.Append("RealGiveCarPersonName= null ,");
			}
			if (model.RealLoadPersonName != null)
			{
				strSql.Append("RealLoadPersonName='"+model.RealLoadPersonName+"',");
			}
			else
			{
				strSql.Append("RealLoadPersonName= null ,");
			}
			if (model.ArriveDestinationAddressName != null)
			{
				strSql.Append("ArriveDestinationAddressName='"+model.ArriveDestinationAddressName+"',");
			}
			else
			{
				strSql.Append("ArriveDestinationAddressName= null ,");
			}
			if (model.PlanLoadAddressName != null)
			{
				strSql.Append("PlanLoadAddressName='"+model.PlanLoadAddressName+"',");
			}
			else
			{
				strSql.Append("PlanLoadAddressName= null ,");
			}
			if (model.PlanGiveCarAddressName != null)
			{
				strSql.Append("PlanGiveCarAddressName='"+model.PlanGiveCarAddressName+"',");
			}
			else
			{
				strSql.Append("PlanGiveCarAddressName= null ,");
			}
			if (model.PlanBackAddressName != null)
			{
				strSql.Append("PlanBackAddressName='"+model.PlanBackAddressName+"',");
			}
			else
			{
				strSql.Append("PlanBackAddressName= null ,");
			}
			if (model.Expr1 != null)
			{
				strSql.Append("Expr1='"+model.Expr1+"',");
			}
			else
			{
				strSql.Append("Expr1= null ,");
			}
			if (model.RealGiveCarAddressName != null)
			{
				strSql.Append("RealGiveCarAddressName='"+model.RealGiveCarAddressName+"',");
			}
			else
			{
				strSql.Append("RealGiveCarAddressName= null ,");
			}
			if (model.RealLoadAddressName != null)
			{
				strSql.Append("RealLoadAddressName='"+model.RealLoadAddressName+"',");
			}
			else
			{
				strSql.Append("RealLoadAddressName= null ,");
			}
			if (model.statename != null)
			{
				strSql.Append("statename='"+model.statename+"',");
			}
			else
			{
				strSql.Append("statename= null ,");
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
			strSql.Append("delete from v_Plan ");
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
		public DB_VehicleTransportManage.Model.v_Plan GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
            strSql.Append(" ID,dt_ArriveDestinationDateTime,ArriveDestinationAddressID,i_State,ApplyID,i_IsTemPlan,vc_PlanCode,CheckPersonID,dt_CheckDateTime,PlanGiveCarDepartmentID,vc_PDAUserIDs,dt_PlanGiveCarDateTime,PlanGiveCarAddressID,PlanUnLoadDepartmentID,PlanBackDepartmentID,dt_PlanBackDateTime,PlanBackAddressID,PlanLoadDepartmentID,PlanLoadAddressID,RealGiveCarDepartmentID,dt_RealGiveCarDateTime,RealGiveCarAddressID,RealLoadDepartmentID,RealGiveCarPersonID,RealLoadPersonID,ApplyDepartmentID,ApplyPersonID,dt_RealLoadDateTime,RealLoadAddressID,dt_RealArriveDestinationDateTime,ApplyDepartmentName,PlanLoadDepartmentName,PlanGiveCarDepartmentName,PlanUnLoadDepartmentName,PlanBackDepartmentName,vc_Name,RealGiveCarDepartmentName,RealLoadDepartmentName,ApplyPersonName,CheckPersonName,RealGiveCarPersonName,RealLoadPersonName,ArriveDestinationAddressName,PlanLoadAddressName,PlanGiveCarAddressName,PlanBackAddressName,Expr1,RealGiveCarAddressName,RealLoadAddressName,statename,dt_PlanLoadDateTime ");
			strSql.Append(" from v_Plan ");
            strSql.Append(" where ID=" + id);
			DB_VehicleTransportManage.Model.v_Plan model=new DB_VehicleTransportManage.Model.v_Plan();
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
		public DB_VehicleTransportManage.Model.v_Plan DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.v_Plan model=new DB_VehicleTransportManage.Model.v_Plan();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dt_ArriveDestinationDateTime"]!=null && row["dt_ArriveDestinationDateTime"].ToString()!="")
				{
					model.dt_ArriveDestinationDateTime=DateTime.Parse(row["dt_ArriveDestinationDateTime"].ToString());
				}
				if(row["ArriveDestinationAddressID"]!=null && row["ArriveDestinationAddressID"].ToString()!="")
				{
					model.ArriveDestinationAddressID=int.Parse(row["ArriveDestinationAddressID"].ToString());
				}
				if(row["i_State"]!=null && row["i_State"].ToString()!="")
				{
					model.i_State=int.Parse(row["i_State"].ToString());
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
				if(row["vc_PDAUserIDs"]!=null)
				{
					model.vc_PDAUserIDs=row["vc_PDAUserIDs"].ToString();
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
				if(row["RealGiveCarPersonID"]!=null && row["RealGiveCarPersonID"].ToString()!="")
				{
					model.RealGiveCarPersonID=int.Parse(row["RealGiveCarPersonID"].ToString());
				}
				if(row["RealLoadPersonID"]!=null && row["RealLoadPersonID"].ToString()!="")
				{
					model.RealLoadPersonID=int.Parse(row["RealLoadPersonID"].ToString());
				}
				if(row["ApplyDepartmentID"]!=null && row["ApplyDepartmentID"].ToString()!="")
				{
					model.ApplyDepartmentID=int.Parse(row["ApplyDepartmentID"].ToString());
				}
				if(row["ApplyPersonID"]!=null && row["ApplyPersonID"].ToString()!="")
				{
					model.ApplyPersonID=int.Parse(row["ApplyPersonID"].ToString());
				}
				if(row["dt_RealLoadDateTime"]!=null && row["dt_RealLoadDateTime"].ToString()!="")
				{
					model.dt_RealLoadDateTime=DateTime.Parse(row["dt_RealLoadDateTime"].ToString());
				}
                if (row["dt_PlanLoadDateTime"] != null && row["dt_PlanLoadDateTime"].ToString() != "")
                {
                    model.dt_PlanLoadDateTime = DateTime.Parse(row["dt_PlanLoadDateTime"].ToString());
                }
				if(row["RealLoadAddressID"]!=null && row["RealLoadAddressID"].ToString()!="")
				{
					model.RealLoadAddressID=int.Parse(row["RealLoadAddressID"].ToString());
				}
				if(row["dt_RealArriveDestinationDateTime"]!=null && row["dt_RealArriveDestinationDateTime"].ToString()!="")
				{
					model.dt_RealArriveDestinationDateTime=DateTime.Parse(row["dt_RealArriveDestinationDateTime"].ToString());
				}
				if(row["ApplyDepartmentName"]!=null)
				{
					model.ApplyDepartmentName=row["ApplyDepartmentName"].ToString();
				}
				if(row["PlanLoadDepartmentName"]!=null)
				{
					model.PlanLoadDepartmentName=row["PlanLoadDepartmentName"].ToString();
				}
				if(row["PlanGiveCarDepartmentName"]!=null)
				{
					model.PlanGiveCarDepartmentName=row["PlanGiveCarDepartmentName"].ToString();
				}
				if(row["PlanUnLoadDepartmentName"]!=null)
				{
					model.PlanUnLoadDepartmentName=row["PlanUnLoadDepartmentName"].ToString();
				}
				if(row["PlanBackDepartmentName"]!=null)
				{
					model.PlanBackDepartmentName=row["PlanBackDepartmentName"].ToString();
				}
				if(row["vc_Name"]!=null)
				{
					model.vc_Name=row["vc_Name"].ToString();
				}
				if(row["RealGiveCarDepartmentName"]!=null)
				{
					model.RealGiveCarDepartmentName=row["RealGiveCarDepartmentName"].ToString();
				}
				if(row["RealLoadDepartmentName"]!=null)
				{
					model.RealLoadDepartmentName=row["RealLoadDepartmentName"].ToString();
				}
				if(row["ApplyPersonName"]!=null)
				{
					model.ApplyPersonName=row["ApplyPersonName"].ToString();
				}
				if(row["CheckPersonName"]!=null)
				{
					model.CheckPersonName=row["CheckPersonName"].ToString();
				}
				if(row["RealGiveCarPersonName"]!=null)
				{
					model.RealGiveCarPersonName=row["RealGiveCarPersonName"].ToString();
				}
				if(row["RealLoadPersonName"]!=null)
				{
					model.RealLoadPersonName=row["RealLoadPersonName"].ToString();
				}
				if(row["ArriveDestinationAddressName"]!=null)
				{
					model.ArriveDestinationAddressName=row["ArriveDestinationAddressName"].ToString();
				}
				if(row["PlanLoadAddressName"]!=null)
				{
					model.PlanLoadAddressName=row["PlanLoadAddressName"].ToString();
				}
				if(row["PlanGiveCarAddressName"]!=null)
				{
					model.PlanGiveCarAddressName=row["PlanGiveCarAddressName"].ToString();
				}
				if(row["PlanBackAddressName"]!=null)
				{
					model.PlanBackAddressName=row["PlanBackAddressName"].ToString();
				}
				if(row["Expr1"]!=null)
				{
					model.Expr1=row["Expr1"].ToString();
				}
				if(row["RealGiveCarAddressName"]!=null)
				{
					model.RealGiveCarAddressName=row["RealGiveCarAddressName"].ToString();
				}
				if(row["RealLoadAddressName"]!=null)
				{
					model.RealLoadAddressName=row["RealLoadAddressName"].ToString();
				}
				if(row["statename"]!=null)
				{
					model.statename=row["statename"].ToString();
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
            strSql.Append("select ID,dt_ArriveDestinationDateTime,ArriveDestinationAddressID,i_State,ApplyID,i_IsTemPlan,vc_PlanCode,CheckPersonID,dt_CheckDateTime,PlanGiveCarDepartmentID,vc_PDAUserIDs,dt_PlanGiveCarDateTime,PlanGiveCarAddressID,PlanUnLoadDepartmentID,PlanBackDepartmentID,dt_PlanBackDateTime,PlanBackAddressID,PlanLoadDepartmentID,PlanLoadAddressID,RealGiveCarDepartmentID,dt_RealGiveCarDateTime,RealGiveCarAddressID,RealLoadDepartmentID,RealGiveCarPersonID,RealLoadPersonID,ApplyDepartmentID,ApplyPersonID,dt_RealLoadDateTime,RealLoadAddressID,dt_RealArriveDestinationDateTime,ApplyDepartmentName,PlanLoadDepartmentName,PlanGiveCarDepartmentName,PlanUnLoadDepartmentName,PlanBackDepartmentName,vc_Name,RealGiveCarDepartmentName,RealLoadDepartmentName,ApplyPersonName,CheckPersonName,RealGiveCarPersonName,RealLoadPersonName,ArriveDestinationAddressName,PlanLoadAddressName,PlanGiveCarAddressName,PlanBackAddressName,Expr1,RealGiveCarAddressName,RealLoadAddressName,statename,dt_PlanLoadDateTime ");
			strSql.Append(" FROM v_Plan ");
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
            strSql.Append(" ID,dt_ArriveDestinationDateTime,dt_PlanLoadDateTime,ArriveDestinationAddressID,i_State,ApplyID,i_IsTemPlan,vc_PlanCode,CheckPersonID,dt_CheckDateTime,PlanGiveCarDepartmentID,vc_PDAUserIDs,dt_PlanGiveCarDateTime,PlanGiveCarAddressID,PlanUnLoadDepartmentID,PlanBackDepartmentID,dt_PlanBackDateTime,PlanBackAddressID,PlanLoadDepartmentID,PlanLoadAddressID,RealGiveCarDepartmentID,dt_RealGiveCarDateTime,RealGiveCarAddressID,RealLoadDepartmentID,RealGiveCarPersonID,RealLoadPersonID,ApplyDepartmentID,ApplyPersonID,dt_RealLoadDateTime,RealLoadAddressID,dt_RealArriveDestinationDateTime,ApplyDepartmentName,PlanLoadDepartmentName,PlanGiveCarDepartmentName,PlanUnLoadDepartmentName,PlanBackDepartmentName,vc_Name,RealGiveCarDepartmentName,RealLoadDepartmentName,ApplyPersonName,CheckPersonName,RealGiveCarPersonName,RealLoadPersonName,ArriveDestinationAddressName,PlanLoadAddressName,PlanGiveCarAddressName,PlanBackAddressName,Expr1,RealGiveCarAddressName,RealLoadAddressName,statename ");
			strSql.Append(" FROM v_Plan ");
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
			strSql.Append("select count(1) FROM v_Plan ");
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
			strSql.Append(")AS Row, T.*  from v_Plan T ");
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

