/**  版本信息模板在安装目录下，可自行修改。
* dt_article_attribute_value.cs
*
* 功 能： N/A
* 类 名： dt_article_attribute_value
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/4/23 14:13:02   N/A    初版
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
namespace JSCERT.DAL
{
	/// <summary>
	/// 数据访问类:dt_article_attribute_value
	/// </summary>
	public partial class dt_article_attribute_value
	{
		public dt_article_attribute_value()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(JSCERT.Model.dt_article_attribute_value model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.article_id != null)
			{
				strSql1.Append("article_id,");
				strSql2.Append(""+model.article_id+",");
			}
			if (model.sub_title != null)
			{
				strSql1.Append("sub_title,");
				strSql2.Append("'"+model.sub_title+"',");
			}
			if (model.source != null)
			{
				strSql1.Append("source,");
				strSql2.Append("'"+model.source+"',");
			}
			if (model.author != null)
			{
				strSql1.Append("author,");
				strSql2.Append("'"+model.author+"',");
			}
			if (model.goods_no != null)
			{
				strSql1.Append("goods_no,");
				strSql2.Append("'"+model.goods_no+"',");
			}
			if (model.stock_quantity != null)
			{
				strSql1.Append("stock_quantity,");
				strSql2.Append(""+model.stock_quantity+",");
			}
			if (model.market_price != null)
			{
				strSql1.Append("market_price,");
				strSql2.Append(""+model.market_price+",");
			}
			if (model.sell_price != null)
			{
				strSql1.Append("sell_price,");
				strSql2.Append(""+model.sell_price+",");
			}
			if (model.point != null)
			{
				strSql1.Append("point,");
				strSql2.Append(""+model.point+",");
			}
			if (model.zhichixitong != null)
			{
				strSql1.Append("zhichixitong,");
				strSql2.Append("'"+model.zhichixitong+"',");
			}
			if (model.pinpai != null)
			{
				strSql1.Append("pinpai,");
				strSql2.Append("'"+model.pinpai+"',");
			}
			if (model.chexi != null)
			{
				strSql1.Append("chexi,");
				strSql2.Append("'"+model.chexi+"',");
			}
			if (model.jiage != null)
			{
				strSql1.Append("jiage,");
				strSql2.Append("'"+model.jiage+"',");
			}
			if (model.nihao != null)
			{
				strSql1.Append("nihao,");
				strSql2.Append("'"+model.nihao+"',");
			}
			strSql.Append("insert into dt_article_attribute_value(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			int rows=DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
		public bool Update(JSCERT.Model.dt_article_attribute_value model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_article_attribute_value set ");
			if (model.sub_title != null)
			{
				strSql.Append("sub_title='"+model.sub_title+"',");
			}
			else
			{
				strSql.Append("sub_title= null ,");
			}
			if (model.source != null)
			{
				strSql.Append("source='"+model.source+"',");
			}
			else
			{
				strSql.Append("source= null ,");
			}
			if (model.author != null)
			{
				strSql.Append("author='"+model.author+"',");
			}
			else
			{
				strSql.Append("author= null ,");
			}
			if (model.goods_no != null)
			{
				strSql.Append("goods_no='"+model.goods_no+"',");
			}
			else
			{
				strSql.Append("goods_no= null ,");
			}
			if (model.stock_quantity != null)
			{
				strSql.Append("stock_quantity="+model.stock_quantity+",");
			}
			else
			{
				strSql.Append("stock_quantity= null ,");
			}
			if (model.market_price != null)
			{
				strSql.Append("market_price="+model.market_price+",");
			}
			else
			{
				strSql.Append("market_price= null ,");
			}
			if (model.sell_price != null)
			{
				strSql.Append("sell_price="+model.sell_price+",");
			}
			else
			{
				strSql.Append("sell_price= null ,");
			}
			if (model.point != null)
			{
				strSql.Append("point="+model.point+",");
			}
			else
			{
				strSql.Append("point= null ,");
			}
			if (model.zhichixitong != null)
			{
				strSql.Append("zhichixitong='"+model.zhichixitong+"',");
			}
			else
			{
				strSql.Append("zhichixitong= null ,");
			}
			if (model.pinpai != null)
			{
				strSql.Append("pinpai='"+model.pinpai+"',");
			}
			else
			{
				strSql.Append("pinpai= null ,");
			}
			if (model.chexi != null)
			{
				strSql.Append("chexi='"+model.chexi+"',");
			}
			else
			{
				strSql.Append("chexi= null ,");
			}
			if (model.jiage != null)
			{
				strSql.Append("jiage='"+model.jiage+"',");
			}
			else
			{
				strSql.Append("jiage= null ,");
			}
			if (model.nihao != null)
			{
				strSql.Append("nihao='"+model.nihao+"',");
			}
			else
			{
				strSql.Append("nihao= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where article_id="+ model.article_id+" ");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int article_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_article_attribute_value ");
			strSql.Append(" where article_id="+article_id+" " );
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
		public JSCERT.Model.dt_article_attribute_value GetModel(int article_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" article_id,sub_title,source,author,goods_no,stock_quantity,market_price,sell_price,point,zhichixitong,pinpai,chexi,jiage,nihao ");
			strSql.Append(" from dt_article_attribute_value ");
			strSql.Append(" where article_id="+article_id+" " );
			JSCERT.Model.dt_article_attribute_value model=new JSCERT.Model.dt_article_attribute_value();
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
		public JSCERT.Model.dt_article_attribute_value DataRowToModel(DataRow row)
		{
			JSCERT.Model.dt_article_attribute_value model=new JSCERT.Model.dt_article_attribute_value();
			if (row != null)
			{
				if(row["article_id"]!=null && row["article_id"].ToString()!="")
				{
					model.article_id=int.Parse(row["article_id"].ToString());
				}
				if(row["sub_title"]!=null)
				{
					model.sub_title=row["sub_title"].ToString();
				}
				if(row["source"]!=null)
				{
					model.source=row["source"].ToString();
				}
				if(row["author"]!=null)
				{
					model.author=row["author"].ToString();
				}
				if(row["goods_no"]!=null)
				{
					model.goods_no=row["goods_no"].ToString();
				}
				if(row["stock_quantity"]!=null && row["stock_quantity"].ToString()!="")
				{
					model.stock_quantity=int.Parse(row["stock_quantity"].ToString());
				}
				if(row["market_price"]!=null && row["market_price"].ToString()!="")
				{
					model.market_price=decimal.Parse(row["market_price"].ToString());
				}
				if(row["sell_price"]!=null && row["sell_price"].ToString()!="")
				{
					model.sell_price=decimal.Parse(row["sell_price"].ToString());
				}
				if(row["point"]!=null && row["point"].ToString()!="")
				{
					model.point=int.Parse(row["point"].ToString());
				}
				if(row["zhichixitong"]!=null)
				{
					model.zhichixitong=row["zhichixitong"].ToString();
				}
				if(row["pinpai"]!=null)
				{
					model.pinpai=row["pinpai"].ToString();
				}
				if(row["chexi"]!=null)
				{
					model.chexi=row["chexi"].ToString();
				}
				if(row["jiage"]!=null)
				{
					model.jiage=row["jiage"].ToString();
				}
				if(row["nihao"]!=null)
				{
					model.nihao=row["nihao"].ToString();
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
			strSql.Append("select article_id,sub_title,source,author,goods_no,stock_quantity,market_price,sell_price,point,zhichixitong,pinpai,chexi,jiage,nihao ");
			strSql.Append(" FROM dt_article_attribute_value ");
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
			strSql.Append(" article_id,sub_title,source,author,goods_no,stock_quantity,market_price,sell_price,point,zhichixitong,pinpai,chexi,jiage,nihao ");
			strSql.Append(" FROM dt_article_attribute_value ");
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
			strSql.Append("select count(1) FROM dt_article_attribute_value ");
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
				strSql.Append("order by T.article_id desc");
			}
			strSql.Append(")AS Row, T.*  from dt_article_attribute_value T ");
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

