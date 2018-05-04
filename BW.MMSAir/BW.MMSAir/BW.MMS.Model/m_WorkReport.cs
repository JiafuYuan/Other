/**  版本信息模板在安装目录下，可自行修改。
* m_WorkReport.cs
*
* 功 能： N/A
* 类 名： m_WorkReport
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/3 21:38:32   N/A    初版
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
	/// m_WorkReport:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_WorkReport
	{
		public m_WorkReport()
		{}
		#region Model
		private int _id;
		private int _userid;
		private string _vc_content;
        private string _vc_nextcontent;
        private string _vc_practicalcompletion;
		private string _vc_reply;
		private int _workreporttype;
		private int _i_flag=0;
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
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Content
		{
			set{ _vc_content=value;}
			get{return _vc_content;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string vc_NextContent
        {
            set { _vc_nextcontent = value; }
            get { return _vc_nextcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string vc_PracticalCompletion
        {
            set { _vc_practicalcompletion = value; }
            get { return _vc_practicalcompletion; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string vc_Reply
		{
			set{ _vc_reply=value;}
			get{return _vc_reply;}
		}
		/// <summary>
		/// 0:日报;1:周报;2:月报
		/// </summary>
		public int WorkReportType
		{
			set{ _workreporttype=value;}
			get{return _workreporttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int i_flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		#endregion Model

	}
}

