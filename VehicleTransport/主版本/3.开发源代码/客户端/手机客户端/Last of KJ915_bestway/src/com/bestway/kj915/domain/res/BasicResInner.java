package com.bestway.kj915.domain.res;

import java.util.HashMap;

/**
 * 所有响应的javabean都要继承的类
 * 
 * @author gaga
 * 
 */
public abstract class BasicResInner {
	/**
	 * 里面封装的是响应bean关联的所有的自定义bean的字节码和bean对象在节点中的名称
	 * 
	 * @return
	 */

	public abstract HashMap<String, Class> getMyDefineClass();

	/**
	 * 里面封装的响应bean所关联的集合对象的字段名称，以及集合所在类的字节码
	 * 
	 * @return
	 */
	public abstract HashMap<String, Class> getList();

	/**
	 * 作为获取新的map集合的小工具
	 * 
	 * @return
	 */
	public HashMap<String, Class> getNewEmpty() {
		return new HashMap<String, Class>();
	}
}
