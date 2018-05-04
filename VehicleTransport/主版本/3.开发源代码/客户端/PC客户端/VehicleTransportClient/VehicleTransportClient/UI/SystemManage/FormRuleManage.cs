using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Forms;
using Common.Enum;
using Common.MessageBoxEx;
using BLL=DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
using DevComponents.AdvTree;
using VehicleTransportClient.Com;

namespace VehicleTransportClient
{

    public partial class FormRuleManage : Form
    {
        private string _tableName = "FormRuleManage";
        private int _selectIndex = -1;
        private Model.m_Rule _model = new Model.m_Rule();
        private BLL.m_Rule bllRule = new BLL.m_Rule();
        private BLL.m_RuleDetail bllRuleDetail = new BLL.m_RuleDetail();
        private BLL.m_User bllUser = new BLL.m_User();
        List<string> checkBoxList = new List<string>();
        FormMain formMain;
        public FormRuleManage(Form frmmain)
        {
            InitializeComponent();
            formMain = (FormMain)frmmain;
        }

        private void FormRuleManage_Load(object sender, EventArgs e)
        {
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            LoadData();
            GisMapEdit.CheckBoxVisible = true;
            GisMapEdit.Tag = "GisMapEdit";
            GetNode();
            tvModule.ExpandAll();
        }
        public void GetNode()
        {
            foreach (Node node in formMain.advTree.Nodes)
            {
                Node node1 = node.Copy();
                node1.CheckBoxVisible = true;
                tvModule.Nodes.Add(node1);
                foreach (Node node2 in node.Nodes)
                {
                    Node node3 = node2.Copy();
                    node1.Nodes.Add(node3);
                    node3.CheckBoxVisible = true;
                }
            }
        }
        private void LoadData()
        {
            dgvList.Rows.Clear();
            List<DB_VehicleTransportManage.Model.m_Rule> rules = bllRule.GetModelList(" i_Flag = 0");
            if (rules != null && rules.Count > 0)
            {
                try
                {
                    foreach (DB_VehicleTransportManage.Model.m_Rule rule in rules)
                    {
                        this.dgvList.Rows.Add(rule.vc_Name, rule.vc_Memo);
                        this.dgvList.Rows[this.dgvList.Rows.Count - 1].Tag = rule;
                    }
                }
                catch (Exception ee)
                {

                }
            }
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void tbnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Node node in tvModule.Nodes)
            {
                node.Checked = true;
                foreach (Node childnode in node.Nodes)
                {
                    childnode.Checked = true;
                }
            }
        }

        private void tbnNoSelect_Click(object sender, EventArgs e)
        {
            foreach (Node node in tvModule.Nodes)
            {
                node.Checked = false;
                foreach (Node childnode in node.Nodes)
                {
                    childnode.Checked = false;
                }
            }
        }

        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            //Bestway.Windows.Forms.ProgressBarForm progressBarForm=new ProgressBarForm();
            if (_selectIndex >= 0)
            {
                //progressBarForm.Show();
                _model = (DB_VehicleTransportManage.Model.m_Rule)dgvList.Rows[_selectIndex].Tag;
                if (bllRuleDetail.DeleteAll(_model.ID))
                {
                    checkBoxList.Clear();
                    GetCheckedNode(tvModule.Nodes);
                    foreach (string strCheck in checkBoxList)
                    {
                        if (bllRuleDetail.InsertRuleDetail(_model.ID, strCheck))
                        {
                            OperationLog.InsertSqlLog(EnumActionType.Add, "角色保存", "角色名称:" + bllRule.GetName(_model.ID) + "模块名称:" + _model.vc_Name);
                        }
                        else
                        {
                            MessageBoxEx.Show("保存失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    //progressBarForm.Hide();
                    MessageBoxEx.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBoxEx.Show("保存失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBoxEx.Show("请选择要保存的角色", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            

        }
    
        private void dgvRule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
            tbnNoSelect_Click(sender, null);
            try
            {
                GetDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace.ToString());
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormRule(Com.OperateTypeEnum.Add, null).ShowDialog();
            LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Rule)dgvList.Rows[_selectIndex].Tag;

                 

                if (MessageBoxEx.Show("确认要删除角色 【" + _model.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (bllUser.IsRuleUsed(_model.ID))
                    {
                        MessageBoxEx.Show("当前角色已被使用，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    _model.i_Flag = 1;
                    if ((new DB_VehicleTransportManage.BLL.m_Rule()).Update(_model))
                    {
                        MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //DB.BLL.m_SystemLog.WriteLog(Global.Params.PersonModel.PersonID, DB.Model.EnumLogAction.Delete, "删除隐患类型", "删除了隐患类型:" + _listUnSageLevel[_selectIndex].vc_Name);
                        //Pub.GisManage.DeleteFeature(Com.EnumLayerName.车辆, _model.ID);
                        OperationLog.InsertSqlLog(EnumActionType.Add, "角色名称", _model.vc_Name);
                        LoadData();

                    }
                    else
                    {
                        MessageBoxEx.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBoxEx.Show("请选择要删除的角色", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Rule)dgvList.Rows[_selectIndex].Tag;
                new FormRule(Com.OperateTypeEnum.Edit, _model).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的角色", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /// <summary>刷新
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>Grid样式设置
        /// Grid样式设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();

            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }

        /// <summary>取消节点选中状态之后，取消所有父节点的选中状态
        /// 取消节点选中状态之后，取消所有父节点的选中状态
        /// </summary>
        /// <param name="currNode"></param>
        /// <param name="state"></param>
        private void setParentNodeCheckedState(Node currNode, bool state)
        {
            Node parentNode = currNode.Parent;
            parentNode.Checked = state;
            if (currNode.Parent.Parent != null)
            {
                setParentNodeCheckedState(currNode.Parent, state);
            }
        }

        /// <summary>节点选中之后，选中节点的所有子节点状态
        /// 节点选中之后，选中节点的所有子节点状态
        /// </summary>
        /// <param name="currNode"></param>
        /// <param name="state"></param>
        private void setChildNodeCheckedState(Node currNode, bool state)
        {
            NodeCollection nodes = currNode.Nodes;
            if (nodes.Count > 0)
            {
                foreach (Node tn in nodes)
                {
                    tn.Checked = state;
                    setChildNodeCheckedState(tn, state);
                }
            }
        }

        /// <summary>节点选中后，判断父节点是否需要选中
        /// 节点选中后，判断父节点是否需要选中
        /// </summary>
        /// <param name="currNode"></param>
        private void setParrentNodeCheckedTrue(Node currNode)
        {
            bool bAllChecked = false;
            if (currNode.Parent != null)
            {
                foreach (Node tn in currNode.Parent.Nodes)
                {
                    if (!tn.Checked)//有节点未选中
                        bAllChecked = true;
                }
                if (!bAllChecked)//节点全部选中
                {
                    currNode.Parent.Checked = true;
                    setParrentNodeCheckedTrue(currNode.Parent);
                }
            }

        }

         //<summary>节点选中后操作
         //节点选中后操作
         //</summary>
         //<param name="sender"></param>
         //<param name="e"></param>
        private void tvModule_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            if (e.Action == eTreeAction.Mouse)
            {
                DevComponents.AdvTree.Node pnode = tvModule.GetNodeAt(e.Cell.Bounds.Location.X, e.Cell.Bounds.Location.Y);
                // textBox1.Text = e.Node.Text;
                if (pnode.Checked)
                {
                    //节点选中之后，所有父节点的选中状态
                    setChildNodeCheckedState(pnode, true);
                    setParrentNodeCheckedTrue(pnode);
                }
                else
                {
                    //取消节点选中状态之后，取消所有父节点的选中状态
                    setChildNodeCheckedState(pnode, false);
                    //如果节点存在父节点，取消父节点的选中状态
                    if (pnode.Parent != null)
                    {
                        setParentNodeCheckedState(pnode, false);
                    }
                }
            }
        }

        /// <summary>获取TreeView选中状态
        /// 获取TreeView选中状态
        /// </summary>
        /// <param name="tnc"></param>
        public void GetCheckedNode(NodeCollection tnc)
        {
            foreach (Node node in tnc)
            {
                //if (node.Checked && node.Nodes.Count == 0)
                if (node.Checked)
                {
                    if (node.Tag != null)
                    {
                        checkBoxList.Add(node.Tag.ToString());
                    }
                    else
                    {
                        checkBoxList.Add("");
                    }

                }
                GetCheckedNode(node.Nodes);
            }

        }

        /// <summary>根据选中的角色，设置TreeView选中状态
        /// 根据选中的角色，设置TreeView选中状态
        /// </summary>
        /// <param name="tnc"></param>
        /// <param name="vc_ModuleName"></param>
        public void SetCheckedNode(NodeCollection tnc, string vc_ModuleName)
        {
            foreach (Node node in tnc)
            {
                //if ((!node.Checked) && node.Nodes.Count == 0)
                if (!node.Checked)
                {
                    if (node.Tag != null)
                    {
                        if (node.Tag.ToString() == vc_ModuleName)
                        {
                            node.Checked = true;
                            break;
                        }
                    }


                }

                SetCheckedNode(node.Nodes, vc_ModuleName);
            }

        }

        /// <summary>获取数据库中角色的选择状态，设置TreeView状态
        /// 获取数据库中角色的选择状态，设置TreeView状态
        /// </summary>
        public void GetDetails()
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Rule)dgvList.Rows[_selectIndex].Tag;
                List<DB_VehicleTransportManage.Model.m_RuleDetail> list =
                    bllRuleDetail.GetModelList("i_Flag=0 and ruleID=" + _model.ID);

                foreach (DB_VehicleTransportManage.Model.m_RuleDetail model in list)
                {
                    SetCheckedNode(tvModule.Nodes, model.vc_ModuleName);
                }
            }
        }

        
    }
}
