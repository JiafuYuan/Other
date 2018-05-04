package com.bestway.kj915.dao;

/**
 * ��Ȩ���Ͼ���·�Զ���ϵͳ�������ι�˾��Ȩ����
 * 
 * ���ߣ�ղѧ��
 * 
 * �汾��1.0
 * 
 * ʱ�䣺2014-9-17 ����5:03:35
 */
import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.List;

import android.content.ContentResolver;
import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.net.Uri;

/**
 * �������ݿ��ͨ�ù�����
 * 
 * @author gaga
 * 
 */
public class CommonDbUtiles {

	/**
	 * ���һ��
	 * 
	 * @param context
	 * @param obj
	 *            ���ݿ����Ӧ��bean����
	 */
	public static void insert(Context context, Object obj) {
		// �õ�ͳһ����
		ContentResolver resolver = context.getContentResolver();

		ContentValues values = new ContentValues();

		Field[] fields = obj.getClass().getFields();

		// ��values׼��ֵ
		for (Field f : fields) {

			try {
				if (!f.getName().equals("ID") || f.getName().equals("ID")) {//

					if (f.getType() == int.class) {

						if (f.get(obj) != null)

							values.put(f.getName(),
									Integer.valueOf(f.get(obj).toString()));

					} else if (f.getType() == String.class) {

						if (f.get(obj) != null)

							values.put(f.getName(), f.get(obj).toString());

					}
				}

			} catch (Exception e) {

				e.printStackTrace();

			}
		}
		// �ύ
		resolver.insert(
				Uri.parse("content://com.bestway.kj915.provider.Basic_db_Provider/insert/"
						+ obj.getClass().getSimpleName()), values);

	}

	/**
	 * ͨ�õģ���ѯ���еĲ���
	 * 
	 * @param context
	 * @param clazz
	 * @return
	 */
	public static <T> List<T> querryAll(Context context, Class<T> clazz) {

		// ׼���ؼ�����
		List<T> li = new ArrayList<T>();

		ContentResolver r = context.getContentResolver();

		Cursor cursor = r
				.query(Uri
						.parse("content://com.bestway.kj915.provider.Basic_db_Provider/query/all/"
								+ clazz.getSimpleName()), null, null, null,
						null);

		while (cursor.moveToNext()) {
			try {
				// ����
				T ins = clazz.newInstance();

				Field[] fields = clazz.getFields();

				// ���ֶ�ѭ�������Լ���ֵ
				for (Field f : fields) {

					if (f.getType() == int.class) {

						int num = cursor.getInt(cursor.getColumnIndex(f
								.getName()));

						f.set(ins, num);

					} else if (f.getType() == String.class) {

						String str = cursor.getString(cursor.getColumnIndex(f
								.getName()));

						f.set(ins, str);

					}

				}

				li.add(ins);

			} catch (Exception e) {

				e.printStackTrace();

			}
		}

		cursor.close();
		
		return li;
	}

	/**
	 * ����������ѯ
	 * 
	 * @param context
	 *            ������
	 * @param clazz
	 *            �ֽ���
	 * @param selection
	 *            ��ѯ����where
	 * @param selectionArgs
	 *            ��ѯ�Ĳ���
	 * @param sortOrder
	 *            ����
	 * @return
	 */
	public static <T> List<T> querryByConditions(Context context,
			Class<T> clazz, String selection, String[] selectionArgs,
			String sortOrder) {

		List<T> li = new ArrayList<T>();

		ContentResolver resolver = context.getContentResolver();

		Uri uri = Uri
				.parse("content://com.bestway.kj915.provider.Basic_db_Provider/query/one/"
						+ clazz.getSimpleName());

		Cursor cursor = resolver.query(uri, null, selection, selectionArgs,
				sortOrder);

		while (cursor.moveToNext()) {

			try {
				// ����
				T ins = clazz.newInstance();

				Field[] fields = clazz.getFields();

				// ���ֶ�ѭ�������Լ���ֵ
				for (Field f : fields) {

					if (f.getType() == int.class) {

						int num = cursor.getInt(cursor.getColumnIndex(f
								.getName()));

						f.set(ins, num);

					} else if (f.getType() == String.class) {

						String str = cursor.getString(cursor.getColumnIndex(f
								.getName()));

						f.set(ins, str);
					}

				}

				li.add(ins);
			} catch (Exception e) {

				e.printStackTrace();

			}
		}
		
		cursor.close();

		return li;
	}

	/**
	 * 
	 * @param context
	 * @param clazz
	 * @param where
	 * @param selectionArgs
	 * @return ɾ������Ч����
	 */
	public static int deleteBycondition(Context context, Class clazz,
			String where, String[] selectionArgs) {

		int num = 0;

		ContentResolver resolver = context.getContentResolver();

		Uri uri = Uri
				.parse("content://com.bestway.kj915.provider.Basic_db_Provider/delete/one/"
						+ clazz.getSimpleName());

		num = resolver.delete(uri, where, selectionArgs);

		return num;
	}

	/**
	 * ɾ����Ӧ����е����е�����
	 * 
	 * @param context
	 * @param clazz
	 * @return
	 */
	public static int deleteAll(Context context, Class clazz) {

		int num = 0;

		ContentResolver resolver = context.getContentResolver();

		Uri uri = Uri
				.parse("content://com.bestway.kj915.provider.Basic_db_Provider/delete/all/"
						+ clazz.getSimpleName());

		num = resolver.delete(uri, null, null);

		return num;
	}

	/**
	 * ���������޸�obj��Ӧ�ı��
	 * 
	 * @param context
	 * @param obj
	 * @param where
	 * @param selectionArgs
	 * @return
	 */
	public static int updata(Context context, Object obj, String where,
			String[] selectionArgs) {

		int num = 0;

		ContentResolver resolver = context.getContentResolver();

		ContentValues values = new ContentValues();

		// ��values׼��ֵ
		Field[] fields = obj.getClass().getFields();
		for (Field f : fields) {

			try {
				if (!f.getName().equals("ID") || f.getName().equals("ID")) {//

					if (f.getType() == int.class) {

						if (f.get(obj) != null)

							values.put(f.getName(),
									Integer.valueOf(f.get(obj).toString()));

					} else if (f.getType() == String.class) {

						if (f.get(obj) != null)

							values.put(f.getName(), f.get(obj).toString());

					}
				}

			} catch (Exception e) {

				e.printStackTrace();

			}
		}

		Uri uri = Uri
				.parse("content://com.bestway.kj915.provider.Basic_db_Provider/update/"
						+ obj.getClass().getSimpleName());

		num = resolver.update(uri, values, where, selectionArgs);

		return num;
	}
}
