E3Apiʹ�ã�

E3BleCallbacks���û���Ҫʵ�ֵĻص��ӿڣ�
	onConnected �������ӳɹ�����ȡService��ص�
	onConnectedFailed ��������ʧ��ʱ�ص�������Э��ջ�����쳣״̬ʱҲ�ص��÷�����
	onAddToMeshSucceeded �豸�����ɹ�ʱ�ص�
	onAddToMeshFailed �豸����ʧ��ʱ�ص�
	onConnectionLost ���ӶϿ�ʱ�ص�
	onCommandExecuted  ����ִ��ʧ��ʱ�ص���Ŀǰֻ��������δ����ʱ���������ص���
	onBleDeviceStatusChanged �豸״̬�����ı�ʱ�ص�������״̬�л����������ӳ٣�
	onNewBleDeviceFound �����µ��豸ʱ�ص�
	onInMeshBleDeviceFound �������������豸ʱ�ص������������豸���Ʋ���E3Control Mesh��
	onBleDeviceTimeRecived ���ͻ�ȡʱ��󷵻�ʱ��Ļص�����
	onBleReady ����δ�������ʱ�ص�
	
E3API �û���Ҫ���õĽӿ�
	sendOnOffCmd  ��������
	sendAdjustCmd �������� ���������ȡ�ɫ�¡�RGB��RGB+�׹⡢�׹� ���
	sendGroupingCmd �����
	sendRemoveAllGroupCmd ɾ��������
	sendRemoveGroupById  ɾ��ָ����
	sendRemoveDeviceCmd ɾ���豸
	sendDelayCmd ��ʱ���ص�����
	sendDeviceAddrCmd ���õ��Ƶ�ַ
	sendNightCmd Сҹ��
	sendGradientCmd RGB����
	sendAddProfileCmd ������ó���
	sendUpdateProfileCmd �޸ĳ���
	sendRemoveProfileByIdCmd  ɾ������
	sendApplyProfileCmd ���ó���
	sendSetTimeCmd ���������豸������ʱ�䣨Ŀ���ַΪ�����������豸��0xFFFF��
	sendGetTimeCmd() ��ȡ�豸ʱ�䣨��ֱ�����豸���в�������ʱ�䷵����notify��
	
	startScanning ��ʼɨ��
	stopScanning ֹͣɨ��
	connect ������������
	setMeshPassword �趨��������
	addToMesh �豸��������
	disconnect �Ͽ���������
	isConnected �ж������Ƿ�����
	
	
	init ��ʼ��API  ApplicationContext ��   E3BleCallbacks
	setCallback  �趨API�Ļص�ʵ��E3BleCallbacks

	
ʹ�ò��裺
	1.ʹ��E3BleAPIImpl ��getInstance��ȡE3BleApiʵ��
	2.ʹ��init������ʼ��E3BleApi
	3.�����������루���룩
	4.ɨ���豸��startScanning��
	5.�����豸��connect��
	6.�豸������addToMesh��
	7.���� ��sendGroupingCmd��
	8.����...

Demo E3BleAPIDemo
