using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 负荷数据表
	/// </summary>
	[Serializable]
	public partial class Data_RatedLoadEntity
	{
		public Data_RatedLoadEntity()
		{}
		#region Model
		private int _id;
		private int? _areaid;
		private decimal? _f_ratedload;
		private decimal? _f_realload;
		private DateTime? _dt_datetime;
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
		/// 区域
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 额定负荷
		/// </summary>
		public decimal? f_RatedLoad
		{
			set{ _f_ratedload=value;}
			get{return _f_ratedload;}
		}
		/// <summary>
		/// 当前负荷
		/// </summary>
		public decimal? f_RealLoad
		{
			set{ _f_realload=value;}
			get{return _f_realload;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime? dt_DateTime
		{
			set{ _dt_datetime=value;}
			get{return _dt_datetime;}
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

