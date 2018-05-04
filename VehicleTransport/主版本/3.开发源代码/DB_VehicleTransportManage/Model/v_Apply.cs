/**  版本信息模板在安装目录下，可自行修改。
* v_Apply.cs
*
* 功 能： N/A
* 类 名： v_Apply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/28 16:41:43   N/A    初版
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
	/// v_Apply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_Apply
	{
		public v_Apply()
		{}
		#region Model
		private int _id;
		private DateTime? _dt_applydatetime;
		private string _deptname;
		private int? _applydepartmentid;
		private int? _applypersonid;
		private string _username;
		private string _vc_planuse;
		private int? _arrivedestinationaddressid;
		private string _addressname;
		private DateTime? _dt_arrive;
		private string _statename;
		private int? _i_state;
		private int? _i_isusematerieapply;
		private string _vc_remark;
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
		public DateTime? dt_ApplyDateTime
		{
			set{ _dt_applydatetime=value;}
			get{return _dt_applydatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string deptname
		{
			set{ _deptname=value;}
			get{return _deptname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApplyDepartmentID
		{
			set{ _applydepartmentid=value;}
			get{return _applydepartmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApplyPersonID
		{
			set{ _applypersonid=value;}
			get{return _applypersonid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_PlanUse
		{
			set{ _vc_planuse=value;}
			get{return _vc_planuse;}
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
		public string addressname
		{
			set{ _addressname=value;}
			get{return _addressname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_arrive
		{
			set{ _dt_arrive=value;}
			get{return _dt_arrive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string statename
		{
			set{ _statename=value;}
			get{return _statename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_State
		{
			set{ _i_state=value;}
			get{return _i_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_IsUseMaterieApply
		{
			set{ _i_isusematerieapply=value;}
			get{return _i_isusematerieapply;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_remark
		{
			set{ _vc_remark=value;}
			get{return _vc_remark;}
		}
		#endregion Model

	}
}

