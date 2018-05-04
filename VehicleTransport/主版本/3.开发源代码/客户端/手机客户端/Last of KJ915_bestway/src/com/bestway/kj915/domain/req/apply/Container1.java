package com.bestway.kj915.domain.req.apply;

import java.util.List;

import com.thoughtworks.xstream.annotations.XStreamImplicit;

public class Container1 {   
	/**
	 * 这句话是关键,将List元素对应的节点都替换为m_Plan_ApplyMaterie 这种方式的弊端是使list集合的节点丢失，所有要嵌套一层容器
	 */
	@XStreamImplicit(itemFieldName = "m_Plan_ApplyMaterie")
	public List<ListM_Plan_ApplyMaterie_Item> list;

	public Container1(List<ListM_Plan_ApplyMaterie_Item> list) {
		super();
		this.list = list;
	}

}