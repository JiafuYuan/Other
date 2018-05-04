package com.bestway.kj915.domain.req.apply;

import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.domain.req.BasicReqInner;

public class ReqApply extends BasicReqInner {

	public int DepartmentID;
	public int AddressID;
	public int UserID;
	public String DateTime;

	/**
	 * ����ط���������Ϊ�˱�֤list���ϵ������ڵ㲻�ᶪʧ���ֶ�����ڵ�������һ��
	 */
	public Container1 ListM_Plan_ApplyMaterie;
	
	public Container2 ListM_Plan_ApplyVehicle;

	/**
	 * ���xml�ڲ����Ի�������ڲ����Ծ�ֱ�Ӳ����Զ���һ��������װ
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
