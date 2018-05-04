/**  版本信息模板在安装目录下，可自行修改。
* v_WorkReport.cs
*
* 功 能： N/A
* 类 名： v_WorkReport
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/9/5 11:18:18   N/A    初版
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
	/// v_WorkReport:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_WorkReport
	{
		public v_WorkReport()
		{}
		#region Model
		private int _id;
		private int _userid;
		private string _vc_content;
        private string _vc_nextcontent;
        private string _vc_practicalcompletion;
		private string _vc_reply;
		private int? _workreporttype;
		private int? _i_flag;
		private DateTime? _dt_addtime;
        private string _vc_realname;
		private string _workreporttypename;
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
		/// 
		/// </summary>
		public int? WorkReportType
		{
			set{ _workreporttype=value;}
			get{return _workreporttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dt_AddTime
		{
			set{ _dt_addtime=value;}
			get{return _dt_addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_RealName
		{
			set{ _vc_realname=value;}
            get { return _vc_realname; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string workreporttypename
		{
			set{ _workreporttypename=value;}
			get{return _workreporttypename;}
		}
		#endregion Model

	}
}

