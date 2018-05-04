using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:sys_ModuleDAL
	/// </summary>
	public partial class sys_ModuleDAL
	{
		public sys_ModuleDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "sys_Module"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_Module");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BW.MMS.Model.sys_Module model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_Module(");
			strSql.Append("vc_ModuleName,vc_URL,vc_Icon,ParentID,vc_Description,vc_Memo,i_Flag)");
			strSql.Append(" values (");
			strSql.Append("@vc_ModuleName,@vc_URL,@vc_Icon,@ParentID,@vc_Description,@vc_Memo,@i_Flag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_ModuleName", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_URL", SqlDbType.VarChar,50),
					new SqlParameter("@vc_Icon", SqlDbType.VarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@vc_Description", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4)};
			parameters[0].Value = model.vc_ModuleName;
			parameters[1].Value = model.vc_URL;
			parameters[2].Value = model.vc_Icon;
			parameters[3].Value = model.ParentID;
			parameters[4].Value = model.vc_Description;
			parameters[5].Value = model.vc_Memo;
			parameters[6].Value = model.i_Flag;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(BW.MMS.Model.sys_Module model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_Module set ");
			strSql.Append("vc_ModuleName=@vc_ModuleName,");
			strSql.Append("vc_URL=@vc_URL,");
			strSql.Append("vc_Icon=@vc_Icon,");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("vc_Description=@vc_Description,");
			strSql.Append("vc_Memo=@vc_Memo,");
			strSql.Append("i_Flag=@i_Flag");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_ModuleName", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_URL", SqlDbType.VarChar,50),
					new SqlParameter("@vc_Icon", SqlDbType.VarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@vc_Description", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.vc_ModuleName;
			parameters[1].Value = model.vc_URL;
			parameters[2].Value = model.vc_Icon;
			parameters[3].Value = model.ParentID;
			parameters[4].Value = model.vc_Description;
			parameters[5].Value = model.vc_Memo;
			parameters[6].Value = model.i_Flag;
			parameters[7].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_Module ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sys_Module ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public BW.MMS.Model.sys_Module GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,vc_ModuleName,vc_URL,vc_Icon,ParentID,vc_Description,vc_Memo,i_Flag from sys_Module ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			BW.MMS.Model.sys_Module model=new BW.MMS.Model.sys_Module();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_ModuleName"]!=null && ds.Tables[0].Rows[0]["vc_ModuleName"].ToString()!="")
				{
					model.vc_ModuleName=ds.Tables[0].Rows[0]["vc_ModuleName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vc_URL"]!=null && ds.Tables[0].Rows[0]["vc_URL"].ToString()!="")
				{
					model.vc_URL=ds.Tables[0].Rows[0]["vc_URL"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vc_Icon"]!=null && ds.Tables[0].Rows[0]["vc_Icon"].ToString()!="")
				{
					model.vc_Icon=ds.Tables[0].Rows[0]["vc_Icon"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ParentID"]!=null && ds.Tables[0].Rows[0]["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_Description"]!=null && ds.Tables[0].Rows[0]["vc_Description"].ToString()!="")
				{
					model.vc_Description=ds.Tables[0].Rows[0]["vc_Description"].ToString();
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
			strSql.Append("select ID,vc_ModuleName,vc_URL,vc_Icon,ParentID,vc_Description,vc_Memo,i_Flag ");
			strSql.Append(" FROM sys_Module ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by Sort asc ");
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
			strSql.Append(" ID,vc_ModuleName,vc_URL,vc_Icon,ParentID,vc_Description,vc_Memo,i_Flag ");
			strSql.Append(" FROM sys_Module ");
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
			strSql.Append("select count(1) FROM sys_Module ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from sys_Module T ");
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
			parameters[0].Value = "sys_Module";
			parameters[1].Value = "ID";
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

