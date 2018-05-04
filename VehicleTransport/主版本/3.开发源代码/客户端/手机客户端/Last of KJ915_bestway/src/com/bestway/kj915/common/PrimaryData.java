package com.bestway.kj915.common;

import java.io.ByteArrayInputStream;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.xmlpull.v1.XmlPullParser;

import android.content.Context;
import android.os.SystemClock;
import android.util.Xml;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.afinalnet.CommonXmlParser;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.dao.CommonDbUtiles;
import com.bestway.kj915.domain.reflect.m_Address;
import com.bestway.kj915.domain.reflect.m_Card;
import com.bestway.kj915.domain.reflect.m_Department;
import com.bestway.kj915.domain.reflect.m_MaterielType;
import com.bestway.kj915.domain.reflect.m_Person;
import com.bestway.kj915.domain.reflect.m_VehicleType;
import com.bestway.kj915.domain.reflect.table_Last_Updata;
import com.bestway.kj915.domain.req.ReqAddress;
import com.bestway.kj915.domain.req.ReqCard;
import com.bestway.kj915.domain.req.ReqDepartment;
import com.bestway.kj915.domain.req.ReqMaterielType;
import com.bestway.kj915.domain.req.ReqPerson;
import com.bestway.kj915.domain.req.ReqVehicleType;
import com.bestway.kj915.domain.res.address.OutGetAddressModel;
import com.bestway.kj915.domain.res.card.OutGetCardModel;
import com.bestway.kj915.domain.res.department.OutGetDepartmentModel;
import com.bestway.kj915.domain.res.materielType.OutGetMaterielTypeModel;
import com.bestway.kj915.domain.res.person.OutGetPersonModel;
import com.bestway.kj915.domain.res.vehicleType.OutGetVehicleTypeModel;
import com.bestway.kj915.utils.LogUtils;
import com.bestway.kj915.utils.TimerUtils;

public class PrimaryData {

	public ProcessCallBack processCallBack;
	public int currentProcess = 0;
	public Context context;
	private String lastUpdateTime;

	public PrimaryData(ProcessCallBack processCallBack, Context context) {
		super();

		this.processCallBack = processCallBack;

		this.context = context;
	}

	public void loadBasicData() {

		initAddress();

	}

	/**
	 * 初始化地点
	 * 
	 * @param context
	 */
	public void initAddress() {

		final FinalNClient client = FinalNClient.getInstance();
		client.sendMessage(new ReqAddress(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {

						System.out
								.println("ggagaggggafadaffafaffaaffa" + inner);

						LogUtils.careLog("iinner:" + inner);

						OutGetAddressModel model = (OutGetAddressModel) CommonXmlParser
								.parserXml(inner, new OutGetAddressModel());

						/**
						 * .......修改更新的日期
						 */
						List<table_Last_Updata> updatas = CommonDbUtiles
								.querryAll(context, table_Last_Updata.class);
						if (updatas.size() == 0) {

							table_Last_Updata last_Updata = new table_Last_Updata();

							last_Updata.m_Address = model.LastUpdateTime;

							CommonDbUtiles.insert(context, last_Updata);

						} else {

							updatas.get(0).m_Address = model.LastUpdateTime;

							CommonDbUtiles.updata(context, updatas.get(0),
									null, null);

						}
						/**
						 * .......修改更新的日期
						 */

						List<m_Address> li = model.Listm_Address.list;

						/**
						 * 网络获取结果不为空
						 */
						if (li != null) {

							CommonDbUtiles.deleteAll(context, m_Address.class);

							for (m_Address address : li) {
								CommonDbUtiles.insert(context, address);

							}

						} else {

							li = CommonDbUtiles.querryAll(context,
									m_Address.class);

						}

						// 准备数据

						HashMap<String, m_Address> map_address = new HashMap<String, m_Address>();

						ArrayList<String> list_address = new ArrayList<String>();

						if (li.size() != 0) {

							for (m_Address address : li) {

								list_address.add(address.vc_Name);

								map_address.put(address.vc_Name, address);

							}

							GlobleFields.list_Address = list_address;
							GlobleFields.map_Address = map_address;

							if (processCallBack != null)
								processCallBack.process(1);
							// *******
							// *******
							// *******
							initDepartment();

						} else {

							if (processCallBack != null)
								processCallBack.process(-1);

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
					public void onResult(String inner, boolean Result) {

					}
				});

	}

	/**
	 * 初始化部门
	 * 
	 * @param context
	 */
	public void initDepartment() {
		FinalNClient client = FinalNClient.getInstance();
		client.sendMessage(new ReqDepartment(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {
						LogUtils.careLog("iinner:" + inner);
						OutGetDepartmentModel model = (OutGetDepartmentModel) CommonXmlParser
								.parserXml(inner, new OutGetDepartmentModel());
						List<m_Department> li = model.getListM_Department()
								.getList();

						/**
						 * 网络获取结果不为空
						 */
						if (li != null) {
							// 清空数据库
							CommonDbUtiles.deleteAll(context,
									m_Department.class);

							for (m_Department department : li) {

								CommonDbUtiles.insert(context, department);

							}
						} else {
							li = CommonDbUtiles.querryAll(context,
									m_Department.class);

						}

						// 准备数据

						HashMap<String, m_Department> map_department = new HashMap<String, m_Department>();

						ArrayList<String> list_department = new ArrayList<String>();

						if (li.size() != 0) {
							for (m_Department department : li) {

								list_department.add(department.vc_Name);

								map_department.put(department.vc_Name,
										department);
							}

							// *******
							// *******
							// *******
							if (processCallBack != null)
								processCallBack.process(2);
							initMaterielType();

							GlobleFields.map_Department = map_department;
							GlobleFields.list_Department = list_department;
						} else {

							if (processCallBack != null)
								processCallBack.process(-1);

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
					public void onResult(String inner, boolean Result) {

					}
				});
	}

	/**
	 * 初始化物料类型
	 * 
	 * @param context
	 */
	public void initMaterielType() {

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(new ReqMaterielType(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {

						LogUtils.careLog("iinner:" + inner);

						OutGetMaterielTypeModel model = (OutGetMaterielTypeModel) CommonXmlParser
								.parserXml(inner, new OutGetMaterielTypeModel());

						List<m_MaterielType> li = model.getListM_MaterielType()
								.getList();

						if (li != null) {

							// 清空数据库
							CommonDbUtiles.deleteAll(context,
									m_MaterielType.class);

							for (m_MaterielType materielType : model
									.getListM_MaterielType().getList()) {

								CommonDbUtiles.insert(context, materielType);
							}

						} else {

							li = CommonDbUtiles.querryAll(context,
									m_MaterielType.class);

						}

						HashMap<String, m_MaterielType> map_materielType = new HashMap<String, m_MaterielType>();
						ArrayList<String> list_materielType = new ArrayList<String>();

						// 物量单位
						ArrayList<String> list_materielUnit = new ArrayList<String>();

						if (li.size() != 0) {

							for (m_MaterielType materielType : li) {

								map_materielType.put(materielType.vc_Name,
										materielType);

								list_materielType.add(materielType.vc_Name);

								list_materielUnit.add(materielType.getVc_Unit());

							}

							GlobleFields.list_MaterielType = list_materielType;
							GlobleFields.map_MaterielType = map_materielType;

							GlobleFields.list_MaterielUnit = list_materielUnit;

							// *******
							// *******
							// *******
							if (processCallBack != null)
								processCallBack.process(3);

							initPerson();
						} else {

							if (processCallBack != null)
								processCallBack.process(-1);

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
					public void onResult(String inner, boolean Result) {

					}
				});
	}

	/**
	 * 初始化人员
	 * 
	 * @param context
	 */
	public void initPerson() {

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(new ReqPerson(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {

						LogUtils.careLog("iinner:" + inner);

						OutGetPersonModel model = (OutGetPersonModel) CommonXmlParser
								.parserXml(inner, new OutGetPersonModel());

						List<m_Person> list = model.Listm_Person.list;

						if (list != null) {

							// 清空数据库，删除人员信息
							CommonDbUtiles.deleteAll(context, m_Person.class);

							for (m_Person person : list) {
								CommonDbUtiles.insert(context, person);
							}
						} else {
							list = CommonDbUtiles.querryAll(context,
									m_Person.class);
						}

						HashMap<String, m_Person> map_person = new HashMap<String, m_Person>();
						ArrayList<String> list_person = new ArrayList<String>();

						if (list.size() != 0) {

							for (m_Person person : list) {
								map_person.put(person.vc_Name, person);

								list_person.add(person.vc_Name);

							}
							// *******
							// *******
							// *******
							if (processCallBack != null)
								processCallBack.process(4);
							initVehicleType();

							GlobleFields.list_Person = list_person;
							GlobleFields.map_Person = map_person;

						} else {

							if (processCallBack != null)
								processCallBack.process(-1);

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
					public void onResult(String inner, boolean Result) {

					}
				});

	}

	/**
	 * 初始化车辆类型
	 * 
	 * @param context
	 */
	public void initVehicleType() {

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(new ReqVehicleType(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {

						LogUtils.careLog("iinner:" + inner);

						OutGetVehicleTypeModel model = (OutGetVehicleTypeModel) CommonXmlParser
								.parserXml(inner, new OutGetVehicleTypeModel());

						List<m_VehicleType> list = model.Listm_VehicleType.list;

						if (list != null) {

							// 清空数据
							CommonDbUtiles.deleteAll(context,
									m_VehicleType.class);

							for (m_VehicleType vehicleType : model.Listm_VehicleType.list) {
								CommonDbUtiles.insert(context, vehicleType);
							}

						} else {

							list = CommonDbUtiles.querryAll(context,
									m_VehicleType.class);

						}

						HashMap<String, m_VehicleType> map_vehicleType = new HashMap<String, m_VehicleType>();

						ArrayList<String> list_vehicleType = new ArrayList<String>();

						if (list.size() != 0) {

							for (m_VehicleType vehicleType : list) {

								map_vehicleType.put(vehicleType.vc_Name,
										vehicleType);

								list_vehicleType.add(vehicleType.vc_Name);

							}

							if (processCallBack != null)
								processCallBack.process(5);
							initCard();

							GlobleFields.list_VehicleType = list_vehicleType;
							GlobleFields.map_VehicleType = map_vehicleType;

						} else {

							if (processCallBack != null)
								processCallBack.process(-1);

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
					public void onResult(String inner, boolean Result) {

					}
				});

	}

	/**
	 * 初始化车辆编号
	 * 
	 * @param context
	 */
	public void initCard() {

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(new ReqCard(TimerUtils.getTime()),
				new NetCallback() {

					@Override
					public void onResult(String entireXml, String inner,
							boolean Result) {

						LogUtils.careLog("iinner:" + inner);

						OutGetCardModel model = (OutGetCardModel) CommonXmlParser
								.parserXml(inner, new OutGetCardModel());

						List<m_Card> list = model.Listm_Card.list;

						if (list != null) {

							// 清空数据
							CommonDbUtiles.deleteAll(context, m_Card.class);

							for (m_Card card : list) {

								CommonDbUtiles.insert(context, card);

							}

						} else {

							list = CommonDbUtiles.querryAll(context,
									m_Card.class);

						}

						if (list.size() != 0) {

							if (processCallBack != null)
								processCallBack.process(6);

							Toast.makeText(context, "基础数据更新完毕", 1).show();

						} else {

							if (processCallBack != null)
								processCallBack.process(-1);

						}

					}

					@Override
					public void onResult(String result) {

					}

					@Override
					public String getCmdType() {

						return NetCallback.Data_GetCard;

					}

					@Override
					public void doPrevious() {

					}

					@Override
					public void onResult(String inner, boolean Result) {

					}
				});

	}

	public String getLastUpdataTime(String entireXml) {

		XmlPullParser parser = Xml.newPullParser();
		try {
			// 设置输入流并指明编码方式
			parser.setInput(
					new ByteArrayInputStream(entireXml.getBytes("gb2312")),
					"gb2312");

			int eventType = parser.getEventType();

			while (eventType != XmlPullParser.END_DOCUMENT) {

				switch (eventType) {

				case XmlPullParser.START_TAG:
					if (parser.getName().equals("LastUpdateTime")) {
						eventType = parser.next();
						lastUpdateTime = parser.getText();
						return lastUpdateTime;
					}
					break;
				}
				eventType = parser.next();
			}

			return null;
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		}
	}

}
