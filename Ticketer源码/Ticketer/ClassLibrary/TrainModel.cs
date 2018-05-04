using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace Ticketer
{
    internal class TrainModel
    {
        public TrainModel(string trainStr)
        {
            string[] strs = trainStr.Split(',');
            if (strs.Length != 17)
                throw new Exception("字符串无法解析为有效信息");
            int.TryParse(strs[0], out order);
            Regex reg = new Regex(@"<\s*(\S+)(\s[^>]*)?>|<\s*\/\1\s*>");
            trainNum = reg.Replace(strs[1], "");
            startStation = strs[2].Replace("&nbsp;", "").Replace("<br>", "\n").Replace("<img src='/otsweb/images/tips/first.gif'>", "*始发车--");
            arriveStation = strs[3].Replace("&nbsp;", "").Replace("<br>", "\n").Replace("<img src='/otsweb/images/tips/last.gif'>", "*终点车--");
            useTime = strs[4];
            businessSeat = setTicketCount(strs[5]);
            specialSeat = setTicketCount(strs[6]);
            firstSeat = setTicketCount(strs[7]);
            secondSeat = setTicketCount(strs[8]);
            highRankingSoftSleeper = setTicketCount(strs[9]);
            softSleeper = setTicketCount(strs[10]);
            hardSleeper = setTicketCount(strs[11]);
            softSeat = setTicketCount(strs[12]);
            hardSeat = setTicketCount(strs[13]);
            noSeat = setTicketCount(strs[14]);
            other = setTicketCount(strs[15]);

            Regex breg = new Regex(@"getSelected\(\'([\s|\S]+)\'\)");
            if (breg.IsMatch(strs[16]))
            {
                isAllowBuy = true;
                buyStr = breg.Match(strs[16]).Groups[1].Value;
            }
            else
            {
                isAllowBuy = false;
            }
        }

        private int setTicketCount(string str)
        {
            int num;
            if (str == "<font color='darkgray'>无</font>")
            {
                num = 0;
            }
            else if (str == "--")
                num = -1;
            else if (str.IndexOf("有") > -1)
                num = 50;
            else
                int.TryParse(str, out num);
            return num;
        }

        #region 属性
        /// <summary>
        /// 获取车次
        /// </summary>
        public string TrainNum { get { return trainNum; } }
        /// <summary>
        /// 获取发车站点
        /// </summary>
        public string StartStation { get { return startStation; } }
        /// <summary>
        /// 获取到达站点
        /// </summary>
        public string ArriveStation { get { return arriveStation; } }
        /// <summary>
        /// 获取需要时间
        /// </summary>
        public string UseTime { get { return useTime; } }
        /// <summary>
        /// 获取商务座数量
        /// </summary>
        public int BusinessSeat { get { return businessSeat; } }
        /// <summary>
        /// 获取特等座数量
        /// </summary>
        public int SpecialSeat { get { return specialSeat; } }
        /// <summary>
        /// 获取一等座数量
        /// </summary>
        public int FirstSeat { get { return firstSeat; } }
        /// <summary>
        /// 获取二等座数量
        /// </summary>
        public int SecondSeat { get { return secondSeat; } }
        /// <summary>
        /// 获取高级软卧数量
        /// </summary>
        public int HighRankingSoftSleeper { get { return highRankingSoftSleeper; } }
        /// <summary>
        /// 获取软卧数量
        /// </summary>
        public int SoftSleeper { get { return softSleeper; } }
        /// <summary>
        /// 获取软座数量
        /// </summary>
        public int SoftSeat { get { return softSeat; } }
        /// <summary>
        /// 获取硬座数量
        /// </summary>
        public int HardSeat { get { return hardSeat; } }
        /// <summary>
        /// 获取硬卧数量
        /// </summary>
        public int HardSleeper { get { return hardSleeper; } }
        /// <summary>
        /// 获取无座数量
        /// </summary>
        public int NoSeat { get { return noSeat; } }
        /// <summary>
        /// 获取其他座数量
        /// </summary>
        public int Other { get { return other; } }
        /// <summary>
        /// 获取列表序号
        /// </summary>
        public int Order { get { return order; } }
        /// <summary>
        /// 获取购买标识字符串
        /// </summary>
        public string BuyString { get { return buyStr; } }
        /// <summary>
        /// 获取是否可以订购
        /// </summary>
        public bool IsAllowBuy { get { return isAllowBuy; } }
        #endregion

        #region 字段
        private string trainNum;
        private string startStation;
        private string arriveStation;
        private string useTime;

        private int businessSeat;
        private int specialSeat;
        private int firstSeat;
        private int secondSeat;
        private int highRankingSoftSleeper;
        private int softSleeper;
        private int hardSleeper;
        private int softSeat;
        private int hardSeat;
        private int noSeat;
        private int other;

        private int order;

        private string buyStr;

        private bool isAllowBuy;
        #endregion
    }
}
