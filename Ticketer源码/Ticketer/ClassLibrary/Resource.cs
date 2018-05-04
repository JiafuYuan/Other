using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Ticketer
{
    delegate void SetContralText(object text);
    delegate void SetContral(System.Windows.Forms.Control con, object arg);
    internal struct LinkAddress
    {
        //private const string webroot = "https://www.12306.cn/";
        private const string webroot = "http://www.12306.cn/";
        //private const string webroot = "https://dynamic.12306.cn/";
        /// <summary>
        /// 本工具连接服务地址
        /// </summary>
        public const string TICKETER_ADDRESS = "https://dynamic.12306.cn/otsweb/";
        /// <summary>
        /// 12306网站订票页面地址
        /// </summary>
        public const string SERVICE_ADDRESS = webroot + "otsweb/main.jsp";
        /// <summary>
        /// 登录验证码地址
        /// </summary>
        public const string LOGINIMG_ADDRESS = webroot + "otsweb/passCodeAction.do?rand=sjrand";
        /// <summary>
        /// 登录前验证并获取登录随机码地址
        /// </summary>
        public const string LOGINSUGGEST = webroot + "otsweb/loginAction.do?method=loginAysnSuggest";
        /// <summary>
        /// 系统登录地址
        /// </summary>
        public const string LOGIN_ADDRESS = webroot + "otsweb/loginAction.do?method=login";
        /// <summary>
        /// 车票信息查询页面
        /// </summary>
        public const string TICKETSEARCH_ADDRESS = webroot + "otsweb/order/querySingleAction.do";
        //"otsweb/passengerAction.do?method=getPagePassengerAll";
        /// <summary>
        /// 获取联系人地址
        /// </summary>
        public const string ALLPASSENGER_ADDRESS = webroot + "otsweb/order/confirmPassengerAction.do?method=getpassengerJson";
        /// <summary>
        /// 提交订单验证码地址
        /// </summary>
        public const string ORDERIMG_ADDRESS = webroot + "otsweb/passCodeAction.do?rand=randp";
        /// <summary>
        /// 订单生成页面地址
        /// </summary>
        public const string CREATEORDER_ADDRESS = webroot + "otsweb/order/querySingleAction.do";
        /// <summary>
        /// 确认订单页面
        /// </summary>
        public const string CONFIRMPASSENGERACTION_ADDRESS = webroot + "otsweb/order/confirmPassengerAction.do?method=checkOrderInfo";
        /// <summary>
        /// 检查剩余票数连接
        /// </summary>
        public const string CHECKNUMBEROFTICKET_ADDRESS = webroot + "otsweb/order/confirmPassengerAction.do?method=getQueueCount";
        /// <summary>
        /// 下单地址，目前只支持单程订单
        /// </summary>
        public const string SUBMITORDER_ADDRESS = webroot + "otsweb/order/confirmPassengerAction.do?method=confirmSingleForQueue";
    }

    internal struct SeatClass
    {
        internal enum SeatType
        {
            商务座 = 1,
            一等座 = 2,
            二等座 = 4,
            高级软卧 = 8,
            软卧 = 16,
            硬卧 = 32,
            软座 = 64,
            硬座 = 128,
            无座 = 256,
            其他 = 512
        }

        internal string GetValueByType(SeatType seatType)
        {
            string result = string.Empty;
            switch (seatType)
            {
                case SeatType.商务座:
                    result = "9";
                    break;
                case SeatType.一等座:
                    result = "M";
                    break;
                case SeatType.二等座:
                    result = "O";
                    break;
                case SeatType.高级软卧:
                    result = "6";
                    break;
                case SeatType.软卧:
                    result = "4";
                    break;
                case SeatType.硬卧:
                    result = "3";
                    break;
                case SeatType.软座:
                    result = "2";
                    break;
                case SeatType.硬座:
                    result = "1";
                    break;
                case SeatType.无座:
                    result = "1";
                    break;
                case SeatType.其他:
                    result = "";
                    break;
            }
            return result;
        }

        internal List<KeyValue> GetSeatTypeList()
        {
            List<KeyValue> list = new List<KeyValue>();
            foreach (SeatType seatType in Enum.GetValues(typeof(SeatType)))
            {
                list.Add(new KeyValue() { Text = seatType.ToString(), Value = GetValueByType(seatType) });
            }
            return list;
        }

        internal class KeyValue
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }
    }
}
