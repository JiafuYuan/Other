using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.InCommandModel
{
    public class InHeartBeatModel
    {
        public int UserID { get; set; }

        public string PDAMac { get; set; }

       // public string PDAIP { get; set; }

        /// <summary>
        /// 所在WIFI基站的Mac地址
        /// </summary>
        public string WifiBaseStationMac { get; set; }


        //public DateTime DateTime { get; set; }
        //public byte[] ArrB = new byte[10000*10];

    }
}
