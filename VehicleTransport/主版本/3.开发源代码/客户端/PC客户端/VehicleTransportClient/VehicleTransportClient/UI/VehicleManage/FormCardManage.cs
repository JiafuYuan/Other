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
using BLL = DB_VehicleTransportManage.BLL;
using VehicleTransportClient.Com;

namespace VehicleTransportClient
{
    public partial class FormCardManage : Form
    {
        private string _tableName = "FormCardManage";
        private int _selectIndex = -1;
        private DB_VehicleTransportManage.Model.m_Card _model = new DB_VehicleTransportManage.Model.m_Card();
        BLL.m_Vehicle bllVehicleEx = new BLL.m_Vehicle();
        BLL.m_Card bllCard = new BLL.m_Card();
        BLL.m_VehicleType bllVehicleType = new BLL.m_VehicleType();
        private DataSet dataSet = null;
        AcNetUtilsManage acNetUtilsManage = new AcNetUtilsManage();
        public FormCardManage()
        {
            InitializeComponent();
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);
            Pub.StyleManager.SetGridStyle(_tableName, this.dgvList);
            this.Load += new EventHandler(FormCardManage_Load);
        }

        void FormCardManage_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectIndex = e.RowIndex;
        }

        public void LoadData()
        {
            List<DB_VehicleTransportManage.Model.m_Card> lst = bllCard.GetModelList("i_flag=0 ");

            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.AllowUserToAddRows = false;
            dgvList.ReadOnly = true;

            dgvList.Rows.Clear();
            foreach (DB_VehicleTransportManage.Model.m_Card item in lst)
            {
                int i = dgvList.Rows.Add(bllVehicleEx.GetVehicleName((int)item.VehicleID)[0],
                    bllVehicleEx.GetVehicleName((int)item.VehicleID)[1],
                    bllVehicleType.GetVehicleTypeName((int)bllVehicleEx.GetVehicleTypeID((int)item.VehicleID)),
                    item.i_LocalizerCardHID, item.i_IdentificationCardHID, item.vc_Memo);
                dgvList.Rows[i].Tag = item;
            }
          
            lblCount.Text = "共有" + dgvList.Rows.Count + "辆车已发卡";
            dgvList.ClearSelection();
            _selectIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataSet dataSet = bllVehicleEx.DropDownSource(" i_state=0 and ID not in (select VehicleID from m_card where i_Flag=0)");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                new FormCard(Com.OperateTypeEnum.Add, null).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("所有车辆已经发卡！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Card)dgvList.Rows[_selectIndex].Tag;
                if (MessageBoxEx.Show("确认要撤销发卡 【" + bllVehicleEx.GetVehicleName((int)_model.VehicleID)[1] + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (new DB_VehicleTransportManage.BLL.m_Vehicle().IsVehicleMainTain(_model.VehicleID.Value))
                    {
                        MessageBoxEx.Show("当前车辆正在维护，无法撤销发卡！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (new DB_VehicleTransportManage.BLL.m_Vehicle().IsVehicleUsed(_model.VehicleID.Value))
                    {
                        MessageBoxEx.Show("当前车辆正在使用，无法撤销发卡！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (DeleteHID((int)_model.i_LocalizerCardHID))
                    {
                        _model.i_Flag = 1;
                        if ((new DB_VehicleTransportManage.BLL.m_Card()).Update(_model))
                        {
                            MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            OperationLog.InsertSqlLog(EnumActionType.Delete, "车辆名称发卡", bllVehicleEx.GetVehicleName((int)_model.VehicleID)[1]);
                            LoadData();

                        }
                        else
                        {
                            MessageBoxEx.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBoxEx.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBoxEx.Show("请选择需要删除的卡", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            if (_selectIndex >= 0)
            {
                _model = (DB_VehicleTransportManage.Model.m_Card)dgvList.Rows[_selectIndex].Tag;
                if (new DB_VehicleTransportManage.BLL.m_Vehicle().IsVehicleMainTain(_model.VehicleID.Value))
                {
                    MessageBoxEx.Show("当前车辆正在维护，无法换卡！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (new DB_VehicleTransportManage.BLL.m_Vehicle().IsVehicleUsed(_model.VehicleID.Value))
                {
                    MessageBoxEx.Show("当前车辆正在使用，无法换卡！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                new FormCard(Com.OperateTypeEnum.Edit, _model).ShowDialog();
                LoadData();
            }
            else
            {
                MessageBoxEx.Show("请选择要换卡的车辆", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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


        private bool DeleteHID(int i_LocalizerCardHID)
        {
            bool bDeleteHID = true;

            if (!(bllCard.DeleteKj222Hid(i_LocalizerCardHID)))
            {

                bDeleteHID = false;
            }

            return bDeleteHID;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            FormAddCard formAddCard = new FormAddCard();
            if (formAddCard.ShowDialog() == DialogResult.Yes)
            {
                new FormAddCard().ShowDialog();
            }
            else
            {
                formAddCard.Close();
            }
            LoadData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            if (acNetUtilsManage.Init(System.Windows.Forms.Application.StartupPath + "\\Report", "CardReport.apt"))
            {
                acNetUtilsManage.FillDataTableToAcFromGridView(dgvList, "CardReport");
                acNetUtilsManage.Print();
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("未找到报表，请设计报表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            acNetUtilsManage.Init(System.Windows.Forms.Application.StartupPath + "\\Report", "CardReport.apt");
            acNetUtilsManage.FillDataTableToAcFromGridView(dgvList, "CardReport");
            acNetUtilsManage.ShowDesigner();
        }
    }
}
