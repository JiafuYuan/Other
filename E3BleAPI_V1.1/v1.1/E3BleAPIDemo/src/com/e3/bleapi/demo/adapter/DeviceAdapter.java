package com.e3.bleapi.demo.adapter;

import java.util.List;

import com.e3.bleapi.demo.E3BleApplication;
import com.e3.bleapi.demo.MainActivity;
import com.e3.bleapi.demo.R;
import com.e3.bleapi.demo.model.BleDevice;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.BaseAdapter;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

public class DeviceAdapter extends BaseAdapter implements OnItemClickListener{
	private List<BleDevice> devices = null;
	private Context context;
	private LayoutInflater inflater;
	private E3BleApplication application;
	
	public DeviceAdapter(Context c,int groupId){
		if(groupId == E3BleApplication.GROUP_All_ID){
			this.devices = E3BleApplication.rootZone.getDevices();
		}else{
			this.devices = E3BleApplication.rootZone.getSubZoneById(groupId).getDevices();
		}
		this.context = c;
		application = (E3BleApplication)context.getApplicationContext();
		this.inflater = LayoutInflater.from(context);
	}

	@Override
	public int getCount() {
		// TODO Auto-generated method stub
		return devices == null ? 0 : devices.size();
	}

	@Override
	public Object getItem(int position) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public long getItemId(int position) {
		// TODO Auto-generated method stub
		return 0;
	}
	
	public void updateDevices(int groupId){
		if(groupId == E3BleApplication.GROUP_All_ID){
			this.devices = E3BleApplication.rootZone.getDevices();
		}else{
			this.devices = E3BleApplication.rootZone.getSubZoneById(groupId).getDevices();
		}
		
		notifyDataSetInvalidated();
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		// TODO Auto-generated method stub
		DeviceViewHolder holder = null;
		if(convertView == null){
			holder = new DeviceViewHolder();
			convertView = (View)inflater.inflate(R.layout.device_item, null);
			holder.blub = (ImageView)convertView.findViewById(R.id.itemBlub);
			holder.meshName = (TextView)convertView.findViewById(R.id.itemName);
			holder.macAddr = (TextView)convertView.findViewById(R.id.itemMac);
			holder.addr = (TextView)convertView.findViewById(R.id.itemAddr);
			holder.onOff = (Switch)convertView.findViewById(R.id.itemOnOff);
			holder.arrow = (ImageView)convertView.findViewById(R.id.itemArrow);
			
			convertView.setTag(holder);
		}else{
			holder = (DeviceViewHolder)convertView.getTag();
		}
		
		final BleDevice device = devices.get(position);
		
		holder.meshName.setText(device.getDesc());
		holder.macAddr.setText(device.getMacAddr());
		holder.addr.setText(device.getAddr()+"");
		
		if(device.getOnoff() == 1){
			holder.blub.setImageResource(R.drawable.bulb);
		}else{
			holder.blub.setImageResource(R.drawable.bulb_off);
		}
		
		holder.blub.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				if(device.getOnoff() == 1){
					device.setOnoff(0);
					application.myApi.sendOnOffCmd(device.getAddr(),false);
				}else{
					device.setOnoff(1);
					application.myApi.sendOnOffCmd(device.getAddr(),true);
				}
			}
		});
		
//		holder.onOff.setOnCheckedChangeListener(new OnCheckedChangeListener() {
//			
//			@Override
//			public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
//				// TODO Auto-generated method stub
//				bleAPI.sendOnOffCmd(isChecked, device.getAddr());
//				
//			}
//		});
		
		return convertView;
	}
	
	class DeviceViewHolder{
		public ImageView 	blub;
		public TextView		meshName;
		public TextView		macAddr;
		public TextView		addr;
		public Switch		onOff;
		public ImageView	arrow;
	}

	@Override
	public void onItemClick(AdapterView<?> parent, View view, int position,
			long id) {
		Toast.makeText(context, "onItemClick   "+devices.get(position).getMacAddr(), Toast.LENGTH_SHORT).show();
	}

}
