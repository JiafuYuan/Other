/**  版本信息模板在安装目录下，可自行修改。
* m_Plan_ApplyVehicle.cs
*
* 功 能： N/A
* 类 名： m_Plan_ApplyVehicle
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-11 11:08:34   N/A    初版
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
	/// m_Plan_ApplyVehicle:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_Plan_ApplyVehicle
	{
		public m_Plan_ApplyVehicle()
		{}
		#region Model
		private int _id;
		private int? _applyid;
		private int? _vehicletypeid;
		private int? _i_count=0;
		private int? _i_checkcount=0;
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
		public int? ApplyID
		{
			set{ _applyid=value;}
			get{return _applyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? VehicleTypeID
		{
			set{ _vehicletypeid=value;}
			get{return _vehicletypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_Count
		{
			set{ _i_count=value;}
			get{return _i_count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_CheckCount
		{
			set{ _i_checkcount=value;}
			get{return _i_checkcount;}
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

