package com.bestway.kj915.domain.req.unload;

import java.util.List;

import com.thoughtworks.xstream.annotations.XStreamImplicit;

public class UnloadContainer {
	@XStreamImplicit(itemFieldName = "m_Plan_UnLoad")
	public List<m_Plan_UnLoad> list;

	public UnloadContainer(List<m_Plan_UnLoad> list) {
		super();
		this.list = list;
	}
}
