package com.bestway.kj915.utils;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

import com.bestway.kj915.GlobleValues;
import com.bestway.kj915.dao.BasicDataOpenHelper;

public class LogUtils {

	/**
	 * ��ӡ��������ע�����־�����Խ׶�ʹ�ã�app���ߺ�Ͳ���ӡ
	 * 
	 * @param care
	 */
	public static void careLog(Object care) {

		if (GlobleValues.IS_LOG) {
			System.out.println("################ע�⣺" + care);
		}
	}

	public void saveLog() {

		/**
		 * ʹ�ù������ģʽ������ͳһ���õķ�ʽ���������Ҫ�Ļ������ݿ���
		 */
		Properties properties = new Properties();

		InputStream is = BasicDataOpenHelper.class.getClassLoader()
				.getResourceAsStream("Log.properties");
		
		try {
			properties.load(is);
		} catch (IOException e) {
			e.printStackTrace();
		}

	}
}
