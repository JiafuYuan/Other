package com.bestway.kj915.domain.req;

import com.bestway.kj915.afinalnet.NetCallback;
/**
 * ½Úµã¿ØÖÆ
 * @author hezison
 *
 */
public class ReqFlowPath extends BasicReqInner {
	
	public String useless="0";
	@Override
	public String getCmdType() {
		return NetCallback.GetFlowPath;
	}

	@Override
	public String getInnerRootMode() {
		return "InGetFlowPathModel";
	}

}
