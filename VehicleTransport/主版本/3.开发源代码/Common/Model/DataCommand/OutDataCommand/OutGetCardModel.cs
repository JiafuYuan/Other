using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model.DataCommand.OutDataCommand
{
    public class OutGetCardModel : BaseDataCommandModel
    {
        public List<DB_VehicleTransportManage.Model.m_Card> Listm_Card = new List<DB_VehicleTransportManage.Model.m_Card>();
    }
}
