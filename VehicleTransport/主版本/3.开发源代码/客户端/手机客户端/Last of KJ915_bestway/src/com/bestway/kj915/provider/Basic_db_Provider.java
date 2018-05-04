package com.bestway.kj915.provider;

/**
 * ��Ȩ���Ͼ���·�Զ���ϵͳ�������ι�˾��Ȩ����
 * 
 * ���ߣ�ղѧ��
 * 
 * �汾��1.0
 * 
 * ʱ�䣺2014-9-18 ����10:18:02
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
 * ���л������ݵ������ṩ�ߵ�ͳһ���
 * 
 * @author gaga
 * 
 */
public class Basic_db_Provider extends ContentProvider {

	private final Uri NOTIFY_URI = Uri.parse("content://cart");

	private static final String AUTHORITY = "com.bestway.kj915.provider.Basic_db_Provider";

	/**
	 * ������ɾ�Ĳ������ƥ����
	 */
	private static final int QUERY_ONE_CODE = 100;// ��ѯһ��
	private static final int QUERY_ALL_CODE = 200;// ��ѯ����

	private static final int DELETE_ONE_CODE = 300;// ɾ��һ��
	private static final int DELETE_ALL_CODE = 400;// ɾ������

	private static final int UPDATE_CODE = 500;// �޸�

	private BasicDataOpenHelper dbHelper;

	/**
	 * ƥ�乤��
	 */
	private static final UriMatcher mUriMatcher;

	/**
	 * bean.property��ʵ�����
	 */
	public static Properties properties;

	/**
	 * ��̬�������г�ʼ������
	 */
	static {

		mUriMatcher = new UriMatcher(UriMatcher.NO_MATCH);

		// ��Ӳ�����Uri:content://com.bestway.kj915.provider.Basic_db_Provider/insert
		try {
			/**
			 * ʹ�ù������ģʽ������ͳһ���õķ�ʽ���������Ҫ�Ļ������ݿ���
			 */
			properties = new Properties();

			InputStream is = Basic_db_Provider.class.getClassLoader()
					.getResourceAsStream("bean.properties");

			properties.load(is);

			for (Object o : properties.keySet()) {

				Class clazz = Class.forName(properties.getProperty((String) o));

				// ��ȡ��Ӧ�ı�����ƺ�ƥ����
				String simpleName = clazz.getSimpleName();

				// ��ȡ����ֵ
				int num = Integer.valueOf((String) o);

				// @1�����еı��ע����ӵ�uri��ƥ����
				mUriMatcher.addURI(AUTHORITY, "insert/" + simpleName, num);

				// @2�����еı��ע���ѯһ����uri��ƥ����
				mUriMatcher.addURI(AUTHORITY, "query/one/" + simpleName,
						QUERY_ONE_CODE + num);

				// @3�����еı��ע���ѯ���е�uri��ƥ����
				mUriMatcher.addURI(AUTHORITY, "query/all/" + simpleName,
						QUERY_ALL_CODE + num);

				// @4�����еı��ע��ɾ��һ����uri��ƥ����
				mUriMatcher.addURI(AUTHORITY, "delete/one/" + simpleName,
						DELETE_ONE_CODE + num);

				// @5�����еı��ע��ɾ�����е�uri��ƥ����
				mUriMatcher.addURI(AUTHORITY, "delete/all/" + simpleName,
						DELETE_ALL_CODE + num);

				// @6�����еı��ע���޸ĵ�uri��ƥ����
				mUriMatcher.addURI(AUTHORITY, "update/" + simpleName,
						UPDATE_CODE + num);

			}

		} catch (Exception e) {

			e.printStackTrace();

		}

	}

	/**
	 * ��ȡ���ݿ���������
	 */
	@Override
	public boolean onCreate() {

		dbHelper = new BasicDataOpenHelper(getContext());

		return false;
	}

	/**
	 * ���б����������
	 */
	@Override
	public Uri insert(Uri uri, ContentValues values) {

		LogUtils.careLog(uri);

		SQLiteDatabase db = dbHelper.getWritableDatabase();

		LogUtils.careLog("nima" + mUriMatcher.match(uri));

		int code = mUriMatcher.match(uri);

		LogUtils.careLog("�¸¸�");

		if (db.isOpen()) {

			try {

				db.insert((Class.forName((String) properties.get(code + "")))
						.getSimpleName(), null, values);

			} catch (ClassNotFoundException e) {

				e.printStackTrace();

			}
			LogUtils.careLog("���һ���ɹ�");
			// ���Ѹı�
			getContext().getContentResolver().notifyChange(NOTIFY_URI, null);
		}

		return null;
	}

	/**
	 * ���б��Ĳ�ѯ����
	 */
	@Override
	public Cursor query(Uri uri, String[] projection, String selection,
			String[] selectionArgs, String sortOrder) {

		SQLiteDatabase db = dbHelper.getReadableDatabase();

		int code = mUriMatcher.match(uri);

		/**
		 * ��ѯһ��
		 */
		if (QUERY_ONE_CODE < code && code < QUERY_ONE_CODE + 100) {

			try {

				if (db.isOpen()) {

					Class cl = Class.forName(properties
							.getProperty((code - QUERY_ONE_CODE) + ""));

					Cursor cursor = db.query(cl.getSimpleName(), projection,
							selection, selectionArgs, null, null, sortOrder);

					LogUtils.careLog("��������ѯ" + cursor.getCount());

					// ��Cursor����һ����ʶ
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
		 * ��ѯ����
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

					LogUtils.careLog("���ݿ��е�����" + cursor.getCount());
					// ��Cursor����һ����ʶ
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
	 * ���б���ɾ������
	 */
	@Override
	public int delete(Uri uri, String selection, String[] selectionArgs) {
		SQLiteDatabase db = dbHelper.getWritableDatabase();

		int code = mUriMatcher.match(uri);

		int deleteCount = 0;

		if (DELETE_ONE_CODE < code && code < DELETE_ALL_CODE) {// ɾ��һ��

			try {
				if (db.isOpen()) {

					Class cl = Class.forName(properties
							.getProperty((code - DELETE_ONE_CODE) + ""));
					/*
					 * ȡ��Uri��id long ID = ContentUris.parseId(uri);
					 */

					// ����Ⱥ���idɾ����Ӧ��Ⱥ��
					int count = db.delete(cl.getSimpleName(), selection,
							selectionArgs);
					// ֪ͨ����
					LogUtils.careLog("ɾ��һ��");

					getContext().getContentResolver().notifyChange(NOTIFY_URI,
							null);

					deleteCount = count;

				}

			} catch (Exception e) {

				e.printStackTrace();

			}

		} else {// ɾ��������
			try {
				if (db.isOpen()) {

					Class cl = Class.forName(properties
							.getProperty((code - DELETE_ALL_CODE) + ""));

					LogUtils.careLog("ɾ��cart�����е�����");

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
	 * ���б��ĸ��²���
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
				// ֪ͨһ�¸�����
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
