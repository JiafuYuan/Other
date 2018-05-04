using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL=DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
using VehicleTransportClient.UI;
namespace VehicleTransportClient.Com
{
    public partial class InputDialog : Form
    {
        TextBox _textBox;
        private BLL.m_Department bllDept = new BLL.m_Department();
        private BLL.m_User bllUser = new BLL.m_User();
        private BLL.m_Person bllPerson = new BLL.m_Person();

        public InputDialog()
        {
            InitializeComponent();
        }

        private void InputDialog_LocationChanged(object sender, EventArgs e)
        {
            SetDialogLocation();
        }
        public void Init(TextBox textBox)
        {
            _textBox = textBox;
            Form frm=_textBox.FindForm();
            SetControlsClickEvent(frm.Controls);
            this.Width = _textBox.Width;
            advTree1.Nodes.Clear();
            SetTree();
            
        }

        /// <summary>
        /// 加载控件的Click事件
        /// </summary>
        /// <param name="cc"></param>
        private void SetControlsClickEvent(Control.ControlCollection cc)
        {
            foreach (Control item in cc)
            {
                if (item.Controls.Count > 0)
                {
                    SetControlsClickEvent(item.Controls);
                }
                if (item.Name != this._textBox.Name)
                    item.Click += new EventHandler(InputPromptForm_Click);
            }
        }
        void InputPromptForm_Click(object sender, EventArgs e)
        {
            btnok_Click(sender, e);

        }
        private void SetTree()
        {
            List<Model.m_Department> listdept = bllDept.GetModelList("i_Flag=0");
            List<Model.m_Department> parentdept=(from m_dept in listdept 
                                                     where m_dept.ParentID==0
                                                     select m_dept).ToList<Model.m_Department>();
            DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
            node.Text = "请选择用户信息";
            NodeTag nodeclass = new NodeTag();
            nodeclass.id = 0;
            nodeclass.nodetype = -1;
            node.Tag = nodeclass;
            advTree1.Nodes.Add(node);
            for (int i = 0; i < parentdept.Count; i++)
            {
                SetChildTree(parentdept[i].ID, ref node, parentdept[i].vc_Name);
            }
            advTree1.Nodes[0].Expand();
        }
        private void SetChildTree(int deptid, ref DevComponents.AdvTree.Node parennode,string deptname)
        {

            DataTable dt = bllPerson.GetUserinfo("a.DepartmentID="+deptid.ToString());
            DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node();
            List<Model.m_Department> childlist = bllDept.GetModelList("i_flag=0 and ParentID=" + deptid.ToString());
            string childdeptid = "0";
            foreach (Model.m_Department dept in childlist)
            {
                childdeptid = childdeptid + "," + dept.ID;
            }
          
            DataTable dt2 = bllPerson.GetUserinfo("a.DepartmentID in (" + childdeptid + ")");
            if (dt.Rows.Count > 0 || dt2.Rows.Count > 0)
            {
                node.Text = deptname;
                node.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                node.CheckBoxVisible = true;
                NodeTag tagclass = new NodeTag();
                tagclass.id = deptid;
                tagclass.nodetype = 1;
                node.Tag = tagclass;
                parennode.Nodes.Add(node);
            }
            else
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DevComponents.AdvTree.Node node1 = new DevComponents.AdvTree.Node();
                node1.Text = dt.Rows[i]["vc_Name"].ToString();
                node1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                node1.CheckBoxVisible = true;
                NodeTag tagclass = new NodeTag();
                tagclass.id = int.Parse(dt.Rows[i]["ID"].ToString());
                tagclass.nodetype = 0;
                node1.Tag = tagclass;
                node.Nodes.Add(node1);
            }
            for (int i = 0; i < childlist.Count; i++)
            {
                SetChildTree(childlist[i].ID, ref node, childlist[i].vc_Name);
            }
        }
        public void SetDialogLocation()
        {
            Point p = _textBox.PointToScreen(_textBox.Location);
          
            this.Left = p.X - _textBox.Left - 2;
            this.Top = p.Y - _textBox.Top + _textBox.Height - 2;

            if ((this.Left + this.Width) > Screen.PrimaryScreen.WorkingArea.Width)
            {
                this.Left = this.Left - (this.Width - _textBox.Width);
            }
        }
        private void advTree1_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Node.Checked == true)
            {
                SetNodeChecked(e.Node, true);
            }
            else
            {
                SetNodeChecked(e.Node, false);
            }
        }
        private void SetNodeChecked(DevComponents.AdvTree.Node node,bool ischecked)
        {
                foreach (DevComponents.AdvTree.Node node1 in node.Nodes)
                {
                    node1.Checked = ischecked;
                    if (node1.Nodes.Count > 0)
                    {
                        SetNodeChecked(node1,ischecked);
                    }
                }
        }

        public void btnok_Click(object sender, EventArgs e)
        {
            List<Model.m_User> listuser = new List<Model.m_User>();
            foreach(DevComponents.AdvTree.Node node in advTree1.Nodes)
            {
                GetUse(ref listuser, node);
            }
            string name="";
            for(int i=0;i<listuser.Count;i++)
            {
                name=name+","+listuser[i].vc_Name;
            }
            if (!string.IsNullOrEmpty(name))
            {
                name=name.Remove(0,1);
            }
            this.Hide();
            if (OnTextChangedEx != null)
            {
                OnTextChangedEx(null, new TextChanagedEventArgs(true, name, listuser, null));
            }
            
        }
        private void GetUse(ref List<Model.m_User> listinfo, DevComponents.AdvTree.Node node)
        {
            NodeTag tag = (NodeTag)node.Tag;
            if (tag.nodetype == 0 && node.Checked)
            {
                Model.m_User user = new Model.m_User();
                user.ID = tag.id;
                user.vc_Name = node.Text;
                listinfo.Add(user);
                return;
            }
            else
            {
                if (node.Nodes.Count > 0)
                {
                    foreach (DevComponents.AdvTree.Node node1 in node.Nodes)
                    {
                        GetUse(ref listinfo, node1);
                    }
                }
            }
        }

        #region 公有事件
        public delegate void TextChangedEx(object sender, TextChanagedEventArgs e);
        public event TextChangedEx OnTextChangedEx;

        /// <summary>选择数据事件参数</summary>
        public class TextChanagedEventArgs : EventArgs
        {
            public bool IsFind { get; set; }//是否选中
            /// <summary>被操作绑定的对象</summary>
            public string  Showinfo { get; set; }
            public object SourceData { get; set; }
            public DataRow SelectedRow { get; set; }

            public TextChanagedEventArgs(bool isFind, string showinfo, object source, DataRow selectRow)
            {
                this.IsFind = isFind;
                this.Showinfo = showinfo;
                this.SourceData = source;
                this.SelectedRow = selectRow;
            }
        }
        #endregion   

    }
    class NodeTag
    {
        /// <summary>
        /// 1:部门;0:用户;-1:其他
        /// </summary>
        public int nodetype;
        public int id;
    }

}
