using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BW.MMS.BLL;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;

namespace BW.MMS.Web.Controllers
{
    public class DayReportController : Controller
    {
        //
        // GET: /WorkReport/
        BLL.HistoryRecord bllHistoryRecord = new HistoryRecord();
     BLL.S_Point bllSPoint=new S_Point();
        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            //column.Add(new DataGridColumn { field = "cbk", columnAttributes = new { checkbox = true } });
            //column.Add(new DataGridColumn { title = "ID", field = "ID", columnAttributes = new { align = "center", width = 120, sortable = true } });
            column.Add(new DataGridColumn { title = "名称", field = "PointName", columnAttributes = new { align = "center", width = 300, sortable = true } });
            column.Add(new DataGridColumn { title = "数值", field = "PointValue", columnAttributes = new { align = "center", width = 200, sortable = true } });
           
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }

        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            return View();
        }

        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public ActionResult GetDayReportList()
        {
            string beginDate = DateTime.Parse(Request["dt_Date"]).ToString("yyyy-MM-dd  00:00:00");
            string endDate = DateTime.Parse(Request["dt_Date"]).ToString("yyyy-MM-dd  23:59:59");
       
            DataSet ds = bllHistoryRecord.GetDayReport(beginDate, endDate);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0].Clone();
                foreach (DataColumn item in dt.Columns)
                {
                    if (item.DataType == typeof(double))
                    {
                        item.DataType = typeof(decimal);
                    }
                }
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn column in dt.Columns)
                    {
                        dr[column.ColumnName] = row[column.ColumnName];
                    }
                    dt.Rows.Add(dr);
                }
                return Content(Newtonsoft.Json.JsonConvert.SerializeObject(dt));
            }
            return null;

        }

        public JsonResult DataTableToReportJson(DataTable dt, string tableName)
        {
            List<object> columns = new List<object>();
            foreach (DataColumn column in dt.Columns)
            {
                string t = "string";
                int length = 0;
                if (column.DataType == typeof(string))
                {
                    length = 500;
                }
                if (column.DataType == typeof(int))
                {
                    t = "integer";
                }
                if (column.DataType == typeof(double))
                {
                    t = "float";
                }
                if (column.DataType == typeof(decimal))
                {
                    t = "float";
                }
                if (column.DataType == typeof(DateTime))
                {
                    t = "datetime";
                }
                columns.Add(new { name = column.ColumnName, type = t, length = column.MaxLength == -1 ? length : column.MaxLength });
            }
            List<object> records = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                string record = string.Empty;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        record += ",";
                    }
                    record += row[dt.Columns[i].ColumnName];
                }
                records.Add(new { values = record });
            }
            var data = new { name = tableName, titles = columns, records = records };
            return Json(data);
        }
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetAreaItem()
        {
            TreeGridItem item = new TreeGridItem();
            item.Guid = "0";
            item.Display_Name = "所有传感器";
            List<Model.Regions> list = new List<Model.Regions>();
            //if (Request["recursion"] != "0")
            //{
            list = bllRegions.GetModelList(string.Format("Status=0 and Parent_GUID={0}", item.Guid) + "");
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
           
            return Json(bllSPoint.GetModelList(string.Format("PointValueType={0}",9)));
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
                node.Guid = entity.GUID;
                node.Code = entity.Code;
                node.Status = Convert.ToInt32(entity.Status);
                node.Display_Name = entity.Display_Name;
                node.Description = entity.Display_Name;
                node.Parent_GUID = entity.Parent_GUID;
                List<Model.Regions> children = bllRegions.GetModelList(string.Format("Status=0 and Parent_GUID={0}", entity.GUID) + "");
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
            public string Guid { get; set; }
            public string Display_Name { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
            public int Status { get; set; }
   
            public bool leaf { get; set; }
            public string Parent_GUID { get; set; }
            public List<TreeGridItem> children { get; set; }

        }
    }
}
