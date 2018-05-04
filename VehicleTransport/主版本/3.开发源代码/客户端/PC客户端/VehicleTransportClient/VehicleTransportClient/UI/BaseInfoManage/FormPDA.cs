using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Common.Enum;
using BLL=DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
using VehicleTransportClient.Com;
using Common.MessageBoxEx;
using DevComponents.AdvTree;

namespace VehicleTransportClient
{
    public partial class FormPDA : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_PDA _model = new DB_VehicleTransportManage.Model.m_PDA();
        BLL.m_PDA bllPda = new BLL.m_PDA();
        BLL.v_PDA bllvpda = new BLL.v_PDA();
        BLL.m_Department bllDepartment = new BLL.m_Department();
        public FormPDA(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_PDA model)
        {
            InitializeComponent();
            _type = type;
            InitCmbDuty();
            switch (type)
            {
                case OperateTypeEnum.Add:
                    this.FormTitle = "增加";
                    btnOK.Text = "添加";
                    break;
                case OperateTypeEnum.Edit:
                    this.FormTitle = "修改";
                    this._model = model;
                    btnOK.Text = "修改";
                    ShowModel();
                    break;
                default:
                    break;
            }
            cmbDept.Nodes[0].Expand();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetModel();
            }
            catch (Exception ex)
            {
                Common.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_type == OperateTypeEnum.Add)
            {
                if (bllPda.GetModelList(" i_flag=0 and vc_Code='" + _model.vc_Code+"'").Count > 0)
                {
                    MessageBoxEx.Show("PDA编号【" + _model.vc_Code + "】 已经存在", "编辑失败", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                    return;
                }

                if (bllPda.GetModelList(" i_flag=0 and vc_MacAddress='" + _model.vc_MacAddress +"'").Count > 0)
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("MAC地址 【" + _model.vc_MacAddress + "】 已经存在", "添加失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                _model.ID=bllPda.Add(_model);
                if (_model.ID > 0)
                {
                    List<Model.v_PDA> listpda=bllvpda.GetModelList("id=" + _model.ID);
                    //Pub.GisManage.AddFeature(EnumLayerName.手机, listpda[0], true);
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Add, "PDA名称", "Mac地址:"+_model.vc_MacAddress);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (_type == OperateTypeEnum.Edit)
            {
                List<DB_VehicleTransportManage.Model.m_PDA> lstUser =bllPda.GetModelList(" i_flag=0 and  vc_MacAddress ='" + _model.vc_MacAddress +
                                                                             "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("MAC地址【" + _model.vc_MacAddress + "】 已经存在", "编辑失败", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                List<DB_VehicleTransportManage.Model.m_PDA> lstPdaCode =
                  bllPda.GetModelList(" i_flag=0 and  vc_Code ='" + _model.vc_Code +
                                                                           "'");
                if (lstPdaCode.Count > 0)
                {
                    if (lstPdaCode[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("PDA编号【" + _model.vc_Code + "】 已经存在", "编辑失败", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                if ((new DB_VehicleTransportManage.BLL.m_PDA()).Update(_model))
                {
                    List<Model.v_PDA> listpda = bllvpda.GetModelList("id=" + _model.ID);
                    //Pub.GisManage.ModifyFeature(EnumLayerName.手机, listpda[0], true);
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "PDA名称", "Mac地址:" + _model.vc_MacAddress);
                    this.Close();
                }
                else
                {
                    MessageBoxEx.Show("编辑失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void GetModel()
        {
            string strReg = "[0-9a-fA-F]{2}[0-9a-fA-F]{2}[0-9a-fA-F]{2}[0-9a-fA-F]{2}[0-9a-fA-F]{2}[0-9a-fA-F]{2}";
            Regex r = new Regex(strReg); //定义一个Regex对象实例
            _model.i_Flag = 0;
            _model.vc_Code = txtCode.Text.Trim();
            if (txtCode.Text.Trim().Length == 0)
            {
                txtCode.Focus();
                throw new Exception("PDA编号不可以为空！");
            }
            if (_model.vc_Code.IndexOf("'") >= 0)
            {
                txtCode.Focus();
                throw new Exception("PDA编号中不可以有特殊字符！");
            }


            MatchCollection mc = r.Matches(txtMacAddress.Text.Trim());
            if (mc.Count > 0 && txtMacAddress.Text.Trim().Length==12)
                _model.vc_MacAddress = mc[0].Value.ToUpper();
            else
            {
                throw new Exception("请输入指定格式的MAC地址，例如：8C7B9D435089");
            }

            if (cmbDept.SelectedNode != null && ((Myobj)cmbDept.SelectedNode.Tag).Id!=0)
            {
                _model.DepartmentID = ((Myobj)cmbDept.SelectedNode.Tag).Id;
            }
            else
            {
                throw new Exception("请选择所属部门！");
            }
            _model.vc_Memo = txtMemo.Text.Trim();
            if (_model.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符！");
            }

        }

        private void ShowModel()
        {
            GetNode((int)_model.DepartmentID, cmbDept.Nodes[0]);
            txtMacAddress.Text = _model.vc_MacAddress;
            txtMemo.Text = _model.vc_Memo;
            txtCode.Text = _model.vc_Code;
        }
        public void InitCmbDuty()
        {
            Myobj obj = new Myobj();
            obj.Id = 0;
            obj.Vc_Name = "==请选择所属部门==";
            Node node1 = new Node();
            node1.Text = obj.Vc_Name;
            node1.Tag = obj;
            cmbDept.Nodes.Add(node1);
            LoadCmboTree(node1);
        }

        public void LoadCmboTree(Node nd)
        {
            DataSet ds = new DataSet();
            ds = bllDepartment.GetList(" i_Flag=0 and ParentID=" + ((Myobj)nd.Tag).Id);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Myobj obj = new Myobj();
                obj.Id = int.Parse(dt.Rows[i]["ID"].ToString());
                obj.Vc_Name = dt.Rows[i]["vc_Name"].ToString();
                Node node1 = new Node();
                node1.Text = obj.Vc_Name;
                node1.Tag = obj;
                nd.Nodes.Add(node1);
                LoadCmboTree(node1);
            }
        }

        private void GetNode(int id, Node pNode)
        {
            foreach (Node node in pNode.Nodes)
            {
                if (((Myobj)node.Tag).Id == id)
                {
                    cmbDept.SelectedNode = node;
                    break;
                }
                GetNode(id, node);

            }
        }

      

    }
}
