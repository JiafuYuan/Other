/**  版本信息模板在安装目录下，可自行修改。
* v_PDA.cs
*
* 功 能： N/A
* 类 名： v_PDA
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/9 13:29:14   N/A    初版
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
	/// v_PDA:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_PDA
	{
		public v_PDA()
		{}
		#region Model
		private int _id;
		private int? _departmentid;
		private string _deptname;
		private string _usename;
		private int? _useno;
		private int? _wifibasestationid;
		private string _vc_macaddress;
		private int? _i_state;
		private int? _i_flag;
        private string _vc_code;

        public string vc_code
        {
            get { return _vc_code; }
            set { _vc_code = value; }
        }
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
		public int? DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string deptname
		{
			set{ _deptname=value;}
			get{return _deptname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string usename
		{
			set{ _usename=value;}
			get{return _usename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? useno
		{
			set{ _useno=value;}
			get{return _useno;}
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
		public string vc_MacAddress
		{
			set{ _vc_macaddress=value;}
			get{return _vc_macaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_State
		{
			set{ _i_state=value;}
			get{return _i_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		#endregion Model

	}
}

