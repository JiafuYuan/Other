using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DB_VehicleTransportManage.DAL
{
	/// <summary>
	/// 数据访问类:m_GisMapFiles
	/// </summary>
	public partial class m_GisMapFiles
	{
		public m_GisMapFiles()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(DB_VehicleTransportManage.Model.m_GisMapFiles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into m_GisMapFiles(");
			strSql.Append("File_Name,File_Data)");
			strSql.Append(" values (");
			strSql.Append("?,?)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@File_Name", OleDbType.VarChar,50),
					new OleDbParameter("@File_Data", OleDbType.Binary)};
			parameters[0].Value = model.File_Name;
			parameters[1].Value = model.File_Data;

            return DB.OleDbHelper.ExecuteSql(strSql.ToString(), parameters);
            //int rows = Global.Params.OleDbHelper.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(DB_VehicleTransportManage.Model.m_GisMapFiles model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_GisMapFiles set ");
			strSql.Append("File_Name=@File_Name,");
			strSql.Append("File_Data=@File_Data");
			strSql.Append(" where ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@File_Name", OleDbType.VarChar,50),
					new OleDbParameter("@File_Data", OleDbType.Binary)};
			parameters[0].Value = model.File_Name;
			parameters[1].Value = model.File_Data;

            int rows = DB.OleDbHelper.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_GisMapFiles ");

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
        public DB_VehicleTransportManage.Model.m_GisMapFiles GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 File_Name,File_Data from m_GisMapFiles ");
			//strSql.Append(" where ");
			//OleDbParameter[] parameters = {
//};

            DB_VehicleTransportManage.Model.m_GisMapFiles model = new DB_VehicleTransportManage.Model.m_GisMapFiles();
           // DataSet ds = Global.Params.OleDbHelper.GetDataSet(strSql.ToString(), parameters);
           DataSet ds  = DB.OleDbHelper.GetDataSet(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["File_Name"]!=null && ds.Tables[0].Rows[0]["File_Name"].ToString()!="")
				{
					model.File_Name=ds.Tables[0].Rows[0]["File_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["File_Data"]!=null && ds.Tables[0].Rows[0]["File_Data"].ToString()!="")
				{
					model.File_Data=(byte[])ds.Tables[0].Rows[0]["File_Data"];
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select File_Name,File_Data ");
			strSql.Append(" FROM m_GisMapFiles ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" File_Name,File_Data ");
			strSql.Append(" FROM m_GisMapFiles ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Int),
					new OleDbParameter("@PageIndex", OleDbType.Int),
					new OleDbParameter("@IsReCount", OleDbType.Bit),
					new OleDbParameter("@OrderType", OleDbType.Bit),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "m_GisMapFiles";
			parameters[1].Value = "";
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

