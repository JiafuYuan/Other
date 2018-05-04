using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 系统异常日志表
	/// </summary>
	[Serializable]
	public partial class sys_ErrorLogEntity
	{
		public sys_ErrorLogEntity()
		{}
		#region Model
		private string _vc_message;
		private string _vc_source;
		private string _stacktrace;
		private int? _oprationpersonid;
		private DateTime _dt_datatime;
		private string _vc_memo;
		private int? _i_flag;
		/// <summary>
		/// 错误消息
		/// </summary>
		public string vc_Message
		{
			set{ _vc_message=value;}
			get{return _vc_message;}
		}
		/// <summary>
		/// 来源
		/// </summary>
		public string vc_Source
		{
			set{ _vc_source=value;}
			get{return _vc_source;}
		}
		/// <summary>
		/// 堆栈路径
		/// </summary>
		public string StackTrace
		{
			set{ _stacktrace=value;}
			get{return _stacktrace;}
		}
		/// <summary>
		/// 操作人
		/// </summary>
		public int? OprationPersonID
		{
			set{ _oprationpersonid=value;}
			get{return _oprationpersonid;}
		}
		/// <summary>
		/// 日志时间
		/// </summary>
		public DateTime dt_DataTime
		{
			set{ _dt_datatime=value;}
			get{return _dt_datatime;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		/// <summary>
		/// i_Flag
		/// </summary>
		public int? i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		#endregion Model

	}
}

