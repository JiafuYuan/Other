package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;

public class ReqHeartBeat extends BasicReqInner {

	public String PDAMac;
	public int UserID;
	public String WifiBaseStationMac;

	public ReqHeartBeat(String pDAMac, int userID, String wifiBaseStationMac) {
		super();
		PDAMac = pDAMac;
		UserID = userID;
		WifiBaseStationMac = wifiBaseStationMac;
	}

	@Override
	public String getCmdType() {
		return NetCallback.HeartBeat;
	}

	@Override
	public String getInnerRootMode() {
		return "InHeartBeatModel";
	}


}
