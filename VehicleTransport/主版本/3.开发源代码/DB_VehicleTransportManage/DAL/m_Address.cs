/**  版本信息模板在安装目录下，可自行修改。
* m_Address.cs
*
* 功 能： N/A
* 类 名： m_Address
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/12 10:39:05   N/A    初版
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
	/// 数据访问类:m_Address
	/// </summary>
	public partial class m_Address
	{
		public m_Address()
		{}
		#region  Method

	

		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DB_VehicleTransportManage.Model.m_Address model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.vc_Name != null)
			{
				strSql1.Append("vc_Name,");
				strSql2.Append("'"+model.vc_Name+"',");
			}
			if (model.LocalizerStationID != null)
			{
				strSql1.Append("LocalizerStationID,");
				strSql2.Append(""+model.LocalizerStationID+",");
			}
			if (model.AreaID != null)
			{
				strSql1.Append("AreaID,");
				strSql2.Append(""+model.AreaID+",");
			}
			if (model.i_IsUpMine != null)
			{
				strSql1.Append("i_IsUpMine,");
				strSql2.Append(""+model.i_IsUpMine+",");
			}
			if (model.i_IsDirectionStation != null)
			{
                strSql1.Append("i_IsDirectionStation,");
                strSql2.Append("" + model.i_IsDirectionStation + ",");
			}
            if (model.DirectionLocalizerStationID != null)
            {
                strSql1.Append("DirectionLocalizerStationID,");
                strSql2.Append("" + model.DirectionLocalizerStationID + ",");
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

            if (model.i_State != null)
            {
                strSql1.Append("i_State,");
                strSql2.Append("" + model.i_State + ",");
            }

			strSql.Append("insert into m_Address(");
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
		public bool Update(DB_VehicleTransportManage.Model.m_Address model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_Address set ");
			if (model.vc_Name != null)
			{
				strSql.Append("vc_Name='"+model.vc_Name+"',");
			}
			else
			{
				strSql.Append("vc_Name= null ,");
			}
			if (model.LocalizerStationID != null)
			{
				strSql.Append("LocalizerStationID="+model.LocalizerStationID+",");
			}
			else
			{
				strSql.Append("LocalizerStationID= null ,");
			}
			if (model.AreaID != null)
			{
				strSql.Append("AreaID="+model.AreaID+",");
			}
			else
			{
				strSql.Append("AreaID= null ,");
			}
			if (model.i_IsUpMine != null)
			{
				strSql.Append("i_IsUpMine="+model.i_IsUpMine+",");
			}
			else
			{
				strSql.Append("i_IsUpMine= null ,");
			}
			if (model.i_IsDirectionStation != null)
			{
                strSql.Append("i_IsDirectionStation=" + model.i_IsDirectionStation + ",");
			}
			else
			{
                strSql.Append("i_IsDirectionStation= null ,");
			}
            if (model.DirectionLocalizerStationID != null)
            {
                strSql.Append("DirectionLocalizerStationID=" + model.DirectionLocalizerStationID + ",");
            }
            else
            {
                strSql.Append("DirectionLocalizerStationID= null ,");
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

            if (model.i_State != null)
            {
                strSql.Append("i_State=" + model.i_State + ",");
            }
            else
            {
                strSql.Append("i_State= null ,");
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
			strSql.Append("delete from m_Address ");
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
			strSql.Append("delete from m_Address ");
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
		public DB_VehicleTransportManage.Model.m_Address GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
            strSql.Append(" ID,vc_Name,LocalizerStationID,AreaID,i_IsUpMine,i_State,i_IsDirectionStation,vc_Memo,i_Flag,DirectionLocalizerStationID ");
			strSql.Append(" from m_Address ");
			strSql.Append(" where ID="+ID+"" );
			DB_VehicleTransportManage.Model.m_Address model=new DB_VehicleTransportManage.Model.m_Address();
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
		public DB_VehicleTransportManage.Model.m_Address DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.m_Address model=new DB_VehicleTransportManage.Model.m_Address();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["vc_Name"]!=null)
				{
					model.vc_Name=row["vc_Name"].ToString();
				}
				if(row["LocalizerStationID"]!=null && row["LocalizerStationID"].ToString()!="")
				{
					model.LocalizerStationID=int.Parse(row["LocalizerStationID"].ToString());
				}
				if(row["AreaID"]!=null && row["AreaID"].ToString()!="")
				{
					model.AreaID=int.Parse(row["AreaID"].ToString());
				}
				if(row["i_IsUpMine"]!=null && row["i_IsUpMine"].ToString()!="")
				{
					model.i_IsUpMine=int.Parse(row["i_IsUpMine"].ToString());
				}
                if (row["i_IsDirectionStation"] != null && row["i_IsDirectionStation"].ToString() != "")
				{
                    model.i_IsDirectionStation = int.Parse(row["i_IsDirectionStation"].ToString());
				}

                if (row["DirectionLocalizerStationID"] != null && row["DirectionLocalizerStationID"].ToString() != "")
                {
                    model.DirectionLocalizerStationID = int.Parse(row["DirectionLocalizerStationID"].ToString());
                }
				if(row["vc_Memo"]!=null)
				{
					model.vc_Memo=row["vc_Memo"].ToString();
				}
				if(row["i_Flag"]!=null && row["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(row["i_Flag"].ToString());
				}

                if (row["i_State"] != null && row["i_State"].ToString() != "")
                {
                    model.i_State = int.Parse(row["i_State"].ToString());
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
            strSql.Append("select ID,vc_Name,LocalizerStationID,AreaID,i_State,i_IsUpMine,i_IsDirectionStation,vc_Memo,i_Flag,DirectionLocalizerStationID ");
			strSql.Append(" FROM m_Address ");
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
            strSql.Append(" ID,vc_Name,LocalizerStationID,AreaID,i_IsUpMine,i_State,i_IsDirectionStation,vc_Memo,i_Flag,DirectionLocalizerStationID ");
			strSql.Append(" FROM m_Address ");
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
			strSql.Append("select count(1) FROM m_Address ");
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
			strSql.Append(")AS Row, T.*  from m_Address T ");
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

