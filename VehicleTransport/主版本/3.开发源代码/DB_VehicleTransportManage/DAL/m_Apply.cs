/**  版本信息模板在安装目录下，可自行修改。
* m_Apply.cs
*
* 功 能： N/A
* 类 名： m_Apply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/28 15:58:19   N/A    初版
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
	/// 数据访问类:m_Apply
	/// </summary>
	public partial class m_Apply
	{
		public m_Apply()
		{}
		#region  Method

	
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DB_VehicleTransportManage.Model.m_Apply model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ApplyPersonID != null)
			{
				strSql1.Append("ApplyPersonID,");
				strSql2.Append(""+model.ApplyPersonID+",");
			}
			if (model.dt_ApplyDateTime != null)
			{
				strSql1.Append("dt_ApplyDateTime,");
				strSql2.Append("'"+model.dt_ApplyDateTime+"',");
			}
			if (model.vc_PlanUse != null)
			{
				strSql1.Append("vc_PlanUse,");
				strSql2.Append("'"+model.vc_PlanUse+"',");
			}
			if (model.i_State != null)
			{
				strSql1.Append("i_State,");
				strSql2.Append(""+model.i_State+",");
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
			if (model.i_IsUseMaterieApply != null)
			{
				strSql1.Append("i_IsUseMaterieApply,");
				strSql2.Append(""+model.i_IsUseMaterieApply+",");
			}
			if (model.ApplyDepartmentID != null)
			{
				strSql1.Append("ApplyDepartmentID,");
				strSql2.Append(""+model.ApplyDepartmentID+",");
			}
			if (model.vc_remark != null)
			{
				strSql1.Append("vc_remark,");
				strSql2.Append("'"+model.vc_remark+"',");
			}
			strSql.Append("insert into m_Apply(");
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
		public bool Update(DB_VehicleTransportManage.Model.m_Apply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_Apply set ");
			if (model.ApplyPersonID != null)
			{
				strSql.Append("ApplyPersonID="+model.ApplyPersonID+",");
			}
			else
			{
				strSql.Append("ApplyPersonID= null ,");
			}
			if (model.dt_ApplyDateTime != null)
			{
				strSql.Append("dt_ApplyDateTime='"+model.dt_ApplyDateTime+"',");
			}
			else
			{
				strSql.Append("dt_ApplyDateTime= null ,");
			}
			if (model.vc_PlanUse != null)
			{
				strSql.Append("vc_PlanUse='"+model.vc_PlanUse+"',");
			}
			else
			{
				strSql.Append("vc_PlanUse= null ,");
			}
			if (model.i_State != null)
			{
				strSql.Append("i_State="+model.i_State+",");
			}
			else
			{
				strSql.Append("i_State= null ,");
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
			if (model.i_IsUseMaterieApply != null)
			{
				strSql.Append("i_IsUseMaterieApply="+model.i_IsUseMaterieApply+",");
			}
			else
			{
				strSql.Append("i_IsUseMaterieApply= null ,");
			}
			if (model.ApplyDepartmentID != null)
			{
				strSql.Append("ApplyDepartmentID="+model.ApplyDepartmentID+",");
			}
			else
			{
				strSql.Append("ApplyDepartmentID= null ,");
			}
			if (model.vc_remark != null)
			{
				strSql.Append("vc_remark='"+model.vc_remark+"',");
			}
			else
			{
				strSql.Append("vc_remark= null ,");
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
			strSql.Append("delete from m_Apply ");
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
			strSql.Append("delete from m_Apply ");
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
		public DB_VehicleTransportManage.Model.m_Apply GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,ApplyPersonID,dt_ApplyDateTime,vc_PlanUse,i_State,dt_ArriveDestinationDateTime,ArriveDestinationAddressID,i_IsUseMaterieApply,ApplyDepartmentID,vc_remark ");
			strSql.Append(" from m_Apply ");
			strSql.Append(" where ID="+ID+"" );
			DB_VehicleTransportManage.Model.m_Apply model=new DB_VehicleTransportManage.Model.m_Apply();
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
		public DB_VehicleTransportManage.Model.m_Apply DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.m_Apply model=new DB_VehicleTransportManage.Model.m_Apply();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ApplyPersonID"]!=null && row["ApplyPersonID"].ToString()!="")
				{
					model.ApplyPersonID=int.Parse(row["ApplyPersonID"].ToString());
				}
				if(row["dt_ApplyDateTime"]!=null && row["dt_ApplyDateTime"].ToString()!="")
				{
					model.dt_ApplyDateTime=DateTime.Parse(row["dt_ApplyDateTime"].ToString());
				}
				if(row["vc_PlanUse"]!=null)
				{
					model.vc_PlanUse=row["vc_PlanUse"].ToString();
				}
				if(row["i_State"]!=null && row["i_State"].ToString()!="")
				{
					model.i_State=int.Parse(row["i_State"].ToString());
				}
				if(row["dt_ArriveDestinationDateTime"]!=null && row["dt_ArriveDestinationDateTime"].ToString()!="")
				{
					model.dt_ArriveDestinationDateTime=DateTime.Parse(row["dt_ArriveDestinationDateTime"].ToString());
				}
				if(row["ArriveDestinationAddressID"]!=null && row["ArriveDestinationAddressID"].ToString()!="")
				{
					model.ArriveDestinationAddressID=int.Parse(row["ArriveDestinationAddressID"].ToString());
				}
				if(row["i_IsUseMaterieApply"]!=null && row["i_IsUseMaterieApply"].ToString()!="")
				{
					model.i_IsUseMaterieApply=int.Parse(row["i_IsUseMaterieApply"].ToString());
				}
				if(row["ApplyDepartmentID"]!=null && row["ApplyDepartmentID"].ToString()!="")
				{
					model.ApplyDepartmentID=int.Parse(row["ApplyDepartmentID"].ToString());
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
			strSql.Append("select ID,ApplyPersonID,dt_ApplyDateTime,vc_PlanUse,i_State,dt_ArriveDestinationDateTime,ArriveDestinationAddressID,i_IsUseMaterieApply,ApplyDepartmentID,vc_remark ");
			strSql.Append(" FROM m_Apply ");
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
			strSql.Append(" ID,ApplyPersonID,dt_ApplyDateTime,vc_PlanUse,i_State,dt_ArriveDestinationDateTime,ArriveDestinationAddressID,i_IsUseMaterieApply,ApplyDepartmentID,vc_remark ");
			strSql.Append(" FROM m_Apply ");
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

