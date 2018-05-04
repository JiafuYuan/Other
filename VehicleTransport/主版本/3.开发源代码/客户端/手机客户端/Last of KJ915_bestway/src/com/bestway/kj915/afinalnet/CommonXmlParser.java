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
		 * ��ʼ��������
		 */
		XStream xstream = new XStream(new DomDriver());

		/**
		 * ��xml�еĽڵ����Զ�����һһ��Ӧ
		 */
		if (resInner.getMyDefineClass() != null) {
			for (String key : resInner.getMyDefineClass().keySet()) {
				xstream.alias(key, resInner.getMyDefineClass().get(key));
			}
		}
		/**
		 * ���������뼯�����еļ����ֶ�����һһ��Ӧ
		 */
		if (resInner.getList() != null) {
			for (String key : resInner.getList().keySet()) {
				xstream.addImplicitCollection(resInner.getList().get(key), key);
			}
		}
		/**
		 * ת��
		 */
		BasicResInner inner = (BasicResInner) xstream.fromXML(xml);
		return inner;
	}

	/**
	 * ����
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
