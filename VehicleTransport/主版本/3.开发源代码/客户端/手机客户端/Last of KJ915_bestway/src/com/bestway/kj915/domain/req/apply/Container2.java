package com.bestway.kj915.domain.req.apply;

import java.util.List;

import com.bestway.kj915.domain.res.plan.m_Plan_ApplyVehicle;
import com.thoughtworks.xstream.annotations.XStreamImplicit;

public class Container2 {
	/**
	 * ��仰�ǹؼ�,��ListԪ�ض�Ӧ�Ľڵ㶼�滻Ϊm_Plan_ApplyMaterie ���ַ�ʽ�ı׶���ʹlist���ϵĽڵ㶪ʧ������ҪǶ��һ������
	 */
	@XStreamImplicit(itemFieldName = "m_Plan_ApplyVehicle")
	public List<m_Plan_ApplyVehicle> list;

	public Container2(List<m_Plan_ApplyVehicle> list) {
		super();
		this.list = list;
	}
}
