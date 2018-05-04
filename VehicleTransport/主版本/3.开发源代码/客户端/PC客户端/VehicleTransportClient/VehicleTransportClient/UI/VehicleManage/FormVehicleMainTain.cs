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
using DevComponents.DotNetBar.Schedule;
using DevComponents.AdvTree;
using Common.MessageBoxEx;
using VehicleTransportClient.Com;
using BLL = DB_VehicleTransportManage.BLL;

namespace VehicleTransportClient
{
    public partial class FormVehicleMainTain : Common.frmBase
    {

        private DB_VehicleTransportManage.Model.m_VehicleMaintain _model = new DB_VehicleTransportManage.Model.m_VehicleMaintain();
        Bestway.Windows.Controls.InputPromptDialog inputPromptCar = new InputPromptDialog();
        BLL.m_Person bllPersonEx = new BLL.m_Person();
        BLL.m_Vehicle bllVehicle = new BLL.m_Vehicle();
        BLL.m_VehicleMaintain bllVehicleMaintain = new BLL.m_VehicleMaintain();
        BLL.m_User bllUser = new BLL.m_User();
        BLL.data_VehicleAlarm bllDataVehicleAlarm = new BLL.data_VehicleAlarm();

        private int _CarID = 0;
        public FormVehicleMainTain( DB_VehicleTransportManage.Model.m_VehicleMaintain model)
        {
            InitializeComponent();

            InitLoad();

            this.FormTitle = "增加";
            btnOK.Text = "添加";
            inputPromptCar.HideForm();
            dtInputStart.MaxDate = DateTime.Now;
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
            DB_VehicleTransportManage.Model.m_Vehicle _modelVehicle = bllVehicle.GetModel(_model.VehicleID.Value);
            if (_modelVehicle != null &&_modelVehicle.dt_CreateDateTime.Value != null &&
                _modelVehicle.dt_CreateDateTime.Value > ((DateTime)(_model.dt_BeginDateTime)).AddDays(1))
            {
                MessageBoxEx.Show("维护开始时间应在车辆开始使用时间【" + _modelVehicle.dt_CreateDateTime.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒") + "】之后", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (bllVehicleMaintain.Add(_model) >0)
            {
                Pub.GisManage.UpdateFeatureState(EnumLayerName.车辆, _modelVehicle.ID, EnumStyleIndex.CarMation, true);
                MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                OperationLog.InsertSqlLog(EnumActionType.Add, "车辆维护", bllVehicle.GetVehicleName((int)_model.VehicleID)[1]);

              
                //更新告警表
                bllVehicle.UpdateVehicleState((int)_model.VehicleID, 2);
                List<DB_VehicleTransportManage.Model.data_VehicleAlarm> listmodel =
                    bllDataVehicleAlarm.GetModelList(String.Format("i_AlarmType=1 and VehicleID={0} and dt_End is null", _model.VehicleID));
                foreach (DB_VehicleTransportManage.Model.data_VehicleAlarm dataVehicleAlarm in listmodel)
                {
                    dataVehicleAlarm.dt_End = _model.dt_BeginDateTime;
                    bllDataVehicleAlarm.Update(dataVehicleAlarm);
                }
                Pub.BackServer.OverAlarm();
                Pub.GisManage.UpdataGisAndDBRemark();
                Pub.GISForm.LoadGrid();
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnNo_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void GetModel()
        {

            if (txtName.Text.Trim().Length == 0 || _CarID==0)
            {
                txtName.Focus();
                throw new Exception("请选择正确的车辆名称！");
            }
            _model.VehicleID = _CarID;


            if (txtPersonName.Text.Trim().Length == 0)
            {
                txtPersonName.Focus();
                throw new Exception("请输入维护人姓名！");
            }
           
            _model.vc_PersonName = txtPersonName.Text.Trim();
            if (_model.vc_PersonName.IndexOf("'") >= 0)
            {
                txtPersonName.Focus();
                throw new Exception("维护人姓名中不可以有特殊字符！");
            }

            if (dtInputStart.Value.Year == 1)
            {
                throw new Exception("请选择开始维护时间！");
            }
            _model.dt_BeginDateTime = dtInputStart.Value;



            _model.vc_Content = txtContent.Text.Trim();
            if (_model.vc_Content.IndexOf("'") >= 0)
            {
                txtContent.Focus();
                throw new Exception("维护内容中不可以有特殊字符！");
            }
            _model.vc_Memo = txtMemo.Text.Trim();
            if (_model.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符！");
            }
            _model.RecordPersonID = bllUser.GetPersonID(Pub.UserId);


        }

        private void ShowModel()
        {
            txtName.Text = bllVehicle.GetVehicleName((int)_model.VehicleID)[1];
            txtPersonName.Text = _model.vc_PersonName;
            dtInputStart.Value = (DateTime)_model.dt_BeginDateTime;

            txtContent.Text = _model.vc_Content;
            txtMemo.Text = _model.vc_Memo;

        }


        private void InitLoad()
        {
            inputPromptCar.ClearBind();
            DataSet dataSet = bllVehicle.DropDownSource("i_state in (0) ");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptCar.Bind(txtName, dataSet.Tables[0], 3, new int[] { 1 });
                inputPromptCar.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptCar_OnTextChangedEx);
            }
        }




        void inputPromptCar_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {

            if (e.IsFind)
            {
                _CarID = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _CarID = 0;
            }

        }



        private void txtName_Click(object sender, EventArgs e)
        {
            inputPromptCar.ShowDropDown();
        }

    }


}
