using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Enum;
using Common.MessageBoxEx;
using DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;

namespace VehicleTransportClient
{
    public partial class FormMaterielTypeManage : Form
    {
        private string _tableName = "FormMaterielTypeManage";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_MaterielType _model = new DB_VehicleTransportManage.Model.m_MaterielType();
        m_MaterielType bllMaterielType = new m_MaterielType();
        public FormMaterielTypeManage()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormMaterielTypeManage_Load);
        }

        void FormMaterielTypeManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData()
        {
            List<DB_VehicleTransportManage.Model.m_MaterielType> lst = new DB_VehicleTransportManage.BLL.m_MaterielType().GetModelList("i_flag=0");

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            foreach (DB_VehicleTransportManage.Model.m_MaterielType item in lst)
            {
                int i = dgvList.Rows.Add(item.vc_Code, item.vc_Name, bllMaterielType.GetMaterielTypeName((int)item.ParentID), item.vc_Unit, item.vc_Specifications, item.vc_Memo);
                dgvList.Rows[i].Tag = item;
            }
            lblCount.Text = "共有" + dgvList.Rows.Count + "个物料";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FormMaterielType(Com.OperateTypeEnum.Add, null).ShowDialog();
            LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_MaterielType)dgvList.Rows[_selectIndex].Tag;



                if (MessageBoxEx.Show("确认要删除物料 【" + _model.vc_Code + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (bllMaterielType.IsMaterielTypeUsed(_model.ID))
                    {
                        MessageBoxEx.Show("当前物料已被使用，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }

                    if (bllMaterielType.IsApplyMaterielTypeUsed(_model.ID))
                    {
                        MessageBoxEx.Show("当前物料已被使用，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (bllMaterielType.IsPlanMaterielTypeUsed(_model.ID))
                    {
                        MessageBoxEx.Show("当前物料已被使用，无法删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    _model.i_Flag = 1;
                    if ((new DB_VehicleTransportManage.BLL.m_MaterielType()).Update(_model))
                    {
                        MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        OperationLog.InsertSqlLog(EnumActionType.Delete, "物料名称", _model.vc_Name);
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
                MessageBoxEx.Show("请选择要删除的物料", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_MaterielType)dgvList.Rows[_selectIndex].Tag;
                new FormMaterielType(Com.OperateTypeEnum.Edit, _model).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要修改的物料", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.GridStyleForm gFrom = new Bestway.Windows.Forms.GridStyleForm(_tableName, Pub.StyleManager);
            gFrom.ShowDialog();

            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }


    }
}
