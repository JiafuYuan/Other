/**  版本信息模板在安装目录下，可自行修改。
* m_SensorNodesDAL.cs
*
* 功 能： N/A
* 类 名： m_SensorNodesDAL
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-11-6 18:22:12   N/A    初版
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
	/// 数据访问类:m_SensorNodesDAL
	/// </summary>
	public partial class m_SensorNodesDAL
	{
		public m_SensorNodesDAL()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BW.MMS.Model.m_SensorNodesEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into m_SensorNodes(");
			strSql.Append("SensorID,NodeID,vc_Address,vc_Memo)");
			strSql.Append(" values (");
			strSql.Append("@SensorID,@NodeID,@vc_Address,@vc_Memo)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SensorID", SqlDbType.Int,4),
					new SqlParameter("@NodeID", SqlDbType.Int,4),
					new SqlParameter("@vc_Address", SqlDbType.VarChar,100),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,100)};
			parameters[0].Value = model.SensorID;
			parameters[1].Value = model.NodeID;
			parameters[2].Value = model.vc_Address;
			parameters[3].Value = model.vc_Memo;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(BW.MMS.Model.m_SensorNodesEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_SensorNodes set ");
			strSql.Append("SensorID=@SensorID,");
			strSql.Append("NodeID=@NodeID,");
			strSql.Append("vc_Address=@vc_Address,");
			strSql.Append("vc_Memo=@vc_Memo");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@SensorID", SqlDbType.Int,4),
					new SqlParameter("@NodeID", SqlDbType.Int,4),
					new SqlParameter("@vc_Address", SqlDbType.VarChar,100),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,100),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.SensorID;
			parameters[1].Value = model.NodeID;
			parameters[2].Value = model.vc_Address;
			parameters[3].Value = model.vc_Memo;
			parameters[4].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_SensorNodes ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_SensorNodes ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
       /// 根据条件删除数据
       /// </summary>
       /// <param name="strWhere"></param>
       /// <returns></returns>
        public bool DeleteWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_SensorNodes ");
            strSql.Append(" where 1=1  ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" and "+strWhere+"");
            }
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
		public BW.MMS.Model.m_SensorNodesEntity GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,SensorID,NodeID,vc_Address,vc_Memo from m_SensorNodes ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			BW.MMS.Model.m_SensorNodesEntity model=new BW.MMS.Model.m_SensorNodesEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public BW.MMS.Model.m_SensorNodesEntity DataRowToModel(DataRow row)
		{
			BW.MMS.Model.m_SensorNodesEntity model=new BW.MMS.Model.m_SensorNodesEntity();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["SensorID"]!=null && row["SensorID"].ToString()!="")
				{
					model.SensorID=int.Parse(row["SensorID"].ToString());
				}
				if(row["NodeID"]!=null && row["NodeID"].ToString()!="")
				{
					model.NodeID=int.Parse(row["NodeID"].ToString());
				}
				if(row["vc_Address"]!=null)
				{
					model.vc_Address=row["vc_Address"].ToString();
				}
				if(row["vc_Memo"]!=null)
				{
					model.vc_Memo=row["vc_Memo"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,SensorID,NodeID,vc_Address,vc_Memo ");
			strSql.Append(" FROM m_SensorNodes ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得关联数据列表
        /// </summary>
        public DataSet GetNodesList(int sensorID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID ,vc_Name, ");
            strSql.Append("(select vc_Code from m_sensor where  ID=" + sensorID + ") as sensorCode ,");
            strSql.Append("(select vc_Address from m_sensor where  ID=" + sensorID + ") as sensorAddress ,");
            strSql.Append("(select ID from m_SensorNodes where a.ID=NodeID and SensorID=" + sensorID + ") as nodesID ,") ;
            strSql.Append("(select vc_Address from m_SensorNodes where a.ID=NodeID and SensorID=" + sensorID + ") as vc_Address");
            strSql.Append(" FROM m_Dictionary a ");
            return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" ID,SensorID,NodeID,vc_Address,vc_Memo ");
			strSql.Append(" FROM m_SensorNodes ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM m_SensorNodes ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from m_SensorNodes T ");
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
			parameters[0].Value = "m_SensorNodes";
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

