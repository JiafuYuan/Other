using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ticketer
{
    delegate void SearchStatusChanged(SearchTicket searchTicket);
    internal enum SearchStatus
    {
        /// <summary>
        /// 查询成功
        /// </summary>
        ok,
        /// <summary>
        /// 创建链接成功
        /// </summary>
        created
    }
    /// <summary>
    /// 查询类
    /// </summary>
    internal class SearchTicket
    {
        public SearchTicket()
        {
 
        }
        /// <summary>
        /// 获取连接状态
        /// </summary>
        public SearchStatus Status
        {
            get
            {
                return status;
            }
        }
        private void statusChanged()
        {
            if (OnStatusChanged != null)
            {
                OnStatusChanged(this);
            }
        }
        public event SearchStatusChanged OnStatusChanged;
        Thread thread;
        private SearchStatus status;
    }

}
