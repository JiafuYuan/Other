/**  版本信息模板在安装目录下，可自行修改。
* data_VehicleAlarm.cs
*
* 功 能： N/A
* 类 名： data_VehicleAlarm
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-11 11:08:32   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace DB_VehicleTransportManage.Model
{
	/// <summary>
	/// data_VehicleAlarm:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class data_VehicleAlarm
	{
		public data_VehicleAlarm()
		{}
		#region Model
		private int _id;
		private int? _i_alarmtype;
		private int? _planid;
		private int? _vehicleid;
		private int? _i_isprealarm=1;
		private DateTime? _dt_start;
		private DateTime? _dt_end;
		private string _vc_memo;
		private int? _i_flag=0;
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
		public int? i_AlarmType
		{
			set{ _i_alarmtype=value;}
			get{return _i_alarmtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanID
		{
			set{ _planid=value;}
			get{return _planid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VehicleID
		{
			set{ _vehicleid=value;}
			get{return _vehicleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_IsPreAlarm
		{
			set{ _i_isprealarm=value;}
			get{return _i_isprealarm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_Start
		{
			set{ _dt_start=value;}
			get{return _dt_start;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_End
		{
			set{ _dt_end=value;}
			get{return _dt_end;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		#endregion Model

	}
}

