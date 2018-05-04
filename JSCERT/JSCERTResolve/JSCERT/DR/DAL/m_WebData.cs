/**  版本信息模板在安装目录下，可自行修改。
* m_WebData.cs
*
* 功 能： N/A
* 类 名： m_WebData
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/9 10:58:12   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace JSCERT.DAL
{
	/// <summary>
	/// 数据访问类:m_WebData
	/// </summary>
	public partial class m_WebData
	{
		public m_WebData()
		{}
		#region  BasicMethod


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(JSCERT.Model.m_WebData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into m_WebData(");
			strSql.Append("vc_Name,dt_Time,i_Count,TypeID)");
			strSql.Append(" values (");
            strSql.Append("?,?,?,?)");
			strSql.Append(";select @@IDENTITY");
			OleDbParameter[] parameters = {
					new OleDbParameter("@vc_Name", model.vc_Name),
					new OleDbParameter("@dt_Time", model.dt_Time),
					new OleDbParameter("@i_Count", model.i_Count),
					new OleDbParameter("@TypeID", model.TypeID)};


            object obj = DB.OleDbHelper.ExecuteSql(strSql.ToString(), parameters, CommandType.Text);
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
		public bool Update(JSCERT.Model.m_WebData model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_WebData set ");
			strSql.Append("vc_Name=?,");
			strSql.Append("dt_Time=?,");
			strSql.Append("i_Count=?,");
            strSql.Append("TypeID=?");
			strSql.Append(" where ID=@ID");
            OleDbParameter[] parameters = {
					new OleDbParameter("@vc_Name",model.vc_Name),
					new OleDbParameter("@dt_Time", model.dt_Time),
					new OleDbParameter("@i_Count", model.i_Count),
					new OleDbParameter("@ID", model.ID),
					new OleDbParameter("@TypeID", model.TypeID)};

			int rows=DB.OleDbHelper.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_WebData ");
			strSql.Append(" where ID=?");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ID", ID)
			};

			int rows=DB.OleDbHelper.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TypeID,int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_WebData ");
			strSql.Append(" where TypeID=? and ID=? ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@TypeID", TypeID),
					new OleDbParameter("@ID", ID)			};
			parameters[0].Value = TypeID;
			parameters[1].Value = ID;

			int rows=DB.OleDbHelper.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_WebData ");
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
		public JSCERT.Model.m_WebData GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,vc_Name,dt_Time,i_Count,TypeID from m_WebData ");
			strSql.Append(" where ID=?");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", ID)
			};

			JSCERT.Model.m_WebData model=new JSCERT.Model.m_WebData();
			DataSet ds=DB.OleDbHelper.GetDataSet(strSql.ToString(),CommandType.Text,parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

      
        ///
        public List<T> DtToList<T>(DataTable dt, Func<DataRow, T> fun)
        {
            List<T> list = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(fun(dr));
            }

            return list;
        }
        /// 
        public bool DataTableToSQLServer(DataTable dt)
        {
            string connectionString = DB.OleDbHelper.DBInfo.GetSqlConnectionString();

            using (SqlConnection destinationConnection = new SqlConnection(connectionString))
            {
                destinationConnection.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.CheckConstraints | SqlBulkCopyOptions.FireTriggers))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = "m_WebData";//要插入的表的表明
                        bulkCopy.ColumnMappings.Add("vc_Name", "vc_Name");//映射字段名 DataTable列名 ,数据库 对应的列名
                        bulkCopy.ColumnMappings.Add("dt_Time", "dt_Time");
                        bulkCopy.ColumnMappings.Add("i_Count", "i_Count");
                        bulkCopy.ColumnMappings.Add("TypeID", "TypeID");
                        bulkCopy.WriteToServer(dt);
                        //dt.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        //Console.WriteLine(ex.Message);
                        return false;
                    }
                    return true;
                }
            }
        }
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public JSCERT.Model.m_WebData DataRowToModel(DataRow row)
		{
			JSCERT.Model.m_WebData model=new JSCERT.Model.m_WebData();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["vc_Name"]!=null && row["vc_Name"].ToString()!="")
				{
					model.vc_Name=row["vc_Name"].ToString();
				}
				if(row["dt_Time"]!=null && row["dt_Time"].ToString()!="")
				{
					model.dt_Time=DateTime.Parse(row["dt_Time"].ToString());
				}
				if(row["i_Count"]!=null && row["i_Count"].ToString()!="")
				{
					model.i_Count=int.Parse(row["i_Count"].ToString());
				}
				if(row["TypeID"]!=null && row["TypeID"].ToString()!="")
				{
					model.TypeID=int.Parse(row["TypeID"].ToString());
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
			strSql.Append("select ID,vc_Name,dt_Time,i_Count,TypeID ");
			strSql.Append(" FROM m_WebData ");
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
			strSql.Append(" ID,vc_Name,dt_Time,i_Count,TypeID ");
			strSql.Append(" FROM m_WebData ");
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
			strSql.Append("select count(1) FROM m_WebData ");
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
			strSql.Append(")AS Row, T.*  from m_WebData T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "m_WebData";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DB.OleDbHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

