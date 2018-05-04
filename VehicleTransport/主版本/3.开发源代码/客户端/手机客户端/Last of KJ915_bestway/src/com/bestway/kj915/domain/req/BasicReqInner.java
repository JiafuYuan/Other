package com.bestway.kj915.domain.req;


/**
 * 封装xml请求的所以javabean类都要继承的类 ，需要发送的属性字段的权限必须是被public所修饰
 * 
 * @author gaga
 * 
 */
public abstract class BasicReqInner {

	/**
	 * 子类必须复写，不能为null，对应xml中的命令类型
	 * 
	 * @return
	 */
	public abstract String getCmdType();

	/**
	 * 子类必须复写，不能为null，对应xml中的内部根节点名称
	 * 
	 * @return
	 */
	public abstract String getInnerRootMode();


}
