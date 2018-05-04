/**  版本信息模板在安装目录下，可自行修改。
* m_Title.cs
*
* 功 能： N/A
* 类 名： m_Title
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/4/13 11:24:32   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using JSCERT.Model;
namespace JSCERT.BLL
{
	/// <summary>
	/// m_Title
	/// </summary>
	public partial class m_Title
	{
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public void UpdateFlag(int TypeID)
		{
		    DB.OleDbHelper.ExecuteSql(string.Format("Update m_Title set i_Flag=1 where typeid={0}",TypeID));
		}

	}
}

