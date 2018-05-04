package com.bestway.kj915.domain.req;

import java.io.Serializable;

import com.bestway.kj915.afinalnet.NetCallback;

/**
 * 获取订单详情
 * 
 * @author gaga
 * 
 */
public class ReqPlanDetail extends BasicReqInner implements Serializable{

	// 开始时间

	//public String BeginDateTime;

	//结束时间

	//public String EndDateTime;

	//申请部门

	//public int ApplyDepartmentID;

	//目的地ID

	//public int ArriveAddressID;
	
	//是哪个环节获取运单的标记
	public String FlowType;

	//开始序号

	public int StartIndex;
	
	public boolean IsApplyDepartment;

	//分页大小

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
