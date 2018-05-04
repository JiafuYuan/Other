using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BW.MMS.Model
{
    public class DataDictionary
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
