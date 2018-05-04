package com.bestway.kj915;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import com.bestway.kj915.activity.home.backvehicle.BackVehicleActivityNFCActivity;
import com.bestway.kj915.activity.home.loadvehilce.LoadChooseActivity;
import com.bestway.kj915.activity.home.loadvehilce.LoadNFCActivity;
import com.bestway.kj915.dao.CommonDbUtiles;
import com.bestway.kj915.domain.User;
import com.bestway.kj915.domain.m_Plan;
import com.bestway.kj915.domain.reflect.m_Address;
import com.bestway.kj915.domain.reflect.m_Card;
import com.bestway.kj915.domain.reflect.m_Department;
import com.bestway.kj915.domain.reflect.m_MaterielType;
import com.bestway.kj915.domain.reflect.m_Person;
import com.bestway.kj915.domain.reflect.m_VehicleType;
import com.bestway.kj915.domain.req.load.ReqLoad;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;

public class GlobleFields {

	public static Intent serverIntent = null;
	// ��SetIpActivity�и�ֵ
	public static SharedPreferences sp;
	// �ж��Ƿ�����ý�����ת�����������ý�����ת��ʱ������Ϊtrue��
	public static boolean isFromSetting = false;
	// �ж��Ƿ����ҳ����ת�������ڴӰ�����ť��ת��ʱ������Ϊfalse��
	public static boolean isLoadFromIndex = true;

	/**
	 * ��¼�û���id���ڵ�һ��¼��ʱ�򱻸�ֵ��
	 */
	public static int UserID;
	//public static String ip;
	public static User user;
	public static String IP;

	/**
	 * �Ĵ�������ݱ��������ͣ����ţ���Ա��������������
	 */
	public static HashMap<String, m_Address> map_Address;
	public static ArrayList<String> list_Address;

	public static HashMap<String, m_Person> map_Person;
	public static ArrayList<String> list_Person;

	public static HashMap<String, m_VehicleType> map_VehicleType;
	public static ArrayList<String> list_VehicleType;

	public static HashMap<String, m_MaterielType> map_MaterielType;
	public static ArrayList<String> list_MaterielType;

	public static HashMap<String, m_Department> map_Department;
	public static ArrayList<String> list_Department;

	// ������λ
	public static ArrayList<String> list_MaterielUnit;

	// ��ǰ������˵�
	public static m_Plan CurrentPlan;

	// ����װ��
	public static ReqLoad reqLoad;
	public static BackVehicleActivityNFCActivity BACK;
	
	public static LoadChooseActivity LOAD;
	


	/**
	 * ��ȡ�������ݵ�ַ
	 * 
	 * @param context
	 * @return
	 */
	public static ArrayList<String> getList_Address(Context context) {

		List<m_Address> li = CommonDbUtiles.querryAll(context, m_Address.class);

		HashMap<String, m_Address> map_address = new HashMap<String, m_Address>();

		ArrayList<String> list_address = new ArrayList<String>();

		if (li.size() != 0) {

			for (m_Address address : li) {

				list_address.add(address.vc_Name);

			}

		}

		return list_address;

	}

	/**
	 * ��ȡ�������ݡ�����ַ���ƣ���ַ��ӳ��
	 * 
	 * @param context
	 * @return
	 */
	public static HashMap<String, m_Address> getHashMap_Address(Context context) {

		List<m_Address> li = CommonDbUtiles.querryAll(context, m_Address.class);

		HashMap<String, m_Address> map_address = new HashMap<String, m_Address>();

		if (li.size() != 0) {

			for (m_Address address : li) {

				map_address.put(address.vc_Name, address);

			}

		}

		return map_address;

	}

	/**
	 * ��ȡ�������ݡ���������λ
	 * 
	 * @param context
	 * @return
	 */
	public static ArrayList<String> getList_MaterielUnit(Context context) {

		List<m_MaterielType> li = CommonDbUtiles.querryAll(context,
				m_MaterielType.class);

		// ������λ
		ArrayList<String> list_materielUnit = new ArrayList<String>();

		if (li.size() != 0) {

			for (m_MaterielType materielType : li) {

				list_materielUnit.add(materielType.getVc_Unit());

			}

		}

		return list_materielUnit;

	}

	/**
	 * ��ȡ�������ݡ��������������ƣ����ϵ�λ
	 * 
	 * @param context
	 * @return
	 */
	public static HashMap<String, String> getHashMap_MaterielUnit(
			Context context) {

		List<m_MaterielType> li = CommonDbUtiles.querryAll(context,
				m_MaterielType.class);

		HashMap<String, String> map_materielUnit = new HashMap<String, String>();

		if (li.size() != 0) {

			for (m_MaterielType materielType : li) {

				map_materielUnit
						.put(materielType.vc_Name, materielType.vc_Unit);

			}

		}

		return map_materielUnit;

	}

	/**
	 * ��ȡ�������ݡ���������������
	 * 
	 * @param context
	 * @return
	 */
	public static ArrayList<String> getList_MaterielType(Context context) {

		List<m_MaterielType> li = CommonDbUtiles.querryAll(context,
				m_MaterielType.class);

		ArrayList<String> list_materielType = new ArrayList<String>();

		if (li.size() != 0) {

			for (m_MaterielType materielType : li) {

				list_materielType.add(materielType.vc_Name);

			}

		}

		return list_materielType;

	}

	/**
	 * ��ȡ�������ݡ����������ƣ�����ӳ��
	 * 
	 * @param context
	 * @return
	 */
	public static HashMap<String, m_MaterielType> getHashMap_MaterielType(
			Context context) {

		List<m_MaterielType> li = CommonDbUtiles.querryAll(context,
				m_MaterielType.class);

		HashMap<String, m_MaterielType> map_materielType = new HashMap<String, m_MaterielType>();

		if (li.size() != 0) {

			for (m_MaterielType materielType : li) {

				map_materielType.put(materielType.vc_Name, materielType);

			}

		}

		return map_materielType;

	}

	/**
	 * ��ȡ�������ݵ���Ա
	 * 
	 * @param context
	 * @return
	 */
	public static ArrayList<String> getList_Person(Context context) {

		List<m_Person> li = CommonDbUtiles.querryAll(context, m_Person.class);

		ArrayList<String> list_person = new ArrayList<String>();

		if (li.size() != 0) {

			for (m_Person person : li) {

				list_person.add(person.vc_Name);

			}

		}

		return list_person;

	}

	/**
	 * ��ȡ�������ݡ�����Ա���ƣ���Աӳ��
	 * 
	 * @param context
	 * @return
	 */
	public static HashMap<String, m_Person> getHashMap_Person(Context context) {

		List<m_Person> li = CommonDbUtiles.querryAll(context, m_Person.class);

		HashMap<String, m_Person> map_person = new HashMap<String, m_Person>();

		if (li.size() != 0) {

			for (m_Person person : li) {

				map_person.put(person.vc_Name, person);

			}

		}

		return map_person;

	}

	/**
	 * ��ȡ�������ݵĲ���
	 * 
	 * @param context
	 * @return
	 */
	public static ArrayList<String> getList_Department(Context context) {

		List<m_Department> li = CommonDbUtiles.querryAll(context,
				m_Department.class);

		ArrayList<String> list_department = new ArrayList<String>();

		if (li.size() != 0) {

			for (m_Department department : li) {

				list_department.add(department.vc_Name);

			}

		}

		return list_department;

	}

	/**
	 * ��ȡ�������ݡ����������ƣ�����ӳ��
	 * 
	 * @param context
	 * @return
	 */
	public static HashMap<String, m_Department> getHashMap_Department(
			Context context) {

		System.out.println("�������ݲ���......");

		List<m_Department> li = CommonDbUtiles.querryAll(context,
				m_Department.class);

		HashMap<String, m_Department> map_department = new HashMap<String, m_Department>();

		if (li.size() != 0) {

			for (m_Department department : li) {

				map_department.put(department.vc_Name, department);

			}

		}

		return map_department;

	}

	/**
	 * ��ȡ�������ݡ������г���������
	 * 
	 * @param context
	 * @return
	 */
	public static ArrayList<String> getList_VehicleType(Context context) {

		List<m_VehicleType> li = CommonDbUtiles.querryAll(context,
				m_VehicleType.class);

		ArrayList<String> list_vehicleType = new ArrayList<String>();

		if (li.size() != 0) {

			for (m_VehicleType vehicleType : li) {

				list_vehicleType.add(vehicleType.vc_Name);

			}

		}

		return list_vehicleType;

	}

	/**
	 * ��ȡ�������ݡ����������ƣ���������ӳ��
	 * 
	 * @param context
	 * @return
	 */
	public static HashMap<String, m_VehicleType> getHashMap_VehicleType(
			Context context) {

		List<m_VehicleType> li = CommonDbUtiles.querryAll(context,
				m_VehicleType.class);

		HashMap<String, m_VehicleType> map_vehicleType = new HashMap<String, m_VehicleType>();

		if (li.size() != 0) {

			for (m_VehicleType vehicleType : li) {

				map_vehicleType.put(vehicleType.vc_Name, vehicleType);

			}

		}

		return map_vehicleType;

	}

	/**
	 * ��ȡ�������ݡ���������ţ�������ID
	 * 
	 * @param context
	 * @return
	 */
	public static HashMap<Integer, Integer> getHashMap_Card(Context context) {

		List<m_Card> li = CommonDbUtiles.querryAll(context, m_Card.class);

		HashMap<Integer, Integer> map_vehicleType = new HashMap<Integer, Integer>();

		if (li.size() != 0) {

			for (m_Card card : li) {

				map_vehicleType.put(card.i_LocalizerCardHID, card.VehicleID);

			}

		}

		return map_vehicleType;

	}

}
