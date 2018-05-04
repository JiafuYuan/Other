package com.bestway.kj915.activity.home.supply;

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

	private List<Item_Waybill> data;// 保存有当前运单的信息，实际使用时候建议采用实时获取数据
	private ArrayList<String> usedCatagoryData;// 保存这历史界面已经选择的所有车型
	private ArrayList<String> currentCatagoryData;// 保存这当前界面已经选择的所有车型

	private ListView lv;
	private VehiclesAdapter adapter;

	boolean isdeleting = false;// 作为adapter在刷新时候判断是增加还是删除的依据，用完要复位
	boolean isadding = false;// 作为adapter在添加时候的依据，用完要复位
	private int deletePosition = -1;// 用完要复位,判断删除的位置

	@Override
	public void doVarious() {
		title_text_view.setText("供车");
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

		// @2 队ListView进行初始化，添加头尾
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
						Toast.makeText(SupplyVehicleActivity.this,
								"请竖直或者水平滑动手指！", 0).show();
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
		data = new ArrayList<Item_Waybill>();
	}

	class VehiclesAdapter extends BaseAdapter {

		@Override
		public int getCount() {
			return data.size();
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

			View view = View.inflate(SupplyVehicleActivity.this,
					R.layout.vehicle_supply_item, null);

			// 删除按钮和弹出删除按钮的初始化
			final ImageButton ib_tanchu = (ImageButton) view
					.findViewById(R.id.ib_tanchu);
			final ImageButton ib_delete = (ImageButton) view
					.findViewById(R.id.ib_delete);
			// 数量
			EditText tv_number = (EditText) view.findViewById(R.id.number);
			tv_number.setText(data.get(position).getNumber() + "");
			// 货物类型
			System.out.println(data.get(position).getCatagory());
			MyDropdownBox catagory = (MyDropdownBox) view
					.findViewById(R.id.catagory);
			catagory.setHeaderGone();
			// 设置车型选择框的数据，默认将当前车的类型设置为第一个
			catagory.setData(currentCatagoryData);

			// 设置车的类型，此方法必须在setData后调用
			catagory.setContent(data.get(position).getCatagory());

			// 下拉选择框添加监听
			catagory.setOnContentChangeListener(new ContentChangeListener() {

				@Override
				public void onContentChange(String content) {
					System.out.println("usedCatagoryData////"
							+ usedCatagoryData);
					if (usedCatagoryData.contains(content)) {
						Toast.makeText(SupplyVehicleActivity.this, "该种类车型已经存在",
								1).show();
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
		data.clear();
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
					data.add(new Item_Waybill(catagoryName, number));
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

			data.add(new Item_Waybill(currentCatagoryData.get(0), 1));
			currentCatagoryData.remove(0);// 删除一条历史记录，保证下拉框中不存在

		}
		// @5删除操作
		if (isdeleting) {
			isdeleting = false;
			currentCatagoryData.add(data.get(deletePosition).getCatagory());
			data.remove(deletePosition);
			deletePosition = -1;

		}

	}

	// 提交运单到服务器
	public void commit(View view) {

		// 保存数据
		saveLvdata();

		if (data == null || data.size() == 0) {

			Toast.makeText(this, "请增加车辆", 0).show();

		}

		HashMap<String, m_VehicleType> map_VehicleType = GlobleFields
				.getHashMap_VehicleType(this);

		// 最外层请求封装
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
			plan_GiveVehicle.vc_Memo = "缺省";
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

	// 获取车的类型的数据，后期可以改为从数据库中查询
	public ArrayList<String> getCatagory() {

		return GlobleFields.getList_VehicleType(this);
	}

}
