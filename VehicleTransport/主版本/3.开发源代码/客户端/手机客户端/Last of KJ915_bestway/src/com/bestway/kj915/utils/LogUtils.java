package com.bestway.kj915.utils;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

import com.bestway.kj915.GlobleValues;
import com.bestway.kj915.dao.BasicDataOpenHelper;

public class LogUtils {

	/**
	 * 打印的是提醒注意的日志，测试阶段使用，app上线后就不打印
	 * 
	 * @param care
	 */
	public static void careLog(Object care) {

		if (GlobleValues.IS_LOG) {
			System.out.println("################注意：" + care);
		}
	}

	public void saveLog() {

		/**
		 * 使用工厂设计模式，采用统一配置的方式添加所有需要的基础数据库表格
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
