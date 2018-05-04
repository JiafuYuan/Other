/**  版本信息模板在安装目录下，可自行修改。
* m_PLC.cs
*
* 功 能： N/A
* 类 名： m_PLC
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-04-14 15:00:01   N/A    初版
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
	/// m_PLC:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_PLCEntity
	{
		public m_PLCEntity()
		{}
		#region Model
		private int _id;
		private string _vc_name;
		private string _vc_ip;
		private string _vc_remark;
        private int _i_flag;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_name
		{
			set{ _vc_name=value;}
			get{return _vc_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_IP
		{
			set{ _vc_ip=value;}
			get{return _vc_ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_remark
		{
			set{ _vc_remark=value;}
			get{return _vc_remark;}
		}

        public int i_flag
        {
            set { _i_flag = value; }
            get { return _i_flag; }
        }
		#endregion Model

	}
}

