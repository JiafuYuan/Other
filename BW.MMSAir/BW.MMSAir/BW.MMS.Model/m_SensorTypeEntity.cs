using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 传感器类型表
	/// </summary>
	[Serializable]
	public partial class m_SensorTypeEntity
	{
		public m_SensorTypeEntity()
		{}
		#region Model
		private int _id;
		private string _vc_code;
		private string _vc_name;
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
		/// 类型编号
		/// </summary>
		public string vc_Code
		{
			set{ _vc_code=value;}
			get{return _vc_code;}
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string vc_Name
		{
			set{ _vc_name=value;}
			get{return _vc_name;}
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

