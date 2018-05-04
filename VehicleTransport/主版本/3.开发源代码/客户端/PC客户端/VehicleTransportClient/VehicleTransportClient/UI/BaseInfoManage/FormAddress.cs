using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bestway.Windows.Controls;
using Common.Enum;
using DB_VehicleTransportManage;
using DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;
using DevComponents.AdvTree;
using Common.MessageBoxEx;
using Model = DB_VehicleTransportManage.Model;
using BLL = DB_VehicleTransportManage.BLL;

namespace VehicleTransportClient
{
    public partial class FormAddress : Common.frmBase
    {
        private OperateTypeEnum _type;
        private Model.v_Address _model = new Model.v_Address();
        private Model.m_Localizer _modeLocalizer = new Model.m_Localizer();
        private BLL.v_Kj222Localizer bllViewKj222Localizer = new v_Kj222Localizer();
        private BLL.m_Localizer bllLocalizer = new m_Localizer();
        private BLL.v_Address bllAddress = new v_Address();
        Bestway.Windows.Controls.InputPromptDialog inputPromptDialogDirectionLocalizer = new InputPromptDialog();
        private int _inputDirectionLocalizerID = 0;
        private BLL.m_Area bllArea = new m_Area();

        public FormAddress(OperateTypeEnum type, DB_VehicleTransportManage.Model.v_Address model)
        {
            InitializeComponent();
            _type = type;
            InitLocalizer();
            InitCmbArea();
            cmbArea.SelectedIndex = 0;
            cmbLocation.SelectedIndex = 0;
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
                    ShowModelKj222();
                    break;
                default:
                    break;
            }
            cmbArea.Nodes[0].Expand();//全部展开ComBoTree
            inputPromptDialogDirectionLocalizer.HideForm();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetModel();
                GetModelKj222();
            }
            catch (Exception ex)
            {
                Common.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_type == OperateTypeEnum.Add)
            {
                //判断基站是否存在
                if (bllAddress.GetModelList(" i_flag=0 and vc_Name='" + _model.vc_Name + "'").Count > 0)
                {
                    MessageBoxEx.Show("基站名称 【" + _model.vc_Name + "】 已存在", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                //判断KJ222基站是否存在
                if (bllLocalizer.GetModelList(" i_flag=0 and vc_Code='" + _modeLocalizer.vc_Code + "'").Count > 0)
                {
                    MessageBoxEx.Show("基站编号 【" + _modeLocalizer.vc_Code + "】 已存在", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            
                //判断KJ222基站是否存在
                if (Pub.IsKj602)
                {
                    if ( bllLocalizer.GetModelList(" i_flag=0 and i_hid=" + _modeLocalizer.i_HID + " and i_parenthid =" +
                                                  _modeLocalizer.i_ParentHID).Count > 0)
                    {
                        MessageBoxEx.Show("对应主站HID,和子站HID的基站已存在", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                else
                {
                    if (bllLocalizer.GetModelList(" i_flag=0 and i_hid=" + _modeLocalizer.i_HID ).Count > 0)
                    {
                        MessageBoxEx.Show("对应HID的基站已存在", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                bool bState = true;
                DB.OleDbHelper.BeginTransaction();
                int i = bllLocalizer.Add(_modeLocalizer);
                if (i > 0)
                {
                    _model.LocalizerStationID = i;
                    _model.ID = bllAddress.Add(_model);
                    if (_model.ID > 0)
                    {
                       
                        OperationLog.InsertSqlLog(EnumActionType.Add, "基站名称", _model.vc_Name);
                        bState = true;
                    }
                    else
                    {
                        bState = false;
                        MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    bState = false;

                }
                if (bState)
                {
                    DB.OleDbHelper.Commit();
                    Model.m_Address entity = new Model.m_Address();
                    entity.ID = _model.ID;
                    entity.LocalizerStationID = _model.LocalizerStationID;
                    entity.vc_Name = _model.vc_Name;
                    Pub.GisManage.AddFeature(EnumLayerName.定位基站, entity, true);
                    Pub.GisManage.UpdataGisAndDBRemark();
                    Pub.GISForm.LoadGrid();
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                else
                {
                    DB.OleDbHelper.Rollback();
                    MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (_type == OperateTypeEnum.Edit)
            {
                _modeLocalizer.ID = (int)_model.LocalizerStationID;
                List<DB_VehicleTransportManage.Model.v_Address> lstUser = bllAddress.GetModelList(" i_flag=0 and  vc_Name='" + _model.vc_Name + "'");
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("基站名称【" + _model.vc_Name + "】 已经存在", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                List<DB_VehicleTransportManage.Model.m_Localizer> lstlLocalizers = bllLocalizer.GetModelList(" i_flag=0 and  vc_Code='" + _modeLocalizer.vc_Code + "'");
                if (lstlLocalizers.Count > 0)
                {
                    if (lstlLocalizers[0].ID != _modeLocalizer.ID)
                    {
                        MessageBoxEx.Show("基站编号【" + _modeLocalizer.vc_Code + "】 已经存在", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                //判断KJ222基站是否存在
                if (Pub.IsKj602)
                {
                     lstlLocalizers = bllLocalizer.GetModelList(" i_flag=0 and i_hid=" + _modeLocalizer.i_HID + " and i_parenthid =" +
                                                  _modeLocalizer.i_ParentHID);
                    if (lstlLocalizers.Count > 0)
                    {
                        if (lstlLocalizers[0].ID != _modeLocalizer.ID)
                        {
                            MessageBoxEx.Show("对应主站HID,和子站HID的基站已经存在", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                    }
                   
                }
                else
                {
                     lstlLocalizers = bllLocalizer.GetModelList(" i_flag=0 and i_hid=" + _modeLocalizer.i_HID);
                    if (lstlLocalizers.Count > 0)
                    {
                        if (lstlLocalizers[0].ID != _modeLocalizer.ID)
                        {
                            MessageBoxEx.Show("对应HID的基站已经存在", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                    }
                }
              
                if (bllAddress.Update(_model) && bllLocalizer.Update(_modeLocalizer))
                {
                    Model.m_Address entity = new Model.m_Address();
                    entity.ID = _model.ID;
                    entity.LocalizerStationID = _model.LocalizerStationID;
                    entity.vc_Name = _model.vc_Name;
                    Pub.GisManage.ModifyFeature(EnumLayerName.定位基站, entity, true);
                    Pub.GISForm.LoadGrid();
                    Pub.GisManage.UpdataGisAndDBRemark();
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "基站名称", _model.vc_Name);
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
            _model.i_Flag = 0;
            _model.vc_Name = txtLocalizerName.Text.Trim();
            if (_model.vc_Name.Length == 0)
            {
                txtLocalizerName.Focus();
                throw new Exception("请输入基站名称！");
            }
            if (_model.vc_Name.IndexOf("'") >= 0)
            {
                txtLocalizerName.Focus();
                throw new Exception("基站名称中不可以有特殊字符！");
            }


            if (txtDirectionLocalizer.Text.Length > 0 && _inputDirectionLocalizerID == 0)
            {
                txtDirectionLocalizer.Focus();
                throw new Exception("请选择正确的方向基站！");
            }

            if (chbox.Checked)
            {
                _model.i_IsDirectionStation = 1;
                _model.DirectionLocalizerStationID = 0;
            }
            else
            {
                _model.i_IsDirectionStation = 0;
                if (_inputDirectionLocalizerID > 0)
                {
                    _model.DirectionLocalizerStationID = _inputDirectionLocalizerID;
                }
                else
                {
                    _model.DirectionLocalizerStationID = 0;
                }
            }

            
            if (cmbArea.SelectedNode != null)
            {
                _model.AreaID = ((Myobj)cmbArea.SelectedNode.Tag).Id;
            }
            else
            {
                _model.AreaID = 0;
            }
            if(_model.AreaID == 0)
                throw new Exception("请选择基站所在区域！");
          
                _model.i_IsUpMine = cmbLocation.SelectedIndex;
           


            _model.vc_Memo = txtMemo.Text.Trim();
            if (_model.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符！");
            }

            if (txtDirectionLocalizer.Text == txtLocalizerName.Text)
            {
                txtLocalizerName.Focus();
                throw new Exception("反向基站和基站名称不能相同！");
            }
            if (txtHid.Text.Trim().Length == 0)
            {
                txtHid.Focus();
                throw new Exception("请输入HID！");
            }
            //if (int.Parse(txtHid.Text.Trim()) > 32767)
            //{
            //    txtHid.Focus();
            //    throw new Exception("HID应小于32767！");
            //}
          
        }

        private void ShowModel()
        {
            txtLocalizerName.Text = _model.vc_Name;
            txtDirectionLocalizer.Text = _model.DirectionLocalizerStationID == null ? "" : bllAddress.GetLocalizerStationNamebyLocalizerStationID((int)_model.DirectionLocalizerStationID);
            cmbLocation.Text = _model.i_IsUpMine == 0 ? "井下" : "井上";
            GetNode((int)_model.AreaID, cmbArea.Nodes[0]);
            txtMemo.Text = _model.vc_Memo;
            if (Pub.IsKj602)
            {
                txtChildHID.Text = _model.i_HID.ToString();
                txtHid.Text = _model.i_ParentHID.ToString();
            }
            else
            {
                txtHid.Text = _model.i_HID.ToString();
            }
            if (_model.i_IsDirectionStation == 1)
            {
                chbox.Checked = true;
            }
            else
            {
                chbox.Checked = false;
            }
        }

        /// <summary>
        /// 设置选择的Node节点
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pNode"></param>
        private void GetNode(int id, Node pNode)
        {
            foreach (Node node in pNode.Nodes)
            {
                if (((Myobj)node.Tag).Id == id)
                {
                    cmbArea.SelectedNode = node;
                    break;
                }
                GetNode(id, node);
            }
        }

        //初始化ComboTree
        public void InitCmbArea()
        {
            Myobj obj = new Myobj();
            obj.Id = 0;
            obj.Vc_Name = "==请选择区域==";
            Node node1 = new Node();
            node1.Text = obj.Vc_Name;
            node1.Tag = obj;
            cmbArea.Nodes.Add(node1);
            LoadCmboTree(node1);
        }

        //递归增加Node节点
        public void LoadCmboTree(Node nd)
        {
            DataSet ds = new DataSet();
            ds = bllArea.GetList(" i_Flag=0 and ParentID=" + ((Myobj)nd.Tag).Id);
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

        //初始化基站
        public void InitLocalizer()
        {

            inputPromptDialogDirectionLocalizer.ClearBind();
            DataSet dataSet = bllAddress.DropDownSourceLocalizerStationName(" i_Flag=0 and i_IsDirectionStation=1");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {

                inputPromptDialogDirectionLocalizer.Bind(txtDirectionLocalizer, dataSet.Tables[0], 3, new int[] { 1 });

                inputPromptDialogDirectionLocalizer.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptDialogDirectionLocalizer_OnTextChangedEx);
            }

        }

        void inputPromptDialogDirectionLocalizer_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                _inputDirectionLocalizerID = int.Parse(e.SelectedRow["LocalizerStationID"].ToString());
            }
            else
            {
                _inputDirectionLocalizerID = 0;
            }
        }

        private void txtDirectionLocalizer_Click(object sender, EventArgs e)
        {
            inputPromptDialogDirectionLocalizer.ShowDropDown();
        }

        private void FormAddress_Load(object sender, EventArgs e)
        {
            DB_VehicleTransportManage.BLL.m_SystemConfig bllSystemConfig = new m_SystemConfig();

            if (bllSystemConfig.GetValue( EnumSystemConfigKeys.HaveKJ222Client) != "0")
            {
                txtHid.ReadOnly = true;
                txtChildHID.ReadOnly = true;
                txtCode.ReadOnly = true;
            }
            if (!Pub.IsKj602)
            {
                lblHID.Text = "HID:";
                lblRedChildHID.Visible = false;
                lblChildHID.Visible = false;
                txtChildHID.Visible = false;
            }
        }

        private void txtHid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtChildHID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void GetModelKj222()
        {
            _modeLocalizer.AreaID = 1;
            _modeLocalizer.i_Type = 1;
            _modeLocalizer.i_Flag = 0;
            _modeLocalizer.vc_Code = txtCode.Text.Trim();
            if (_modeLocalizer.vc_Code == "")
            {
                txtCode.Focus();
                throw new Exception("基站编号不可以为空！");
            }
            if (_modeLocalizer.vc_Code.IndexOf("'") >= 0)
            {
                txtCode.Focus();
                throw new Exception("基站编号中不可以有特殊字符！");
            }
            _modeLocalizer.vc_Name = txtLocalizerName.Text.Trim();
            if (_modeLocalizer.vc_Name == "")
            {
                txtLocalizerName.Focus();
                throw new Exception("基站名称不可以为空！");
            }
            if (_modeLocalizer.vc_Name.IndexOf("'") >= 0)
            {
                txtLocalizerName.Focus();
                throw new Exception("基站名称中不可以有特殊字符！");
            }

            if (txtHid.Text.Trim().Length == 0)
            {
                txtHid.Focus();
                throw new Exception("基站HID不可以为空！");
            }
            
          
            if (Pub.IsKj602)
            {
                if (txtChildHID.Text.Trim().Length == 0)
                {
                    txtChildHID.Focus();
                    throw new Exception("子站HID不可以为空！");
                }
                _modeLocalizer.i_ParentHID = int.Parse(txtHid.Text.Trim());
                _modeLocalizer.i_HID = int.Parse(txtChildHID.Text.Trim());
            }
            else
            {
                _modeLocalizer.i_HID = int.Parse(txtHid.Text.Trim());
            }
            //if (_modeLocalizer.i_ParentHID > 32767)
            //{
            //    txtHid.Focus();
            //    throw new Exception("HID应小于32767！");
            //}
            //if (_modeLocalizer.i_HID > 32767)
            //{
            //    txtChildHID.Focus();
            //    throw new Exception("HID应小于32767！");
            //}
         
        }

        private void ShowModelKj222()
        {
            txtCode.Text = _model.vc_Code;
        }

        private void chbox_CheckedChanged(object sender, EventArgs e)
        {
            if (chbox.Checked)
            {
                txtDirectionLocalizer.Visible = false;
                lblDirectionLocalizer.Visible = false;
            }
            else
            {
                txtDirectionLocalizer.Visible = true;
                lblDirectionLocalizer.Visible = true;
            }
        }

    }


}
