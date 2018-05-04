package com.bestway.kj915.domain.reflect;

public class m_VehicleType {
	
	public int ID;
	public String vc_Name;
	public String vc_Memo;
	public int i_Flag = 0;

	public int getID() {
		return ID;
	}

	public void setID(int iD) {
		ID = iD;
	}

	public String getVc_Name() {
		return vc_Name;
	}

	public void setVc_Name(String vc_Name) {
		this.vc_Name = vc_Name;
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

	public m_VehicleType() {
		super();
	}

	public m_VehicleType(int iD, String vc_Name, String vc_Memo, int i_Flag) {
		super();
		ID = iD;
		this.vc_Name = vc_Name;
		this.vc_Memo = vc_Memo;
		this.i_Flag = i_Flag;
	}

	@Override
	public String toString() {
		return "m_VehicleType [ID=" + ID + ", vc_Name=" + vc_Name
				+ ", vc_Memo=" + vc_Memo + ", i_Flag=" + i_Flag + "]";
	}

	
}
