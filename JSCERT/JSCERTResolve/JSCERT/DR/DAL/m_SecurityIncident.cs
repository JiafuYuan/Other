/**  版本信息模板在安装目录下，可自行修改。
* m_SecurityIncident.cs
*
* 功 能： N/A
* 类 名： m_SecurityIncident
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/20 15:56:11   N/A    初版
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
	/// 数据访问类:m_SecurityIncident
	/// </summary>
	public partial class m_SecurityIncident
	{
		public m_SecurityIncident()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(JSCERT.Model.m_SecurityIncident model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into m_SecurityIncident(");
            strSql.Append("vc_Source,vc_Name,vc_Level,vc_Type,vc_ChildType,dt_RecTime,vc_Url,vc_IP,vc_DomainName,vc_InjuredPartyName,vc_InjuredPartyType,vc_Cisborder,vc_Country,vc_Tel,vc_City,vc_Describe,vc_Accessory)");
            strSql.Append(" values (");
            strSql.Append("?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
            strSql.Append(";select @@IDENTITY");
            OleDbParameter[] parameters = {
					new OleDbParameter("@vc_Source", model.vc_Source),
					new OleDbParameter("@vc_Name", model.vc_Name),
					new OleDbParameter("@vc_Level", model.vc_Level),
					new OleDbParameter("@vc_Type", model.vc_Type),
					new OleDbParameter("@vc_ChildType", model.vc_ChildType),
					new OleDbParameter("@dt_RecTime", model.dt_RecTime),
					new OleDbParameter("@vc_Url", model.vc_Url),
					new OleDbParameter("@vc_IP", model.vc_IP),
					new OleDbParameter("@vc_DomainName", model.vc_DomainName),
					new OleDbParameter("@vc_InjuredPartyName", model.vc_InjuredPartyName),
					new OleDbParameter("@vc_InjuredPartyType", model.vc_InjuredPartyType),
					new OleDbParameter("@vc_Cisborder", model.vc_Cisborder),
					new OleDbParameter("@vc_Country", model.vc_Country),
					new OleDbParameter("@vc_Tel", model.vc_Tel),
					new OleDbParameter("@vc_City", model.vc_City),
					new OleDbParameter("@vc_Describe", model.vc_Describe),
					new OleDbParameter("@vc_Accessory", model.vc_Accessory)};
            object obj = DB.OleDbHelper.ExecuteSql(strSql.ToString(), parameters, CommandType.Text);
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
		public bool Update(JSCERT.Model.m_SecurityIncident model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_SecurityIncident set ");
			if (model.vc_Source != null)
			{
				strSql.Append("vc_Source='"+model.vc_Source+"',");
			}
			if (model.vc_Name != null)
			{
				strSql.Append("vc_Name='"+model.vc_Name+"',");
			}
			if (model.vc_Level != null)
			{
				strSql.Append("vc_Level='"+model.vc_Level+"',");
			}
			else
			{
				strSql.Append("vc_Level= null ,");
			}
			if (model.vc_Type != null)
			{
				strSql.Append("vc_Type='"+model.vc_Type+"',");
			}
			if (model.vc_ChildType != null)
			{
				strSql.Append("vc_ChildType='"+model.vc_ChildType+"',");
			}
			else
			{
				strSql.Append("vc_ChildType= null ,");
			}
			if (model.dt_RecTime != null)
			{
				strSql.Append("dt_RecTime='"+model.dt_RecTime+"',");
			}
			else
			{
				strSql.Append("dt_RecTime= null ,");
			}
			if (model.vc_Url != null)
			{
				strSql.Append("vc_Url='"+model.vc_Url+"',");
			}
			else
			{
				strSql.Append("vc_Url= null ,");
			}
			if (model.vc_IP != null)
			{
				strSql.Append("vc_IP='"+model.vc_IP+"',");
			}
			else
			{
				strSql.Append("vc_IP= null ,");
			}
			if (model.vc_DomainName != null)
			{
				strSql.Append("vc_DomainName='"+model.vc_DomainName+"',");
			}
			else
			{
				strSql.Append("vc_DomainName= null ,");
			}
			if (model.vc_InjuredPartyName != null)
			{
				strSql.Append("vc_InjuredPartyName='"+model.vc_InjuredPartyName+"',");
			}
			else
			{
				strSql.Append("vc_InjuredPartyName= null ,");
			}
			if (model.vc_InjuredPartyType != null)
			{
				strSql.Append("vc_InjuredPartyType='"+model.vc_InjuredPartyType+"',");
			}
			else
			{
				strSql.Append("vc_InjuredPartyType= null ,");
			}
			if (model.vc_Cisborder != null)
			{
				strSql.Append("vc_Cisborder='"+model.vc_Cisborder+"',");
			}
			else
			{
				strSql.Append("vc_Cisborder= null ,");
			}
			if (model.vc_Country != null)
			{
				strSql.Append("vc_Country='"+model.vc_Country+"',");
			}
			else
			{
				strSql.Append("vc_Country= null ,");
			}
			if (model.vc_Tel != null)
			{
				strSql.Append("vc_Tel='"+model.vc_Tel+"',");
			}
			else
			{
				strSql.Append("vc_Tel= null ,");
			}
			if (model.vc_City != null)
			{
				strSql.Append("vc_City='"+model.vc_City+"',");
			}
			else
			{
				strSql.Append("vc_City= null ,");
			}
			if (model.vc_Describe != null)
			{
				strSql.Append("vc_Describe='"+model.vc_Describe+"',");
			}
			else
			{
				strSql.Append("vc_Describe= null ,");
			}
			if (model.vc_Accessory != null)
			{
				strSql.Append("vc_Accessory='"+model.vc_Accessory+"',");
			}
			else
			{
				strSql.Append("vc_Accessory= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ID="+ model.ID+" ");
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
		public bool Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_SecurityIncident ");
			strSql.Append(" where ID="+ID+" " );
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
		public JSCERT.Model.m_SecurityIncident GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,vc_Source,vc_Name,vc_Level,vc_Type,vc_ChildType,dt_RecTime,vc_Url,vc_IP,vc_DomainName,vc_InjuredPartyName,vc_InjuredPartyType,vc_Cisborder,vc_Country,vc_Tel,vc_City,vc_Describe,vc_Accessory ");
			strSql.Append(" from m_SecurityIncident ");
			strSql.Append(" where ID="+ID+" " );
			JSCERT.Model.m_SecurityIncident model=new JSCERT.Model.m_SecurityIncident();
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
		public JSCERT.Model.m_SecurityIncident DataRowToModel(DataRow row)
		{
			JSCERT.Model.m_SecurityIncident model=new JSCERT.Model.m_SecurityIncident();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["vc_Source"]!=null)
				{
					model.vc_Source=row["vc_Source"].ToString();
				}
				if(row["vc_Name"]!=null)
				{
					model.vc_Name=row["vc_Name"].ToString();
				}
				if(row["vc_Level"]!=null)
				{
					model.vc_Level=row["vc_Level"].ToString();
				}
				if(row["vc_Type"]!=null)
				{
					model.vc_Type=row["vc_Type"].ToString();
				}
				if(row["vc_ChildType"]!=null)
				{
					model.vc_ChildType=row["vc_ChildType"].ToString();
				}
				if(row["dt_RecTime"]!=null && row["dt_RecTime"].ToString()!="")
				{
					model.dt_RecTime=DateTime.Parse(row["dt_RecTime"].ToString());
				}
				if(row["vc_Url"]!=null)
				{
					model.vc_Url=row["vc_Url"].ToString();
				}
				if(row["vc_IP"]!=null)
				{
					model.vc_IP=row["vc_IP"].ToString();
				}
				if(row["vc_DomainName"]!=null)
				{
					model.vc_DomainName=row["vc_DomainName"].ToString();
				}
				if(row["vc_InjuredPartyName"]!=null)
				{
					model.vc_InjuredPartyName=row["vc_InjuredPartyName"].ToString();
				}
				if(row["vc_InjuredPartyType"]!=null)
				{
					model.vc_InjuredPartyType=row["vc_InjuredPartyType"].ToString();
				}
				if(row["vc_Cisborder"]!=null)
				{
					model.vc_Cisborder=row["vc_Cisborder"].ToString();
				}
				if(row["vc_Country"]!=null)
				{
					model.vc_Country=row["vc_Country"].ToString();
				}
				if(row["vc_Tel"]!=null)
				{
					model.vc_Tel=row["vc_Tel"].ToString();
				}
				if(row["vc_City"]!=null)
				{
					model.vc_City=row["vc_City"].ToString();
				}
				if(row["vc_Describe"]!=null)
				{
					model.vc_Describe=row["vc_Describe"].ToString();
				}
				if(row["vc_Accessory"]!=null)
				{
					model.vc_Accessory=row["vc_Accessory"].ToString();
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
			strSql.Append("select ID,vc_Source,vc_Name,vc_Level,vc_Type,vc_ChildType,dt_RecTime,vc_Url,vc_IP,vc_DomainName,vc_InjuredPartyName,vc_InjuredPartyType,vc_Cisborder,vc_Country,vc_Tel,vc_City,vc_Describe,vc_Accessory ");
			strSql.Append(" FROM m_SecurityIncident ");
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
			strSql.Append(" ID,vc_Source,vc_Name,vc_Level,vc_Type,vc_ChildType,dt_RecTime,vc_Url,vc_IP,vc_DomainName,vc_InjuredPartyName,vc_InjuredPartyType,vc_Cisborder,vc_Country,vc_Tel,vc_City,vc_Describe,vc_Accessory ");
			strSql.Append(" FROM m_SecurityIncident ");
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
			strSql.Append("select count(1) FROM m_SecurityIncident ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from m_SecurityIncident T ");
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

