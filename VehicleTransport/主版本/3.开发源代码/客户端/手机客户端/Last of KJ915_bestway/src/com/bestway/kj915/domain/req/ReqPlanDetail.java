package com.bestway.kj915.domain.req;

import java.io.Serializable;

import com.bestway.kj915.afinalnet.NetCallback;

/**
 * ��ȡ��������
 * 
 * @author gaga
 * 
 */
public class ReqPlanDetail extends BasicReqInner implements Serializable{

	// ��ʼʱ��

	//public String BeginDateTime;

	//����ʱ��

	//public String EndDateTime;

	//���벿��

	//public int ApplyDepartmentID;

	//Ŀ�ĵ�ID

	//public int ArriveAddressID;
	
	//���ĸ����ڻ�ȡ�˵��ı��
	public String FlowType;

	//��ʼ���

	public int StartIndex;
	
	public boolean IsApplyDepartment;

	//��ҳ��С

	public int PageSize;
	
	public int UserID;

	@Override
	public String getCmdType() {
		
		return NetCallback.Data_GetPlanDetail;
		
	}

	@Override
	public String getInnerRootMode() {
		return "InGetPlanDetailModel";
	}

	public ReqPlanDetail(String flowType, int startIndex, int pageSize,
			int userID) {
		super();
		FlowType = flowType;
		StartIndex = startIndex;
		PageSize = pageSize;
		UserID = userID;
	}
	
}
