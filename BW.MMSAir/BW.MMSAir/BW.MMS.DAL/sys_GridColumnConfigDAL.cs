using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:sys_GridColumnConfigDAL
	/// </summary>
	public partial class sys_GridColumnConfigDAL
	{
		public sys_GridColumnConfigDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "sys_GridColumnConfig"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sys_GridColumnConfig");
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
		public int Add(BW.MMS.Model.sys_GridColumnConfigEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sys_GridColumnConfig(");
			strSql.Append("GridId,Title,Field,Width,Align,Sortable,DisplayOrder,Hidden,Colspan,i_Flag)");
			strSql.Append(" values (");
			strSql.Append("@GridId,@Title,@Field,@Width,@Align,@Sortable,@DisplayOrder,@Hidden,@Colspan,@i_Flag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@GridId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Field", SqlDbType.VarChar,50),
					new SqlParameter("@Width", SqlDbType.Int,4),
					new SqlParameter("@Align", SqlDbType.VarChar,50),
					new SqlParameter("@Sortable", SqlDbType.Bit,1),
					new SqlParameter("@DisplayOrder", SqlDbType.Int,4),
					new SqlParameter("@Hidden", SqlDbType.Bit,1),
					new SqlParameter("@Colspan", SqlDbType.Int,4),
					new SqlParameter("@i_Flag", SqlDbType.Int,4)};
			parameters[0].Value = model.GridId;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Field;
			parameters[3].Value = model.Width;
			parameters[4].Value = model.Align;
			parameters[5].Value = model.Sortable;
			parameters[6].Value = model.DisplayOrder;
			parameters[7].Value = model.Hidden;
			parameters[8].Value = model.Colspan;
			parameters[9].Value = model.i_Flag;

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
		public bool Update(BW.MMS.Model.sys_GridColumnConfigEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sys_GridColumnConfig set ");
			strSql.Append("GridId=@GridId,");
			strSql.Append("Title=@Title,");
			strSql.Append("Field=@Field,");
			strSql.Append("Width=@Width,");
			strSql.Append("Align=@Align,");
			strSql.Append("Sortable=@Sortable,");
			strSql.Append("DisplayOrder=@DisplayOrder,");
			strSql.Append("Hidden=@Hidden,");
			strSql.Append("Colspan=@Colspan,");
			strSql.Append("i_Flag=@i_Flag");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@GridId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Field", SqlDbType.VarChar,50),
					new SqlParameter("@Width", SqlDbType.Int,4),
					new SqlParameter("@Align", SqlDbType.VarChar,50),
					new SqlParameter("@Sortable", SqlDbType.Bit,1),
					new SqlParameter("@DisplayOrder", SqlDbType.Int,4),
					new SqlParameter("@Hidden", SqlDbType.Bit,1),
					new SqlParameter("@Colspan", SqlDbType.Int,4),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.GridId;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Field;
			parameters[3].Value = model.Width;
			parameters[4].Value = model.Align;
			parameters[5].Value = model.Sortable;
			parameters[6].Value = model.DisplayOrder;
			parameters[7].Value = model.Hidden;
			parameters[8].Value = model.Colspan;
			parameters[9].Value = model.i_Flag;
			parameters[10].Value = model.ID;

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
			strSql.Append("delete from sys_GridColumnConfig ");
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
			strSql.Append("delete from sys_GridColumnConfig ");
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
		public BW.MMS.Model.sys_GridColumnConfigEntity GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,GridId,Title,Field,Width,Align,Sortable,DisplayOrder,Hidden,Colspan,i_Flag from sys_GridColumnConfig ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			BW.MMS.Model.sys_GridColumnConfigEntity model=new BW.MMS.Model.sys_GridColumnConfigEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["GridId"]!=null && ds.Tables[0].Rows[0]["GridId"].ToString()!="")
				{
					model.GridId=int.Parse(ds.Tables[0].Rows[0]["GridId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Title"]!=null && ds.Tables[0].Rows[0]["Title"].ToString()!="")
				{
					model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Field"]!=null && ds.Tables[0].Rows[0]["Field"].ToString()!="")
				{
					model.Field=ds.Tables[0].Rows[0]["Field"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Width"]!=null && ds.Tables[0].Rows[0]["Width"].ToString()!="")
				{
					model.Width=int.Parse(ds.Tables[0].Rows[0]["Width"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Align"]!=null && ds.Tables[0].Rows[0]["Align"].ToString()!="")
				{
					model.Align=ds.Tables[0].Rows[0]["Align"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Sortable"]!=null && ds.Tables[0].Rows[0]["Sortable"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Sortable"].ToString()=="1")||(ds.Tables[0].Rows[0]["Sortable"].ToString().ToLower()=="true"))
					{
						model.Sortable=true;
					}
					else
					{
						model.Sortable=false;
					}
				}
				if(ds.Tables[0].Rows[0]["DisplayOrder"]!=null && ds.Tables[0].Rows[0]["DisplayOrder"].ToString()!="")
				{
					model.DisplayOrder=int.Parse(ds.Tables[0].Rows[0]["DisplayOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Hidden"]!=null && ds.Tables[0].Rows[0]["Hidden"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["Hidden"].ToString()=="1")||(ds.Tables[0].Rows[0]["Hidden"].ToString().ToLower()=="true"))
					{
						model.Hidden=true;
					}
					else
					{
						model.Hidden=false;
					}
				}
				if(ds.Tables[0].Rows[0]["Colspan"]!=null && ds.Tables[0].Rows[0]["Colspan"].ToString()!="")
				{
					model.Colspan=int.Parse(ds.Tables[0].Rows[0]["Colspan"].ToString());
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
			strSql.Append("select ID,GridId,Title,Field,Width,Align,Sortable,DisplayOrder,Hidden,Colspan,i_Flag ");
			strSql.Append(" FROM sys_GridColumnConfig ");
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
			strSql.Append(" ID,GridId,Title,Field,Width,Align,Sortable,DisplayOrder,Hidden,Colspan,i_Flag ");
			strSql.Append(" FROM sys_GridColumnConfig ");
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
			strSql.Append("select count(1) FROM sys_GridColumnConfig ");
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
			strSql.Append(")AS Row, T.*  from sys_GridColumnConfig T ");
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
			parameters[0].Value = "sys_GridColumnConfig";
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

