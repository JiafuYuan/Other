using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 风量实时数据表
	/// </summary>
	[Serializable]
	public partial class Data_RealTime_WindEntity
	{
		public Data_RealTime_WindEntity()
		{}
		#region Model
		private int _id;
		private int _sensorid;
		private decimal? _f_traffic;
		private decimal? _f_cumulativetraffic;
		private decimal? _f_temperature;
		private decimal? _f_pressure;
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
		/// 流量
		/// </summary>
		public decimal? f_Traffic
		{
			set{ _f_traffic=value;}
			get{return _f_traffic;}
		}
		/// <summary>
		/// 累积量
		/// </summary>
		public decimal? f_CumulativeTraffic
		{
			set{ _f_cumulativetraffic=value;}
			get{return _f_cumulativetraffic;}
		}
		/// <summary>
		/// 温度
		/// </summary>
		public decimal? f_Temperature
		{
			set{ _f_temperature=value;}
			get{return _f_temperature;}
		}
		/// <summary>
		/// 压力
		/// </summary>
		public decimal? f_Pressure
		{
			set{ _f_pressure=value;}
			get{return _f_pressure;}
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

