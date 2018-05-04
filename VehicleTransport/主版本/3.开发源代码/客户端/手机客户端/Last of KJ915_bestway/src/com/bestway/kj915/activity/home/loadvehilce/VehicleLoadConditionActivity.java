package com.bestway.kj915.activity.home.loadvehilce;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

import android.app.AlertDialog;
import android.app.AlertDialog.Builder;
import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.TimePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.TextUtils;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.DatePicker;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.custom.MyDropdownBox;
import com.bestway.kj915.domain.req.load.LoadContainer;
import com.bestway.kj915.domain.req.load.ReqLoad;
import com.bestway.kj915.domain.req.load.m_Plan_Load;
import com.bestway.kj915.utils.TimerUtils;

public class VehicleLoadConditionActivity extends BasicTitleActivity {

	@Override
	public void doVarious() {
		title_text_view.setVisibility(View.VISIBLE);
		title_text_view.setText("装车信息");

		// 把刷新按钮替换为运单详情
		/*
		 * title_image_flush.setVisibility(View.VISIBLE);
		 * title_image_flush.setImageResource(R.drawable.waybill_description);
		 * 
		 * title_image_flush.setOnClickListener(new OnClickListener() {
		 * 
		 * @Override public void onClick(View v) { View vi =
		 * View.inflate(VehicleLoadConditionActivity.this,
		 * R.layout.item_waybill, null); Builder bu = new
		 * Builder(VehicleLoadConditionActivity.this); AlertDialog dialog =
		 * bu.create();
		 * 
		 * vi.findViewById(R.id.jiantou).setVisibility(View.GONE);
		 * 
		 * dialog.setView(vi);
		 * 
		 * dialog.show();
		 * 
		 * } });
		 */
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		setContentView(R.layout.activity_load_vehicle_choose_condition);

		// 初始化时间选择器
		initializeViews();
		initCalendar();

		initData();

	}

	private void initData() {

	}

	/**
	 * 下一步
	 */
	public void toContinue(View v) {

		// 部门
		String tv_department = department.getCurrentText();

		// 地点
		String tv_address = address.getCurrentText();

		// 时间
		String time = showDate.getText().toString() + "T"
				+ showTime.getText().toString() + ":00";

		if (!TextUtils.isEmpty(tv_department) && !TextUtils.isEmpty(tv_address)) {
			// 初始化消息发送请求
			ReqLoad load = new ReqLoad();

			LoadContainer container = new LoadContainer();

			List<m_Plan_Load> list = new ArrayList<m_Plan_Load>();

			container.list = list;

			load.ListM_Plan_Load = container;

			// *************
			load.AddressID = 0;

			load.DepartmentID = 0;

			load.DateTime = TimerUtils.getTime();
			// *************

			load.UserID = GlobleFields.UserID;

			load.PlanID = GlobleFields.CurrentPlan.ID;
			// load.PlanID = 111;

			GlobleFields.reqLoad = load;

			finish();
			
			Intent intent = new Intent(
					"com.bestway.kj915.activity.home.loadvehilce.VehicleLoadNfcActivity");
			
			startActivity(intent);

		} else {

			Toast.makeText(this, "选择条件不能为空", 0).show();

		}

	}

	// 以下所有都是处理时间选择控件的操作
	// ####################
	// ####################

	private static final int SHOW_DATAPICK = 0;
	private static final int DATE_DIALOG_ID = 1;
	private static final int SHOW_TIMEPICK = 2;
	private static final int TIME_DIALOG_ID = 3;

	private int mYear;
	private int mMonth;
	private int mDay;
	private int mHour;
	private int mMinute;

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
		showDate = (TextView) findViewById(R.id.showdate);
		showTime = (TextView) findViewById(R.id.showtime);

		showDate.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				Message msg = new Message();

				msg.what = VehicleLoadConditionActivity.SHOW_DATAPICK;
				VehicleLoadConditionActivity.this.dateandtimeHandler
						.sendMessage(msg);
			}
		});

		showTime.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				Message msg = new Message();
				if (showTime.equals((TextView) v)) {
					msg.what = VehicleLoadConditionActivity.SHOW_TIMEPICK;
				}
				VehicleLoadConditionActivity.this.dateandtimeHandler
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
		showDate.setText(new StringBuilder().append(mYear).append("-")
				.append((mMonth + 1) < 10 ? "0" + (mMonth + 1) : (mMonth + 1))
				.append("-").append((mDay < 10) ? "0" + mDay : mDay));
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
		showTime.setText(new StringBuilder()
				.append((mHour < 10) ? "0" + mHour : mHour).append(":")
				.append((mMinute < 10) ? "0" + mMinute : mMinute));
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
			case VehicleLoadConditionActivity.SHOW_DATAPICK:
				showDialog(DATE_DIALOG_ID);
				break;
			case VehicleLoadConditionActivity.SHOW_TIMEPICK:
				showDialog(TIME_DIALOG_ID);
				break;
			}
		}

	};
	private TextView showDate;
	private TextView showTime;
	// ####################
	// ####################
	// 以上所有的都是处理时间选择控件的操作
	private MyDropdownBox department;
	private MyDropdownBox address;

}
