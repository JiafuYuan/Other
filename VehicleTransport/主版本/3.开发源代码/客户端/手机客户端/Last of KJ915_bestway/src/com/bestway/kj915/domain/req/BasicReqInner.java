package com.bestway.kj915.domain.req;


/**
 * ��װxml���������javabean�඼Ҫ�̳е��� ����Ҫ���͵������ֶε�Ȩ�ޱ����Ǳ�public������
 * 
 * @author gaga
 * 
 */
public abstract class BasicReqInner {

	/**
	 * ������븴д������Ϊnull����Ӧxml�е���������
	 * 
	 * @return
	 */
	public abstract String getCmdType();

	/**
	 * ������븴д������Ϊnull����Ӧxml�е��ڲ����ڵ�����
	 * 
	 * @return
	 */
	public abstract String getInnerRootMode();


}
