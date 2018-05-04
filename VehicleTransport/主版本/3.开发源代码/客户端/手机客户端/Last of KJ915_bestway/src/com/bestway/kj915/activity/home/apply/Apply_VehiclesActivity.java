package com.bestway.kj915.activity.home.apply;

/**
 * ��Ȩ���Ͼ���·�Զ���ϵͳ���޹�˾��Ȩ����
 * 
 * ���ߣ�ղѧ��
 * 
 * �汾��1.0
 * 
 * ʱ�䣺2014-8-21 ����5:03:50
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

	private List<Item_Waybill> datas;// �����е�ǰ�˵�����Ϣ��ʵ��ʹ��ʱ�������ʵʱ��ȡ����
	private ArrayList<String> usedCatagoryData;// ��������ʷ�����Ѿ�ѡ������г���
	private ArrayList<String> currentCatagoryData;// �����⵱ǰ�����Ѿ�ѡ������г���

	private ListView lv;
	private VehiclesAdapter adapter;

	boolean isdeleting = false;// ��Ϊadapter��ˢ��ʱ���ж������ӻ���ɾ�������ݣ�����Ҫ��λ
	boolean isadding = false;// ��Ϊadapter�����ʱ������ݣ�����Ҫ��λ
	private int deletePosition = -1;// ����Ҫ��λ,�ж�ɾ����λ��

	@Override
	public void doVarious() {
		title_text_view.setText("���복��");
		title_text_view.setVisibility(View.VISIBLE);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_apply_vehicles);

		// ��ʼ��ʱ��ѡ����
		initializeViews();
		initCalendar();

		initdata();
		initView();

	}

	private void initView() {

		// @1ListView���г�ʼ�������ͷβ
		lv = (ListView) findViewById(R.id.lv);
		View header = View.inflate(this, R.layout.vehicle_supply_header, null);
		View footer = View.inflate(this, R.layout.vehicle_supply_footer, null);
		// I��ͷ����ӵ���¼��������ʱ������ɾ����������
		header.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				cancleDelete();
			}
		});
		// II����β����ӵ���¼��������ʱ������ɾ����������
		footer.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				cancleDelete();
			}
		});
		// III��β��������һ���¼�
		footer.findViewById(R.id.creat).setOnClickListener(
				new OnClickListener() {

					@Override
					public void onClick(View v) {
						isadding = true;

						adapter.notifyDataSetChanged();
					}
				});
		// IV�����ͷβ��
		lv.addHeaderView(header);
		lv.addFooterView(footer);

		// @4��listview���������
		adapter = new VehiclesAdapter();
		lv.setAdapter(adapter);

		// @5��ListView��ӵ����һ����¼����Ӷ�����ɾ�������һ��
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
								"����ֱ����ˮƽ������ָ��", 0).show();
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

	// ȡ������ɾ��������
	public void cancleDelete() {
		for (int i = 0; i < lv.getChildCount(); i++) {
			View v = lv.getChildAt(i).findViewById(R.id.ib_tanchu);
			if (v != null)
				v.setVisibility(View.VISIBLE);
		}
	}

	// ��ʼ������
	private void initdata() {
		usedCatagoryData = new ArrayList<String>();
		// �˵�������Ŀ
		datas = new ArrayList<Item_Waybill>();
	}

	class VehiclesAdapter extends BaseAdapter {

		@Override
		public int getCount() {
			return datas.size();
		}

		/**
		 * ��д���²������Ա��ڸ���֮ǰ����������Ѿ���д�����ݣ���ֹ���ݶ�ʧ
		 */
		@Override
		public void notifyDataSetChanged() {
			// ��������
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

			// ɾ����ť�͵���ɾ����ť�ĳ�ʼ��
			final ImageButton ib_tanchu = (ImageButton) view
					.findViewById(R.id.ib_tanchu);
			final ImageButton ib_delete = (ImageButton) view
					.findViewById(R.id.ib_delete);
			// ����
			EditText tv_number = (EditText) view.findViewById(R.id.number);
			tv_number.setText(datas.get(position).getNumber() + "");
			// ��������
			System.out.println(datas.get(position).getCatagory());
			MyDropdownBox catagory = (MyDropdownBox) view
					.findViewById(R.id.catagory);
			catagory.setHeaderGone();
			// ���ó���ѡ�������ݣ�Ĭ�Ͻ���ǰ������������Ϊ��һ��
			catagory.setData(currentCatagoryData);

			// ���ó������ͣ��˷���������setData�����
			catagory.setContent(datas.get(position).getCatagory());

			// ����ѡ�����Ӽ���
			catagory.setOnContentChangeListener(new ContentChangeListener() {

				@Override
				public void onContentChange(String content) {
					System.out.println("usedCatagoryData////"
							+ usedCatagoryData);
					if (usedCatagoryData.contains(content)) {
						Toast.makeText(Apply_VehiclesActivity.this,
								"�����೵���Ѿ�����", 1).show();
					}
					currentCatagoryData.add(content);
					adapter.notifyDataSetChanged();
				}

				@Override
				public void sameContent(String content) {

				}
			});

			// ����ɾ����ť
			ib_tanchu.setOnClickListener(new OnClickListener() {

				@Override
				public void onClick(View v) {
					ib_tanchu.setVisibility(View.GONE);
				}
			});

			// ɾ����ť����¼�
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

	// ��ˢ��ǰ����ListView��������д�õ�����
	public void saveLvdata() {

		// @1������ݼ�¼�������³�ʼ��
		datas.clear();
		currentCatagoryData = getCatagory();

		// @2��ȡ����Ŀ������һ��д�õ����ݲ����б���
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

		// @3��ʷ��¼�������������ɾ������λ
		usedCatagoryData.clear();

		// @ 4���Ӳ���
		if (isadding) {
			isadding = false;
			if (currentCatagoryData.size() == 0) {
				Toast.makeText(this, "�޸��೵�Ϳ�ѡ", 1).show();
				return;
			}

			datas.add(new Item_Waybill(currentCatagoryData.get(0), 1));
			currentCatagoryData.remove(0);// ɾ��һ����ʷ��¼����֤�������в�����

		}
		// @5ɾ������
		if (isdeleting) {
			isdeleting = false;
			currentCatagoryData.add(datas.get(deletePosition).getCatagory());
			datas.remove(deletePosition);
			deletePosition = -1;

		}

	}

	// �ύ�˵���������
	public void commit(View view) {

		saveLvdata();

		// Ŀ�ĵ�
		String des = destination.getCurrentText();
		// ����
		String data = showDate.getText().toString();
		// ʱ��
		String time = showTime.getText().toString();

		/**
		 * Ŀ�ĵ�λ���ж�
		 */
		if (TextUtils.isEmpty(des)) {
			Toast.makeText(this, "Ŀ�ĵز���Ϊ��", 0).show();
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
			use = "ȱʡ";
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
		// ���õ���ص�
		reqApply.AddressID = GlobleFields.getHashMap_Address(this).get(des).ID;
		reqApply.DateTime = data + "T" + time + ":00";
		reqApply.DepartmentID = 0;// �ɷ�����ȥ��
		reqApply.ListM_Plan_ApplyVehicle = container;
		reqApply.UserID = GlobleFields.UserID;
		reqApply.M_Apply = m_Apply;
		

		/**
		 * ���ݴ���
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

	// ��ȡ�������͵����ݣ����ڿ��Ը�Ϊ�����ݿ��в�ѯ
	public ArrayList<String> getCatagory() {
		return GlobleFields.getList_VehicleType(this);
	}

	// �������ж��Ǵ���ʱ��ѡ��ؼ��Ĳ���
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
	 * ��ʼ���ؼ���UI��ͼ
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
	 * ��������
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
	 * ����������ʾ
	 */
	private void updateDateDisplay() {
		showDate.setText(new StringBuilder().append(mYear).append("-")
				.append((mMonth + 1) < 10 ? "0" + (mMonth + 1) : (mMonth + 1))
				.append("-").append((mDay < 10) ? "0" + mDay : mDay));
	}

	/**
	 * ���ڿؼ����¼�
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
	 * ����ʱ��
	 */
	private void setTimeOfDay() {
		final Calendar c = Calendar.getInstance();
		mHour = c.get(Calendar.HOUR_OF_DAY);
		mMinute = c.get(Calendar.MINUTE);
		updateTimeDisplay();
	}

	/**
	 * ����ʱ����ʾ
	 */
	private void updateTimeDisplay() {
		showTime.setText(new StringBuilder()
				.append(((mHour < 10) ? "0" + mHour : mHour)).append(":")
				.append((mMinute < 10) ? "0" + mMinute : mMinute));
	}

	/**
	 * ʱ��ؼ��¼�
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
	 * �������ں�ʱ��ؼ���Handler
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
	// �������еĶ��Ǵ���ʱ��ѡ��ؼ��Ĳ���

}
