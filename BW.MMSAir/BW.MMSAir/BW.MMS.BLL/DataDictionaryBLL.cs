using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BW.MMS.DAL;
using BW.MMS.Model;

namespace BW.MMS.BLL
{
    public class DataDictionaryBLL
    {
        private readonly DataDictionaryDAL dal = new DataDictionaryDAL();

        public int Add(DataDictionary model)
        {
            return dal.Add(model);
        }

        public bool Update(DataDictionary model)
        {
            return dal.Update(model);
        }

        public List<DataDictionary> SelectByType(string type)
        {
            return dal.SelectByType(type);
        }
    }
}
