E3Api使用：

E3BleCallbacks是用户需要实现的回调接口：
	onConnected 蓝牙连接成功并获取Service后回调
	onConnectedFailed 蓝牙连接失败时回调（蓝牙协议栈返回异常状态时也回调该方法）
	onAddToMeshSucceeded 设备入网成功时回调
	onAddToMeshFailed 设备入网失败时回调
	onConnectionLost 连接断开时回调
	onCommandExecuted  命令执行失败时回调（目前只有在蓝牙未连接时发送命令会回调）
	onBleDeviceStatusChanged 设备状态发生改变时回调（开关状态切换，返回有延迟）
	onNewBleDeviceFound 发现新的设备时回调
	onInMeshBleDeviceFound 发现已入网的设备时回调（已入网的设备名称不是E3Control Mesh）
	onBleDeviceTimeRecived 发送获取时间后返回时间的回调函数
	onBleReady 参数未设置完成时回调
	
E3API 用户需要调用的接口
	sendOnOffCmd  开关命令
	sendAdjustCmd 调节命令 （调节亮度、色温、RGB、RGB+白光、白光 命令）
	sendGroupingCmd 添加组
	sendRemoveAllGroupCmd 删除所有组
	sendRemoveGroupById  删除指定组
	sendRemoveDeviceCmd 删除设备
	sendDelayCmd 延时开关灯命令
	sendDeviceAddrCmd 设置单灯地址
	sendNightCmd 小夜灯
	sendGradientCmd RGB渐变
	sendAddProfileCmd 添加设置场景
	sendUpdateProfileCmd 修改场景
	sendRemoveProfileByIdCmd  删除场景
	sendApplyProfileCmd 调用场景
	sendSetTimeCmd 设置蓝牙设备的日期时间（目标地址为所有入网的设备即0xFFFF）
	sendGetTimeCmd() 获取设备时间（对直连的设备进行操作），时间返回在notify中
	
	startScanning 开始扫描
	stopScanning 停止扫描
	connect 发送连接命令
	setMeshPassword 设定入网密码
	addToMesh 设备入网命令
	disconnect 断开蓝牙连接
	isConnected 判断蓝牙是否连接
	
	
	init 初始化API  ApplicationContext 和   E3BleCallbacks
	setCallback  设定API的回调实现E3BleCallbacks

	
使用步骤：
	1.使用E3BleAPIImpl 的getInstance获取E3BleApi实现
	2.使用init方法初始化E3BleApi
	3.设置入网密码（必须）
	4.扫描设备（startScanning）
	5.连接设备（connect）
	6.设备入网（addToMesh）
	7.分组 （sendGroupingCmd）
	8.控制...

Demo E3BleAPIDemo
