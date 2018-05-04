using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;
namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:m_CDR
	/// </summary>
	public partial class m_CDR
	{
		public m_CDR()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "m_CDR"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_CDR");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BW.MMS.Model.m_CDR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into m_CDR(");
			strSql.Append("vc_CallingNum,vc_CalledNum,dt_SetupTime,dt_ConnectTime,dt_AnswerTime,dt_DisconnectTime,dt_RemoteDisconnecTime,i_Duration,vc_HostIP,vc_VisitIP,i_rpc,i_rpno,i_ServiceProvider,i_CallType,i_TalkType,i_ChargeValue,vc_Memo,i_Flag,vc_Path,vc_recPath)");
			strSql.Append(" values (");
			strSql.Append("@vc_CallingNum,@vc_CalledNum,@dt_SetupTime,@dt_ConnectTime,@dt_AnswerTime,@dt_DisconnectTime,@dt_RemoteDisconnecTime,@i_Duration,@vc_HostIP,@vc_VisitIP,@i_rpc,@i_rpno,@i_ServiceProvider,@i_CallType,@i_TalkType,@i_ChargeValue,@vc_Memo,@i_Flag,@vc_Path,@vc_recPath)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_CallingNum", SqlDbType.VarChar,50),
					new SqlParameter("@vc_CalledNum", SqlDbType.VarChar,50),
					new SqlParameter("@dt_SetupTime", SqlDbType.DateTime),
					new SqlParameter("@dt_ConnectTime", SqlDbType.DateTime),
					new SqlParameter("@dt_AnswerTime", SqlDbType.DateTime),
					new SqlParameter("@dt_DisconnectTime", SqlDbType.DateTime),
					new SqlParameter("@dt_RemoteDisconnecTime", SqlDbType.DateTime),
					new SqlParameter("@i_Duration", SqlDbType.BigInt,8),
					new SqlParameter("@vc_HostIP", SqlDbType.VarChar,50),
					new SqlParameter("@vc_VisitIP", SqlDbType.VarChar,50),
					new SqlParameter("@i_rpc", SqlDbType.Int,4),
					new SqlParameter("@i_rpno", SqlDbType.Int,4),
					new SqlParameter("@i_ServiceProvider", SqlDbType.Int,4),
					new SqlParameter("@i_CallType", SqlDbType.Int,4),
					new SqlParameter("@i_TalkType", SqlDbType.Int,4),
					new SqlParameter("@i_ChargeValue", SqlDbType.BigInt,8),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@vc_Path", SqlDbType.VarChar,200),
					new SqlParameter("@vc_recPath", SqlDbType.VarChar,200)};
			parameters[0].Value = model.vc_CallingNum;
			parameters[1].Value = model.vc_CalledNum;
			parameters[2].Value = model.dt_SetupTime;
			parameters[3].Value = model.dt_ConnectTime;
			parameters[4].Value = model.dt_AnswerTime;
			parameters[5].Value = model.dt_DisconnectTime;
			parameters[6].Value = model.dt_RemoteDisconnecTime;
			parameters[7].Value = model.i_Duration;
			parameters[8].Value = model.vc_HostIP;
			parameters[9].Value = model.vc_VisitIP;
			parameters[10].Value = model.i_rpc;
			parameters[11].Value = model.i_rpno;
			parameters[12].Value = model.i_ServiceProvider;
			parameters[13].Value = model.i_CallType;
			parameters[14].Value = model.i_TalkType;
			parameters[15].Value = model.i_ChargeValue;
			parameters[16].Value = model.vc_Memo;
			parameters[17].Value = model.i_Flag;
			parameters[18].Value = model.vc_Path;
			parameters[19].Value = model.vc_recPath;

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
		public bool Update(BW.MMS.Model.m_CDR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_CDR set ");
			strSql.Append("vc_CallingNum=@vc_CallingNum,");
			strSql.Append("vc_CalledNum=@vc_CalledNum,");
			strSql.Append("dt_SetupTime=@dt_SetupTime,");
			strSql.Append("dt_ConnectTime=@dt_ConnectTime,");
			strSql.Append("dt_AnswerTime=@dt_AnswerTime,");
			strSql.Append("dt_DisconnectTime=@dt_DisconnectTime,");
			strSql.Append("dt_RemoteDisconnecTime=@dt_RemoteDisconnecTime,");
			strSql.Append("i_Duration=@i_Duration,");
			strSql.Append("vc_HostIP=@vc_HostIP,");
			strSql.Append("vc_VisitIP=@vc_VisitIP,");
			strSql.Append("i_rpc=@i_rpc,");
			strSql.Append("i_rpno=@i_rpno,");
			strSql.Append("i_ServiceProvider=@i_ServiceProvider,");
			strSql.Append("i_CallType=@i_CallType,");
			strSql.Append("i_TalkType=@i_TalkType,");
			strSql.Append("i_ChargeValue=@i_ChargeValue,");
			strSql.Append("vc_Memo=@vc_Memo,");
			strSql.Append("i_Flag=@i_Flag,");
			strSql.Append("vc_Path=@vc_Path,");
			strSql.Append("vc_recPath=@vc_recPath");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_CallingNum", SqlDbType.VarChar,50),
					new SqlParameter("@vc_CalledNum", SqlDbType.VarChar,50),
					new SqlParameter("@dt_SetupTime", SqlDbType.DateTime),
					new SqlParameter("@dt_ConnectTime", SqlDbType.DateTime),
					new SqlParameter("@dt_AnswerTime", SqlDbType.DateTime),
					new SqlParameter("@dt_DisconnectTime", SqlDbType.DateTime),
					new SqlParameter("@dt_RemoteDisconnecTime", SqlDbType.DateTime),
					new SqlParameter("@i_Duration", SqlDbType.BigInt,8),
					new SqlParameter("@vc_HostIP", SqlDbType.VarChar,50),
					new SqlParameter("@vc_VisitIP", SqlDbType.VarChar,50),
					new SqlParameter("@i_rpc", SqlDbType.Int,4),
					new SqlParameter("@i_rpno", SqlDbType.Int,4),
					new SqlParameter("@i_ServiceProvider", SqlDbType.Int,4),
					new SqlParameter("@i_CallType", SqlDbType.Int,4),
					new SqlParameter("@i_TalkType", SqlDbType.Int,4),
					new SqlParameter("@i_ChargeValue", SqlDbType.BigInt,8),
					new SqlParameter("@vc_Memo", SqlDbType.VarChar,200),
					new SqlParameter("@i_Flag", SqlDbType.Int,4),
					new SqlParameter("@vc_Path", SqlDbType.VarChar,200),
					new SqlParameter("@vc_recPath", SqlDbType.VarChar,200),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.vc_CallingNum;
			parameters[1].Value = model.vc_CalledNum;
			parameters[2].Value = model.dt_SetupTime;
			parameters[3].Value = model.dt_ConnectTime;
			parameters[4].Value = model.dt_AnswerTime;
			parameters[5].Value = model.dt_DisconnectTime;
			parameters[6].Value = model.dt_RemoteDisconnecTime;
			parameters[7].Value = model.i_Duration;
			parameters[8].Value = model.vc_HostIP;
			parameters[9].Value = model.vc_VisitIP;
			parameters[10].Value = model.i_rpc;
			parameters[11].Value = model.i_rpno;
			parameters[12].Value = model.i_ServiceProvider;
			parameters[13].Value = model.i_CallType;
			parameters[14].Value = model.i_TalkType;
			parameters[15].Value = model.i_ChargeValue;
			parameters[16].Value = model.vc_Memo;
			parameters[17].Value = model.i_Flag;
			parameters[18].Value = model.vc_Path;
			parameters[19].Value = model.vc_recPath;
			parameters[20].Value = model.ID;

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
			strSql.Append("delete from m_CDR ");
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
			strSql.Append("delete from m_CDR ");
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
		public BW.MMS.Model.m_CDR GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,vc_CallingNum,vc_CalledNum,dt_SetupTime,dt_ConnectTime,dt_AnswerTime,dt_DisconnectTime,dt_RemoteDisconnecTime,i_Duration,vc_HostIP,vc_VisitIP,i_rpc,i_rpno,i_ServiceProvider,i_CallType,i_TalkType,i_ChargeValue,vc_Memo,i_Flag,vc_Path,vc_recPath from m_CDR ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			BW.MMS.Model.m_CDR model=new BW.MMS.Model.m_CDR();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_CallingNum"]!=null && ds.Tables[0].Rows[0]["vc_CallingNum"].ToString()!="")
				{
					model.vc_CallingNum=ds.Tables[0].Rows[0]["vc_CallingNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vc_CalledNum"]!=null && ds.Tables[0].Rows[0]["vc_CalledNum"].ToString()!="")
				{
					model.vc_CalledNum=ds.Tables[0].Rows[0]["vc_CalledNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["dt_SetupTime"]!=null && ds.Tables[0].Rows[0]["dt_SetupTime"].ToString()!="")
				{
					model.dt_SetupTime=DateTime.Parse(ds.Tables[0].Rows[0]["dt_SetupTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dt_ConnectTime"]!=null && ds.Tables[0].Rows[0]["dt_ConnectTime"].ToString()!="")
				{
					model.dt_ConnectTime=DateTime.Parse(ds.Tables[0].Rows[0]["dt_ConnectTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dt_AnswerTime"]!=null && ds.Tables[0].Rows[0]["dt_AnswerTime"].ToString()!="")
				{
					model.dt_AnswerTime=DateTime.Parse(ds.Tables[0].Rows[0]["dt_AnswerTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dt_DisconnectTime"]!=null && ds.Tables[0].Rows[0]["dt_DisconnectTime"].ToString()!="")
				{
					model.dt_DisconnectTime=DateTime.Parse(ds.Tables[0].Rows[0]["dt_DisconnectTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["dt_RemoteDisconnecTime"]!=null && ds.Tables[0].Rows[0]["dt_RemoteDisconnecTime"].ToString()!="")
				{
					model.dt_RemoteDisconnecTime=DateTime.Parse(ds.Tables[0].Rows[0]["dt_RemoteDisconnecTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["i_Duration"]!=null && ds.Tables[0].Rows[0]["i_Duration"].ToString()!="")
				{
					model.i_Duration=long.Parse(ds.Tables[0].Rows[0]["i_Duration"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_HostIP"]!=null && ds.Tables[0].Rows[0]["vc_HostIP"].ToString()!="")
				{
					model.vc_HostIP=ds.Tables[0].Rows[0]["vc_HostIP"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vc_VisitIP"]!=null && ds.Tables[0].Rows[0]["vc_VisitIP"].ToString()!="")
				{
					model.vc_VisitIP=ds.Tables[0].Rows[0]["vc_VisitIP"].ToString();
				}
				if(ds.Tables[0].Rows[0]["i_rpc"]!=null && ds.Tables[0].Rows[0]["i_rpc"].ToString()!="")
				{
					model.i_rpc=int.Parse(ds.Tables[0].Rows[0]["i_rpc"].ToString());
				}
				if(ds.Tables[0].Rows[0]["i_rpno"]!=null && ds.Tables[0].Rows[0]["i_rpno"].ToString()!="")
				{
					model.i_rpno=int.Parse(ds.Tables[0].Rows[0]["i_rpno"].ToString());
				}
				if(ds.Tables[0].Rows[0]["i_ServiceProvider"]!=null && ds.Tables[0].Rows[0]["i_ServiceProvider"].ToString()!="")
				{
					model.i_ServiceProvider=int.Parse(ds.Tables[0].Rows[0]["i_ServiceProvider"].ToString());
				}
				if(ds.Tables[0].Rows[0]["i_CallType"]!=null && ds.Tables[0].Rows[0]["i_CallType"].ToString()!="")
				{
					model.i_CallType=int.Parse(ds.Tables[0].Rows[0]["i_CallType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["i_TalkType"]!=null && ds.Tables[0].Rows[0]["i_TalkType"].ToString()!="")
				{
					model.i_TalkType=int.Parse(ds.Tables[0].Rows[0]["i_TalkType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["i_ChargeValue"]!=null && ds.Tables[0].Rows[0]["i_ChargeValue"].ToString()!="")
				{
					model.i_ChargeValue=long.Parse(ds.Tables[0].Rows[0]["i_ChargeValue"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_Memo"]!=null && ds.Tables[0].Rows[0]["vc_Memo"].ToString()!="")
				{
					model.vc_Memo=ds.Tables[0].Rows[0]["vc_Memo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["i_Flag"]!=null && ds.Tables[0].Rows[0]["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(ds.Tables[0].Rows[0]["i_Flag"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_Path"]!=null && ds.Tables[0].Rows[0]["vc_Path"].ToString()!="")
				{
					model.vc_Path=ds.Tables[0].Rows[0]["vc_Path"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vc_recPath"]!=null && ds.Tables[0].Rows[0]["vc_recPath"].ToString()!="")
				{
					model.vc_recPath=ds.Tables[0].Rows[0]["vc_recPath"].ToString();
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
			strSql.Append("select ID,vc_CallingNum,vc_CalledNum,dt_SetupTime,dt_ConnectTime,dt_AnswerTime,dt_DisconnectTime,dt_RemoteDisconnecTime,i_Duration,vc_HostIP,vc_VisitIP,i_rpc,i_rpno,i_ServiceProvider,i_CallType,i_TalkType,i_ChargeValue,vc_Memo,i_Flag,vc_Path,vc_recPath ");
			strSql.Append(" FROM m_CDR ");
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
			strSql.Append(" ID,vc_CallingNum,vc_CalledNum,dt_SetupTime,dt_ConnectTime,dt_AnswerTime,dt_DisconnectTime,dt_RemoteDisconnecTime,i_Duration,vc_HostIP,vc_VisitIP,i_rpc,i_rpno,i_ServiceProvider,i_CallType,i_TalkType,i_ChargeValue,vc_Memo,i_Flag,vc_Path,vc_recPath ");
			strSql.Append(" FROM m_CDR ");
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
			strSql.Append("select count(1) FROM m_CDR ");
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
			strSql.Append(")AS Row, T.*  from m_CDR T ");
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
			parameters[0].Value = "m_CDR";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/


        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="page">当前页</param>
        /// <param name="rows">每页显示条数</param>
        /// <param name="sort">提序字段</param>
        /// <param name="order">排序方式</param>
        /// <param name="total">返回总条数</param>
        /// <returns></returns>
        public DataTable GetPagingList(string name, int page, int rows, string sort, string order, out int total)
        {
            QueryParam param = new QueryParam();
            param.Orderfld = sort;
            if (order.ToUpper() == "ASC")
            {
                param.OrderType = 2;
            }
            else
            {
                param.OrderType = 1;
            }
            
            param.PageIndex = page;
            param.PageSize = rows;
            param.ReturnFields = " ID,dt_SetupTime,vc_CallingNum,vc_CalledNum,dt_ConnectTime,dt_AnswerTime,dt_DisconnectTime,i_Duration,vc_RecPath,i_CallType ";
            param.TableName = " m_cdr where i_CallType=0 and i_flag=0 ";
            string strWhere = " and  1=1 ";
            if (name.Trim().Length > 0)
            {
                strWhere += name.Trim();
            }
            param.Where = strWhere;
            return DbHelperSQL.SelectDataByStoredProcedure(param, out total);
        }
		#endregion  Method
	}
}

