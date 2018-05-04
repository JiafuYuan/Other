package com.bestway.kj915.dao;

/**
 * ��Ȩ���Ͼ���·�Զ���ϵͳ�������ι�˾��Ȩ����
 * 
 * ���ߣ�ղѧ��
 * 
 * �汾��1.0
 * 
 * ʱ�䣺2014-9-17 ����5:03:50
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
	 * ���캯���������ݿ�
	 * 
	 * @param context
	 */
	public BasicDataOpenHelper(Context context) {

		super(context, NAME, null, 1);

	}

	/**
	 * ��ʼ�����
	 */
	@Override
	public void onCreate(SQLiteDatabase db) {

		try {

			/**
			 * ʹ�ù������ģʽ������ͳһ���õķ�ʽ���������Ҫ�Ļ������ݿ���
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
				 * ��ȡ�������ƣ�����������齨
				 */
				String tableName = clazz.getSimpleName();

				buf.append(tableName + "(");

				/**
				 * �����ȡ���е��ֶΣ����������ݿ�������
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
				 * �޳�����һ������
				 */
				String finalSql = buf.toString();

				int dian = finalSql.indexOf(",");

				String f = finalSql.substring(0, dian)
						+ finalSql.substring(dian + 1);

				/**
				 * �������ݿ���
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
