using System;

namespace Ticketer
{
    /// <summary>
    /// 车站信息
    /// </summary>
    internal class StationModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 数字编码
        /// </summary>
        public string NumCode { set; get; }
        /// <summary>
        /// 名称短拼音
        /// </summary>
        public string ShortPYString { set; get; }
        /// <summary>
        /// 名称拼音
        /// </summary>
        public string PYString { set; get; }
        /// <summary>
        /// 字母编码
        /// </summary>
        public string LetterCode { set; get; }
        /// <summary>
        /// 模糊拼音
        /// </summary>
        public string VaguePYString { set; get; }
    }
}
