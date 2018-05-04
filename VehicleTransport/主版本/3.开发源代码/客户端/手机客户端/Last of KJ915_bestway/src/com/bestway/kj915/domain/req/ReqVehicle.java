package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqVehicle extends BasicReqInner {
	public String LastUpdateTime;

	@Override
	public String getCmdType() {
		return NetCallback.Data_GetVehicle;
	}

	@Override
	public String getInnerRootMode() {
		return "InGetVehicleModel";
	}

	public String getLastUpdateTime() {
		return LastUpdateTime;
	}

	public void setLastUpdateTime(String lastUpdateTime) {
		LastUpdateTime = lastUpdateTime;
	}

	public ReqVehicle(String lastUpdateTime) {
		super();
		LastUpdateTime = lastUpdateTime;
	}

}
