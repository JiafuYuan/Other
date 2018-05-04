package com.bestway.kj915.service;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import android.os.SystemClock;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.afinalnet.NetUtil;
import com.bestway.kj915.domain.User;
import com.bestway.kj915.domain.req.ReqHeartBeat;
import com.bestway.kj915.domain.req.ReqLogin;
import com.bestway.kj915.utils.LogUtils;

public class HeartService extends Service {

	private FinalNClient client;
	private boolean stop=false;
	
	@Override
	public void onCreate() {
		super.onCreate();
		
		client = FinalNClient.getInstance();

		new Thread() {
			public void run() {

				while (!stop) {

					if (NetUtil.checkNet(getApplicationContext())) {
						client.sendMessage(new ReqHeartBeat("dd",
								GlobleFields.UserID, "dd"), new NetCallback() {

							@Override
							public void onResult(String result) {

								LogUtils.careLog(result);
								
								if (result == FinalNClient.CONNET_INTERUPT) {

									LogUtils.careLog("�����ж�");
									client.init();
									LogUtils.careLog("���µ�¼�˺�");

									login(GlobleFields.user);
								} else if (result == FinalNClient.CONNET_FAILED) {
									LogUtils.careLog("���Ӳ���");

								} else if (result == FinalNClient.INIT_EXCEPTION) {
									LogUtils.careLog("��ʼ��ʧ�ܣ����³�ʼ��");
									client.init();
									new Thread() {
										public void run() {
											login(GlobleFields.user);
										};
									}.start();

								}
								LogUtils.careLog("������...");

							}

							@Override
							public String getCmdType() {
								return NetCallback.HeartBeat;
							}

							@Override
							public void doPrevious() {
							}

							@Override
							public void onResult(String inner, boolean Result) {

							}

							@Override
							public void onResult(String entireXml,
									String inner, boolean Result) {
								
							}
						});

						SystemClock.sleep(15000);

					}

				}
			};

		}.start();

	}

	/*@Override
	public int onStartCommand(Intent intent, int flags, int startId) {

		final User user = (User) intent.getExtras().get("user");

		client = FinalNClient.getInstance();

		new Thread() {
			public void run() {

				while (!stop) {

					if (NetUtil.checkNet(getApplicationContext())) {
						client.sendMessage(new ReqHeartBeat("dd",
								GlobleFields.UserID, "dd"), new NetCallback() {

							@Override
							public void onResult(String result) {

								LogUtils.careLog(result);
								if (result == FinalNClient.CONNET_INTERUPT) {

									LogUtils.careLog("�����ж�");
									client.init();
									LogUtils.careLog("���µ�¼�˺�");

									login(user);
								} else if (result == FinalNClient.CONNET_FAILED) {
									LogUtils.careLog("���Ӳ���");

								} else if (result == FinalNClient.INIT_EXCEPTION) {
									LogUtils.careLog("��ʼ��ʧ�ܣ����³�ʼ��");
									client.init();
									new Thread() {
										public void run() {
											login(user);
										};
									}.start();

								}
								LogUtils.careLog("������...");

							}

							@Override
							public String getCmdType() {
								return NetCallback.HeartBeat;
							}

							@Override
							public void doPrevious() {
							}

							@Override
							public void onResult(String inner, boolean Result) {

							}
						});

						SystemClock.sleep(15000);

					}

				}
			};

		}.start();

		return super.onStartCommand(intent, flags, startId);
	}*/

	@Override
	public IBinder onBind(Intent intent) {
		return null;
	}

	public void login(User user) {

		client.sendMessage(
				new ReqLogin(user.getUsername(), user.getPassword()),
				new NetCallback() {
					@Override
					public void onResult(String result) {
						LogUtils.careLog("result:%%%%%%%%" + result);
					}

					@Override
					public String getCmdType() {
						return NetCallback.Login;
					}

					@Override
					public void doPrevious() {
					}

					@Override
					public void onResult(String inner, boolean Result) {
						LogUtils.careLog(Result + "���ߵ�¼" + inner);
					}

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {
					}
				});
	}

	@Override
	public void onDestroy() {
		
		//stop = true;
		super.onDestroy();
	}
}
