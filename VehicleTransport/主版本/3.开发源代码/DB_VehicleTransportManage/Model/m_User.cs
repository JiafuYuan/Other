/**  版本信息模板在安装目录下，可自行修改。
* m_User.cs
*
* 功 能： N/A
* 类 名： m_User
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-11 11:08:37   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace DB_VehicleTransportManage.Model
{
	/// <summary>
	/// m_User:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_User
	{
		public m_User()
		{}
		#region Model
		private int _id;
		private string _vc_name;
		private string _vc_password;
		private int? _personid;
		private int? _departmentid;
		private int? _ruleid;
		private int? _i_ispda=0;
		private DateTime? _dt_createtime;
		private int? _pdaid;
		private int? _wifibasestationid;
		private string _vc_memo;
		private int? _i_flag=0;
	    private int? _i_IdentificationCardHID = 0;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Name
		{
			set{ _vc_name=value;}
			get{return _vc_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Password
		{
			set{ _vc_password=value;}
			get{return _vc_password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PersonID
		{
			set{ _personid=value;}
			get{return _personid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RuleID
		{
			set{ _ruleid=value;}
			get{return _ruleid;}
		}
		/// <summary>
		/// 
		///
		/// </summary>
		public int? i_IsPDA
		{
			set{ _i_ispda=value;}
			get{return _i_ispda;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_CreateTime
		{
			set{ _dt_createtime=value;}
			get{return _dt_createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PdaID
		{
			set{ _pdaid=value;}
			get{return _pdaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? WifiBaseStationID
		{
			set{ _wifibasestationid=value;}
			get{return _wifibasestationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}

        /// <summary>
        /// 
        /// </summary>
        public int? i_IdentificationCardHID
        {
            set { _i_IdentificationCardHID = value; }
            get { return _i_IdentificationCardHID; }
        }
		#endregion Model

        public DateTime dt_LastActiveDateTime { get; set; }

        /// <summary>
        /// 1为登录0为正常
        /// </summary>
        public int i_State { get; set; }

        public string vc_IP { get; set; }

        public int i_Port { get; set; }
	}
}

