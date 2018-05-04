/**  版本信息模板在安装目录下，可自行修改。
* m_User.cs
*
* 功 能： N/A
* 类 名： m_User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-11 11:08:37   N/A    初版
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
	/// 数据访问类:m_User
	/// </summary>
	public partial class m_User
	{
		public m_User()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DB_VehicleTransportManage.Model.m_User model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.vc_Name != null)
			{
				strSql1.Append("vc_Name,");
				strSql2.Append("'"+model.vc_Name+"',");
			}
            if (model.vc_IP != null)
            {
                strSql1.Append("vc_IP,");
                strSql2.Append("'" + model.vc_IP + "',");
            }

			if (model.vc_Password != null)
			{
				strSql1.Append("vc_Password,");
				strSql2.Append("'"+model.vc_Password+"',");
			}
			if (model.PersonID != null)
			{
				strSql1.Append("PersonID,");
				strSql2.Append(""+model.PersonID+",");
			}
            if (model.i_Port != null)
            {
                strSql1.Append("i_Port,");
                strSql2.Append("" + model.i_Port + ",");
            }

			if (model.DepartmentID != null)
			{
				strSql1.Append("DepartmentID,");
				strSql2.Append(""+model.DepartmentID+",");
			}
			if (model.RuleID != null)
			{
				strSql1.Append("RuleID,");
				strSql2.Append(""+model.RuleID+",");
			}
			if (model.i_IsPDA != null)
			{
				strSql1.Append("i_IsPDA,");
				strSql2.Append(""+model.i_IsPDA+",");
			}
			if (model.dt_CreateTime != null)
			{
				strSql1.Append("dt_CreateTime,");
				strSql2.Append("'"+model.dt_CreateTime+"',");
			}

            if (model.dt_LastActiveDateTime != null)
            {
                strSql1.Append("dt_LastActiveDateTime,");
                strSql2.Append("'" + model.dt_LastActiveDateTime + "',");
            }

			if (model.PdaID != null)
			{
				strSql1.Append("PdaID,");
				strSql2.Append(""+model.PdaID+",");
			}
			if (model.WifiBaseStationID != null)
			{
				strSql1.Append("WifiBaseStationID,");
				strSql2.Append(""+model.WifiBaseStationID+",");
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
            if (model.i_IdentificationCardHID != null)
            {
                strSql1.Append("i_IdentificationCardHID,");
                strSql2.Append("" + model.i_IdentificationCardHID + ",");
            }
            if (model.i_State != null)
            {
                strSql1.Append("i_State,");
                strSql2.Append("" + model.i_State + ",");
            }

			strSql.Append("insert into m_User(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
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
		/// 更新一条数据
		/// </summary>
		public bool Update(DB_VehicleTransportManage.Model.m_User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_User set ");
			if (model.vc_Name != null)
			{
				strSql.Append("vc_Name='"+model.vc_Name+"',");
			}
			else
			{
				strSql.Append("vc_Name= null ,");
			}

            if (model.vc_IP != null)
            {
                strSql.Append("vc_IP='" + model.vc_IP + "',");
            }
            else
            {
                strSql.Append("vc_IP= null ,");
            }


			if (model.vc_Password != null)
			{
				strSql.Append("vc_Password='"+model.vc_Password+"',");
			}
			else
			{
				strSql.Append("vc_Password= null ,");
			}
			if (model.PersonID != null)
			{
				strSql.Append("PersonID="+model.PersonID+",");
			}
			else
			{
				strSql.Append("PersonID= null ,");
			}
			if (model.DepartmentID != null)
			{
				strSql.Append("DepartmentID="+model.DepartmentID+",");
			}
			else
			{
				strSql.Append("DepartmentID= null ,");
			}

            if (model.i_Port != null)
            {
                strSql.Append("i_Port=" + model.i_Port + ",");
            }
            else
            {
                strSql.Append("i_Port= null ,");
            }

			if (model.RuleID != null)
			{
				strSql.Append("RuleID="+model.RuleID+",");
			}
			else
			{
				strSql.Append("RuleID= null ,");
			}
			if (model.i_IsPDA != null)
			{
				strSql.Append("i_IsPDA="+model.i_IsPDA+",");
			}
			else
			{
				strSql.Append("i_IsPDA= null ,");
			}
			if (model.dt_CreateTime != null)
			{
				strSql.Append("dt_CreateTime='"+model.dt_CreateTime+"',");
			}
			else
			{
				strSql.Append("dt_CreateTime= null ,");
			}

            if (model.dt_LastActiveDateTime != null)
            {
                strSql.Append("dt_LastActiveDateTime='" + model.dt_LastActiveDateTime + "',");
            }
            else
            {
                strSql.Append("dt_LastActiveDateTime= null ,");
            }


			if (model.PdaID != null)
			{
				strSql.Append("PdaID="+model.PdaID+",");
			}
			else
			{
				strSql.Append("PdaID= null ,");
			}
			if (model.WifiBaseStationID != null)
			{
				strSql.Append("WifiBaseStationID="+model.WifiBaseStationID+",");
			}
			else
			{
				strSql.Append("WifiBaseStationID= null ,");
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
            if (model.i_IdentificationCardHID != null)
            {
                strSql.Append("i_IdentificationCardHID=" + model.i_IdentificationCardHID + ",");
            }
            else
            {
                strSql.Append("i_IdentificationCardHID= null ,");
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
			strSql.Append("delete from m_User ");
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
			strSql.Append("delete from m_User ");
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
		public DB_VehicleTransportManage.Model.m_User GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
            strSql.Append(" ID,vc_Name,vc_Password,PersonID,DepartmentID,RuleID,i_State,i_Port,vc_IP,i_IsPDA,dt_CreateTime,dt_LastActiveDateTime,PdaID,WifiBaseStationID,vc_Memo,i_Flag,i_IdentificationCardHID ");
			strSql.Append(" from m_User ");
			strSql.Append(" where ID="+ID+"" );
			DB_VehicleTransportManage.Model.m_User model=new DB_VehicleTransportManage.Model.m_User();
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
		public DB_VehicleTransportManage.Model.m_User DataRowToModel(DataRow row)
		{
			DB_VehicleTransportManage.Model.m_User model=new DB_VehicleTransportManage.Model.m_User();
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

                if (row["vc_IP"] != null)
                {
                    model.vc_IP = row["vc_IP"].ToString();
                }


				if(row["vc_Password"]!=null)
				{
					model.vc_Password=row["vc_Password"].ToString();
				}
				if(row["PersonID"]!=null && row["PersonID"].ToString()!="")
				{
					model.PersonID=int.Parse(row["PersonID"].ToString());
				}

                if (row["i_Port"] != null && row["i_Port"].ToString() != "")
                {
                    model.i_Port = int.Parse(row["i_Port"].ToString());
                }


				if(row["DepartmentID"]!=null && row["DepartmentID"].ToString()!="")
				{
					model.DepartmentID=int.Parse(row["DepartmentID"].ToString());
				}
				if(row["RuleID"]!=null && row["RuleID"].ToString()!="")
				{
					model.RuleID=int.Parse(row["RuleID"].ToString());
				}
				if(row["i_IsPDA"]!=null && row["i_IsPDA"].ToString()!="")
				{
					model.i_IsPDA=int.Parse(row["i_IsPDA"].ToString());
				}
				if(row["dt_CreateTime"]!=null && row["dt_CreateTime"].ToString()!="")
				{
					model.dt_CreateTime=DateTime.Parse(row["dt_CreateTime"].ToString());
				}

                if (row["dt_LastActiveDateTime"] != null && row["dt_LastActiveDateTime"].ToString() != "")
                {
                    model.dt_LastActiveDateTime = DateTime.Parse(row["dt_LastActiveDateTime"].ToString());
                }


				if(row["PdaID"]!=null && row["PdaID"].ToString()!="")
				{
					model.PdaID=int.Parse(row["PdaID"].ToString());
				}
				if(row["WifiBaseStationID"]!=null && row["WifiBaseStationID"].ToString()!="")
				{
					model.WifiBaseStationID=int.Parse(row["WifiBaseStationID"].ToString());
				}
				if(row["vc_Memo"]!=null)
				{
					model.vc_Memo=row["vc_Memo"].ToString();
				}
				if(row["i_Flag"]!=null && row["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(row["i_Flag"].ToString());
				}
                if (row["i_IdentificationCardHID"] != null && row["i_IdentificationCardHID"].ToString() != "")
                {
                    model.i_IdentificationCardHID = int.Parse(row["i_IdentificationCardHID"].ToString());
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
            strSql.Append("select ID,vc_Name,vc_Password,PersonID,DepartmentID,RuleID,i_IsPDA,i_Port,vc_IP,i_State,dt_CreateTime,dt_LastActiveDateTime,PdaID,WifiBaseStationID,vc_Memo,i_Flag,i_IdentificationCardHID ");
			strSql.Append(" FROM m_User ");
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
            strSql.Append(" ID,vc_Name,vc_Password,PersonID,DepartmentID,RuleID,i_IsPDA,i_State,i_Port,vc_IP,dt_CreateTime,dt_LastActiveDateTime,PdaID,WifiBaseStationID,vc_Memo,i_Flag,i_IdentificationCardHID ");
			strSql.Append(" FROM m_User ");
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
			strSql.Append("select count(1) FROM m_User ");
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
			strSql.Append(")AS Row, T.*  from m_User T ");
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

