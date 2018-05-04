package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqDepartment extends BasicReqInner {
	public String LastUpdateTime;

	@Override
	public String getCmdType() {
		return NetCallback.Data_GetDepartment;
	}

	@Override
	public String getInnerRootMode() {
		return "InGetDepartmentModel";
	}

	public String getLastUpdateTime() {
		return LastUpdateTime;
	}

	public void setLastUpdateTime(String lastUpdateTime) {
		LastUpdateTime = lastUpdateTime;
	}

	public ReqDepartment(String lastUpdateTime) {
		super();
		LastUpdateTime = lastUpdateTime;
	}

}
