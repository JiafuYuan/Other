using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// m_Ash:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_AshEntity
	{
		public m_AshEntity()
		{}
		#region Model
		private decimal _id;
		private string _installationposition;
		private int? _i_flag=0;
		/// <summary>
		/// 
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InstallationPosition
		{
			set{ _installationposition=value;}
			get{return _installationposition;}
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

