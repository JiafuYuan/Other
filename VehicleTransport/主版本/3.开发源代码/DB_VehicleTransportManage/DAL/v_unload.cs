/**  版本信息模板在安装目录下，可自行修改。
* v_unload.cs
*
* 功 能： N/A
* 类 名： v_unload
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/31 9:03:30   N/A    初版
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
	/// 数据访问类:v_unload
	/// </summary>
	public partial class v_unload
	{
		public v_unload()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DB_VehicleTransportManage.Model.v_unload model)
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
			if (model.carcode != null)
			{
				strSql1.Append("carcode,");
				strSql2.Append("'"+model.carcode+"',");
			}
			if (model.PersonID != null)
			{
				strSql1.Append("PersonID,");
				strSql2.Append(""+model.PersonID+",");
			}
			if (model.personname != null)
			{
				strSql1.Append("personname,");
				strSql2.Append("'"+model.personname+"',");
			}
			if (model.dt_DateTime != null)
			{
				strSql1.Append("dt_DateTime,");
				strSql2.Append("'"+model.dt_DateTime+"',");
			}
			if (model.MaterieTypeID != null)
			{
				strSql1.Append("MaterieTypeID,");
				strSql2.Append(""+model.MaterieTypeID+",");
			}
			if (model.matername != null)
			{
				strSql1.Append("matername,");
				strSql2.Append("'"+model.matername+"',");
			}
			if (model.n_Count != null)
			{
				strSql1.Append("n_Count,");
				strSql2.Append(""+model.n_Count+",");
			}
			strSql.Append("insert into v_unload(");
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
		public bool Update(DB_VehicleTransportManage.Model.v_unload model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update v_unload set ");
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
			if (model.carcode != null)
			{
				strSql.Append("carcode='"+model.carcode+"',");
			}
			else
			{
				strSql.Append("carcode= null ,");
			}
			if (model.PersonID != null)
			{
				strSql.Append("PersonID="+model.PersonID+",");
			}
			else
			{
				strSql.Append("PersonID= null ,");
			}
			if (model.personname != null)
			{
				strSql.Append("personname='"+model.personname+"',");
			}
			else
			{
				strSql.Append("personname= null ,");
			}
			if (model.dt_DateTime != null)
			{
				strSql.Append("dt_DateTime='"+model.dt_DateTime+"',");
			}
			else
			{
				strSql.Append("dt_DateTime= null ,");
			}
			if (model.MaterieTypeID != null)
			{
				strSql.Append("MaterieTypeID="+model.MaterieTypeID+",");
			}
			else
			{
				strSql.Append("MaterieTypeID= null ,");
			}
			if (model.matername != null)
			{
				strSql.Append("matername='"+model.matername+"',");
			}
			else
			{
				strSql.Append("matername= null ,");
			}
			if (model.n_Count != null)
			{
				strSql.Append("n_Count="+model.n_Count+",");
			}
			else
			{
				strSql.Append("n_Count= null ,");
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
			strSql.Append("delete from v_unload ");
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
		public DB_VehicleTransportManage.Model.v_unload GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" PlanID,VehicleID,carcode,PersonID,personname,dt_DateTime,MaterieTypeID,matername,n_Count ");
			strSql.Append(" from v_unload ");
			strSql.Append(" where " );
			DB_VehicleTransportManage.Model.v_unload model=new DB_VehicleTransportManage.Model.v_unload();
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
		public DB_VehicleTransportManage.Model.v_unload DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.v_unload model=new DB_VehicleTransportManage.Model.v_unload();
			if (row != null)
			{
				if(row["PlanID"]!=null && row["PlanID"].ToString()!="")
				{
					model.PlanID=int.Parse(row["PlanID"].ToString());
				}
				if(row["VehicleID"]!=null && row["VehicleID"].ToString()!="")
				{
					model.VehicleID=int.Parse(row["VehicleID"].ToString());
				}
				if(row["carcode"]!=null)
				{
					model.carcode=row["carcode"].ToString();
				}
				if(row["PersonID"]!=null && row["PersonID"].ToString()!="")
				{
					model.PersonID=int.Parse(row["PersonID"].ToString());
				}
				if(row["personname"]!=null)
				{
					model.personname=row["personname"].ToString();
				}
				if(row["dt_DateTime"]!=null && row["dt_DateTime"].ToString()!="")
				{
					model.dt_DateTime=DateTime.Parse(row["dt_DateTime"].ToString());
				}
				if(row["MaterieTypeID"]!=null && row["MaterieTypeID"].ToString()!="")
				{
					model.MaterieTypeID=int.Parse(row["MaterieTypeID"].ToString());
				}
				if(row["matername"]!=null)
				{
					model.matername=row["matername"].ToString();
				}
				if(row["n_Count"]!=null && row["n_Count"].ToString()!="")
				{
					model.n_Count=decimal.Parse(row["n_Count"].ToString());
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
			strSql.Append("select PlanID,VehicleID,carcode,PersonID,personname,dt_DateTime,MaterieTypeID,matername,n_Count ");
			strSql.Append(" FROM v_unload ");
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
			strSql.Append(" PlanID,VehicleID,carcode,PersonID,personname,dt_DateTime,MaterieTypeID,matername,n_Count ");
			strSql.Append(" FROM v_unload ");
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
			strSql.Append("select count(1) FROM v_unload ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DB.OleDbHelper.GetDataSet(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from v_unload T ");
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

