package com.bestway.kj915.domain.res;

import java.util.HashMap;

/**
 * ������Ӧ��javabean��Ҫ�̳е���
 * 
 * @author gaga
 * 
 */
public abstract class BasicResInner {
	/**
	 * �����װ������Ӧbean���������е��Զ���bean���ֽ����bean�����ڽڵ��е�����
	 * 
	 * @return
	 */

	public abstract HashMap<String, Class> getMyDefineClass();

	/**
	 * �����װ����Ӧbean�������ļ��϶�����ֶ����ƣ��Լ�������������ֽ���
	 * 
	 * @return
	 */
	public abstract HashMap<String, Class> getList();

	/**
	 * ��Ϊ��ȡ�µ�map���ϵ�С����
	 * 
	 * @return
	 */
	public HashMap<String, Class> getNewEmpty() {
		return new HashMap<String, Class>();
	}
}
