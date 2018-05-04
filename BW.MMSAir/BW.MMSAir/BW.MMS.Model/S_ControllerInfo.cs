/**  版本信息模板在安装目录下，可自行修改。
* S_ControllerInfo.cs
*
* 功 能： N/A
* 类 名： S_ControllerInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/24 15:57:18   N/A    初版
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
	/// S_ControllerInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class S_ControllerInfo
	{
		public S_ControllerInfo()
		{}
		#region Model
		private int _id;
		private string _controlname;
		private string _systemlabel;
		private string _description;
		private string _area;
		private bool _enable;
		private string _channelname;
		private string _controlleraddress;
		private string _ipaddress;
		private string _port;
		private string _macaddress;
		private string _username;
		private string _password;
		private string _devicelabel;
		private string _devicecode;
		private int? _opcrate;
		private int? _opctimebias;
		private decimal? _opcdeadband;
		private string _opclcid;
		private int? _inchannel;
		private int? _outchannel;
		private int? _operlevel;
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
		public string SystemLabel
		{
			set{ _systemlabel=value;}
			get{return _systemlabel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
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
		public bool Enable
		{
			set{ _enable=value;}
			get{return _enable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChannelName
		{
			set{ _channelname=value;}
			get{return _channelname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ControllerAddress
		{
			set{ _controlleraddress=value;}
			get{return _controlleraddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IPaddress
		{
			set{ _ipaddress=value;}
			get{return _ipaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Port
		{
			set{ _port=value;}
			get{return _port;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MacAddress
		{
			set{ _macaddress=value;}
			get{return _macaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
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
		public int? OPCRate
		{
			set{ _opcrate=value;}
			get{return _opcrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OPCTimeBias
		{
			set{ _opctimebias=value;}
			get{return _opctimebias;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OPCDeadBand
		{
			set{ _opcdeadband=value;}
			get{return _opcdeadband;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OPCLcid
		{
			set{ _opclcid=value;}
			get{return _opclcid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? InChannel
		{
			set{ _inchannel=value;}
			get{return _inchannel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OutChannel
		{
			set{ _outchannel=value;}
			get{return _outchannel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OperLevel
		{
			set{ _operlevel=value;}
			get{return _operlevel;}
		}
		#endregion Model

	}
}

