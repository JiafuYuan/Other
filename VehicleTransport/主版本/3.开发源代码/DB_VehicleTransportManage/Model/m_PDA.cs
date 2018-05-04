/**  版本信息模板在安装目录下，可自行修改。
* m_PDA.cs
*
* 功 能： N/A
* 类 名： m_PDA
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-11 11:08:33   N/A    初版
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
	/// m_PDA:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_PDA
	{
		public m_PDA()
		{}
		#region Model
		private int _id;
		private string _vc_macaddress;
        private string _vc_Code;
		private int? _i_state=0;
		private string _vc_memo;
		private int? _i_flag=0;
        private int? _departmentID = 0;
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
		public string vc_MacAddress
		{
			set{ _vc_macaddress=value;}
			get{return _vc_macaddress;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string vc_Code
        {
            set { _vc_Code = value; }
            get { return _vc_Code; }
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
        public int? DepartmentID
		{
            set { _departmentID = value; }
            get { return _departmentID; }
		}
		#endregion Model

	}
}

