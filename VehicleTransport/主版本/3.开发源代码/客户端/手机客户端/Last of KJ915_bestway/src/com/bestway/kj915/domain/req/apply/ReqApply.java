package com.bestway.kj915.domain.req.apply;

import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.BasicReqInner;

public class ReqApply extends BasicReqInner {

	public int DepartmentID;
	public int AddressID;
	public int UserID;
	public String DateTime;

	/**
	 * 这个地方的容器是为了保证list集合的外层根节点不会丢失，字段名与节点名必须一致
	 */
	public Container1 ListM_Plan_ApplyMaterie;
	
	public Container2 ListM_Plan_ApplyVehicle;

	/**
	 * 如果xml内部属性还有许多内部属性就直接采用自定义一个类来封装
	 */
	public M_Apply M_Apply;


	@Override
	public String getCmdType() {
		return NetCallback.Flow_Apply;
	}

	@Override
	public String getInnerRootMode() {
		return "InApplyModel";
	}

	
}
