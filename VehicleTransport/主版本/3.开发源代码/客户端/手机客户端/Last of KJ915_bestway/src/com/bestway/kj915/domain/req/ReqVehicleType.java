package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqVehicleType extends BasicReqInner {
	public String LastUpdateTime;

	@Override
	public String getCmdType() {
		return NetCallback.Data_GetVehicleType;
	}

	@Override
	public String getInnerRootMode() {
		return "InGetVehicleTypeModel";
	}

	public String getLastUpdateTime() {
		return LastUpdateTime;
	}

	public void setLastUpdateTime(String lastUpdateTime) {
		LastUpdateTime = lastUpdateTime;
	}

	public ReqVehicleType(String lastUpdateTime) {
		super();
		LastUpdateTime = lastUpdateTime;
	}

}
