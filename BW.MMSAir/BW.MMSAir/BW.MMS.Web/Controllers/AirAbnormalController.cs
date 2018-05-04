using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;

namespace BW.MMS.Web.Controllers
{
    public class EquipmentController : Controller
    {
        //
        // GET: /WorkReport/、
        BLL.S_ControllerInfo bllSControllerInfo=new S_ControllerInfo();
      
        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            //column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
            //column.Add(new DataGridColumn { title = "ID", field = "ID", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "控制器名称", field = "ControlName", columnAttributes = new { align = "center", width = 150, sortable = true } });
            column.Add(new DataGridColumn { title = "系统名称", field = "SystemLabel", columnAttributes = new { align = "center", width = 150, sortable = true } });
            column.Add(new DataGridColumn { title = "描述", field = "Description", columnAttributes = new { align = "center", width = 200, sortable = true } });
            column.Add(new DataGridColumn { title = "区域", field = "Area", columnAttributes = new { align = "center", width = 200, sortable = true } });
            column.Add(new DataGridColumn { title = "是否启用", field = "Enable", columnAttributes = new { align = "center", width = 200, sortable = true, formatter = new { function = "data_string" } } });
            column.Add(new DataGridColumn { title = "通道名称", field = "ChannelName", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "地址", field = "ControllerAddress", columnAttributes = new { align = "center", width = 80, sortable = true } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }

        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            return View();
        }
        [ExceptionFilter]
        public JsonResult GetEquipmentList(int page, int rows, string sort, string order)
        {
            int record = 0;
            string paramSearchAreaName = Request["AreaName"];
            string paramSearchControlName = Request["ControlName"];
          
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(paramSearchAreaName) && paramSearchAreaName!="0")
            {
                sb.AppendFormat(" AND Area like '%{0}%'", paramSearchAreaName);
            }

            if (!string.IsNullOrEmpty(paramSearchControlName))
            {
                sb.AppendFormat(" AND ControlName like '%{0}%'", paramSearchControlName);
            }
            List<Model.S_ControllerInfo> list = bllSControllerInfo.GetPagingList(sb.ToString(), page, rows, sort, order, out record);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("total", record);
            data.Add("rows", list);
         
            return Json(data);

        }
        //获取区域
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetAreaItem()
        {
            TreeGridItem item = new TreeGridItem();
            item.id  = "0";
            item.text = "所有区域";
            List<Model.Regions> list = new List<Model.Regions>();
            //if (item.id != "0")
            //{
            list = bllRegions.GetModelList(string.Format("Status=0 and Display_Name='{0}'", "根区域"));
            //list = bllRegions.GetModelList("Status=0 ");
            //}
            bool recursion = true;
            if (!string.IsNullOrEmpty(Request["recursion"]))
            {
                recursion = bool.Parse(Request["recursion"]);
            }
            item.children = InitTree(list, recursion);
            List<TreeGridItem> tree = new List<TreeGridItem>();
            tree.Add(item);
            
            return Json(tree);
        }
        ///// <summary>绑定传感器类型
        /// 绑定传感器类型
        /// </summary>
        /// <returns></returns>
        public JsonResult GetSensorType()
        {
           
            return Json(bllSControllerInfo.GetModelList(""));
        }

        BLL.Regions bllRegions=new Regions();
        /// <summary>
        /// 递归添加数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<TreeGridItem> InitTree(List<Model.Regions> list, bool recursion)
        {
            List<TreeGridItem> nodes = new List<TreeGridItem>();
            TreeGridItem node;
            foreach (Model.Regions entity in list)
            {
                node = new TreeGridItem();
                node.id = entity.GUID;
                node.Code = entity.Code;
                node.Status = Convert.ToInt32(entity.Status);
                node.text = entity.Display_Name;
                node.Description = entity.Description;
                node.Parent_GUID = entity.Parent_GUID;
                List<Model.Regions> children = bllRegions.GetModelList(string.Format("Status=0 and Parent_GUID='{0}'", entity.GUID) + "");
                if (children.Count > 0 && recursion)
                {
                    node.children = InitTree(children, recursion);
                    node.leaf = false;
                }
                else
                {
                    node.leaf = true;
                }
                nodes.Add(node);
            }
            return nodes;
        }

        /// <summary>
        /// TreeGrid模版
        /// </summary>
        class TreeGridItem
        {
            public string id { get; set; }
            public string text { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
            public int Status { get; set; }
   
            public bool leaf { get; set; }
            public string Parent_GUID { get; set; }
            public List<TreeGridItem> children { get; set; }

        }
    }
}
