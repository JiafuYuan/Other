using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 功能表
	/// </summary>
	[Serializable]
	public partial class sys_ActionEntity
	{
		public sys_ActionEntity()
		{}
		#region Model
		private int _id;
		private string _vc_actioncode;
		private string _vc_actionname;
		private int? _moduleid;
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
		/// 功能代码
		/// </summary>
		public string vc_ActionCode
		{
			set{ _vc_actioncode=value;}
			get{return _vc_actioncode;}
		}
		/// <summary>
		/// 功能名称
		/// </summary>
		public string vc_ActionName
		{
			set{ _vc_actionname=value;}
			get{return _vc_actionname;}
		}
		/// <summary>
		/// 所属模块
		/// </summary>
		public int? ModuleID
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
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

