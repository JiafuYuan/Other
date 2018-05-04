package com.bestway.kj915.activity;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.app.PendingIntent;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.IntentFilter.MalformedMimeTypeException;
import android.nfc.NfcAdapter;
import android.nfc.tech.NfcF;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.EditText;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.home.handover.HandoverNFCActivity;
import com.bestway.kj915.afinalnet.CommonXmlParser;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.dao.BasicDataOpenHelper;
import com.bestway.kj915.dao.CommonDbUtiles;
import com.bestway.kj915.domain.User;
import com.bestway.kj915.domain.reflect.m_Address;
import com.bestway.kj915.domain.reflect.m_Card;
import com.bestway.kj915.domain.reflect.m_Department;
import com.bestway.kj915.domain.reflect.m_MaterielType;
import com.bestway.kj915.domain.reflect.m_Person;
import com.bestway.kj915.domain.reflect.m_VehicleType;
import com.bestway.kj915.domain.req.ReqAddress;
import com.bestway.kj915.domain.req.ReqCard;
import com.bestway.kj915.domain.req.ReqChangePassowrd;
import com.bestway.kj915.domain.req.ReqDepartment;
import com.bestway.kj915.domain.req.ReqFlowPath;
import com.bestway.kj915.domain.req.ReqLogin;
import com.bestway.kj915.domain.req.ReqMaterielType;
import com.bestway.kj915.domain.req.ReqPerson;
import com.bestway.kj915.domain.req.ReqVehicle;
import com.bestway.kj915.domain.req.ReqVehicleType;
import com.bestway.kj915.domain.req.load.LoadContainer;
import com.bestway.kj915.domain.req.load.ReqLoad;
import com.bestway.kj915.domain.req.load.m_Plan_Load;
import com.bestway.kj915.domain.req.supply.ReqSupplyCar;
import com.bestway.kj915.domain.req.supply.SupplyContainer;
import com.bestway.kj915.domain.req.supply.m_Plan_GiveVehicle;
import com.bestway.kj915.domain.res.OutFlowPathModel;
import com.bestway.kj915.domain.res.OutLoginModel;
import com.bestway.kj915.domain.res.address.OutGetAddressModel;
import com.bestway.kj915.domain.res.card.OutGetCardModel;
import com.bestway.kj915.domain.res.department.OutGetDepartmentModel;
import com.bestway.kj915.domain.res.materielType.OutGetMaterielTypeModel;
import com.bestway.kj915.domain.res.person.OutGetPersonModel;
import com.bestway.kj915.domain.res.vehicleType.OutGetVehicleTypeModel;
import com.bestway.kj915.nfc.NfcMessageParser;
import com.bestway.kj915.utils.DIP_PIX_Utils;
import com.bestway.kj915.utils.LogUtils;
import com.bestway.kj915.utils.SharePreferenceUtils_config;
import com.bestway.kj915.utils.TimerUtils;

public class LoginActivity extends Activity {

	private EditText username;
	private EditText password;
	private CheckBox autologin;
	private CheckBox remenber;
	private Button login;
	private ProgressDialog dialog;
	private NfcAdapter mAdapter;
	private PendingIntent mPendingIntent;
	private String[][] mTechLists;
	private IntentFilter[] mFilters;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_login);

		dealNfc();

		System.out.println(DIP_PIX_Utils.px2dip(this, 58));
		// 读取表格数据
		// test4();
		// test1();// 测试部门
		// test3();// 测试物料

		// test2();// 测试数据库增删改查

		// 测试获取运单
		// test5();

		// 测试地点
		// test6();

		// 测试车辆
		// test7();

		// 获取车辆类型
		// test8();

		// 获取人员的信息
		// test9();

		
		// startActivity(new
		// Intent("com.bestway.kj915.activity.IndexActivity"));
		init();

		// 装车
		// test10();

		// 测试card信息
		// test11();

		// 测试流程节点控制
		// test12();

		// 修改密码
		// test13();

		// 供车模块
		// test14();
		
		//TimerUtils.testDate();   
	}

	private void dealNfc() {
		mAdapter = NfcAdapter.getDefaultAdapter(this);

		mPendingIntent = PendingIntent.getActivity(this, 0, new Intent(this,
				getClass()).addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP), 0);

		IntentFilter ndef = new IntentFilter(NfcAdapter.ACTION_NDEF_DISCOVERED);
		try {
			ndef.addDataType("*/*");
		} catch (MalformedMimeTypeException e) {
			throw new RuntimeException("fail", e);
		}
		mFilters = new IntentFilter[] { ndef };

		mTechLists = new String[][] { new String[] { NfcF.class.getName() } };
	}

	private void test14() {

		ReqSupplyCar supplyCar = new ReqSupplyCar();

		supplyCar.DateTime = TimerUtils.getTime();

		supplyCar.AddressID = 1;

		supplyCar.DepartmentID = 2;  

		supplyCar.PlanID = 176;

		supplyCar.UserID = GlobleFields.UserID;

		SupplyContainer container = new SupplyContainer();

		ArrayList<m_Plan_GiveVehicle> li = new ArrayList<m_Plan_GiveVehicle>();

		m_Plan_GiveVehicle plan_GiveVehicle = new m_Plan_GiveVehicle();
		plan_GiveVehicle.PlanID = 176;
		plan_GiveVehicle.vc_Memo = "年后啊";
		plan_GiveVehicle.VehicleTypeID = 1;

		li.add(plan_GiveVehicle);
		container.list = li;
		supplyCar.ListM_Plan_GiveVehicle = container;

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(supplyCar, new NetCallback() {

			@Override
			public String getCmdType() {
				return NetCallback.Flow_Give;
			}

			@Override
			public void doPrevious() {

			}

			@Override
			public void onResult(String result) {

			}

			@Override
			public void onResult(String inner, boolean Result) {

			}

			@Override
			public void onResult(String entireXml, String inner, boolean Result) {

				System.out.println(entireXml);

			}

		});

	}

	private void test13() {
		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(new ReqChangePassowrd("zxy", 2),
				new NetCallback() {

					@Override
					public String getCmdType() {
						return NetCallback.ChangePassword;
					}

					@Override
					public void doPrevious() {

					}

					@Override
					public void onResult(String result) {

					}

					@Override
					public void onResult(String inner, boolean Result) {

					}

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {

						System.out.println(entireXml);

					}

				});
	}

	private void test12() {

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(new ReqFlowPath(), new NetCallback() {

			@Override
			public String getCmdType() {
				return NetCallback.GetFlowPath;
			}

			@Override
			public void doPrevious() {

			}

			@Override
			public void onResult(String result) {

			}

			@Override
			public void onResult(String inner, boolean Result) {

			}

			@Override
			public void onResult(String entireXml, String inner, boolean Result) {

				System.out.println(entireXml);

				OutFlowPathModel model = (OutFlowPathModel) CommonXmlParser
						.parserXml(inner, new OutFlowPathModel());

				System.out.println(model);
			}

		});

	}

	private void test11() {

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(new ReqCard(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public String getCmdType() {
						return NetCallback.Data_GetCard;
					}

					@Override
					public void doPrevious() {

					}

					@Override
					public void onResult(String result) {

					}

					@Override
					public void onResult(String inner, boolean Result) {
						System.out.println("ininter" + inner);

						OutGetCardModel model = (OutGetCardModel) CommonXmlParser
								.parserXml(inner, new OutGetCardModel());

						List<m_Card> cards = model.Listm_Card.list;

						if (cards != null) {

							for (m_Card card : cards) {
								CommonDbUtiles.insert(LoginActivity.this, card);
							}

						}

						System.out.println(model.Listm_Card.list.get(0));
					}

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {
						// TODO Auto-generated method stub

					}

				});

	}

	private void test10() {

		m_Plan_Load plan_Load = new m_Plan_Load(1, 2, 1, 2, 12, "haode", 1);
		List<m_Plan_Load> list = new ArrayList<m_Plan_Load>();
		list.add(plan_Load);

		LoadContainer container = new LoadContainer(list);
		ReqLoad load = new ReqLoad(1, 2, 1, 0, "2014-08-24T08:20:00", container);

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(load, new NetCallback() {

			@Override
			public String getCmdType() {
				return NetCallback.Flow_Load;
			}

			@Override
			public void doPrevious() {

			}

			@Override
			public void onResult(String result) {

			}

			@Override
			public void onResult(String inner, boolean Result) {
				System.out
						.println("{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{"
								+ inner);
			}

			@Override
			public void onResult(String entireXml, String inner, boolean Result) {
				// TODO Auto-generated method stub

			}

		});

	}

	private void test9() {

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(new ReqPerson(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String inner, boolean Result) {

						System.out.println("iinner:" + inner);

						OutGetPersonModel model = (OutGetPersonModel) CommonXmlParser
								.parserXml(inner, new OutGetPersonModel());

						List<m_Person> list = model.Listm_Person.list;
						if (list != null) {

							for (m_Person person : list) {
								CommonDbUtiles.insert(LoginActivity.this,
										person);
							}
						}

					}

					@Override
					public void onResult(String result) {

					}

					@Override
					public String getCmdType() {
						return NetCallback.Data_GetPerson;
					}

					@Override
					public void doPrevious() {

					}

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {
						// TODO Auto-generated method stub

					}
				});

	}

	private void test8() {
		final FinalNClient client = FinalNClient.getInstance();
		client.sendMessage(new ReqVehicleType(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String inner, boolean Result) {

						System.out.println("iinner:" + inner);

						OutGetVehicleTypeModel model = (OutGetVehicleTypeModel) CommonXmlParser
								.parserXml(inner, new OutGetVehicleTypeModel());

						for (m_VehicleType vehicleType : model.Listm_VehicleType.list) {
							CommonDbUtiles.insert(LoginActivity.this,
									vehicleType);
						}

					}

					@Override
					public void onResult(String result) {

					}

					@Override
					public String getCmdType() {
						return NetCallback.Data_GetVehicleType;
					}

					@Override
					public void doPrevious() {

					}

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {
						// TODO Auto-generated method stub

					}
				});

	}

	private void test7() {
		final FinalNClient client = FinalNClient.getInstance();
		client.sendMessage(new ReqVehicle(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String inner, boolean Result) {

						System.out.println("iinner:" + inner);

					}

					@Override
					public void onResult(String result) {

					}

					@Override
					public String getCmdType() {

						return NetCallback.Data_GetVehicle;
					}

					@Override
					public void doPrevious() {

					}

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {

					}
				});
	}

	/*
	 * private void test5() {
	 * 
	 * final FinalNClient client = FinalNClient.getInstance();
	 * 
	 * client.sendMessage( new ReqPlanDetail("2014-09-18T15:41:31",
	 * TimerUtils.getTime(), 0, 0, EnumFlowTypePath.Load.name(), 0, 13), new
	 * NetCallback() {
	 * 
	 * @Override public String getCmdType() {
	 * 
	 * return NetCallback.Data_GetPlanDetail;
	 * 
	 * }
	 * 
	 * @Override public void doPrevious() {
	 * 
	 * }
	 * 
	 * @Override public void onResult(String result) {
	 * 
	 * }
	 * 
	 * @Override public void onResult(String inner, boolean Result) {
	 * System.out.println("Result" + Result); System.out.println(inner);
	 * OutGetPlanDetailModel model = (OutGetPlanDetailModel) CommonXmlParser
	 * .parserXml(inner, new OutGetPlanDetailModel());
	 * 
	 * if (model.Listm_Plan.list != null) System.out.println("长度。。" +
	 * model.Listm_Plan.list.size());
	 * 
	 * }
	 * 
	 * @Override public void onResult(String entireXml, String inner, boolean
	 * Result) { // TODO Auto-generated method stub
	 * 
	 * } }); }
	 */

	private void test6() {
		final FinalNClient client = FinalNClient.getInstance();
		client.sendMessage(new ReqAddress(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String inner, boolean Result) {

						System.out.println("iinner:" + inner);
						OutGetAddressModel model = (OutGetAddressModel) CommonXmlParser
								.parserXml(inner, new OutGetAddressModel());

						for (m_Address address : model.Listm_Address.list) {

							CommonDbUtiles.insert(LoginActivity.this, address);

						}

					}

					@Override
					public void onResult(String result) {

					}

					@Override
					public String getCmdType() {
						return NetCallback.Data_GetAddress;
					}

					@Override
					public void doPrevious() {

					}

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {
						// TODO Auto-generated method stub

					}
				});
	}

	private void test3() {
		final FinalNClient client = FinalNClient.getInstance();
		client.sendMessage(new ReqMaterielType(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String inner, boolean Result) {

						System.out.println("iinner:" + inner);
						OutGetMaterielTypeModel model = (OutGetMaterielTypeModel) CommonXmlParser
								.parserXml(inner, new OutGetMaterielTypeModel());
						System.out.println("model.getList().size()"
								+ model.getListM_MaterielType().getList()
										.size());
						for (m_MaterielType obj : model.getListM_MaterielType()
								.getList()) {
							CommonDbUtiles.insert(LoginActivity.this, obj);
						}

					}

					@Override
					public void onResult(String result) {

					}

					@Override
					public String getCmdType() {
						return NetCallback.Data_GetMaterielType;
					}

					@Override
					public void doPrevious() {

					}

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {
						// TODO Auto-generated method stub

					}
				});
	}

	private void test4() {
		List<m_Department> li = CommonDbUtiles.querryAll(this,
				m_Department.class);
		for (m_Department p : li) {
			System.out.println(p);
		}
	}

	private void test2() {

		BasicDataOpenHelper helper = new BasicDataOpenHelper(this);
		helper.getReadableDatabase();

		CommonDbUtiles.insert(this, new m_Person(1, 2 + "(", "ff", 2, 2, "php",
				"凡士林", "110", "nice", 1));
		List<m_Person> li = CommonDbUtiles.querryAll(this, m_Person.class);

		CommonDbUtiles.deleteBycondition(this, m_Person.class, "vc_Code=?",
				new String[] { "FF" });

		System.out.println(li.size());
		for (m_Person p : li) {
			System.out.println(p);
		}
	}

	private void test1() {
		FinalNClient client = FinalNClient.getInstance();
		client.sendMessage(new ReqDepartment(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String inner, boolean Result) {
						System.out.println("iinner:" + inner);
						OutGetDepartmentModel model = (OutGetDepartmentModel) CommonXmlParser
								.parserXml(inner, new OutGetDepartmentModel());
						System.out.println("siizVVV"
								+ model.getListM_Department().getList().size());
						System.out.println(model.getListM_Department()
								.getList().get(0).getVc_Name());

						for (m_Department department : model
								.getListM_Department().getList()) {
							CommonDbUtiles.insert(LoginActivity.this,
									department);
						}
					}

					@Override
					public void onResult(String result) {
					}

					@Override
					public String getCmdType() {
						return NetCallback.Data_GetDepartment;
					}

					@Override
					public void doPrevious() {

					}

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {

					}
				});
	}

	/**
	 * 初始化布局
	 */
	private void init() {
		// 用户名，密码
		username = (EditText) findViewById(R.id.login_et_user);
		password = (EditText) findViewById(R.id.login_et_password);

		// 自动登录，记住密码
		autologin = (CheckBox) findViewById(R.id.login_checkbox_zddl);
		remenber = (CheckBox) findViewById(R.id.login_checkbox_password);

		// 登录按钮
		login = (Button) findViewById(R.id.login_activity_login);

		// 获取保存的用户名和密码并填充
		boolean sp_Autologin = GlobleFields.sp.getBoolean("autologin", false);
		String sp_username = GlobleFields.sp.getString("username", "");
		String sp_password = GlobleFields.sp.getString("password", "");

		LogUtils.careLog("第一次获取sp_username..." + sp_username + ".."
				+ GlobleFields.sp);
		// 保存的内容进行显示
		username.setText(sp_username);
		password.setText(sp_password);
		autologin.setChecked(sp_Autologin);
		remenber.setChecked(GlobleFields.sp.getBoolean("remenber", false));

		// @1登录按钮设置监听
		login.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				login(-1);
			}
		});
		// @2 自动登录设置点击监听
		autologin.setOnCheckedChangeListener(new OnCheckedChangeListener() {

			@Override
			public void onCheckedChanged(CompoundButton buttonView,
					boolean isChecked) {

				SharePreferenceUtils_config.edit_Boolean(LoginActivity.this,
						"autologin", isChecked);
			}
		});
		// @3 记住密码设置点击监听
		remenber.setOnCheckedChangeListener(new OnCheckedChangeListener() {

			@Override
			public void onCheckedChanged(CompoundButton buttonView,
					boolean isChecked) {
				SharePreferenceUtils_config.edit_Boolean(LoginActivity.this,
						"remenber", isChecked);
				if (!isChecked)
					SharePreferenceUtils_config.edit_String(LoginActivity.this,
							"password", "");
			}
		});

		System.out.println("ppp" + !GlobleFields.isFromSetting);
		// 判断是否自动登录(且界面不是来自设置中的退出登录)
		if (sp_Autologin && !GlobleFields.isFromSetting) {
			LogUtils.careLog("自动登录");
			login(-1);
			return;
		}
		GlobleFields.isFromSetting = false;

	}

	// 执行登陆
	public void login(int cardHID) {

		// 获取登录密码与用户名
		final String text_username = username.getText().toString();
		final String text_password = password.getText().toString();
		final User user = new User(text_username, text_password);

		ReqLogin reqLogin = new ReqLogin(user.getUsername(), user.getPassword());

		if (cardHID != -1) {
			
			reqLogin.IsPasswordLogin = false;
			
			reqLogin.CardHID = cardHID;
			
		}

		LogUtils.careLog("用户名:" + text_username + "密码：" + text_password);

		if (TextUtils.isEmpty(text_username)) {
			Toast.makeText(this, "用户名不能为空", 0).show();
			return;
		}

		if (TextUtils.isEmpty(text_password)) {
			Toast.makeText(this, "密码不能为空", 0).show();
			return;
		}

		if (dialog == null) {
			dialog = new ProgressDialog(this);
			dialog.setTitle("友情提示");
			dialog.setMessage("正在登录...");
			dialog.setCancelable(false);
		}

		FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(reqLogin,

		new NetCallback() {

			@Override
			public void onResult(String inner, boolean Result) {
				dialog.dismiss();

				if (inner != null) {

					// 处理登录返回的结果
					OutLoginModel loginModel = (OutLoginModel) CommonXmlParser
							.parserXml(inner, new OutLoginModel());
					System.out.println(loginModel.UserID);
					LogUtils.careLog("登录成功" + text_username);

					// 第一次赋值给userid
					GlobleFields.UserID = Integer.valueOf(loginModel.UserID);

					// 保存用户名，密码。
					SharePreferenceUtils_config.edit_String(LoginActivity.this,
							"username", text_username);
					if (GlobleFields.sp.getBoolean("remenber", false)) {// 选择不记住密码，清空记录
						SharePreferenceUtils_config.edit_String(
								LoginActivity.this, "password", text_password);
					} else {
						SharePreferenceUtils_config.edit_String(
								LoginActivity.this, "password", "");
					}

					// 开启后台心跳服务
					GlobleFields.serverIntent = new Intent(
							"com.bestway.kj915.service.HeartService");
					// user.setUserID(loginModel.getUserID());
					// GlobleFields.serverIntent.putExtra("user", user);

					GlobleFields.user = user;
					startService(GlobleFields.serverIntent);

					// 登录到导航页面
					Intent intent = new Intent(
							"com.bestway.kj915.activity.IndexActivity");
					startActivity(intent);

				} else {
					dialog.dismiss();
					Toast.makeText(LoginActivity.this, "网路异常，稍后再试", 0).show();
				}
			}

			@Override
			public void onResult(String result) {
				dialog.dismiss();
				if (result.equals(FinalNClient.CONNET_FAILED)
						|| result.equals(FinalNClient.INIT_EXCEPTION)
						|| result.equals(FinalNClient.CONNET_FAILED))
					Toast.makeText(LoginActivity.this, "网路异常，稍后再试", 0).show();
			}

			@Override
			public String getCmdType() {
				return NetCallback.Login;
			}

			@Override
			public void doPrevious() {
				dialog.show();
			}

			@Override
			public void onResult(String entireXml, String inner, boolean Result) {
				// TODO Auto-generated method stub

			}
		});
	}

	@Override
	public void onResume() {

		super.onResume();

		if (mAdapter != null)

			mAdapter.enableForegroundDispatch(this, mPendingIntent, mFilters,
					mTechLists);
	}

	@Override
	public void onNewIntent(Intent intent) {
		super.onNewIntent(intent);

		Integer newNumber = 0;

		NfcMessageParser nfcMessageParser = new NfcMessageParser(intent);
		List<String> tagMessage = nfcMessageParser.getTagMessage();

		String text = tagMessage.get(0);
		int start = text.lastIndexOf("TEL;CEL") + 9;
		int end = text.lastIndexOf("END:VCARD");
		String result = tagMessage.get(0).substring(start, end);

		LogUtils.careLog("获取的数字是=" + result);

		try {
			newNumber = Integer.parseInt(result.trim());
		} catch (Exception e) {
			Toast.makeText(LoginActivity.this, "卡的内容格式错误", 0).show();
			return;
		}

		login(newNumber);

	}

	@Override
	public void onPause() {
		super.onPause();

		if (mAdapter != null)

			mAdapter.disableForegroundDispatch(this);
		finish();
	}

	@Override
	public void onBackPressed() {
		super.onBackPressed();
	}
}
