package com.bestway.kj915.activity.home.apply;

/**
 * 版权：南京北路自动化系统有限公司版权所有
 * 
 * 作者：詹学勇
 * 
 * 版本：1.0
 * 
 * 时间：2014-8-21 下午5:03:50
 */
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.TimePickerDialog;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.TextUtils;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnTouchListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.custom.MyDropdownBox;
import com.bestway.kj915.custom.MyDropdownBox.ContentChangeListener;
import com.bestway.kj915.domain.Item_Waybill;
import com.bestway.kj915.domain.Item_apply_goods;
import com.bestway.kj915.domain.req.apply.Container1;
import com.bestway.kj915.domain.req.apply.Container2;
import com.bestway.kj915.domain.req.apply.ListM_Plan_ApplyMaterie_Item;
import com.bestway.kj915.domain.req.apply.M_Apply;
import com.bestway.kj915.domain.req.apply.ReqApply;
import com.bestway.kj915.domain.res.plan.m_Plan_ApplyVehicle;
import com.bestway.kj915.utils.TimerUtils;

public class Apply_VehiclesActivity extends BasicTitleActivity {

	private List<Item_Waybill> datas;// 保存有当前运单的信息，实际使用时候建议采用实时获取数据
	private ArrayList<String> usedCatagoryData;// 保存这历史界面已经选择的所有车型
	private ArrayList<String> currentCatagoryData;// 保存这当前界面已经选择的所有车型

	private ListView lv;
	private VehiclesAdapter adapter;

	boolean isdeleting = false;// 作为adapter在刷新时候判断是增加还是删除的依据，用完要复位
	boolean isadding = false;// 作为adapter在添加时候的依据，用完要复位
	private int deletePosition = -1;// 用完要复位,判断删除的位置

	@Override
	public void doVarious() {
		title_text_view.setText("申请车辆");
		title_text_view.setVisibility(View.VISIBLE);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_apply_vehicles);

		// 初始化时间选择器
		initializeViews();
		initCalendar();

		initdata();
		initView();

	}

	private void initView() {

		// @1ListView进行初始化，添加头尾
		lv = (ListView) findViewById(R.id.lv);
		View header = View.inflate(this, R.layout.vehicle_supply_header, null);
		View footer = View.inflate(this, R.layout.vehicle_supply_footer, null);
		// I：头部添加点击事件，点击的时候隐藏删除的垃圾箱
		header.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				cancleDelete();
			}
		});
		// II：给尾部添加点击事件，点击的时候隐藏删除的垃圾箱
		footer.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				cancleDelete();
			}
		});
		// III：尾部点击添加一条事件
		footer.findViewById(R.id.creat).setOnClickListener(
				new OnClickListener() {

					@Override
					public void onClick(View v) {
						isadding = true;

						adapter.notifyDataSetChanged();
					}
				});
		// IV：添加头尾部
		lv.addHeaderView(header);
		lv.addFooterView(footer);

		// @4给listview添加适配器
		adapter = new VehiclesAdapter();
		lv.setAdapter(adapter);

		// @5给ListView添加点左右滑动事件，从而可以删除，添加一条
		lv.setOnTouchListener(new OnTouchListener() {

			private int preX = 0;
			private int preY = 0;
			private int currentX;
			private int currentY;

			@Override
			public boolean onTouch(View v, MotionEvent event) {

				switch (event.getAction()) {
				case MotionEvent.ACTION_DOWN:
					preX = (int) event.getX();
					preY = (int) event.getY();
					break;

				case MotionEvent.ACTION_UP: {
					currentX = (int) event.getX();
					currentY = (int) event.getY();

					float x = (float) (Math.abs(currentX - preX));
					float y = (float) (Math.abs(currentY - preY));
					if (0.33f < (x / y) && (x / y) < 3f) {
						Toast.makeText(Apply_VehiclesActivity.this,
								"请竖直或者水平滑动手指！", 0).show();
					} else {

						if ((currentY - preY) > 78) {
							isadding = true;
							adapter.notifyDataSetChanged();
							break;

						}
						if ((currentY - preY) < -78) {
							if (datas != null && datas.size() != 0) {
								isdeleting = true;
								deletePosition = datas.size() - 1;
								adapter.notifyDataSetChanged();
							}
							break;

						}
						if ((preX - currentX) > 12) {

							for (int i = 0; i < lv.getChildCount(); i++) {
								View item = lv.getChildAt(i);
								View ib_tanchu = item
										.findViewById(R.id.ib_tanchu);
								if (ib_tanchu != null)
									ib_tanchu.setVisibility(View.GONE);
							}
							break;
						}
						if ((currentX - preX) > 12) {
							cancleDelete();
							break;
						}

					}
				}
					break;
				}

				return false;
			}
		});

		destination = (MyDropdownBox) findViewById(R.id.destination);

		destination.setData(GlobleFields.getList_Address(this));

		purpose = (EditText) findViewById(R.id.purpose);
	}

	// 取消弹出删除垃圾箱
	public void cancleDelete() {
		for (int i = 0; i < lv.getChildCount(); i++) {
			View v = lv.getChildAt(i).findViewById(R.id.ib_tanchu);
			if (v != null)
				v.setVisibility(View.VISIBLE);
		}
	}

	// 初始化数据
	private void initdata() {
		usedCatagoryData = new ArrayList<String>();
		// 运单的子条目
		datas = new ArrayList<Item_Waybill>();
	}

	class VehiclesAdapter extends BaseAdapter {

		@Override
		public int getCount() {
			return datas.size();
		}

		/**
		 * 复写更新操作，以便在更新之前保存好我们已经填写的数据，防止数据丢失
		 */
		@Override
		public void notifyDataSetChanged() {
			// 保存数据
			saveLvdata();

			super.notifyDataSetChanged();
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
		public View getView(final int position, View convertView,
				ViewGroup parent) {

			View view = View.inflate(Apply_VehiclesActivity.this,
					R.layout.vehicle_supply_item, null);

			// 删除按钮和弹出删除按钮的初始化
			final ImageButton ib_tanchu = (ImageButton) view
					.findViewById(R.id.ib_tanchu);
			final ImageButton ib_delete = (ImageButton) view
					.findViewById(R.id.ib_delete);
			// 数量
			EditText tv_number = (EditText) view.findViewById(R.id.number);
			tv_number.setText(datas.get(position).getNumber() + "");
			// 货物类型
			System.out.println(datas.get(position).getCatagory());
			MyDropdownBox catagory = (MyDropdownBox) view
					.findViewById(R.id.catagory);
			catagory.setHeaderGone();
			// 设置车型选择框的数据，默认将当前车的类型设置为第一个
			catagory.setData(currentCatagoryData);

			// 设置车的类型，此方法必须在setData后调用
			catagory.setContent(datas.get(position).getCatagory());

			// 下拉选择框添加监听
			catagory.setOnContentChangeListener(new ContentChangeListener() {

				@Override
				public void onContentChange(String content) {
					System.out.println("usedCatagoryData////"
							+ usedCatagoryData);
					if (usedCatagoryData.contains(content)) {
						Toast.makeText(Apply_VehiclesActivity.this,
								"该种类车型已经存在", 1).show();
					}
					currentCatagoryData.add(content);
					adapter.notifyDataSetChanged();
				}

				@Override
				public void sameContent(String content) {

				}
			});

			// 弹出删除按钮
			ib_tanchu.setOnClickListener(new OnClickListener() {

				@Override
				public void onClick(View v) {
					ib_tanchu.setVisibility(View.GONE);
				}
			});

			// 删除按钮添加事件
			ib_delete.setOnClickListener(new OnClickListener() {

				@Override
				public void onClick(View v) {
					isdeleting = true;
					deletePosition = position;
					adapter.notifyDataSetChanged();
				}
			});

			return view;
		}
	}

	// 在刷新前保存ListView中我们填写好的数据
	public void saveLvdata() {

		// @1清空数据记录，并重新初始化
		datas.clear();
		currentCatagoryData = getCatagory();

		// @2获取子条目中我们一填写好的数据并进行保存
		for (int i = 0; i < lv.getChildCount(); i++) {
			View v = lv.getChildAt(i);
			{
				MyDropdownBox catagory = (MyDropdownBox) v
						.findViewById(R.id.catagory);
				if (catagory != null) {
					String catagoryName = catagory.getCurrentText();
					EditText tv_number = (EditText) v.findViewById(R.id.number);
					usedCatagoryData.add(catagoryName);

					currentCatagoryData.removeAll(usedCatagoryData);

					int number = Integer
							.valueOf(tv_number.getText().toString());
					datas.add(new Item_Waybill(catagoryName, number));
				}

			}

		}

		// @3历史记录的用完后腰重新删除，复位
		usedCatagoryData.clear();

		// @ 4增加操作
		if (isadding) {
			isadding = false;
			if (currentCatagoryData.size() == 0) {
				Toast.makeText(this, "无更多车型可选", 1).show();
				return;
			}

			datas.add(new Item_Waybill(currentCatagoryData.get(0), 1));
			currentCatagoryData.remove(0);// 删除一条历史记录，保证下拉框中不存在

		}
		// @5删除操作
		if (isdeleting) {
			isdeleting = false;
			currentCatagoryData.add(datas.get(deletePosition).getCatagory());
			datas.remove(deletePosition);
			deletePosition = -1;

		}

	}

	// 提交运单到服务器
	public void commit(View view) {

		saveLvdata();

		// 目的地
		String des = destination.getCurrentText();
		// 日期
		String data = showDate.getText().toString();
		// 时间
		String time = showTime.getText().toString();

		/**
		 * 目的地位空判断
		 */
		if (TextUtils.isEmpty(des)) {
			Toast.makeText(this, "目的地不能为空", 0).show();
			return;
		}

		List<m_Plan_ApplyVehicle> vehicles = new ArrayList<m_Plan_ApplyVehicle>();
		for (Item_Waybill waybill : datas) {

			m_Plan_ApplyVehicle vehicle = new m_Plan_ApplyVehicle();

			vehicle.VehicleTypeID = GlobleFields.getHashMap_VehicleType(this)
					.get(waybill.getCatagory()).ID;
			vehicle.i_Count = waybill.getNumber();

			vehicles.add(vehicle);

		}

		M_Apply m_Apply = new M_Apply();

		String use = purpose.getText().toString();

		if (TextUtils.isEmpty(use)) {
			use = "缺省";
		}
		m_Apply.vc_PlanUse = use;

		System.out.println("destination" + destination.getCurrentText());

		m_Apply.dt_ArriveDestinationDateTime = data + "T" + time + ":00";
		m_Apply.ArriveDestinationAddressID = GlobleFields.getHashMap_Address(
				this).get(des).ID;
		m_Apply.dt_ApplyDateTime = TimerUtils.getTime();
		m_Apply.i_IsUseMaterieApply=0;

		Container2 container = new Container2(vehicles);

		ReqApply reqApply = new ReqApply();
		// 设置到达地点
		reqApply.AddressID = GlobleFields.getHashMap_Address(this).get(des).ID;
		reqApply.DateTime = data + "T" + time + ":00";
		reqApply.DepartmentID = 0;// 由服务器去做
		reqApply.ListM_Plan_ApplyVehicle = container;
		reqApply.UserID = GlobleFields.UserID;
		reqApply.M_Apply = m_Apply;
		

		/**
		 * 数据传输
		 */
		FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(reqApply, new NetCallback() {

			@Override
			public void onResult(String entireXml, String inner, boolean Result) {
				System.out.println(entireXml);
			}

			@Override
			public void onResult(String inner, boolean Result) {

			}

			@Override
			public void onResult(String result) {

			}

			@Override
			public String getCmdType() {
				return NetCallback.Flow_Apply;
			}

			@Override
			public void doPrevious() {

			}
		});

	}

	// 获取车的类型的数据，后期可以改为从数据库中查询
	public ArrayList<String> getCatagory() {
		return GlobleFields.getList_VehicleType(this);
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

				msg.what = Apply_VehiclesActivity.SHOW_DATAPICK;
				Apply_VehiclesActivity.this.dateandtimeHandler.sendMessage(msg);
			}
		});

		showTime.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				Message msg = new Message();
				if (showTime.equals((TextView) v)) {
					msg.what = Apply_VehiclesActivity.SHOW_TIMEPICK;
				}
				Apply_VehiclesActivity.this.dateandtimeHandler.sendMessage(msg);
			}
		});
	}

	/**
	 * 设置日期
	 */
	private void setDateTime() {
		final Calendar c = Calendar.getInstance();
		c.add(c.DATE, 1);

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
				.append(((mHour < 10) ? "0" + mHour : mHour)).append(":")
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
			case Apply_VehiclesActivity.SHOW_DATAPICK:
				showDialog(DATE_DIALOG_ID);
				break;
			case Apply_VehiclesActivity.SHOW_TIMEPICK:
				showDialog(TIME_DIALOG_ID);
				break;
			}
		}

	};
	private TextView showDate;

	private TextView showTime;
	private EditText purpose;
	private MyDropdownBox destination;

	// ####################
	// ####################
	// 以上所有的都是处理时间选择控件的操作

}
