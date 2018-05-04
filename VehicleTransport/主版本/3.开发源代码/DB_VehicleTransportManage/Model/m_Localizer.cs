/**  版本信息模板在安装目录下，可自行修改。
* m_Localizer.cs
*
* 功 能： N/A
* 类 名： m_Localizer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/12 13:23:06   N/A    初版
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
	/// m_Localizer:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_Localizer
	{
		public m_Localizer()
		{}
		#region Model
		private int _id;
		private int _areaid;
		private int _i_hid;
		private int _i_parenthid;
		private int? _i_type;
		private string _vc_code;
		private string _vc_name;
		private string _vc_memo;
		private int _i_flag=0;
		
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
		public int AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_HID
		{
			set{ _i_hid=value;}
			get{return _i_hid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_ParentHID
		{
			set{ _i_parenthid=value;}
			get{return _i_parenthid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_Type
		{
			set{ _i_type=value;}
			get{return _i_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Code
		{
			set{ _vc_code=value;}
			get{return _vc_code;}
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
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		
		#endregion Model

	}
}

