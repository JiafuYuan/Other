using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// m_AreaEntity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_AreaEntity
	{
		public m_AreaEntity()
		{}
		#region Model
		private int _id;
		private string _vc_code;
		private string _vc_name;
		private decimal? _point_x;
		private decimal? _point_y;
		private int _i_flag;
		private int? _i_parentid;
		private string _nvc_type;
		private int? _i_personcount;
		private string _vc_memo;
		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 编号
		/// </summary>
		public string vc_Code
		{
			set{ _vc_code=value;}
			get{return _vc_code;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string vc_Name
		{
			set{ _vc_name=value;}
			get{return _vc_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Point_X
		{
			set{ _point_x=value;}
			get{return _point_x;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Point_Y
		{
			set{ _point_y=value;}
			get{return _point_y;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		/// <summary>
		/// 父级区域
		/// </summary>
		public int? i_parentid
		{
			set{ _i_parentid=value;}
			get{return _i_parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nvc_Type
		{
			set{ _nvc_type=value;}
			get{return _nvc_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_personcount
		{
			set{ _i_personcount=value;}
			get{return _i_personcount;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		#endregion Model

	}
}

