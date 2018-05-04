using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// Grid配置
	/// </summary>
	[Serializable]
	public partial class sys_GridConfigEntity
	{
		public sys_GridConfigEntity()
		{}
		#region Model
		private int _id;
		private string _vc_gridkey;
		private string _vc_gridname;
		private string _vc_field;
		private bool _ischk;
		private string _vc_tablename;
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
		/// Grid标识
		/// </summary>
		public string vc_GridKey
		{
			set{ _vc_gridkey=value;}
			get{return _vc_gridkey;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string vc_GridName
		{
			set{ _vc_gridname=value;}
			get{return _vc_gridname;}
		}
		/// <summary>
		/// 标识/主键
		/// </summary>
		public string vc_Field
		{
			set{ _vc_field=value;}
			get{return _vc_field;}
		}
		/// <summary>
		/// 是否显示复选框
		/// </summary>
		public bool IsChk
		{
			set{ _ischk=value;}
			get{return _ischk;}
		}
		/// <summary>
		/// 表名或视图
		/// </summary>
		public string vc_TableName
		{
			set{ _vc_tablename=value;}
			get{return _vc_tablename;}
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

