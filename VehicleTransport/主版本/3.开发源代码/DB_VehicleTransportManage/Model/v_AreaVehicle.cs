/**  版本信息模板在安装目录下，可自行修改。
* v_AreaVehicle.cs
*
* 功 能： N/A
* 类 名： v_AreaVehicle
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/23 15:56:04   N/A    初版
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
	/// v_AreaVehicle:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_AreaVehicle
	{
		public v_AreaVehicle()
		{}
		#region Model
		private int? _areaid;
		private string _areaname;
		private int? _emptyvehicle;
		private int? _weightvehicle;
		/// <summary>
		/// 
		/// </summary>
		public int? AreaID
		{
			set{ _areaid=value;}
			get{return _areaid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AreaName
		{
			set{ _areaname=value;}
			get{return _areaname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmptyVehicle
		{
			set{ _emptyvehicle=value;}
			get{return _emptyvehicle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? WeightVehicle
		{
			set{ _weightvehicle=value;}
			get{return _weightvehicle;}
		}
		#endregion Model

	}
}

