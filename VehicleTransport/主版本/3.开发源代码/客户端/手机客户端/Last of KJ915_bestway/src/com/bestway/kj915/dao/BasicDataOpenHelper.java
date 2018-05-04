package com.bestway.kj915.dao;

/**
 * 版权：南京北路自动化系统有限责任公司版权所有
 * 
 * 作者：詹学勇
 * 
 * 版本：1.0
 * 
 * 时间：2014-9-17 下午5:03:50
 */
import java.io.IOException;
import java.io.InputStream;
import java.lang.reflect.Field;
import java.util.Properties;

import com.bestway.kj915.utils.LogUtils;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class BasicDataOpenHelper extends SQLiteOpenHelper {

	static String NAME = "basic_data.db";

	/**
	 * 构造函数创建数据库
	 * 
	 * @param context
	 */
	public BasicDataOpenHelper(Context context) {

		super(context, NAME, null, 1);

	}

	/**
	 * 初始化表格
	 */
	@Override
	public void onCreate(SQLiteDatabase db) {

		try {

			/**
			 * 使用工厂设计模式，采用统一配置的方式添加所有需要的基础数据库表格
			 */
			Properties properties = new Properties();

			InputStream is = BasicDataOpenHelper.class.getClassLoader()
					.getResourceAsStream("bean.properties");

			try {

				properties.load(is);

			} catch (IOException e) {

				e.printStackTrace();

			}

			for (Object o : properties.values()) {

				StringBuffer buf = new StringBuffer("create table ");

				String path = (String) o;

				LogUtils.careLog(path);

				Class clazz = Class.forName(path);// "com.bestway.kj915.domain.reflect.m_Department"

				/**
				 * 获取表格的名称，并进行语句组建
				 */
				String tableName = clazz.getSimpleName();

				buf.append(tableName + "(");

				/**
				 * 反射获取所有的字段，并创建数据库添加语句
				 */
				Field[] field = clazz.getFields();

				for (Field f : field) {

					if (f.getName().equals("ID")) {

						buf.append(",ID integer primary key");// autoincrement

					} else {

						if (f.getType() == int.class) {

							buf.append("," + f.getName() + " integer");

						} else if (f.getType() == String.class) {

							buf.append("," + f.getName() + " String");

						}
					}
				}

				buf.append(")");

				/**
				 * 剔除掉第一个逗号
				 */
				String finalSql = buf.toString();

				int dian = finalSql.indexOf(",");

				String f = finalSql.substring(0, dian)
						+ finalSql.substring(dian + 1);

				/**
				 * 创建数据库表格
				 */
				db.execSQL(f);

			}
		} catch (Exception e) {

			e.printStackTrace();

		}
	}

	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

	}
}
