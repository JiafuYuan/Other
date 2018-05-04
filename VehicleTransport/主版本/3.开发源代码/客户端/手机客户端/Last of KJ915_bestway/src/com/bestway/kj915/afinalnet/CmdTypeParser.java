package com.bestway.kj915.afinalnet;

import java.io.ByteArrayInputStream;

import org.xmlpull.v1.XmlPullParser;

import android.util.Xml;

/**
 * 用于解析xml外部的cmdType，请求的结果，以及内部的xml字符串
 * 
 * @author gaga
 * 
 */
public class CmdTypeParser {

	private static String cmdType;
	private static String inner;
	private static String hasSucceed;

	public static String paser(String result) {
		
		XmlPullParser parser = Xml.newPullParser();
		try {
			// 设置输入流并指明编码方式
			parser.setInput(
					new ByteArrayInputStream(result.getBytes("gb2312")),
					"gb2312");

			int eventType = parser.getEventType();
			while (eventType != XmlPullParser.END_DOCUMENT) {
				switch (eventType) {
				case XmlPullParser.START_TAG:
					if (parser.getName().equals("CmdType")) {
						eventType = parser.next();
						cmdType = parser.getText();
						System.out.println("解析的命令类型》》》" + cmdType);

					} else if (parser.getName().equals("CmdModelXml")) {

						eventType = parser.next();

						
						inner = parser.getText();
					} else if (parser.getName().equals("Result")) {
						eventType = parser.next();
						

						hasSucceed = parser.getText();
						System.out.println("hasSucceed" + hasSucceed);
					}
					break;
				}
				eventType = parser.next();
			}
			
			String back=cmdType + "##" + hasSucceed + "##" + inner;
			inner=null;
			hasSucceed=null;
			cmdType=null;
			
			return back;
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		}
	}

}
