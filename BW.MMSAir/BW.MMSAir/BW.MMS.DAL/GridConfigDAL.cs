using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;

namespace BW_AutoMationSysConfig.DAL
{
    /// <summary>
    /// 数据访问类:GridConfig
    /// </summary>
    public partial class GridConfigDAL
    {
        public GridConfigDAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "sys_GridConfig");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_GridConfig");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BW.MMS.Model.GridConfigEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_GridConfig(");
            strSql.Append("GridKeyName,ChineseName,ApplicationCode,IDField,ischk,PageCode,Type,TVName)");
            strSql.Append(" values (");
            strSql.Append("@GridKeyName,@ChineseName,@ApplicationCode,@IDField,@ischk,@PageCode,@Type,@TVName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GridKeyName", SqlDbType.NVarChar,50),
					new SqlParameter("@ChineseName", SqlDbType.NVarChar,50),
					new SqlParameter("@ApplicationCode", SqlDbType.VarChar,50),
					new SqlParameter("@IDField", SqlDbType.VarChar,50),
					new SqlParameter("@ischk", SqlDbType.Bit,1),
					new SqlParameter("@PageCode", SqlDbType.VarChar,20),
					new SqlParameter("@Type", SqlDbType.Char,1),
					new SqlParameter("@TVName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.GridKeyName;
            parameters[1].Value = model.ChineseName;
            parameters[2].Value = model.ApplicationCode;
            parameters[3].Value = model.IDField;
            parameters[4].Value = model.ischk;
            parameters[5].Value = model.PageCode;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.TVName;

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
        public bool Update(BW.MMS.Model.GridConfigEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_GridConfig set ");
            strSql.Append("GridKeyName=@GridKeyName,");
            strSql.Append("ChineseName=@ChineseName,");
            strSql.Append("ApplicationCode=@ApplicationCode,");
            strSql.Append("IDField=@IDField,");
            strSql.Append("ischk=@ischk,");
            strSql.Append("PageCode=@PageCode,");
            strSql.Append("Type=@Type,");
            strSql.Append("TVName=@TVName");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@GridKeyName", SqlDbType.NVarChar,50),
					new SqlParameter("@ChineseName", SqlDbType.NVarChar,50),
					new SqlParameter("@ApplicationCode", SqlDbType.VarChar,50),
					new SqlParameter("@IDField", SqlDbType.VarChar,50),
					new SqlParameter("@ischk", SqlDbType.Bit,1),
					new SqlParameter("@PageCode", SqlDbType.VarChar,20),
					new SqlParameter("@Type", SqlDbType.Char,1),
					new SqlParameter("@TVName", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.GridKeyName;
            parameters[1].Value = model.ChineseName;
            parameters[2].Value = model.ApplicationCode;
            parameters[3].Value = model.IDField;
            parameters[4].Value = model.ischk;
            parameters[5].Value = model.PageCode;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.TVName;
            parameters[8].Value = model.ID;

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
            strSql.Append("delete from sys_GridConfig ");
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_GridConfig ");
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
        public BW.MMS.Model.GridConfigEntity GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,GridKeyName,ChineseName,ApplicationCode,IDField,ischk,PageCode,Type,TVName from sys_GridConfig ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            BW.MMS.Model.GridConfigEntity model = new BW.MMS.Model.GridConfigEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GridKeyName"] != null && ds.Tables[0].Rows[0]["GridKeyName"].ToString() != "")
                {
                    model.GridKeyName = ds.Tables[0].Rows[0]["GridKeyName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ChineseName"] != null && ds.Tables[0].Rows[0]["ChineseName"].ToString() != "")
                {
                    model.ChineseName = ds.Tables[0].Rows[0]["ChineseName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ApplicationCode"] != null && ds.Tables[0].Rows[0]["ApplicationCode"].ToString() != "")
                {
                    model.ApplicationCode = ds.Tables[0].Rows[0]["ApplicationCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IDField"] != null && ds.Tables[0].Rows[0]["IDField"].ToString() != "")
                {
                    model.IDField = ds.Tables[0].Rows[0]["IDField"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ischk"] != null && ds.Tables[0].Rows[0]["ischk"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ischk"].ToString() == "1") || (ds.Tables[0].Rows[0]["ischk"].ToString().ToLower() == "true"))
                    {
                        model.ischk = true;
                    }
                    else
                    {
                        model.ischk = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PageCode"] != null && ds.Tables[0].Rows[0]["PageCode"].ToString() != "")
                {
                    model.PageCode = ds.Tables[0].Rows[0]["PageCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Type"] != null && ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = ds.Tables[0].Rows[0]["Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TVName"] != null && ds.Tables[0].Rows[0]["TVName"].ToString() != "")
                {
                    model.TVName = ds.Tables[0].Rows[0]["TVName"].ToString();
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
            strSql.Append("select ID,GridKeyName,ChineseName,ApplicationCode,IDField,ischk,PageCode,Type,TVName ");
            strSql.Append(" FROM sys_GridConfig ");
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
            strSql.Append(" ID,GridKeyName,ChineseName,ApplicationCode,IDField,ischk,PageCode,Type,TVName ");
            strSql.Append(" FROM sys_GridConfig ");
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
            strSql.Append("select count(1) FROM sys_GridConfig ");
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
            strSql.Append(")AS Row, T.*  from sys_GridConfig T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method

        /// <summary>
        /// grid配置数据
        /// </summary>
        /// <param name="GridName"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="sort"></param>
        /// <param name="dir"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public DataTable GetPagingList(string name, int page, int rows, string sort, string order, out int record)
        {
            QueryParam param = new QueryParam();
            param.Orderfld = sort;
            if (string.Compare("ASC", order, true) == 0)
            {
                param.OrderType = 2;
            }
            else
            {
                param.OrderType = 1;
            }
            param.PageIndex = page;
            param.PageSize = rows;
            param.ReturnFields = " * ";
            param.TableName = " sys_GridConfig ";
            string strWhere = " WHERE 1 = 1  ";
            if (!string.IsNullOrEmpty(name))
            {
                strWhere += string.Format("AND (GridKeyName LIKE '%{0}%' or GridKeyName LIKE '%{0}%')", name);
            }
            param.Where = strWhere;
            return DbHelperSQL.SelectDataByStoredProcedure(param, out record);
        }
        /// <summary>
        /// 获取表和视图集合
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetTableViews(string type)
        {
            string sql = string.Format("select name as  ID,name as Name from sysobjects where xtype= '{0}' order by id", type);
            return DbHelperSQL.Query(sql);
        }
        /// <summary>
        /// 获取指定表/视图字段信息
        /// </summary>
        /// <param name="gridconfigID"></param>
        /// <param name="ParentID"></param>
        /// <param name="tvName"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public DataSet GetTVField(int gridconfigID, int ParentID, string tvName,string type)
        {
            if (type == "p")
            {
                return DbHelperSQL.RunProcedure(tvName, new SqlParameter[] { }, "tab", 2000);
            }
            string sql = @" SELECT ISNULL(CONVERT(NVARCHAR, C.title,100),CONVERT(NVARCHAR, B.value,100)) AS title ,
                            ISNULL(CONVERT(NVARCHAR, C.field,100),CONVERT(NVARCHAR, A.name,100)) AS field ,
                            A.is_identity,C.ID,C.gridconfigID,C.ParentID,C.width,C.colspan,
                            C.rowspan,C.iscolspan,C.align,C.sortable,C.showposition,C.hidden,CASE  WHEN C.ID IS NULL THEN 0 ELSE 1 END AS isshow
                            FROM sys.all_columns AS A
                            LEFT JOIN sys.extended_properties AS B ON B.minor_id = A.column_id AND B.major_id=object_id('" + tvName + "')";
            sql += "  LEFT JOIN sys_GridColumnConfig AS C ON C.field = A.name AND C.gridconfigID=" + gridconfigID + " AND C.ParentID=" + ParentID + "";
            sql += "   WHERE A.object_id=object_id('" + tvName + "')  ORDER BY A.name";
            return DbHelperSQL.Query(sql);
        }
    }
}

