using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 排班表
	/// </summary>
	[Serializable]
	public partial class m_ArrayClassEntity
	{
		public m_ArrayClassEntity()
		{}
		#region Model
		private int _id;
		private DateTime _dt_date;
		private int _deptid;
		private int _classid;
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
		/// 日期
		/// </summary>
		public DateTime dt_Date
		{
			set{ _dt_date=value;}
			get{return _dt_date;}
		}
		/// <summary>
		/// 使用单位
		/// </summary>
		public int DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 班次
		/// </summary>
		public int ClassID
		{
			set{ _classid=value;}
			get{return _classid;}
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

