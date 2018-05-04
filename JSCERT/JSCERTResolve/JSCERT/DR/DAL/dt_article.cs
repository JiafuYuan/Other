/**  版本信息模板在安装目录下，可自行修改。
* dt_article.cs
*
* 功 能： N/A
* 类 名： dt_article
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/4/23 14:28:42   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Data.SqlClient;
namespace JSCERT.DAL
{
	/// <summary>
	/// 数据访问类:dt_article
	/// </summary>
	public partial class dt_article
	{
		public dt_article()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(JSCERT.Model.dt_article model)
		{
            OleDbParameter[] parameters = new OleDbParameter[6];
            parameters[0] = new OleDbParameter("@content", model.content);
            parameters[1] = new OleDbParameter("@category_id", model.category_id);
            parameters[2] = new OleDbParameter("@channel_id", model.channel_id);
            parameters[3] = new OleDbParameter("@TitleID", model.TitleID);
            parameters[4] = new OleDbParameter("@title", model.title);
            parameters[5] = new OleDbParameter("@add_time", model.add_time);
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();

            if (model.content != null)
            {
                strSql1.Append("content,");
                strSql2.Append("?,");
            }
            if (model.category_id != null)
            {
                strSql1.Append("category_id,");
                strSql2.Append("?,");
            }
			if (model.channel_id != null)
			{
				strSql1.Append("channel_id,");
                strSql2.Append("?,");
			}
			if (model.TitleID != null)
			{
				strSql1.Append("TitleID,");
                strSql2.Append("?,");
			}
            if (model.title != null)
            {
                strSql1.Append("title,");
                strSql2.Append("?,");
            }
            if (model.add_time != null)
            {
                strSql1.Append("add_time,");
                strSql2.Append("?,");
            }
			strSql.Append("insert into dt_article(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
			object obj = DB.OleDbHelper.ExecuteScale(strSql.ToString(), parameters);
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
		public bool Update(JSCERT.Model.dt_article model)
		{
            OleDbParameter[] parameters = new OleDbParameter[6];
            parameters[0] = new OleDbParameter("@content", model.content);
            parameters[1] = new OleDbParameter("@category_id", model.category_id);
            parameters[2] = new OleDbParameter("@channel_id", model.channel_id);
            parameters[3] = new OleDbParameter("@TitleID", model.TitleID);
            parameters[4] = new OleDbParameter("@title", model.title);
            parameters[5] = new OleDbParameter("@add_time", model.add_time);
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_article set ");
            if (model.content != null)
            {
                strSql.Append("content=?,");
            }
            else
            {
                strSql.Append("content= null ,");
            }
            if (model.category_id != null)
            {
                strSql.Append("category_id=?,");
            }
			if (model.channel_id != null)
			{
				strSql.Append("channel_id=?,");
			}
            if (model.TitleID != null)
            {
                strSql.Append("TitleID=?,");
            }
            else
            {
                strSql.Append("TitleID= null ,");
            }
			
			if (model.title != null)
			{
                strSql.Append("title=?,");
			}
			else
			{
				strSql.Append("title= null ,");
			}
			
			
			if (model.add_time != null)
			{
                strSql.Append("add_time=?,");
			}
			else
			{
				strSql.Append("add_time= null ,");
			}
			
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where id="+ model.id+"");
			int rowsAffected=DB.OleDbHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_article ");
			strSql.Append(" where id="+id+"" );
			int rowsAffected=DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
		public JSCERT.Model.dt_article GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" id,channel_id,category_id,call_index,title,link_url,img_url,seo_title,seo_keywords,seo_description,zhaiyao,content,sort_id,click,status,groupids_view,vote_id,is_msg,is_top,is_red,is_hot,is_slide,is_sys,user_name,add_time,update_time,TitleID ");
			strSql.Append(" from dt_article ");
			strSql.Append(" where id="+id+"" );
			JSCERT.Model.dt_article model=new JSCERT.Model.dt_article();
			DataSet ds=DB.OleDbHelper.GetDataSet(strSql.ToString());
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
		public JSCERT.Model.dt_article DataRowToModel(DataRow row)
		{
			JSCERT.Model.dt_article model=new JSCERT.Model.dt_article();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["channel_id"]!=null && row["channel_id"].ToString()!="")
				{
					model.channel_id=int.Parse(row["channel_id"].ToString());
				}
				if(row["category_id"]!=null && row["category_id"].ToString()!="")
				{
					model.category_id=int.Parse(row["category_id"].ToString());
				}
				if(row["call_index"]!=null)
				{
					model.call_index=row["call_index"].ToString();
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["link_url"]!=null)
				{
					model.link_url=row["link_url"].ToString();
				}
				if(row["img_url"]!=null)
				{
					model.img_url=row["img_url"].ToString();
				}
				if(row["seo_title"]!=null)
				{
					model.seo_title=row["seo_title"].ToString();
				}
				if(row["seo_keywords"]!=null)
				{
					model.seo_keywords=row["seo_keywords"].ToString();
				}
				if(row["seo_description"]!=null)
				{
					model.seo_description=row["seo_description"].ToString();
				}
				if(row["zhaiyao"]!=null)
				{
					model.zhaiyao=row["zhaiyao"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["sort_id"]!=null && row["sort_id"].ToString()!="")
				{
					model.sort_id=int.Parse(row["sort_id"].ToString());
				}
				if(row["click"]!=null && row["click"].ToString()!="")
				{
					model.click=int.Parse(row["click"].ToString());
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["groupids_view"]!=null)
				{
					model.groupids_view=row["groupids_view"].ToString();
				}
				if(row["vote_id"]!=null && row["vote_id"].ToString()!="")
				{
					model.vote_id=int.Parse(row["vote_id"].ToString());
				}
				if(row["is_msg"]!=null && row["is_msg"].ToString()!="")
				{
					model.is_msg=int.Parse(row["is_msg"].ToString());
				}
				if(row["is_top"]!=null && row["is_top"].ToString()!="")
				{
					model.is_top=int.Parse(row["is_top"].ToString());
				}
				if(row["is_red"]!=null && row["is_red"].ToString()!="")
				{
					model.is_red=int.Parse(row["is_red"].ToString());
				}
				if(row["is_hot"]!=null && row["is_hot"].ToString()!="")
				{
					model.is_hot=int.Parse(row["is_hot"].ToString());
				}
				if(row["is_slide"]!=null && row["is_slide"].ToString()!="")
				{
					model.is_slide=int.Parse(row["is_slide"].ToString());
				}
				if(row["is_sys"]!=null && row["is_sys"].ToString()!="")
				{
					model.is_sys=int.Parse(row["is_sys"].ToString());
				}
				if(row["user_name"]!=null)
				{
					model.user_name=row["user_name"].ToString();
				}
				if(row["add_time"]!=null && row["add_time"].ToString()!="")
				{
                    model.add_time = DateTime.Parse(((DateTime)row["add_time"]).ToString("yyyy-MM-dd HH:mm:ss.fff"));
				}
				if(row["update_time"]!=null && row["update_time"].ToString()!="")
				{
					model.update_time=DateTime.Parse(row["update_time"].ToString());
				}
				if(row["TitleID"]!=null && row["TitleID"].ToString()!="")
				{
					model.TitleID=int.Parse(row["TitleID"].ToString());
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
			strSql.Append("select id,channel_id,category_id,call_index,title,link_url,img_url,seo_title,seo_keywords,seo_description,zhaiyao,content,sort_id,click,status,groupids_view,vote_id,is_msg,is_top,is_red,is_hot,is_slide,is_sys,user_name,add_time,update_time,TitleID ");
			strSql.Append(" FROM dt_article ");
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
			strSql.Append(" id,channel_id,category_id,call_index,title,link_url,img_url,seo_title,seo_keywords,seo_description,zhaiyao,content,sort_id,click,status,groupids_view,vote_id,is_msg,is_top,is_red,is_hot,is_slide,is_sys,user_name,add_time,update_time,TitleID ");
			strSql.Append(" FROM dt_article ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM dt_article ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from dt_article T ");
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

