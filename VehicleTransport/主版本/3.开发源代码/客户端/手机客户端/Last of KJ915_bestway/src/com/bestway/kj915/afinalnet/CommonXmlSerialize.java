package com.bestway.kj915.afinalnet;

import java.io.StringWriter;
import java.text.SimpleDateFormat;
import java.util.Date;

import org.xmlpull.v1.XmlSerializer;

import android.util.Xml;

import com.bestway.kj915.domain.req.BasicReqInner;
import com.bestway.kj915.utils.TimerUtils;
import com.thoughtworks.xstream.XStream;

public class CommonXmlSerialize {

	/**
	 * ���л��ⲿͨ�ýڵ�
	 * 
	 * @param innerXML
	 * @param cmdType
	 * @return
	 */
	private static String SerializeXML(String innerXML, String cmdType) {

		XmlSerializer serializer = Xml.newSerializer();
		StringWriter writer = new StringWriter();
		try {
			serializer.setOutput(writer);
			serializer.startDocument("gb2312", true);
			serializer.startTag("", "CommandObjectModel");

			serializer.startTag("", "CmdID");
			serializer.text("61398511");
			serializer.endTag("", "CmdID");

			// #1��ʼ�����������
			serializer.startTag("", "CmdType");
			serializer.text(cmdType);
			serializer.endTag("", "CmdType");

			/**
			 * �ڲ�xml��Ϊnull������²��б�Ҫ���л�
			 */
			if (innerXML != null) {
				// #2��ʼ��������ڲ�xml
				serializer.startTag("", "CmdModelXml");
				serializer.text(innerXML);
				serializer.endTag("", "CmdModelXml");
			}

			serializer.startTag("", "Result");
			serializer.text("true");
			serializer.endTag("", "Result");
			/**
			 * ��������
			 */
			serializer.startTag("", "DateTime");
			serializer.text(TimerUtils.getTime());
			serializer.endTag("", "DateTime");
			/**
			 * ���ñ��ص�IP��ַ
			 */
			serializer.startTag("", "ClientIP");
			String ip = "";
			ip = WifiUtils.getLocalIpAddress();
			System.out.println(ip);
			serializer.text(ip);
			serializer.endTag("", "ClientIP");

			/**
			 * ���ñ��ض˿�
			 */
			serializer.startTag("", "ClientPort");

			serializer.text("####");

			serializer.endTag("", "ClientPort");

			serializer.endTag("", "CommandObjectModel");
			serializer.endDocument();
			return writer.toString();
		} catch (Exception e) {
			e.printStackTrace();
			System.out.println("wifiû��");
			return null;
		}
	}

	/**
	 * ����bean����ת��Ϊxml��ͨ�÷�ʽ
	 * 
	 * @param reqInner
	 * @return
	 */
	public static String serializeCommonReq(BasicReqInner reqInner) {

		XmlSerializer serializer = Xml.newSerializer();
		StringWriter writer = new StringWriter();

		if (reqInner.getInnerRootMode() == null) { // �ڲ�xmlΪ��

			return SerializeXML(null, reqInner.getCmdType());

		} else {// �ڲ�xml��Ϊ��

			/**
			 * ����Xstream��ɶ��ڲ��ڵ�����л�
			 */
			XStream stream = new XStream();

			/**
			 * �β���ز����٣�����ע����Ч��,XstreamĬ���ǲ�ʶ��ע���
			 */
			stream.autodetectAnnotations(true);

			// ȡ��reference������ ������������
			// <m_Plan_ApplyMateriereferencem_Plan_ApplyMaterie="" />
			stream.setMode(XStream.NO_REFERENCES);
			/**
			 * ȥ�����ø��ڵ�
			 */
			String xInner = stream.toXML(reqInner);
			int start = xInner.indexOf(">") + 1;
			int end = xInner.lastIndexOf("<");
			System.out.println("xInnerxInnerxInnerxInner" + xInner);
			String streamStr = xInner.substring(start, end).trim();
			try {

				serializer.setOutput(writer);

				serializer.startDocument("gb2312", true);
				serializer.startTag("", reqInner.getInnerRootMode());

				/**
				 * ����xml���л�
				 */
				serializer.entityRef(streamStr.replaceAll("\\s*", "")
						.replaceAll("__", "_"));

				serializer.endTag("", reqInner.getInnerRootMode());
				serializer.endDocument();

				/**
				 * ȥ�����õ��ַ�
				 */
				String str1 = writer.toString().replace(";", "");
				String str2 = str1.replace("&", "");

				System.out.println("bean����ת���ɵ�xml" + str2);

				/**
				 * ���ز������ڲ���xml���л�
				 */
				return SerializeXML(
						str2.trim()
								.replace(
										//
										"?xml version='1.0' encoding='gb2312' standalone='yes' ?",
										"?xml version=\"1.0\" encoding=\"gb2312\"?"),
						reqInner.getCmdType());

			} catch (Exception e) {
				e.printStackTrace();
				return null;
			}

		}
	}

}
