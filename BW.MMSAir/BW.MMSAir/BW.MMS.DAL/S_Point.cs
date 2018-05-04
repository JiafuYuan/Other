/**  版本信息模板在安装目录下，可自行修改。
* S_Point.cs
*
* 功 能： N/A
* 类 名： S_Point
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/9 17:32:49   N/A    初版
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
	/// 数据访问类:S_Point
	/// </summary>
	public partial class S_Point
	{
		public S_Point()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BW.MMS.Model.S_Point model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ControlName != null)
			{
				strSql1.Append("ControlName,");
				strSql2.Append("'"+model.ControlName+"',");
			}
			if (model.PointName != null)
			{
				strSql1.Append("PointName,");
				strSql2.Append("'"+model.PointName+"',");
			}
			if (model.PointAddress != null)
			{
				strSql1.Append("PointAddress,");
				strSql2.Append("'"+model.PointAddress+"',");
			}
			if (model.PointDescription != null)
			{
				strSql1.Append("PointDescription,");
				strSql2.Append("'"+model.PointDescription+"',");
			}
			if (model.PointValueType != null)
			{
				strSql1.Append("PointValueType,");
				strSql2.Append(""+model.PointValueType+",");
			}
			if (model.OperLevel != null)
			{
				strSql1.Append("OperLevel,");
				strSql2.Append(""+model.OperLevel+",");
			}
			if (model.SystemLabel != null)
			{
				strSql1.Append("SystemLabel,");
				strSql2.Append("'"+model.SystemLabel+"',");
			}
			if (model.Unit != null)
			{
				strSql1.Append("Unit,");
				strSql2.Append("'"+model.Unit+"',");
			}
			if (model.Associatevideo != null)
			{
				strSql1.Append("Associatevideo,");
				strSql2.Append("'"+model.Associatevideo+"',");
			}
			if (model.DeviceLabel != null)
			{
				strSql1.Append("DeviceLabel,");
				strSql2.Append("'"+model.DeviceLabel+"',");
			}
			if (model.DeviceCode != null)
			{
				strSql1.Append("DeviceCode,");
				strSql2.Append("'"+model.DeviceCode+"',");
			}
			if (model.Area != null)
			{
				strSql1.Append("Area,");
				strSql2.Append("'"+model.Area+"',");
			}
			if (model.AlarmForm != null)
			{
				strSql1.Append("AlarmForm,");
				strSql2.Append("'"+model.AlarmForm+"',");
			}
			if (model.Latitudes != null)
			{
				strSql1.Append("Latitudes,");
				strSql2.Append(""+model.Latitudes+",");
			}
			if (model.Longitude != null)
			{
				strSql1.Append("Longitude,");
				strSql2.Append(""+model.Longitude+",");
			}
			if (model.Marker != null)
			{
				strSql1.Append("Marker,");
				strSql2.Append(""+(model.Marker? 1 : 0) +",");
			}
			if (model.IconName != null)
			{
				strSql1.Append("IconName,");
				strSql2.Append("'"+model.IconName+"',");
			}
			if (model.Enable != null)
			{
				strSql1.Append("Enable,");
				strSql2.Append(""+(model.Enable? 1 : 0) +",");
			}
			if (model.ReadOnly != null)
			{
				strSql1.Append("ReadOnly,");
				strSql2.Append(""+(model.ReadOnly? 1 : 0) +",");
			}
			strSql.Append("insert into S_Point(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
			object obj = DbHelperSQLGH_IMS.ExecuteSql(strSql.ToString());
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
		public bool Update(BW.MMS.Model.S_Point model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_Point set ");
			if (model.ControlName != null)
			{
				strSql.Append("ControlName='"+model.ControlName+"',");
			}
			else
			{
				strSql.Append("ControlName= null ,");
			}
			if (model.PointName != null)
			{
				strSql.Append("PointName='"+model.PointName+"',");
			}
			else
			{
				strSql.Append("PointName= null ,");
			}
			if (model.PointAddress != null)
			{
				strSql.Append("PointAddress='"+model.PointAddress+"',");
			}
			else
			{
				strSql.Append("PointAddress= null ,");
			}
			if (model.PointDescription != null)
			{
				strSql.Append("PointDescription='"+model.PointDescription+"',");
			}
			else
			{
				strSql.Append("PointDescription= null ,");
			}
			if (model.PointValueType != null)
			{
				strSql.Append("PointValueType="+model.PointValueType+",");
			}
			else
			{
				strSql.Append("PointValueType= null ,");
			}
			if (model.OperLevel != null)
			{
				strSql.Append("OperLevel="+model.OperLevel+",");
			}
			else
			{
				strSql.Append("OperLevel= null ,");
			}
			if (model.SystemLabel != null)
			{
				strSql.Append("SystemLabel='"+model.SystemLabel+"',");
			}
			else
			{
				strSql.Append("SystemLabel= null ,");
			}
			if (model.Unit != null)
			{
				strSql.Append("Unit='"+model.Unit+"',");
			}
			else
			{
				strSql.Append("Unit= null ,");
			}
			if (model.Associatevideo != null)
			{
				strSql.Append("Associatevideo='"+model.Associatevideo+"',");
			}
			else
			{
				strSql.Append("Associatevideo= null ,");
			}
			if (model.DeviceLabel != null)
			{
				strSql.Append("DeviceLabel='"+model.DeviceLabel+"',");
			}
			else
			{
				strSql.Append("DeviceLabel= null ,");
			}
			if (model.DeviceCode != null)
			{
				strSql.Append("DeviceCode='"+model.DeviceCode+"',");
			}
			else
			{
				strSql.Append("DeviceCode= null ,");
			}
			if (model.Area != null)
			{
				strSql.Append("Area='"+model.Area+"',");
			}
			else
			{
				strSql.Append("Area= null ,");
			}
			if (model.AlarmForm != null)
			{
				strSql.Append("AlarmForm='"+model.AlarmForm+"',");
			}
			else
			{
				strSql.Append("AlarmForm= null ,");
			}
			if (model.Latitudes != null)
			{
				strSql.Append("Latitudes="+model.Latitudes+",");
			}
			else
			{
				strSql.Append("Latitudes= null ,");
			}
			if (model.Longitude != null)
			{
				strSql.Append("Longitude="+model.Longitude+",");
			}
			else
			{
				strSql.Append("Longitude= null ,");
			}
			if (model.Marker != null)
			{
				strSql.Append("Marker="+ (model.Marker? 1 : 0) +",");
			}
			else
			{
				strSql.Append("Marker= null ,");
			}
			if (model.IconName != null)
			{
				strSql.Append("IconName='"+model.IconName+"',");
			}
			else
			{
				strSql.Append("IconName= null ,");
			}
			if (model.Enable != null)
			{
				strSql.Append("Enable="+ (model.Enable? 1 : 0) +",");
			}
			else
			{
				strSql.Append("Enable= null ,");
			}
			if (model.ReadOnly != null)
			{
				strSql.Append("ReadOnly="+ (model.ReadOnly? 1 : 0) +",");
			}
			else
			{
				strSql.Append("ReadOnly= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ID="+ model.ID+"");
			int rowsAffected=DbHelperSQLGH_IMS.ExecuteSql(strSql.ToString());
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
			strSql.Append("delete from S_Point ");
			strSql.Append(" where ID="+ID+"" );
			int rowsAffected=DbHelperSQLGH_IMS.ExecuteSql(strSql.ToString());
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
		public BW.MMS.Model.S_Point GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,ControlName,PointName,PointAddress,PointDescription,PointValueType,OperLevel,SystemLabel,Unit,Associatevideo,DeviceLabel,DeviceCode,Area,AlarmForm,Latitudes,Longitude,Marker,IconName,Enable,ReadOnly ");
			strSql.Append(" from S_Point ");
			strSql.Append(" where ID="+ID+"" );
			BW.MMS.Model.S_Point model=new BW.MMS.Model.S_Point();
			DataSet ds=DbHelperSQLGH_IMS.Query(strSql.ToString());
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
		public BW.MMS.Model.S_Point DataRowToModel(DataRow row)
		{
			BW.MMS.Model.S_Point model=new BW.MMS.Model.S_Point();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ControlName"]!=null)
				{
					model.ControlName=row["ControlName"].ToString();
				}
				if(row["PointName"]!=null)
				{
					model.PointName=row["PointName"].ToString();
				}
				if(row["PointAddress"]!=null)
				{
					model.PointAddress=row["PointAddress"].ToString();
				}
				if(row["PointDescription"]!=null)
				{
					model.PointDescription=row["PointDescription"].ToString();
				}
				if(row["PointValueType"]!=null && row["PointValueType"].ToString()!="")
				{
					model.PointValueType=int.Parse(row["PointValueType"].ToString());
				}
				if(row["OperLevel"]!=null && row["OperLevel"].ToString()!="")
				{
					model.OperLevel=int.Parse(row["OperLevel"].ToString());
				}
				if(row["SystemLabel"]!=null)
				{
					model.SystemLabel=row["SystemLabel"].ToString();
				}
				if(row["Unit"]!=null)
				{
					model.Unit=row["Unit"].ToString();
				}
				if(row["Associatevideo"]!=null)
				{
					model.Associatevideo=row["Associatevideo"].ToString();
				}
				if(row["DeviceLabel"]!=null)
				{
					model.DeviceLabel=row["DeviceLabel"].ToString();
				}
				if(row["DeviceCode"]!=null)
				{
					model.DeviceCode=row["DeviceCode"].ToString();
				}
				if(row["Area"]!=null)
				{
					model.Area=row["Area"].ToString();
				}
				if(row["AlarmForm"]!=null)
				{
					model.AlarmForm=row["AlarmForm"].ToString();
				}
				if(row["Latitudes"]!=null && row["Latitudes"].ToString()!="")
				{
					model.Latitudes=decimal.Parse(row["Latitudes"].ToString());
				}
				if(row["Longitude"]!=null && row["Longitude"].ToString()!="")
				{
					model.Longitude=decimal.Parse(row["Longitude"].ToString());
				}
				if(row["Marker"]!=null && row["Marker"].ToString()!="")
				{
					if((row["Marker"].ToString()=="1")||(row["Marker"].ToString().ToLower()=="true"))
					{
						model.Marker=true;
					}
					else
					{
						model.Marker=false;
					}
				}
				if(row["IconName"]!=null)
				{
					model.IconName=row["IconName"].ToString();
				}
				if(row["Enable"]!=null && row["Enable"].ToString()!="")
				{
					if((row["Enable"].ToString()=="1")||(row["Enable"].ToString().ToLower()=="true"))
					{
						model.Enable=true;
					}
					else
					{
						model.Enable=false;
					}
				}
				if(row["ReadOnly"]!=null && row["ReadOnly"].ToString()!="")
				{
					if((row["ReadOnly"].ToString()=="1")||(row["ReadOnly"].ToString().ToLower()=="true"))
					{
						model.ReadOnly=true;
					}
					else
					{
						model.ReadOnly=false;
					}
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
			strSql.Append("select ID,ControlName,PointName,PointAddress,PointDescription,PointValueType,OperLevel,SystemLabel,Unit,Associatevideo,DeviceLabel,DeviceCode,Area,AlarmForm,Latitudes,Longitude,Marker,IconName,Enable,ReadOnly ");
			strSql.Append(" FROM S_Point ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQLGH_IMS.Query(strSql.ToString());
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
			strSql.Append(" ID,ControlName,PointName,PointAddress,PointDescription,PointValueType,OperLevel,SystemLabel,Unit,Associatevideo,DeviceLabel,DeviceCode,Area,AlarmForm,Latitudes,Longitude,Marker,IconName,Enable,ReadOnly ");
			strSql.Append(" FROM S_Point ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQLGH_IMS.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM S_Point ");
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
			strSql.Append(")AS Row, T.*  from S_Point T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQLGH_IMS.Query(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

