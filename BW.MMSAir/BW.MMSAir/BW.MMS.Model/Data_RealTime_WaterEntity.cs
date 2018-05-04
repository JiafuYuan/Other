using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 水量实时数据表
	/// </summary>
	[Serializable]
	public partial class Data_RealTime_WaterEntity
	{
		public Data_RealTime_WaterEntity()
		{}
		#region Model
		private int _id;
		private int _sensorid;
		private decimal? _f_instantaneousvelocity;
		private decimal? _f_instantaneousflowrate;
		private decimal? _f_pluscumulativeflowrate;
		private decimal? _f_minuscumulativeflowrate;
		private DateTime? _f_integratingruntime;
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
		/// 传感器标识
		/// </summary>
		public int SensorID
		{
			set{ _sensorid=value;}
			get{return _sensorid;}
		}
		/// <summary>
		/// 瞬时流速
		/// </summary>
		public decimal? f_InstantaneousVelocity
		{
			set{ _f_instantaneousvelocity=value;}
			get{return _f_instantaneousvelocity;}
		}
		/// <summary>
		/// 瞬时流量
		/// </summary>
		public decimal? f_InstantaneousFlowrate
		{
			set{ _f_instantaneousflowrate=value;}
			get{return _f_instantaneousflowrate;}
		}
		/// <summary>
		/// 正累计流量
		/// </summary>
		public decimal? f_PlusCumulativeFlowrate
		{
			set{ _f_pluscumulativeflowrate=value;}
			get{return _f_pluscumulativeflowrate;}
		}
		/// <summary>
		/// 负累计流量
		/// </summary>
		public decimal? f_MinusCumulativeFlowrate
		{
			set{ _f_minuscumulativeflowrate=value;}
			get{return _f_minuscumulativeflowrate;}
		}
		/// <summary>
		/// 累计运行时间
		/// </summary>
		public DateTime? f_IntegratingRunTime
		{
			set{ _f_integratingruntime=value;}
			get{return _f_integratingruntime;}
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

