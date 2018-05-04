package com.bestway.kj915.afinalnet;

/**
 * 版权：南京北路自动化系统有限责任公司版权所有
 * 
 * 作者：詹学勇
 * 
 * 版本：1.0
 * 
 * 时间：2014-9-1 上午11:31:31
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
	 * 通信的端口号和ip地址
	 */
	public static String IP = GlobleFields.IP;//36";//67";//61";//58";//

    
	public static int PORT =12345;//9999;//

	/**
	 * 用于处理是响应的是消息头，还是消息体
	 */
	boolean islength = true;  
	int currentSize = 4;   
	

	/**
	 * 用于判断标识通信通道是否初始化成功
	 */
	private boolean hasInit = false;  

	/**
	 * 本地的端口，通信通道初始化后才能被初始化，所以在发送请求命令的时候替换
	 */
	private int myPort;

	/**
	 * 所有的请求异常对应的字符串
	 */
	public static final String CONNET_FAILED = "服务器链接不上";
	public static final String CONNET_INTERUPT = "服务器失去链接";
	public static final String INIT_EXCEPTION = "信道初始化失败";

	/**
	 * 所有的消息的识别码
	 */
	private static final int MSG_REICEIVE_SUCCEED = 1;// 请求和接受成功
	private static final int MSG_SEND_NULL_EXCEPTION = 2;// 发送失败
	private static final int MSG_CONNECT_FAILD = 3;// 链接服务器异常
	private static final int MSG_INIT_EXCEPTION = 4;// 初始化通信通道失败

	/**
	 * 定义处理编码的字符集
	 */
	private Charset charset = Charset.forName("gb2312");
    
	/**
	 * 通信的关键对象，在静态代码快中初始化
	 */
	private SocketChannel socketChannel = null;
	private Selector selector = null;

	/**
	 * 储存所有的的网络请求的回调类，进而根据给定的key给出相应回调
	 */
	private HashMap<String, NetCallback> callbacks = new HashMap<String, NetCallback>();

	/**
	 * 异步请求，主线程更新界面
	 */
	public Handler myHandler = new Handler() {

		@Override
		public void handleMessage(Message msg) {

			LogUtils.careLog(callbacks.size());

			switch (msg.what) {

			case MSG_REICEIVE_SUCCEED:// 请求成功
				CallBackInfo backInfo = (CallBackInfo) msg.obj;
				String cmdType = backInfo.getCmdType();
				String result = backInfo.getTotalResult();
				// 获取并删除项目，然后回调请求
				NetCallback callback = callbacks.remove(cmdType);
				if (callback != null) {
					// 回调结果处理方法1
					callback.onResult(result);
					// 回调结果处理方法2
					callback.onResult(backInfo.getInnerResult(),
							backInfo.isHasSuceed());
					//回调结果处理方法3
					callback.onResult(result,backInfo.getInnerResult(),
							backInfo.isHasSuceed());
					callbacks.remove(callback);
				}
				break;

			case MSG_SEND_NULL_EXCEPTION:// 网络异常

				for (NetCallback callback2 : callbacks.values()) {
					callback2.onResult(CONNET_FAILED);
				}
				break;

			case MSG_CONNECT_FAILD:// 网络异常
				for (NetCallback callback2 : callbacks.values())
					callback2.onResult(CONNET_INTERUPT);
				break;

			case MSG_INIT_EXCEPTION:// 通信通道初始化失败
				for (NetCallback callback2 : callbacks.values())
					callback2.onResult(INIT_EXCEPTION);
				break;

			}
		}

	};

	/**
	 * 单例设计模式
	 */
	private static FinalNClient client = new FinalNClient();

	/**
	 * 静态代码块中执行初始化通信通道的操作
	 */
	static {

		client.init();

	}

	/**
	 * 构造方法私有
	 */
	private FinalNClient() {

	}

	/**
	 * 静态方法获取单实例的唯一操作
	 * 
	 * @return
	 */
	public static FinalNClient getInstance() {
		return client;
	}

	/**
	 * 注意：此方法只能在链接中断后被调用。在子线程，初始化通信信道,在每次断开链接后就要重新初始化。
	 */
	public void init() {

		// 重新配置
		hasInit = false;
		LogUtils.careLog("初始化FinalNClient、、、、");
		new Thread() {

			public void run() {
				try {

					selector = Selector.open();
					InetSocketAddress addrss = new InetSocketAddress(IP, PORT);

					// 调用open的静态方法创建连接指定的主机的SocketChannel
					socketChannel = SocketChannel.open(addrss);

					hasInit = true;
					// 设置该sc已非阻塞的方式工作
					socketChannel.configureBlocking(false);

					// 将SocketChannel对象注册到指定的Selector
					socketChannel.register(selector, SelectionKey.OP_READ);

					// 获取当前的ip地址
					myPort = socketChannel.socket().getLocalPort();

					// 启动读取服务器数据端
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
	 * 建议：通过这种发送请求的方式，比较简单，实际发送请求以此为主
	 * 
	 * 重载的方法
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
	 * 发送请求的所有操作都在次线程中执行
	 * 
	 * @param str
	 */
	public void sendMessage(final String str, NetCallback callback) {

		LogUtils.careLog("发送啊》》" + str);
		if (callback != null) {

			// 主线程调用的初始化对话框，进度条类似的操作
			callback.doPrevious();
			// 将请求储存在集合中，获得网络响应后回调
			callbacks.put(callback.getCmdType(), callback);

		}

		// 如果请求为null，则没必要发送数据
		if (str == null) {
			return;
		}

		// 创建新的线程发送数据
		new Thread() {
			public void run() {
				// 如果通信通道没完全初始化就会一直等到
				while (!hasInit) {
					SystemClock.sleep(100);
				}

				try {
					// 替换成真实的端口
					String finalStr = str.replaceAll("####", "" + myPort);

					// 打包
					ByteBuffer buffer = ByteBuffer.allocate(102400);
					buffer.put(Int_Byte.Int2BytesLH(finalStr.getBytes().length));
					buffer.put(ByteBuffer.wrap(new String(finalStr).getBytes()));
					buffer.flip();

					// socket对象为null则发送请求失败消息
					if (socketChannel == null) {
						myHandler.sendEmptyMessage(MSG_SEND_NULL_EXCEPTION);
						return;
					}

					// 发送
					socketChannel.write(buffer);

				} catch (IOException e) {

					myHandler.sendEmptyMessage(MSG_CONNECT_FAILD);
					e.printStackTrace();
				}
			};
		}.start();

	}

	/**
	 * 异步轮询读取数据的线程
	 */

	private int totalSize;

	byte[] arr;

	public void readMessage() {

		ByteArrayOutputStream baos = new ByteArrayOutputStream();

		try {

			while (selector.select() > 0) {

				// 遍历每个有可能的IO操作的Channel对银行的SelectionKey
				for (SelectionKey sk : selector.selectedKeys()) {

					// 删除正在处理的SelectionKey
					selector.selectedKeys().remove(sk);

					// 如果该SelectionKey对应的Channel中有可读的数据
					if (sk.isReadable()) {

						// 使用NIO读取Channel中的数据
						LogUtils.careLog("进入可读状态");
						SocketChannel sc = (SocketChannel) sk.channel();
						String content = "";

						System.out.println(currentSize + "....?currentSize");

						ByteBuffer bff = ByteBuffer.allocate(currentSize);

						// 解析消息
						while (sc.read(bff) > 0) {

							sc.read(bff);

							bff.flip();
							content += charset.decode(bff);

							if (!islength) {
								baos.write(bff.array(), 0, bff.limit());
							}
						}

						/**
						 * 这是获取消息头长度
						 */
						if (islength) {

							/**
							 * 复原
							 */
							islength = false;

							// 获取消息的长度
							totalSize = Int_Byte.toInt(bff.array());

							currentSize = totalSize;

							System.out.println("总的长度。。" + totalSize);

						} else {

							int preLength = baos.toByteArray().length;

							if (preLength < totalSize) {// 没接收完

								currentSize = totalSize - preLength;

							} else {

								String block = baos.toString("gb2312");

								// 全部读完重新初始化
								baos = new ByteArrayOutputStream();

								currentSize = 4;

								/**
								 * 获取响应的消息，并解析消息
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
								 * 信息封装在回调的javabean对象中
								 */
								CallBackInfo backInfo = new CallBackInfo();
								backInfo.setCmdType(cmdType);
								backInfo.setTotalResult(content);

								// 处理内部的结果
								if (inner != null) {
									backInfo.setInnerResult(inner);
								}

								// 处理是否请求成功
								if (re.equals("true")) {
									backInfo.setHasSuceed(true);
								} else {
									backInfo.setHasSuceed(false);
								}

								/**
								 * 消息发送
								 */
								message.what = MSG_REICEIVE_SUCCEED;
								message.obj = backInfo;

								// 发送handler消息
								myHandler.sendMessage(message);

								/**
								 * 复原
								 */
								islength = true;

								totalSize = 0;

							}

						}

						// 将sk对应的Channel设置成准备下一次读取
						sk.interestOps(SelectionKey.OP_READ);

					}

				}
			}

		} catch (IOException io) {
			io.printStackTrace();
		}
	}

	/**
	 * 处理异步中封装的消息，解析响应类型，从而避免主线程执行过多的逻辑操作，进而提高界面的响应速度
	 * 
	 * @author gaga
	 * 
	 */
	public class CallBackInfo {
		/**
		 * 命令的类型
		 */
		private String cmdType;
		/**
		 * 经过cmdTypeParser解析的字符串
		 */
		private String innerResult;

		/**
		 * 总的字符串
		 */
		private String totalResult;

		/**
		 * 响应的结果result
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
	 * 设置ip
	 * 
	 * @param ip
	 */
	public static void setServerIP(String ip) {
		IP = ip;
	}

	/**
	 * 设置端口
	 * 
	 * @param port
	 */
	public static void setServerPORT(int port) {
		PORT = port;
	}
}
