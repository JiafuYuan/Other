using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model=DB_VehicleTransportManage.Model;
using BLL=DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Bestway.Windows.Controls;
using Common.MessageBoxEx;
using DB_VehicleTransportManage;
using VehicleTransportClient.Com;
using Common.Enum;
namespace VehicleTransportClient.UI
{
    public partial class FormReviewCarEdit : Common.frmBase
    {
       
        BLL.m_Department bllDeptment = new BLL.m_Department();
        BLL.m_Person bllPerson = new BLL.m_Person();
        BLL.m_Plan_CheckVehicle bllplancheckcar = new BLL.m_Plan_CheckVehicle();
        BLL.m_Department bllDepartment = new BLL.m_Department();
        BLL.m_Address bllAddress = new BLL.m_Address();
        BLL.m_Plan bllplan = new BLL.m_Plan();
        BLL.m_Plan_ApplyVehicle bllapplymater = new BLL.m_Plan_ApplyVehicle();
        BLL.m_VehicleType bllcartype = new BLL.m_VehicleType();
        BLL.m_Apply bllapply = new BLL.m_Apply();
        BLL.m_User blluser = new BLL.m_User();
        BLL.m_Vehicle bllcar = new BLL.m_Vehicle();
        private List<Model.m_Plan_ApplyVehicle> _listApplyDetail = new List<Model.m_Plan_ApplyVehicle>();
        private Model.m_Apply _apply = new Model.m_Apply();
        private List<Model.m_User> _listUserinfo = new List<Model.m_User>();
        Bestway.Windows.Controls.InputPromptDialog inputPromptsupply = new Bestway.Windows.Controls.InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptload = new Bestway.Windows.Controls.InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptback = new Bestway.Windows.Controls.InputPromptDialog();

        Com.InputDialog inputUser = new Com.InputDialog();

        int _backaddressid = 0;
        int _supplyaddressid = 0;
        int _loadaddressid = 0;
       

        private int _applyid = 0;//申请ID
        //private int _supplyid = 0;
        //public FormReviewCarEdit()
        //{
        //    InitializeComponent();
        //}

        private void FormReviewMaterEdit_Load(object sender, EventArgs e)
        {
            try
            {
                
                txtdeptname.Text = bllDeptment.GetName(_apply.ApplyDepartmentID.Value);
                txtusername.Text = bllPerson.GetName(_apply.ApplyPersonID.Value);
                dtarrive.Text = _apply.dt_ArriveDestinationDateTime.Value.ToString();
                InitCmb();
                Inittxt();
                LoadGrid(_listApplyDetail);
                if (Pub.FlowPath.Give == false)
                {
                    panelA1.Visible = false;
                    labelsupply.Text = "装车时间";
                }
                if (Pub.FlowPath.Back == false)
                {
                    panelA4.Visible = false;
                    List<Model.m_Plan> listplan = bllplan.GetModelList("convert(varchar(21),dt_CheckDateTime,120) like '%" + DateTime.Now.ToString("yyyy-MM-dd") + "%'");
                    int count = 1;
                    if (listplan != null && listplan.Count > 0)
                        count = listplan.Count + 1;
                    string plancode = DateTime.Now.ToString("yyyyMMdd") + count.ToString().PadLeft(3, '0');
                    txtback.Text = plancode;
                    txtback.ReadOnly = true;

                    labelback.Text = "运单号";
                }
                dtarrive.Value = _apply.dt_ArriveDestinationDateTime.Value;
                List<Model.m_Apply> listapply = bllapply.GetModelList("ApplyPersonID=" + _apply.ApplyPersonID + " and ArriveDestinationAddressID=" + _apply.ArriveDestinationAddressID + " and dt_ApplyDateTime='" + _apply.dt_ApplyDateTime + "' and i_IsUseMaterieApply=" + _apply.i_IsUseMaterieApply + " and dt_ArriveDestinationDateTime='" + _apply.dt_ArriveDestinationDateTime + "'");
                if (listapply.Count == 1)
                {
                    _applyid = listapply[0].ID;

                }
                else
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("没有找到对应的申请单", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            catch
            { }

        }
        public FormReviewCarEdit(List<Model.m_Plan_ApplyVehicle> listdetail, Model.m_Apply mapply,bool CanRefuse)
        {
            InitializeComponent();
            try
            {
                _listApplyDetail = listdetail;
                _apply = mapply;
                if (CanRefuse == false)
                {
                    btncancle.Visible = false;
                }
            }
            catch
            { }
        }
        public void LoadGrid(List<Model.m_Plan_ApplyVehicle> listdetail)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("colid");
            dt.Columns.Add("colnumber");
            dt.Columns.Add("colchecknumber");
            dt.Columns.Add("colcartype");
            dt.Columns.Add("colcarid");
            dt.Columns.Add("colplancheck");
            for (int i = 0; i < listdetail.Count; i++)
            {
                if (listdetail[i].i_Count - listdetail[i].i_CheckCount == 0)
                {
                    continue;
                }
                DataRow dr = dt.NewRow();
                dr["colid"] = i + 1;
                dr["colnumber"] = listdetail[i].i_Count-listdetail[i].i_CheckCount;
                dr["colchecknumber"] = listdetail[i].i_Count - listdetail[i].i_CheckCount;
                dr["colcartype"] = bllcartype.GetModel(listdetail[i].VehicleTypeID.Value).vc_Name;
                dr["colcarid"] = listdetail[i].VehicleTypeID;
                dr["colplancheck"] = bllcar.GetCheckCarTypeNum(listdetail[i].VehicleTypeID.Value);
                dt.Rows.Add(dr);
            }
            dgvList.DataSource = dt;
        }

        private void InitCmb()
        {
            Myobj obj = new Myobj();
            obj.Id = 0;
            obj.Vc_Name = "==请选择部门==";
            Node node1 = new Node();
            node1.Text = obj.Vc_Name;
            node1.Tag = obj;
            LoadCmboTreeDepartment(ref node1);
            cmbbackDept.Nodes.Add(node1);
            cmbbackDept.Nodes[0].Expand();

            Node node2 = node1.DeepCopy();
            cmbloadDept.Nodes.Add(node2);
            cmbloadDept.Nodes[0].Expand();

            Node node3 = node1.DeepCopy();
            cmbSupplyDept.Nodes.Add(node3);
            cmbSupplyDept.Nodes[0].Expand();

            Node node4 = node1.DeepCopy();
            cmbunloadDept.Nodes.Add(node4);
            cmbunloadDept.Nodes[0].Expand();

        }
        public void Inittxt()
        {
            inputUser.Init(txtpdauser);
            inputUser.OnTextChangedEx += new Com.InputDialog.TextChangedEx(inputUser_OnTextChangedEx);
            DataSet dataSet = bllAddress.DropDownSource();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptsupply.Bind(txtsupply, dataSet.Tables[0], 2, new int[] { 1 });
                inputPromptsupply.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptsupply_OnTextChangedEx);

                inputPromptload.Bind(txtload, dataSet.Tables[0], 2, new int[] { 1 });
                inputPromptload.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptload_OnTextChangedEx);

                inputPromptback.Bind(txtback, dataSet.Tables[0], 2, new int[] { 1 });
                inputPromptback.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptback_OnTextChangedEx);
            }
          

        }


        void inputUser_OnTextChangedEx(object sender, Com.InputDialog.TextChanagedEventArgs e)
        {
            txtpdauser.Text = e.Showinfo;
            _listUserinfo = (List<Model.m_User>)e.SourceData;
        }

       

        void inputPromptback_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                _backaddressid = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _backaddressid = 0;
            }
        }

        void inputPromptload_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                _loadaddressid = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _loadaddressid = 0;
            }
        }

        void inputPromptsupply_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                _supplyaddressid = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _supplyaddressid = 0;
            }
        }
        public void LoadCmboTreeDepartment(ref Node nd)
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
                LoadCmboTreeDepartment(ref node1);
            }
        }
      

        private void btnok_Click(object sender, EventArgs e)
        {
            btncancle.Enabled = false;
            btnok.Enabled = false;
            if (_listUserinfo.Count==0)
            {
                btncancle.Enabled = true;
                btnok.Enabled = true;
                MessageBoxEx.Show("请输入通知人");
                return;
            }
            try
            {
                int planid=0;

                bool allchecked = true;
                Model.m_Plan planmodel = new Model.m_Plan();
                planmodel.ApplyID = _applyid;

                List<Model.m_Plan> listplan = bllplan.GetModelList("convert(varchar(21),dt_CheckDateTime,120) like '%" + DateTime.Now.ToString("yyyy-MM-dd") + "%'");
                int count = 1;
                if (listplan != null && listplan.Count > 0)
                    count = listplan.Count + 1;
                string plancode = DateTime.Now.ToString("yyyyMMdd") + count.ToString().PadLeft(3, '0');

                planmodel.vc_PlanCode = plancode;
                planmodel.dt_ArriveDestinationDateTime = DateTime.Parse(dtarrive.Text);
                if (planmodel.dt_ArriveDestinationDateTime <= DateTime.Now)
                {
                    MessageBoxEx.Show("到达时间应大于当前时间");
                    btncancle.Enabled = true;
                    btnok.Enabled = true;
                    return;
                }
                planmodel.ArriveDestinationAddressID = _apply.ArriveDestinationAddressID;
                planmodel.i_State = 0;
                if (rdplan.Checked)
                {
                    planmodel.i_IsTemPlan = 0;
                }
                else
                {
                    planmodel.i_IsTemPlan = 1;
                }
                //planmodel.CheckPersonID = blluser.GetModel(Pub.UserId).PersonID == null ? 0 : blluser.GetModel(Pub.UserId).PersonID;
                planmodel.CheckPersonID = blluser.GetModel(Pub.UserId).PersonID ?? 0;
                string userid = "";
                for (int i = 0; i < _listUserinfo.Count; i++)
                {
                    userid = userid + "," + _listUserinfo[i].ID;
                }
                
                planmodel.vc_PDAUserIDs =userid.Remove(0,1);
                planmodel.dt_CheckDateTime = DateTime.Now;
                planmodel.PlanGiveCarDepartmentID = cmbSupplyDept.SelectedNode == null ? 0 : ((Myobj)cmbSupplyDept.SelectedNode.Tag).Id;
                
                if (Pub.FlowPath.Give)
                {
                    planmodel.dt_PlanLoadDateTime = DateTime.Parse("1900-1-1");
                    if (dtsupply.Value.ToString("yyyy-MM-dd") == "0001-01-01")
                    {
                        planmodel.dt_PlanGiveCarDateTime = DateTime.Parse("1900-1-1");
                    }
                    else
                    {
                        if (dtsupply.Value <= DateTime.Now)
                        {
                            MessageBoxEx.Show("供车时间应大于当前时间");
                            btncancle.Enabled = true;
                            btnok.Enabled = true;
                            return;
                        }
                        planmodel.dt_PlanGiveCarDateTime = dtsupply.Value;
                    }
                }
                else
                {
                    planmodel.dt_PlanGiveCarDateTime = DateTime.Parse("1900-1-1");
                    if (dtsupply.Value.ToString("yyyy-MM-dd") == "0001-01-01")
                    {
                        planmodel.dt_PlanLoadDateTime = DateTime.Parse("1900-1-1");
                    }
                    else
                    {
                        if (dtsupply.Value <= DateTime.Now)
                        {
                            MessageBoxEx.Show("装车时间应大于当前时间");
                            btncancle.Enabled = true;
                            btnok.Enabled = true;
                            return;
                        }
                        planmodel.dt_PlanLoadDateTime = dtsupply.Value;
                    }
                }
                planmodel.PlanGiveCarAddressID = _supplyaddressid;
                planmodel.PlanUnLoadDepartmentID = cmbunloadDept.SelectedNode == null ? 0 : ((Myobj)cmbunloadDept.SelectedNode.Tag).Id;
                planmodel.PlanBackDepartmentID = cmbbackDept.SelectedNode == null ? 0 : ((Myobj)cmbbackDept.SelectedNode.Tag).Id;
                planmodel.dt_PlanBackDateTime = DateTime.Parse("1900-1-1");
                if (dtback.Value.ToString("yyyy-MM-dd") != "0001-01-01")
                {
                    if (dtback.Value <= DateTime.Now)
                    {
                        MessageBoxEx.Show("还车时间应大于当前时间");
                        btncancle.Enabled = true;
                        btnok.Enabled = true;
                        return;
                    }
                    planmodel.dt_PlanBackDateTime = dtback.Value;
                }
                planmodel.PlanBackAddressID = _backaddressid;
                planmodel.PlanLoadDepartmentID = cmbloadDept.SelectedNode == null ? 0 : ((Myobj)cmbloadDept.SelectedNode.Tag).Id;
                planmodel.PlanLoadAddressID = _loadaddressid;
                planmodel.RealGiveCarDepartmentID = 0;
                planmodel.dt_RealGiveCarDateTime =DateTime.Parse("1900-1-1");
                planmodel.RealGiveCarAddressID = 0;
                planmodel.RealLoadDepartmentID = 0;
                planmodel.dt_RealLoadDateTime = DateTime.Parse("1900-1-1");
                planmodel.RealLoadAddressID = 0;
                planmodel.dt_RealArriveDestinationDateTime = DateTime.Parse("1900-1-1");
                ////////planmodel.RealUnLoadDepartmentID = 0;
                ////////planmodel.dt_RealUnLoadDateTime = DateTime.Parse("1900-1-1");
                ////////planmodel.RealUnLoadAddressID = 0;
                ////////planmodel.RealBackDepartmentID = 0;
                ////////planmodel.dt_RealBackDateTime = DateTime.Parse("1900-1-1");
                ////////planmodel.RealBackAddressID = 0;
                List<Model.m_Plan_ApplyVehicle> listApplyCar = new List<Model.m_Plan_ApplyVehicle>();
                List<Model.m_Plan_CheckVehicle> listCheckCar = new List<Model.m_Plan_CheckVehicle>();
                DataTable dt = (DataTable)dgvList.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    int number = 0;
                    int checknumber = 0;
                    string cartype = "";
                    int carid = 0;
                    if (dt.Rows[i]["colnumber"] != null)
                        Int32.TryParse(dt.Rows[i]["colnumber"].ToString(), out number);
                    if (dt.Rows[i]["colchecknumber"] != null)
                    {
                        if (!Int32.TryParse(dt.Rows[i]["colchecknumber"].ToString(), out checknumber))
                        {
                            MessageBoxEx.Show("请输入有效的审核数量");
                            btncancle.Enabled = true;
                            btnok.Enabled = true;
                            return;
 
                        }
                        int plancheckcarnumber = int.Parse(dt.Rows[i]["colplancheck"].ToString());
                        if (plancheckcarnumber < checknumber)
                        {
                            MessageBoxEx.Show("派车数量不能大于可派车数量");
                            btncancle.Enabled = true;
                            btnok.Enabled = true;
                            return;
                        }
                    }
                    if (checknumber < 0)
                    {
                        MessageBoxEx.Show("审核数量不能为负数");
                        btncancle.Enabled = true;
                        btnok.Enabled = true;
                        return;
                    }
                    if (dt.Rows[i]["colcartype"] != null)
                        cartype = dt.Rows[i]["colcartype"].ToString();

                    if (dt.Rows[i]["colcarid"] != null)
                        int.TryParse(dt.Rows[i]["colcarid"].ToString(), out carid);

                    List<Model.m_Plan_ApplyVehicle> listmater = bllapplymater.GetModelList("ApplyID=" + _applyid + " and VehicleTypeID=" + carid);
                    if (listmater.Count == 1)
                    {
                        int oldchecknumber = listmater[0].i_CheckCount.Value;
                        int oldplannumber = listmater[0].i_Count.Value;
                        if (oldchecknumber + checknumber > oldplannumber)
                        {
                            btncancle.Enabled = true;
                            btnok.Enabled = true;
                            MessageBoxEx.Show("审核数量不能大于申请数量");
                            return;
                        }
                        else if (oldchecknumber + checknumber < oldplannumber)
                        {
                            allchecked = false;
                        }
                        //更新审核物料表
                        listmater[0].i_CheckCount = oldchecknumber + checknumber;
                        listmater[0].i_Count = oldplannumber;
                        listApplyCar.Add(listmater[0]);
                        //插入审核申请车辆表
                        if (checknumber > 0)
                        {
                            Model.m_Plan_CheckVehicle checkcar = new Model.m_Plan_CheckVehicle();
                            checkcar.PlanID = planid;
                            checkcar.VehicleTypeID = carid;
                            checkcar.i_Count = checknumber;
                            checkcar.MaterieTypeID = 0;
                            checkcar.n_Count = 0;
                            checkcar.vc_Memo = " ";
                            checkcar.i_Flag = 0;
                            listCheckCar.Add(checkcar);
                        }
                    }

                }
                //更新申请主表状态
                Model.m_Apply applymodel = _apply;
                applymodel.ID = _applyid;
                if (allchecked == false)
                {
                    applymodel.i_State = (int)EnumApplyState.CheckPart;
                }
                else
                {
                    applymodel.i_State = (int)EnumApplyState.Checked;
                }
                applymodel.i_IsUseMaterieApply = _apply.i_IsUseMaterieApply;
                applymodel.ApplyDepartmentID = _apply.ApplyDepartmentID;
                if (listCheckCar.Count > 0)
                {
                    bool bresult = Pub.BackServer.SendCheck(planmodel, null, listApplyCar, listCheckCar, applymodel);
                    if (bresult == true)
                    {
                        MessageBoxEx.Show("完成审核");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        btncancle.Enabled = true;
                        btnok.Enabled = true;
                        MessageBoxEx.Show("发送失败,请重新审核");
                        return;
                    }
                }
                else
                {
                    btncancle.Enabled = true;
                    btnok.Enabled = true;
                    MessageBoxEx.Show("没有批复车辆数量,请重新审核");
                    return;
                }

            }
            catch (Exception exc)
            {
                WriteLog.AppendErrorLog("审查物料保存报错" + exc.ToString());
                DB.OleDbHelper.Rollback();
                btnok.Enabled = true;
                btncancle.Enabled = true;
                return;
            }
        }

        private void txtsupply_Click(object sender, EventArgs e)
        {
            inputPromptsupply.ShowDropDown();
        }

        private void txtload_Click(object sender, EventArgs e)
        {
            inputPromptload.ShowDropDown();
        }

        private void txtback_Click(object sender, EventArgs e)
        {
            inputPromptback.ShowDropDown();
        }

        private void txtpdauser_Click(object sender, EventArgs e)
        {
            inputUser.Hide();
            inputUser.Show(this);
            inputUser.SetDialogLocation();
        }


        private void btncancle_Click(object sender, EventArgs e)
        {
            Model.m_Apply applymodel = _apply;
            applymodel.ID = _applyid;
            applymodel.i_State = (int)EnumApplyState.NoPass;
            FormUnCheckReason frmuncheck = new FormUnCheckReason(applymodel);
            DialogResult dresult = frmuncheck.ShowDialog();
            if (dresult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
 
            }
       
        }
      
        private void dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgvList.Rows[e.RowIndex].Cells["colchecknumber"].ColumnIndex)
            {
                int i = 0;
                if (!int.TryParse(dgvList.Rows[e.RowIndex].Cells["colchecknumber"].Value.ToString(), out i))
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("审核数量只能为数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgvList.Rows[e.RowIndex].Cells["colchecknumber"].Value = "";
                }
            }
        }

        private void dtsupply_Click(object sender, EventArgs e)
        {
            dtsupply.Focus();
        }

        private void dtarrive_Click(object sender, EventArgs e)
        {
            dtarrive.Focus();
        }

        private void dtback_Click(object sender, EventArgs e)
        {
            dtback.Focus();
        }

      

      
    }
}
