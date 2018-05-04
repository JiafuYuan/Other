/**  版本信息模板在安装目录下，可自行修改。
* HR_personnel.cs
*
* 功 能： N/A
* 类 名： HR_personnel
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-11-26 10:22:30   N/A    初版
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

namespace BW_MMS.DAL
{
	/// <summary>
	/// 数据访问类:HR_personnel
	/// </summary>
	public partial class HR_personnel
	{
		public HR_personnel()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "HR_personnel"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from HR_personnel");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BW_MMS.Model.HR_personnel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HR_personnel(");
			strSql.Append("vc_perid,vc_pname,i_sex,dt_birth,vc_idcard,i_dutyid,i_wtypeid,dt_joinwork,i_deptid,vc_folk,dc_stature,dc_weight,vc_educate,vc_native,vc_polity,vc_speci,vc_marr,vc_address,vc_school,vc_telphone,b_photo,i_state,vc_memo,vc_telphone1,vc_telphone2,vc_email,vc_professionaltitle,vc_graduatedate,vc_becomesdate,vc_ginsengprotectdate,vc_labourcontractdate,vc_permanentaddress,vc_qq,vc_bloodtype,b_iris_l,b_iris_r,vc_Departuredate,vc_Company,vc_businessstart,vc_businessend,vc_changetime,vc_attribution,vc_busystate)");
			strSql.Append(" values (");
			strSql.Append("@vc_perid,@vc_pname,@i_sex,@dt_birth,@vc_idcard,@i_dutyid,@i_wtypeid,@dt_joinwork,@i_deptid,@vc_folk,@dc_stature,@dc_weight,@vc_educate,@vc_native,@vc_polity,@vc_speci,@vc_marr,@vc_address,@vc_school,@vc_telphone,@b_photo,@i_state,@vc_memo,@vc_telphone1,@vc_telphone2,@vc_email,@vc_professionaltitle,@vc_graduatedate,@vc_becomesdate,@vc_ginsengprotectdate,@vc_labourcontractdate,@vc_permanentaddress,@vc_qq,@vc_bloodtype,@b_iris_l,@b_iris_r,@vc_Departuredate,@vc_Company,@vc_businessstart,@vc_businessend,@vc_changetime,@vc_attribution,@vc_busystate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_perid", SqlDbType.VarChar,8),
					new SqlParameter("@vc_pname", SqlDbType.VarChar,20),
					new SqlParameter("@i_sex", SqlDbType.SmallInt,2),
					new SqlParameter("@dt_birth", SqlDbType.DateTime),
					new SqlParameter("@vc_idcard", SqlDbType.VarChar,20),
					new SqlParameter("@i_dutyid", SqlDbType.Int,4),
					new SqlParameter("@i_wtypeid", SqlDbType.Int,4),
					new SqlParameter("@dt_joinwork", SqlDbType.DateTime),
					new SqlParameter("@i_deptid", SqlDbType.Int,4),
					new SqlParameter("@vc_folk", SqlDbType.VarChar,50),
					new SqlParameter("@dc_stature", SqlDbType.Decimal,9),
					new SqlParameter("@dc_weight", SqlDbType.Decimal,9),
					new SqlParameter("@vc_educate", SqlDbType.VarChar,50),
					new SqlParameter("@vc_native", SqlDbType.VarChar,50),
					new SqlParameter("@vc_polity", SqlDbType.VarChar,50),
					new SqlParameter("@vc_speci", SqlDbType.VarChar,50),
					new SqlParameter("@vc_marr", SqlDbType.VarChar,50),
					new SqlParameter("@vc_address", SqlDbType.VarChar,128),
					new SqlParameter("@vc_school", SqlDbType.VarChar,64),
					new SqlParameter("@vc_telphone", SqlDbType.VarChar,32),
					new SqlParameter("@b_photo", SqlDbType.Image),
					new SqlParameter("@i_state", SqlDbType.Int,4),
					new SqlParameter("@vc_memo", SqlDbType.VarChar,100),
					new SqlParameter("@vc_telphone1", SqlDbType.VarChar,50),
					new SqlParameter("@vc_telphone2", SqlDbType.VarChar,50),
					new SqlParameter("@vc_email", SqlDbType.VarChar,50),
					new SqlParameter("@vc_professionaltitle", SqlDbType.VarChar,50),
					new SqlParameter("@vc_graduatedate", SqlDbType.DateTime),
					new SqlParameter("@vc_becomesdate", SqlDbType.DateTime),
					new SqlParameter("@vc_ginsengprotectdate", SqlDbType.DateTime),
					new SqlParameter("@vc_labourcontractdate", SqlDbType.DateTime),
					new SqlParameter("@vc_permanentaddress", SqlDbType.VarChar,128),
					new SqlParameter("@vc_qq", SqlDbType.VarChar,50),
					new SqlParameter("@vc_bloodtype", SqlDbType.VarChar,50),
					new SqlParameter("@b_iris_l", SqlDbType.Image),
					new SqlParameter("@b_iris_r", SqlDbType.Image),
					new SqlParameter("@vc_Departuredate", SqlDbType.DateTime),
					new SqlParameter("@vc_Company", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_businessstart", SqlDbType.DateTime),
					new SqlParameter("@vc_businessend", SqlDbType.DateTime),
					new SqlParameter("@vc_changetime", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_attribution", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_busystate", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.vc_perid;
			parameters[1].Value = model.vc_pname;
			parameters[2].Value = model.i_sex;
			parameters[3].Value = model.dt_birth;
			parameters[4].Value = model.vc_idcard;
			parameters[5].Value = model.i_dutyid;
			parameters[6].Value = model.i_wtypeid;
			parameters[7].Value = model.dt_joinwork;
			parameters[8].Value = model.i_deptid;
			parameters[9].Value = model.vc_folk;
			parameters[10].Value = model.dc_stature;
			parameters[11].Value = model.dc_weight;
			parameters[12].Value = model.vc_educate;
			parameters[13].Value = model.vc_native;
			parameters[14].Value = model.vc_polity;
			parameters[15].Value = model.vc_speci;
			parameters[16].Value = model.vc_marr;
			parameters[17].Value = model.vc_address;
			parameters[18].Value = model.vc_school;
			parameters[19].Value = model.vc_telphone;
			parameters[20].Value = model.b_photo;
			parameters[21].Value = model.i_state;
			parameters[22].Value = model.vc_memo;
			parameters[23].Value = model.vc_telphone1;
			parameters[24].Value = model.vc_telphone2;
			parameters[25].Value = model.vc_email;
			parameters[26].Value = model.vc_professionaltitle;
			parameters[27].Value = model.vc_graduatedate;
			parameters[28].Value = model.vc_becomesdate;
			parameters[29].Value = model.vc_ginsengprotectdate;
			parameters[30].Value = model.vc_labourcontractdate;
			parameters[31].Value = model.vc_permanentaddress;
			parameters[32].Value = model.vc_qq;
			parameters[33].Value = model.vc_bloodtype;
			parameters[34].Value = model.b_iris_l;
			parameters[35].Value = model.b_iris_r;
			parameters[36].Value = model.vc_Departuredate;
			parameters[37].Value = model.vc_Company;
			parameters[38].Value = model.vc_businessstart;
			parameters[39].Value = model.vc_businessend;
			parameters[40].Value = model.vc_changetime;
			parameters[41].Value = model.vc_attribution;
			parameters[42].Value = model.vc_busystate;

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
		public bool Update(BW_MMS.Model.HR_personnel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HR_personnel set ");
			strSql.Append("vc_perid=@vc_perid,");
			strSql.Append("vc_pname=@vc_pname,");
			strSql.Append("i_sex=@i_sex,");
			strSql.Append("dt_birth=@dt_birth,");
			strSql.Append("vc_idcard=@vc_idcard,");
			strSql.Append("i_dutyid=@i_dutyid,");
			strSql.Append("i_wtypeid=@i_wtypeid,");
			strSql.Append("dt_joinwork=@dt_joinwork,");
			strSql.Append("i_deptid=@i_deptid,");
			strSql.Append("vc_folk=@vc_folk,");
			strSql.Append("dc_stature=@dc_stature,");
			strSql.Append("dc_weight=@dc_weight,");
			strSql.Append("vc_educate=@vc_educate,");
			strSql.Append("vc_native=@vc_native,");
			strSql.Append("vc_polity=@vc_polity,");
			strSql.Append("vc_speci=@vc_speci,");
			strSql.Append("vc_marr=@vc_marr,");
			strSql.Append("vc_address=@vc_address,");
			strSql.Append("vc_school=@vc_school,");
			strSql.Append("vc_telphone=@vc_telphone,");
			strSql.Append("b_photo=@b_photo,");
			strSql.Append("i_state=@i_state,");
			strSql.Append("vc_memo=@vc_memo,");
			strSql.Append("vc_telphone1=@vc_telphone1,");
			strSql.Append("vc_telphone2=@vc_telphone2,");
			strSql.Append("vc_email=@vc_email,");
			strSql.Append("vc_professionaltitle=@vc_professionaltitle,");
			strSql.Append("vc_graduatedate=@vc_graduatedate,");
			strSql.Append("vc_becomesdate=@vc_becomesdate,");
			strSql.Append("vc_ginsengprotectdate=@vc_ginsengprotectdate,");
			strSql.Append("vc_labourcontractdate=@vc_labourcontractdate,");
			strSql.Append("vc_permanentaddress=@vc_permanentaddress,");
			strSql.Append("vc_qq=@vc_qq,");
			strSql.Append("vc_bloodtype=@vc_bloodtype,");
			strSql.Append("b_iris_l=@b_iris_l,");
			strSql.Append("b_iris_r=@b_iris_r,");
			strSql.Append("vc_Departuredate=@vc_Departuredate,");
			strSql.Append("vc_Company=@vc_Company,");
			strSql.Append("vc_businessstart=@vc_businessstart,");
			strSql.Append("vc_businessend=@vc_businessend,");
			strSql.Append("vc_changetime=@vc_changetime,");
			strSql.Append("vc_attribution=@vc_attribution,");
			strSql.Append("vc_busystate=@vc_busystate");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@vc_perid", SqlDbType.VarChar,8),
					new SqlParameter("@vc_pname", SqlDbType.VarChar,20),
					new SqlParameter("@i_sex", SqlDbType.SmallInt,2),
					new SqlParameter("@dt_birth", SqlDbType.DateTime),
					new SqlParameter("@vc_idcard", SqlDbType.VarChar,20),
					new SqlParameter("@i_dutyid", SqlDbType.Int,4),
					new SqlParameter("@i_wtypeid", SqlDbType.Int,4),
					new SqlParameter("@dt_joinwork", SqlDbType.DateTime),
					new SqlParameter("@i_deptid", SqlDbType.Int,4),
					new SqlParameter("@vc_folk", SqlDbType.VarChar,50),
					new SqlParameter("@dc_stature", SqlDbType.Decimal,9),
					new SqlParameter("@dc_weight", SqlDbType.Decimal,9),
					new SqlParameter("@vc_educate", SqlDbType.VarChar,50),
					new SqlParameter("@vc_native", SqlDbType.VarChar,50),
					new SqlParameter("@vc_polity", SqlDbType.VarChar,50),
					new SqlParameter("@vc_speci", SqlDbType.VarChar,50),
					new SqlParameter("@vc_marr", SqlDbType.VarChar,50),
					new SqlParameter("@vc_address", SqlDbType.VarChar,128),
					new SqlParameter("@vc_school", SqlDbType.VarChar,64),
					new SqlParameter("@vc_telphone", SqlDbType.VarChar,32),
					new SqlParameter("@b_photo", SqlDbType.Image),
					new SqlParameter("@i_state", SqlDbType.Int,4),
					new SqlParameter("@vc_memo", SqlDbType.VarChar,100),
					new SqlParameter("@vc_telphone1", SqlDbType.VarChar,50),
					new SqlParameter("@vc_telphone2", SqlDbType.VarChar,50),
					new SqlParameter("@vc_email", SqlDbType.VarChar,50),
					new SqlParameter("@vc_professionaltitle", SqlDbType.VarChar,50),
					new SqlParameter("@vc_graduatedate", SqlDbType.DateTime),
					new SqlParameter("@vc_becomesdate", SqlDbType.DateTime),
					new SqlParameter("@vc_ginsengprotectdate", SqlDbType.DateTime),
					new SqlParameter("@vc_labourcontractdate", SqlDbType.DateTime),
					new SqlParameter("@vc_permanentaddress", SqlDbType.VarChar,128),
					new SqlParameter("@vc_qq", SqlDbType.VarChar,50),
					new SqlParameter("@vc_bloodtype", SqlDbType.VarChar,50),
					new SqlParameter("@b_iris_l", SqlDbType.Image),
					new SqlParameter("@b_iris_r", SqlDbType.Image),
					new SqlParameter("@vc_Departuredate", SqlDbType.DateTime),
					new SqlParameter("@vc_Company", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_businessstart", SqlDbType.DateTime),
					new SqlParameter("@vc_businessend", SqlDbType.DateTime),
					new SqlParameter("@vc_changetime", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_attribution", SqlDbType.NVarChar,50),
					new SqlParameter("@vc_busystate", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.vc_perid;
			parameters[1].Value = model.vc_pname;
			parameters[2].Value = model.i_sex;
			parameters[3].Value = model.dt_birth;
			parameters[4].Value = model.vc_idcard;
			parameters[5].Value = model.i_dutyid;
			parameters[6].Value = model.i_wtypeid;
			parameters[7].Value = model.dt_joinwork;
			parameters[8].Value = model.i_deptid;
			parameters[9].Value = model.vc_folk;
			parameters[10].Value = model.dc_stature;
			parameters[11].Value = model.dc_weight;
			parameters[12].Value = model.vc_educate;
			parameters[13].Value = model.vc_native;
			parameters[14].Value = model.vc_polity;
			parameters[15].Value = model.vc_speci;
			parameters[16].Value = model.vc_marr;
			parameters[17].Value = model.vc_address;
			parameters[18].Value = model.vc_school;
			parameters[19].Value = model.vc_telphone;
			parameters[20].Value = model.b_photo;
			parameters[21].Value = model.i_state;
			parameters[22].Value = model.vc_memo;
			parameters[23].Value = model.vc_telphone1;
			parameters[24].Value = model.vc_telphone2;
			parameters[25].Value = model.vc_email;
			parameters[26].Value = model.vc_professionaltitle;
			parameters[27].Value = model.vc_graduatedate;
			parameters[28].Value = model.vc_becomesdate;
			parameters[29].Value = model.vc_ginsengprotectdate;
			parameters[30].Value = model.vc_labourcontractdate;
			parameters[31].Value = model.vc_permanentaddress;
			parameters[32].Value = model.vc_qq;
			parameters[33].Value = model.vc_bloodtype;
			parameters[34].Value = model.b_iris_l;
			parameters[35].Value = model.b_iris_r;
			parameters[36].Value = model.vc_Departuredate;
			parameters[37].Value = model.vc_Company;
			parameters[38].Value = model.vc_businessstart;
			parameters[39].Value = model.vc_businessend;
			parameters[40].Value = model.vc_changetime;
			parameters[41].Value = model.vc_attribution;
			parameters[42].Value = model.vc_busystate;
			parameters[43].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HR_personnel ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HR_personnel ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public BW_MMS.Model.HR_personnel GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,vc_perid,vc_pname,i_sex,dt_birth,vc_idcard,i_dutyid,i_wtypeid,dt_joinwork,i_deptid,vc_folk,dc_stature,dc_weight,vc_educate,vc_native,vc_polity,vc_speci,vc_marr,vc_address,vc_school,vc_telphone,b_photo,i_state,vc_memo,vc_telphone1,vc_telphone2,vc_email,vc_professionaltitle,vc_graduatedate,vc_becomesdate,vc_ginsengprotectdate,vc_labourcontractdate,vc_permanentaddress,vc_qq,vc_bloodtype,b_iris_l,b_iris_r,vc_Departuredate,vc_Company,vc_businessstart,vc_businessend,vc_changetime,vc_attribution,vc_busystate from HR_personnel ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			BW_MMS.Model.HR_personnel model=new BW_MMS.Model.HR_personnel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public BW_MMS.Model.HR_personnel DataRowToModel(DataRow row)
		{
			BW_MMS.Model.HR_personnel model=new BW_MMS.Model.HR_personnel();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["vc_perid"]!=null)
				{
					model.vc_perid=row["vc_perid"].ToString();
				}
				if(row["vc_pname"]!=null)
				{
					model.vc_pname=row["vc_pname"].ToString();
				}
				if(row["i_sex"]!=null && row["i_sex"].ToString()!="")
				{
					model.i_sex=int.Parse(row["i_sex"].ToString());
				}
				if(row["dt_birth"]!=null && row["dt_birth"].ToString()!="")
				{
					model.dt_birth=DateTime.Parse(row["dt_birth"].ToString());
				}
				if(row["vc_idcard"]!=null)
				{
					model.vc_idcard=row["vc_idcard"].ToString();
				}
				if(row["i_dutyid"]!=null && row["i_dutyid"].ToString()!="")
				{
					model.i_dutyid=int.Parse(row["i_dutyid"].ToString());
				}
				if(row["i_wtypeid"]!=null && row["i_wtypeid"].ToString()!="")
				{
					model.i_wtypeid=int.Parse(row["i_wtypeid"].ToString());
				}
				if(row["dt_joinwork"]!=null && row["dt_joinwork"].ToString()!="")
				{
					model.dt_joinwork=DateTime.Parse(row["dt_joinwork"].ToString());
				}
				if(row["i_deptid"]!=null && row["i_deptid"].ToString()!="")
				{
					model.i_deptid=int.Parse(row["i_deptid"].ToString());
				}
				if(row["vc_folk"]!=null)
				{
					model.vc_folk=row["vc_folk"].ToString();
				}
				if(row["dc_stature"]!=null && row["dc_stature"].ToString()!="")
				{
					model.dc_stature=decimal.Parse(row["dc_stature"].ToString());
				}
				if(row["dc_weight"]!=null && row["dc_weight"].ToString()!="")
				{
					model.dc_weight=decimal.Parse(row["dc_weight"].ToString());
				}
				if(row["vc_educate"]!=null)
				{
					model.vc_educate=row["vc_educate"].ToString();
				}
				if(row["vc_native"]!=null)
				{
					model.vc_native=row["vc_native"].ToString();
				}
				if(row["vc_polity"]!=null)
				{
					model.vc_polity=row["vc_polity"].ToString();
				}
				if(row["vc_speci"]!=null)
				{
					model.vc_speci=row["vc_speci"].ToString();
				}
				if(row["vc_marr"]!=null)
				{
					model.vc_marr=row["vc_marr"].ToString();
				}
				if(row["vc_address"]!=null)
				{
					model.vc_address=row["vc_address"].ToString();
				}
				if(row["vc_school"]!=null)
				{
					model.vc_school=row["vc_school"].ToString();
				}
				if(row["vc_telphone"]!=null)
				{
					model.vc_telphone=row["vc_telphone"].ToString();
				}
				if(row["b_photo"]!=null && row["b_photo"].ToString()!="")
				{
					model.b_photo=(byte[])row["b_photo"];
				}
				if(row["i_state"]!=null && row["i_state"].ToString()!="")
				{
					model.i_state=int.Parse(row["i_state"].ToString());
				}
				if(row["vc_memo"]!=null)
				{
					model.vc_memo=row["vc_memo"].ToString();
				}
				if(row["vc_telphone1"]!=null)
				{
					model.vc_telphone1=row["vc_telphone1"].ToString();
				}
				if(row["vc_telphone2"]!=null)
				{
					model.vc_telphone2=row["vc_telphone2"].ToString();
				}
				if(row["vc_email"]!=null)
				{
					model.vc_email=row["vc_email"].ToString();
				}
				if(row["vc_professionaltitle"]!=null)
				{
					model.vc_professionaltitle=row["vc_professionaltitle"].ToString();
				}
				if(row["vc_graduatedate"]!=null && row["vc_graduatedate"].ToString()!="")
				{
					model.vc_graduatedate=DateTime.Parse(row["vc_graduatedate"].ToString());
				}
				if(row["vc_becomesdate"]!=null && row["vc_becomesdate"].ToString()!="")
				{
					model.vc_becomesdate=DateTime.Parse(row["vc_becomesdate"].ToString());
				}
				if(row["vc_ginsengprotectdate"]!=null && row["vc_ginsengprotectdate"].ToString()!="")
				{
					model.vc_ginsengprotectdate=DateTime.Parse(row["vc_ginsengprotectdate"].ToString());
				}
				if(row["vc_labourcontractdate"]!=null && row["vc_labourcontractdate"].ToString()!="")
				{
					model.vc_labourcontractdate=DateTime.Parse(row["vc_labourcontractdate"].ToString());
				}
				if(row["vc_permanentaddress"]!=null)
				{
					model.vc_permanentaddress=row["vc_permanentaddress"].ToString();
				}
				if(row["vc_qq"]!=null)
				{
					model.vc_qq=row["vc_qq"].ToString();
				}
				if(row["vc_bloodtype"]!=null)
				{
					model.vc_bloodtype=row["vc_bloodtype"].ToString();
				}
				if(row["b_iris_l"]!=null && row["b_iris_l"].ToString()!="")
				{
					model.b_iris_l=(byte[])row["b_iris_l"];
				}
				if(row["b_iris_r"]!=null && row["b_iris_r"].ToString()!="")
				{
					model.b_iris_r=(byte[])row["b_iris_r"];
				}
				if(row["vc_Departuredate"]!=null && row["vc_Departuredate"].ToString()!="")
				{
					model.vc_Departuredate=DateTime.Parse(row["vc_Departuredate"].ToString());
				}
				if(row["vc_Company"]!=null)
				{
					model.vc_Company=row["vc_Company"].ToString();
				}
				if(row["vc_businessstart"]!=null && row["vc_businessstart"].ToString()!="")
				{
					model.vc_businessstart=DateTime.Parse(row["vc_businessstart"].ToString());
				}
				if(row["vc_businessend"]!=null && row["vc_businessend"].ToString()!="")
				{
					model.vc_businessend=DateTime.Parse(row["vc_businessend"].ToString());
				}
				if(row["vc_changetime"]!=null)
				{
					model.vc_changetime=row["vc_changetime"].ToString();
				}
				if(row["vc_attribution"]!=null)
				{
					model.vc_attribution=row["vc_attribution"].ToString();
				}
				if(row["vc_busystate"]!=null)
				{
					model.vc_busystate=row["vc_busystate"].ToString();
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
			strSql.Append("select id,vc_perid,vc_pname,i_sex,dt_birth,vc_idcard,i_dutyid,i_wtypeid,dt_joinwork,i_deptid,vc_folk,dc_stature,dc_weight,vc_educate,vc_native,vc_polity,vc_speci,vc_marr,vc_address,vc_school,vc_telphone,b_photo,i_state,vc_memo,vc_telphone1,vc_telphone2,vc_email,vc_professionaltitle,vc_graduatedate,vc_becomesdate,vc_ginsengprotectdate,vc_labourcontractdate,vc_permanentaddress,vc_qq,vc_bloodtype,b_iris_l,b_iris_r,vc_Departuredate,vc_Company,vc_businessstart,vc_businessend,vc_changetime,vc_attribution,vc_busystate ");
			strSql.Append(" FROM HR_personnel ");
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
			strSql.Append(" id,vc_perid,vc_pname,i_sex,dt_birth,vc_idcard,i_dutyid,i_wtypeid,dt_joinwork,i_deptid,vc_folk,dc_stature,dc_weight,vc_educate,vc_native,vc_polity,vc_speci,vc_marr,vc_address,vc_school,vc_telphone,b_photo,i_state,vc_memo,vc_telphone1,vc_telphone2,vc_email,vc_professionaltitle,vc_graduatedate,vc_becomesdate,vc_ginsengprotectdate,vc_labourcontractdate,vc_permanentaddress,vc_qq,vc_bloodtype,b_iris_l,b_iris_r,vc_Departuredate,vc_Company,vc_businessstart,vc_businessend,vc_changetime,vc_attribution,vc_busystate ");
			strSql.Append(" FROM HR_personnel ");
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
			strSql.Append("select count(1) FROM HR_personnel ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from HR_personnel T ");
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
			parameters[0].Value = "HR_personnel";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

