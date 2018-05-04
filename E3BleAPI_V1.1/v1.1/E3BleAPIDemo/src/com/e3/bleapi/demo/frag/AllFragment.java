package com.e3.bleapi.demo.frag;

import com.e3.bleapi.demo.E3BleApplication;
import com.e3.bleapi.demo.MainActivity;
import com.e3.bleapi.demo.R;
import com.e3.bleapi.demo.adapter.DeviceAdapter;

import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

public class AllFragment extends E3Fragment{
	private int groupId = 0;
	private ListView deviceList;
	
	private MainActivity activity;
	private E3BleApplication application;
	private LayoutInflater mInflater;
	
	private DeviceAdapter adapter ;
	
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) {
		activity = (MainActivity)getActivity();
		application = (E3BleApplication)activity.getApplication();
		
		groupId = E3BleApplication.GROUP_All_ID;
		
		mInflater = inflater;
		View view = mInflater.inflate(R.layout.fragment, null);
		
		deviceList = (ListView)view.findViewById(R.id.listview);
		
		adapter = new DeviceAdapter(activity, groupId);
		deviceList.setAdapter(adapter);
		
//		deviceList.setOnItemClickListener(adapter);
		
		return view;
	}

	@Override
	public void updateDataStatus() {
//		adapter.notifyDataSetChanged();
		adapter.updateDevices(groupId);
		super.updateDataStatus();
	}
	
	
	
}
