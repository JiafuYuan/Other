/**  版本信息模板在安装目录下，可自行修改。
* m_EnergyPlanDAL.cs
*
* 功 能： N/A
* 类 名： m_EnergyPlanDAL
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-10-29 17:40:19   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
    /// <summary>
    /// 数据访问类:m_EnergyPlanDAL
    /// </summary>
    public partial class m_EnergyPlanDAL
    {
        public m_EnergyPlanDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "m_EnergyPlan");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from m_EnergyPlan");
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
        public int Add(BW.MMS.Model.m_EnergyPlanEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into m_EnergyPlan(");
            strSql.Append("DeptID,Years,Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec,type)");
            strSql.Append(" values (");
            strSql.Append("@DeptID,@Years,@Jan,@Feb,@Mar,@Apr,@May,@Jun,@Jul,@Aug,@Sep,@Oct,@Nov,@Dec,@type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@Years", SqlDbType.Int,4),
					new SqlParameter("@Jan", SqlDbType.Float,8),
					new SqlParameter("@Feb", SqlDbType.Float,8),
					new SqlParameter("@Mar", SqlDbType.Float,8),
					new SqlParameter("@Apr", SqlDbType.Float,8),
					new SqlParameter("@May", SqlDbType.Float,8),
					new SqlParameter("@Jun", SqlDbType.Float,8),
					new SqlParameter("@Jul", SqlDbType.Float,8),
					new SqlParameter("@Aug", SqlDbType.Float,8),
					new SqlParameter("@Sep", SqlDbType.Float,8),
					new SqlParameter("@Oct", SqlDbType.Float,8),
					new SqlParameter("@Nov", SqlDbType.Float,8),
					new SqlParameter("@Dec", SqlDbType.Float,8),
					new SqlParameter("@type", SqlDbType.Int,4)};
            parameters[0].Value = model.DeptID;
            parameters[1].Value = model.Years;
            parameters[2].Value = model.Jan;
            parameters[3].Value = model.Feb;
            parameters[4].Value = model.Mar;
            parameters[5].Value = model.Apr;
            parameters[6].Value = model.May;
            parameters[7].Value = model.Jun;
            parameters[8].Value = model.Jul;
            parameters[9].Value = model.Aug;
            parameters[10].Value = model.Sep;
            parameters[11].Value = model.Oct;
            parameters[12].Value = model.Nov;
            parameters[13].Value = model.Dec;
            parameters[14].Value = model.type;

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
        public bool Update(BW.MMS.Model.m_EnergyPlanEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update m_EnergyPlan set ");
            strSql.Append("DeptID=@DeptID,");
            strSql.Append("Years=@Years,");
            strSql.Append("Jan=@Jan,");
            strSql.Append("Feb=@Feb,");
            strSql.Append("Mar=@Mar,");
            strSql.Append("Apr=@Apr,");
            strSql.Append("May=@May,");
            strSql.Append("Jun=@Jun,");
            strSql.Append("Jul=@Jul,");
            strSql.Append("Aug=@Aug,");
            strSql.Append("Sep=@Sep,");
            strSql.Append("Oct=@Oct,");
            strSql.Append("Nov=@Nov,");
            strSql.Append("Dec=@Dec,");
            strSql.Append("type=@type");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@Years", SqlDbType.Int,4),
					new SqlParameter("@Jan", SqlDbType.Float,8),
					new SqlParameter("@Feb", SqlDbType.Float,8),
					new SqlParameter("@Mar", SqlDbType.Float,8),
					new SqlParameter("@Apr", SqlDbType.Float,8),
					new SqlParameter("@May", SqlDbType.Float,8),
					new SqlParameter("@Jun", SqlDbType.Float,8),
					new SqlParameter("@Jul", SqlDbType.Float,8),
					new SqlParameter("@Aug", SqlDbType.Float,8),
					new SqlParameter("@Sep", SqlDbType.Float,8),
					new SqlParameter("@Oct", SqlDbType.Float,8),
					new SqlParameter("@Nov", SqlDbType.Float,8),
					new SqlParameter("@Dec", SqlDbType.Float,8),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.DeptID;
            parameters[1].Value = model.Years;
            parameters[2].Value = model.Jan;
            parameters[3].Value = model.Feb;
            parameters[4].Value = model.Mar;
            parameters[5].Value = model.Apr;
            parameters[6].Value = model.May;
            parameters[7].Value = model.Jun;
            parameters[8].Value = model.Jul;
            parameters[9].Value = model.Aug;
            parameters[10].Value = model.Sep;
            parameters[11].Value = model.Oct;
            parameters[12].Value = model.Nov;
            parameters[13].Value = model.Dec;
            parameters[14].Value = model.type;
            parameters[15].Value = model.ID;

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
            strSql.Append("delete from m_EnergyPlan ");
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
            strSql.Append("delete from m_EnergyPlan ");
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
        public BW.MMS.Model.m_EnergyPlanEntity GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,DeptID,Years,Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec,type from m_EnergyPlan ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            BW.MMS.Model.m_EnergyPlanEntity model = new BW.MMS.Model.m_EnergyPlanEntity();
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
        public BW.MMS.Model.m_EnergyPlanEntity DataRowToModel(DataRow row)
        {
            BW.MMS.Model.m_EnergyPlanEntity model = new BW.MMS.Model.m_EnergyPlanEntity();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["DeptID"] != null && row["DeptID"].ToString() != "")
                {
                    model.DeptID = int.Parse(row["DeptID"].ToString());
                }
                if (row["Years"] != null && row["Years"].ToString() != "")
                {
                    model.Years = int.Parse(row["Years"].ToString());
                }
                if (row["Jan"] != null && row["Jan"].ToString() != "")
                {
                    model.Jan = decimal.Parse(row["Jan"].ToString());
                }
                if (row["Feb"] != null && row["Feb"].ToString() != "")
                {
                    model.Feb = decimal.Parse(row["Feb"].ToString());
                }
                if (row["Mar"] != null && row["Mar"].ToString() != "")
                {
                    model.Mar = decimal.Parse(row["Mar"].ToString());
                }
                if (row["Apr"] != null && row["Apr"].ToString() != "")
                {
                    model.Apr = decimal.Parse(row["Apr"].ToString());
                }
                if (row["May"] != null && row["May"].ToString() != "")
                {
                    model.May = decimal.Parse(row["May"].ToString());
                }
                if (row["Jun"] != null && row["Jun"].ToString() != "")
                {
                    model.Jun = decimal.Parse(row["Jun"].ToString());
                }
                if (row["Jul"] != null && row["Jul"].ToString() != "")
                {
                    model.Jul = decimal.Parse(row["Jul"].ToString());
                }
                if (row["Aug"] != null && row["Aug"].ToString() != "")
                {
                    model.Aug = decimal.Parse(row["Aug"].ToString());
                }
                if (row["Sep"] != null && row["Sep"].ToString() != "")
                {
                    model.Sep = decimal.Parse(row["Sep"].ToString());
                }
                if (row["Oct"] != null && row["Oct"].ToString() != "")
                {
                    model.Oct = decimal.Parse(row["Oct"].ToString());
                }
                if (row["Nov"] != null && row["Nov"].ToString() != "")
                {
                    model.Nov = decimal.Parse(row["Nov"].ToString());
                }
                if (row["Dec"] != null && row["Dec"].ToString() != "")
                {
                    model.Dec = decimal.Parse(row["Dec"].ToString());
                }
                if (row["type"] != null && row["type"].ToString() != "")
                {
                    model.type = int.Parse(row["type"].ToString());
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
            strSql.Append("select ID,DeptID,Years,Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec,type ");
            strSql.Append(" FROM m_EnergyPlan ");
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
            strSql.Append(" ID,DeptID,Years,Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec,type ");
            strSql.Append(" FROM m_EnergyPlan ");
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
            strSql.Append("select count(1) FROM m_EnergyPlan ");
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
            strSql.Append(")AS Row, T.*  from m_EnergyPlan T ");
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
            parameters[0].Value = "m_EnergyPlan";
            parameters[1].Value = "ID";
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

