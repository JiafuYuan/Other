using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// GridColumn配置
	/// </summary>
	[Serializable]
	public partial class sys_GridColumnConfigEntity
	{
		public sys_GridColumnConfigEntity()
		{}
		#region Model
		private int _id;
		private int _gridid;
		private string _title;
		private string _field;
		private int? _width;
		private string _align;
		private bool _sortable;
		private int? _displayorder;
		private bool _hidden;
		private int? _colspan;
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
		/// Grid编号
		/// </summary>
		public int GridId
		{
			set{ _gridid=value;}
			get{return _gridid;}
		}
		/// <summary>
		/// 列名
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 字段
		/// </summary>
		public string Field
		{
			set{ _field=value;}
			get{return _field;}
		}
		/// <summary>
		/// 宽度
		/// </summary>
		public int? Width
		{
			set{ _width=value;}
			get{return _width;}
		}
		/// <summary>
		/// 对齐方式
		/// </summary>
		public string Align
		{
			set{ _align=value;}
			get{return _align;}
		}
		/// <summary>
		/// 是否排序
		/// </summary>
		public bool Sortable
		{
			set{ _sortable=value;}
			get{return _sortable;}
		}
		/// <summary>
		/// 显示顺序
		/// </summary>
		public int? DisplayOrder
		{
			set{ _displayorder=value;}
			get{return _displayorder;}
		}
		/// <summary>
		/// 是否隐藏
		/// </summary>
		public bool Hidden
		{
			set{ _hidden=value;}
			get{return _hidden;}
		}
		/// <summary>
		/// 合并列
		/// </summary>
		public int? Colspan
		{
			set{ _colspan=value;}
			get{return _colspan;}
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

