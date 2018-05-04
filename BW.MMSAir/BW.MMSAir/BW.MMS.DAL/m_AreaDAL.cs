using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
    /// <summary>
    /// 数据访问类:m_AreaDAL
    /// </summary>
    public partial class m_AreaDAL
    {
        public m_AreaDAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "m_Area");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from m_Area");
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
        public int Add(BW.MMS.Model.m_AreaEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into m_Area(");
            strSql.Append("vc_Code,vc_Name,Point_X,Point_Y,i_Flag,i_parentid,nvc_Type,i_personcount,vc_Memo)");
            strSql.Append(" values (");
            strSql.Append("@vc_Code,@vc_Name,@Point_X,@Point_Y,@i_Flag,@i_parentid,@nvc_Type,@i_personcount,@vc_Memo)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@vc_Code", SqlDbType.NVarChar,10),
					new SqlParameter("@vc_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Point_X", SqlDbType.Decimal,5),
					new SqlParameter("@Point_Y", SqlDbType.Decimal,5),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@i_parentid", SqlDbType.Int,4),
					new SqlParameter("@nvc_Type", SqlDbType.NVarChar,100),
					new SqlParameter("@i_personcount", SqlDbType.Int,4),
					new SqlParameter("@vc_Memo", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.vc_Code;
            parameters[1].Value = model.vc_Name;
            parameters[2].Value = model.Point_X;
            parameters[3].Value = model.Point_Y;
            parameters[4].Value = model.i_Flag;
            parameters[5].Value = model.i_parentid;
            parameters[6].Value = model.nvc_Type;
            parameters[7].Value = model.i_personcount;
            parameters[8].Value = model.vc_Memo;

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
        public bool Update(BW.MMS.Model.m_AreaEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update m_Area set ");
            strSql.Append("vc_Code=@vc_Code,");
            strSql.Append("vc_Name=@vc_Name,");
            strSql.Append("Point_X=@Point_X,");
            strSql.Append("Point_Y=@Point_Y,");
            strSql.Append("i_Flag=@i_Flag,");
            strSql.Append("i_parentid=@i_parentid,");
            strSql.Append("nvc_Type=@nvc_Type,");
            strSql.Append("i_personcount=@i_personcount,");
            strSql.Append("vc_Memo=@vc_Memo");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@vc_Code", SqlDbType.NVarChar,10),
					new SqlParameter("@vc_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Point_X", SqlDbType.Decimal,5),
					new SqlParameter("@Point_Y", SqlDbType.Decimal,5),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@i_parentid", SqlDbType.Int,4),
					new SqlParameter("@nvc_Type", SqlDbType.NVarChar,100),
					new SqlParameter("@i_personcount", SqlDbType.Int,4),
					new SqlParameter("@vc_Memo", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.vc_Code;
            parameters[1].Value = model.vc_Name;
            parameters[2].Value = model.Point_X;
            parameters[3].Value = model.Point_Y;
            parameters[4].Value = model.i_Flag;
            parameters[5].Value = model.i_parentid;
            parameters[6].Value = model.nvc_Type;
            parameters[7].Value = model.i_personcount;
            parameters[8].Value = model.vc_Memo;
            parameters[9].Value = model.ID;

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
            strSql.Append("update m_Area set i_Flag=1 ");
            strSql.Append(" where ID in(select * from dbo.GetAreaChildID(@ID))");
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
            strSql.Append("update m_Area set i_Flag=1");
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
        public BW.MMS.Model.m_AreaEntity GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,vc_Code,vc_Name,Point_X,Point_Y,i_Flag,i_parentid,nvc_Type,i_personcount,vc_Memo from m_Area ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            BW.MMS.Model.m_AreaEntity model = new BW.MMS.Model.m_AreaEntity();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["vc_Code"] != null && ds.Tables[0].Rows[0]["vc_Code"].ToString() != "")
                {
                    model.vc_Code = ds.Tables[0].Rows[0]["vc_Code"].ToString();
                }
                if (ds.Tables[0].Rows[0]["vc_Name"] != null && ds.Tables[0].Rows[0]["vc_Name"].ToString() != "")
                {
                    model.vc_Name = ds.Tables[0].Rows[0]["vc_Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Point_X"] != null && ds.Tables[0].Rows[0]["Point_X"].ToString() != "")
                {
                    model.Point_X = decimal.Parse(ds.Tables[0].Rows[0]["Point_X"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Point_Y"] != null && ds.Tables[0].Rows[0]["Point_Y"].ToString() != "")
                {
                    model.Point_Y = decimal.Parse(ds.Tables[0].Rows[0]["Point_Y"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_Flag"] != null && ds.Tables[0].Rows[0]["i_Flag"].ToString() != "")
                {
                    model.i_Flag = int.Parse(ds.Tables[0].Rows[0]["i_Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["i_parentid"] != null && ds.Tables[0].Rows[0]["i_parentid"].ToString() != "")
                {
                    model.i_parentid = int.Parse(ds.Tables[0].Rows[0]["i_parentid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["nvc_Type"] != null && ds.Tables[0].Rows[0]["nvc_Type"].ToString() != "")
                {
                    model.nvc_Type = ds.Tables[0].Rows[0]["nvc_Type"].ToString();
                }
                if (ds.Tables[0].Rows[0]["i_personcount"] != null && ds.Tables[0].Rows[0]["i_personcount"].ToString() != "")
                {
                    model.i_personcount = int.Parse(ds.Tables[0].Rows[0]["i_personcount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["vc_Memo"] != null && ds.Tables[0].Rows[0]["vc_Memo"].ToString() != "")
                {
                    model.vc_Memo = ds.Tables[0].Rows[0]["vc_Memo"].ToString();
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
            strSql.Append("select ID,vc_Code,vc_Name,Point_X,Point_Y,i_Flag,i_parentid,nvc_Type,i_personcount,vc_Memo ");
            strSql.Append(" FROM m_Area where i_Flag=0");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
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
            strSql.Append(" ID,vc_Code,vc_Name,Point_X,Point_Y,i_Flag,i_parentid,nvc_Type,i_personcount,vc_Memo ");
            strSql.Append(" FROM m_Area ");
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
            strSql.Append("select count(1) FROM m_Area ");
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
            strSql.Append(")AS Row, T.*  from m_Area T ");
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
            parameters[0].Value = "m_Area";
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

