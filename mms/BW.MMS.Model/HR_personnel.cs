/**  版本信息模板在安装目录下，可自行修改。
* HR_personnel.cs
*
* 功 能： N/A
* 类 名： HR_personnel
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-11-26 10:22:29   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace BW_MMS.Model
{
	/// <summary>
	/// HR_personnel:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HR_personnel
	{
		public HR_personnel()
		{}
		#region Model
		private int _id;
		private string _vc_perid;
		private string _vc_pname;
		private int _i_sex;
		private DateTime? _dt_birth;
		private string _vc_idcard;
		private int _i_dutyid;
		private int _i_wtypeid;
		private DateTime? _dt_joinwork;
		private int _i_deptid;
		private string _vc_folk;
		private decimal? _dc_stature;
		private decimal? _dc_weight;
		private string _vc_educate;
		private string _vc_native;
		private string _vc_polity;
		private string _vc_speci;
		private string _vc_marr;
		private string _vc_address;
		private string _vc_school;
		private string _vc_telphone;
		private byte[] _b_photo;
		private int _i_state=0;
		private string _vc_memo;
		private string _vc_telphone1;
		private string _vc_telphone2;
		private string _vc_email;
		private string _vc_professionaltitle;
		private DateTime? _vc_graduatedate;
		private DateTime? _vc_becomesdate;
		private DateTime? _vc_ginsengprotectdate;
		private DateTime? _vc_labourcontractdate;
		private string _vc_permanentaddress;
		private string _vc_qq;
		private string _vc_bloodtype;
		private byte[] _b_iris_l;
		private byte[] _b_iris_r;
		private DateTime? _vc_departuredate;
		private string _vc_company;
		private DateTime? _vc_businessstart;
		private DateTime? _vc_businessend;
		private string _vc_changetime;
		private string _vc_attribution;
		private string _vc_busystate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_perid
		{
			set{ _vc_perid=value;}
			get{return _vc_perid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_pname
		{
			set{ _vc_pname=value;}
			get{return _vc_pname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_sex
		{
			set{ _i_sex=value;}
			get{return _i_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_birth
		{
			set{ _dt_birth=value;}
			get{return _dt_birth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_idcard
		{
			set{ _vc_idcard=value;}
			get{return _vc_idcard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_dutyid
		{
			set{ _i_dutyid=value;}
			get{return _i_dutyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_wtypeid
		{
			set{ _i_wtypeid=value;}
			get{return _i_wtypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_joinwork
		{
			set{ _dt_joinwork=value;}
			get{return _dt_joinwork;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_deptid
		{
			set{ _i_deptid=value;}
			get{return _i_deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_folk
		{
			set{ _vc_folk=value;}
			get{return _vc_folk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? dc_stature
		{
			set{ _dc_stature=value;}
			get{return _dc_stature;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? dc_weight
		{
			set{ _dc_weight=value;}
			get{return _dc_weight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_educate
		{
			set{ _vc_educate=value;}
			get{return _vc_educate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_native
		{
			set{ _vc_native=value;}
			get{return _vc_native;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_polity
		{
			set{ _vc_polity=value;}
			get{return _vc_polity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_speci
		{
			set{ _vc_speci=value;}
			get{return _vc_speci;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_marr
		{
			set{ _vc_marr=value;}
			get{return _vc_marr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_address
		{
			set{ _vc_address=value;}
			get{return _vc_address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_school
		{
			set{ _vc_school=value;}
			get{return _vc_school;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_telphone
		{
			set{ _vc_telphone=value;}
			get{return _vc_telphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] b_photo
		{
			set{ _b_photo=value;}
			get{return _b_photo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_state
		{
			set{ _i_state=value;}
			get{return _i_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		/// <summary>
		/// 内线
		/// </summary>
		public string vc_telphone1
		{
			set{ _vc_telphone1=value;}
			get{return _vc_telphone1;}
		}
		/// <summary>
		/// 固话
		/// </summary>
		public string vc_telphone2
		{
			set{ _vc_telphone2=value;}
			get{return _vc_telphone2;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string vc_email
		{
			set{ _vc_email=value;}
			get{return _vc_email;}
		}
		/// <summary>
		/// 职称
		/// </summary>
		public string vc_professionaltitle
		{
			set{ _vc_professionaltitle=value;}
			get{return _vc_professionaltitle;}
		}
		/// <summary>
		/// 毕业时间
		/// </summary>
		public DateTime? vc_graduatedate
		{
			set{ _vc_graduatedate=value;}
			get{return _vc_graduatedate;}
		}
		/// <summary>
		/// 转正日期
		/// </summary>
		public DateTime? vc_becomesdate
		{
			set{ _vc_becomesdate=value;}
			get{return _vc_becomesdate;}
		}
		/// <summary>
		/// 参保日期
		/// </summary>
		public DateTime? vc_ginsengprotectdate
		{
			set{ _vc_ginsengprotectdate=value;}
			get{return _vc_ginsengprotectdate;}
		}
		/// <summary>
		/// 最后劳动合同期限
		/// </summary>
		public DateTime? vc_labourcontractdate
		{
			set{ _vc_labourcontractdate=value;}
			get{return _vc_labourcontractdate;}
		}
		/// <summary>
		/// 户籍地址
		/// </summary>
		public string vc_permanentaddress
		{
			set{ _vc_permanentaddress=value;}
			get{return _vc_permanentaddress;}
		}
		/// <summary>
		/// 日报统计
		/// </summary>
		public string vc_qq
		{
			set{ _vc_qq=value;}
			get{return _vc_qq;}
		}
		/// <summary>
		/// 周报统计
		/// </summary>
		public string vc_bloodtype
		{
			set{ _vc_bloodtype=value;}
			get{return _vc_bloodtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] b_iris_l
		{
			set{ _b_iris_l=value;}
			get{return _b_iris_l;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] b_iris_r
		{
			set{ _b_iris_r=value;}
			get{return _b_iris_r;}
		}
		/// <summary>
		/// 离职日期
		/// </summary>
		public DateTime? vc_Departuredate
		{
			set{ _vc_departuredate=value;}
			get{return _vc_departuredate;}
		}
		/// <summary>
		/// 所属公司
		/// </summary>
		public string vc_Company
		{
			set{ _vc_company=value;}
			get{return _vc_company;}
		}
		/// <summary>
		/// 商业保险开始时间
		/// </summary>
		public DateTime? vc_businessstart
		{
			set{ _vc_businessstart=value;}
			get{return _vc_businessstart;}
		}
		/// <summary>
		/// 商业保险结束时间
		/// </summary>
		public DateTime? vc_businessend
		{
			set{ _vc_businessend=value;}
			get{return _vc_businessend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_changetime
		{
			set{ _vc_changetime=value;}
			get{return _vc_changetime;}
		}
		/// <summary>
		/// 归属地
		/// </summary>
		public string vc_attribution
		{
			set{ _vc_attribution=value;}
			get{return _vc_attribution;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_busystate
		{
			set{ _vc_busystate=value;}
			get{return _vc_busystate;}
		}
		#endregion Model

	}
}

