using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SPcms.DBUtility;
using SPcms.Common;

namespace SPcms.Web.Plugin.Feedback.DAL
{
	/// <summary>
	/// 数据访问类:在线留言
	/// </summary>
	public partial class feedback
	{
        private string databaseprefix; //数据库表名前缀
        public feedback(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }

		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "feedback");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.feedback model)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "feedback(");
            strSql.Append("title,content,user_name,user_tel,user_qq,user_email,add_time,is_lock,cateid)");
			strSql.Append(" values (");
            strSql.Append("@title,@content,@user_name,@user_tel,@user_qq,@user_email,@add_time,@is_lock,@cateid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
					new SqlParameter("@user_qq", SqlDbType.NVarChar,30),
					new SqlParameter("@user_email", SqlDbType.NVarChar,100),
					new SqlParameter("@add_time", SqlDbType.DateTime),
                    new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
                    new SqlParameter("@cateid", SqlDbType.Int,4)                    };
			parameters[0].Value = model.title;
			parameters[1].Value = model.content;
			parameters[2].Value = model.user_name;
			parameters[3].Value = model.user_tel;
			parameters[4].Value = model.user_qq;
			parameters[5].Value = model.user_email;
			parameters[6].Value = model.add_time;
            parameters[7].Value = model.is_lock;
            parameters[8].Value = model.cateid;
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
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "feedback set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "feedback set ");
            strSql.Append("title=@title,");
            strSql.Append("content=@content,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("user_tel=@user_tel,");
            strSql.Append("user_qq=@user_qq,");
            strSql.Append("user_email=@user_email,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("reply_content=@reply_content,");
            strSql.Append("reply_time=@reply_time,");
            strSql.Append("is_lock=@is_lock");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@user_tel", SqlDbType.NVarChar,30),
					new SqlParameter("@user_qq", SqlDbType.NVarChar,30),
					new SqlParameter("@user_email", SqlDbType.NVarChar,100),
					new SqlParameter("@add_time", SqlDbType.DateTime),
					new SqlParameter("@reply_content", SqlDbType.NText),
					new SqlParameter("@reply_time", SqlDbType.DateTime),
					new SqlParameter("@is_lock", SqlDbType.TinyInt,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.content;
            parameters[2].Value = model.user_name;
            parameters[3].Value = model.user_tel;
            parameters[4].Value = model.user_qq;
            parameters[5].Value = model.user_email;
            parameters[6].Value = model.add_time;
            parameters[7].Value = model.reply_content;
            parameters[8].Value = model.reply_time;
            parameters[9].Value = model.is_lock;
            parameters[10].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "feedback ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

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
        public bool Deletebycate(int cate)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "feedback ");
            strSql.Append(" where cateid=@cateid");
			SqlParameter[] parameters = {
					new SqlParameter("@cateid", SqlDbType.Int,4)};
            parameters[0].Value = cate;

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
        /// 得到一个对象实体
        /// </summary>
        public Model.feedback GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,content,user_name,user_tel,user_qq,user_email,add_time,reply_content,reply_time,is_lock from " + databaseprefix + "feedback ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.feedback model = new Model.feedback();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_name"] != null && ds.Tables[0].Rows[0]["user_name"].ToString() != "")
                {
                    model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_tel"] != null && ds.Tables[0].Rows[0]["user_tel"].ToString() != "")
                {
                    model.user_tel = ds.Tables[0].Rows[0]["user_tel"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_qq"] != null && ds.Tables[0].Rows[0]["user_qq"].ToString() != "")
                {
                    model.user_qq = ds.Tables[0].Rows[0]["user_qq"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_email"] != null && ds.Tables[0].Rows[0]["user_email"].ToString() != "")
                {
                    model.user_email = ds.Tables[0].Rows[0]["user_email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["reply_content"] != null && ds.Tables[0].Rows[0]["reply_content"].ToString() != "")
                {
                    model.reply_content = ds.Tables[0].Rows[0]["reply_content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["reply_time"] != null && ds.Tables[0].Rows[0]["reply_time"].ToString() != "")
                {
                    model.reply_time = DateTime.Parse(ds.Tables[0].Rows[0]["reply_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"] != null && ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,title,content,user_name,user_tel,user_qq,user_email,add_time,reply_content,reply_time,is_lock ");
            strSql.Append(" FROM " + databaseprefix + "feedback ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by add_time desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "feedback");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

		#endregion  Method
	}
    public partial class feedback_cate
    {
       private string databaseprefix; //数据库表名前缀
       public feedback_cate(string _databaseprefix)
		{
            databaseprefix = _databaseprefix;
        }
        #region  BasicMethod

       /// <summary>
       /// 获得查询分页数据
       /// </summary>
       public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * FROM " + databaseprefix + "feedback_cate");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
           return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
       }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.feedback_cate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into  "+ databaseprefix + "feedback_cate(");
            strSql.Append("name)");
            strSql.Append(" values (");
            strSql.Append("@name)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.name;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Model.feedback_cate model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "feedback_cate set ");
            strSql.Append("name=@name");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "feedback_cate");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "feedback_cate ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "feedback_cate ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public Model.feedback_cate GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name from " + databaseprefix + "feedback_cate ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Model.feedback_cate model = new Model.feedback_cate();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Model.feedback_cate DataRowToModel(DataRow row)
        {
            Model.feedback_cate model = new Model.feedback_cate();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name ");
            strSql.Append(" FROM " + databaseprefix + "feedback_cate ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,name ");
            strSql.Append(" FROM " + databaseprefix + "feedback_cate ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM " + databaseprefix + "feedback_cate ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from " + databaseprefix + "feedback_cate T ");
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
            parameters[0].Value = "dt_feedback_cate";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

