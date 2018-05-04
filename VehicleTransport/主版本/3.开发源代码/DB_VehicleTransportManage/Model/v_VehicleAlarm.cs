/**  版本信息模板在安装目录下，可自行修改。
* v_VehicleAlarm.cs
*
* 功 能： N/A
* 类 名： v_VehicleAlarm
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/1 11:16:05   N/A    初版
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
	/// v_VehicleAlarm:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_VehicleAlarm
	{
		public v_VehicleAlarm()
		{}
		#region Model
		private int _id;
		private int? _i_alarmtype;
		private int? _planid;
		private int? _vehicleid;
		private int? _i_isprealarm;
		private DateTime? _dt_start;
		private DateTime? _dt_end;
		private string _vc_memo;
		private int? _i_flag;
		private string _vc_name;
		private string _vc_code;
		private string _vc_plancode;
		private DateTime? _dt_lastmaintaindatetime;
		private DateTime? _dt_scrapdatetime;
		private int? _i_maintaininterval;
		private string _localizerstationname;
		private string _applydepartmentname;
		private string _checkpersonname;
		private string _plangivecardepartmentname;
		private DateTime? _dt_plangivecardatetime;
		private string _planloaddepartmentname;
		private DateTime? _dt_planloaddatetime;
		private string _arrivedestinationaddressname;
		private DateTime? _dt_arrivedestinationdatetime;
		private string _planbackdepartmentname;
		private DateTime? _dt_planbackdatetime;
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
		/// <summary>
		/// 
		/// </summary>
		public string vc_Name
		{
			set{ _vc_name=value;}
			get{return _vc_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Code
		{
			set{ _vc_code=value;}
			get{return _vc_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_PlanCode
		{
			set{ _vc_plancode=value;}
			get{return _vc_plancode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_LastMaintainDateTIme
		{
			set{ _dt_lastmaintaindatetime=value;}
			get{return _dt_lastmaintaindatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_ScrapDateTime
		{
			set{ _dt_scrapdatetime=value;}
			get{return _dt_scrapdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_MaintainInterval
		{
			set{ _i_maintaininterval=value;}
			get{return _i_maintaininterval;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LocalizerStationName
		{
			set{ _localizerstationname=value;}
			get{return _localizerstationname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApplyDepartmentName
		{
			set{ _applydepartmentname=value;}
			get{return _applydepartmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckPersonName
		{
			set{ _checkpersonname=value;}
			get{return _checkpersonname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanGiveCarDepartmentName
		{
			set{ _plangivecardepartmentname=value;}
			get{return _plangivecardepartmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_PlanGiveCarDateTime
		{
			set{ _dt_plangivecardatetime=value;}
			get{return _dt_plangivecardatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanLoadDepartmentName
		{
			set{ _planloaddepartmentname=value;}
			get{return _planloaddepartmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_PlanLoadDateTime
		{
			set{ _dt_planloaddatetime=value;}
			get{return _dt_planloaddatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArriveDestinationAddressName
		{
			set{ _arrivedestinationaddressname=value;}
			get{return _arrivedestinationaddressname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_ArriveDestinationDateTime
		{
			set{ _dt_arrivedestinationdatetime=value;}
			get{return _dt_arrivedestinationdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanBackDepartmentName
		{
			set{ _planbackdepartmentname=value;}
			get{return _planbackdepartmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_PlanBackDateTime
		{
			set{ _dt_planbackdatetime=value;}
			get{return _dt_planbackdatetime;}
		}
		#endregion Model

	}
}

