using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 电量实时数据表
	/// </summary>
	[Serializable]
	public partial class Data_RealTime_PowerEntity
	{
		public Data_RealTime_PowerEntity()
		{}
		#region Model
		private int _id;
		private int _sensorid;
		private decimal? _f_currentpower;
		private decimal? _f_cumulativepower;
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
		/// 当前电量
		/// </summary>
		public decimal? f_CurrentPower
		{
			set{ _f_currentpower=value;}
			get{return _f_currentpower;}
		}
		/// <summary>
		/// 累积量
		/// </summary>
		public decimal? f_CumulativePower
		{
			set{ _f_cumulativepower=value;}
			get{return _f_cumulativepower;}
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

