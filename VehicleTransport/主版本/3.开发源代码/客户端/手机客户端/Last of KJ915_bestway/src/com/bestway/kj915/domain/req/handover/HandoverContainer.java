package com.bestway.kj915.domain.req.handover;

import java.util.List;

import com.thoughtworks.xstream.annotations.XStreamImplicit;

public class HandoverContainer {
	@XStreamImplicit(itemFieldName = "m_Plan_Handover")
	public List<m_Plan_Handover> list;
}
