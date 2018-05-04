using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;

namespace BW_AutoMationSysConfig.DAL
{
    /// <summary>
    /// 数据访问类:GridColumnConfig
    /// </summary>
    public partial class GridColumnConfigDAL
    {
        public GridColumnConfigDAL()
        { }
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from sys_GridColumnConfig");
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
        public int Add(BW.MMS.Model.GridColumnConfigEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into sys_GridColumnConfig(");
            strSql.Append("gridconfigID,ParentID,title,field,width,rowspan,iscolspan,colspan,align,hidden,sortable,showposition)");
            strSql.Append(" values (");
            strSql.Append("@gridconfigID,@ParentID,@title,@field,@width,@rowspan,@iscolspan,@colspan,@align,@hidden,@sortable,@showposition)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@gridconfigID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@field", SqlDbType.VarChar,50),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@rowspan", SqlDbType.Int,4),
					new SqlParameter("@iscolspan", SqlDbType.Bit,1),
					new SqlParameter("@colspan", SqlDbType.Int,4),
					new SqlParameter("@align", SqlDbType.VarChar,10),
					new SqlParameter("@hidden", SqlDbType.Bit,1),
					new SqlParameter("@sortable", SqlDbType.Bit,1),
					new SqlParameter("@showposition", SqlDbType.Int,4)};
            parameters[0].Value = model.gridconfigID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.title;
            parameters[3].Value = model.field;
            parameters[4].Value = model.width;
            parameters[5].Value = model.rowspan;
            parameters[6].Value = model.iscolspan;
            parameters[7].Value = model.colspan;
            parameters[8].Value = model.align;
            parameters[9].Value = model.hidden;
            parameters[10].Value = model.sortable;
            parameters[11].Value = model.showposition;

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
        public bool Update(BW.MMS.Model.GridColumnConfigEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update sys_GridColumnConfig set ");
            strSql.Append("gridconfigID=@gridconfigID,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("title=@title,");
            strSql.Append("field=@field,");
            strSql.Append("width=@width,");
            strSql.Append("rowspan=@rowspan,");
            strSql.Append("iscolspan=@iscolspan,");
            strSql.Append("colspan=@colspan,");
            strSql.Append("align=@align,");
            strSql.Append("hidden=@hidden,");
            strSql.Append("sortable=@sortable,");
            strSql.Append("showposition=@showposition");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@gridconfigID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@field", SqlDbType.VarChar,50),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@rowspan", SqlDbType.Int,4),
					new SqlParameter("@iscolspan", SqlDbType.Bit,1),
					new SqlParameter("@colspan", SqlDbType.Int,4),
					new SqlParameter("@align", SqlDbType.VarChar,10),
					new SqlParameter("@hidden", SqlDbType.Bit,1),
					new SqlParameter("@sortable", SqlDbType.Bit,1),
					new SqlParameter("@showposition", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.gridconfigID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.title;
            parameters[3].Value = model.field;
            parameters[4].Value = model.width;
            parameters[5].Value = model.rowspan;
            parameters[6].Value = model.iscolspan;
            parameters[7].Value = model.colspan;
            parameters[8].Value = model.align;
            parameters[9].Value = model.hidden;
            parameters[10].Value = model.sortable;
            parameters[11].Value = model.showposition;
            parameters[12].Value = model.ID;

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
            strSql.Append("delete from sys_GridColumnConfig ");
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
            strSql.Append("delete from sys_GridColumnConfig ");
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
        public BW.MMS.Model.GridColumnConfigEntity GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,gridconfigID,ParentID,title,field,width,rowspan,iscolspan,colspan,align,hidden,sortable,showposition from sys_GridColumnConfig ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            BW.MMS.Model.GridColumnConfigEntity model = new BW.MMS.Model.GridColumnConfigEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gridconfigID"] != null && ds.Tables[0].Rows[0]["gridconfigID"].ToString() != "")
                {
                    model.gridconfigID = int.Parse(ds.Tables[0].Rows[0]["gridconfigID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ParentID"] != null && ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["field"] != null && ds.Tables[0].Rows[0]["field"].ToString() != "")
                {
                    model.field = ds.Tables[0].Rows[0]["field"].ToString();
                }
                if (ds.Tables[0].Rows[0]["width"] != null && ds.Tables[0].Rows[0]["width"].ToString() != "")
                {
                    model.width = int.Parse(ds.Tables[0].Rows[0]["width"].ToString());
                }
                if (ds.Tables[0].Rows[0]["rowspan"] != null && ds.Tables[0].Rows[0]["rowspan"].ToString() != "")
                {
                    model.rowspan = int.Parse(ds.Tables[0].Rows[0]["rowspan"].ToString());
                }
                if (ds.Tables[0].Rows[0]["iscolspan"] != null && ds.Tables[0].Rows[0]["iscolspan"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["iscolspan"].ToString() == "1") || (ds.Tables[0].Rows[0]["iscolspan"].ToString().ToLower() == "true"))
                    {
                        model.iscolspan = true;
                    }
                    else
                    {
                        model.iscolspan = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["colspan"] != null && ds.Tables[0].Rows[0]["colspan"].ToString() != "")
                {
                    model.colspan = int.Parse(ds.Tables[0].Rows[0]["colspan"].ToString());
                }
                if (ds.Tables[0].Rows[0]["align"] != null && ds.Tables[0].Rows[0]["align"].ToString() != "")
                {
                    model.align = ds.Tables[0].Rows[0]["align"].ToString();
                }
                if (ds.Tables[0].Rows[0]["hidden"] != null && ds.Tables[0].Rows[0]["hidden"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["hidden"].ToString() == "1") || (ds.Tables[0].Rows[0]["hidden"].ToString().ToLower() == "true"))
                    {
                        model.hidden = true;
                    }
                    else
                    {
                        model.hidden = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["sortable"] != null && ds.Tables[0].Rows[0]["sortable"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["sortable"].ToString() == "1") || (ds.Tables[0].Rows[0]["sortable"].ToString().ToLower() == "true"))
                    {
                        model.sortable = true;
                    }
                    else
                    {
                        model.sortable = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["showposition"] != null && ds.Tables[0].Rows[0]["showposition"].ToString() != "")
                {
                    model.showposition = int.Parse(ds.Tables[0].Rows[0]["showposition"].ToString());
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
            strSql.Append("select ID,gridconfigID,ParentID,title,field,width,rowspan,iscolspan,colspan,align,hidden,sortable,showposition ");
            strSql.Append(" FROM sys_GridColumnConfig ");
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
            strSql.Append(" ID,gridconfigID,ParentID,title,field,width,rowspan,iscolspan,colspan,align,hidden,sortable,showposition ");
            strSql.Append(" FROM sys_GridColumnConfig ");
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
            strSql.Append("select count(1) FROM sys_GridColumnConfig ");
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
            strSql.Append(")AS Row, T.*  from sys_GridColumnConfig T ");
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
        /// grid配置详情
        /// </summary>
        /// <param name="GridID"></param>
        /// <param name="ParentID"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="sort"></param>
        /// <param name="dir"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public DataTable GetPagingList(int GridID, int ParentID, int PageIndex, int PageSize, string sort, string dir, out int RecordCount)
        {
            QueryParam param = new QueryParam();
            param.Orderfld = sort;
            if (string.Compare("ASC", dir, true) == 0)
            {
                param.OrderType = 2;
            }
            else
            {
                param.OrderType = 1;
            }
            param.PageIndex = PageIndex;
            param.PageSize = PageSize;
            param.ReturnFields = " ID,gridconfigID,ParentID,title,field,width,align,hidden,sortable,showposition,dbo.GetChildPlaceNum(sys_GridColumnConfig.ID,sys_GridColumnConfig.gridconfigID) AS iscolspan ";
            param.TableName = " sys_GridColumnConfig ";
            string strWhere = " WHERE 1 = 1  ";
            strWhere += " AND gridconfigID = " + GridID + " AND ParentID=" + ParentID + " ";
            param.Where = strWhere;
            return DbHelperSQL.SelectDataByStoredProcedure(param, out RecordCount);
        }

        /// <summary>
        /// 获取指定表/视图字段信息
        /// </summary>
        /// <param name="gridconfigID"></param>
        /// <param name="ParentID"></param>
        /// <param name="tvName"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public DataSet GetTVField(int gridconfigID, int ParentID, string tvName, string connection)
        {
            string sql = @" SELECT ISNULL(CONVERT(NVARCHAR, C.title,100),CONVERT(NVARCHAR, B.value,100)) AS title ,
                            ISNULL(CONVERT(NVARCHAR, C.field,100),CONVERT(NVARCHAR, A.name,100)) AS field ,
                            A.is_identity,C.ID,C.gridconfigID,C.ParentID,C.width,C.colspan,
                            C.rowspan,C.iscolspan,C.align,C.sortable,C.showposition,C.hidden,CASE  WHEN C.ID IS NULL THEN 0 ELSE 1 END AS isshow
                            FROM sys.all_columns AS A
                            LEFT JOIN sys.extended_properties AS B ON B.minor_id = A.column_id AND B.major_id=object_id('" + tvName + "')";
            sql += "  LEFT JOIN BW_AUTOSYS.dbo.sys_GridColumnConfig AS C ON C.field = A.name AND C.gridconfigID=" + gridconfigID + " AND C.ParentID=" + ParentID + "";
            sql += "   WHERE A.object_id=object_id('" + tvName + "')  ORDER BY A.name";
            return DbHelperSQL.Query(sql, connection);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListLev(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,gridconfigID,ParentID,title,field,width,rowspan,iscolspan,colspan,align,hidden,sortable,showposition,dbo.GetChildPlaceNum(sys_GridColumnConfig.ID,sys_GridColumnConfig.gridconfigID) AS PlaceNum,dbo.GetPlaceMsg(sys_GridColumnConfig.ID,sys_GridColumnConfig.gridconfigID) AS  Lev");
            strSql.Append(" FROM sys_GridColumnConfig ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByParentID(int ParentID,int gridID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sys_GridColumnConfig ");
            strSql.Append(" WHERE ParentID=@ParentID AND gridconfigID=@gridID");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4),
                    new SqlParameter("@gridID", SqlDbType.Int,4)
			};
            parameters[0].Value = ParentID;
            parameters[1].Value = gridID;

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
        public bool DeleteByParentID(int ParentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sys_GridColumnConfig ");
            strSql.Append(" WHERE ID IN (SELECT * FROM dbo.GetChildAll(@ParentID))");
            SqlParameter[] parameters = {
					new SqlParameter("@ParentID", SqlDbType.Int,4)
			};
            parameters[0].Value = ParentID;

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
        public bool DeleteByGridID(string gridID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM sys_GridColumnConfig ");
            strSql.Append(" WHERE gridconfigID IN (@gridID)");
            SqlParameter[] parameters = {
                    new SqlParameter("@gridID", SqlDbType.NVarChar)
			};
            parameters[0].Value = gridID;

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
    }
}

