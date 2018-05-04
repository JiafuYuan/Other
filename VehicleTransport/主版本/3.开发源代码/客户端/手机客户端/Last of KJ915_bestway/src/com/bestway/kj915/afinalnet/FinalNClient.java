package com.bestway.kj915.afinalnet;

/**
 * ��Ȩ���Ͼ���·�Զ���ϵͳ�������ι�˾��Ȩ����
 * 
 * ���ߣ�ղѧ��
 * 
 * �汾��1.0
 * 
 * ʱ�䣺2014-9-1 ����11:31:31
 */
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.net.InetSocketAddress;
import java.nio.ByteBuffer;
import java.nio.channels.SelectionKey;
import java.nio.channels.Selector;
import java.nio.channels.SocketChannel;
import java.nio.charset.Charset;
import java.util.HashMap;

import android.os.Handler;
import android.os.Message;
import android.os.SystemClock;

import com.bestway.kj915.GlobleFields;
import com.bestway.kj915.domain.req.BasicReqInner;
import com.bestway.kj915.utils.LogUtils;

public class FinalNClient {

	/**
	 * ͨ�ŵĶ˿ںź�ip��ַ
	 */
	public static String IP = GlobleFields.IP;//36";//67";//61";//58";//

    
	public static int PORT =12345;//9999;//

	/**
	 * ���ڴ�������Ӧ������Ϣͷ��������Ϣ��
	 */
	boolean islength = true;  
	int currentSize = 4;   
	

	/**
	 * �����жϱ�ʶͨ��ͨ���Ƿ��ʼ���ɹ�
	 */
	private boolean hasInit = false;  

	/**
	 * ���صĶ˿ڣ�ͨ��ͨ����ʼ������ܱ���ʼ���������ڷ������������ʱ���滻
	 */
	private int myPort;

	/**
	 * ���е������쳣��Ӧ���ַ���
	 */
	public static final String CONNET_FAILED = "���������Ӳ���";
	public static final String CONNET_INTERUPT = "������ʧȥ����";
	public static final String INIT_EXCEPTION = "�ŵ���ʼ��ʧ��";

	/**
	 * ���е���Ϣ��ʶ����
	 */
	private static final int MSG_REICEIVE_SUCCEED = 1;// ����ͽ��ܳɹ�
	private static final int MSG_SEND_NULL_EXCEPTION = 2;// ����ʧ��
	private static final int MSG_CONNECT_FAILD = 3;// ���ӷ������쳣
	private static final int MSG_INIT_EXCEPTION = 4;// ��ʼ��ͨ��ͨ��ʧ��

	/**
	 * ���崦�������ַ���
	 */
	private Charset charset = Charset.forName("gb2312");
    
	/**
	 * ͨ�ŵĹؼ������ھ�̬������г�ʼ��
	 */
	private SocketChannel socketChannel = null;
	private Selector selector = null;

	/**
	 * �������еĵ���������Ļص��࣬�������ݸ�����key������Ӧ�ص�
	 */
	private HashMap<String, NetCallback> callbacks = new HashMap<String, NetCallback>();

	/**
	 * �첽�������̸߳��½���
	 */
	public Handler myHandler = new Handler() {

		@Override
		public void handleMessage(Message msg) {

			LogUtils.careLog(callbacks.size());

			switch (msg.what) {

			case MSG_REICEIVE_SUCCEED:// ����ɹ�
				CallBackInfo backInfo = (CallBackInfo) msg.obj;
				String cmdType = backInfo.getCmdType();
				String result = backInfo.getTotalResult();
				// ��ȡ��ɾ����Ŀ��Ȼ��ص�����
				NetCallback callback = callbacks.remove(cmdType);
				if (callback != null) {
					// �ص����������1
					callback.onResult(result);
					// �ص����������2
					callback.onResult(backInfo.getInnerResult(),
							backInfo.isHasSuceed());
					//�ص����������3
					callback.onResult(result,backInfo.getInnerResult(),
							backInfo.isHasSuceed());
					callbacks.remove(callback);
				}
				break;

			case MSG_SEND_NULL_EXCEPTION:// �����쳣

				for (NetCallback callback2 : callbacks.values()) {
					callback2.onResult(CONNET_FAILED);
				}
				break;

			case MSG_CONNECT_FAILD:// �����쳣
				for (NetCallback callback2 : callbacks.values())
					callback2.onResult(CONNET_INTERUPT);
				break;

			case MSG_INIT_EXCEPTION:// ͨ��ͨ����ʼ��ʧ��
				for (NetCallback callback2 : callbacks.values())
					callback2.onResult(INIT_EXCEPTION);
				break;

			}
		}

	};

	/**
	 * �������ģʽ
	 */
	private static FinalNClient client = new FinalNClient();

	/**
	 * ��̬�������ִ�г�ʼ��ͨ��ͨ���Ĳ���
	 */
	static {

		client.init();

	}

	/**
	 * ���췽��˽��
	 */
	private FinalNClient() {

	}

	/**
	 * ��̬������ȡ��ʵ����Ψһ����
	 * 
	 * @return
	 */
	public static FinalNClient getInstance() {
		return client;
	}

	/**
	 * ע�⣺�˷���ֻ���������жϺ󱻵��á������̣߳���ʼ��ͨ���ŵ�,��ÿ�ζϿ����Ӻ��Ҫ���³�ʼ����
	 */
	public void init() {

		// ��������
		hasInit = false;
		LogUtils.careLog("��ʼ��FinalNClient��������");
		new Thread() {

			public void run() {
				try {

					selector = Selector.open();
					InetSocketAddress addrss = new InetSocketAddress(IP, PORT);

					// ����open�ľ�̬������������ָ����������SocketChannel
					socketChannel = SocketChannel.open(addrss);

					hasInit = true;
					// ���ø�sc�ѷ������ķ�ʽ����
					socketChannel.configureBlocking(false);

					// ��SocketChannel����ע�ᵽָ����Selector
					socketChannel.register(selector, SelectionKey.OP_READ);

					// ��ȡ��ǰ��ip��ַ
					myPort = socketChannel.socket().getLocalPort();

					// ������ȡ���������ݶ�
					readMessage();
				} catch (Exception e) {
					e.printStackTrace();
					myHandler.sendEmptyMessage(MSG_INIT_EXCEPTION);
				}

			};
		}.start();

	}

	/**
	 * 
	 * ���飺ͨ�����ַ�������ķ�ʽ���Ƚϼ򵥣�ʵ�ʷ��������Դ�Ϊ��
	 * 
	 * ���صķ���
	 * 
	 * @param reqInner
	 * @param callback
	 */
	public void sendMessage(BasicReqInner reqInner, NetCallback callback) {

		String str = CommonXmlSerialize.serializeCommonReq(reqInner);

		sendMessage(str, callback);
	}

	/**
	 * 
	 * ������������в������ڴ��߳���ִ��
	 * 
	 * @param str
	 */
	public void sendMessage(final String str, NetCallback callback) {

		LogUtils.careLog("���Ͱ�����" + str);
		if (callback != null) {

			// ���̵߳��õĳ�ʼ���Ի��򣬽��������ƵĲ���
			callback.doPrevious();
			// �����󴢴��ڼ����У����������Ӧ��ص�
			callbacks.put(callback.getCmdType(), callback);

		}

		// �������Ϊnull����û��Ҫ��������
		if (str == null) {
			return;
		}

		// �����µ��̷߳�������
		new Thread() {
			public void run() {
				// ���ͨ��ͨ��û��ȫ��ʼ���ͻ�һֱ�ȵ�
				while (!hasInit) {
					SystemClock.sleep(100);
				}

				try {
					// �滻����ʵ�Ķ˿�
					String finalStr = str.replaceAll("####", "" + myPort);

					// ���
					ByteBuffer buffer = ByteBuffer.allocate(102400);
					buffer.put(Int_Byte.Int2BytesLH(finalStr.getBytes().length));
					buffer.put(ByteBuffer.wrap(new String(finalStr).getBytes()));
					buffer.flip();

					// socket����Ϊnull��������ʧ����Ϣ
					if (socketChannel == null) {
						myHandler.sendEmptyMessage(MSG_SEND_NULL_EXCEPTION);
						return;
					}

					// ����
					socketChannel.write(buffer);

				} catch (IOException e) {

					myHandler.sendEmptyMessage(MSG_CONNECT_FAILD);
					e.printStackTrace();
				}
			};
		}.start();

	}

	/**
	 * �첽��ѯ��ȡ���ݵ��߳�
	 */

	private int totalSize;

	byte[] arr;

	public void readMessage() {

		ByteArrayOutputStream baos = new ByteArrayOutputStream();

		try {

			while (selector.select() > 0) {

				// ����ÿ���п��ܵ�IO������Channel�����е�SelectionKey
				for (SelectionKey sk : selector.selectedKeys()) {

					// ɾ�����ڴ����SelectionKey
					selector.selectedKeys().remove(sk);

					// �����SelectionKey��Ӧ��Channel���пɶ�������
					if (sk.isReadable()) {

						// ʹ��NIO��ȡChannel�е�����
						LogUtils.careLog("����ɶ�״̬");
						SocketChannel sc = (SocketChannel) sk.channel();
						String content = "";

						System.out.println(currentSize + "....?currentSize");

						ByteBuffer bff = ByteBuffer.allocate(currentSize);

						// ������Ϣ
						while (sc.read(bff) > 0) {

							sc.read(bff);

							bff.flip();
							content += charset.decode(bff);

							if (!islength) {
								baos.write(bff.array(), 0, bff.limit());
							}
						}

						/**
						 * ���ǻ�ȡ��Ϣͷ����
						 */
						if (islength) {

							/**
							 * ��ԭ
							 */
							islength = false;

							// ��ȡ��Ϣ�ĳ���
							totalSize = Int_Byte.toInt(bff.array());

							currentSize = totalSize;

							System.out.println("�ܵĳ��ȡ���" + totalSize);

						} else {

							int preLength = baos.toByteArray().length;

							if (preLength < totalSize) {// û������

								currentSize = totalSize - preLength;

							} else {

								String block = baos.toString("gb2312");

								// ȫ���������³�ʼ��
								baos = new ByteArrayOutputStream();

								currentSize = 4;

								/**
								 * ��ȡ��Ӧ����Ϣ����������Ϣ
								 */
								String[] arrs = CmdTypeParser.paser(block)
										.split("##");
								if (arrs == null || arrs.length < 0) {
									break;
								}

								String cmdType = arrs[0];
								String re = arrs[1];
								String inner = arrs[2];
								Message message = new Message();

								/**
								 * ��Ϣ��װ�ڻص���javabean������
								 */
								CallBackInfo backInfo = new CallBackInfo();
								backInfo.setCmdType(cmdType);
								backInfo.setTotalResult(content);

								// �����ڲ��Ľ��
								if (inner != null) {
									backInfo.setInnerResult(inner);
								}

								// �����Ƿ�����ɹ�
								if (re.equals("true")) {
									backInfo.setHasSuceed(true);
								} else {
									backInfo.setHasSuceed(false);
								}

								/**
								 * ��Ϣ����
								 */
								message.what = MSG_REICEIVE_SUCCEED;
								message.obj = backInfo;

								// ����handler��Ϣ
								myHandler.sendMessage(message);

								/**
								 * ��ԭ
								 */
								islength = true;

								totalSize = 0;

							}

						}

						// ��sk��Ӧ��Channel���ó�׼����һ�ζ�ȡ
						sk.interestOps(SelectionKey.OP_READ);

					}

				}
			}

		} catch (IOException io) {
			io.printStackTrace();
		}
	}

	/**
	 * �����첽�з�װ����Ϣ��������Ӧ���ͣ��Ӷ��������߳�ִ�й�����߼�������������߽������Ӧ�ٶ�
	 * 
	 * @author gaga
	 * 
	 */
	public class CallBackInfo {
		/**
		 * ���������
		 */
		private String cmdType;
		/**
		 * ����cmdTypeParser�������ַ���
		 */
		private String innerResult;

		/**
		 * �ܵ��ַ���
		 */
		private String totalResult;

		/**
		 * ��Ӧ�Ľ��result
		 */
		private boolean hasSuceed;

		public String getCmdType() {
			return cmdType;
		}

		public void setCmdType(String cmdType) {
			this.cmdType = cmdType;
		}

		public String getInnerResult() {
			return innerResult;
		}

		public void setInnerResult(String innerResult) {
			this.innerResult = innerResult;
		}

		public String getTotalResult() {
			return totalResult;
		}

		public void setTotalResult(String totalResult) {
			this.totalResult = totalResult;
		}

		public boolean isHasSuceed() {
			return hasSuceed;
		}

		public void setHasSuceed(boolean hasSuceed) {
			this.hasSuceed = hasSuceed;
		}

	}

	/**
	 * ����ip
	 * 
	 * @param ip
	 */
	public static void setServerIP(String ip) {
		IP = ip;
	}

	/**
	 * ���ö˿�
	 * 
	 * @param port
	 */
	public static void setServerPORT(int port) {
		PORT = port;
	}
}
