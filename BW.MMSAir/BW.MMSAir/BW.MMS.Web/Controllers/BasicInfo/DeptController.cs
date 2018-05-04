using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BW.MMS.Web.HtmlExtension.Easyui;
using BW.MMS.Web.Filters;
using BW.MMS.Model;
using BW.MMS.BLL;
using System.Data;

namespace BW.MMS.Web.Controllers.BasicInfo
{
    public class DeptController : BaseController
    {
        //
        // GET: /Dept/

        private readonly m_DeptBLL bll = new m_DeptBLL();

        private List<List<DataGridColumn>> GetColumns()
        {
            List<DataGridColumn> column = new List<DataGridColumn>();
            column.Add(new DataGridColumn { field = "i_Sort", title = "排序号", columnAttributes = new { align = "center", width = 60 } });
            column.Add(new DataGridColumn { field = "vc_Name", title = "使用单位名称", columnAttributes = new { align = "left", width = 180 } });
            column.Add(new DataGridColumn { field = "vc_Code", title = "使用单位编号", columnAttributes = new { align = "center", width = 100 } });
            column.Add(new DataGridColumn { field = "vc_Memo", title = "备注", columnAttributes = new { align = "center", width = 100 } });
            List<List<DataGridColumn>> columns = new List<List<DataGridColumn>>();
            columns.Add(column);
            return columns;
        }

        public ActionResult Index()
        {
            ViewData["GridColumn"] = GetColumns();
            return View();
        }

        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetDeptList()
        {
            string txtValue = Request["txtValue"];
            string where = "i_Flag=0";
            if (!string.IsNullOrEmpty(txtValue))
            {
                where += string.Format(" AND (vc_Code LIKE '%{0}%' OR vc_Name LIKE '%{0}%')", txtValue);
            }
            else
            {
                where += " AND ParentDeptID=0";
            }

            where += " ";
            List<m_DeptEntity> list = bll.GetModelList(where);
            if (list.Count > 0)
            {
                if (string.IsNullOrEmpty(txtValue))
                {
                    return Json(InitTree(list, true));
                }
                else
                {
                    return Json(InitTree(list, false));
                }
            }
            return Json(new List<TreeGridItem>());
        }

        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetDeptItem()
        {
            TreeGridItem item = new TreeGridItem();
            item.id = 0;
            item.text = "所有部门";
            List<m_DeptEntity> list = new List<m_DeptEntity>();
            //if (Request["recursion"] != "0")
            //{
            list = bll.GetModelList(string.Format("i_Flag=0 and ParentDeptID={0}", item.id));
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

        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetDeptTree()
        {
            List<m_DeptEntity> list = bll.GetModelList("ParentDeptID=0 and i_Flag=0");
            return Json(InitTree(list, true));
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult GetDeptItems(int id = 0)
        {
            List<m_DeptEntity> list = bll.GetModelList("ParentDeptID=" + id + " and i_Flag=0 ");
            return Json(list);
        }

        [ExceptionFilter]
        public ActionResult Edit(int id = 0)
        {
            m_DeptEntity entity = bll.GetModel(id);
            if (entity == null)
            {
                entity = new m_DeptEntity { ParentDeptID = 0 };
            }
            return View(entity);
        }

        [ExceptionFilter(IsAjax = true)]
        public JsonResult Delete(string id)
        {
            m_SensorBLL sensorBll = new m_SensorBLL();
            DataTable dt = new DataTable();
            dt = sensorBll.GetList(" deptID=" + int.Parse(id) + "").Tables[0];
            if (dt.Rows.Count > 0)
            {
                return Json(new { success = false, message = "该部门下有传感器，无法删除！" });
            }

            DataTable isParentDt = new DataTable();
            isParentDt = bll.GetList(" i_Flag=0 and parentdeptid=0 and ID=" + int.Parse(id) + "").Tables[0];
            if (isParentDt.Rows.Count > 0)
            {
                isParentDt = bll.GetList("i_Flag=0 and parentdeptid=" + int.Parse(id) + "").Tables[0];
                for (int i = 0; i < isParentDt.Rows.Count; i++)
                {
                    dt = sensorBll.GetList(" deptID=" + int.Parse(isParentDt.Rows[i]["ID"].ToString()) + "").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        return Json(new { success = false, message = "该部门下有传感器，无法删除！" });
                    }
                }
            }
            if (bll.UpdateFlagList(id))
            {
                return Json(new { success = true, message = "删除成功！" });
            }
            else
            {
                return Json(new { success = false, message = "删除失败！" });
            }
        }
        [HttpPost]
        [ExceptionFilter(IsAjax = true)]
        public JsonResult Edit(m_DeptEntity entity)
        {
            entity.i_Flag = 0;
            if (entity.ID == 0)
            {
                List<m_DeptEntity> list = bll.GetModelList(" i_Flag=0 and ( vc_Name='" + entity.vc_Name + "' or vc_Code='" + entity.vc_Code + "')");
                if (list.Count > 0)
                {
                    return Json(new { success = false, message = "名称或编码已存在！" });
                }
                if (bll.Add(entity) > 0)
                {
                    return Json(new { success = true, message = "添加成功！" });
                }
                else
                {
                    return Json(new { success = true, message = "添加失败！" });
                }
            }
            else
            {
                List<m_DeptEntity> list = bll.GetModelList(" i_Flag=0 and id<>" + entity.ID + " and ( vc_Name='" + entity.vc_Name + "' or vc_Code='" + entity.vc_Code + "')");
                if (list.Count > 0)
                {
                    return Json(new { success = false, message = "名称或编码已存在！" });
                }
                if (bll.Update(entity))
                {
                    return Json(new { success = true, message = "修改成功！" });
                }
                else
                {
                    return Json(new { success = true, message = "修改失败！" });
                }
            }
        }

        /// <summary>
        /// 递归添加数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<TreeGridItem> InitTree(List<m_DeptEntity> list, bool recursion)
        {
            List<TreeGridItem> nodes = new List<TreeGridItem>();
            TreeGridItem node;
            foreach (m_DeptEntity entity in list)
            {
                node = new TreeGridItem();
                node.id = entity.ID;
                node.vc_Code = entity.vc_Code;
              
                node.vc_Name = entity.vc_Name;
                node.text = entity.vc_Name;
                node.vc_Memo = entity.vc_Memo;
                node.ParentDeptID = entity.ParentDeptID;
                List<m_DeptEntity> children = bll.GetModelList(string.Format("i_Flag=0 and ParentDeptID={0}", entity.ID) + " ");
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
            public int id { get; set; }
            public string vc_Code { get; set; }
            public string text { get; set; }
            public string vc_Name { get; set; }
            public int i_Sort { get; set; }
            public string vc_Memo { get; set; }
            public bool leaf { get; set; }
            public int? ParentDeptID { get; set; }
            public List<TreeGridItem> children { get; set; }

        }
    }
}
