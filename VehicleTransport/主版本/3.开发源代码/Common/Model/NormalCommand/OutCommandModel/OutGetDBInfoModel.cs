using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.NormalCommand.OutCommandModel
{
    public class OutGetDBInfoModel
    {
        public string DBServer { get; set; }

        public string UID { get; set; }

        public string Psw { get; set; }

        public string DBName { get; set; }
    }
}
