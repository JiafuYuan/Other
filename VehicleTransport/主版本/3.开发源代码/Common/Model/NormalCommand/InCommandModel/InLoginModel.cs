using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.InCommandModel
{
    public class InLoginModel
    {
        public bool IsPasswordLogin = true;

        public string UserName { get; set; }

        public string  PassWord { get; set; }

        public Enum.EnumUserType UserType;

        /// <summary>
        /// 人员标识卡HID
        /// </summary>
        public int CardHID;
    }
}
