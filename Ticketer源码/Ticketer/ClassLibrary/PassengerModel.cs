using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ticketer
{
    internal class PassengerModel
    {
        public PassengerModel(JsonObject json)
        {
            name = json["passenger_name"].Value;
            passengerID = json["passenger_id_no"].Value;
            passengerIDType = json["passenger_id_type_code"].Value;
            passengerType = json["passenger_type"].Value;
            telephone = json["mobile_no"].Value;
        }
        /// <summary>
        /// 乘客姓名
        /// </summary>
        public string Name { get { return name; } }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string PassengerID { get { return passengerID; } }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string PassengerIDType { get { return passengerIDType; } }
        /// <summary>
        /// 乘客类型
        /// </summary>
        public string PassengerType { get { return passengerType; } }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get { return telephone; } }


        private string name;
        private string passengerID;
        private string passengerIDType;
        private string passengerType;
        private string telephone;
    }
}
