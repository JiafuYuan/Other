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
	 * 序列化外部通用节点
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

			// #1初始化命令的类型
			serializer.startTag("", "CmdType");
			serializer.text(cmdType);
			serializer.endTag("", "CmdType");

			/**
			 * 内部xml不为null的情况下才有必要序列化
			 */
			if (innerXML != null) {
				// #2初始化命令的内部xml
				serializer.startTag("", "CmdModelXml");
				serializer.text(innerXML);
				serializer.endTag("", "CmdModelXml");
			}

			serializer.startTag("", "Result");
			serializer.text("true");
			serializer.endTag("", "Result");
			/**
			 * 设置日期
			 */
			serializer.startTag("", "DateTime");
			serializer.text(TimerUtils.getTime());
			serializer.endTag("", "DateTime");
			/**
			 * 设置本地的IP地址
			 */
			serializer.startTag("", "ClientIP");
			String ip = "";
			ip = WifiUtils.getLocalIpAddress();
			System.out.println(ip);
			serializer.text(ip);
			serializer.endTag("", "ClientIP");

			/**
			 * 设置本地端口
			 */
			serializer.startTag("", "ClientPort");

			serializer.text("####");

			serializer.endTag("", "ClientPort");

			serializer.endTag("", "CommandObjectModel");
			serializer.endDocument();
			return writer.toString();
		} catch (Exception e) {
			e.printStackTrace();
			System.out.println("wifi没打开");
			return null;
		}
	}

	/**
	 * 所有bean对象转换为xml的通用方式
	 * 
	 * @param reqInner
	 * @return
	 */
	public static String serializeCommonReq(BasicReqInner reqInner) {

		XmlSerializer serializer = Xml.newSerializer();
		StringWriter writer = new StringWriter();

		if (reqInner.getInnerRootMode() == null) { // 内部xml为空

			return SerializeXML(null, reqInner.getCmdType());

		} else {// 内部xml不为空

			/**
			 * 利用Xstream完成对内部节点的序列化
			 */
			XStream stream = new XStream();

			/**
			 * 次步骤必不可少，否则注解无效果,Xstream默认是不识别注解的
			 */
			stream.autodetectAnnotations(true);

			// 取消reference的设置 ，否则有类似
			// <m_Plan_ApplyMateriereferencem_Plan_ApplyMaterie="" />
			stream.setMode(XStream.NO_REFERENCES);
			/**
			 * 去掉无用根节点
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
				 * 进行xml串行化
				 */
				serializer.entityRef(streamStr.replaceAll("\\s*", "")
						.replaceAll("__", "_"));

				serializer.endTag("", reqInner.getInnerRootMode());
				serializer.endDocument();

				/**
				 * 去掉无用的字符
				 */
				String str1 = writer.toString().replace(";", "");
				String str2 = str1.replace("&", "");

				System.out.println("bean对象转换成的xml" + str2);

				/**
				 * 返回并进行内部的xml序列化
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
