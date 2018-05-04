package com.bestway.kj915.activity;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ImageView;
import android.widget.TextView;

import com.bestway.kj915.R;
import com.bestway.kj915.application.SysApplication;

/**
 * 带有标题的都activity都可以继承
 * 
 * @author gaga
 * 
 */
public abstract class BasicTitleActivity extends Activity {

	public View common_title;// 共同的标题
	public ImageView title_image_back;
	public TextView title_text_view;
	public ImageView title_image_flush;

	@Override
	protected void onStart() {
		super.onStart();
		doCommon();
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		
		SysApplication.getInstance().addActivity(this);
		
	}
	/**
	 * 都要执行的共同方法
	 */
	public void doCommon() {

		common_title = findViewById(R.id.common_title);

		title_text_view = (TextView) common_title
				.findViewById(R.id.title_text_view);
		title_image_flush = (ImageView) common_title
				.findViewById(R.id.title_image_flush);

		title_image_back = (ImageView) common_title
				.findViewById(R.id.title_image_back);

		title_image_back.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				finish();
			}
		});

		doVarious();

	}

	/**
	 * 我们可以根据不同需要对标题进行操作
	 */
	public abstract void doVarious();

	@Override
	public void onBackPressed() {
		super.onBackPressed();
		finish();
	}

}
