/**  版本信息模板在安装目录下，可自行修改。
* m_SystemConfig.cs
*
* 功 能： N/A
* 类 名： m_SystemConfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-08-11 11:08:36   N/A    初版
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
	/// m_SystemConfig:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_SystemConfig
	{
		public m_SystemConfig()
		{}
		#region Model
		private string _vc_key;
		private string _vc_value;
		private string _vc_memo;
		/// <summary>
		/// 
		/// </summary>
		public string vc_Key
		{
			set{ _vc_key=value;}
			get{return _vc_key;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Value
		{
			set{ _vc_value=value;}
			get{return _vc_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		#endregion Model

	}
}

