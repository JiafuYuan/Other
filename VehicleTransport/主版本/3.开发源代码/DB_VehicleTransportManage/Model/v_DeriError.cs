﻿/**  版本信息模板在安装目录下，可自行修改。
* v_DeriError.cs
*
* 功 能： N/A
* 类 名： v_DeriError
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/10/16 14:13:43   N/A    初版
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
	/// v_DeriError:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_DeriError
	{
		public v_DeriError()
		{}
		#region Model
		private int _vehicleid;
		private int _addressid;
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
		public int AddressID
		{
			set{ _addressid=value;}
			get{return _addressid;}
		}
		#endregion Model

	}
}

