using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:m_SensorRelationshipDAL
	/// </summary>
	public partial class m_SensorRelationshipDAL
	{
		public m_SensorRelationshipDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SensorID", "m_SensorRelationship"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SensorID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_SensorRelationship");
			strSql.Append(" where SensorID=@SensorID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SensorID", SqlDbType.Int,4)			};
			parameters[0].Value = SensorID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BW.MMS.Model.m_SensorRelationshipEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into m_SensorRelationship(");
			strSql.Append("ID,SensorID,ParentSensorID,i_Flag,vc_Memo)");
			strSql.Append(" values (");
			strSql.Append("@ID,@SensorID,@ParentSensorID,@i_Flag,@vc_Memo)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SensorID", SqlDbType.Int,4),
					new SqlParameter("@ParentSensorID", SqlDbType.Int,4),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.SensorID;
			parameters[2].Value = model.ParentSensorID;
			parameters[3].Value = model.i_Flag;
			parameters[4].Value = model.vc_Memo;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(BW.MMS.Model.m_SensorRelationshipEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_SensorRelationship set ");
			strSql.Append("ID=@ID,");
			strSql.Append("ParentSensorID=@ParentSensorID,");
			strSql.Append("i_Flag=@i_Flag,");
			strSql.Append("vc_Memo=@vc_Memo");
			strSql.Append(" where SensorID=@SensorID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ParentSensorID", SqlDbType.Int,4),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@SensorID", SqlDbType.Int,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ParentSensorID;
			parameters[2].Value = model.i_Flag;
			parameters[3].Value = model.vc_Memo;
			parameters[4].Value = model.SensorID;

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
		public bool Delete(int SensorID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_SensorRelationship ");
			strSql.Append(" where SensorID=@SensorID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SensorID", SqlDbType.Int,4)			};
			parameters[0].Value = SensorID;

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
		public bool DeleteList(string SensorIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_SensorRelationship ");
			strSql.Append(" where SensorID in ("+SensorIDlist + ")  ");
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
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.m_SensorRelationshipEntity GetModel(int SensorID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,SensorID,ParentSensorID,i_Flag,vc_Memo from m_SensorRelationship ");
			strSql.Append(" where SensorID=@SensorID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SensorID", SqlDbType.Int,4)			};
			parameters[0].Value = SensorID;

			BW.MMS.Model.m_SensorRelationshipEntity model=new BW.MMS.Model.m_SensorRelationshipEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SensorID"]!=null && ds.Tables[0].Rows[0]["SensorID"].ToString()!="")
				{
					model.SensorID=int.Parse(ds.Tables[0].Rows[0]["SensorID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ParentSensorID"]!=null && ds.Tables[0].Rows[0]["ParentSensorID"].ToString()!="")
				{
					model.ParentSensorID=int.Parse(ds.Tables[0].Rows[0]["ParentSensorID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["i_Flag"]!=null && ds.Tables[0].Rows[0]["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(ds.Tables[0].Rows[0]["i_Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_Memo"]!=null && ds.Tables[0].Rows[0]["vc_Memo"].ToString()!="")
				{
					model.vc_Memo=ds.Tables[0].Rows[0]["vc_Memo"].ToString();
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
			strSql.Append("select ID,SensorID,ParentSensorID,i_Flag,vc_Memo ");
			strSql.Append(" FROM m_SensorRelationship ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			strSql.Append(" ID,SensorID,ParentSensorID,i_Flag,vc_Memo ");
			strSql.Append(" FROM m_SensorRelationship ");
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
			strSql.Append("select count(1) FROM m_SensorRelationship ");
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
				strSql.Append("order by T.SensorID desc");
			}
			strSql.Append(")AS Row, T.*  from m_SensorRelationship T ");
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
			parameters[0].Value = "m_SensorRelationship";
			parameters[1].Value = "SensorID";
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

