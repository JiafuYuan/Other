package com.bestway.kj915.activity.home.loadvehilce;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;
import java.util.List;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.TimePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.TextUtils;
import android.view.View;
import android.widget.DatePicker;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.custom.MyDropdownBox;
import com.bestway.kj915.dao.CommonDbUtiles;
import com.bestway.kj915.domain.reflect.m_Address;
import com.bestway.kj915.domain.reflect.m_Department;
import com.bestway.kj915.domain.req.ReqPlanDetail;
import com.bestway.kj915.enumation.EnumFlowTypePath;

public class QuerryWaybillUiActivity extends BasicTitleActivity {

	private static final int SHOW_DATAPICK = 0;
	private static final int DATE_DIALOG_ID = 1;
	private static final int SHOW_TIMEPICK = 2;
	private static final int TIME_DIALOG_ID = 3;

	private int mYear;
	private int mMonth;
	private int mDay;
	private int mHour;
	private int mMinute;

	private boolean isFrom = true;
	private boolean isTo = true;
	public String broadReiceiver = "done";

	private MyDropdownBox department;
	private MyDropdownBox destination;
	private List<m_Department> dataDepartments;
	private ArrayList<String> dataList_Department;

	@Override
	public void doVarious() {
		title_text_view.setVisibility(View.VISIBLE);
		title_text_view.setText("查询运单");
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_load_vehicles_query_waybill_ui);

		// 初始化时间选择器
		initializeViews();
		initCalendar();

		initData();

		initView();

	}

	/**
	 * 初始化数据
	 */
	private void initData() {
		
		map_Department = GlobleFields.getHashMap_Department(this);
		dataList_Department = GlobleFields.getList_Department(this);
		map_Address = GlobleFields.getHashMap_Address(this);
		dataList_Address = GlobleFields.getList_Address(this);
		
	}

	private void initData1() {

		/**
		 * 初始化部门数据
		 */
		dataDepartments = CommonDbUtiles.querryAll(this, m_Department.class);

		dataList_Department = new ArrayList<String>();

		map_Department = new HashMap<String, m_Department>();

		for (m_Department department : dataDepartments) {

			map_Department.put(department.getVc_Name(), department);

			dataList_Department.add(department.getVc_Name());

		}

		/**
		 * 初始化地点信息
		 * 
		 */

		dataAddress = CommonDbUtiles.querryAll(this, m_Address.class);

		dataList_Address = new ArrayList<String>();

		map_Address = new HashMap<String, m_Address>();

		for (m_Address address : dataAddress) {

			map_Address.put(address.vc_Name, address);

			dataList_Address.add(address.vc_Name);

		}

	}

	private void initView() {

		department = (MyDropdownBox) findViewById(R.id.department);

		destination = (MyDropdownBox) findViewById(R.id.destination);

		department.setData(dataList_Department);
		destination.setData(dataList_Address);

	}

	public void query(View v) {

		// 检查日期时间
		// showDateFrom.getText().toString().equals(showDateTo.getText().toString())||

		if (TextUtils.isEmpty(showTimeFrom.getText().toString())
				|| TextUtils.isEmpty(showTimeTo.getText().toString())) {

			Toast.makeText(QuerryWaybillUiActivity.this, "请检查日期", 0).show();
			return;
		}

		System.out.println(showTimeTo.getText().toString());

		String beginDateTime = showDateFrom.getText().toString() + "T"
				+ showTimeFrom.getText().toString().replace("::", ":") + ":00";
		String endDateTime = showDateTo.getText().toString() + "T"
				+ showTimeTo.getText().toString().replace("::", ":") + ":00";

		// 处理部门
		int applyDepartmentID = 0;
		
		if (!TextUtils.isEmpty(department.getCurrentText().trim())) {

			applyDepartmentID = Integer.valueOf(map_Department.get(department
					.getCurrentText()).ID);
		}

		// 处理地点
		int arriveAddressID = 0;

		if (!TextUtils.isEmpty(destination.getCurrentText().trim())) {

			arriveAddressID = Integer.valueOf(map_Address.get(destination
					.getCurrentText()).ID);
		}

//		ReqPlanDetail reqPlan = new ReqPlanDetail(beginDateTime, endDateTime,
//				applyDepartmentID, arriveAddressID,
//				EnumFlowTypePath.Load.name(), -1, -1);

		Intent intent = new Intent(
				"com.bestway.kj915.activity.home.loadvehilce.QueryWaybillShowResultActivity");
		//intent.putExtra("reqPlan", reqPlan);

		startActivityForResult(intent, 0);

	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		super.onActivityResult(requestCode, resultCode, data);

		if (data != null && resultCode == 1) {

			setResult(1, data);

			finish();

		}
	}

	// 以下所有都是处理时间选择控件的操作
	// ####################
	// ####################
	private void initCalendar() {
		final Calendar c = Calendar.getInstance();
		mYear = c.get(Calendar.YEAR);
		mMonth = c.get(Calendar.MONTH);
		mDay = c.get(Calendar.DAY_OF_MONTH);
		mHour = c.get(Calendar.HOUR_OF_DAY);
		mMinute = c.get(Calendar.MINUTE);

		setDateTime();
		setTimeOfDay();
	}

	/**
	 * 初始化控件和UI视图
	 */
	private void initializeViews() {

		showDateFrom = (TextView) findViewById(R.id.showdateFrom);
		showTimeFrom = (TextView) findViewById(R.id.showtimeFrom);

		showTimeTo = (TextView) findViewById(R.id.showtimeTo);
		showDateTo = (TextView) findViewById(R.id.showdateTo);

		showDateFrom.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				isFrom = true;
				Message msg = new Message();

				msg.what = QuerryWaybillUiActivity.SHOW_DATAPICK;
				QuerryWaybillUiActivity.this.dateandtimeHandler
						.sendMessage(msg);
			}
		});

		showTimeFrom.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				isFrom = true;
				Message msg = new Message();
				if (showTimeFrom.equals((TextView) v)) {
					msg.what = QuerryWaybillUiActivity.SHOW_TIMEPICK;
				}
				QuerryWaybillUiActivity.this.dateandtimeHandler
						.sendMessage(msg);
			}
		});

		showDateTo.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				isTo = true;
				Message msg = new Message();

				msg.what = QuerryWaybillUiActivity.SHOW_DATAPICK;
				QuerryWaybillUiActivity.this.dateandtimeHandler
						.sendMessage(msg);
			}
		});

		showTimeTo.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				isTo = true;
				Message msg = new Message();
				if (showTimeTo.equals((TextView) v)) {
					msg.what = QuerryWaybillUiActivity.SHOW_TIMEPICK;
				}
				QuerryWaybillUiActivity.this.dateandtimeHandler
						.sendMessage(msg);
			}
		});
	}

	/**
	 * 设置日期
	 */
	private void setDateTime() {
		final Calendar c = Calendar.getInstance();

		mYear = c.get(Calendar.YEAR);
		mMonth = c.get(Calendar.MONTH);
		mDay = c.get(Calendar.DAY_OF_MONTH);

		updateDateDisplay();
	}

	/**
	 * 更新日期显示
	 */
	private void updateDateDisplay() {

		if (isFrom)
			showDateFrom.setText(new StringBuilder()
					.append(mYear)
					.append("-")
					.append((mMonth + 1) < 10 ? "0" + (mMonth + 1)
							: (mMonth + 1)).append("-")
					.append((mDay < 10) ? "0" + mDay : mDay));
		if (isTo)
			showDateTo.setText(new StringBuilder()
					.append(mYear)
					.append("-")
					.append((mMonth + 1) < 10 ? "0" + (mMonth + 1)
							: (mMonth + 1)).append("-")
					.append((mDay < 10) ? "0" + mDay : mDay));
		isFrom = false;
		isTo = false;
	}

	/**
	 * 日期控件的事件
	 */
	private DatePickerDialog.OnDateSetListener mDateSetListener = new DatePickerDialog.OnDateSetListener() {

		public void onDateSet(DatePicker view, int year, int monthOfYear,
				int dayOfMonth) {
			mYear = year;
			mMonth = monthOfYear;
			mDay = dayOfMonth;

			updateDateDisplay();
		}
	};

	/**
	 * 设置时间
	 */
	private void setTimeOfDay() {
		final Calendar c = Calendar.getInstance();
		mHour = c.get(Calendar.HOUR_OF_DAY);
		mMinute = c.get(Calendar.MINUTE);
		updateTimeDisplay();
	}

	/**
	 * 更新时间显示
	 */
	private void updateTimeDisplay() {
		if (isFrom)
			showTimeFrom.setText(new StringBuilder().append(mHour).append(":")
					.append((mMinute < 10) ? "0" + mMinute : mMinute));
		if (isTo)
			showTimeTo.setText(new StringBuilder().append(mHour).append(":")
					.append((mMinute < 10) ? "0" + mMinute : mMinute));
		isFrom = false;
		isTo = false;
	}

	/**
	 * 时间控件事件
	 */
	private TimePickerDialog.OnTimeSetListener mTimeSetListener = new TimePickerDialog.OnTimeSetListener() {

		@Override
		public void onTimeSet(TimePicker view, int hourOfDay, int minute) {

			mHour = hourOfDay;
			mMinute = minute;

			updateTimeDisplay();
		}
	};

	@Override
	protected Dialog onCreateDialog(int id) {
		switch (id) {

		case DATE_DIALOG_ID:
			return new DatePickerDialog(this, mDateSetListener, mYear, mMonth,
					mDay);

		case TIME_DIALOG_ID:
			return new TimePickerDialog(this, mTimeSetListener, mHour, mMinute,
					true);
		}

		return null;
	}

	@Override
	protected void onPrepareDialog(int id, Dialog dialog) {
		switch (id) {
		case DATE_DIALOG_ID:

			((DatePickerDialog) dialog).updateDate(mYear, mMonth, mDay);
			break;

		case TIME_DIALOG_ID:

			((TimePickerDialog) dialog).updateTime(mHour, mMinute);
			break;

		}
	}

	/**
	 * 处理日期和时间控件的Handler
	 */
	Handler dateandtimeHandler = new Handler() {

		@Override
		public void handleMessage(Message msg) {
			switch (msg.what) {
			case QuerryWaybillUiActivity.SHOW_DATAPICK:
				showDialog(DATE_DIALOG_ID);
				break;
			case QuerryWaybillUiActivity.SHOW_TIMEPICK:
				showDialog(TIME_DIALOG_ID);
				break;
			}
		}

	};
	/**
	 * 起始时间
	 */
	private TextView showDateFrom;
	private TextView showTimeFrom;
	/**
	 * 结束时间
	 */
	private TextView showDateTo;
	private TextView showTimeTo;
	// ####################
	// ####################
	// 以上所有的都是处理时间选择控件的操作
	private List<m_Address> dataAddress;
	private ArrayList<String> dataList_Address;
	private HashMap<String, m_Department> map_Department;
	private HashMap<String, m_Address> map_Address;

}
