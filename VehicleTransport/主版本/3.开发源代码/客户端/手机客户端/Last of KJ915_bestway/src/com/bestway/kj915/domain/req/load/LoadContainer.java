package com.bestway.kj915.domain.req.load;

import java.util.List;

import com.thoughtworks.xstream.annotations.XStreamImplicit;

public class LoadContainer {
	
	@XStreamImplicit(itemFieldName = "m_Plan_Load")
	public List<m_Plan_Load> list;

	public LoadContainer(List<m_Plan_Load> list) {
		super();
		this.list = list;
	}

	public LoadContainer() {
		super();
	}
	
	
}
