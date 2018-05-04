package com.bestway.kj915.provider;

/**
 * 版权：南京北路自动化系统有限责任公司版权所有
 * 
 * 作者：詹学勇
 * 
 * 版本：1.0
 * 
 * 时间：2014-9-18 上午10:18:02
 */

import java.io.InputStream;
import java.util.Properties;

import android.content.ContentProvider;
import android.content.ContentValues;
import android.content.UriMatcher;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;

import com.bestway.kj915.dao.BasicDataOpenHelper;
import com.bestway.kj915.utils.LogUtils;

/**
 * 所有基础数据的内容提供者的统一入口
 * 
 * @author gaga
 * 
 */
public class Basic_db_Provider extends ContentProvider {

	private final Uri NOTIFY_URI = Uri.parse("content://cart");

	private static final String AUTHORITY = "com.bestway.kj915.provider.Basic_db_Provider";

	/**
	 * 所有增删改查操作的匹配码
	 */
	private static final int QUERY_ONE_CODE = 100;// 查询一条
	private static final int QUERY_ALL_CODE = 200;// 查询所有

	private static final int DELETE_ONE_CODE = 300;// 删除一条
	private static final int DELETE_ALL_CODE = 400;// 删除所有

	private static final int UPDATE_CODE = 500;// 修改

	private BasicDataOpenHelper dbHelper;

	/**
	 * 匹配工具
	 */
	private static final UriMatcher mUriMatcher;

	/**
	 * bean.property的实体对象
	 */
	public static Properties properties;

	/**
	 * 静态代码块进行初始化操作
	 */
	static {

		mUriMatcher = new UriMatcher(UriMatcher.NO_MATCH);

		// 添加操作的Uri:content://com.bestway.kj915.provider.Basic_db_Provider/insert
		try {
			/**
			 * 使用工厂设计模式，采用统一配置的方式添加所有需要的基础数据库表格
			 */
			properties = new Properties();

			InputStream is = Basic_db_Provider.class.getClassLoader()
					.getResourceAsStream("bean.properties");

			properties.load(is);

			for (Object o : properties.keySet()) {

				Class clazz = Class.forName(properties.getProperty((String) o));

				// 获取对应的表格名称和匹配吗
				String simpleName = clazz.getSimpleName();

				// 获取键的值
				int num = Integer.valueOf((String) o);

				// @1给所有的表格注册添加的uri和匹配码
				mUriMatcher.addURI(AUTHORITY, "insert/" + simpleName, num);

				// @2给所有的表格注册查询一条的uri和匹配码
				mUriMatcher.addURI(AUTHORITY, "query/one/" + simpleName,
						QUERY_ONE_CODE + num);

				// @3给所有的表格注册查询所有的uri和匹配码
				mUriMatcher.addURI(AUTHORITY, "query/all/" + simpleName,
						QUERY_ALL_CODE + num);

				// @4给所有的表格注册删除一条的uri和匹配码
				mUriMatcher.addURI(AUTHORITY, "delete/one/" + simpleName,
						DELETE_ONE_CODE + num);

				// @5给所有的表格注册删除所有的uri和匹配码
				mUriMatcher.addURI(AUTHORITY, "delete/all/" + simpleName,
						DELETE_ALL_CODE + num);

				// @6给所有的表格注册修改的uri和匹配码
				mUriMatcher.addURI(AUTHORITY, "update/" + simpleName,
						UPDATE_CODE + num);

			}

		} catch (Exception e) {

			e.printStackTrace();

		}

	}

	/**
	 * 获取数据库操作相关类
	 */
	@Override
	public boolean onCreate() {

		dbHelper = new BasicDataOpenHelper(getContext());

		return false;
	}

	/**
	 * 所有表格的增添操作
	 */
	@Override
	public Uri insert(Uri uri, ContentValues values) {

		LogUtils.careLog(uri);

		SQLiteDatabase db = dbHelper.getWritableDatabase();

		LogUtils.careLog("nima" + mUriMatcher.match(uri));

		int code = mUriMatcher.match(uri);

		LogUtils.careLog("嘎嘎嘎");

		if (db.isOpen()) {

			try {

				db.insert((Class.forName((String) properties.get(code + "")))
						.getSimpleName(), null, values);

			} catch (ClassNotFoundException e) {

				e.printStackTrace();

			}
			LogUtils.careLog("添加一条成功");
			// 提醒改变
			getContext().getContentResolver().notifyChange(NOTIFY_URI, null);
		}

		return null;
	}

	/**
	 * 所有表格的查询操作
	 */
	@Override
	public Cursor query(Uri uri, String[] projection, String selection,
			String[] selectionArgs, String sortOrder) {

		SQLiteDatabase db = dbHelper.getReadableDatabase();

		int code = mUriMatcher.match(uri);

		/**
		 * 查询一条
		 */
		if (QUERY_ONE_CODE < code && code < QUERY_ONE_CODE + 100) {

			try {

				if (db.isOpen()) {

					Class cl = Class.forName(properties
							.getProperty((code - QUERY_ONE_CODE) + ""));

					Cursor cursor = db.query(cl.getSimpleName(), projection,
							selection, selectionArgs, null, null, sortOrder);

					LogUtils.careLog("按条件查询" + cursor.getCount());

					// 给Cursor设置一个标识
					cursor.setNotificationUri(
							getContext().getContentResolver(), NOTIFY_URI);

					return cursor;

				} else {

					return null;

				}

			} catch (Exception e) {

				e.printStackTrace();

				return null;
			}
		}

		/**
		 * 查询所有
		 */
		else {

			try {

				if (db.isOpen()) {

					LogUtils.careLog(code);

					LogUtils.careLog("gagagagag"
							+ properties.getProperty((code - QUERY_ALL_CODE)
									+ ""));

					Class cl = Class.forName(properties
							.getProperty((code - QUERY_ALL_CODE) + ""));

					Cursor cursor = db.query(cl.getSimpleName(), projection,
							selection, selectionArgs, null, null, sortOrder);

					LogUtils.careLog("数据库中的数量" + cursor.getCount());
					// 给Cursor设置一个标识
					cursor.setNotificationUri(
							getContext().getContentResolver(), NOTIFY_URI);

					return cursor;

				} else {

					return null;

				}

			} catch (Exception e) {

				e.printStackTrace();

				return null;

			}
		}

	}

	/**
	 * 所有表格的删除操作
	 */
	@Override
	public int delete(Uri uri, String selection, String[] selectionArgs) {
		SQLiteDatabase db = dbHelper.getWritableDatabase();

		int code = mUriMatcher.match(uri);

		int deleteCount = 0;

		if (DELETE_ONE_CODE < code && code < DELETE_ALL_CODE) {// 删除一条

			try {
				if (db.isOpen()) {

					Class cl = Class.forName(properties
							.getProperty((code - DELETE_ONE_CODE) + ""));
					/*
					 * 取出Uri中id long ID = ContentUris.parseId(uri);
					 */

					// 根据群组的id删除对应的群组
					int count = db.delete(cl.getSimpleName(), selection,
							selectionArgs);
					// 通知更新
					LogUtils.careLog("删除一条");

					getContext().getContentResolver().notifyChange(NOTIFY_URI,
							null);

					deleteCount = count;

				}

			} catch (Exception e) {

				e.printStackTrace();

			}

		} else {// 删除所有条
			try {
				if (db.isOpen()) {

					Class cl = Class.forName(properties
							.getProperty((code - DELETE_ALL_CODE) + ""));

					LogUtils.careLog("删除cart中所有的数据");

					int count = db.delete(cl.getSimpleName(), null, null);

					getContext().getContentResolver().notifyChange(NOTIFY_URI,
							null);

					deleteCount = count;

				}
			} catch (Exception e) {

				e.printStackTrace();

			}
		}

		return deleteCount;
	}

	/**
	 * 所有表格的更新操作
	 */
	@Override
	public int update(Uri uri, ContentValues values, String selection,
			String[] selectionArgs) {

		int updateCount = 0;

		try {

			int code = mUriMatcher.match(uri);

			Class cl = Class.forName(properties
					.getProperty((code - UPDATE_CODE) + ""));

			SQLiteDatabase db = dbHelper.getWritableDatabase();

			if (db.isOpen()) {

				updateCount = db.update(cl.getSimpleName(), values, selection,
						selectionArgs);
				// 通知一下更新了
				getContext().getContentResolver()
						.notifyChange(NOTIFY_URI, null);

			}

		} catch (Exception e) {

			e.printStackTrace();

		}

		return updateCount;
	}

	@Override
	public String getType(Uri uri) {

		return null;

	}
}
