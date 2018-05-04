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
namespace VehicleTransportClient
{
    public partial class FormMyApply : Form
    {
        BLL.v_Apply bllapply = new BLL.v_Apply();
        BLL.m_User blluser = new BLL.m_User();
        BLL.m_Person bllperson = new BLL.m_Person();
        BLL.m_Plan_ApplyMaterie bllapplymater = new BLL.m_Plan_ApplyMaterie();
        BLL.m_Plan_ApplyVehicle bllapplycar = new BLL.m_Plan_ApplyVehicle();
        BLL.m_MaterielType bllmater = new BLL.m_MaterielType();
        BLL.m_VehicleType bllcartype = new BLL.m_VehicleType();
        BLL.v_Plan bllplan = new BLL.v_Plan();
        BLL.m_Department blldept = new BLL.m_Department();
        public FormMyApply()
        {
            InitializeComponent();
        }
        private void InitGrid(DateTime dtstart,DateTime dtend)
        {
            dgvList.Rows.Clear();
            Model.m_User userentity = blluser.GetModel(Pub.UserId);
            int deptid = 0;

            Model.m_Person person = bllperson.GetModel(userentity.PersonID.Value);
            deptid = person.DepartmentID;

          
            List<Model.m_Person> listperson = bllperson.GetModelList("DepartmentID=" + deptid);
            string persons = userentity.PersonID.ToString();
            for (int i = 0; i < listperson.Count; i++)
            {
                persons = persons + "," + listperson[i].ID;
            }
            //List<Model.m_Person> listperson = bllperson.GetModelList("i_flag=0 and DepartmentID=" + deptid);
            //string personids = "";
            //foreach (Model.m_Person person in listperson)
            //{
            //    personids = personids + "," + person.ID.ToString();
            //}
            string strwhere = "ApplyDepartmentID =" + deptid;
            strwhere = strwhere + string.Format("  and dt_ApplyDateTime>='{0}' and dt_ApplyDateTime<='{1}' ", dtstart, dtend);
            //if (string.IsNullOrEmpty(personids) == false)
            //{
            //    personids = personids.Remove(0, 1);
            //    strwhere = strwhere + " or ApplyPersonID in (" + personids + ")";

            //}

            List<Model.v_Apply> lst = bllapply.GetModelList(strwhere);
            if (lst == null)
                return;
            lst = (from apply in lst orderby apply.ID descending select apply).ToList<Model.v_Apply>();
            foreach (Model.v_Apply apply in lst)
            {
                StringBuilder strbuild = new StringBuilder();
                if (apply.i_IsUseMaterieApply == (int)Common.Enum.EnumApplyType.Materie)
                {
                    List<Model.m_Plan_ApplyMaterie> listmater = bllapplymater.GetModelList("applyid=" + apply.ID);
                    foreach (Model.m_Plan_ApplyMaterie applymater in listmater)
                    {
                        Model.m_MaterielType materentity = bllmater.GetModel(applymater.MaterieTypeID.Value);
                        strbuild.AppendFormat(" " + materentity.vc_Name + ":" + applymater.n_Count + "(" + materentity.vc_Unit + ")");
                    }
                }
                else
                {
                    List<Model.m_Plan_ApplyVehicle> listcar = bllapplycar.GetModelList("applyid=" + apply.ID);
                    foreach (Model.m_Plan_ApplyVehicle applycar in listcar)
                    {
                        Model.m_VehicleType cartype = bllcartype.GetModel(applycar.VehicleTypeID.Value);
                        strbuild.AppendFormat(" " + cartype.vc_Name + ":" + applycar.i_Count+"(辆)");
                    }
                }
                int i = dgvList.Rows.Add(
                    dgvList.Rows.Count + 1,
                    apply.username,
                    apply.dt_ApplyDateTime,
                    strbuild.ToString(),
                    apply.addressname,
                    apply.dt_arrive,
                    apply.statename,
                    apply.vc_remark,
                    "详情",
                    "运输路线"
                );
                dgvList.Rows[i].Tag = apply;

            }
            //lbcount.Text = "总记录" + dgvList.Rows.Count.ToString();
        }

        private void FormMyApply_Load(object sender, EventArgs e)
        {
            dtStart.Value = DateTime.Parse(DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd 00:00:00"));
            dtStop.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            InitGrid(DateTime.Parse(dtStart.Value.ToString("yyyy-MM-dd 00:00:00")), DateTime.Parse(dtStop.Value.ToString("yyyy-MM-dd 23:59:59")));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitGrid(DateTime.Parse(dtStart.Value.ToString("yyyy-MM-dd 00:00:00")), DateTime.Parse(dtStop.Value.ToString("yyyy-MM-dd 23:59:59")));
        }

        private void dgvList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvList.Columns[e.ColumnIndex].Name == "colbt")
            {
                if (dgvList.SelectedRows.Count > 0)
                {
                    Model.v_Apply apply = (Model.v_Apply)dgvList.SelectedRows[0].Tag;
                    List<Model.v_Plan> listplan = bllplan.GetModelList("ApplyID=" + apply.ID);
                    if (listplan.Count > 1)
                    {
                        FormMyApplyDetail frmdetail = new FormMyApplyDetail(apply.ID);
                        frmdetail.ShowDialog();
                    
                        return;
                       
                    }
                    else if (listplan == null || listplan.Count == 0)
                    {
                        Common.MessageBoxEx.MessageBoxEx.Show("该记录暂未产生运单");
                        return;
                    }
                    else
                    {
                        FormPlanDetailQuery frm1 = new FormPlanDetailQuery(listplan[0].ID);
                        frm1.ShowDialog();
                    }
                }
            }
            if (dgvList.Columns[e.ColumnIndex].Name == "coltrans")
            {
                if (dgvList.SelectedRows.Count > 0)
                {
                    Model.v_Apply apply = (Model.v_Apply)dgvList.SelectedRows[0].Tag;
                    List<Model.v_Plan> listplan = bllplan.GetModelList("ApplyID=" + apply.ID);
                    if (listplan.Count > 1)
                    {
                        FormMyApplyDetail frmdetail = new FormMyApplyDetail(apply.ID);
                        frmdetail.ShowDialog();
                      
                        return;

                    }
                    else if (listplan == null || listplan.Count == 0)
                    {
                        Common.MessageBoxEx.MessageBoxEx.Show("该记录暂未产生运单");
                        return;
                    }
                    else
                    {

                        if (listplan[0].i_State == (int)Common.Enum.EnumPlanState.Checked || listplan[0].i_State == (int)Common.Enum.EnumPlanState.Gived)
                        {
                            Common.MessageBoxEx.MessageBoxEx.Show("该订单暂无车辆运输");
                            return;
                        }
                        else if (listplan[0].i_State == (int)Common.Enum.EnumPlanState.Complete)
                        {
                            UI.FrmQueryPlanCar frmqry = new UI.FrmQueryPlanCar(listplan[0].ID);
                            frmqry.ShowDialog();
                        }
                        else
                        {
                            UI.FrmQueryGIS frmgis = new UI.FrmQueryGIS(listplan[0].ID);
                            DialogResult bresult = frmgis.ShowDialog();
                            if (bresult == DialogResult.Ignore)
                            {
                                Common.MessageBoxEx.MessageBoxEx.Show("该运单下的车辆暂时都无法定位");
                                frmgis.Close();
                                return;
                            }
                            else
                            {
                                frmgis.Close();
                                return;
                            }
                        }
                    }
                }
            }
        }
     
    }
}
