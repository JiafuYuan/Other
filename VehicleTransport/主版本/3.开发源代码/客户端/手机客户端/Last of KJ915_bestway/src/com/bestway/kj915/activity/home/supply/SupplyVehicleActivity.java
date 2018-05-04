package com.bestway.kj915.activity.home.supply;

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
import java.util.HashMap;
import java.util.List;

import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnTouchListener;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.Toast;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.R;
import com.bestway.kj915.activity.BasicTitleActivity;
import com.bestway.kj915.afinalnet.FinalNClient;
import com.bestway.kj915.afinalnet.NetCallback;
import com.bestway.kj915.custom.MyDropdownBox;
import com.bestway.kj915.custom.MyDropdownBox.ContentChangeListener;
import com.bestway.kj915.domain.Item_Waybill;
import com.bestway.kj915.domain.reflect.m_VehicleType;
import com.bestway.kj915.domain.req.supply.ReqSupplyCar;
import com.bestway.kj915.domain.req.supply.SupplyContainer;
import com.bestway.kj915.domain.req.supply.m_Plan_GiveVehicle;
import com.bestway.kj915.utils.TimerUtils;

public class SupplyVehicleActivity extends BasicTitleActivity {

	private List<Item_Waybill> data;// �����е�ǰ�˵�����Ϣ��ʵ��ʹ��ʱ�������ʵʱ��ȡ����
	private ArrayList<String> usedCatagoryData;// ��������ʷ�����Ѿ�ѡ������г���
	private ArrayList<String> currentCatagoryData;// �����⵱ǰ�����Ѿ�ѡ������г���

	private ListView lv;
	private VehiclesAdapter adapter;

	boolean isdeleting = false;// ��Ϊadapter��ˢ��ʱ���ж������ӻ���ɾ�������ݣ�����Ҫ��λ
	boolean isadding = false;// ��Ϊadapter�����ʱ������ݣ�����Ҫ��λ
	private int deletePosition = -1;// ����Ҫ��λ,�ж�ɾ����λ��

	@Override
	public void doVarious() {
		title_text_view.setText("����");
		title_text_view.setVisibility(View.VISIBLE);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_supply);

		initdata();
		initView();

	}

	private void initView() {

		// @2 ��ListView���г�ʼ�������ͷβ
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
						Toast.makeText(SupplyVehicleActivity.this,
								"����ֱ����ˮƽ������ָ��", 0).show();
					} else {

						if ((currentY - preY) > 78) {
							isadding = true;
							adapter.notifyDataSetChanged();
							break;

						}
						if ((currentY - preY) < -78) {
							if (data != null && data.size() != 0) {
								isdeleting = true;
								deletePosition = data.size() - 1;
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
		data = new ArrayList<Item_Waybill>();
	}

	class VehiclesAdapter extends BaseAdapter {

		@Override
		public int getCount() {
			return data.size();
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

			View view = View.inflate(SupplyVehicleActivity.this,
					R.layout.vehicle_supply_item, null);

			// ɾ����ť�͵���ɾ����ť�ĳ�ʼ��
			final ImageButton ib_tanchu = (ImageButton) view
					.findViewById(R.id.ib_tanchu);
			final ImageButton ib_delete = (ImageButton) view
					.findViewById(R.id.ib_delete);
			// ����
			EditText tv_number = (EditText) view.findViewById(R.id.number);
			tv_number.setText(data.get(position).getNumber() + "");
			// ��������
			System.out.println(data.get(position).getCatagory());
			MyDropdownBox catagory = (MyDropdownBox) view
					.findViewById(R.id.catagory);
			catagory.setHeaderGone();
			// ���ó���ѡ�������ݣ�Ĭ�Ͻ���ǰ������������Ϊ��һ��
			catagory.setData(currentCatagoryData);

			// ���ó������ͣ��˷���������setData�����
			catagory.setContent(data.get(position).getCatagory());

			// ����ѡ�����Ӽ���
			catagory.setOnContentChangeListener(new ContentChangeListener() {

				@Override
				public void onContentChange(String content) {
					System.out.println("usedCatagoryData////"
							+ usedCatagoryData);
					if (usedCatagoryData.contains(content)) {
						Toast.makeText(SupplyVehicleActivity.this, "�����೵���Ѿ�����",
								1).show();
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
		data.clear();
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
					data.add(new Item_Waybill(catagoryName, number));
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

			data.add(new Item_Waybill(currentCatagoryData.get(0), 1));
			currentCatagoryData.remove(0);// ɾ��һ����ʷ��¼����֤�������в�����

		}
		// @5ɾ������
		if (isdeleting) {
			isdeleting = false;
			currentCatagoryData.add(data.get(deletePosition).getCatagory());
			data.remove(deletePosition);
			deletePosition = -1;

		}

	}

	// �ύ�˵���������
	public void commit(View view) {

		// ��������
		saveLvdata();

		if (data == null || data.size() == 0) {

			Toast.makeText(this, "�����ӳ���", 0).show();

		}

		HashMap<String, m_VehicleType> map_VehicleType = GlobleFields
				.getHashMap_VehicleType(this);

		// ����������װ
		ReqSupplyCar supplyCar = new ReqSupplyCar();

		supplyCar.DateTime = TimerUtils.getTime();

		supplyCar.AddressID = 1;

		supplyCar.DepartmentID = 2;

		supplyCar.PlanID = 176;

		supplyCar.UserID = GlobleFields.UserID;

		SupplyContainer container = new SupplyContainer();

		ArrayList<m_Plan_GiveVehicle> li = new ArrayList<m_Plan_GiveVehicle>();

		for (Item_Waybill item_Waybill : data) {

			m_Plan_GiveVehicle plan_GiveVehicle = new m_Plan_GiveVehicle();
			plan_GiveVehicle.PlanID = 176;
			plan_GiveVehicle.vc_Memo = "ȱʡ";
			plan_GiveVehicle.VehicleTypeID = map_VehicleType.get(item_Waybill
					.getCatagory()).ID;
			plan_GiveVehicle.i_Count = item_Waybill.getNumber();

			li.add(plan_GiveVehicle);

		}

		container.list = li;
		supplyCar.ListM_Plan_GiveVehicle = container;

		final FinalNClient client = FinalNClient.getInstance();

		client.sendMessage(supplyCar, new NetCallback() {

			@Override
			public String getCmdType() {
				return NetCallback.Flow_Give;
			}

			@Override
			public void doPrevious() {

			}

			@Override
			public void onResult(String result) {

			}

			@Override
			public void onResult(String inner, boolean Result) {

			}

			@Override
			public void onResult(String entireXml, String inner, boolean Result) {

				System.out.println(entireXml);

			}

		});

	}

	// ��ȡ�������͵����ݣ����ڿ��Ը�Ϊ�����ݿ��в�ѯ
	public ArrayList<String> getCatagory() {

		return GlobleFields.getList_VehicleType(this);
	}

}
