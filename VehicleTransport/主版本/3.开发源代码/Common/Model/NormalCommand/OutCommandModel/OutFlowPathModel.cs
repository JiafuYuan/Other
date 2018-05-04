using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.OutCommandModel
{
    public class OutFlowPathModel
    {
        /// <summary>
        /// 申请
        /// </summary>
        public  bool Apply = true;

        /// <summary>
        /// 审核
        /// </summary>
        public  bool Check = true;

        /// <summary>
        /// 供车
        /// </summary>
        public bool Give = false;

        /// <summary>
        /// 装车
        /// </summary>
        public  bool Load = true;

        /// <summary>
        /// 交接车
        /// </summary>
        public bool Handover = false;

        /// <summary>
        /// 卸车
        /// </summary>
        public  bool UnLoad = true;

        /// <summary>
        /// 还车
        /// </summary>
        public bool Back = false;
    }
}
