/**  版本信息模板在安装目录下，可自行修改。
* m_WorkReport.cs
*
* 功 能： N/A
* 类 名： m_WorkReport
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/3 21:38:32   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BW.MMS.DBUtility;

namespace BW.MMS.DAL
{
	/// <summary>
	/// 数据访问类:m_WorkReport
	/// </summary>
	public partial class m_WorkReport
	{
		public m_WorkReport()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BW.MMS.Model.m_WorkReport model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.UserID != null)
			{
				strSql1.Append("UserID,");
				strSql2.Append(""+model.UserID+",");
			}
			if (model.vc_Content != null)
			{
				strSql1.Append("vc_Content,");
				strSql2.Append("'"+model.vc_Content+"',");
			}
            if (model.vc_NextContent != null)
            {
                strSql1.Append("vc_NextContent,");
                strSql2.Append("'" + model.vc_NextContent + "',");
            }
            if (model.vc_PracticalCompletion != null)
            {
                strSql1.Append("vc_PracticalCompletion,");
                strSql2.Append("'" + model.vc_PracticalCompletion + "',");
            }
			if (model.vc_Reply != null)
			{
				strSql1.Append("vc_Reply,");
				strSql2.Append("'"+model.vc_Reply+"',");
			}
			if (model.WorkReportType != null)
			{
				strSql1.Append("WorkReportType,");
				strSql2.Append(""+model.WorkReportType+",");
			}
			if (model.i_flag != null)
			{
				strSql1.Append("i_flag,");
				strSql2.Append(""+model.i_flag+",");
			}
			strSql.Append("insert into m_WorkReport(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
			object obj = DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public bool Update(BW.MMS.Model.m_WorkReport model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_WorkReport set ");
			if (model.UserID != null)
			{
				strSql.Append("UserID="+model.UserID+",");
			}
			if (model.vc_Content != null)
			{
				strSql.Append("vc_Content='"+model.vc_Content+"',");
			}
			else
			{
				strSql.Append("vc_Content= null ,");
			}
            if (model.vc_NextContent != null)
            {
                strSql.Append("vc_NextContent='" + model.vc_NextContent + "',");
            }
            else
            {
                strSql.Append("vc_NextContent= null ,");
            }
            if (model.vc_PracticalCompletion != null)
            {
                strSql.Append("vc_PracticalCompletion='" + model.vc_PracticalCompletion + "',");
            }
            else
            {
                strSql.Append("vc_PracticalCompletion= null ,");
            }
			if (model.vc_Reply != null)
			{
				strSql.Append("vc_Reply='"+model.vc_Reply+"',");
			}
			else
			{
				strSql.Append("vc_Reply= null ,");
			}
			if (model.WorkReportType != null)
			{
				strSql.Append("WorkReportType="+model.WorkReportType+",");
			}
			if (model.i_flag != null)
			{
				strSql.Append("i_flag="+model.i_flag+",");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ID="+ model.ID+"");
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_WorkReport ");
			strSql.Append(" where ID="+ID+"" );
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public BW.MMS.Model.m_WorkReport GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
            strSql.Append(" ID,UserID,vc_Content,vc_PracticalCompletion,vc_NextContent,vc_Reply,WorkReportType,i_flag ");
			strSql.Append(" from m_WorkReport ");
			strSql.Append(" where ID="+ID+"" );
			BW.MMS.Model.m_WorkReport model=new BW.MMS.Model.m_WorkReport();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
		public BW.MMS.Model.m_WorkReport DataRowToModel(DataRow row)
		{
			BW.MMS.Model.m_WorkReport model=new BW.MMS.Model.m_WorkReport();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["vc_Content"]!=null)
				{
					model.vc_Content=row["vc_Content"].ToString();
				}
                if (row["vc_NextContent"] != null)
                {
                    model.vc_NextContent = row["vc_NextContent"].ToString();
                }
                if (row["vc_PracticalCompletion"] != null)
                {
                    model.vc_PracticalCompletion = row["vc_PracticalCompletion"].ToString();
                }
				if(row["vc_Reply"]!=null)
				{
					model.vc_Reply=row["vc_Reply"].ToString();
				}
				if(row["WorkReportType"]!=null && row["WorkReportType"].ToString()!="")
				{
					model.WorkReportType=int.Parse(row["WorkReportType"].ToString());
				}
				if(row["i_flag"]!=null && row["i_flag"].ToString()!="")
				{
					model.i_flag=int.Parse(row["i_flag"].ToString());
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
            strSql.Append("select ID,UserID,vc_PracticalCompletion,vc_Content,vc_NextContent,vc_Reply,WorkReportType,i_flag ");
			strSql.Append(" FROM m_WorkReport ");
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
            strSql.Append(" ID,UserID,vc_Content,vc_PracticalCompletion,vc_NextContent,vc_Reply,WorkReportType,i_flag ");
			strSql.Append(" FROM m_WorkReport ");
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
			strSql.Append("select count(1) FROM m_WorkReport ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.ExecuteSql(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from m_WorkReport T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		*/
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
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
            param.ReturnFields = " ID,UserID,vc_PracticalCompletion,vc_Content,vc_NextContent,vc_Reply,WorkReportType,i_flag ";
            param.TableName = " m_WorkReport where i_flag=0 ";
            string strWhere = "  and 1=1 ";
            if (name.Trim().Length > 0)
            {
                strWhere += name.Trim();
            }
            param.Where = strWhere;
            return DbHelperSQL.SelectDataByStoredProcedure(param, out total);
        }
		
		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

