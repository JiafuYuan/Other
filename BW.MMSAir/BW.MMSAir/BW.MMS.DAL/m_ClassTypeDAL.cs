using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:m_ClassTypeDAL
	/// </summary>
	public partial class m_ClassTypeDAL
	{
		public m_ClassTypeDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "m_ClassType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_ClassType");
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
		public int Add(BW.MMS.Model.m_ClassTypeEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into m_ClassType(");
			strSql.Append("nvc_name,nvc_shortname,nvc_descripe,nvc_remark)");
			strSql.Append(" values (");
			strSql.Append("@nvc_name,@nvc_shortname,@nvc_descripe,@nvc_remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@nvc_name", SqlDbType.NVarChar,50),
					new SqlParameter("@nvc_shortname", SqlDbType.NVarChar,50),
					new SqlParameter("@nvc_descripe", SqlDbType.NVarChar,50),
					new SqlParameter("@nvc_remark", SqlDbType.NVarChar,250)};
			parameters[0].Value = model.nvc_name;
			parameters[1].Value = model.nvc_shortname;
			parameters[2].Value = model.nvc_descripe;
			parameters[3].Value = model.nvc_remark;

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
		public bool Update(BW.MMS.Model.m_ClassTypeEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_ClassType set ");
			strSql.Append("nvc_name=@nvc_name,");
			strSql.Append("nvc_shortname=@nvc_shortname,");
			strSql.Append("nvc_descripe=@nvc_descripe,");
			strSql.Append("nvc_remark=@nvc_remark");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@nvc_name", SqlDbType.NVarChar,50),
					new SqlParameter("@nvc_shortname", SqlDbType.NVarChar,50),
					new SqlParameter("@nvc_descripe", SqlDbType.NVarChar,50),
					new SqlParameter("@nvc_remark", SqlDbType.NVarChar,250),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.nvc_name;
			parameters[1].Value = model.nvc_shortname;
			parameters[2].Value = model.nvc_descripe;
			parameters[3].Value = model.nvc_remark;
			parameters[4].Value = model.ID;

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
			strSql.Append("delete from m_ClassType ");
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
			strSql.Append("delete from m_ClassType ");
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
		public BW.MMS.Model.m_ClassTypeEntity GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,nvc_name,nvc_shortname,nvc_descripe,nvc_remark from m_ClassType ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			BW.MMS.Model.m_ClassTypeEntity model=new BW.MMS.Model.m_ClassTypeEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["nvc_name"]!=null && ds.Tables[0].Rows[0]["nvc_name"].ToString()!="")
				{
					model.nvc_name=ds.Tables[0].Rows[0]["nvc_name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["nvc_shortname"]!=null && ds.Tables[0].Rows[0]["nvc_shortname"].ToString()!="")
				{
					model.nvc_shortname=ds.Tables[0].Rows[0]["nvc_shortname"].ToString();
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
			strSql.Append("select ID,nvc_name,nvc_shortname,nvc_descripe,nvc_remark ");
			strSql.Append(" FROM m_ClassType ");
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
			strSql.Append(" ID,nvc_name,nvc_shortname,nvc_descripe,nvc_remark ");
			strSql.Append(" FROM m_ClassType ");
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
			strSql.Append("select count(1) FROM m_ClassType ");
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
			strSql.Append(")AS Row, T.*  from m_ClassType T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere">条件语句</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">显示条数</param>
        /// <param name="sort">排序字段</param>
        /// <param name="dir">升/降序(DESC、ASC)</param>
        /// <param name="records">输出总条数</param>
        /// <returns></returns>
        public DataTable GetPagingList(string strWhere, int PageIndex, int PageSize, string sort, string dir, out int RecordCount)
        {
            QueryParam param = new QueryParam();
            param.Orderfld = sort;
            if (string.Compare(dir, "ASC", true) == 0)
            {
                param.OrderType = 2;
            }
            else
            {
                param.OrderType = 1;
            }
            param.PageIndex = PageIndex;
            param.PageSize = PageSize;
            param.ReturnFields = "  ID,nvc_name,nvc_shortname,nvc_descripe,nvc_remark ";
            param.TableName = " m_classtype where 1=1 ";
            if (strWhere.Trim().Length > 0)
            {
                param.Where = strWhere;
            }
            return DbHelperSQL.SelectDataByStoredProcedure(param, out RecordCount);
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
			parameters[0].Value = "m_ClassType";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteClassList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_Class ");
            strSql.Append(" where classTypeID in (" + IDlist + ")  ");
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
        /// <summary>
        /// 检查是否存在此班次
        /// </summary>
        /// <param name="ClassTypeName"></param>
        /// <returns></returns>
        public DataSet CheckClassTypeByName(string ClassTypeName)
        {
            string strSql = "SELECT ID FROM m_ClassType WHERE nvc_name='" + ClassTypeName + "'";
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 检查是否存在此班次
        /// </summary>
        /// <param name="ClassTypeID"></param>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        public DataSet CheckClassTypeByName(int ClassTypeID, string ClassTypeName)
        {
            string strSql = "SELECT ID FROM m_ClassType WHERE nvc_name='" + ClassTypeName + "' AND ID<>" + ClassTypeID + "";
            return DbHelperSQL.Query(strSql.ToString());
        }
		#endregion  Method
	}
}

