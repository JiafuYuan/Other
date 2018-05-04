/**  版本信息模板在安装目录下，可自行修改。
* m_SystemLog.cs
*
* 功 能： N/A
* 类 名： m_SystemLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-11 11:08:36   N/A    初版
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
	/// m_SystemLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_SystemLog
	{
		public m_SystemLog()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private int? _i_actiontype;
		private string _vc_title;
		private string _vc_description;
		private DateTime? _dt_datetime;
		private string _vc_memo;
		private int? _i_flag=0;
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
		public int? UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_ActionType
		{
			set{ _i_actiontype=value;}
			get{return _i_actiontype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Title
		{
			set{ _vc_title=value;}
			get{return _vc_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Description
		{
			set{ _vc_description=value;}
			get{return _vc_description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_DateTime
		{
			set{ _dt_datetime=value;}
			get{return _dt_datetime;}
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
		#endregion Model

	}
}

