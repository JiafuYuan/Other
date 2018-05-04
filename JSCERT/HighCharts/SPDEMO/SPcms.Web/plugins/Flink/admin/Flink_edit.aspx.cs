using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPcms.Common;
using System.Reflection;

namespace SPcms.Web.Plugin.FLink.admin
{
    public partial class Flink_edit : SPcms.Web.UI.ManagePage
    {
        private string action = SPEnums.ActionEnum.Add.ToString(); //操作类型
        private static string  id ="";
        BLL.Flink bll = new BLL.Flink();
        protected FieldInfo[] fields = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            SPcms.Common.InitJs.initJavascript();
            string _action = SPRequest.GetQueryString("action");
         
       
            //判断数据库有数据没有 只允许有一条， 如果存在则修改
        
            Type type = typeof(SPcms.Common.SPEnums.Sitetype);
            fields = type.GetFields();
            if (bll.GetAllList().Tables[0].Rows.Count > 0)
            {
                ClientScript.RegisterClientScriptBlock(Page.GetType(), "", "alert('只允许添加一条信息')", true);
              //  JscriptMsg("只允许添加一条信息！", "index.aspx", "Error");
                return;
                //  _action = SPEnums.ActionEnum.Edit.ToString();//修改类型 
            }
            if (!Page.IsPostBack)
            {
                id = Guid.NewGuid().ToString().Replace("-", "");
                code.Value = id;
                DoAdd();
                //添加行业分类
           
                //for (int i = 1; i < fields.Length; i++)
                //{
                //    if (fields[i].Name != "基础字段")
                //    {
                //        //drpcode.Items.Add(fields[i].Name);
                //        //cbltfcode1.Items.Add(fields[i].Name);
                //        //cbltfcode.Items.Add(fields[i].Name);
                //    }
                //}
                ChkAdminLevel("plugin_Flink", SPEnums.ActionEnum.View.ToString()); //检查权限
                //if (action == SPEnums.ActionEnum.Edit.ToString()) //修改
                //{
                //    ShowInfo(id);
                //}
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
         
            //Model.Flink model = bll.GetModel(_id,true);
            //hfid.Value = model.id;
            //for (int k = 0; k < drpcode.Items.Count; k++)
            //{
            //    if (drpcode.Items[k].ToString() == model.Flinkcode.Trim())
            //    {
            //        drpcode.Items[k].Selected = true;
            //    }
            //}
           
            //txtFlinkname.Text = model.Flinkname;
            //rblstat.SelectedValue = model.Flinkstat.ToString();
            //txtFlinkurl.Text = model.Flinkurl;
            //txtcontent.Value = model.Flinktfcontent;
            //if (model.FlinktfCode != "")
            //{
            //    string[] arr = model.FlinktfCode.Split('|');
            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        for (int j = 0; j < cbltfcode.Items.Count; j++)
            //        {
            //            if (cbltfcode.Items[j].ToString() == arr[i].ToString())
            //            {
            //                cbltfcode.Items[j].Selected=true;
            //            }
            //        }
            //    }
            //}

        }
        #endregion

        //#region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.Flink model = new Model.Flink();
            BLL.Flink bll = new BLL.Flink();
            model.id =id;
            model.Faddtime = DateTime.Now;
            model.Flinkcode ="";
            model.Flinkname ="";
            model.Flinkstat = 0;
           
         
      
            model.FlinktfCode ="";
            model.Flinktfcontent = getcontent(id);
            model.Flinktfnum = 0;
            model.Flinkurl ="";
            model.Fupdatetime = DateTime.Now;
            if (bll.Add(model) > 0)
            {
                AddAdminLog(SPEnums.ActionEnum.Add.ToString(), "添加站外链接：" + model.Flinkname); //记录日志
                result = true;
            }
            return result;
        }

        private string getcontent(string id)
        {
            return "<script type=\"text/javascript\" src=\"http://{config.remoturl}/Flink_js.ashx?id=" + id + "&flag=1\"></script>";
        }

     
        //#endregion

        //#region 修改操作=================================
        //private bool DoEdit(int _id)
        //{
        //    //bool result = false;
           
        //    //Model.Flink model = new Model.Flink();
        //    //BLL.Flink bll = new BLL.Flink();
        //    //model.Faddtime = DateTime.Now;
        //    //model.Flinkcode = drpcode.SelectedValue;
        //    //model.Flinkname = txtFlinkname.Text;
        //    //model.Flinkstat = Int32.Parse(rblstat.SelectedValue);
        //    //string tfcode = "";
        //    //for (int i = 0; i < cbltfcode.Items.Count; i++)
        //    //{
        //    //    if (cbltfcode.Items[i].Selected)
        //    //    {
        //    //        tfcode += cbltfcode.Items[i].Value + "|";
        //    //    }
        //    //}
        //    //tfcode = tfcode.TrimEnd('|');
        //    //model.FlinktfCode = tfcode.ToString();
        //    //model.Flinktfcontent = txtcontent.Value;
        //    //model.Flinktfnum = 0;
        //    //model.Flinkurl = txtFlinkurl.Text;
        //    //model.Fupdatetime = DateTime.Now;
        //    //model.id = hfid.Value;
        //    //if(bll.Update(model))
        //    //{
        //    //    AddAdminLog(SPEnums.ActionEnum.Edit.ToString(), "修改站外链接：" + model.Flinkname); //记录日志
        //    //    result = true;
        //    //}

        //    //return result;
        //}
        //#endregion

        ////保存
        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    //if (action == SPEnums.ActionEnum.Edit.ToString()) //修改
        //    //{
        //    //    ChkAdminLevel("plugin_Flink", SPEnums.ActionEnum.Edit.ToString()); //检查权限
        //    //    if (!DoEdit(id))
        //    //    {
        //    //        JscriptMsg("保存过程中发生错误！", "", "Error");
        //    //        return;
        //    //    }
        //    //    JscriptMsg("修改链接成功！", "index.aspx", "Success");
        //    //}
        //    //else //添加
        //    //{
        //    //    ChkAdminLevel("plugin_Flink", SPEnums.ActionEnum.Add.ToString()); //检查权限
        //    //    if (!DoAdd())
        //    //    {
        //    //        JscriptMsg("保存过程中发生错误！", "", "Error");
        //    //        return;
        //    //    }
        //    //    JscriptMsg("添加链接成功！", "index.aspx", "Success");
        //    //}
        //}

    }
}