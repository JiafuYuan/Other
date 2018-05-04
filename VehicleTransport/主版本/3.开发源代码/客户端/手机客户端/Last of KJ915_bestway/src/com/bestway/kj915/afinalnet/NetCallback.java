package com.bestway.kj915.afinalnet;

public interface NetCallback {

	/**
	 * 所有请求的消息对应的字符串
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
	 * 判断当前消息类型的唯一标识，必须返回字符串否则包空指针异常（所有的类型都在FinalNClient中的字段）
	 * 
	 * @return
	 */
	public String getCmdType();

	/**
	 * 一般在UI线程中执行的方法， 请求前调用的方法，初始化对话框之类的
	 */
	public void doPrevious();

	/**
	 * 一般在UI线程中执行的方法：消息请求后返回过来的总的结果（包括外部xml）
	 * 
	 * @param result
	 */
	public void onResult(String result);

	
	
	/**
	 * 重载，实际过程建议使用，结果处理，已知外部xml的boolean结果result，内部的字符串
	 * 
	 * @param inner
	 * @param Result
	 */
	public void onResult(String inner, boolean Result);
	
	
	/**
	 * 重载
	 * @param entireXml
	 * @param inner
	 * @param Result
	 */
	public void onResult(String entireXml,String inner, boolean Result);
}
