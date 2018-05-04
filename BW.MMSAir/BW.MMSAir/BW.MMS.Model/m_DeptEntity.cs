using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 使用单位
	/// </summary>
	[Serializable]
	public partial class m_DeptEntity
	{
		public m_DeptEntity()
		{}
		#region Model
		private int _id;
		private string _vc_code;
		private string _vc_name;
		private int? _parentdeptid;
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
		/// 部门编号
		/// </summary>
		public string vc_Code
		{
			set{ _vc_code=value;}
			get{return _vc_code;}
		}
		/// <summary>
		/// 部门名称
		/// </summary>
		public string vc_Name
		{
			set{ _vc_name=value;}
			get{return _vc_name;}
		}
		/// <summary>
		/// 父级部门
		/// </summary>
		public int? ParentDeptID
		{
			set{ _parentdeptid=value;}
			get{return _parentdeptid;}
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

