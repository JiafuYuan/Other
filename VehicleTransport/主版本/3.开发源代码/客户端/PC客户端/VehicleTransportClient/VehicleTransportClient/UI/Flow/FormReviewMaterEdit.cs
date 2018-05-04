using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model = DB_VehicleTransportManage.Model;
using BLL = DB_VehicleTransportManage.BLL;
using DevComponents.AdvTree;
using Bestway.Windows.Controls;
using Common.MessageBoxEx;
using DB_VehicleTransportManage;
using VehicleTransportClient.Com;
using Common.Enum;
namespace VehicleTransportClient.UI
{
    public partial class FormReviewMaterEdit : Common.frmBase
    {
        BLL.m_MaterielType bllMaterielType = new DB_VehicleTransportManage.BLL.m_MaterielType();
        BLL.m_Department bllDeptment = new BLL.m_Department();
        BLL.m_Person bllPerson = new BLL.m_Person();
        BLL.m_Department bllDepartment = new BLL.m_Department();
        BLL.m_Address bllAddress = new BLL.m_Address();
        BLL.m_Plan bllplan = new BLL.m_Plan();
        BLL.m_Plan_ApplyMaterie bllapplymater = new BLL.m_Plan_ApplyMaterie();
        BLL.m_VehicleType bllcartype = new BLL.m_VehicleType();
        BLL.m_Apply bllapply = new BLL.m_Apply();
        BLL.m_Plan_CheckVehicle bllplancheckcar = new BLL.m_Plan_CheckVehicle();
        BLL.m_User blluser = new BLL.m_User();
        private List<Model.m_Plan_ApplyMaterie> _listApplyDetail = new List<Model.m_Plan_ApplyMaterie>();
        private Model.m_Apply _apply = new Model.m_Apply();
        private List<Model.m_User> _listUserinfo = new List<Model.m_User>();
        Bestway.Windows.Controls.InputPromptDialog inputPromptsupply = new Bestway.Windows.Controls.InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptload = new Bestway.Windows.Controls.InputPromptDialog();
        Bestway.Windows.Controls.InputPromptDialog inputPromptback = new Bestway.Windows.Controls.InputPromptDialog();
        Com.InputDialog inputUser = new Com.InputDialog();
        BLL.m_Vehicle bllcar = new BLL.m_Vehicle();


        int _backaddressid = 0;
        int _supplyaddressid = 0;
        int _loadaddressid = 0;


        private int _applyid = 0;//申请ID
        //private int _supplyid = 0;
        public FormReviewMaterEdit()
        {
            InitializeComponent();
        }
        private void FormReviewMaterEdit_Load(object sender, EventArgs e)
        {
           
            txtdeptname.Text = bllDeptment.GetName(_apply.ApplyDepartmentID.Value);
            txtusername.Text = bllPerson.GetName(_apply.ApplyPersonID.Value);
            dtarrive.Text = _apply.dt_ArriveDestinationDateTime.Value.ToString();
            InitCmb();
            InitGridCmb();
            LoadGrid(_listApplyDetail);
            Inittxt();
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
            List<Model.m_Apply> listapply = bllapply.GetModelList("ApplyPersonID=" + _apply.ApplyPersonID +  " and ArriveDestinationAddressID=" + _apply.ArriveDestinationAddressID + " and dt_ApplyDateTime='" + _apply.dt_ApplyDateTime + "' and i_IsUseMaterieApply=" + _apply.i_IsUseMaterieApply + " and dt_ArriveDestinationDateTime='" + _apply.dt_ArriveDestinationDateTime + "'");
            if (listapply.Count == 1)
            {
                _applyid = listapply[0].ID;

            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("没有找到对应的申请单", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.Cancel;
            }
            txtpdauser.LostFocus += new EventHandler(txtpdauser_LostFocus);
            dtarrive.Value = _apply.dt_ArriveDestinationDateTime.Value;

        }

      
        public FormReviewMaterEdit(List<Model.m_Plan_ApplyMaterie> listdetail, Model.m_Apply mapply,bool CanRefuse)
        {
            InitializeComponent();
            
            _listApplyDetail = listdetail;
            _apply = mapply;
            if (CanRefuse == false)
            {
                btncancle.Visible = false;
            }
        }
        public void LoadGrid(List<Model.m_Plan_ApplyMaterie> listdetail)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("colname");
            dt.Columns.Add("colnumber");
            dt.Columns.Add("colchecknumber");
            dt.Columns.Add("colcartype");
            dt.Columns.Add("colplancarnumber");
            dt.Columns.Add("colmaterid");
            dt.Columns.Add("colid");
            dt.Columns.Add("colUnit");
            dt.Columns.Add("colplancheck");
            for (int i = 0; i < listdetail.Count; i++)
            {
                if (listdetail[i].n_Count - listdetail[i].n_CheckCount == 0)
                {
                    continue;
                }
                DataRow dr = dt.NewRow();
                dr["colname"] = bllMaterielType.GetMaterielTypeName(listdetail[i].MaterieTypeID.Value);
                dr["colnumber"] = listdetail[i].n_Count - listdetail[i].n_CheckCount;
                dr["colchecknumber"] = listdetail[i].n_Count - listdetail[i].n_CheckCount;
                dr["colcartype"] = 0;
                dr["colplancarnumber"] = 1;
                dr["colmaterid"] = listdetail[i].MaterieTypeID.Value;
                dr["colid"] = i + 1;
                dr["colUnit"] = bllMaterielType.GetMaterielTypeUnit(listdetail[i].MaterieTypeID.Value);
                dr["colplancheck"] = 0;
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
        private void InitGridCmb()
        {
            List<Model.m_VehicleType> listtype = bllcartype.GetModelList("i_flag=0");
            Model.m_VehicleType type = new Model.m_VehicleType();
            type.vc_Name = "请选择";
            type.ID = 0;
            listtype.Add(type);
            DataTable dt = new DataTable();
            dt.Columns.Add("colcartype");
            dt.Columns.Add("colcartypename");
            for (int i = 0; i < listtype.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["colcartype"] = listtype[i].ID;
                dr["colcartypename"] = listtype[i].vc_Name;
                dt.Rows.Add(dr);
            }

            colcartype.DataSource = dt;
            colcartype.DisplayMember = "colcartypename";
            colcartype.ValueMember = "colcartype";
            

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
            //DataSet dataSetperson = bllPerson.DropDownSource();
            //if (dataSetperson != null && dataSetedperson.Tables[0].Rows.Count > 0)
            //{
            //    inputPromptPerson.Bind(txtpdauser, dataSetperson.Tables[0], 3, new int[] { 1 });
            //    inputPromptPerson.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptPerson_OnTextChangedEx);
            //}

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
            if (_listUserinfo.Count == 0)
            {
                btncancle.Enabled = true;
                btnok.Enabled = true;
                MessageBoxEx.Show("请输入通知人");

                return;
            }

            int planid = 0;
            try
            {
                bool allchecked = true;
                Model.m_Plan planmodel = new Model.m_Plan();
                planmodel.ApplyID = _applyid;

                List<Model.m_Plan> listplan = bllplan.GetModelList("convert(varchar(21),dt_CheckDateTime,120) like '%"+DateTime.Now.ToString("yyyy-MM-dd")+"%'");
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
                planmodel.CheckPersonID = blluser.GetModel(Pub.UserId).PersonID == null ? 0 : blluser.GetModel(Pub.UserId).PersonID;
                string userid = "";
                for (int i = 0; i < _listUserinfo.Count; i++)
                {
                    userid = userid + "," + _listUserinfo[i].ID;
                }
                
                planmodel.vc_PDAUserIDs = userid.Remove(0,1);
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
                planmodel.dt_RealGiveCarDateTime = DateTime.Parse("1900-1-1");
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

                List<Model.m_Plan_ApplyMaterie> listApplymater = new List<Model.m_Plan_ApplyMaterie>();
                List<Model.m_Plan_CheckVehicle> listCheckcar = new List<Model.m_Plan_CheckVehicle>();
                List<Model.m_Plan_CheckVehicle> tmplistCheckcar = new List<Model.m_Plan_CheckVehicle>();
                DataTable dt = (DataTable)dgvList.DataSource;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string name = "";
                    decimal number = 0;
                    decimal checknumber = 0;
                    string cartype = "";
                    int plancarnumber = 0;
                    int materid = 0;
                    if (dt.Rows[i]["colname"] != null)
                        name = dt.Rows[i]["colname"].ToString();
                    if (dt.Rows[i]["colnumber"] != null)
                        Decimal.TryParse(dt.Rows[i]["colnumber"].ToString(), out number);
                    if (dt.Rows[i]["colchecknumber"] != null)
                    {
                        if (Decimal.TryParse(dt.Rows[i]["colchecknumber"].ToString(), out checknumber)==false)
                        {
                            MessageBoxEx.Show("请输入有效的审核数量");
                            btncancle.Enabled = true;
                            btnok.Enabled = true;
                            DB.OleDbHelper.Rollback();
                            return;
                        }
                    }
                    if (checknumber < 0)
                    {
                        MessageBoxEx.Show("审核数量不能为负数");
                        btncancle.Enabled = true;
                        btnok.Enabled = true;
                        DB.OleDbHelper.Rollback();
                        return;
                    }

                    if (dt.Rows[i]["colcartype"] != null && dt.Rows[i]["colcartype"].ToString() != "0")
                    {
                        cartype = dt.Rows[i]["colcartype"].ToString();
                    }
                    else
                    {
                        if (checknumber > 0)
                        {
                            MessageBoxEx.Show("请选择车辆类型");
                            btncancle.Enabled = true;
                            btnok.Enabled = true;
                            return;
                        }
                    }
                    if (dt.Rows[i]["colplancarnumber"] != null)
                    {
                        if (int.TryParse(dt.Rows[i]["colplancarnumber"].ToString(), out plancarnumber) == false)
                        {
                            MessageBoxEx.Show("请输入有效的派车数量");
                            btncancle.Enabled = true;
                            btnok.Enabled = true;
                            return;
                        }
                        int plancheckcarnumber = int.Parse(dt.Rows[i]["colplancheck"].ToString());
                        if (plancheckcarnumber < plancarnumber)
                        {
                            MessageBoxEx.Show("派车数量不能大于可派车数量");
                            btncancle.Enabled = true;
                            btnok.Enabled = true;
                            return;
                        }
                    }
                    if (checknumber == 0 && plancarnumber > 0)
                    {
                        MessageBoxEx.Show("没有物料分配的车辆无法派车");
                        btncancle.Enabled = true;
                        btnok.Enabled = true;
                        return;
                    }
                    if (dt.Rows[i]["colmaterid"] != null)
                        int.TryParse(dt.Rows[i]["colmaterid"].ToString(), out materid);

                    List<Model.m_Plan_ApplyMaterie> listmater = bllapplymater.GetModelList("ApplyID=" + _applyid + " and MaterieTypeID=" + materid);
                    if (listmater.Count == 1)
                    {
                        decimal oldchecknumber = listmater[0].n_CheckCount.Value;
                        decimal oldplannumber = listmater[0].n_Count.Value;
                        if (oldchecknumber + checknumber > oldplannumber)
                        {
                            MessageBoxEx.Show("审核数量不能大于申请数量");
                            btncancle.Enabled = true;
                            btnok.Enabled = true;
                            return;
                        }
                        else if (oldchecknumber + checknumber < oldplannumber)
                        {
                            allchecked = false;
                        }
                        //更新审核物料表
                        listmater[0].n_CheckCount = oldchecknumber + checknumber;
                        listmater[0].n_Count = oldplannumber;
                        listApplymater.Add(listmater[0]);

                        //插入审核申请车辆表
                        if (checknumber > 0 && plancarnumber>0)
                        {
                            Model.m_Plan_CheckVehicle checkcar = new Model.m_Plan_CheckVehicle();
                            checkcar.PlanID = planid;
                            checkcar.VehicleTypeID = int.Parse(cartype);
                            checkcar.i_Count = plancarnumber;
                            checkcar.MaterieTypeID = materid;
                            checkcar.n_Count = checknumber;
                            checkcar.vc_Memo = " ";
                            checkcar.i_Flag = 0;
                            listCheckcar.Add(checkcar);
                        }
                        if (checknumber > 0)
                        {
                            Model.m_Plan_CheckVehicle checkcar = new Model.m_Plan_CheckVehicle();
                            checkcar.PlanID = planid;
                            checkcar.VehicleTypeID = int.Parse(cartype);
                            checkcar.i_Count = plancarnumber;
                            checkcar.MaterieTypeID = materid;
                            checkcar.n_Count = checknumber;
                            checkcar.vc_Memo = " ";
                            checkcar.i_Flag = 0;
                            tmplistCheckcar.Add(checkcar);
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
                if (listCheckcar.Count > 0)
                {
                    bool breturn = Pub.BackServer.SendCheck(planmodel, listApplymater, null, tmplistCheckcar, applymodel);

                    if (breturn == true)
                    {
                        MessageBoxEx.Show("完成审核");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBoxEx.Show("发送失败,请重新审核");
                        btnok.Enabled = true;
                        btncancle.Enabled = true;
                    }
                }
                else
                {
                    MessageBoxEx.Show("没有批复车辆数量,请重新审核");
                    btnok.Enabled = true;
                    btncancle.Enabled = true;
                }
            }
            catch (Exception exc)
            {
                WriteLog.AppendErrorLog("审查物料保存报错" + exc.ToString());
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
        bool lostfocus = true;
        private void txtpdauser_Click(object sender, EventArgs e)
        {

            lostfocus = false;
            inputUser.Hide();
            inputUser.Show(this);
            inputUser.SetDialogLocation();
            lostfocus = true;
            //MessageBox.Show(p.X.ToString() + "," + p.Y.ToString());
            //MessageBox.Show(MousePosition.X.ToString() + "," + MousePosition.Y.ToString());
            //inputUser.Location = new Point(p.X+30, p.Y+250);


        }
        void txtpdauser_LostFocus(object sender, EventArgs e)
        {
            if (lostfocus == true)
            {
                inputUser.Hide();
            }
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
            if (e.ColumnIndex == dgvList.Rows[e.RowIndex].Cells["colplancarnumber"].ColumnIndex)
            {
                int i = 0;
                if (!int.TryParse(dgvList.Rows[e.RowIndex].Cells["colplancarnumber"].Value.ToString(), out i))
                {
                    Common.MessageBoxEx.MessageBoxEx.Show("派车数量只能为数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgvList.Rows[e.RowIndex].Cells["colplancarnumber"].Value = "";
                }
            }


        }

        private void dgvList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvList.IsCurrentCellDirty)
            {
                dgvList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgvList.Rows.Count > 0 && dgvList.Columns[e.ColumnIndex].Name == "colcartype")
                {
                    int cartype = int.Parse(dgvList.Rows[e.RowIndex].Cells["colcartype"].Value.ToString());
                    if (cartype != 0)
                    {
                        int carnumber = bllcar.GetCheckCarTypeNum(cartype);
                        for (int i = 0; i < dgvList.Rows.Count; i++)
                        {
                            if (int.Parse(dgvList.Rows[i].Cells["colcartype"].Value.ToString()) == cartype && i != e.RowIndex)
                            {
                                carnumber = carnumber - int.Parse(dgvList.Rows[i].Cells["colplancarnumber"].Value.ToString());
                            }
                        }
                        if (carnumber < 0)
                            carnumber = 0;
                        dgvList.Rows[e.RowIndex].Cells["colplancheck"].Value = carnumber;
                    }
                    else
                    {
                        dgvList.Rows[e.RowIndex].Cells["colplancheck"].Value = 0;
                    }
                }
                else if (dgvList.Rows.Count > 0 && dgvList.Columns[e.ColumnIndex].Name == "colplancarnumber")
                {
                    int cartype = int.Parse(dgvList.Rows[e.RowIndex].Cells["colcartype"].Value.ToString());
                    if (cartype != 0)
                    {
                        int carnumber = bllcar.GetCheckCarTypeNum(cartype);
                        for (int i = 0; i < dgvList.Rows.Count; i++)
                        {
                            if (int.Parse(dgvList.Rows[i].Cells["colcartype"].Value.ToString()) == cartype && i != e.RowIndex)
                            {
                                dgvList.Rows[i].Cells["colcartype"].Value = 0;
                                dgvList.Rows[i].Cells["colplancarnumber"].Value = 0;
                                dgvList.Rows[i].Cells["colplancheck"].Value = 0;
                            }
                        }
                        if (carnumber < 0)
                            carnumber = 0;
                        dgvList.Rows[e.RowIndex].Cells["colplancheck"].Value = carnumber;
                    }
                    else
                    {
                        dgvList.Rows[e.RowIndex].Cells["colplancheck"].Value = 0;
                    }
                }
            }
            catch
            { 

            }
        }

        private void dtback_Click(object sender, EventArgs e)
        {
            dtback.Focus();
        }

        private void dtarrive_Click(object sender, EventArgs e)
        {
            dtarrive.Focus();
        }

        private void dtsupply_Click(object sender, EventArgs e)
        {
            dtsupply.Focus();
        }

      

    }
}
