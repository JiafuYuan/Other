using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Model;

namespace BW.MMS.Web.Controllers.BasicInfo
{
    public class PowerSettlementController : BaseController
    {
        private readonly DataDictionaryBLL bll = new DataDictionaryBLL();
        private const string type = "Power";

        public ActionResult Index()
        {
            List<DataDictionary> list = bll.SelectByType(type);
            ViewData["Hour"] = list.FirstOrDefault(m => m.Key == "Hour").Value;
            ViewData["Day"] = list.FirstOrDefault(m => m.Key == "Day").Value;
            return View();
        }
        [HttpPost]
        public JsonResult SaveConfig()
        {
            List<DataDictionary> list = bll.SelectByType(type);
            DataDictionary model = list.FirstOrDefault(m => m.Key == "Hour");
            model.Value = Request["hour"];
            bll.Update(model);
            model = list.FirstOrDefault(m => m.Key == "Day");
            model.Value = Request["day"];
            bll.Update(model);
            return Json(new { success = true, message = "保存成功！" });
        }
    }
}
