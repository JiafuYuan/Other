using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// v_ArrayClassEntity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_ArrayClassEntity
	{
		public v_ArrayClassEntity()
		{}
		#region Model
		private int _id;
		private DateTime _dt_date;
		private int _deptid;
		private string _deptname;
		private int _classid;
		private string _classname;
		private string _vc_memo;
		private int? _i_flag;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dt_Date
		{
			set{ _dt_date=value;}
			get{return _dt_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptName
		{
			set{ _deptname=value;}
			get{return _deptname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ClassID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ClassName
		{
			set{ _classname=value;}
			get{return _classname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
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

