package com.bestway.kj915.afinalnet;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.io.UnsupportedEncodingException;

import com.bestway.kj915.domain.res.BasicResInner;
import com.thoughtworks.xstream.XStream;
import com.thoughtworks.xstream.io.xml.DomDriver;

public class CommonXmlParser {

	

	public static BasicResInner parserXml(InputStream xml,
			BasicResInner resInner) {
		/**
		 * 初始化工具类
		 */
		XStream xstream = new XStream(new DomDriver());

		/**
		 * 将xml中的节点与自定义类一一对应
		 */
		if (resInner.getMyDefineClass() != null) {
			for (String key : resInner.getMyDefineClass().keySet()) {
				xstream.alias(key, resInner.getMyDefineClass().get(key));
			}
		}
		/**
		 * 将集合类与集合类中的集合字段名称一一对应
		 */
		if (resInner.getList() != null) {
			for (String key : resInner.getList().keySet()) {
				xstream.addImplicitCollection(resInner.getList().get(key), key);
			}
		}
		/**
		 * 转换
		 */
		BasicResInner inner = (BasicResInner) xstream.fromXML(xml);
		return inner;
	}

	/**
	 * 重载
	 * 
	 * @param xml
	 * @param resInner
	 * @return
	 */
	public static BasicResInner parserXml(String xml, BasicResInner resInner) {
		ByteArrayInputStream in;
		try {
			in = new ByteArrayInputStream(xml.getBytes("gb2312"));
			return parserXml(in, resInner);
		} catch (UnsupportedEncodingException e) {
			e.printStackTrace();
			return null;
		}
		
	}
}
