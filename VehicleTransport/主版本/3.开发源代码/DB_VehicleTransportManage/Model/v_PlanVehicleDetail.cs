/**  版本信息模板在安装目录下，可自行修改。
* v_PlanVehicleDetail.cs
*
* 功 能： N/A
* 类 名： v_PlanVehicleDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-10-30 10:51:35   N/A    初版
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
	/// v_PlanVehicleDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_PlanVehicleDetail
	{
		public v_PlanVehicleDetail()
		{}
		#region Model
		private int _vehicleid;
		private string _vc_code;
		private string _vehiclename;
		private int _vehicletypeid;
		private int _departmentid;
		private int _vehiclestate;
		private int? _i_safeload;
		private int _i_localizerstationid;
		private DateTime _dt_inlocalizerstationdatetime;
		private int? _i_maintaininterval;
		private DateTime? _dt_scrapdatetime;
		private DateTime _dt_createdatetime;
		private DateTime _dt_lastmaintaindatetime;
		private string _vc_memo;
		private int? _i_flag;
		private int _planid;
		private DateTime? _dt_arrivedestinationdatetime;
		private int? _arrivedestinationaddressid;
		private int? _planstate;
		private int? _applyid;
		private int? _i_istemplan;
		private string _vc_plancode;
		private int? _checkpersonid;
		private DateTime? _dt_checkdatetime;
		private int? _plangivecardepartmentid;
		private DateTime? _dt_plangivecardatetime;
		private int? _plangivecaraddressid;
		private int? _planunloaddepartmentid;
		private int? _planbackdepartmentid;
		private DateTime? _dt_planbackdatetime;
		private int? _planbackaddressid;
		private int? _planloaddepartmentid;
		private int? _planloadaddressid;
		private int? _realgivecardepartmentid;
		private DateTime? _dt_realgivecardatetime;
		private int? _realgivecaraddressid;
		private int? _realloaddepartmentid;
		private DateTime? _dt_realloaddatetime;
		private int? _realloadaddressid;
		private DateTime? _dt_realarrivedestinationdatetime;
		private int? _i_lastlocalizerstationid;
		private int? _lastaddressid;
		/// <summary>
		/// 
		/// </summary>
		public int VehicleID
		{
			set{ _vehicleid=value;}
			get{return _vehicleid;}
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
		public string VehicleName
		{
			set{ _vehiclename=value;}
			get{return _vehiclename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int VehicleTypeID
		{
			set{ _vehicletypeid=value;}
			get{return _vehicletypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int VehicleState
		{
			set{ _vehiclestate=value;}
			get{return _vehiclestate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_SafeLoad
		{
			set{ _i_safeload=value;}
			get{return _i_safeload;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_LocalizerStationID
		{
			set{ _i_localizerstationid=value;}
			get{return _i_localizerstationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dt_InLocalizerStationDateTime
		{
			set{ _dt_inlocalizerstationdatetime=value;}
			get{return _dt_inlocalizerstationdatetime;}
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
		public DateTime? dt_ScrapDateTime
		{
			set{ _dt_scrapdatetime=value;}
			get{return _dt_scrapdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dt_CreateDateTime
		{
			set{ _dt_createdatetime=value;}
			get{return _dt_createdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime dt_LastMaintainDateTIme
		{
			set{ _dt_lastmaintaindatetime=value;}
			get{return _dt_lastmaintaindatetime;}
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
		public int PlanID
		{
			set{ _planid=value;}
			get{return _planid;}
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
		public int? ArriveDestinationAddressID
		{
			set{ _arrivedestinationaddressid=value;}
			get{return _arrivedestinationaddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanState
		{
			set{ _planstate=value;}
			get{return _planstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApplyID
		{
			set{ _applyid=value;}
			get{return _applyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_IsTemPlan
		{
			set{ _i_istemplan=value;}
			get{return _i_istemplan;}
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
		public int? CheckPersonID
		{
			set{ _checkpersonid=value;}
			get{return _checkpersonid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_CheckDateTime
		{
			set{ _dt_checkdatetime=value;}
			get{return _dt_checkdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanGiveCarDepartmentID
		{
			set{ _plangivecardepartmentid=value;}
			get{return _plangivecardepartmentid;}
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
		public int? PlanGiveCarAddressID
		{
			set{ _plangivecaraddressid=value;}
			get{return _plangivecaraddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanUnLoadDepartmentID
		{
			set{ _planunloaddepartmentid=value;}
			get{return _planunloaddepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanBackDepartmentID
		{
			set{ _planbackdepartmentid=value;}
			get{return _planbackdepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_PlanBackDateTime
		{
			set{ _dt_planbackdatetime=value;}
			get{return _dt_planbackdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanBackAddressID
		{
			set{ _planbackaddressid=value;}
			get{return _planbackaddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanLoadDepartmentID
		{
			set{ _planloaddepartmentid=value;}
			get{return _planloaddepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlanLoadAddressID
		{
			set{ _planloadaddressid=value;}
			get{return _planloadaddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RealGiveCarDepartmentID
		{
			set{ _realgivecardepartmentid=value;}
			get{return _realgivecardepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_RealGiveCarDateTime
		{
			set{ _dt_realgivecardatetime=value;}
			get{return _dt_realgivecardatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RealGiveCarAddressID
		{
			set{ _realgivecaraddressid=value;}
			get{return _realgivecaraddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RealLoadDepartmentID
		{
			set{ _realloaddepartmentid=value;}
			get{return _realloaddepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_RealLoadDateTime
		{
			set{ _dt_realloaddatetime=value;}
			get{return _dt_realloaddatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RealLoadAddressID
		{
			set{ _realloadaddressid=value;}
			get{return _realloadaddressid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_RealArriveDestinationDateTime
		{
			set{ _dt_realarrivedestinationdatetime=value;}
			get{return _dt_realarrivedestinationdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_LastLocalizerStationID
		{
			set{ _i_lastlocalizerstationid=value;}
			get{return _i_lastlocalizerstationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LastAddressID
		{
			set{ _lastaddressid=value;}
			get{return _lastaddressid;}
		}
		#endregion Model

	}
}

