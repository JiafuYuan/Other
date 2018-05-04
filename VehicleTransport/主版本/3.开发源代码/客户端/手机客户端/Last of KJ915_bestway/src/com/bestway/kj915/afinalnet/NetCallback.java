package com.bestway.kj915.afinalnet;

public interface NetCallback {

	/**
	 * �����������Ϣ��Ӧ���ַ���
	 */
	public static String None = "None";
	public static String HeartBeat = "HeartBeat";
	public static String Login = "Login";
	public static String LoginOut = "LoginOut";

	public static String GetFlowPath = "GetFlowPath";
	public static String GetTime = "GetTime";
	public static String GetAPKVersion = "GetAPKVersion";
	public static String GetAPKFile = "GetAPKFile";

	public static String Flow_Apply = "Flow_Apply";
	public static String Flow_Give = "Flow_Give";
	public static String Flow_Load = "Flow_Load";
	public static String Flow_Handover = "Flow_Handover";
	public static String Flow_UnLoad = "Flow_UnLoad";
	public static String Flow_Back = "Flow_Back";

	public static String Data_GetPerson = "Data_GetPerson";
	public static String Data_GetMessage = "Data_GetMessage";
	public static String Data_GetMaterielType = "Data_GetMaterielType";
	public static String Data_GetVehicle = "Data_GetVehicle";
	public static String Data_GetVehicleType = "Data_GetVehicleType";
	public static String Data_GetDepartment = "Data_GetDepartment";
	public static String Data_GetPlanDetail = "Data_GetPlanDetail";
	public static String Data_GetAddress = "Data_GetAddress";
	public static String Data_GetCard = "Data_GetCard";
	public static String Data_GetUser = "Data_GetUser";
	public static String Data_SendMessage = "Data_SendMessage";
	public static String Data_GetVehicleDistributed="Data_GetVehicleDistributed";
	
	public static String ChangePassword = "ChangePassword";

	/**
	 * �жϵ�ǰ��Ϣ���͵�Ψһ��ʶ�����뷵���ַ����������ָ���쳣�����е����Ͷ���FinalNClient�е��ֶΣ�
	 * 
	 * @return
	 */
	public String getCmdType();

	/**
	 * һ����UI�߳���ִ�еķ����� ����ǰ���õķ�������ʼ���Ի���֮���
	 */
	public void doPrevious();

	/**
	 * һ����UI�߳���ִ�еķ�������Ϣ����󷵻ع������ܵĽ���������ⲿxml��
	 * 
	 * @param result
	 */
	public void onResult(String result);

	
	
	/**
	 * ���أ�ʵ�ʹ��̽���ʹ�ã����������֪�ⲿxml��boolean���result���ڲ����ַ���
	 * 
	 * @param inner
	 * @param Result
	 */
	public void onResult(String inner, boolean Result);
	
	
	/**
	 * ����
	 * @param entireXml
	 * @param inner
	 * @param Result
	 */
	public void onResult(String entireXml,String inner, boolean Result);
}
