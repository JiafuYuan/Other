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
using VehicleTransportClient.Com;
using DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Common.MessageBoxEx;
using BLL = DB_VehicleTransportManage.BLL;
namespace VehicleTransportClient
{
    public partial class FormVehicleScrap : Common.frmBase
    {
        private OperateTypeEnum _type;
        private DB_VehicleTransportManage.Model.m_VehicleScrap _model = new DB_VehicleTransportManage.Model.m_VehicleScrap();
        Bestway.Windows.Controls.InputPromptDialog inputPromptCar = new InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptPerson = new InputPromptDialog();
        DB_VehicleTransportManage.BLL.m_Person bllPersonEx = new m_Person();
        DB_VehicleTransportManage.BLL.m_Vehicle bllVehicle = new m_Vehicle();
        DB_VehicleTransportManage.BLL.m_VehicleScrap bllVehicleScrap = new m_VehicleScrap();
        BLL.data_VehicleAlarm bllDataVehicleAlarm = new BLL.data_VehicleAlarm();
        BLL.m_VehicleMaintain bllVehicleMaintain = new BLL.m_VehicleMaintain();
        private int _personID = 0;
        private int _CarID = 0;
        public FormVehicleScrap(OperateTypeEnum type, DB_VehicleTransportManage.Model.m_VehicleScrap model)
        {
            InitializeComponent();
            _type = type;
            InitLoad();
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
                    txtName.ReadOnly = true;
                    break;
                default:
                    break;
            }
           inputPromptCar.HideForm();
           inputPromptPerson.HideForm();
            dtInputStop.MaxDate = DateTime.Now;
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
            List<DB_VehicleTransportManage.Model.m_VehicleMaintain> listVehicleMaintain=
                bllVehicleMaintain.GetModelList(String.Format("i_Flag=0 and VehicleID={0}  order by ID desc", _model.VehicleID.Value));
           
            if (_modelVehicle != null)//车辆
            {
                if (listVehicleMaintain.Count>0)//存在维护信息
                {
                    if (((DateTime)(_model.dt_DateTime)).AddDays(1) < listVehicleMaintain[0].dt_BeginDateTime)
                    {
                        MessageBoxEx.Show("报废时间应在维护开始时间【" + listVehicleMaintain[0].dt_BeginDateTime.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒") + "】之后", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                else
                {
                    if (_modelVehicle.dt_CreateDateTime.Value != null && ((DateTime)(_model.dt_DateTime)).AddDays(1) < _modelVehicle.dt_CreateDateTime)
                    {
                        MessageBoxEx.Show("报废时间应在车辆开始使用时间【" + _modelVehicle.dt_CreateDateTime.Value.ToString("yyyy年MM月dd日 HH时mm分ss秒") + "】之后", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                
            }
            if (_type == OperateTypeEnum.Add)
            {

                if (bllVehicleScrap.Add(_model) > 0)
                {
                    Pub.GisManage.UpdateFeatureState(EnumLayerName.车辆, _modelVehicle.ID, EnumStyleIndex.CarScrap, true);
                    MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Add, "报废车辆",
                        bllVehicle.GetVehicleName((int)_model.VehicleID)[1]);
                    bllVehicle.UpdateVehicleState((int)_model.VehicleID, 3);
                    //更新告警表
                    List<DB_VehicleTransportManage.Model.data_VehicleAlarm> listmodel =
                        bllDataVehicleAlarm.GetModelList(
                            String.Format("(i_AlarmType=1 or i_AlarmType=2)  and VehicleID={0} and dt_End is null",
                                _model.VehicleID));
                    foreach (DB_VehicleTransportManage.Model.data_VehicleAlarm dataVehicleAlarm in listmodel)
                    {
                        dataVehicleAlarm.dt_End = _model.dt_DateTime;
                        bllDataVehicleAlarm.Update(dataVehicleAlarm);
                    }
                    //更新维护表
                    //DB_VehicleTransportManage.Model.m_VehicleMaintain _vehicleMaintain = bllVehicleMaintain.GetModel((int)_model.VehicleID);
                    //if (_vehicleMaintain!=null)
                    //    {
                    //_vehicleMaintain.dt_EndDateTime =_model.dt_DateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    //bllVehicleMaintain.Update(_vehicleMaintain);
                    //    }
                    new DB_VehicleTransportManage.BLL.m_VehicleMaintain().setMaintainEnd((int)_model.VehicleID, DateTime.Parse(_model.dt_DateTime.ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                    //更新车辆表
                    DB_VehicleTransportManage.Model.m_Vehicle _vehicleModel = bllVehicle.GetModel((int)_model.VehicleID);
                    _vehicleModel.dt_LastMaintainDateTIme = _model.dt_DateTime;
                    bllVehicle.Update(_vehicleModel);
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
            if (_type == OperateTypeEnum.Edit)
            {
                List<DB_VehicleTransportManage.Model.m_VehicleScrap> lstUser =
                    bllVehicleScrap.GetModelList(" i_flag=0 and  VehicleID=" + _model.VehicleID);
                if (lstUser.Count > 0)
                {
                    if (lstUser[0].ID != _model.ID)
                    {
                        MessageBoxEx.Show("车辆名称【" + bllVehicle.GetVehicleName((int)_model.VehicleID)[1] + "】 已经存在", "编辑失败", MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                if (bllVehicleScrap.Update(_model))
                {
                    MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    OperationLog.InsertSqlLog(EnumActionType.Update, "报废车辆", bllVehicle.GetVehicleName((int)_model.VehicleID)[1]);
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
            if (_type == OperateTypeEnum.Add)
            {
                if (txtName.Text.Trim().Length == 0 || _CarID == 0)
                {
                    txtName.Focus();
                    throw new Exception("请选择正确的车辆名称！");
                }
                else
                {
                    _model.VehicleID = _CarID;
                }
            }

            if (txtPersonName.Text.Trim().Length == 0 || _personID == 0)
            {
                txtPersonName.Focus();
                throw new Exception("请选择报废提交人姓名！");
            }
            else
            {
                _model.PersonID = _personID;
            }

            if (dtInputStop.Value.Year == 1)
            {
                throw new Exception("请选择报废时间！");
            }
            _model.dt_DateTime = dtInputStop.Value;

            _model.vc_Memo = txtMemo.Text.Trim();
            if (_model.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符！");
            }

        }

        private void ShowModel()
        {
            txtName.Text = bllVehicle.GetVehicleName((int)_model.VehicleID)[1];
            txtPersonName.Text = bllPersonEx.GetName((int)_model.PersonID);
            dtInputStop.Value = (DateTime)_model.dt_DateTime;
            txtMemo.Text = _model.vc_Memo;

        }





        private void InitLoad()
        {
            inputPromptPerson.ClearBind();
            inputPromptCar.ClearBind();
            DataSet dataSet = bllPersonEx.DropDownSource();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptPerson.Bind(txtPersonName, dataSet.Tables[0], 3, new int[] { 1 });
                inputPromptPerson.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPrompt_OnTextChangedEx);
            }
            dataSet = bllVehicle.DropDownSource(" (i_State=0 or i_state=2)");
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptCar.Bind(txtName, dataSet.Tables[0], 3, new int[] { 1 });
                inputPromptCar.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptCar_OnTextChangedEx);
            }
        }

        void inputPrompt_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {

            if (e.IsFind)
            {
                _personID = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _personID = 0;
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

        private void txtPersonName_Click(object sender, EventArgs e)
        {
            inputPromptPerson.ShowDropDown();

        }

        private void txtName_Click(object sender, EventArgs e)
        {
            inputPromptCar.ShowDropDown();
        }

    }


}
