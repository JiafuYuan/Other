using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 能耗类型表
	/// </summary>
	[Serializable]
	public partial class m_EnergyTypeEntity
	{
		public m_EnergyTypeEntity()
		{}
		#region Model
		private int _id;
		private string _vc_energytypename;
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
		/// 类型名称
		/// </summary>
		public string vc_EnergyTypeName
		{
			set{ _vc_energytypename=value;}
			get{return _vc_energytypename;}
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

