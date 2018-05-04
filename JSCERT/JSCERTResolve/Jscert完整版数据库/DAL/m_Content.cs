/**  版本信息模板在安装目录下，可自行修改。
* m_Content.cs
*
* 功 能： N/A
* 类 名： m_Content
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/4/13 11:24:32   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Data.SqlClient;
namespace JSCERT.DAL
{
    /// <summary>
    /// 数据访问类:m_Content
    /// </summary>
    public partial class m_Content
    {
        public m_Content()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(JSCERT.Model.m_Content model)
        {
            OleDbParameter[] parameters = new OleDbParameter[5];
            parameters[0] = new OleDbParameter("@vc_Content", model.vc_Content);
            parameters[1] = new OleDbParameter("@vc_Source", model.vc_Source);
            parameters[2] = new OleDbParameter("@vc_Title", model.vc_Title);
            parameters[3] = new OleDbParameter("@TitleID", model.TitleID);
            parameters[4] = new OleDbParameter("@i_Flag", model.i_Flag);
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.vc_Content != null)
            {
                strSql1.Append("vc_Content,");
                strSql2.Append("?,");
            }
            if (model.vc_Source != null)
            {
                strSql1.Append("vc_Source,");
                strSql2.Append("?,");
            }
            if (model.vc_Title != null)
            {
                strSql1.Append("vc_Title,");
                strSql2.Append("?,");
            }
            if (model.TitleID != null)
            {
                strSql1.Append("TitleID,");
                strSql2.Append("?,");
            }
            if (model.i_Flag != null)
            {
                strSql1.Append("i_Flag,");
                strSql2.Append("?,");
            }
            strSql.Append("insert into m_Content(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            object obj = DB.OleDbHelper.ExecuteSql(strSql.ToString(), parameters, CommandType.Text);
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
        public bool Update(JSCERT.Model.m_Content model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update m_Content set ");
            if (model.vc_Content != null)
            {
                strSql.Append("vc_Content='" + model.vc_Content + "',");
            }
            if (model.vc_Source != null)
            {
                strSql.Append("vc_Source='" + model.vc_Source + "',");
            }
            if (model.vc_Title != null)
            {
                strSql.Append("vc_Title='" + model.vc_Title + "',");
            }
            if (model.TitleID != null)
            {
                strSql.Append("TitleID=" + model.TitleID + ",");
            }
            if (model.i_Flag != null)
            {
                strSql.Append("i_Flag=" + model.i_Flag + ",");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where ID=" + model.ID + "");
            int rowsAffected = DB.OleDbHelper.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
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
            strSql.Append("delete from m_Content ");
            strSql.Append(" where ID=" + ID + "");
            int rowsAffected = DB.OleDbHelper.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
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
        public JSCERT.Model.m_Content GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ID,vc_Content,vc_Source,vc_Title,TitleID,i_Flag ");
            strSql.Append(" from m_Content ");
            strSql.Append(" where ID=" + ID + "");
            JSCERT.Model.m_Content model = new JSCERT.Model.m_Content();
            DataSet ds = DB.OleDbHelper.GetDataSet(strSql.ToString());
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
        public JSCERT.Model.m_Content DataRowToModel(DataRow row)
        {
            JSCERT.Model.m_Content model = new JSCERT.Model.m_Content();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["vc_Content"] != null)
                {
                    model.vc_Content = row["vc_Content"].ToString();
                }
                if (row["vc_Source"] != null)
                {
                    model.vc_Source = row["vc_Source"].ToString();
                }
                if (row["vc_Title"] != null)
                {
                    model.vc_Title = row["vc_Title"].ToString();
                }
                if (row["TitleID"] != null && row["TitleID"].ToString() != "")
                {
                    model.TitleID = int.Parse(row["TitleID"].ToString());
                }
                if (row["i_Flag"] != null && row["i_Flag"].ToString() != "")
                {
                    model.i_Flag = int.Parse(row["i_Flag"].ToString());
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
            strSql.Append("select ID,vc_Content,vc_Source,vc_Title,TitleID,i_Flag ");
            strSql.Append(" FROM m_Content ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
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
            strSql.Append(" ID,vc_Content,vc_Source,vc_Title,TitleID,i_Flag ");
            strSql.Append(" FROM m_Content ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM m_Content ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
            strSql.Append(")AS Row, T.*  from m_Content T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
        }

        /*
        */

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

