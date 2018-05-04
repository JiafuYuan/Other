/**  版本信息模板在安装目录下，可自行修改。
* HistoryRecord.cs
*
* 功 能： N/A
* 类 名： HistoryRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/8 15:32:21   N/A    初版
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
using BW.MMS.DBUtility;

namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:HistoryRecord
	/// </summary>
	public partial class HistoryRecord
	{
		public HistoryRecord()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BW.MMS.Model.HistoryRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.GUID != null)
			{
				strSql1.Append("GUID,");
				strSql2.Append("'"+model.GUID+"',");
			}
			if (model.PointName != null)
			{
				strSql1.Append("PointName,");
				strSql2.Append("'"+model.PointName+"',");
			}
			if (model.PointValue != null)
			{
				strSql1.Append("PointValue,");
				strSql2.Append("'"+model.PointValue+"',");
			}
			if (model.PointDesc != null)
			{
				strSql1.Append("PointDesc,");
				strSql2.Append("'"+model.PointDesc+"',");
			}
			if (model.PointType != null)
			{
				strSql1.Append("PointType,");
				strSql2.Append("'"+model.PointType+"',");
			}
			if (model.RecordTime != null)
			{
				strSql1.Append("RecordTime,");
				strSql2.Append("'"+model.RecordTime+"',");
			}
			if (model.RecordType != null)
			{
				strSql1.Append("RecordType,");
				strSql2.Append("'"+model.RecordType+"',");
			}
			if (model.RecordWay != null)
			{
				strSql1.Append("RecordWay,");
				strSql2.Append("'"+model.RecordWay+"',");
			}
			if (model.HandleTime != null)
			{
				strSql1.Append("HandleTime,");
				strSql2.Append("'"+model.HandleTime+"',");
			}
			if (model.HandleResult != null)
			{
				strSql1.Append("HandleResult,");
				strSql2.Append("'"+model.HandleResult+"',");
			}
			if (model.HandleUser != null)
			{
				strSql1.Append("HandleUser,");
				strSql2.Append("'"+model.HandleUser+"',");
			}
			if (model.Priority != null)
			{
				strSql1.Append("Priority,");
				strSql2.Append("'"+model.Priority+"',");
			}
			strSql.Append("insert into HistoryRecord(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			int rows=DbHelperSQLGH_LOG.ExecuteSql(strSql.ToString());
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
		public bool Update(BW.MMS.Model.HistoryRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HistoryRecord set ");
			if (model.GUID != null)
			{
				strSql.Append("GUID='"+model.GUID+"',");
			}
			if (model.PointName != null)
			{
				strSql.Append("PointName='"+model.PointName+"',");
			}
			if (model.PointValue != null)
			{
				strSql.Append("PointValue='"+model.PointValue+"',");
			}
			if (model.PointDesc != null)
			{
				strSql.Append("PointDesc='"+model.PointDesc+"',");
			}
			if (model.PointType != null)
			{
				strSql.Append("PointType='"+model.PointType+"',");
			}
			if (model.RecordTime != null)
			{
				strSql.Append("RecordTime='"+model.RecordTime+"',");
			}
			if (model.RecordType != null)
			{
				strSql.Append("RecordType='"+model.RecordType+"',");
			}
			if (model.RecordWay != null)
			{
				strSql.Append("RecordWay='"+model.RecordWay+"',");
			}
			if (model.HandleTime != null)
			{
				strSql.Append("HandleTime='"+model.HandleTime+"',");
			}
			else
			{
				strSql.Append("HandleTime= null ,");
			}
			if (model.HandleResult != null)
			{
				strSql.Append("HandleResult='"+model.HandleResult+"',");
			}
			else
			{
				strSql.Append("HandleResult= null ,");
			}
			if (model.HandleUser != null)
			{
				strSql.Append("HandleUser='"+model.HandleUser+"',");
			}
			else
			{
				strSql.Append("HandleUser= null ,");
			}
			if (model.Priority != null)
			{
				strSql.Append("Priority='"+model.Priority+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ");
			int rowsAffected=DbHelperSQLGH_LOG.ExecuteSql(strSql.ToString());
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
		public bool Delete()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HistoryRecord ");
			strSql.Append(" where " );
			int rowsAffected=DbHelperSQLGH_LOG.ExecuteSql(strSql.ToString());
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
		public BW.MMS.Model.HistoryRecord GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" GUID,PointName,PointValue,PointDesc,PointType,RecordTime,RecordType,RecordWay,HandleTime,HandleResult,HandleUser,Priority ");
			strSql.Append(" from HistoryRecord ");
			strSql.Append(" where " );
			BW.MMS.Model.HistoryRecord model=new BW.MMS.Model.HistoryRecord();
			DataSet ds=DbHelperSQLGH_LOG.Query(strSql.ToString());
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
		public BW.MMS.Model.HistoryRecord DataRowToModel(DataRow row)
		{
			BW.MMS.Model.HistoryRecord model=new BW.MMS.Model.HistoryRecord();
			if (row != null)
			{
				if(row["GUID"]!=null)
				{
					model.GUID=row["GUID"].ToString();
				}
				if(row["PointName"]!=null)
				{
					model.PointName=row["PointName"].ToString();
				}
				if(row["PointValue"]!=null)
				{
					model.PointValue=row["PointValue"].ToString();
				}
				if(row["PointDesc"]!=null)
				{
					model.PointDesc=row["PointDesc"].ToString();
				}
				if(row["PointType"]!=null)
				{
					model.PointType=row["PointType"].ToString();
				}
				if(row["RecordTime"]!=null && row["RecordTime"].ToString()!="")
				{
					model.RecordTime=DateTime.Parse(row["RecordTime"].ToString());
				}
				if(row["RecordType"]!=null)
				{
					model.RecordType=row["RecordType"].ToString();
				}
				if(row["RecordWay"]!=null)
				{
					model.RecordWay=row["RecordWay"].ToString();
				}
				if(row["HandleTime"]!=null && row["HandleTime"].ToString()!="")
				{
					model.HandleTime=DateTime.Parse(row["HandleTime"].ToString());
				}
				if(row["HandleResult"]!=null)
				{
					model.HandleResult=row["HandleResult"].ToString();
				}
				if(row["HandleUser"]!=null)
				{
					model.HandleUser=row["HandleUser"].ToString();
				}
				if(row["Priority"]!=null)
				{
					model.Priority=row["Priority"].ToString();
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
			strSql.Append("select GUID,PointName,PointValue,PointDesc,PointType,RecordTime,RecordType,RecordWay,HandleTime,HandleResult,HandleUser,Priority ");
			strSql.Append(" FROM HistoryRecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLGH_LOG.Query(strSql.ToString());
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
			strSql.Append(" GUID,PointName,PointValue,PointDesc,PointType,RecordTime,RecordType,RecordWay,HandleTime,HandleResult,HandleUser,Priority ");
			strSql.Append(" FROM HistoryRecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQLGH_LOG.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM HistoryRecord ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQLGH_LOG.ExecuteSql(strSql.ToString());
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from HistoryRecord T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLGH_LOG.Query(strSql.ToString());
		}

		/*
		*/
        /*
		*/
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
            param.ReturnFields = " GUID,PointName,PointValue,PointDesc,PointType,RecordTime,RecordType,RecordWay,HandleTime,HandleResult,HandleUser,Priority ";
            param.TableName = " HistoryRecord ";
            string strWhere = "  where  1=1 ";
            if (name.Trim().Length > 0)
            {
                strWhere += name.Trim();
            }
            param.Where = strWhere;
            return DbHelperSQLGH_LOG.SelectDataByStoredProcedure(param, out total);
        }
        /// <summary>
        /// 返回月统计数据
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataSet GetDayReport(string startDate, string endDate)
        {
            DataSet ds = DbHelperSQLGH_LOG.RunProcedure("DayReport", new SqlParameter[] { new SqlParameter("@begin_date", startDate), new SqlParameter("@end_date", endDate) }, "table", 1000);
            return ds;
        }
        /// <summary>
        /// 返回月统计数据
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataSet GetMonthReport(string startDate, string endDate)
        {
            DataSet ds = DbHelperSQLGH_LOG.RunProcedure("MonthReport", new SqlParameter[] { new SqlParameter("@begin_date", startDate), new SqlParameter("@end_date", endDate) }, "table", 1000);
            return ds;
        }
        /// <summary>
        /// 返回年统计数据
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataSet GetYearReport(string startDate, string endDate)
        {
            DataSet ds = DbHelperSQLGH_LOG.RunProcedure("YearReport", new SqlParameter[] { new SqlParameter("@begin_date", startDate), new SqlParameter("@end_date", endDate) }, "table", 1000);
            return ds;
        }

        /// <summary>
        /// 根据区域返回月统计数据
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataSet GetAreaMonthReport(string startDate, string endDate,string areaName)
        {
            DataSet ds = DbHelperSQLGH_LOG.RunProcedure("AreaMonthReport", new SqlParameter[] { new SqlParameter("@begin_date", startDate), new SqlParameter("@end_date", endDate), new SqlParameter("@areaName", areaName) }, "table", 1000);
            return ds;
        }
        /// <summary>
        /// 根据区域返回年统计数据
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataSet GetAreaYearReport(string startDate, string endDate,string areaName)
        {
            DataSet ds = DbHelperSQLGH_LOG.RunProcedure("AreaYearReport", new SqlParameter[] { new SqlParameter("@begin_date", startDate), new SqlParameter("@end_date", endDate), new SqlParameter("@areaName",areaName), }, "table", 1000);
            return ds;
        }
		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

