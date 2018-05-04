/**  版本信息模板在安装目录下，可自行修改。
* m_Apply.cs
*
* 功 能： N/A
* 类 名： m_Apply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/28 15:58:19   N/A    初版
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
	/// m_Apply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_Apply
	{
		public m_Apply()
		{}
		#region Model
		private int _id;
		private int? _applypersonid;
		private DateTime? _dt_applydatetime;
		private string _vc_planuse;
		private int? _i_state=0;
		private DateTime? _dt_arrivedestinationdatetime;
		private int? _arrivedestinationaddressid;
		private int? _i_isusematerieapply=0;
		private int? _applydepartmentid;
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
		public int? ApplyPersonID
		{
			set{ _applypersonid=value;}
			get{return _applypersonid;}
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
		public string vc_PlanUse
		{
			set{ _vc_planuse=value;}
			get{return _vc_planuse;}
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
		public int? i_IsUseMaterieApply
		{
			set{ _i_isusematerieapply=value;}
			get{return _i_isusematerieapply;}
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
		public string vc_remark
		{
			set{ _vc_remark=value;}
			get{return _vc_remark;}
		}
		#endregion Model

	}
}

