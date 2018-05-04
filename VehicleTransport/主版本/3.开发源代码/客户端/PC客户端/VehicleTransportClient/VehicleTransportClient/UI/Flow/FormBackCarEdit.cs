using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL = DB_VehicleTransportManage.BLL;
using Model = DB_VehicleTransportManage.Model;
using DevComponents.AdvTree;
using Bestway.Windows.Controls;
using Common.Enum;
using Common.MessageBoxEx;
namespace VehicleTransportClient.UI
{
    public partial class FormBackCarEdit : Common.frmBase
    {
        public Model.m_Vehicle model = new Model.m_Vehicle();
        BLL.v_PlanVehicleDetail bllplancar = new BLL.v_PlanVehicleDetail();
        BLL.m_Vehicle bllVehicle = new BLL.m_Vehicle();
        Bestway.Windows.Controls.InputPromptDialog inputPromptDialog = new InputPromptDialog();
        private int _CarID = 0;
        int _i_state = -1;
        DataGridViewRowCollection _dgrows = null;
        Com.OperateTypeEnum _OperateType;
        int _EditIndex = 0;
        public FormBackCarEdit(Com.OperateTypeEnum operatetype, DataGridViewRowCollection dgrows, int rowindex)
        {
            InitializeComponent();
            try
            {
                //InitLoad();
                InitCombox();
                _dgrows = dgrows;
                _OperateType = operatetype;

                _EditIndex = rowindex;
                if (_OperateType == Com.OperateTypeEnum.Edit)
                {
                    ShowModel();
                }
            }
            catch
            { }
       
        }
        private void ShowModel()
        {
            Model.m_Vehicle entity = (Model.m_Vehicle)_dgrows[_EditIndex].Tag;
            comCar.SelectedValue = entity.ID;
            //txtCar.Text = entity.vc_Code;
            _CarID = entity.ID;

        }
        /// <summary>初始化下拉绑定等操作
        /// 初始化下拉绑定等操作
        /// </summary>
        //private void InitLoad()
        //{
        //    inputPromptDialog.ClearBind();
        //    DataSet dataSet = bllVehicle.DropDownSource();
        //    if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
        //    {
        //        inputPromptDialog.Bind(txtCar, dataSet.Tables[0], 2, new int[] { 1 });
        //        inputPromptDialog.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptDialog_OnTextChangedEx);
        //    }
        //}

        //void inputPromptDialog_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        //{
        //    if (e.IsFind)
        //    {
        //        _CarID = int.Parse(e.SelectedRow["ID"].ToString());
        //        btnOK.Enabled = false;
        //        btnNo.Enabled = false;
        //        bool iscando = Pub.BackServer.SendCarOperate(EnumFlowPathType.Back, _CarID);
        //        if (iscando == false)
        //        {
        //            Common.MessageBoxEx.MessageBoxEx.Show("该车辆无法进行还车");
        //            txtCar.Text = "";
        //            _CarID = 0;
        //        }
        //        btnOK.Enabled = true;
        //        btnNo.Enabled = true;
        //    }
        //    else
        //    {
        //        _CarID = 0;
        //    }
        //}

        private void txtCar_Click(object sender, EventArgs e)
        {
            inputPromptDialog.ShowDropDown();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _CarID = (int)comCar.SelectedValue;
            bool iscando = Pub.BackServer.SendCarOperate(EnumFlowPathType.Back, _CarID);
            if (iscando == false)
            {
                MessageBoxEx.Show("该车辆无法进行还车");
                _CarID = 0;
                return;
            }
            try
            {
                GetModel();
            }
            catch (Exception ex)
            {
                Common.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.DialogResult = DialogResult.OK;

        }
        private void GetModel()
        {
           
            if (comCar.SelectedIndex == -1)
            {
                //txtCar.Text = "";
                throw new Exception("请填写车辆编号");
            }
            model.ID = int.Parse(comCar.SelectedValue.ToString());
            model.vc_Code =comCar.Text;

            for (int i = 0; i < _dgrows.Count; i++)
            {
                if (((Model.m_Vehicle)_dgrows[i].Tag).ID == model.ID)
                {
                    if (_OperateType == Com.OperateTypeEnum.Add)
                    {
                        throw new Exception("该车辆已经存在！");
                    }
                    else
                    {
                        if (_EditIndex != i)
                        {
                            throw new Exception("该车辆已经存在！");
                        }
                    }
                }
                else
                {
                    continue;
                }
            }




        }

        private void InitCombox()
        {
            List<Model.v_PlanVehicleDetail> listplan = bllplancar.GetModelList("PlanState=" + Common.Enum.EnumPlanState.UnLoaded.GetHashCode() + " and VehicleState=" + Common.Enum.EnumVehicleState.Using.GetHashCode());
            comCar.ValueMember = "VehicleID";
            comCar.DisplayMember = "vc_Code";
            comCar.DataSource = listplan;
            comCar.SelectedIndexChanged+=new EventHandler(comCar_SelectedIndexChanged);
        }

        private void comCar_SelectedIndexChanged(object sender, EventArgs e)
        {
           //  _CarID = (int)comCar.SelectedValue;
           //// btnOK.Enabled = false;
           //// btnNo.Enabled = false;
            
           // bool iscando = Pub.BackServer.SendCarOperate(EnumFlowPathType.Back, _CarID);
           // if (iscando == false)
           // {
           //     MessageBoxEx.Show("该车辆无法进行还车");
           //     //txtCar.Text = "";
           //     _CarID = 0;
           // }
           // else
           // {
              //  btnOK.Enabled = true;
           // }
            //btnNo.Enabled = true;
        }


      
    }
}
