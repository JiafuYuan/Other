using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// m_ClassEntity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_ClassEntity
	{
		public m_ClassEntity()
		{}
		#region Model
		private int _id;
		private int? _classtypeid;
		private string _nvc_name;
		private string _nvc_shortname;
		private string _d_start;
		private string _d_end;
		private string _nvc_descripe;
		private string _nvc_remark;
		/// <summary>
		/// 编号
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 班次类型
		/// </summary>
		public int? classTypeID
		{
			set{ _classtypeid=value;}
			get{return _classtypeid;}
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
		/// 开始时间
		/// </summary>
		public string d_start
		{
			set{ _d_start=value;}
			get{return _d_start;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public string d_End
		{
			set{ _d_end=value;}
			get{return _d_end;}
		}
		/// <summary>
		/// 表示形式
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

