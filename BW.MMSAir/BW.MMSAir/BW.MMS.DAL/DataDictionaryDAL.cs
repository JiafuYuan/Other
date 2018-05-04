using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BW.MMS.Model;
using System.Data.SqlClient;
using System.Data;
using BW.MMS.DBUtility;

namespace BW.MMS.DAL
{
    public class DataDictionaryDAL
    {
        public int Add(DataDictionary model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DataDictionary(");
            strSql.Append("Type,[Key],Value,Description)");
            strSql.Append(" values (");
            strSql.Append("@Type,@Key,@Value,@Description)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Key", SqlDbType.VarChar,50),
					new SqlParameter("@Value", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.Type;
            parameters[1].Value = model.Key;
            parameters[2].Value = model.Value;
            parameters[3].Value = model.Description;

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

        public bool Update(DataDictionary model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DataDictionary set ");
            strSql.Append("Type=@Type,");
            strSql.Append("[Key]=@Key,");
            strSql.Append("Value=@Value,");
            strSql.Append("Description=@Description");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@Key", SqlDbType.VarChar,50),
					new SqlParameter("@Value", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.Type;
            parameters[1].Value = model.Key;
            parameters[2].Value = model.Value;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.ID;

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


        public List<DataDictionary> SelectByType(string type)
        {
            string strSql = string.Format("SELECT * FROM DataDictionary WHERE Type='{0}'", type);
            DataSet ds = DbHelperSQL.Query(strSql);
            return DataTableToList(ds.Tables[0]);
        }

        private List<DataDictionary> DataTableToList(DataTable dt)
        {
            List<DataDictionary> modelList = new List<DataDictionary>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DataDictionary model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DataDictionary();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["Type"] != null && dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = dt.Rows[n]["Type"].ToString();
                    }
                    if (dt.Rows[n]["Key"] != null && dt.Rows[n]["Key"].ToString() != "")
                    {
                        model.Key = dt.Rows[n]["Key"].ToString();
                    }
                    if (dt.Rows[n]["Value"] != null && dt.Rows[n]["Value"].ToString() != "")
                    {
                        model.Value = dt.Rows[n]["Value"].ToString();
                    }
                    if (dt.Rows[n]["Description"] != null && dt.Rows[n]["Description"].ToString() != "")
                    {
                        model.Description = dt.Rows[n]["Description"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}
