using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using SPcms.DBUtility;

namespace SPcms.Web.Plugin.FLink.DAL
{
    /// <summary>
    /// 数据访问类:Flink
    /// </summary>
    public partial class Flink
    {
        private string databaseprefix;

        public Flink(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Flink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "Flink(");
            strSql.Append("Flinkurl,Flinkname,Flinkcode,FlinktfCode,Flinktfnum,Flinktfcontent,Faddtime,Fupdatetime,id,Flinkstat)");
            strSql.Append(" values (");
            strSql.Append("@Flinkurl,@Flinkname,@Flinkcode,@FlinktfCode,@Flinktfnum,@Flinktfcontent,@Faddtime,@Fupdatetime,@id,"+model.Flinkstat+")");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Flinkurl", SqlDbType.NVarChar,500),
					new SqlParameter("@Flinkname", SqlDbType.NVarChar,50),
					new SqlParameter("@Flinkcode", SqlDbType.NChar,10),
					new SqlParameter("@FlinktfCode", SqlDbType.NVarChar,3000),
					new SqlParameter("@Flinktfnum", SqlDbType.Int,4),
					new SqlParameter("@Flinktfcontent", SqlDbType.NVarChar,3000),
					new SqlParameter("@Faddtime", SqlDbType.DateTime),
					new SqlParameter("@Fupdatetime", SqlDbType.DateTime),
                    new SqlParameter("@id", SqlDbType.NChar,32)};
            parameters[0].Value = model.Flinkurl;
            parameters[1].Value = model.Flinkname;
            parameters[2].Value = model.Flinkcode;
            parameters[3].Value = model.FlinktfCode;
            parameters[4].Value = model.Flinktfnum;
            parameters[5].Value = model.Flinktfcontent;
            parameters[6].Value = model.Faddtime;
            parameters[7].Value = model.Fupdatetime;
            parameters[8].Value = model.id;
            int obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return obj;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Flink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Flink set ");
            strSql.Append("Flinkurl=@Flinkurl,");
            strSql.Append("Flinkname=@Flinkname,");
            strSql.Append("Flinkcode=@Flinkcode,");
            strSql.Append("FlinktfCode=@FlinktfCode,");
            strSql.Append("Flinktfnum=@Flinktfnum,");
            strSql.Append("Flinktfcontent=@Flinktfcontent,");
            strSql.Append("Faddtime=@Faddtime,");
            strSql.Append("Fupdatetime=@Fupdatetime");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@Flinkurl", SqlDbType.NVarChar,500),
					new SqlParameter("@Flinkname", SqlDbType.NVarChar,50),
					new SqlParameter("@Flinkcode", SqlDbType.NChar,10),
					new SqlParameter("@FlinktfCode", SqlDbType.NVarChar,3000),
					new SqlParameter("@Flinktfnum", SqlDbType.Int,4),
					new SqlParameter("@Flinktfcontent", SqlDbType.NVarChar,3000),
					new SqlParameter("@Faddtime", SqlDbType.DateTime),
					new SqlParameter("@Fupdatetime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.NChar,16)};
            parameters[0].Value = model.Flinkurl;
            parameters[1].Value = model.Flinkname;
            parameters[2].Value = model.Flinkcode;
            parameters[3].Value = model.FlinktfCode;
            parameters[4].Value = model.Flinktfnum;
            parameters[5].Value = model.Flinktfcontent;
            parameters[6].Value = model.Faddtime;
            parameters[7].Value = model.Fupdatetime;
            parameters[8].Value = model.id;

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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "Flink ");
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
            strSql.Append("delete from " + databaseprefix + "Flink ");
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
        public Model.Flink GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Flinkurl,Flinkname,Flinkcode,FlinktfCode,Flinktfnum,Flinktfcontent,Faddtime,Fupdatetime,Flinkstat from " + databaseprefix + "Flink ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Model.Flink model = new Model.Flink();
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
        public Model.Flink GetModel(int id,bool t)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Flinkurl,Flinkname,Flinkcode,FlinktfCode,Flinktfnum,Flinktfcontent,Faddtime,Fupdatetime,Flinkstat from " + databaseprefix + "Flink ");
            //strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Model.Flink model = new Model.Flink();
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
        public Model.Flink DataRowToModel(DataRow row)
        {
            Model.Flink model = new Model.Flink();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id =row["id"].ToString();
                }
                if (row["Flinkstat"] != null && row["Flinkstat"].ToString() != "")
                {
                    model.Flinkstat = int.Parse(row["Flinkstat"].ToString());
                }
                
                if (row["Flinkurl"] != null)
                {
                    model.Flinkurl = row["Flinkurl"].ToString();
                }
                if (row["Flinkname"] != null)
                {
                    model.Flinkname = row["Flinkname"].ToString();
                }
                if (row["Flinkcode"] != null)
                {
                    model.Flinkcode = row["Flinkcode"].ToString();
                }
                if (row["FlinktfCode"] != null)
                {
                    model.FlinktfCode = row["FlinktfCode"].ToString();
                }
                if (row["Flinktfnum"] != null && row["Flinktfnum"].ToString() != "")
                {
                    model.Flinktfnum = int.Parse(row["Flinktfnum"].ToString());
                }
                if (row["Flinktfcontent"] != null)
                {
                    model.Flinktfcontent = row["Flinktfcontent"].ToString();
                }
                if (row["Faddtime"] != null && row["Faddtime"].ToString() != "")
                {
                    model.Faddtime = DateTime.Parse(row["Faddtime"].ToString());
                }
                if (row["Fupdatetime"] != null && row["Fupdatetime"].ToString() != "")
                {
                    model.Fupdatetime = DateTime.Parse(row["Fupdatetime"].ToString());
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
            strSql.Append("select id,Flinkurl,Flinkname,Flinkcode,FlinktfCode,Flinktfnum,Flinktfcontent,Faddtime,Fupdatetime,Flinkstat ");
            strSql.Append(" FROM " + databaseprefix + "Flink ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Flink set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
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
            strSql.Append(" id,Flinkurl,Flinkname,Flinkcode,FlinktfCode,Flinktfnum,Flinktfcontent,Faddtime,Fupdatetime,Flinkstat ");
            strSql.Append(" FROM " + databaseprefix + "Flink ");
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
            strSql.Append("select count(1) FROM " + databaseprefix + "Flink ");
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
            strSql.Append(")AS Row, T.*  from Flink T ");
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
            parameters[0].Value = "Flink";
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

