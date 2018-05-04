using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 实时告警数据表
	/// </summary>
	[Serializable]
	public partial class Alarm_CurrentEntity
	{
		public Alarm_CurrentEntity()
		{}
		#region Model
		private int _id;
		private int? _alarmtypeid;
		private int? _areaid;
		private string _vc_address;
		private DateTime? _dt_begintime;
		private string _vc_alarmreason;
		private string _vc_unalarmplan;
		private int? _deptid;
		private string _vc_deptname;
		private int? _personid;
		private string _vc_personnmae;
		private string _vc_memo;
		private int? _i_flag;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 告警类型
		/// </summary>
        public int? AlarmTypeID
		{
			set{ _alarmtypeid=value;}
			get{return _alarmtypeid;}
		}
		/// <summary>
		/// 告警区域
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 告警地点
		/// </summary>
		public string vc_Address
		{
			set{ _vc_address=value;}
			get{return _vc_address;}
		}
		/// <summary>
		/// 告警开始时间
		/// </summary>
		public DateTime? dt_BeginTime
		{
			set{ _dt_begintime=value;}
			get{return _dt_begintime;}
		}
		/// <summary>
		/// 告警原因
		/// </summary>
		public string vc_AlarmReason
		{
			set{ _vc_alarmreason=value;}
			get{return _vc_alarmreason;}
		}
		/// <summary>
		/// 处理方案
		/// </summary>
		public string vc_UnAlarmPlan
		{
			set{ _vc_unalarmplan=value;}
			get{return _vc_unalarmplan;}
		}
		/// <summary>
		/// 责任部门ID
		/// </summary>
		public int? DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 责任部门名称
		/// </summary>
		public string vc_DeptName
		{
			set{ _vc_deptname=value;}
			get{return _vc_deptname;}
		}
		/// <summary>
		/// 责任人ID
		/// </summary>
		public int? PersonID
		{
			set{ _personid=value;}
			get{return _personid;}
		}
		/// <summary>
		/// 责任人名称
		/// </summary>
		public string vc_PersonNmae
		{
			set{ _vc_personnmae=value;}
			get{return _vc_personnmae;}
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

