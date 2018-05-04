using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.DataCommand.InDataCommand
{
    public class InGetVehicleModel : BaseDataCommandModel
    {
        /// <summary>
        /// 区域ID，为0时返回所有
        /// </summary>
        public int AreaID;
    }
}
