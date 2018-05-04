/**  版本信息模板在安装目录下，可自行修改。
* m_Vehicle.cs
*
* 功 能： N/A
* 类 名： m_Vehicle
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-14 16:48:07   N/A    初版
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
	/// 数据访问类:m_Vehicle
	/// </summary>
	public partial class m_Vehicle
	{
		public m_Vehicle()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DB_VehicleTransportManage.Model.m_Vehicle model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.vc_Code != null)
			{
				strSql1.Append("vc_Code,");
				strSql2.Append("'"+model.vc_Code+"',");
			}
			if (model.vc_Name != null)
			{
				strSql1.Append("vc_Name,");
				strSql2.Append("'"+model.vc_Name+"',");
			}
			if (model.VehicleTypeID != null)
			{
				strSql1.Append("VehicleTypeID,");
				strSql2.Append(""+model.VehicleTypeID+",");
			}
			if (model.DepartmentID != null)
			{
				strSql1.Append("DepartmentID,");
				strSql2.Append(""+model.DepartmentID+",");
			}
            if (model.i_LastLocalizerStationID != null)
            {
                strSql1.Append("i_LastLocalizerStationID,");
                strSql2.Append("" + model.i_LastLocalizerStationID + ",");
            }
			if (model.i_State != null)
			{
				strSql1.Append("i_State,");
				strSql2.Append(""+model.i_State+",");
			}
			if (model.i_SafeLoad != null)
			{
				strSql1.Append("i_SafeLoad,");
				strSql2.Append(""+model.i_SafeLoad+",");
			}
            if (model.i_LocalizerStationIDChanaged != null)
            {
                strSql1.Append("i_LocalizerStationIDChanaged,");
                strSql2.Append("" + model.i_LocalizerStationIDChanaged + ",");
            }
			if (model.i_LocalizerStationID != null)
			{
				strSql1.Append("i_LocalizerStationID,");
				strSql2.Append(""+model.i_LocalizerStationID+",");
			}
			if (model.dt_InLocalizerStationDateTime != null)
			{
				strSql1.Append("dt_InLocalizerStationDateTime,");
				strSql2.Append("'"+model.dt_InLocalizerStationDateTime+"',");
			}
			if (model.i_MaintainInterval != null)
			{
				strSql1.Append("i_MaintainInterval,");
				strSql2.Append(""+model.i_MaintainInterval+",");
			}
			if (model.dt_ScrapDateTime != null)
			{
				strSql1.Append("dt_ScrapDateTime,");
				strSql2.Append("'"+model.dt_ScrapDateTime+"',");
			}
			if (model.dt_CreateDateTime != null)
			{
				strSql1.Append("dt_CreateDateTime,");
				strSql2.Append("'"+model.dt_CreateDateTime+"',");
			}
			if (model.dt_LastMaintainDateTIme != null)
			{
				strSql1.Append("dt_LastMaintainDateTIme,");
				strSql2.Append("'"+model.dt_LastMaintainDateTIme+"',");
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
			strSql.Append("insert into m_Vehicle(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
            
			object obj =DB.OleDbHelper.ExecuteScale(strSql.ToString());
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
		public bool Update(DB_VehicleTransportManage.Model.m_Vehicle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_Vehicle set ");
			if (model.vc_Code != null)
			{
				strSql.Append("vc_Code='"+model.vc_Code+"',");
			}
			else
			{
				strSql.Append("vc_Code= null ,");
			}
			if (model.vc_Name != null)
			{
				strSql.Append("vc_Name='"+model.vc_Name+"',");
			}
			else
			{
				strSql.Append("vc_Name= null ,");
			}
			if (model.VehicleTypeID != null)
			{
				strSql.Append("VehicleTypeID="+model.VehicleTypeID+",");
			}
			else
			{
				strSql.Append("VehicleTypeID= null ,");
			}
			if (model.DepartmentID != null)
			{
				strSql.Append("DepartmentID="+model.DepartmentID+",");
			}
			else
			{
				strSql.Append("DepartmentID= null ,");
			}
			if (model.i_State != null)
			{
				strSql.Append("i_State="+model.i_State+",");
			}
			if (model.i_SafeLoad != null)
			{
				strSql.Append("i_SafeLoad="+model.i_SafeLoad+",");
			}
			else
			{
				strSql.Append("i_SafeLoad= null ,");
			}

            if (model.i_LocalizerStationIDChanaged != null)
            {
                strSql.Append("i_LocalizerStationIDChanaged=" + model.i_LocalizerStationIDChanaged + ",");
            }
            else
            {
                strSql.Append("i_LocalizerStationIDChanaged= null ,");
            }

			if (model.i_LocalizerStationID != null)
			{
				strSql.Append("i_LocalizerStationID="+model.i_LocalizerStationID+",");
			}
			if (model.dt_InLocalizerStationDateTime != null)
			{
				strSql.Append("dt_InLocalizerStationDateTime='"+model.dt_InLocalizerStationDateTime+"',");
			}
			else
			{
				strSql.Append("dt_InLocalizerStationDateTime= null ,");
			}
			if (model.i_MaintainInterval != null)
			{
				strSql.Append("i_MaintainInterval="+model.i_MaintainInterval+",");
			}
			else
			{
				strSql.Append("i_MaintainInterval= null ,");
			}
			if (model.dt_ScrapDateTime != null)
			{
				strSql.Append("dt_ScrapDateTime='"+model.dt_ScrapDateTime+"',");
			}
			else
			{
				strSql.Append("dt_ScrapDateTime= null ,");
			}
			if (model.dt_CreateDateTime != null)
			{
				strSql.Append("dt_CreateDateTime='"+model.dt_CreateDateTime+"',");
			}
			else
			{
				strSql.Append("dt_CreateDateTime= null ,");
			}
			if (model.dt_LastMaintainDateTIme != null)
			{
				strSql.Append("dt_LastMaintainDateTIme='"+model.dt_LastMaintainDateTIme+"',");
			}
			else
			{
				strSql.Append("dt_LastMaintainDateTIme= null ,");
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

            if (model.i_LastLocalizerStationID != null)
            {
                strSql.Append("i_LastLocalizerStationID=" + model.i_LastLocalizerStationID + ",");
            }
            else
            {
                strSql.Append("i_LastLocalizerStationID= null ,");
            }

			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ID="+ model.ID+"");
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
		public bool Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_Vehicle ");
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
			strSql.Append("delete from m_Vehicle ");
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
		public DB_VehicleTransportManage.Model.m_Vehicle GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
            strSql.Append(" ID,vc_Code,vc_Name,VehicleTypeID,DepartmentID,i_LocalizerStationIDChanaged,i_LastLocalizerStationID,i_State,i_SafeLoad,i_LocalizerStationID,dt_InLocalizerStationDateTime,i_MaintainInterval,dt_ScrapDateTime,dt_CreateDateTime,dt_LastMaintainDateTIme,vc_Memo,i_Flag ");
			strSql.Append(" from m_Vehicle ");
			strSql.Append(" where ID="+ID+"" );
			DB_VehicleTransportManage.Model.m_Vehicle model=new DB_VehicleTransportManage.Model.m_Vehicle();
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
		public DB_VehicleTransportManage.Model.m_Vehicle DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.m_Vehicle model=new DB_VehicleTransportManage.Model.m_Vehicle();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["vc_Code"]!=null)
				{
					model.vc_Code=row["vc_Code"].ToString();
				}
				if(row["vc_Name"]!=null)
				{
					model.vc_Name=row["vc_Name"].ToString();
				}
				if(row["VehicleTypeID"]!=null && row["VehicleTypeID"].ToString()!="")
				{
					model.VehicleTypeID=int.Parse(row["VehicleTypeID"].ToString());
				}
				if(row["DepartmentID"]!=null && row["DepartmentID"].ToString()!="")
				{
					model.DepartmentID=int.Parse(row["DepartmentID"].ToString());
				}
				if(row["i_State"]!=null && row["i_State"].ToString()!="")
				{
					model.i_State=int.Parse(row["i_State"].ToString());
				}
				if(row["i_SafeLoad"]!=null && row["i_SafeLoad"].ToString()!="")
				{
					model.i_SafeLoad=int.Parse(row["i_SafeLoad"].ToString());
				}

                if (row["i_LocalizerStationIDChanaged"] != null && row["i_LocalizerStationIDChanaged"].ToString() != "")
                {
                    model.i_LocalizerStationIDChanaged = int.Parse(row["i_LocalizerStationIDChanaged"].ToString());
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
                if (row["i_LastLocalizerStationID"] != null && row["i_LastLocalizerStationID"].ToString() != "")
                {
                    model.i_LastLocalizerStationID = int.Parse(row["i_LastLocalizerStationID"].ToString());
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
            strSql.Append("select ID,vc_Code,vc_Name,VehicleTypeID,DepartmentID,i_LocalizerStationIDChanaged,i_LastLocalizerStationID,i_State,i_SafeLoad,i_LocalizerStationID,dt_InLocalizerStationDateTime,i_MaintainInterval,dt_ScrapDateTime,dt_CreateDateTime,dt_LastMaintainDateTIme,vc_Memo,i_Flag ");
			strSql.Append(" FROM m_Vehicle ");
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
            strSql.Append(" ID,vc_Code,vc_Name,VehicleTypeID,DepartmentID,i_LastLocalizerStationID,i_LocalizerStationIDChanaged,i_State,i_SafeLoad,i_LocalizerStationID,dt_InLocalizerStationDateTime,i_MaintainInterval,dt_ScrapDateTime,dt_CreateDateTime,dt_LastMaintainDateTIme,vc_Memo,i_Flag ");
			strSql.Append(" FROM m_Vehicle ");
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
			strSql.Append("select count(1) FROM m_Vehicle ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj =DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from m_Vehicle T ");
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

