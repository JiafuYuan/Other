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
using Bestway.Windows.Controls;
namespace VehicleTransportClient.UI
{
    public partial class FormTransferCarEdit : Common.frmBase
    {
        Model.v_Plan _planmodel = new Model.v_Plan();
        BLL.v_handover bllhandover = new BLL.v_handover();
        BLL.m_Plan_Handover bllmhandover = new BLL.m_Plan_Handover();
        BLL.m_Vehicle bllcar = new BLL.m_Vehicle();
        BLL.m_MaterielType bllmatertype = new BLL.m_MaterielType();
        BLL.m_Plan_Load bllload = new BLL.m_Plan_Load();
        Bestway.Windows.Controls.InputPromptDialog inputPromptPerson = new InputPromptDialog();
        BLL.m_Person bllPersonEx = new BLL.m_Person();
        int _Personid = 0;
        public FormTransferCarEdit(Model.v_Plan planmodel)
        {
            InitializeComponent();
            _planmodel = planmodel;
            txtplancode.Text = _planmodel.vc_PlanCode;
        }

        private void FormTransferCarEdit_Load(object sender, EventArgs e)
        {
            InitGrid();
            InitPerson();
        }
        private void InitGrid()
        {
            if (_planmodel.i_State == (int)Common.Enum.EnumPlanState.Transporting)
            {
                //运输中
                int handcount = bllmhandover.GetHandOverCount(_planmodel.ID);
                List<Model.v_handover> list = bllhandover.GetModelList("planid=" + _planmodel.ID + " and i_handovercount=" + handcount);
                foreach (Model.v_handover item in list)
                {
                    int i = dgvList.Rows.Add(dgvList.Rows.Count+1,item.carcode, item.matername, item.n_Count, item.n_Count);
                    dgvList.Rows[i].Tag = item;
                }
            }
            else if (_planmodel.i_State == (int)Common.Enum.EnumPlanState.Loaded)
            {
                List<Model.m_Plan_Load> list=bllload.GetModelList("planid="+_planmodel.ID);
                foreach (Model.m_Plan_Load item in list)
                {
                    int i = dgvList.Rows.Add(
                        dgvList.Rows.Count+1,
                        bllcar.GetModel(item.VehicleID.Value).vc_Code,
                        bllmatertype.GetModel(item.MaterieTypeID.Value).vc_Name,
                        item.n_Count,
                        item.n_Count
                        );
                    dgvList.Rows[i].Tag = item;
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormTransferCarEditMater frmadd = new FormTransferCarEditMater(_planmodel.i_State.Value, dgvList.Rows);
            DialogResult bresult = frmadd.ShowDialog();
            if (bresult == DialogResult.OK)
            {
                if (_planmodel.i_State == (int)Common.Enum.EnumPlanState.Loaded)
                {
                    Model.m_Plan_Load item = new Model.m_Plan_Load();
                    item.VehicleID = frmadd.handovermodel.VehicleID;
                    item.MaterieTypeID = frmadd.handovermodel.MaterieTypeID;
                    item.n_Count = frmadd.handovermodel.n_Count;
                    int i = dgvList.Rows.Add(
                        dgvList.Rows.Count+1,
                        bllcar.GetModel(item.VehicleID.Value).vc_Code,
                        bllmatertype.GetModel(item.MaterieTypeID.Value).vc_Name,
                        0,
                        item.n_Count
                        );
                    dgvList.Rows[i].Tag = item;

                }
                else if (_planmodel.i_State == (int)Common.Enum.EnumPlanState.Transporting)
                {
                    int i = dgvList.Rows.Add(frmadd.handovermodel.carcode, frmadd.handovermodel.matername, 0, frmadd.handovermodel.n_Count);
                    dgvList.Rows[i].Tag = frmadd.handovermodel;
                }
            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            btnsave.Enabled = false;
            if (_Personid == 0)
            {
                Common.MessageBoxEx.MessageBoxEx.Show("请输入交接人信息");
                btnsave.Enabled = true;
                return;
            }
            if (_planmodel.i_State == (int)Common.Enum.EnumPlanState.Loaded)
            {
                List<Model.m_Plan_Handover> list = new List<Model.m_Plan_Handover>();
                List<int> listcarid=new List<int>();
                List<Model.m_Plan_HandoverMaterie> listdetail = new List<Model.m_Plan_HandoverMaterie>();
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    int carid = ((Model.m_Plan_Load)dgvList.Rows[i].Tag).VehicleID.Value;
                    if (listcarid.Contains(carid) == false)
                    {
                        listcarid.Add(carid);
                    }
                }
                DateTime dt = DateTime.Now;
                for (int i = 0; i < listcarid.Count; i++)
                {
                    Model.m_Plan_Handover model = new Model.m_Plan_Handover();
                    model.PlanID = _planmodel.ID;
                    model.i_Flag = 0;
                    model.dt_HandoverDateTime = dt;
                    model.ReceiveVehiclePersonID = Pub.UserId;
                    model.vc_Memo = "";
                    model.VehicleID = listcarid[i];
                    model.ReceiveVehiclePersonID = _Personid;
                    model.dt_HandoverDateTime = dtTime.Value;
                    model.ID = i+1;
                    model.i_HandoverCount = 1;
                    list.Add(model);
                    for (int j = 0; j < dgvList.Rows.Count; j++)
                    {
                        if (((Model.m_Plan_Load)dgvList.Rows[j].Tag).VehicleID == listcarid[i])
                        {
                            Model.m_Plan_HandoverMaterie modeldetail = new Model.m_Plan_HandoverMaterie();
                            modeldetail.i_Flag = 0;
                            modeldetail.MaterieTypeID = ((Model.m_Plan_Load)dgvList.Rows[j].Tag).MaterieTypeID;
                            decimal number=0;
                            bool b=decimal.TryParse(dgvList.Rows[j].Cells["colnumber"].Value.ToString(),out number);
                            if (b==false)
                            {
                                Common.MessageBoxEx.MessageBoxEx.Show("请输入有效数量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                btnsave.Enabled = true;
                                return;
                            }
                            modeldetail.n_Count = number;
                            modeldetail.PlanHandoverID = i + 1;
                            modeldetail.vc_Memo = "";
                            modeldetail.ID = 0;
                            listdetail.Add(modeldetail);
                        }
                    }
                }
                //bool bresult = Pub.BackServer.SendHandOver(list,listdetail,_planmodel.ID,dtTime.Value);
                //if (bresult == false)
                //{
                //    Common.MessageBoxEx.MessageBoxEx.Show("发送失败,请重新审核");
                //    btnsave.Enabled = true;
                //    return;
                //}
                //else
                //{
                //    Common.MessageBoxEx.MessageBoxEx.Show("完成交接车");
                //    this.DialogResult = DialogResult.OK;
                //}
            }
            else if (_planmodel.i_State == (int)Common.Enum.EnumPlanState.Transporting)
            {
                List<Model.m_Plan_Handover> list = new List<Model.m_Plan_Handover>();
                List<int> listcarid = new List<int>();
                List<Model.m_Plan_HandoverMaterie> listdetail = new List<Model.m_Plan_HandoverMaterie>();
                for (int i = 0; i < dgvList.Rows.Count; i++)
                {
                    int carid = ((Model.v_handover)dgvList.Rows[i].Tag).VehicleID.Value;
                    if (listcarid.Contains(carid) == false)
                    {
                        listcarid.Add(carid);
                    }
                }
               
                for (int i = 0; i < listcarid.Count; i++)
                {
                    Model.m_Plan_Handover model = new Model.m_Plan_Handover();
                    model.PlanID = _planmodel.ID;
                    model.i_Flag = 0;
                    model.dt_HandoverDateTime = dtTime.Value;
                    model.ReceiveVehiclePersonID = _Personid;
                    model.vc_Memo = "";
                    model.VehicleID = listcarid[i];
                    model.ID = i+1;
                    model.i_HandoverCount= bllmhandover.GetHandOverCount(_planmodel.ID)+1;
                    list.Add(model);
                    for (int j = 0; j < dgvList.Rows.Count; j++)
                    {
                        if (((Model.v_handover)dgvList.Rows[j].Tag).VehicleID == listcarid[i])
                        {
                            Model.m_Plan_HandoverMaterie modeldetail = new Model.m_Plan_HandoverMaterie();
                            modeldetail.i_Flag = 0;
                            modeldetail.MaterieTypeID = ((Model.v_handover)dgvList.Rows[j].Tag).MaterieTypeID;
                            decimal number = 0;
                            bool b = decimal.TryParse(dgvList.Rows[j].Cells["colnumber"].Value.ToString(), out number);
                            if (b == false)
                            {
                                Common.MessageBoxEx.MessageBoxEx.Show("请输入有效数量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                btnsave.Enabled = true;
                                return;
                            }
                            modeldetail.n_Count = number;
                            modeldetail.PlanHandoverID = i + 1;
                            modeldetail.vc_Memo = "";
                            listdetail.Add(modeldetail);
                        }
                    }
                }
                //bool bresult = Pub.BackServer.SendHandOver(list, listdetail,_planmodel.ID,dtTime.Value);
                //if (bresult == false)
                //{
                //    Common.MessageBoxEx.MessageBoxEx.Show("发送失败,请重新审核");
                //    btnsave.Enabled = true;
                //    return;
                //}
                //else
                //{
                //    Common.MessageBoxEx.MessageBoxEx.Show("完成交接车");
                //    this.DialogResult = DialogResult.OK;
                //}

            }
            btnsave.Enabled = true;
        }

        private void txtPerson_Click(object sender, EventArgs e)
        {
            inputPromptPerson.ShowDropDown();
        }
        private void InitPerson()
        {
           
            inputPromptPerson.ClearBind();
            
            DataSet dataSet = bllPersonEx.DropDownSource();
            if (dataSet != null && dataSet.Tables[0].Rows.Count > 0)
            {
                inputPromptPerson.Bind(txtPerson, dataSet.Tables[0], 3, new int[] { 1 });
                inputPromptPerson.OnTextChangedEx += new InputPromptDialog.TextChangedEx(inputPromptPerson_OnTextChangedEx);
            
            }
        }

        void inputPromptPerson_OnTextChangedEx(object sender, InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                _Personid = int.Parse(e.SelectedRow["ID"].ToString());
            }
            else
            {
                _Personid = 0;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                dgvList.Rows.RemoveAt(dgvList.SelectedRows[0].Index);
            }
            else
            {
                Common.MessageBoxEx.MessageBoxEx.Show("请选择要删除的信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
