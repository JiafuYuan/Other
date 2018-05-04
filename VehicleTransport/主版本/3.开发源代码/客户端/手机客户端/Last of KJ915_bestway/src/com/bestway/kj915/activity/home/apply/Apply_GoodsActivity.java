package com.bestway.kj915.activity.home.apply;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;
import java.util.List;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.app.TimePickerDialog;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
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
import com.bestway.kj915.domain.Item_apply_goods;
import com.bestway.kj915.domain.reflect.m_Address;
import com.bestway.kj915.domain.reflect.m_MaterielType;
import com.bestway.kj915.domain.req.apply.Container1;
import com.bestway.kj915.domain.req.apply.ListM_Plan_ApplyMaterie_Item;
import com.bestway.kj915.domain.req.apply.M_Apply;
import com.bestway.kj915.domain.req.apply.ReqApply;
import com.bestway.kj915.utils.LogUtils;
import com.bestway.kj915.utils.TimerUtils;

public class Apply_GoodsActivity extends BasicTitleActivity {

	private static final int SHOW_DATAPICK = 0;
	private static final int DATE_DIALOG_ID = 1;
	private static final int SHOW_TIMEPICK = 2;
	private static final int TIME_DIALOG_ID = 3;

	private int mYear;
	private int mMonth;
	private int mDay;
	private int mHour;
	private int mMinute;

	private ListView lv;
	private MyAdapter adapter;

	// listview������Դ
	private ArrayList<Item_apply_goods> currentData;
	private ArrayList<String> usedCatagory;

	@Override
	public void doVarious() {
		title_text_view.setText("��������");
		title_text_view.setVisibility(View.VISIBLE);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_apply_goods);

		// ��ʼ��ʱ��ѡ����
		initializeViews();
		initCalendar();

		initData();
		initView();
	}

	private void initData() {

		map_MaterielUnit = GlobleFields.getHashMap_MaterielUnit(this);

		map_Address = GlobleFields.getHashMap_Address(this);

		list_Address = GlobleFields.getList_Address(this);

		list_MaterielType = GlobleFields.getList_MaterielType(this);

		map_MaterielType = GlobleFields.getHashMap_MaterielType(this);

		currentData = new ArrayList<Item_apply_goods>();
		usedCatagory = new ArrayList<String>();

		// ���һ������
		currentData.add(0, new Item_apply_goods(list_MaterielType.get(0), null,
				1));

		usedCatagory.add(list_MaterielType.get(0));
	}

	public void initView() {

		lv = (ListView) findViewById(R.id.lv);

		adapter = new MyAdapter();

		lv.setAdapter(adapter);

		Button add_lv = (Button) findViewById(R.id.add_lv);

		// ������¼��������һ��
		add_lv.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {

				if (lv.getCount() == list_MaterielType.size()) {

					Toast.makeText(Apply_GoodsActivity.this, "�޸����������", 0)
							.show();
					return;
				}

				// ���һ������
				ArrayList<String> mt = getMaterielTypes();

				mt.removeAll(usedCatagory);

				currentData.add(new Item_apply_goods(mt.get(0), null, 1));

				usedCatagory.add(0, mt.get(0));

				adapter.notifyDataSetChanged();
			}

		});

		destination = (MyDropdownBox) findViewById(R.id.destination);

		destination.setData(GlobleFields.getList_Address(this));

		purpose = (EditText) findViewById(R.id.purpose);
	}

	private ArrayList<String> getMaterielTypes() {
		return GlobleFields.getList_MaterielType(this);
	}

	// �ύ��������
	public void submit(View view) {

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

		List<ListM_Plan_ApplyMaterie_Item> m_Plan_ApplyMaterie = new ArrayList<ListM_Plan_ApplyMaterie_Item>();
		System.out.println("currentDatacurrentDatacurrentData..."
				+ currentData.size());
		for (Item_apply_goods item_apply_goods : currentData) {
			ListM_Plan_ApplyMaterie_Item item = new ListM_Plan_ApplyMaterie_Item(
					0, 0, 1, 1, 1, 123, "mm");

			// �����������ID
			item.MaterieTypeID = GlobleFields.getHashMap_MaterielType(this)
					.get(item_apply_goods.getCatagory()).ID;

			if (item_apply_goods.getNumber() < 0) {

				Toast.makeText(this, "������������Ϊ��", 0).show();
				return;
			}
			// �������
			item.n_Count = item_apply_goods.getNumber();

			m_Plan_ApplyMaterie.add(item);

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
		m_Apply.i_IsUseMaterieApply=1;

		Container1 container = new Container1(m_Plan_ApplyMaterie);

		ReqApply reqApply = new ReqApply();
		// ���õ���ص�
		reqApply.AddressID = GlobleFields.getHashMap_Address(this).get(des).ID;
		reqApply.DateTime = data + "T" + time + ":00";
		reqApply.DepartmentID = 0;// �ɷ�����ȥ��
		reqApply.ListM_Plan_ApplyMaterie = container;
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

	class MyAdapter extends BaseAdapter {

		@Override
		public int getCount() {
			LogUtils.careLog("currentData.size()" + currentData.size());
			return currentData.size();
		}

		@Override
		public void notifyDataSetChanged() {
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
			View view = View.inflate(Apply_GoodsActivity.this,
					R.layout.item_goods_apply, null);

			// �������ķ���
			final MyDropdownBox catagory = (MyDropdownBox) view
					.findViewById(R.id.catagory);

			catagory.setHeaderGone();

			final String text_catagory = currentData.get(position)
					.getCatagory();

			String text_unit = map_MaterielUnit.get(text_catagory);

			String text_number = currentData.get(position).getNumber() + "";

			usedCatagory.add(0, text_catagory);

			ArrayList<String> show = GlobleFields
					.getList_MaterielType(Apply_GoodsActivity.this);

			show.removeAll(usedCatagory);

			catagory.setData(show);

			catagory.setContent(text_catagory);

			catagory.setOnContentChangeListener(new ContentChangeListener() {

				@Override
				public void onContentChange(String content) {

					String currentContent = catagory.getCurrentText();

					currentData.get(position).setCatagory(currentContent);

					usedCatagory.add(0, currentContent);

					// ɾ���ַ���һ�µ�����
					List<String> positions = new ArrayList<String>();

					for (int i = 0; i < usedCatagory.size(); i++) {

						if (usedCatagory.get(i).equals(text_catagory)) {
							positions.add(usedCatagory.get(i));
						}

					}

					for (String del : positions) {
						usedCatagory.remove(del);
					}

					adapter.notifyDataSetChanged();

				}

				@Override
				public void sameContent(String content) {

				}
			});

			// �������ĵ�λ
			TextView unit = (TextView) view.findViewById(R.id.unit);

			Button bt_delete = (Button) view.findViewById(R.id.bt_delete);

			bt_delete.setOnClickListener(new OnClickListener() {

				@Override
				public void onClick(View v) {

					String current = currentData.get(position).getCatagory();

					// ɾ���ַ���һ�µ�����
					List<String> positions = new ArrayList<String>();

					for (int i = 0; i < usedCatagory.size(); i++) {

						if (usedCatagory.get(i).equals(current)) {
							positions.add(usedCatagory.get(i));
						}

					}

					for (String del : positions) {
						usedCatagory.remove(del);
					}

					currentData.remove(position);

					adapter.notifyDataSetChanged();

				}
			});
			// ������������
			final EditText number = (EditText) view.findViewById(R.id.number);

			number.addTextChangedListener(new TextWatcher() {

				@Override
				public void onTextChanged(CharSequence s, int start,
						int before, int count) {
				}

				@Override
				public void beforeTextChanged(CharSequence s, int start,
						int count, int after) {
				}

				@Override
				public void afterTextChanged(Editable s) {

					currentData.get(position).setNumber(
							Integer.valueOf(number.getText().toString()));

				}

			});

			// ����չʾ

			if (text_unit != null) {

				unit.setText(text_unit);

				if (!text_number.equals("0")) {

					number.setText(text_number);

				}

			}

			return view;
		}
	}

	// �������ж��Ǵ���ʱ��ѡ��ؼ��Ĳ���
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
	 * ��ʼ���ؼ���UI��ͼ
	 */
	private void initializeViews() {
		showDate = (TextView) findViewById(R.id.showdate);
		showTime = (TextView) findViewById(R.id.showtime);

		showDate.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				Message msg = new Message();

				msg.what = Apply_GoodsActivity.SHOW_DATAPICK;
				Apply_GoodsActivity.this.dateandtimeHandler.sendMessage(msg);
			}
		});

		showTime.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				Message msg = new Message();
				if (showTime.equals((TextView) v)) {
					msg.what = Apply_GoodsActivity.SHOW_TIMEPICK;
				}
				Apply_GoodsActivity.this.dateandtimeHandler.sendMessage(msg);
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
			case Apply_GoodsActivity.SHOW_DATAPICK:
				showDialog(DATE_DIALOG_ID);
				break;
			case Apply_GoodsActivity.SHOW_TIMEPICK:
				showDialog(TIME_DIALOG_ID);
				break;
			}
		}

	};
	private TextView showDate;

	private TextView showTime;

	// ####################
	// ####################
	// �������еĶ��Ǵ���ʱ��ѡ��ؼ��Ĳ���
	private MyDropdownBox destination;
	private EditText purpose;
	private HashMap<String, String> map_MaterielUnit;
	private HashMap<String, m_Address> map_Address;
	private ArrayList<String> list_Address;
	private ArrayList<String> list_MaterielType;
	private HashMap<String, m_MaterielType> map_MaterielType;

}
