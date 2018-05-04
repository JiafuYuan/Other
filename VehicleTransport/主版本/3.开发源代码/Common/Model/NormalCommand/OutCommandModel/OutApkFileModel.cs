using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.OutCommandModel
{
    public class OutApkFileModel
    {
        public byte[] File { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPackage { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPackage { get; set; }
    }
}
