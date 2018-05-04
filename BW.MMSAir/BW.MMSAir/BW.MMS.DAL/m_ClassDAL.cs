using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:m_ClassDAL
	/// </summary>
	public partial class m_ClassDAL
	{
		public m_ClassDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "m_Class"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_Class");
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
		public int Add(BW.MMS.Model.m_ClassEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into m_Class(");
			strSql.Append("classTypeID,nvc_name,nvc_shortname,d_start,d_End,nvc_descripe,nvc_remark)");
			strSql.Append(" values (");
			strSql.Append("@classTypeID,@nvc_name,@nvc_shortname,@d_start,@d_End,@nvc_descripe,@nvc_remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@classTypeID", SqlDbType.Int,4),
					new SqlParameter("@nvc_name", SqlDbType.NVarChar,50),
					new SqlParameter("@nvc_shortname", SqlDbType.NVarChar,50),
					new SqlParameter("@d_start", SqlDbType.VarChar,10),
					new SqlParameter("@d_End", SqlDbType.VarChar,10),
					new SqlParameter("@nvc_descripe", SqlDbType.VarChar,50),
					new SqlParameter("@nvc_remark", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.classTypeID;
			parameters[1].Value = model.nvc_name;
			parameters[2].Value = model.nvc_shortname;
			parameters[3].Value = model.d_start;
			parameters[4].Value = model.d_End;
			parameters[5].Value = model.nvc_descripe;
			parameters[6].Value = model.nvc_remark;

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
		public bool Update(BW.MMS.Model.m_ClassEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_Class set ");
			strSql.Append("classTypeID=@classTypeID,");
			strSql.Append("nvc_name=@nvc_name,");
			strSql.Append("nvc_shortname=@nvc_shortname,");
			strSql.Append("d_start=@d_start,");
			strSql.Append("d_End=@d_End,");
			strSql.Append("nvc_descripe=@nvc_descripe,");
			strSql.Append("nvc_remark=@nvc_remark");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@classTypeID", SqlDbType.Int,4),
					new SqlParameter("@nvc_name", SqlDbType.NVarChar,50),
					new SqlParameter("@nvc_shortname", SqlDbType.NVarChar,50),
					new SqlParameter("@d_start", SqlDbType.VarChar,10),
					new SqlParameter("@d_End", SqlDbType.VarChar,10),
					new SqlParameter("@nvc_descripe", SqlDbType.VarChar,50),
					new SqlParameter("@nvc_remark", SqlDbType.NVarChar,500),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.classTypeID;
			parameters[1].Value = model.nvc_name;
			parameters[2].Value = model.nvc_shortname;
			parameters[3].Value = model.d_start;
			parameters[4].Value = model.d_End;
			parameters[5].Value = model.nvc_descripe;
			parameters[6].Value = model.nvc_remark;
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
			strSql.Append("delete from m_Class ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {
            if (!string.IsNullOrEmpty(where))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from m_Class ");
                strSql.AppendFormat(" where {0}", where);
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
			strSql.Append("delete from m_Class ");
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
		public BW.MMS.Model.m_ClassEntity GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,classTypeID,nvc_name,nvc_shortname,d_start,d_End,nvc_descripe,nvc_remark from m_Class ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			BW.MMS.Model.m_ClassEntity model=new BW.MMS.Model.m_ClassEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["classTypeID"]!=null && ds.Tables[0].Rows[0]["classTypeID"].ToString()!="")
				{
					model.classTypeID=int.Parse(ds.Tables[0].Rows[0]["classTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["nvc_name"]!=null && ds.Tables[0].Rows[0]["nvc_name"].ToString()!="")
				{
					model.nvc_name=ds.Tables[0].Rows[0]["nvc_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nvc_shortname"]!=null && ds.Tables[0].Rows[0]["nvc_shortname"].ToString()!="")
				{
					model.nvc_shortname=ds.Tables[0].Rows[0]["nvc_shortname"].ToString();
				}
				if(ds.Tables[0].Rows[0]["d_start"]!=null && ds.Tables[0].Rows[0]["d_start"].ToString()!="")
				{
					model.d_start=ds.Tables[0].Rows[0]["d_start"].ToString();
				}
				if(ds.Tables[0].Rows[0]["d_End"]!=null && ds.Tables[0].Rows[0]["d_End"].ToString()!="")
				{
					model.d_End=ds.Tables[0].Rows[0]["d_End"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nvc_descripe"]!=null && ds.Tables[0].Rows[0]["nvc_descripe"].ToString()!="")
				{
					model.nvc_descripe=ds.Tables[0].Rows[0]["nvc_descripe"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nvc_remark"]!=null && ds.Tables[0].Rows[0]["nvc_remark"].ToString()!="")
				{
					model.nvc_remark=ds.Tables[0].Rows[0]["nvc_remark"].ToString();
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
			strSql.Append("select ID,classTypeID,nvc_name,nvc_shortname,d_start,d_End,nvc_descripe,nvc_remark ");
			strSql.Append(" FROM m_Class ");
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
			strSql.Append(" ID,classTypeID,nvc_name,nvc_shortname,d_start,d_End,nvc_descripe,nvc_remark ");
			strSql.Append(" FROM m_Class ");
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
			strSql.Append("select count(1) FROM m_Class ");
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
			strSql.Append(")AS Row, T.*  from m_Class T ");
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
			parameters[0].Value = "m_Class";
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

