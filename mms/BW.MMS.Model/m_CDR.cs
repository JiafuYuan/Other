using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// m_CDR:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_CDR
	{
		public m_CDR()
		{}
		#region Model
		private int _id;
		private string _vc_callingnum;
		private string _vc_callednum;
		private DateTime? _dt_setuptime;
		private DateTime? _dt_connecttime;
		private DateTime? _dt_answertime;
		private DateTime? _dt_disconnecttime;
		private DateTime? _dt_remotedisconnectime;
		private long? _i_duration;
		private string _vc_hostip;
		private string _vc_visitip;
		private int? _i_rpc;
		private int? _i_rpno;
		private int? _i_serviceprovider;
		private int? _i_calltype;
		private int? _i_talktype;
		private long? _i_chargevalue;
		private string _vc_memo;
		private int? _i_flag=0;
		private string _vc_path;
		private string _vc_recpath;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 主叫号码
		/// </summary>
		public string vc_CallingNum
		{
			set{ _vc_callingnum=value;}
			get{return _vc_callingnum;}
		}
		/// <summary>
		/// 被叫号码
		/// </summary>
		public string vc_CalledNum
		{
			set{ _vc_callednum=value;}
			get{return _vc_callednum;}
		}
		/// <summary>
		/// 发起时间
		/// </summary>
		public DateTime? dt_SetupTime
		{
			set{ _dt_setuptime=value;}
			get{return _dt_setuptime;}
		}
		/// <summary>
		/// 连接时间
		/// </summary>
		public DateTime? dt_ConnectTime
		{
			set{ _dt_connecttime=value;}
			get{return _dt_connecttime;}
		}
		/// <summary>
		/// 应答时间
		/// </summary>
		public DateTime? dt_AnswerTime
		{
			set{ _dt_answertime=value;}
			get{return _dt_answertime;}
		}
		/// <summary>
		/// 挂断时间
		/// </summary>
		public DateTime? dt_DisconnectTime
		{
			set{ _dt_disconnecttime=value;}
			get{return _dt_disconnecttime;}
		}
		/// <summary>
		/// 对端挂断时间
		/// </summary>
		public DateTime? dt_RemoteDisconnecTime
		{
			set{ _dt_remotedisconnectime=value;}
			get{return _dt_remotedisconnectime;}
		}
		/// <summary>
		/// 呼叫时长
		/// </summary>
		public long? i_Duration
		{
			set{ _i_duration=value;}
			get{return _i_duration;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_HostIP
		{
			set{ _vc_hostip=value;}
			get{return _vc_hostip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_VisitIP
		{
			set{ _vc_visitip=value;}
			get{return _vc_visitip;}
		}
		/// <summary>
		/// 预留字段，暂不用
		/// </summary>
		public int? i_rpc
		{
			set{ _i_rpc=value;}
			get{return _i_rpc;}
		}
		/// <summary>
		/// 预留字段，暂不用
		/// </summary>
		public int? i_rpno
		{
			set{ _i_rpno=value;}
			get{return _i_rpno;}
		}
		/// <summary>
		/// 运营商，1移动，2联通，3电信
		/// </summary>
		public int? i_ServiceProvider
		{
			set{ _i_serviceprovider=value;}
			get{return _i_serviceprovider;}
		}
		/// <summary>
		/// 呼叫类型，本地主叫0，漫游主叫1，本地被叫2，漫游被叫3，本地数据4，漫游数据5
		/// </summary>
		public int? i_CallType
		{
			set{ _i_calltype=value;}
			get{return _i_calltype;}
		}
		/// <summary>
		/// 通话类型，网内通话，市话，国内长途，国际长途，漫游
		/// </summary>
		public int? i_TalkType
		{
			set{ _i_talktype=value;}
			get{return _i_talktype;}
		}
		/// <summary>
		/// 费用
		/// </summary>
		public long? i_ChargeValue
		{
			set{ _i_chargevalue=value;}
			get{return _i_chargevalue;}
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
		public string vc_Path
		{
			set{ _vc_path=value;}
			get{return _vc_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_recPath
		{
			set{ _vc_recpath=value;}
			get{return _vc_recpath;}
		}
		#endregion Model

	}
}

