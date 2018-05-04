using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 产量计划
	/// </summary>
	[Serializable]
	public partial class m_ProductionPlanEntity
	{
		public m_ProductionPlanEntity()
		{}
		#region Model
		private int _id;
		private int? _deptid;
		private int? _years;
		private decimal? _jan;
		private decimal? _feb;
		private decimal? _mar;
		private decimal? _apr;
		private decimal? _may;
		private decimal? _jun;
		private decimal? _jul;
		private decimal? _aug;
		private decimal? _sep;
		private decimal? _oct;
		private decimal? _nov;
		private decimal? _dec;
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
		public int? DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Years
		{
			set{ _years=value;}
			get{return _years;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Jan
		{
			set{ _jan=value;}
			get{return _jan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Feb
		{
			set{ _feb=value;}
			get{return _feb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Mar
		{
			set{ _mar=value;}
			get{return _mar;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Apr
		{
			set{ _apr=value;}
			get{return _apr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? May
		{
			set{ _may=value;}
			get{return _may;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Jun
		{
			set{ _jun=value;}
			get{return _jun;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Jul
		{
			set{ _jul=value;}
			get{return _jul;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Aug
		{
			set{ _aug=value;}
			get{return _aug;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Sep
		{
			set{ _sep=value;}
			get{return _sep;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Oct
		{
			set{ _oct=value;}
			get{return _oct;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Nov
		{
			set{ _nov=value;}
			get{return _nov;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Dec
		{
			set{ _dec=value;}
			get{return _dec;}
		}
		#endregion Model

	}
}

