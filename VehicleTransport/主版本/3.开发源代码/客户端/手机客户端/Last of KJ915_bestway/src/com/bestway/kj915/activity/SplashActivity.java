package com.bestway.kj915.activity;

import java.io.File;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

import net.tsz.afinal.FinalHttp;
import net.tsz.afinal.http.AjaxCallBack;

import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.app.AlertDialog.Builder;
import android.content.DialogInterface;
import android.content.DialogInterface.OnClickListener;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.content.pm.PackageManager.NameNotFoundException;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.view.View;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import com.bestway.kj915.GlobleValues;
import com.bestway.kj915.R;
import com.bestway.kj915.common.PrimaryData;
import com.bestway.kj915.common.ProcessCallBack;
import com.bestway.kj915.utils.StreamTools;

public class SplashActivity extends Activity {

	private SharedPreferences preferences;
	private static final int ENTER_HOME = 110;
	private static final int SHOW_UPDATE_DIALOG = 111;
	private static final int URL_ERRO = 112;
	private static final int IO_EXCEPTION = 113;
	private static final int JSON_EXCEPTION = 114;
	private TextView tv_version;
	private String apkurl;
	private String description;
	private TextView tv_progress;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_splash);

		/**
		 * 基础数据更新进度条
		 * 
		 */

		final ProgressBar bar = (ProgressBar) findViewById(R.id.splash_tv_pb);

		bar.setMax(6);

		ProcessCallBack callBack = new ProcessCallBack() {

			@Override
			public void process(int currentProcess) {
				System.out.println(currentProcess);
				bar.setProgress(currentProcess);
			}
		};

		PrimaryData primaryData = new PrimaryData(callBack, this);
		primaryData.loadBasicData();

		pm = getPackageManager();

		preferences = getSharedPreferences("config", MODE_PRIVATE);
		tv_progress = (TextView) findViewById(R.id.splash_tv_progress);
		// 获得版本
		tv_version = (TextView) findViewById(R.id.splash_tv_version);
		// 设置版本号
		tv_version.setText("版本: " + getversionName());

		System.out.println(getversionName());
		// 判断是否更新
		boolean update = preferences.getBoolean("update", false);

		if (!update) {
			// 常见的延时操作，延时过后进入主线程执行
			handler.postDelayed(new Runnable() {

				@Override
				public void run() {
					accessMainActivity();
				}
			}, 2000);
			return;
		}

		update();

	}

	private Handler handler = new Handler() {
		@Override
		public void handleMessage(Message msg) {
			switch (msg.what) {
			case ENTER_HOME:
				accessMainActivity();
				break;
			case SHOW_UPDATE_DIALOG:

				Builder builder = new Builder(SplashActivity.this);
				builder.setTitle("版本更新通知");
				builder.setMessage(description);
				builder.setPositiveButton("立即更新", new OnClickListener() {
					@Override
					public void onClick(DialogInterface dialog, int which) {
						// 下载
						FinalHttp finalHttp = new FinalHttp();
						System.out.println(apkurl);
						finalHttp.download(apkurl, Environment
								.getExternalStorageDirectory()
								.getAbsolutePath()
								+ "/kj915.apk", new AjaxCallBack<File>() {
							@Override
							public void onFailure(Throwable t, int errorNo,
									String strMsg) {
								super.onFailure(t, errorNo, strMsg);
								Toast.makeText(SplashActivity.this, "下载失败", 0)
										.show();
							}

							@Override
							public void onLoading(long count, long current) {
								super.onLoading(count, current);
								tv_progress.setVisibility(View.VISIBLE);
								tv_progress.setText("当前进度: " + current * 100
										/ count);

							}

							@Override
							public void onSuccess(File t) {
								super.onSuccess(t);
								installApk(t);
							}

							private void installApk(File t) {
								Intent intent = new Intent(
										"android.intent.action.VIEW");
								intent.addCategory("android.intent.category.DEFAULT");
								intent.setDataAndType(Uri.fromFile(t),
										"application/vnd.android.package-archive");
								startActivity(intent);
							}
						});

					}
				});
				builder.setNegativeButton("下次再说", new OnClickListener() {

					@Override
					public void onClick(DialogInterface dialog, int which) {
						// close dialog
						dialog.dismiss();
						// 进入主页面
						accessMainActivity();
					}
				});
				builder.show();
				break;
			case URL_ERRO:
				Toast.makeText(SplashActivity.this, "url解析错误", 0).show();
				break;
			case IO_EXCEPTION:
				Toast.makeText(SplashActivity.this, "网络异常", 0).show();
				break;
			case JSON_EXCEPTION:
				Toast.makeText(SplashActivity.this, "JSON解析错误", 0).show();
				break;

			default:
				break;
			}
			super.handleMessage(msg);
		}
	};
	private PackageInfo info;
	private PackageManager pm;

	// 进入主界面
	public void accessMainActivity() {
		Intent intent = new Intent("com.bestway.kj915.activity.LoginActivity");
		startActivity(intent);
		finish();
	}

	private String getversionName() {
		try {
			info = pm.getPackageInfo(getPackageName(), 0);
		} catch (NameNotFoundException e) {
			e.printStackTrace();
		}
		return info.versionName;
	}

	// 检查是否需要更新
	public void update() {

		new Thread(new Runnable() {
			@Override
			public void run() {
				Message mess = Message.obtain();
				try {
					// 获取链接
					URL url = new URL(GlobleValues.UPDATA_IP);
					HttpURLConnection connection = (HttpURLConnection) url
							.openConnection();
					connection.setConnectTimeout(3000);
					connection.setRequestMethod("GET");
					int responsecode = connection.getResponseCode();
					if (responsecode == 200) {
						String str = StreamTools.readFromStream(connection
								.getInputStream());
						System.out.println(str);
						JSONObject jsonObject = new JSONObject(str);
						String version = jsonObject.getString("version");
						description = jsonObject.getString("description");
						apkurl = jsonObject.getString("apkurl");
						if (getversionName().equals(version)) {
							mess.what = ENTER_HOME;// 成功进入主界面
						} else {
							mess.what = SHOW_UPDATE_DIALOG;
						}
					}
				} catch (MalformedURLException e) {
					e.printStackTrace();
					mess.what = URL_ERRO;
				} catch (IOException e) {
					e.printStackTrace();
					mess.what = IO_EXCEPTION;
				} catch (JSONException e) {
					e.printStackTrace();
					mess.what = JSON_EXCEPTION;
				} finally {
					handler.sendMessage(mess);
				}
			}
		}).start();

	}

}
