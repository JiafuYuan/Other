package com.bestway.kj915.domain.req.apply;

import java.util.List;

import com.thoughtworks.xstream.annotations.XStreamImplicit;

public class Container1 {   
	/**
	 * ��仰�ǹؼ�,��ListԪ�ض�Ӧ�Ľڵ㶼�滻Ϊm_Plan_ApplyMaterie ���ַ�ʽ�ı׶���ʹlist���ϵĽڵ㶪ʧ������ҪǶ��һ������
	 */
	@XStreamImplicit(itemFieldName = "m_Plan_ApplyMaterie")
	public List<ListM_Plan_ApplyMaterie_Item> list;

	public Container1(List<ListM_Plan_ApplyMaterie_Item> list) {
		super();
		this.list = list;
	}

}