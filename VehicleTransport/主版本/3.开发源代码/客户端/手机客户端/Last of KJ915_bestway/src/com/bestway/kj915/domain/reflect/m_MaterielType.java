package com.bestway.kj915.domain.reflect;
/**
 * 
 * @author gaga
 *
 */
public class m_MaterielType {
	public int ID;
	public String vc_Code;
	public String vc_Name;
	public String vc_Unit;
	public int ParentID;
	public String vc_Specifications;
	public String vc_Memo;
	public int i_Flag=0;
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
	public String getVc_Unit() {
		return vc_Unit;
	}
	public void setVc_Unit(String vc_Unit) {
		this.vc_Unit = vc_Unit;
	}
	public int getParentID() {
		return ParentID;
	}
	public void setParentID(int parentID) {
		ParentID = parentID;
	}
	public String getVc_Specifications() {
		return vc_Specifications;
	}
	public void setVc_Specifications(String vc_Specifications) {
		this.vc_Specifications = vc_Specifications;
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
	
	
	public m_MaterielType() {
		super();
	}
	
	public m_MaterielType(int iD, String vc_Code, String vc_Name,
			String vc_Unit, int parentID, String vc_Specifications,
			String vc_Memo, int i_Flag) {
		super();
		ID = iD;
		this.vc_Code = vc_Code;
		this.vc_Name = vc_Name;
		this.vc_Unit = vc_Unit;
		ParentID = parentID;
		this.vc_Specifications = vc_Specifications;
		this.vc_Memo = vc_Memo;
		this.i_Flag = i_Flag;
	}
	@Override
	public String toString() {
		return "m_materialType [ID=" + ID + ", vc_Code=" + vc_Code
				+ ", vc_Name=" + vc_Name + ", vc_Unit=" + vc_Unit
				+ ", ParentID=" + ParentID + ", vc_Specifications="
				+ vc_Specifications + ", vc_Memo=" + vc_Memo + ", i_Flag="
				+ i_Flag + "]";
	}
	
	
}
