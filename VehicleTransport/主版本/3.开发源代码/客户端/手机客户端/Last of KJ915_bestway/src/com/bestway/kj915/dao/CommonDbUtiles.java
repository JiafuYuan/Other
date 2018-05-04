package com.bestway.kj915.dao;

/**
 * 版权：南京北路自动化系统有限责任公司版权所有
 * 
 * 作者：詹学勇
 * 
 * 版本：1.0
 * 
 * 时间：2014-9-17 下午5:03:35
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
 * 处理数据库的通用工具类
 * 
 * @author gaga
 * 
 */
public class CommonDbUtiles {

	/**
	 * 添加一条
	 * 
	 * @param context
	 * @param obj
	 *            数据库表格对应的bean对象
	 */
	public static void insert(Context context, Object obj) {
		// 得到统一对象
		ContentResolver resolver = context.getContentResolver();

		ContentValues values = new ContentValues();

		Field[] fields = obj.getClass().getFields();

		// 给values准备值
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
		// 提交
		resolver.insert(
				Uri.parse("content://com.bestway.kj915.provider.Basic_db_Provider/insert/"
						+ obj.getClass().getSimpleName()), values);

	}

	/**
	 * 通用的，查询所有的操作
	 * 
	 * @param context
	 * @param clazz
	 * @return
	 */
	public static <T> List<T> querryAll(Context context, Class<T> clazz) {

		// 准备关键对象
		List<T> li = new ArrayList<T>();

		ContentResolver r = context.getContentResolver();

		Cursor cursor = r
				.query(Uri
						.parse("content://com.bestway.kj915.provider.Basic_db_Provider/query/all/"
								+ clazz.getSimpleName()), null, null, null,
						null);

		while (cursor.moveToNext()) {
			try {
				// 反射
				T ins = clazz.newInstance();

				Field[] fields = clazz.getFields();

				// 对字段循环遍历以及赋值
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
	 * 按照条件查询
	 * 
	 * @param context
	 *            上下文
	 * @param clazz
	 *            字节码
	 * @param selection
	 *            查询条件where
	 * @param selectionArgs
	 *            查询的参数
	 * @param sortOrder
	 *            排序
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
				// 反射
				T ins = clazz.newInstance();

				Field[] fields = clazz.getFields();

				// 对字段循环遍历以及赋值
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
	 * @return 删除的有效行数
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
	 * 删除对应表格中的所有的数据
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
	 * 按照条件修改obj对应的表格
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

		// 给values准备值
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
