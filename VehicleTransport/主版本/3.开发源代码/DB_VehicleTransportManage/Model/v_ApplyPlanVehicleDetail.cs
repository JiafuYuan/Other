/**  版本信息模板在安装目录下，可自行修改。
* v_ApplyPlanVehicleDetail.cs
*
* 功 能： N/A
* 类 名： v_ApplyPlanVehicleDetail
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
	/// v_ApplyPlanVehicleDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_ApplyPlanVehicleDetail
	{
		public v_ApplyPlanVehicleDetail()
		{}
		#region Model
		private int _vehicleid;
		private string _vc_code;
		private string _vehiclename;
		private int _vehicletypeid;
		private int _vehiclestate;
		private int? _i_safeload;
		private int _i_localizerstationid;
		private int _planid;
		private int? _planstate;
		private string _vc_plancode;
		private int? _arrivedestinationaddressid;
		private DateTime? _dt_arrivedestinationdatetime;
		private int? _applydepartmentid;
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
		public int PlanID
		{
			set{ _planid=value;}
			get{return _planid;}
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
		public string vc_PlanCode
		{
			set{ _vc_plancode=value;}
			get{return _vc_plancode;}
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
		public DateTime? dt_ArriveDestinationDateTime
		{
			set{ _dt_arrivedestinationdatetime=value;}
			get{return _dt_arrivedestinationdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApplyDepartmentID
		{
			set{ _applydepartmentid=value;}
			get{return _applydepartmentid;}
		}
		#endregion Model

	}
}

