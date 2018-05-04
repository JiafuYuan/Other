package com.bestway.kj915.custom;

import java.util.ArrayList;

import android.content.Context;
import android.graphics.drawable.BitmapDrawable;
import android.text.TextUtils;
import android.util.AttributeSet;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.BaseAdapter;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.PopupWindow;
import android.widget.PopupWindow.OnDismissListener;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.bestway.kj915.R;
import com.bestway.kj915.utils.DIP_PIX_Utils;

public class BigDropdownBox extends RelativeLayout implements OnClickListener,
		OnItemClickListener {
	private Context context;
	private ListView lv;
	private PopupWindow pw;
	private List_Item_Adapter mAdapter;
	private ArrayList<String> numberList;
	private TextView tv_content;
	private ImageButton ib_arrow;
	private TextView tv_name;
	private String title_name;
	private String size;
	public ContentChangeListener contentChangeListener;
	private View header;

	public BigDropdownBox(Context context) {
		super(context);
		this.context = context;
		initView(context);
	}

	public BigDropdownBox(Context context, AttributeSet attrs) {
		super(context, attrs);
		this.context = context;
		initView(context);

		title_name = attrs.getAttributeValue(
				"http://schemas.android.com/apk/res/com.bestway.kj915", "bigName");
		size = attrs
				.getAttributeValue(
						"http://schemas.android.com/apk/res/com.bestway.kj915",
						"bigWidth");
		if (title_name != null) {
			setName(title_name);

		}
		if (title_name == null) {
			System.out.println("��������gone");
			tv_name.setVisibility(View.GONE);
		}

	}

	public BigDropdownBox(Context context, AttributeSet attrs, int defStyle) {
		super(context, attrs, defStyle);
		this.context = context;
		initView(context);
	}

	private void initView(Context context) {
		View.inflate(context, R.layout.bigdropdownbox, this);
		tv_content = (TextView) findViewById(R.id.tv_content);
		ib_arrow = (ImageButton) findViewById(R.id.ib_arrow);
		tv_name = (TextView) findViewById(R.id.tv_name);

		tv_content.setOnClickListener(this);
		ib_arrow.setOnClickListener(this);
		
		//ͷ����
		header = View.inflate(context,
				R.layout.bigdropdownbox_list_header, null);
	}

	/**
	 * ��ʾ�����б�Ի���
	 */
	private void showNumberListDialog() {
		initListView();
		if (pw == null) {
			pw = new PopupWindow(lv, tv_content.getWidth(), 300);
			pw.setFocusable(true); // ����ǰ�Ĵ�����Ի�ý���
			pw.setOutsideTouchable(true);// �����ⲿ���Ա����
			pw.setBackgroundDrawable(new BitmapDrawable());
			pw.setOnDismissListener(new OnDismissListener() {

				@Override
				public void onDismiss() {
					ib_arrow.setBackgroundResource(R.drawable.down_arrow);
				}
			});
		}
		pw.showAsDropDown(tv_content, 0, 0);// 2, -5
		// pw.showAtLocation(tv_content, gravity, x, y)

	}

	/**
	 * ��ʼ��ListView
	 */
	private void initListView() {
		System.out.println(context);
		lv = new ListView(context);

		lv.setBackgroundResource(R.drawable.listview_background);
		lv.setDivider(null); // ���÷ָ���ͼƬΪnull
		lv.setDividerHeight(0); // ���÷ָ��ߵĸ߶�Ϊ0
		lv.setOnItemClickListener(this);

		
		lv.addHeaderView(header);
		header.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				tv_content.setText("");
			}
		});

		mAdapter = new List_Item_Adapter();
		
		lv.setAdapter(mAdapter);
	}

	/**
	 * �˷������뱻����
	 * 
	 * @param numberList
	 */
	public void setData(ArrayList<String> numberList) {
		
		this.numberList = numberList;

		// if (numberList != null && numberList.size() > 0)
		// setContent(numberList.get(0));
		// setContent("--��ѡ��--");
	}

	// ������setData֮�����
	public void setContent(String content) {
		if (!TextUtils.equals(content, getCurrentText())) {
			tv_content.setText(content);
			if (contentChangeListener != null) {
				contentChangeListener.onContentChange(content);
			}

		} else {
			if (contentChangeListener != null) {
				contentChangeListener.sameContent(content);
			}
		}

	}

	/**
	 * ��ȡ��ǰ���ݵķ���
	 */
	public String getCurrentText() {
		return tv_content.getText().toString();
	}

	/**
	 * ��������
	 * 
	 * @param name
	 */
	public void setName(String name) {
		tv_name.setText(name + " :");
	}

	@Override
	public void onClick(View v) {
		ib_arrow.setBackgroundResource(R.drawable.down_arrow_clicked);
		showNumberListDialog();
	}

	@Override
	public void onItemClick(AdapterView<?> parent, View view, int position,
			long id) {
		System.out.println("onItemClick ����ִ����");
		
		String number = numberList.get(position-1);
		setContent(number);

		pw.dismiss();

	}

	class List_Item_Adapter extends BaseAdapter {

		@Override
		public int getCount() {
			if (numberList != null)
				return numberList.size();
			else {
				return 0;
			}
		}

		@Override
		public View getView(final int position, View convertView,
				ViewGroup parent) {
			if (convertView != null) {
				View view = convertView;
			}
			View view = View.inflate(context, R.layout.bigdropdownbox_list_item,
					null);
			TextView tv_list_item = (TextView) view
					.findViewById(R.id.tv_list_item);
			tv_list_item.setText(numberList.get(position));
			return view;
		}

		@Override
		public Object getItem(int position) {
			return null;
		}

		@Override
		public long getItemId(int position) {
			return 0;
		}
	}

	
	@Override
	protected void onLayout(boolean changed, int l, int t, int r, int b) {
		super.onLayout(changed, l, t, r, b);

		if (!TextUtils.isEmpty(size)) {
			int totalLength = DIP_PIX_Utils.dip2px(context, 270);
			System.out.println("totalLength///" + totalLength + "size"
					+ Integer.valueOf(size));
			this.setLayoutParams(new LinearLayout.LayoutParams(totalLength
					* Integer.valueOf(size) / 10,
					LinearLayout.LayoutParams.WRAP_CONTENT));
		}
	}

	// ���ü���
	public void setOnContentChangeListener(
			ContentChangeListener contentChangeListener) {
		System.out.println("catagory���ݸı�");
		this.contentChangeListener = contentChangeListener;

	}

	// ���ݸı�ļ���
	public interface ContentChangeListener {

		public void onContentChange(String content);

		public void sameContent(String content);

	}

	public void notifyDataSetChanged() {
		if (mAdapter != null)
			mAdapter.notifyDataSetChanged();
	}
	
	/**
	 * ����ͷ����ʧ
	 */
	public void setHeaderGone(){
		header.setVisibility(View.GONE);
	}
}
