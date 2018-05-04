/**  版本信息模板在安装目录下，可自行修改。
* v_Kj222Localizer.cs
*
* 功 能： N/A
* 类 名： v_Kj222Localizer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/12 10:54:06   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace DB_VehicleTransportManage.DAL
{
    /// <summary>
    /// 数据访问类:v_Kj222Localizer
    /// </summary>
    public partial class v_Kj222Localizer
    {
        public v_Kj222Localizer()
        {
        }
        #region  Method

        public static bool IsKj602(string tableName, string columnName)
        {
            var columnsInfo = GetTableColumnsInfo(tableName);
            if (columnsInfo == null || columnsInfo.Rows.Count == 0)
            {
                return false;
            }
            var query = columnsInfo.AsEnumerable();
            return query.Any(m => m.Field<string>("name") == columnName);
	    }

      
        public static DataTable GetTableColumnsInfo(string tableName)
        {
            string strsql =
                "select * from bw_kj222.dbo.syscolumns where id=object_id('bw_kj222.dbo.{0}')";
            return DB.OleDbHelper.GetDataTable(string.Format(strsql, tableName));
        }
        public bool IsKj602()
        {
            string strsql =
                "select * from bw_kj222.dbo.syscolumns where id=object_id('bw_kj222.dbo.m_Localizer') and name='i_ParentHID'";
            DataSet dataSet = DB.OleDbHelper.GetDataSet(strsql);
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DB_VehicleTransportManage.Model.v_Kj222Localizer model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();

            if (model.AreaID != null)
            {
                strSql1.Append("AreaID,");
                strSql2.Append("" + model.AreaID + ",");
            }
            if (model.i_HID != null)
            {
                strSql1.Append("i_HID,");
                strSql2.Append("" + model.i_HID + ",");
            }
            if (model.i_ParentHID != null && IsKj602())
            {
                strSql1.Append("i_ParentHID,");
                strSql2.Append("" + model.i_ParentHID + ",");
            }
            if (model.i_Type != null)
            {
                strSql1.Append("i_Type,");
                strSql2.Append("" + model.i_Type + ",");
            }
            if (model.vc_Code != null)
            {
                strSql1.Append("vc_Code,");
                strSql2.Append("'" + model.vc_Code + "',");
            }
            if (model.vc_Name != null)
            {
                strSql1.Append("vc_Name,");
                strSql2.Append("'" + model.vc_Name + "',");
            }
            if (model.vc_Memo != null)
            {
                strSql1.Append("vc_Memo,");
                strSql2.Append("'" + model.vc_Memo + "',");
            }
            if (model.i_Flag != null)
            {
                strSql1.Append("i_Flag,");
                strSql2.Append("" + model.i_Flag + ",");
            }
          
            strSql.Append("insert into v_Kj222Localizer(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
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
        /// 更新一条数据
        /// </summary>
        public bool Update(DB_VehicleTransportManage.Model.v_Kj222Localizer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update v_Kj222Localizer set ");
            if (model.AreaID != null)
            {
                strSql.Append("AreaID=" + model.AreaID + ",");
            }
            if (model.i_HID != null)
            {
                strSql.Append("i_HID=" + model.i_HID + ",");
            }
            if (IsKj602()&&model.i_ParentHID != null )
            {
                strSql.Append("i_ParentHID=" + model.i_ParentHID + ",");
            }
            if (model.i_Type != null)
            {
                strSql.Append("i_Type=" + model.i_Type + ",");
            }
            else
            {
                strSql.Append("i_Type= null ,");
            }
            if (model.vc_Code != null)
            {
                strSql.Append("vc_Code='" + model.vc_Code + "',");
            }
            if (model.vc_Name != null)
            {
                strSql.Append("vc_Name='" + model.vc_Name + "',");
            }
            else
            {
                strSql.Append("vc_Name= null ,");
            }
            if (model.vc_Memo != null)
            {
                strSql.Append("vc_Memo='" + model.vc_Memo + "',");
            }
            else
            {
                strSql.Append("vc_Memo= null ,");
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
            strSql.Append("delete from v_Kj222Localizer ");
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
        }		/// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_Kj222Localizer ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
        public DB_VehicleTransportManage.Model.v_Kj222Localizer GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            if (IsKj602())
            {
                strSql.Append(
                    " ID,AreaID,i_HID,i_ParentHID,i_Type,vc_Code,vc_Name,vc_Memo,i_Flag ");
            }
            else
            {
                strSql.Append(" ID,AreaID,i_HID,i_Type,vc_Code,vc_Name,vc_Memo,i_Flag ");
            }
            
            strSql.Append(" from v_Kj222Localizer ");
            strSql.Append(" where ID=" + ID + "");
            DB_VehicleTransportManage.Model.v_Kj222Localizer model = new DB_VehicleTransportManage.Model.v_Kj222Localizer();
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
        public DB_VehicleTransportManage.Model.v_Kj222Localizer DataRowToModel(DataRow row)
        {
            DB_VehicleTransportManage.Model.v_Kj222Localizer model = new DB_VehicleTransportManage.Model.v_Kj222Localizer();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["AreaID"] != null && row["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(row["AreaID"].ToString());
                }
                if (row["i_HID"] != null && row["i_HID"].ToString() != "")
                {
                    model.i_HID = int.Parse(row["i_HID"].ToString());
                }
                if (IsKj602()&&row["i_ParentHID"] != null && row["i_ParentHID"].ToString() != "")
                {
                    model.i_ParentHID = int.Parse(row["i_ParentHID"].ToString());
                }
                if (row["i_Type"] != null && row["i_Type"].ToString() != "")
                {
                    model.i_Type = int.Parse(row["i_Type"].ToString());
                }
                if (row["vc_Code"] != null)
                {
                    model.vc_Code = row["vc_Code"].ToString();
                }
                if (row["vc_Name"] != null)
                {
                    model.vc_Name = row["vc_Name"].ToString();
                }
                if (row["vc_Memo"] != null)
                {
                    model.vc_Memo = row["vc_Memo"].ToString();
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
            if (IsKj602())
            strSql.Append("select ID,AreaID,i_HID,i_ParentHID,i_Type,vc_Code,vc_Name,vc_Memo,i_Flag ");
            else
            {
                strSql.Append("select ID,AreaID,i_HID,i_Type,vc_Code,vc_Name,vc_Memo,i_Flag ");
            }
            strSql.Append(" FROM v_Kj222Localizer ");
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
            if (IsKj602())
            strSql.Append(" ID,AreaID,i_HID,i_ParentHID,i_Type,vc_Code,vc_Name,vc_Memo,i_Flag ");
            else
            {
                strSql.Append(" ID,AreaID,i_HID,i_Type,vc_Code,vc_Name,vc_Memo,i_Flag ");
            }
            strSql.Append(" FROM v_Kj222Localizer ");
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
            strSql.Append("select count(1) FROM v_Kj222Localizer ");
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
            strSql.Append(")AS Row, T.*  from v_Kj222Localizer T ");
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

