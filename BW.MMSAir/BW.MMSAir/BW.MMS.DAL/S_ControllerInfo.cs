/**  版本信息模板在安装目录下，可自行修改。
* S_ControllerInfo.cs
*
* 功 能： N/A
* 类 名： S_ControllerInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/24 15:57:19   N/A    初版
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
	/// 数据访问类:S_ControllerInfo
	/// </summary>
	public partial class S_ControllerInfo
	{
		public S_ControllerInfo()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BW.MMS.Model.S_ControllerInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.ControlName != null)
			{
				strSql1.Append("ControlName,");
				strSql2.Append("'"+model.ControlName+"',");
			}
			if (model.SystemLabel != null)
			{
				strSql1.Append("SystemLabel,");
				strSql2.Append("'"+model.SystemLabel+"',");
			}
			if (model.Description != null)
			{
				strSql1.Append("Description,");
				strSql2.Append("'"+model.Description+"',");
			}
			if (model.Area != null)
			{
				strSql1.Append("Area,");
				strSql2.Append("'"+model.Area+"',");
			}
			if (model.Enable != null)
			{
				strSql1.Append("Enable,");
				strSql2.Append(""+(model.Enable? 1 : 0) +",");
			}
			if (model.ChannelName != null)
			{
				strSql1.Append("ChannelName,");
				strSql2.Append("'"+model.ChannelName+"',");
			}
			if (model.ControllerAddress != null)
			{
				strSql1.Append("ControllerAddress,");
				strSql2.Append("'"+model.ControllerAddress+"',");
			}
			if (model.IPaddress != null)
			{
				strSql1.Append("IPaddress,");
				strSql2.Append("'"+model.IPaddress+"',");
			}
			if (model.Port != null)
			{
				strSql1.Append("Port,");
				strSql2.Append("'"+model.Port+"',");
			}
			if (model.MacAddress != null)
			{
				strSql1.Append("MacAddress,");
				strSql2.Append("'"+model.MacAddress+"',");
			}
			if (model.UserName != null)
			{
				strSql1.Append("UserName,");
				strSql2.Append("'"+model.UserName+"',");
			}
			if (model.PassWord != null)
			{
				strSql1.Append("PassWord,");
				strSql2.Append("'"+model.PassWord+"',");
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
			if (model.OPCRate != null)
			{
				strSql1.Append("OPCRate,");
				strSql2.Append(""+model.OPCRate+",");
			}
			if (model.OPCTimeBias != null)
			{
				strSql1.Append("OPCTimeBias,");
				strSql2.Append(""+model.OPCTimeBias+",");
			}
			if (model.OPCDeadBand != null)
			{
				strSql1.Append("OPCDeadBand,");
				strSql2.Append(""+model.OPCDeadBand+",");
			}
			if (model.OPCLcid != null)
			{
				strSql1.Append("OPCLcid,");
				strSql2.Append("'"+model.OPCLcid+"',");
			}
			if (model.InChannel != null)
			{
				strSql1.Append("InChannel,");
				strSql2.Append(""+model.InChannel+",");
			}
			if (model.OutChannel != null)
			{
				strSql1.Append("OutChannel,");
				strSql2.Append(""+model.OutChannel+",");
			}
			if (model.OperLevel != null)
			{
				strSql1.Append("OperLevel,");
				strSql2.Append(""+model.OperLevel+",");
			}
			strSql.Append("insert into S_ControllerInfo(");
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
		public bool Update(BW.MMS.Model.S_ControllerInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_ControllerInfo set ");
			if (model.ControlName != null)
			{
				strSql.Append("ControlName='"+model.ControlName+"',");
			}
			else
			{
				strSql.Append("ControlName= null ,");
			}
			if (model.SystemLabel != null)
			{
				strSql.Append("SystemLabel='"+model.SystemLabel+"',");
			}
			else
			{
				strSql.Append("SystemLabel= null ,");
			}
			if (model.Description != null)
			{
				strSql.Append("Description='"+model.Description+"',");
			}
			else
			{
				strSql.Append("Description= null ,");
			}
			if (model.Area != null)
			{
				strSql.Append("Area='"+model.Area+"',");
			}
			else
			{
				strSql.Append("Area= null ,");
			}
			if (model.Enable != null)
			{
				strSql.Append("Enable="+ (model.Enable? 1 : 0) +",");
			}
			else
			{
				strSql.Append("Enable= null ,");
			}
			if (model.ChannelName != null)
			{
				strSql.Append("ChannelName='"+model.ChannelName+"',");
			}
			else
			{
				strSql.Append("ChannelName= null ,");
			}
			if (model.ControllerAddress != null)
			{
				strSql.Append("ControllerAddress='"+model.ControllerAddress+"',");
			}
			else
			{
				strSql.Append("ControllerAddress= null ,");
			}
			if (model.IPaddress != null)
			{
				strSql.Append("IPaddress='"+model.IPaddress+"',");
			}
			else
			{
				strSql.Append("IPaddress= null ,");
			}
			if (model.Port != null)
			{
				strSql.Append("Port='"+model.Port+"',");
			}
			else
			{
				strSql.Append("Port= null ,");
			}
			if (model.MacAddress != null)
			{
				strSql.Append("MacAddress='"+model.MacAddress+"',");
			}
			else
			{
				strSql.Append("MacAddress= null ,");
			}
			if (model.UserName != null)
			{
				strSql.Append("UserName='"+model.UserName+"',");
			}
			else
			{
				strSql.Append("UserName= null ,");
			}
			if (model.PassWord != null)
			{
				strSql.Append("PassWord='"+model.PassWord+"',");
			}
			else
			{
				strSql.Append("PassWord= null ,");
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
			if (model.OPCRate != null)
			{
				strSql.Append("OPCRate="+model.OPCRate+",");
			}
			else
			{
				strSql.Append("OPCRate= null ,");
			}
			if (model.OPCTimeBias != null)
			{
				strSql.Append("OPCTimeBias="+model.OPCTimeBias+",");
			}
			else
			{
				strSql.Append("OPCTimeBias= null ,");
			}
			if (model.OPCDeadBand != null)
			{
				strSql.Append("OPCDeadBand="+model.OPCDeadBand+",");
			}
			else
			{
				strSql.Append("OPCDeadBand= null ,");
			}
			if (model.OPCLcid != null)
			{
				strSql.Append("OPCLcid='"+model.OPCLcid+"',");
			}
			else
			{
				strSql.Append("OPCLcid= null ,");
			}
			if (model.InChannel != null)
			{
				strSql.Append("InChannel="+model.InChannel+",");
			}
			else
			{
				strSql.Append("InChannel= null ,");
			}
			if (model.OutChannel != null)
			{
				strSql.Append("OutChannel="+model.OutChannel+",");
			}
			else
			{
				strSql.Append("OutChannel= null ,");
			}
			if (model.OperLevel != null)
			{
				strSql.Append("OperLevel="+model.OperLevel+",");
			}
			else
			{
				strSql.Append("OperLevel= null ,");
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
			strSql.Append("delete from S_ControllerInfo ");
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
		public BW.MMS.Model.S_ControllerInfo GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,ControlName,SystemLabel,Description,Area,Enable,ChannelName,ControllerAddress,IPaddress,Port,MacAddress,UserName,PassWord,DeviceLabel,DeviceCode,OPCRate,OPCTimeBias,OPCDeadBand,OPCLcid,InChannel,OutChannel,OperLevel ");
			strSql.Append(" from S_ControllerInfo ");
			strSql.Append(" where ID="+ID+"" );
			BW.MMS.Model.S_ControllerInfo model=new BW.MMS.Model.S_ControllerInfo();
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
		public BW.MMS.Model.S_ControllerInfo DataRowToModel(DataRow row)
		{
			BW.MMS.Model.S_ControllerInfo model=new BW.MMS.Model.S_ControllerInfo();
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
				if(row["SystemLabel"]!=null)
				{
					model.SystemLabel=row["SystemLabel"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Area"]!=null)
				{
					model.Area=row["Area"].ToString();
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
				if(row["ChannelName"]!=null)
				{
					model.ChannelName=row["ChannelName"].ToString();
				}
				if(row["ControllerAddress"]!=null)
				{
					model.ControllerAddress=row["ControllerAddress"].ToString();
				}
				if(row["IPaddress"]!=null)
				{
					model.IPaddress=row["IPaddress"].ToString();
				}
				if(row["Port"]!=null)
				{
					model.Port=row["Port"].ToString();
				}
				if(row["MacAddress"]!=null)
				{
					model.MacAddress=row["MacAddress"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
				if(row["DeviceLabel"]!=null)
				{
					model.DeviceLabel=row["DeviceLabel"].ToString();
				}
				if(row["DeviceCode"]!=null)
				{
					model.DeviceCode=row["DeviceCode"].ToString();
				}
				if(row["OPCRate"]!=null && row["OPCRate"].ToString()!="")
				{
					model.OPCRate=int.Parse(row["OPCRate"].ToString());
				}
				if(row["OPCTimeBias"]!=null && row["OPCTimeBias"].ToString()!="")
				{
					model.OPCTimeBias=int.Parse(row["OPCTimeBias"].ToString());
				}
				if(row["OPCDeadBand"]!=null && row["OPCDeadBand"].ToString()!="")
				{
					model.OPCDeadBand=decimal.Parse(row["OPCDeadBand"].ToString());
				}
				if(row["OPCLcid"]!=null)
				{
					model.OPCLcid=row["OPCLcid"].ToString();
				}
				if(row["InChannel"]!=null && row["InChannel"].ToString()!="")
				{
					model.InChannel=int.Parse(row["InChannel"].ToString());
				}
				if(row["OutChannel"]!=null && row["OutChannel"].ToString()!="")
				{
					model.OutChannel=int.Parse(row["OutChannel"].ToString());
				}
				if(row["OperLevel"]!=null && row["OperLevel"].ToString()!="")
				{
					model.OperLevel=int.Parse(row["OperLevel"].ToString());
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
			strSql.Append("select ID,ControlName,SystemLabel,Description,Area,Enable,ChannelName,ControllerAddress,IPaddress,Port,MacAddress,UserName,PassWord,DeviceLabel,DeviceCode,OPCRate,OPCTimeBias,OPCDeadBand,OPCLcid,InChannel,OutChannel,OperLevel ");
			strSql.Append(" FROM S_ControllerInfo ");
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
			strSql.Append(" ID,ControlName,SystemLabel,Description,Area,Enable,ChannelName,ControllerAddress,IPaddress,Port,MacAddress,UserName,PassWord,DeviceLabel,DeviceCode,OPCRate,OPCTimeBias,OPCDeadBand,OPCLcid,InChannel,OutChannel,OperLevel ");
			strSql.Append(" FROM S_ControllerInfo ");
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
			strSql.Append("select count(1) FROM S_ControllerInfo ");
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
			strSql.Append(")AS Row, T.*  from S_ControllerInfo T ");
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
            param.ReturnFields = "ID,ControlName,SystemLabel,Description,Area,Enable,ChannelName,ControllerAddress,IPaddress,Port,MacAddress,UserName,PassWord,DeviceLabel,DeviceCode,OPCRate,OPCTimeBias,OPCDeadBand,OPCLcid,InChannel,OutChannel,OperLevel";
            param.TableName = " S_ControllerInfo ";
            string strWhere = "  where  1=1 ";
            if (name.Trim().Length > 0)
            {
                strWhere += name.Trim();
            }
            param.Where = strWhere;
            return DbHelperSQLGH_IMS.SelectDataByStoredProcedure(param, out total);
        }
        /*
        */
		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

