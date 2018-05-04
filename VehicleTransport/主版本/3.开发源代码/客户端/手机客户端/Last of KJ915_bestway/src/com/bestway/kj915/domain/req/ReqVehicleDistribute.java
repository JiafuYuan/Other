package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqVehicleDistribute extends BasicReqInner{

	public String shengqu;
	@Override
	public String getCmdType() {
		return NetCallback.Data_GetVehicleDistributed;
	}

	@Override
	public String getInnerRootMode() {
		return "quqiu";
	}

	public ReqVehicleDistribute(String shengqu) {
		super();
		this.shengqu = shengqu;
	}
	
	

}
