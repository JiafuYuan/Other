package com.bestway.kj915.domain.req.supply;

import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.BasicReqInner;

public class ReqSupplyCar extends BasicReqInner {

	public int UserID;

	public int DepartmentID;

	public int AddressID;

	public int PlanID;

	public String DateTime;
	
	public SupplyContainer ListM_Plan_GiveVehicle;

	@Override
	public String getCmdType() {

		return NetCallback.Flow_Give;

	}

	@Override
	public String getInnerRootMode() {

		return "InGiveModel";

	}

}
