﻿using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// 风量历史数据表
	/// </summary>
	[Serializable]
	public partial class Data_History_Wind_YYYY_MMEntity
	{
		public Data_History_Wind_YYYY_MMEntity()
		{}
		#region Model
		private int _id;
		private DateTime _dt_datetime;
		private int? _sensorid;
		private decimal? _f_traffic;
		private decimal? _f_cumulativetraffic;
		private decimal? _f_temperature;
		private decimal? _f_pressure;
		private int? _areaid;
		private int? _deptid;
		private string _vc_memo;
		private int? _i_flag;
		private DateTime? _dt_now;
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
		public DateTime dt_DateTime
		{
			set{ _dt_datetime=value;}
			get{return _dt_datetime;}
		}
		/// <summary>
		/// 传感器标识
		/// </summary>
		public int? SensorID
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
		/// 所属区域
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 使用单位
		/// </summary>
		public int? DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
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
		/// <summary>
		/// 数据时间
		/// </summary>
		public DateTime? dt_Now
		{
			set{ _dt_now=value;}
			get{return _dt_now;}
		}
		#endregion Model

	}
}
