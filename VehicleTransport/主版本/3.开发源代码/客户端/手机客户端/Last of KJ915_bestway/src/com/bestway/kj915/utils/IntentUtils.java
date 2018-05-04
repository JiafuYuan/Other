package com.bestway.kj915.utils;

import android.content.Context;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.content.pm.PackageManager.NameNotFoundException;
import android.graphics.Bitmap;
import android.net.Uri;

public class IntentUtils {

	/**
	 * ������������Ի�÷�װ�õ�ж�س������ͼ
	 * 
	 * @param packageName
	 *            ����
	 * @return
	 */
	public static Intent uninstall(String packageName) {
		Intent intent = new Intent();
		intent.setAction("android.intent.action.VIEW");
		intent.addCategory("android.intent.category.DEFAULT");
		intent.setData(Uri.parse("package:" + packageName));
		return intent;
	}

	/**
	 * ����������ݼȿ��Ի�ȡ���Ͷ��ŵ���ͼ
	 * 
	 * @param content
	 *            ��Ϣ����
	 * @return
	 */
	public static Intent sendSms(String content) {
		Intent intent = new Intent();
		intent.setAction("android.intent.action.SEND");
		intent.addCategory("android.intent.category.DEFAULT");
		intent.setType("text/plain");
		intent.putExtra(Intent.EXTRA_TEXT, content);
		return intent;
	}

	/**
	 * ����֪Ҫ���򿪵ĳ���İ������Լ���������е�һ��Activity����ĵĹ������е�action
	 * android:name="android.intent.action.MAIN"ʱ���Ӧ��
	 * 
	 * @param packageName
	 *            Ӧ�õİ���
	 * @param activityName
	 *            Ӧ�õ�Ҫ���򿪵�Activity������name
	 * @return
	 */
	public static Intent openActivity(String packageName, String activityName) {
		Intent intent = new Intent();
		intent.setClassName(packageName, activityName);
		return intent;
	}

	/**
	 * ͨ��������������
	 * 
	 * @param context
	 * @param packageName
	 * @return
	 */
	public static Intent openActivityWithPackageName(Context context,
			String packageName) {
		PackageManager pm = context.getPackageManager();
		Intent intent = null;
		try {
			PackageInfo info = pm.getPackageInfo(packageName,
					PackageManager.GET_ACTIVITIES);
			ActivityInfo[] activityInfos = info.activities;
			// ��ȡ���������activity����ͼaction����
			if (activityInfos != null && activityInfos.length != 0) {
				String activityName = activityInfos[0].name;
				intent = IntentUtils.openActivity(packageName, activityName);
			}

		} catch (NameNotFoundException e) {
			e.printStackTrace();
			return null;
		}
		return intent;
	}

	/**
	 * ���ݸ���ĵ绰���룬ת�����Ž���
	 * 
	 * @param number
	 * @return
	 */
	public static Intent call(String number) {
		Intent intent = new Intent();
		intent.setAction(Intent.ACTION_DIAL);
		intent.setData(Uri.parse("tel:" + number));
		return intent;
	}

	/**
	 * ���ݸ���ĵ绰���룬ֱ�Ӳ���绰
	 * 
	 * @param number
	 * @return
	 */
	public static Intent callImmediate(String number) {
		Intent intent = new Intent();
		intent.setAction(Intent.ACTION_CALL);
		intent.setData(Uri.parse("tel:" + number));
		return intent;
	}

	/**
	 * ������ݼ�����ͼ��ע��Ҫ���ݼ�������ɱ���ע��һ������ �����ļ�����ҪȨ�ޣ� <uses-permission
	 * android:name="com.android.launcher.permission.INSTALL_SHORTCUT"/>
	 * ��ҪsendBroadcast(Intent intent)֪ͨ������ӿ�ݷ�ʽ
	 * 
	 * @param appName
	 * @param bitmapIcon
	 * @param dowhatIntent
	 *            ��Ҫ��ݼ���ʲô
	 * @return
	 */
	public static Intent createShortcut(String appName, Bitmap bitmapIcon,
			Intent dowhatIntent) {
		System.out.println("��װ��ݷ�ʽ");
		Intent intent = new Intent(
				"com.android.launcher.action.INSTALL_SHORTCUT");
		// ���ÿ�ݼ�������
		intent.putExtra(Intent.EXTRA_SHORTCUT_NAME, appName);
		// ���ÿ�ݼ���ͼ��
		intent.putExtra(Intent.EXTRA_SHORTCUT_ICON, bitmapIcon);
		// ���ÿ�ݼ�����ͼ(�򿪿�ݼ����ĸ�ҳ��)
		intent.putExtra(Intent.EXTRA_SHORTCUT_INTENT, dowhatIntent);
		return intent;
	}

	/**
	 * ����һ���µ����񣬵�ǰ��������Ȼ�������У��б���
	 * 
	 * @param actionName
	 * @return
	 */
	public static Intent startNewTask(String actionName) {
		Intent intent = new Intent(actionName);
		intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
		return intent;
	}

	/**
	 * ���ش��������ͼ
	 * 
	 * @return
	 */
	public static Intent goLancher() {
		Intent intent = new Intent();
		intent.setAction("android.intent.action.MAIN");
		intent.addCategory("android.intent.category.HOME");
		return intent;
	}

	/**
	 * һ��ͨ��startAcitivityforResult��ȡ���صĽ����������ѡ����ϵ�� �ͻ᷵�ص���ǰҳ�棬ͨ��Uri uri =
	 * data.getData()��ȡ��ѯ��uri Cursor cursor = resolver.query(uri, new
	 * String[]{"has_phone_number", "_id"}, null, null, null);
	 * ��ȡ��ѯ�Ľ�������hasPhoneNumber == 0�����м�¼���޺��룬�������ǿ��Ի�ȡ_id,
	 * contentResolver.query(Phone.CONTENT_URI, new String[]{"data1"},
	 * "contact_id = " + _id, null, null);��ȡ��ϵ�˵ĺ��롣
	 * 
	 * @return
	 */
	public static Intent goCantactPage() {
		Intent intent = new Intent();
		intent.setAction("android.intent.action.PICK");
		intent.setData(Uri.parse("content://com.android.contacts/contacts"));
		return intent;
	}

}
