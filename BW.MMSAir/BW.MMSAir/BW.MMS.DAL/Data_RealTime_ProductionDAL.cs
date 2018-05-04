using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:Data_RealTime_ProductionDAL
	/// </summary>
	public partial class Data_RealTime_ProductionDAL
	{
		public Data_RealTime_ProductionDAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SensorID", "Data_RealTime_Production"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SensorID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Data_RealTime_Production");
			strSql.Append(" where SensorID=@SensorID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SensorID", SqlDbType.Int,4)			};
			parameters[0].Value = SensorID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BW.MMS.Model.Data_RealTime_ProductionEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Data_RealTime_Production(");
			strSql.Append("SensorID,f_InstantaneousFlowrate,f_CumulativeTraffic,vc_Memo,i_Flag)");
			strSql.Append(" values (");
			strSql.Append("@SensorID,@f_InstantaneousFlowrate,@f_CumulativeTraffic,@vc_Memo,@i_Flag)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SensorID", SqlDbType.Int,4),
					new SqlParameter("@f_InstantaneousFlowrate", SqlDbType.Float,8),
					new SqlParameter("@f_CumulativeTraffic", SqlDbType.Float,8),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4)};
			parameters[0].Value = model.SensorID;
			parameters[1].Value = model.f_InstantaneousFlowrate;
			parameters[2].Value = model.f_CumulativeTraffic;
			parameters[3].Value = model.vc_Memo;
			parameters[4].Value = model.i_Flag;

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
		public bool Update(BW.MMS.Model.Data_RealTime_ProductionEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Data_RealTime_Production set ");
			strSql.Append("f_InstantaneousFlowrate=@f_InstantaneousFlowrate,");
			strSql.Append("f_CumulativeTraffic=@f_CumulativeTraffic,");
			strSql.Append("vc_Memo=@vc_Memo,");
			strSql.Append("i_Flag=@i_Flag");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@f_InstantaneousFlowrate", SqlDbType.Float,8),
					new SqlParameter("@f_CumulativeTraffic", SqlDbType.Float,8),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SensorID", SqlDbType.Int,4)};
			parameters[0].Value = model.f_InstantaneousFlowrate;
			parameters[1].Value = model.f_CumulativeTraffic;
			parameters[2].Value = model.vc_Memo;
			parameters[3].Value = model.i_Flag;
			parameters[4].Value = model.ID;
			parameters[5].Value = model.SensorID;

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
			strSql.Append("delete from Data_RealTime_Production ");
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
		/// 删除一条数据
		/// </summary>
        public bool DeleteBySensor(int SensorID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Data_RealTime_Production ");
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Data_RealTime_Production ");
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
		/// 得到一个对象实体
		/// </summary>
		public BW.MMS.Model.Data_RealTime_ProductionEntity GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,SensorID,f_InstantaneousFlowrate,f_CumulativeTraffic,vc_Memo,i_Flag from Data_RealTime_Production ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			BW.MMS.Model.Data_RealTime_ProductionEntity model=new BW.MMS.Model.Data_RealTime_ProductionEntity();
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
				if(ds.Tables[0].Rows[0]["f_InstantaneousFlowrate"]!=null && ds.Tables[0].Rows[0]["f_InstantaneousFlowrate"].ToString()!="")
				{
					model.f_InstantaneousFlowrate=decimal.Parse(ds.Tables[0].Rows[0]["f_InstantaneousFlowrate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["f_CumulativeTraffic"]!=null && ds.Tables[0].Rows[0]["f_CumulativeTraffic"].ToString()!="")
				{
					model.f_CumulativeTraffic=decimal.Parse(ds.Tables[0].Rows[0]["f_CumulativeTraffic"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_Memo"]!=null && ds.Tables[0].Rows[0]["vc_Memo"].ToString()!="")
				{
					model.vc_Memo=ds.Tables[0].Rows[0]["vc_Memo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["i_Flag"]!=null && ds.Tables[0].Rows[0]["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(ds.Tables[0].Rows[0]["i_Flag"].ToString());
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
			strSql.Append("select ID,SensorID,f_InstantaneousFlowrate,f_CumulativeTraffic,vc_Memo,i_Flag ");
			strSql.Append(" FROM Data_RealTime_Production ");
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
			strSql.Append(" ID,SensorID,f_InstantaneousFlowrate,f_CumulativeTraffic,vc_Memo,i_Flag ");
			strSql.Append(" FROM Data_RealTime_Production ");
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
			strSql.Append("select count(1) FROM Data_RealTime_Production ");
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
			strSql.Append(")AS Row, T.*  from Data_RealTime_Production T ");
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
			parameters[0].Value = "Data_RealTime_Production";
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

