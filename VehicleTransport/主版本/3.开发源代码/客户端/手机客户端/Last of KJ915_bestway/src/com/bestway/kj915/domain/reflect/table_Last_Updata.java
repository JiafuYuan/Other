package com.bestway.kj915.domain.reflect;

public class table_Last_Updata {

	public int ID;
	public String m_Department;
	public String m_VehicleType;
	public String m_Person;
	public String m_MaterielType;  
	public String m_Address;  
	public String m_Card;  

	public int getID() {
		return ID;
	}

	public void setID(int iD) {
		ID = iD;
	}

	public String getM_Department() {
		return m_Department;
	}

	public void setM_Department(String m_Department) {
		this.m_Department = m_Department;
	}

	public String getM_VehicleType() {
		return m_VehicleType;
	}

	public void setM_VehicleType(String m_VehicleType) {
		this.m_VehicleType = m_VehicleType;
	}

	public String getM_Person() {
		return m_Person;
	}

	public void setM_Person(String m_Person) {
		this.m_Person = m_Person;
	}

	public String getM_MaterielType() {
		return m_MaterielType;
	}

	public void setM_MaterielType(String m_MaterielType) {
		this.m_MaterielType = m_MaterielType;
	}

	public table_Last_Updata() {
		super();
	}

	public table_Last_Updata(int iD, String m_Department, String m_VehicleType,
			String m_Person, String m_MaterielType) {
		super();
		ID = iD;
		this.m_Department = m_Department;
		this.m_VehicleType = m_VehicleType;
		this.m_Person = m_Person;
		this.m_MaterielType = m_MaterielType;
	}

}
