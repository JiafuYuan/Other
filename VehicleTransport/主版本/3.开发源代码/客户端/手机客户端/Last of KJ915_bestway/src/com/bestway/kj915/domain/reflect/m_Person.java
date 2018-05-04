package com.bestway.kj915.domain.reflect;

public class m_Person {

	public int ID;
	public String vc_Code;// 工号
	public String vc_Name;// 姓名
	public int i_Sex;// 性别
	public int DepartmentID;// 部门编号
	public String vc_Job;// 职务
	public String vc_WorkType;// 工种
	public String vc_Telphone;// 电话
	public String vc_Memo;// 备注
	public int i_Flag = 0;
	
	public int getID() {
		return ID;
	}
	public void setID(int iD) {
		ID = iD;
	}
	public String getVc_Code() {
		return vc_Code;
	}
	public void setVc_Code(String vc_Code) {
		this.vc_Code = vc_Code;
	}
	public String getVc_Name() {
		return vc_Name;
	}
	public void setVc_Name(String vc_Name) {
		this.vc_Name = vc_Name;
	}
	public int getI_Sex() {
		return i_Sex;
	}
	public void setI_Sex(int i_Sex) {
		this.i_Sex = i_Sex;
	}
	public int getDepartmentID() {
		return DepartmentID;
	}
	public void setDepartmentID(int departmentID) {
		DepartmentID = departmentID;
	}
	public String getVc_Job() {
		return vc_Job;
	}
	public void setVc_Job(String vc_Job) {
		this.vc_Job = vc_Job;
	}
	public String getVc_WorkType() {
		return vc_WorkType;
	}
	public void setVc_WorkType(String vc_WorkType) {
		this.vc_WorkType = vc_WorkType;
	}
	public String getVc_Telphone() {
		return vc_Telphone;
	}
	public void setVc_Telphone(String vc_Telphone) {
		this.vc_Telphone = vc_Telphone;
	}
	public String getVc_Memo() {
		return vc_Memo;
	}
	public void setVc_Memo(String vc_Memo) {
		this.vc_Memo = vc_Memo;
	}
	public int getI_Flag() {
		return i_Flag;
	}
	public void setI_Flag(int i_Flag) {
		this.i_Flag = i_Flag;
	}
	
	
	public m_Person() {
		super();
	}
	public m_Person(int iD, String vc_Code, String vc_Name, int i_Sex,
			int departmentID, String vc_Job, String vc_WorkType,
			String vc_Telphone, String vc_Memo, int i_Flag) {
		super();
		ID = iD;
		this.vc_Code = vc_Code;
		this.vc_Name = vc_Name;
		this.i_Sex = i_Sex;
		DepartmentID = departmentID;
		this.vc_Job = vc_Job;
		this.vc_WorkType = vc_WorkType;
		this.vc_Telphone = vc_Telphone;
		this.vc_Memo = vc_Memo;
		this.i_Flag = i_Flag;
	}
	@Override
	public String toString() {
		return "m_Person [ID=" + ID + ", vc_Code=" + vc_Code + ", vc_Name="
				+ vc_Name + ", i_Sex=" + i_Sex + ", DepartmentID="
				+ DepartmentID + ", vc_Job=" + vc_Job + ", vc_WorkType="
				+ vc_WorkType + ", vc_Telphone=" + vc_Telphone + ", vc_Memo="
				+ vc_Memo + ", i_Flag=" + i_Flag + "]";
	}
	

}
