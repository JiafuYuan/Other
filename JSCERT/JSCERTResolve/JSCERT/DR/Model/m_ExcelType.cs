/**  版本信息模板在安装目录下，可自行修改。
* m_ExcelType.cs
*
* 功 能： N/A
* 类 名： m_ExcelType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/9 15:59:23   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace JSCERT.Model
{
	/// <summary>
	/// m_ExcelType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_ExcelType
	{
		public m_ExcelType()
		{}
		#region Model
		private int _id;
		private string _vc_name;
		private int? _icode;
        private string _vc_Memo;
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
		public string vc_Name
		{
			set{ _vc_name=value;}
			get{return _vc_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? iCode
		{
			set{ _icode=value;}
			get{return _icode;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string vc_Memo
        {
            set { _vc_Memo = value; }
            get { return _vc_Memo; }
        }
		#endregion Model

	}
}

