package com.e3.bleapi.demo.widget;

import com.e3.bleapi.demo.R;

import android.app.Dialog;
import android.content.Context;
import android.os.Bundle;
import android.widget.TextView;

public class LoadingDialog extends Dialog{
	private TextView loadingMsg;
	private String msgStr;
	
	public LoadingDialog(Context context, boolean cancelable,
			OnCancelListener cancelListener,String msg) {
		super(context, cancelable, cancelListener);
		// TODO Auto-generated constructor stub
		msgStr = msg;
	}

	public LoadingDialog(Context context, int theme,String msg) {
		super(context, theme);
		// TODO Auto-generated constructor stub
		msgStr = msg;
	}

	public LoadingDialog(Context context,String msg) {
		super(context);
		msgStr = msg;
		// TODO Auto-generated constructor stub
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.dialog_loading);  
		loadingMsg = (TextView)this.findViewById(R.id.loading_message);  
		loadingMsg.setText(msgStr);  
	}
	
	public void setMessage(String msg){
		if(loadingMsg == null)
			loadingMsg = (TextView)this.findViewById(R.id.loading_message);  
		loadingMsg.setText(msg);
	}
	
	
	
}
