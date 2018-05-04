package com.bestway.kj915.activity.home.apply;

import java.util.ArrayList;
import java.util.Calendar;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.app.TimePickerDialog;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.TimePicker;

import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.custom.MyDropdownBox;

public class Apply_GoodsActivity1 extends BasicTitleActivity {

	private static final int SHOW_DATAPICK = 0;
	private static final int DATE_DIALOG_ID = 1;
	private static final int SHOW_TIMEPICK = 2;
	private static final int TIME_DIALOG_ID = 3;

	private int mYear;
	private int mMonth;
	private int mDay;
	private int mHour;
	private int mMinute;

	@Override
	public void doVarious() {
		title_text_view.setText("申请物料");
		title_text_view.setVisibility(View.VISIBLE);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_apply_goods);

		// 初始化时间选择器
		initializeViews();
		initCalendar();

		initData();
		initView();
	}

	private void initData() {

	}

	public void initView() {

		lv = (ListView) findViewById(R.id.lv);
		adapter = new MyAdapter();
		lv.setAdapter(adapter);

		Button add_lv = (Button) findViewById(R.id.add_lv);
		// 给点击事件增加添加一条
		add_lv.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				size = size + 1;
				adapter.notifyDataSetChanged();
			}
		});

	}

	// 获取单位的集合
	public ArrayList<String> getUnitData() {
		ArrayList<String> unitList = new ArrayList<String>();
		unitList.add("顿");
		unitList.add("kg");
		unitList.add("根");
		return unitList;
	}

	// 获取申请物品的种类
	public ArrayList<String> getGoodsCatagoryData() {
		ArrayList<String> numberList = new ArrayList<String>();
		numberList.add("沙子");
		numberList.add("水泥");
		numberList.add("石块");
		return numberList;
	}

	// 提交到服务器
	public void submit(View view) {
	}

	private int size = 1;

	class MyAdapter extends BaseAdapter {

		@Override
		public int getCount() {

			return size;
		}

		@Override
		public Object getItem(int position) {
			return null;
		}

		@Override
		public long getItemId(int position) {
			return 0;
		}

		@Override
		public View getView(int position, View convertView, ViewGroup parent) {
			View view = View.inflate(Apply_GoodsActivity1.this,
					R.layout.item_goods_apply, null);
			// 申请货物的分类
			MyDropdownBox dropdownBox = (MyDropdownBox) view
					.findViewById(R.id.catagory);
			// 申请货物的单位
			MyDropdownBox unit = (MyDropdownBox) view.findViewById(R.id.unit);

			ArrayList<String> unitList = getUnitData();
			unit.setData(unitList);

			ArrayList<String> goodsCatagoryData = getGoodsCatagoryData();
			dropdownBox.setData(goodsCatagoryData);
			return view;
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
		showDate = (TextView) findViewById(R.id.showdate);
		showTime = (TextView) findViewById(R.id.showtime);

		showDate.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				Message msg = new Message();

				msg.what = Apply_GoodsActivity1.SHOW_DATAPICK;
				Apply_GoodsActivity1.this.dateandtimeHandler.sendMessage(msg);
			}
		});

		showTime.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				Message msg = new Message();
				if (showTime.equals((TextView) v)) {
					msg.what = Apply_GoodsActivity1.SHOW_TIMEPICK;
				}
				Apply_GoodsActivity1.this.dateandtimeHandler.sendMessage(msg);
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
		showTime.setText(new StringBuilder().append(mHour).append(":")
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
			case Apply_GoodsActivity1.SHOW_DATAPICK:
				showDialog(DATE_DIALOG_ID);
				break;
			case Apply_GoodsActivity1.SHOW_TIMEPICK:
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
	private ListView lv;
	private MyAdapter adapter;
}
