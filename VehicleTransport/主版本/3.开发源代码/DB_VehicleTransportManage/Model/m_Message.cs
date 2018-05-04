/**  版本信息模板在安装目录下，可自行修改。
* m_Message.cs
*
* 功 能： N/A
* 类 名： m_Message
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/29 11:29:39   N/A    初版
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
	/// m_Message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_Message
	{
		public m_Message()
		{}
		#region Model
		private int _id;
		private int? _planid;
		private int? _i_messagetype;
		private int? _fromuserid;
		private int? _touserid;
		private string _vc_message;
		private DateTime? _dt_senddatetime;
		private DateTime? _dt_receivedatetime;
		private string _vc_memo;
		private int? _i_flag=0;
		private int? _i_state;
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
		public int? PlanID
		{
			set{ _planid=value;}
			get{return _planid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_MessageType
		{
			set{ _i_messagetype=value;}
			get{return _i_messagetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FromUserID
		{
			set{ _fromuserid=value;}
			get{return _fromuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ToUserID
		{
			set{ _touserid=value;}
			get{return _touserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Message
		{
			set{ _vc_message=value;}
			get{return _vc_message;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_SendDateTime
		{
			set{ _dt_senddatetime=value;}
			get{return _dt_senddatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_ReceiveDateTime
		{
			set{ _dt_receivedatetime=value;}
			get{return _dt_receivedatetime;}
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
		public int? i_State
		{
			set{ _i_state=value;}
			get{return _i_state;}
		}
		#endregion Model

	}
}

