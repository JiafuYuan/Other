/**  版本信息模板在安装目录下，可自行修改。
* v_AreaVehicle.cs
*
* 功 能： N/A
* 类 名： v_AreaVehicle
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/23 15:56:04   N/A    初版
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
	/// 数据访问类:v_AreaVehicle
	/// </summary>
	public partial class v_AreaVehicle
	{
		public v_AreaVehicle()
		{}
		#region  Method

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DB_VehicleTransportManage.Model.v_AreaVehicle GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" AreaID,AreaName,EmptyVehicle,WeightVehicle ");
			strSql.Append(" from v_AreaVehicle ");
			strSql.Append(" where " );
			DB_VehicleTransportManage.Model.v_AreaVehicle model=new DB_VehicleTransportManage.Model.v_AreaVehicle();
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
		public DB_VehicleTransportManage.Model.v_AreaVehicle DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.v_AreaVehicle model=new DB_VehicleTransportManage.Model.v_AreaVehicle();
			if (row != null)
			{
				if(row["AreaID"]!=null && row["AreaID"].ToString()!="")
				{
					model.AreaID=int.Parse(row["AreaID"].ToString());
				}
				if(row["AreaName"]!=null)
				{
					model.AreaName=row["AreaName"].ToString();
				}
				if(row["EmptyVehicle"]!=null && row["EmptyVehicle"].ToString()!="")
				{
					model.EmptyVehicle=int.Parse(row["EmptyVehicle"].ToString());
				}
				if(row["WeightVehicle"]!=null && row["WeightVehicle"].ToString()!="")
				{
					model.WeightVehicle=int.Parse(row["WeightVehicle"].ToString());
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
			strSql.Append("select AreaID,AreaName,EmptyVehicle,WeightVehicle ");
			strSql.Append(" FROM v_AreaVehicle ");
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
			strSql.Append(" AreaID,AreaName,EmptyVehicle,WeightVehicle ");
			strSql.Append(" FROM v_AreaVehicle ");
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
			strSql.Append(")AS Row, T.*  from v_AreaVehicle T ");
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

