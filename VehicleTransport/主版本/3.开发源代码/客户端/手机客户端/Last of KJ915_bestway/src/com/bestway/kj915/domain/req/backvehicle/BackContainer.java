package com.bestway.kj915.domain.req.backvehicle;

import java.util.List;

import com.bestway.kj915.domain.req.load.m_Plan_Load;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

public class BackContainer {

	@XStreamImplicit(itemFieldName = "m_Plan_BackVehicle")
	public List<m_Plan_BackVehicle> list;

	public BackContainer(List<m_Plan_BackVehicle> list) {
		super();
		this.list = list;
	}

	public BackContainer() {
		super();
	}
}
