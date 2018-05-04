/**  版本信息模板在安装目录下，可自行修改。
* S_Point.cs
*
* 功 能： N/A
* 类 名： S_Point
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/9 17:32:49   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// S_Point:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class S_Point
	{
		public S_Point()
		{}
		#region Model
		private int _id;
		private string _controlname;
		private string _pointname;
		private string _pointaddress;
		private string _pointdescription;
		private int? _pointvaluetype;
		private int? _operlevel;
		private string _systemlabel;
		private string _unit;
		private string _associatevideo;
		private string _devicelabel;
		private string _devicecode;
		private string _area;
		private string _alarmform;
		private decimal? _latitudes;
		private decimal? _longitude;
		private bool _marker;
		private string _iconname;
		private bool _enable;
		private bool _readonly;
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
		public string ControlName
		{
			set{ _controlname=value;}
			get{return _controlname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PointName
		{
			set{ _pointname=value;}
			get{return _pointname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PointAddress
		{
			set{ _pointaddress=value;}
			get{return _pointaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PointDescription
		{
			set{ _pointdescription=value;}
			get{return _pointdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PointValueType
		{
			set{ _pointvaluetype=value;}
			get{return _pointvaluetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OperLevel
		{
			set{ _operlevel=value;}
			get{return _operlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SystemLabel
		{
			set{ _systemlabel=value;}
			get{return _systemlabel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Associatevideo
		{
			set{ _associatevideo=value;}
			get{return _associatevideo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeviceLabel
		{
			set{ _devicelabel=value;}
			get{return _devicelabel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeviceCode
		{
			set{ _devicecode=value;}
			get{return _devicecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AlarmForm
		{
			set{ _alarmform=value;}
			get{return _alarmform;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Latitudes
		{
			set{ _latitudes=value;}
			get{return _latitudes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Longitude
		{
			set{ _longitude=value;}
			get{return _longitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Marker
		{
			set{ _marker=value;}
			get{return _marker;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IconName
		{
			set{ _iconname=value;}
			get{return _iconname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool Enable
		{
			set{ _enable=value;}
			get{return _enable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ReadOnly
		{
			set{ _readonly=value;}
			get{return _readonly;}
		}
		#endregion Model

	}
}

