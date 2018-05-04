/**  版本信息模板在安装目录下，可自行修改。
* m_SensorNodesEntity.cs
*
* 功 能： N/A
* 类 名： m_SensorNodesEntity
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-11-6 18:22:12   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace BW.MMS.Model
{
	/// <summary>
	/// m_SensorNodesEntity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_SensorNodesEntity
	{
		public m_SensorNodesEntity()
		{}
		#region Model
		private int _id;
		private int _sensorid;
		private int _nodeid;
		private string _vc_address;
		private string _vc_memo;
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
		public int SensorID
		{
			set{ _sensorid=value;}
			get{return _sensorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int NodeID
		{
			set{ _nodeid=value;}
			get{return _nodeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Address
		{
			set{ _vc_address=value;}
			get{return _vc_address;}
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

