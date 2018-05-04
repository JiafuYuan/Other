using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 告警类型表
	/// </summary>
	[Serializable]
	public partial class m_AlarmTypeEntity
	{
		public m_AlarmTypeEntity()
		{}
		#region Model
		private int _id;
		private int _alarmtypeid;
		private string _vc_alarmname;
		private string _vc_description;
		private string _vc_memo;
		private int _i_flag;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 告警编号
		/// </summary>
		public int AlarmTypeID
		{
			set{ _alarmtypeid=value;}
			get{return _alarmtypeid;}
		}
		/// <summary>
		/// 告警名称
		/// </summary>
		public string vc_AlarmName
		{
			set{ _vc_alarmname=value;}
			get{return _vc_alarmname;}
		}
		/// <summary>
		/// 告警描述
		/// </summary>
		public string vc_Description
		{
			set{ _vc_description=value;}
			get{return _vc_description;}
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
		public int i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		#endregion Model

	}
}

