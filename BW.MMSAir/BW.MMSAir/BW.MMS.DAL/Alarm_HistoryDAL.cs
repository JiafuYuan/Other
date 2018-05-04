using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
    /// <summary>
    /// 数据访问类:Alarm_HistoryDAL
    /// </summary>
    public partial class Alarm_HistoryDAL
    {
        public Alarm_HistoryDAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Alarm_History");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Alarm_History");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BW.MMS.Model.Alarm_HistoryEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Alarm_History(");
            strSql.Append("ID,AlarmTypeID,AreaID,vc_Address,dt_BeginTime,dt_EndTime,vc_AlarmReason,vc_UnAlarmPlan,DeptID,vc_DeptName,PersonID,vc_PersonNmae,vc_Memo,i_Flag)");
            strSql.Append(" values (");
            strSql.Append("@ID,@AlarmTypeID,@AreaID,@vc_Address,@dt_BeginTime,@dt_EndTime,@vc_AlarmReason,@vc_UnAlarmPlan,@DeptID,@vc_DeptName,@PersonID,@vc_PersonNmae,@vc_Memo,@i_Flag)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@AlarmTypeID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@vc_Address", SqlDbType.VarChar,200),
					new SqlParameter("@dt_BeginTime", SqlDbType.DateTime),
					new SqlParameter("@dt_EndTime", SqlDbType.DateTime),
					new SqlParameter("@vc_AlarmReason", SqlDbType.VarChar,500),
					new SqlParameter("@vc_UnAlarmPlan", SqlDbType.VarChar,500),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@vc_DeptName", SqlDbType.VarChar,50),
					new SqlParameter("@PersonID", SqlDbType.Int,4),
					new SqlParameter("@vc_PersonNmae", SqlDbType.VarChar,20),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.AlarmTypeID;
            parameters[2].Value = model.AreaID;
            parameters[3].Value = model.vc_Address;
            parameters[4].Value = model.dt_BeginTime;
            parameters[5].Value = model.dt_EndTime;
            parameters[6].Value = model.vc_AlarmReason;
            parameters[7].Value = model.vc_UnAlarmPlan;
            parameters[8].Value = model.DeptID;
            parameters[9].Value = model.vc_DeptName;
            parameters[10].Value = model.PersonID;
            parameters[11].Value = model.vc_PersonNmae;
            parameters[12].Value = model.vc_Memo;
            parameters[13].Value = model.i_Flag;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(BW.MMS.Model.Alarm_HistoryEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Alarm_History set ");
            strSql.Append("AlarmTypeID=@AlarmTypeID,");
            strSql.Append("AreaID=@AreaID,");
            strSql.Append("vc_Address=@vc_Address,");
            strSql.Append("dt_BeginTime=@dt_BeginTime,");
            strSql.Append("dt_EndTime=@dt_EndTime,");
            strSql.Append("vc_AlarmReason=@vc_AlarmReason,");
            strSql.Append("vc_UnAlarmPlan=@vc_UnAlarmPlan,");
            strSql.Append("DeptID=@DeptID,");
            strSql.Append("vc_DeptName=@vc_DeptName,");
            strSql.Append("PersonID=@PersonID,");
            strSql.Append("vc_PersonNmae=@vc_PersonNmae,");
            strSql.Append("vc_Memo=@vc_Memo,");
            strSql.Append("i_Flag=@i_Flag");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AlarmTypeID", SqlDbType.Int,4),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@vc_Address", SqlDbType.VarChar,200),
					new SqlParameter("@dt_BeginTime", SqlDbType.DateTime),
					new SqlParameter("@dt_EndTime", SqlDbType.DateTime),
					new SqlParameter("@vc_AlarmReason", SqlDbType.VarChar,500),
					new SqlParameter("@vc_UnAlarmPlan", SqlDbType.VarChar,500),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@vc_DeptName", SqlDbType.VarChar,50),
					new SqlParameter("@PersonID", SqlDbType.Int,4),
					new SqlParameter("@vc_PersonNmae", SqlDbType.VarChar,20),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.AlarmTypeID;
            parameters[1].Value = model.AreaID;
            parameters[2].Value = model.vc_Address;
            parameters[3].Value = model.dt_BeginTime;
            parameters[4].Value = model.dt_EndTime;
            parameters[5].Value = model.vc_AlarmReason;
            parameters[6].Value = model.vc_UnAlarmPlan;
            parameters[7].Value = model.DeptID;
            parameters[8].Value = model.vc_DeptName;
            parameters[9].Value = model.PersonID;
            parameters[10].Value = model.vc_PersonNmae;
            parameters[11].Value = model.vc_Memo;
            parameters[12].Value = model.i_Flag;
            parameters[13].Value = model.ID;

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
            strSql.Append("delete from Alarm_History ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
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
            strSql.Append("delete from Alarm_History ");
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
        public BW.MMS.Model.Alarm_HistoryEntity GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,AlarmTypeID,AreaID,vc_Address,dt_BeginTime,dt_EndTime,vc_AlarmReason,vc_UnAlarmPlan,DeptID,vc_DeptName,PersonID,vc_PersonNmae,vc_Memo,i_Flag from Alarm_History ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)			};
            parameters[0].Value = ID;

            BW.MMS.Model.Alarm_HistoryEntity model = new BW.MMS.Model.Alarm_HistoryEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AlarmTypeID"] != null && ds.Tables[0].Rows[0]["AlarmTypeID"].ToString() != "")
                {
                    model.AlarmTypeID = int.Parse(ds.Tables[0].Rows[0]["AlarmTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AreaID"] != null && ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["vc_Address"] != null && ds.Tables[0].Rows[0]["vc_Address"].ToString() != "")
                {
                    model.vc_Address = ds.Tables[0].Rows[0]["vc_Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["dt_BeginTime"] != null && ds.Tables[0].Rows[0]["dt_BeginTime"].ToString() != "")
                {
                    model.dt_BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["dt_BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dt_EndTime"] != null && ds.Tables[0].Rows[0]["dt_EndTime"].ToString() != "")
                {
                    model.dt_EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["dt_EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["vc_AlarmReason"] != null && ds.Tables[0].Rows[0]["vc_AlarmReason"].ToString() != "")
                {
                    model.vc_AlarmReason = ds.Tables[0].Rows[0]["vc_AlarmReason"].ToString();
                }
                if (ds.Tables[0].Rows[0]["vc_UnAlarmPlan"] != null && ds.Tables[0].Rows[0]["vc_UnAlarmPlan"].ToString() != "")
                {
                    model.vc_UnAlarmPlan = ds.Tables[0].Rows[0]["vc_UnAlarmPlan"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DeptID"] != null && ds.Tables[0].Rows[0]["DeptID"].ToString() != "")
                {
                    model.DeptID = int.Parse(ds.Tables[0].Rows[0]["DeptID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["vc_DeptName"] != null && ds.Tables[0].Rows[0]["vc_DeptName"].ToString() != "")
                {
                    model.vc_DeptName = ds.Tables[0].Rows[0]["vc_DeptName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PersonID"] != null && ds.Tables[0].Rows[0]["PersonID"].ToString() != "")
                {
                    model.PersonID = int.Parse(ds.Tables[0].Rows[0]["PersonID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["vc_PersonNmae"] != null && ds.Tables[0].Rows[0]["vc_PersonNmae"].ToString() != "")
                {
                    model.vc_PersonNmae = ds.Tables[0].Rows[0]["vc_PersonNmae"].ToString();
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
            strSql.Append("select ID,AlarmTypeID,AreaID,vc_Address,dt_BeginTime,dt_EndTime,vc_AlarmReason,vc_UnAlarmPlan,DeptID,vc_DeptName,PersonID,vc_PersonNmae,vc_Memo,i_Flag ");
            strSql.Append(" FROM Alarm_History ");
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
            strSql.Append(" ID,AlarmTypeID,AreaID,vc_Address,dt_BeginTime,dt_EndTime,vc_AlarmReason,vc_UnAlarmPlan,DeptID,vc_DeptName,PersonID,vc_PersonNmae,vc_Memo,i_Flag ");
            strSql.Append(" FROM Alarm_History ");
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
            strSql.Append("select count(1) FROM Alarm_History ");
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
            strSql.Append(")AS Row, T.*  from Alarm_History T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="where">条件语句</param>
        /// <param name="page">当前页</param>
        /// <param name="rows">每页显示条数</param>
        /// <param name="sort">提序字段</param>
        /// <param name="order">排序方式</param>
        /// <param name="total">返回总条数</param>
        /// <returns></returns>
        public DataTable GetPagingList(string where, int page, int rows, string sort, string order, out int total)
        {
            QueryParam param = new QueryParam();
            param.Orderfld = sort;
            if (order.ToUpper() == "ASC")
            {
                param.OrderType = 2;
            }
            else
            {
                param.OrderType = 1;
            }
            param.PageIndex = page;
            param.PageSize = rows;
            param.ReturnFields = " [ID],[vc_Code],[DeptName],[AreaName],[vc_Address],[vc_AlarmName],[dt_BeginTime],[dt_EndTime],[CumulativeDate],[vc_AlarmReason] ";
            param.TableName = " v_Alarm_History ";
            string strWhere = " where 1=1 ";
            if (!string.IsNullOrEmpty(where))
            {
                strWhere += where;
            }
            param.Where = strWhere;
            return DbHelperSQL.SelectDataByStoredProcedure(param, out total);
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
            parameters[0].Value = "Alarm_History";
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

