using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 产量实时数据表
	/// </summary>
	[Serializable]
	public partial class Data_RealTime_ProductionEntity
	{
		public Data_RealTime_ProductionEntity()
		{}
		#region Model
		private int _id;
		private int _sensorid;
		private decimal? _f_instantaneousflowrate;
		private decimal? _f_cumulativetraffic;
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
		/// 瞬时流量
		/// </summary>
		public decimal? f_InstantaneousFlowrate
		{
			set{ _f_instantaneousflowrate=value;}
			get{return _f_instantaneousflowrate;}
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

