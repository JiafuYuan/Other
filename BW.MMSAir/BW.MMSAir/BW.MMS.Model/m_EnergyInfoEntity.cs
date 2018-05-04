using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 能效信息表
	/// </summary>
	[Serializable]
	public partial class m_EnergyInfoEntity
	{
		public m_EnergyInfoEntity()
		{}
		#region Model
		private int _id;
		private DateTime _dt_date;
		private int _deptid;
		private decimal? _f_rateenergy;
		private decimal? _f_realenergy;
		private decimal? _f_production;
		private decimal? _f_netproduction;
		private decimal? _f_energy;
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
		/// 额定能效
		/// </summary>
		public decimal? f_RateEnergy
		{
			set{ _f_rateenergy=value;}
			get{return _f_rateenergy;}
		}
		/// <summary>
		/// 实际能效
		/// </summary>
		public decimal? f_RealEnergy
		{
			set{ _f_realenergy=value;}
			get{return _f_realenergy;}
		}
		/// <summary>
		/// 产量
		/// </summary>
		public decimal? f_Production
		{
			set{ _f_production=value;}
			get{return _f_production;}
		}
		/// <summary>
		/// 净产量
		/// </summary>
		public decimal? f_NetProduction
		{
			set{ _f_netproduction=value;}
			get{return _f_netproduction;}
		}
		/// <summary>
		/// 能耗
		/// </summary>
		public decimal? f_Energy
		{
			set{ _f_energy=value;}
			get{return _f_energy;}
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

