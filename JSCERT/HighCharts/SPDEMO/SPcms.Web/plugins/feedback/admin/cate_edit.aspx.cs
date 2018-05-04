using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SPcms.Common;

namespace SPcms.Web.Plugin.Feedback.admin
{
    public partial class cate_edit : SPcms.Web.UI.ManagePage
    {
        public string action = SPEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = SPRequest.GetQueryString("action");

            if (!string.IsNullOrEmpty(_action) && _action == SPEnums.ActionEnum.Edit.ToString())
            {
                this.action = SPEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = SPRequest.GetQueryInt("id", 0);
                if (this.id < 1)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.feedback_cate().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {

                if (action == SPEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
                if (_action == SPEnums.ActionEnum.View.ToString()) //修改
                {
                    this.action = SPEnums.ActionEnum.View.ToString();
                    this.id = SPRequest.GetQueryInt("id", 0);

                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.feedback_cate bll = new BLL.feedback_cate();
            Model.feedback_cate model = bll.GetModel(_id);

            txtcate.Text = model.name;

        }




        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.feedback_cate model = new Model.feedback_cate();
            BLL.feedback_cate bll = new BLL.feedback_cate();

            model.name = txtcate.Text.Trim();

            int mid = bll.Add(model);
            if (mid > 0)
            {
                AddAdminLog(SPEnums.ActionEnum.Add.ToString(), "添加留言类别：" + model.name); //记录日志
                result = true;
            }
            return result;
          
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            Model.feedback_cate model = new Model.feedback_cate();
            BLL.feedback_cate bll = new BLL.feedback_cate();
            model.id = _id;
            model.name = txtcate.Text.Trim();

            bool mid = bll.Update(model);
            if (mid)
            {
                AddAdminLog(SPEnums.ActionEnum.Add.ToString(), "修改留言类别：" + model.name); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == SPEnums.ActionEnum.Edit.ToString()) //修改
            {
              
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改成功！", "cate_list.aspx", "Success");
            }
            else //添加
            {
               
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加成功！", "cate_list.aspx", "Success");
            }
        }



    }
}