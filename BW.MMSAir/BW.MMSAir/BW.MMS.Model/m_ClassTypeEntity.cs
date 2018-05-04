using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// m_ClassTypeEntity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_ClassTypeEntity
	{
		public m_ClassTypeEntity()
		{}
		#region Model
		private int _id;
		private string _nvc_name;
		private string _nvc_shortname;
		private string _nvc_descripe;
		private string _nvc_remark;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string nvc_name
		{
			set{ _nvc_name=value;}
			get{return _nvc_name;}
		}
		/// <summary>
		/// 简称
		/// </summary>
		public string nvc_shortname
		{
			set{ _nvc_shortname=value;}
			get{return _nvc_shortname;}
		}
		/// <summary>
		/// 表现形式
		/// </summary>
		public string nvc_descripe
		{
			set{ _nvc_descripe=value;}
			get{return _nvc_descripe;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string nvc_remark
		{
			set{ _nvc_remark=value;}
			get{return _nvc_remark;}
		}
		#endregion Model

	}
}

