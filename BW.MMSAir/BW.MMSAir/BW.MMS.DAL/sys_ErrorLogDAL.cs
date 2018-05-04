using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:sys_ErrorLogDAL
	/// </summary>
	public partial class sys_ErrorLogDAL
	{
		public sys_ErrorLogDAL()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(DateTime dt_DataTime)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_ErrorLog");
			strSql.Append(" where dt_DataTime=@dt_DataTime ");
			SqlParameter[] parameters = {
					new SqlParameter("@dt_DataTime", SqlDbType.DateTime)			};
			parameters[0].Value = dt_DataTime;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BW.MMS.Model.sys_ErrorLogEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_ErrorLog(");
			strSql.Append("vc_Message,vc_Source,StackTrace,OprationPersonID,dt_DataTime,vc_Memo,i_Flag)");
			strSql.Append(" values (");
			strSql.Append("@vc_Message,@vc_Source,@StackTrace,@OprationPersonID,@dt_DataTime,@vc_Memo,@i_Flag)");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_Message", SqlDbType.NVarChar,500),
					new SqlParameter("@vc_Source", SqlDbType.NVarChar,500),
					new SqlParameter("@StackTrace", SqlDbType.Text),
					new SqlParameter("@OprationPersonID", SqlDbType.Int,4),
					new SqlParameter("@dt_DataTime", SqlDbType.DateTime),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4)};
			parameters[0].Value = model.vc_Message;
			parameters[1].Value = model.vc_Source;
			parameters[2].Value = model.StackTrace;
			parameters[3].Value = model.OprationPersonID;
			parameters[4].Value = model.dt_DataTime;
			parameters[5].Value = model.vc_Memo;
			parameters[6].Value = model.i_Flag;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(BW.MMS.Model.sys_ErrorLogEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_ErrorLog set ");
			strSql.Append("vc_Message=@vc_Message,");
			strSql.Append("vc_Source=@vc_Source,");
			strSql.Append("StackTrace=@StackTrace,");
			strSql.Append("OprationPersonID=@OprationPersonID,");
			strSql.Append("vc_Memo=@vc_Memo,");
			strSql.Append("i_Flag=@i_Flag");
			strSql.Append(" where dt_DataTime=@dt_DataTime ");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_Message", SqlDbType.NVarChar,500),
					new SqlParameter("@vc_Source", SqlDbType.NVarChar,500),
					new SqlParameter("@StackTrace", SqlDbType.Text),
					new SqlParameter("@OprationPersonID", SqlDbType.Int,4),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@dt_DataTime", SqlDbType.DateTime)};
			parameters[0].Value = model.vc_Message;
			parameters[1].Value = model.vc_Source;
			parameters[2].Value = model.StackTrace;
			parameters[3].Value = model.OprationPersonID;
			parameters[4].Value = model.vc_Memo;
			parameters[5].Value = model.i_Flag;
			parameters[6].Value = model.dt_DataTime;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(DateTime dt_DataTime)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_ErrorLog ");
			strSql.Append(" where dt_DataTime=@dt_DataTime ");
			SqlParameter[] parameters = {
					new SqlParameter("@dt_DataTime", SqlDbType.DateTime)			};
			parameters[0].Value = dt_DataTime;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string dt_DataTimelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_ErrorLog ");
			strSql.Append(" where dt_DataTime in ("+dt_DataTimelist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public BW.MMS.Model.sys_ErrorLogEntity GetModel(DateTime dt_DataTime)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 vc_Message,vc_Source,StackTrace,OprationPersonID,dt_DataTime,vc_Memo,i_Flag from sys_ErrorLog ");
			strSql.Append(" where dt_DataTime=@dt_DataTime ");
			SqlParameter[] parameters = {
					new SqlParameter("@dt_DataTime", SqlDbType.DateTime)			};
			parameters[0].Value = dt_DataTime;

			BW.MMS.Model.sys_ErrorLogEntity model=new BW.MMS.Model.sys_ErrorLogEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["vc_Message"]!=null && ds.Tables[0].Rows[0]["vc_Message"].ToString()!="")
				{
					model.vc_Message=ds.Tables[0].Rows[0]["vc_Message"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vc_Source"]!=null && ds.Tables[0].Rows[0]["vc_Source"].ToString()!="")
				{
					model.vc_Source=ds.Tables[0].Rows[0]["vc_Source"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StackTrace"]!=null && ds.Tables[0].Rows[0]["StackTrace"].ToString()!="")
				{
					model.StackTrace=ds.Tables[0].Rows[0]["StackTrace"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OprationPersonID"]!=null && ds.Tables[0].Rows[0]["OprationPersonID"].ToString()!="")
				{
					model.OprationPersonID=int.Parse(ds.Tables[0].Rows[0]["OprationPersonID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dt_DataTime"]!=null && ds.Tables[0].Rows[0]["dt_DataTime"].ToString()!="")
				{
					model.dt_DataTime=DateTime.Parse(ds.Tables[0].Rows[0]["dt_DataTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_Memo"]!=null && ds.Tables[0].Rows[0]["vc_Memo"].ToString()!="")
				{
					model.vc_Memo=ds.Tables[0].Rows[0]["vc_Memo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["i_Flag"]!=null && ds.Tables[0].Rows[0]["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(ds.Tables[0].Rows[0]["i_Flag"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select vc_Message,vc_Source,StackTrace,OprationPersonID,dt_DataTime,vc_Memo,i_Flag ");
			strSql.Append(" FROM sys_ErrorLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" vc_Message,vc_Source,StackTrace,OprationPersonID,dt_DataTime,vc_Memo,i_Flag ");
			strSql.Append(" FROM sys_ErrorLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM sys_ErrorLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.dt_DataTime desc");
			}
			strSql.Append(")AS Row, T.*  from sys_ErrorLog T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
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
			parameters[0].Value = "sys_ErrorLog";
			parameters[1].Value = "dt_DataTime";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

