using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
    /// <summary>
    /// 数据访问类:m_ArrayClassDAL
    /// </summary>
    public partial class m_ArrayClassDAL
    {
        public m_ArrayClassDAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("DeptID", "m_ArrayClass");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(DateTime dt_Date, int DeptID, int ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from m_ArrayClass");
            strSql.Append(" where dt_Date=@dt_Date and DeptID=@DeptID and ClassID=@ClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@dt_Date", SqlDbType.DateTime),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@ClassID", SqlDbType.Int,4)			};
            parameters[0].Value = dt_Date;
            parameters[1].Value = DeptID;
            parameters[2].Value = ClassID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BW.MMS.Model.m_ArrayClassEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into m_ArrayClass(");
            strSql.Append("dt_Date,DeptID,ClassID,vc_Memo,i_Flag)");
            strSql.Append(" values (");
            strSql.Append("@dt_Date,@DeptID,@ClassID,@vc_Memo,@i_Flag)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@dt_Date", SqlDbType.DateTime),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4)};
            parameters[0].Value = model.dt_Date;
            parameters[1].Value = model.DeptID;
            parameters[2].Value = model.ClassID;
            parameters[3].Value = model.vc_Memo;
            parameters[4].Value = model.i_Flag;

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
        public bool Update(BW.MMS.Model.m_ArrayClassEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update m_ArrayClass set ");
            strSql.Append("vc_Memo=@vc_Memo,");
            strSql.Append("i_Flag=@i_Flag");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@dt_Date", SqlDbType.DateTime),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@ClassID", SqlDbType.Int,4)};
            parameters[0].Value = model.vc_Memo;
            parameters[1].Value = model.i_Flag;
            parameters[2].Value = model.ID;
            parameters[3].Value = model.dt_Date;
            parameters[4].Value = model.DeptID;
            parameters[5].Value = model.ClassID;

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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_ArrayClass ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

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
        /// 删除数据
        /// </summary>
        public bool Delete(DateTime beginDate, DateTime endDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_ArrayClass ");
            strSql.Append(" where dt_Date>=@beginDate and dt_Date<=@endDate ");
            SqlParameter[] parameters = {
					new SqlParameter("@beginDate", SqlDbType.DateTime),
					new SqlParameter("@endDate", SqlDbType.DateTime)};
            parameters[0].Value = beginDate;
            parameters[1].Value = endDate;
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
        public bool Delete(DateTime dt_Date, int DeptID, int ClassID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_ArrayClass ");
            strSql.Append(" where dt_Date=@dt_Date and DeptID=@DeptID and ClassID=@ClassID ");
            SqlParameter[] parameters = {
					new SqlParameter("@dt_Date", SqlDbType.DateTime),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@ClassID", SqlDbType.Int,4)			};
            parameters[0].Value = dt_Date;
            parameters[1].Value = DeptID;
            parameters[2].Value = ClassID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_ArrayClass ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public BW.MMS.Model.m_ArrayClassEntity GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,dt_Date,DeptID,ClassID,vc_Memo,i_Flag from m_ArrayClass ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            BW.MMS.Model.m_ArrayClassEntity model = new BW.MMS.Model.m_ArrayClassEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dt_Date"] != null && ds.Tables[0].Rows[0]["dt_Date"].ToString() != "")
                {
                    model.dt_Date = DateTime.Parse(ds.Tables[0].Rows[0]["dt_Date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DeptID"] != null && ds.Tables[0].Rows[0]["DeptID"].ToString() != "")
                {
                    model.DeptID = int.Parse(ds.Tables[0].Rows[0]["DeptID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClassID"] != null && ds.Tables[0].Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["vc_Memo"] != null && ds.Tables[0].Rows[0]["vc_Memo"].ToString() != "")
                {
                    model.vc_Memo = ds.Tables[0].Rows[0]["vc_Memo"].ToString();
                }
                if (ds.Tables[0].Rows[0]["i_Flag"] != null && ds.Tables[0].Rows[0]["i_Flag"].ToString() != "")
                {
                    model.i_Flag = int.Parse(ds.Tables[0].Rows[0]["i_Flag"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,dt_Date,DeptID,ClassID,vc_Memo,i_Flag ");
            strSql.Append(" FROM m_ArrayClass ");
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
            strSql.Append(" ID,dt_Date,DeptID,ClassID,vc_Memo,i_Flag ");
            strSql.Append(" FROM m_ArrayClass ");
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
            strSql.Append("select count(1) FROM m_ArrayClass ");
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
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from m_ArrayClass T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataTable GetArrayClass()
        {
            string strSql = "SELECT t.nvc_name AS classTypeName,c.ID ClassID,c.nvc_name AS ClassName,'' AS DeptID,'' AS DeptName  FROM m_Class c left join m_ClassType t ON c.classTypeID=t.ID";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public DataSet GetArrayList(DateTime startDate, DateTime endDate)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@BeginDate", SqlDbType.DateTime),
					new SqlParameter("@EndDate", SqlDbType.DateTime)	};
            parameters[0].Value = startDate;
            parameters[1].Value = endDate;
            return DbHelperSQL.RunProcedure("p_ArrayClassTable", parameters, "table", 1000);
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
            parameters[0].Value = "m_ArrayClass";
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

