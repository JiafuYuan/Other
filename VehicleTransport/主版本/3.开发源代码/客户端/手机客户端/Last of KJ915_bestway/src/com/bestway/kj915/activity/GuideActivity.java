package com.bestway.kj915.activity;

/**
 * �����Ľ���
 */
import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v4.view.ViewPager.OnPageChangeListener;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.LinearLayout.LayoutParams;

import com.bestway.kj915.R;
import com.bestway.kj915.utils.SharePreferenceUtils_config;

public class GuideActivity extends Activity {

	private List<ImageView> data;
	private LinearLayout ll;
	private int[] imageResIDs;
	int previous = 0;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		
		
		SharedPreferences sp = getSharedPreferences("config",
				Context.MODE_PRIVATE);
		// ȷ���Ƿ���ʾ����ҳ��
		boolean showGuide = sp.getBoolean("showGuide", true);

		if (showGuide) {
			System.out.println("showGuide");

			setContentView(R.layout.guide);

			initData();
			initView();

			final ViewPager viewpage = (ViewPager) findViewById(R.id.viewpage);

			viewpage.setAdapter(new ViewPagerAdapter());
			ll.getChildAt(0).setEnabled(true);
			viewpage.setOnPageChangeListener(new OnPageChangeListener() {

				@Override
				public void onPageSelected(int arg0) {
					System.out.println("�任��һ��" + arg0);
					// �ѵ�ǰ��ѡ�е�����Ŀ�Ķ�Ӧ��СԲ������Ϊ���ã�
					// �Լ���һ����ѡ�е�����Ŀ�Ķ�Ӧ��СԲ������Ϊ��������
					ll.getChildAt(arg0).setEnabled(true);
					ll.getChildAt(previous).setEnabled(false);

					// ����ǰ������Ϊѡ����
					previous = viewpage.getCurrentItem();
					if (arg0 == data.size() - 1) {

						GuideActivity.this.findViewById(R.id.checkbox)
								.setVisibility(View.VISIBLE);
						GuideActivity.this.findViewById(R.id.bt).setVisibility(
								View.VISIBLE);
					} else {
						GuideActivity.this.findViewById(R.id.checkbox)
								.setVisibility(View.INVISIBLE);
						GuideActivity.this.findViewById(R.id.bt).setVisibility(
								View.INVISIBLE);
					}

				}

				@Override
				public void onPageScrolled(int arg0, float arg1, int arg2) {

				}

				@Override
				public void onPageScrollStateChanged(int arg0) {

				}
			});

		} else {
			startActivity(new Intent(
					"com.bestway.kj915.activity.SetIpActivity"));
			finish();
		}
	}

	private void initData() {
		data = getImageViewList();
		imageResIDs = new int[] { R.drawable.guide01, R.drawable.guide02,
				R.drawable.guide03 };
	}

	private List<ImageView> getImageViewList() {

		List<ImageView> li = new ArrayList<ImageView>();

		return li;
	}

	private void initView() {
		
		ll = (LinearLayout) findViewById(R.id.ll);

		for (int id : imageResIDs) {
			ImageView imageView = new ImageView(this);

			imageView.setBackgroundResource(id);
			data.add(imageView);

			// �򲼾�����ӱ�����
			View view = new View(this);
			view.setBackgroundResource(R.drawable.ova);
			LayoutParams params = new LayoutParams(20, 20);
			params.rightMargin = 5;

			view.setLayoutParams(params);// �������ʱ��Ҫע�������Բ��ֵ�
			view.setEnabled(false);

			ll.addView(view);
		}

	}

	class ViewPagerAdapter extends PagerAdapter {

		@Override
		public int getCount() {
			return data.size();
		}

		/**
		 * �жϳ�ȥ��view�Ƿ���ڽ�����view ���Ϊtrueֱ�Ӹ���
		 */
		@Override
		public boolean isViewFromObject(View arg0, Object arg1) {
			return arg0 == arg1;
		}

		/**
		 * ����Ԥ���������view����, �����Ҫ���ٵĶ��������λ�ô���������position
		 */
		@Override
		public void destroyItem(ViewGroup container, int position, Object object) {
			container.removeView(data.get(position % data.size()));
		}

		/**
		 * ����һ��view
		 */
		@Override
		public Object instantiateItem(ViewGroup container, int position) {
			container.addView(data.get(position % data.size()));
			return data.get(position % data.size());
		}
	}

	public void nomore(View view) {

		SharePreferenceUtils_config.edit_Boolean(this, "showGuide",
				!((CheckBox) view).isChecked());
	}

	public void next(View view) {
		startActivity(new Intent("com.bestway.kj915.activity.SetIpActivity"));
		finish();
		
	}
}
