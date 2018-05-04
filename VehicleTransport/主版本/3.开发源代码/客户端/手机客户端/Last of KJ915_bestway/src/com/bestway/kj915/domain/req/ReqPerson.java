package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqPerson extends BasicReqInner {
	public String LastUpdateTime;
	@Override
	public String getCmdType() {
		// TODO Auto-generated method stub
		return NetCallback.Data_GetPerson;
	}

	@Override
	public String getInnerRootMode() {
		// TODO Auto-generated method stub
		return "InGetPersonModel";  
	}

	public ReqPerson(String lastUpdateTime) {
		super();
		LastUpdateTime = lastUpdateTime;
	}

}
