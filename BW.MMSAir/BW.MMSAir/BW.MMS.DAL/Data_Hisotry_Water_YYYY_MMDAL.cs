using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;//Please add references
namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:Data_Hisotry_Water_YYYY_MMDAL
	/// </summary>
	public partial class Data_Hisotry_Water_YYYY_MMDAL
	{
		public Data_Hisotry_Water_YYYY_MMDAL()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(DateTime dt_DateTime)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Data_Hisotry_Water_YYYY_MM");
			strSql.Append(" where dt_DateTime=@dt_DateTime ");
			SqlParameter[] parameters = {
					new SqlParameter("@dt_DateTime", SqlDbType.DateTime)			};
			parameters[0].Value = dt_DateTime;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BW.MMS.Model.Data_Hisotry_Water_YYYY_MMEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Data_Hisotry_Water_YYYY_MM(");
			strSql.Append("dt_DateTime,SensorID,f_InstantaneousVelocity,f_InstantaneousFlowrate,f_PlusCumulativeFlowrate,f_MinusCumulativeFlowrate,f_IntegratingRunTime,AreaID,DeptID,vc_Memo,i_Flag,dt_Now)");
			strSql.Append(" values (");
			strSql.Append("@dt_DateTime,@SensorID,@f_InstantaneousVelocity,@f_InstantaneousFlowrate,@f_PlusCumulativeFlowrate,@f_MinusCumulativeFlowrate,@f_IntegratingRunTime,@AreaID,@DeptID,@vc_Memo,@i_Flag,@dt_Now)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@dt_DateTime", SqlDbType.DateTime),
					new SqlParameter("@SensorID", SqlDbType.Int,4),
					new SqlParameter("@f_InstantaneousVelocity", SqlDbType.Float,8),
					new SqlParameter("@f_InstantaneousFlowrate", SqlDbType.Float,8),
					new SqlParameter("@f_PlusCumulativeFlowrate", SqlDbType.Float,8),
					new SqlParameter("@f_MinusCumulativeFlowrate", SqlDbType.Float,8),
					new SqlParameter("@f_IntegratingRunTime", SqlDbType.DateTime),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@dt_Now", SqlDbType.DateTime)};
			parameters[0].Value = model.dt_DateTime;
			parameters[1].Value = model.SensorID;
			parameters[2].Value = model.f_InstantaneousVelocity;
			parameters[3].Value = model.f_InstantaneousFlowrate;
			parameters[4].Value = model.f_PlusCumulativeFlowrate;
			parameters[5].Value = model.f_MinusCumulativeFlowrate;
			parameters[6].Value = model.f_IntegratingRunTime;
			parameters[7].Value = model.AreaID;
			parameters[8].Value = model.DeptID;
			parameters[9].Value = model.vc_Memo;
			parameters[10].Value = model.i_Flag;
			parameters[11].Value = model.dt_Now;

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
		public bool Update(BW.MMS.Model.Data_Hisotry_Water_YYYY_MMEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Data_Hisotry_Water_YYYY_MM set ");
			strSql.Append("SensorID=@SensorID,");
			strSql.Append("f_InstantaneousVelocity=@f_InstantaneousVelocity,");
			strSql.Append("f_InstantaneousFlowrate=@f_InstantaneousFlowrate,");
			strSql.Append("f_PlusCumulativeFlowrate=@f_PlusCumulativeFlowrate,");
			strSql.Append("f_MinusCumulativeFlowrate=@f_MinusCumulativeFlowrate,");
			strSql.Append("f_IntegratingRunTime=@f_IntegratingRunTime,");
			strSql.Append("AreaID=@AreaID,");
			strSql.Append("DeptID=@DeptID,");
			strSql.Append("vc_Memo=@vc_Memo,");
			strSql.Append("i_Flag=@i_Flag,");
			strSql.Append("dt_Now=@dt_Now");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@SensorID", SqlDbType.Int,4),
					new SqlParameter("@f_InstantaneousVelocity", SqlDbType.Float,8),
					new SqlParameter("@f_InstantaneousFlowrate", SqlDbType.Float,8),
					new SqlParameter("@f_PlusCumulativeFlowrate", SqlDbType.Float,8),
					new SqlParameter("@f_MinusCumulativeFlowrate", SqlDbType.Float,8),
					new SqlParameter("@f_IntegratingRunTime", SqlDbType.DateTime),
					new SqlParameter("@AreaID", SqlDbType.Int,4),
					new SqlParameter("@DeptID", SqlDbType.Int,4),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@dt_Now", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@dt_DateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.SensorID;
			parameters[1].Value = model.f_InstantaneousVelocity;
			parameters[2].Value = model.f_InstantaneousFlowrate;
			parameters[3].Value = model.f_PlusCumulativeFlowrate;
			parameters[4].Value = model.f_MinusCumulativeFlowrate;
			parameters[5].Value = model.f_IntegratingRunTime;
			parameters[6].Value = model.AreaID;
			parameters[7].Value = model.DeptID;
			parameters[8].Value = model.vc_Memo;
			parameters[9].Value = model.i_Flag;
			parameters[10].Value = model.dt_Now;
			parameters[11].Value = model.ID;
			parameters[12].Value = model.dt_DateTime;

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
			strSql.Append("delete from Data_Hisotry_Water_YYYY_MM ");
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
		public bool Delete(DateTime dt_DateTime)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Data_Hisotry_Water_YYYY_MM ");
			strSql.Append(" where dt_DateTime=@dt_DateTime ");
			SqlParameter[] parameters = {
					new SqlParameter("@dt_DateTime", SqlDbType.DateTime)			};
			parameters[0].Value = dt_DateTime;

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
			strSql.Append("delete from Data_Hisotry_Water_YYYY_MM ");
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
		public BW.MMS.Model.Data_Hisotry_Water_YYYY_MMEntity GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,dt_DateTime,SensorID,f_InstantaneousVelocity,f_InstantaneousFlowrate,f_PlusCumulativeFlowrate,f_MinusCumulativeFlowrate,f_IntegratingRunTime,AreaID,DeptID,vc_Memo,i_Flag,dt_Now from Data_Hisotry_Water_YYYY_MM ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			BW.MMS.Model.Data_Hisotry_Water_YYYY_MMEntity model=new BW.MMS.Model.Data_Hisotry_Water_YYYY_MMEntity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dt_DateTime"]!=null && ds.Tables[0].Rows[0]["dt_DateTime"].ToString()!="")
				{
					model.dt_DateTime=DateTime.Parse(ds.Tables[0].Rows[0]["dt_DateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SensorID"]!=null && ds.Tables[0].Rows[0]["SensorID"].ToString()!="")
				{
					model.SensorID=int.Parse(ds.Tables[0].Rows[0]["SensorID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["f_InstantaneousVelocity"]!=null && ds.Tables[0].Rows[0]["f_InstantaneousVelocity"].ToString()!="")
				{
					model.f_InstantaneousVelocity=decimal.Parse(ds.Tables[0].Rows[0]["f_InstantaneousVelocity"].ToString());
				}
				if(ds.Tables[0].Rows[0]["f_InstantaneousFlowrate"]!=null && ds.Tables[0].Rows[0]["f_InstantaneousFlowrate"].ToString()!="")
				{
					model.f_InstantaneousFlowrate=decimal.Parse(ds.Tables[0].Rows[0]["f_InstantaneousFlowrate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["f_PlusCumulativeFlowrate"]!=null && ds.Tables[0].Rows[0]["f_PlusCumulativeFlowrate"].ToString()!="")
				{
					model.f_PlusCumulativeFlowrate=decimal.Parse(ds.Tables[0].Rows[0]["f_PlusCumulativeFlowrate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["f_MinusCumulativeFlowrate"]!=null && ds.Tables[0].Rows[0]["f_MinusCumulativeFlowrate"].ToString()!="")
				{
					model.f_MinusCumulativeFlowrate=decimal.Parse(ds.Tables[0].Rows[0]["f_MinusCumulativeFlowrate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["f_IntegratingRunTime"]!=null && ds.Tables[0].Rows[0]["f_IntegratingRunTime"].ToString()!="")
				{
					model.f_IntegratingRunTime=DateTime.Parse(ds.Tables[0].Rows[0]["f_IntegratingRunTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AreaID"]!=null && ds.Tables[0].Rows[0]["AreaID"].ToString()!="")
				{
					model.AreaID=int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DeptID"]!=null && ds.Tables[0].Rows[0]["DeptID"].ToString()!="")
				{
					model.DeptID=int.Parse(ds.Tables[0].Rows[0]["DeptID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_Memo"]!=null && ds.Tables[0].Rows[0]["vc_Memo"].ToString()!="")
				{
					model.vc_Memo=ds.Tables[0].Rows[0]["vc_Memo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["i_Flag"]!=null && ds.Tables[0].Rows[0]["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(ds.Tables[0].Rows[0]["i_Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dt_Now"]!=null && ds.Tables[0].Rows[0]["dt_Now"].ToString()!="")
				{
					model.dt_Now=DateTime.Parse(ds.Tables[0].Rows[0]["dt_Now"].ToString());
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
			strSql.Append("select ID,dt_DateTime,SensorID,f_InstantaneousVelocity,f_InstantaneousFlowrate,f_PlusCumulativeFlowrate,f_MinusCumulativeFlowrate,f_IntegratingRunTime,AreaID,DeptID,vc_Memo,i_Flag,dt_Now ");
			strSql.Append(" FROM Data_Hisotry_Water_YYYY_MM ");
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
			strSql.Append(" ID,dt_DateTime,SensorID,f_InstantaneousVelocity,f_InstantaneousFlowrate,f_PlusCumulativeFlowrate,f_MinusCumulativeFlowrate,f_IntegratingRunTime,AreaID,DeptID,vc_Memo,i_Flag,dt_Now ");
			strSql.Append(" FROM Data_Hisotry_Water_YYYY_MM ");
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
			strSql.Append("select count(1) FROM Data_Hisotry_Water_YYYY_MM ");
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
			strSql.Append(")AS Row, T.*  from Data_Hisotry_Water_YYYY_MM T ");
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
			parameters[0].Value = "Data_Hisotry_Water_YYYY_MM";
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

