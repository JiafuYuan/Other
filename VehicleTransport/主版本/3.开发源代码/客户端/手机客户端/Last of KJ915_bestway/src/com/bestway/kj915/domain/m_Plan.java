package com.bestway.kj915.domain;

/**
 * 单个运单详情
 * 
 * @author gaga
 * 
 */
public class m_Plan {

	public String dt_ArriveDestinationDateTime;
	public String dt_PlanGiveCarDateTime;
	public String dt_PlanBackDateTime;
	public String dt_RealLoadDateTime;
	public String dt_RealUnLoadDateTime;
	public String dt_RealGiveCarDateTime;
	public String dt_RealArriveDestinationDateTime;
	public String dt_RealBackDateTime;
	public String dt_PlanLoadDateTime;
	public String dt_CheckDateTime;
	public String vc_PlanCode;
	public String vc_PDAUserIDs;

	public int ID;
	public int ArriveDestinationAddressID;
	public int i_State;
	public int ApplyID;
	public int i_IsTemPlan;
	public int CheckPersonID;

	public int PlanGiveCarDepartmentID;
	public int PlanGiveCarAddressID;

	public int PlanLoadAddressID;

	public int PlanUnLoadDepartmentID;
	public int PlanLoadDepartmentID;

	public int RealLoadDepartmentID;
	public int RealUnLoadDepartmentID;

	public int RealLoadAddressID;
	public int RealUnLoadAddressID;

	public int PlanBackDepartmentID;
	public int PlanBackAddressID;

	public int RealGiveCarDepartmentID;
	public int RealGiveCarAddressID;

	public int RealBackDepartmentID;
	public int RealBackAddressID;

	// 后续加上
	public String RealGiveCarPersonID;
	public String RealLoadPersonID;

}
