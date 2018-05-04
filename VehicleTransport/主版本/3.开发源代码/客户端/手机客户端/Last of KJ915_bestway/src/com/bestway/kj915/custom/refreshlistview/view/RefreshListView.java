package com.bestway.kj915.custom.refreshlistview.view;

import java.text.SimpleDateFormat;
import java.util.Date;

import android.content.Context;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.view.View;
import android.view.animation.Animation;
import android.view.animation.RotateAnimation;
import android.widget.AbsListView;
import android.widget.AbsListView.OnScrollListener;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.TextView;

import com.bestway.kj915.R;
import com.bestway.kj915.custom.refreshlistview.interf.OnRefreshListener;

public class RefreshListView extends ListView implements OnScrollListener {

	private int downY; // ����ʱy���ֵ
	private int firstVisibleItem; // ���׶��µ�ǰ��Ļ��ʾ���������item������
	private View headerView; // ͷ���ֶ���
	private int headerViewHeight; // ͷ���ֵĸ߶�

	private final int DOWN_PULL = 0; // ����ˢ��
	private final int RELEASE_REFRESH = 1; // �ͷ�ˢ��
	private final int REFRESHING = 2; // ����ˢ��

	public int headerViewCurrentState = DOWN_PULL; // ��ǰͷ���ֵ�״̬, Ĭ��Ϊ: ����ˢ��
	private RotateAnimation upAnimation; // ������ת�Ķ���
	private RotateAnimation downAnimation; // ������ת�Ķ���
	private ImageView ivArrow; // ͷ���ֵļ�ͷ
	private ProgressBar mProgressBar; // ͷ���ֵĽ�����
	private TextView tvState; // ͷ���ֵ�״̬
	private TextView tvLastUpdateTime; // ͷ���ֵ�ˢ��ʱ��

	private OnRefreshListener mOnRefreshListener; // �û�ˢ�µĻص��¼�
	private boolean isScroll2Bottom; // ��ǰ�Ƿ�������ײ�
	private View footerView; // �Ų��ֶ���
	private boolean isLoadingMore = false; // �Ƿ����ڼ��ظ�����, Ĭ��Ϊ: false
	private int footerViewHeight; // �Ų��ֵĸ߶�
	public int diff;

	public RefreshListView(Context context, AttributeSet attrs) {
		super(context, attrs);

		initHeader();
		initFooter();

		setOnScrollListener(this);
	}

	/**
	 * ��ʼ���Ų���
	 */
	private void initFooter() {
		footerView = View.inflate(getContext(), R.layout.listview_footer, null);

		// ���ȵõõ��Ų��ֵĸ߶�, �ֶ����ýŲ��ֵĲ�������measure
		footerView.measure(0, 0);

		footerViewHeight = footerView.getMeasuredHeight();

		footerView.setPadding(0, -footerViewHeight, 0, 0);

		this.addFooterView(footerView);
	}

	/**
	 * ��ListView���ͷ����
	 */
	private void initHeader() {
		headerView = View.inflate(getContext(), R.layout.listview_header, null);

		ivArrow = (ImageView) headerView
				.findViewById(R.id.iv_listview_header_arrow);
		mProgressBar = (ProgressBar) headerView
				.findViewById(R.id.pb_listview_header);
		tvState = (TextView) headerView
				.findViewById(R.id.tv_listview_header_state);
		tvLastUpdateTime = (TextView) headerView
				.findViewById(R.id.tv_listview_header_last_update_time);

		// TODO ��Ҫ��tvLastUpdateTime����һ�µ�ǰ��ʱ��
		tvLastUpdateTime.setText("���ˢ��ʱ��: " + getLastUpdateTime());

		// �ÿ�ܰ�����ȥ����ͷ���ֵĸ߶ȺͿ��.
		headerView.measure(0, 0);

		// getHeight()����ֻ�����ڲ�����ʾ(����Ļ��չʾ)֮���ø߶�.
		// int height = headerView.getHeight();

		headerViewHeight = headerView.getMeasuredHeight();

		System.out.println("ͷ���ָ߶�:" + headerViewHeight);

		headerView.setPadding(0, -headerViewHeight, 0, 0);

		this.addHeaderView(headerView); // ��ListView�Ķ�����һ������

		initAnimation();
	}

	/**
	 * ��ʼ������
	 */
	private void initAnimation() {
		upAnimation = new RotateAnimation(0, -180, Animation.RELATIVE_TO_SELF,
				0.5f, Animation.RELATIVE_TO_SELF, 0.5f);
		upAnimation.setDuration(500);
		upAnimation.setFillAfter(true); // ���ö���ͣ���ڽ�����λ����

		downAnimation = new RotateAnimation(-180, -360,
				Animation.RELATIVE_TO_SELF, 0.5f, Animation.RELATIVE_TO_SELF,
				0.5f);
		downAnimation.setDuration(500);
		downAnimation.setFillAfter(true); // ���ö���ͣ���ڽ�����λ����
	}

	@Override
	public boolean onTouchEvent(MotionEvent ev) {
		switch (ev.getAction()) {
		case MotionEvent.ACTION_DOWN:
			diff = 0;
			downY = (int) ev.getY();
			break;
		case MotionEvent.ACTION_MOVE:
			int moveY = (int) ev.getY();

			diff = (moveY - downY) / 2;

			if (diff > 0 && firstVisibleItem == 0
					&& headerViewCurrentState != REFRESHING) { // ��ǰ�������ƶ�,
																// ���ҵ�ǰ���ڶ���,
																// ���ҵ�ǰ��������ˢ���е�״̬
				// ��ͷ������������

				// -ͷ���ֵĸ߶� + �ƶ��ľ��� = ���µ�paddingTop
				int paddingTop = -headerViewHeight + diff;

				if (paddingTop > 0 && headerViewCurrentState == DOWN_PULL) {
					System.out.println("�������ͷ�ˢ��״̬");
					headerViewCurrentState = RELEASE_REFRESH;
					refreshHeaderViewState();
				} else if (paddingTop < 0
						&& headerViewCurrentState == RELEASE_REFRESH) {
					System.out.println("����������ˢ��״̬");
					headerViewCurrentState = DOWN_PULL;
					refreshHeaderViewState();
				}

				headerView.setPadding(0, paddingTop, 0, 0);
				return true; // �Լ�����ĵ�ǰ�¼�
			}
			break;
		case MotionEvent.ACTION_UP:
			// �жϵ�ǰ��״̬, �����: ����ˢ��, ����ͷ����, �����: �ͷ�ˢ��, ���뵽����ˢ��״̬
			if (headerViewCurrentState == DOWN_PULL) {
				// ��ǰ����ˢ��, ����ͷ����
				headerView.setPadding(0, -headerViewHeight, 0, 0);
			} else if (headerViewCurrentState == RELEASE_REFRESH) {
				// ��ǰ�ͷ�ˢ��, ���뵽����ˢ��״̬
				headerViewCurrentState = REFRESHING;
				refreshHeaderViewState();
				headerView.setPadding(0, 0, 0, 0); // ��ȫ��ʾͷ����.

				// �����û��Ļص��¼�, ��ʹ����ȥˢ������ȥ.
				if (mOnRefreshListener != null) {
					mOnRefreshListener.onDownPullRefresh();
				}
			}
			break;
		default:
			break;
		}
		return super.onTouchEvent(ev);
	}

	/**
	 * ����headerViewCurrentState��ˢ��ͷ���ֵ�״̬
	 */
	private void refreshHeaderViewState() {
		switch (headerViewCurrentState) {
		case DOWN_PULL: // ����ˢ��
			ivArrow.startAnimation(downAnimation);
			tvState.setText("����ˢ��");
			break;
		case RELEASE_REFRESH: // �ͷ�ˢ��
			ivArrow.startAnimation(upAnimation);
			tvState.setText("�ͷ�ˢ��");
			break;
		case REFRESHING: // ����ˢ����
			ivArrow.setVisibility(View.INVISIBLE);
			ivArrow.clearAnimation();
			mProgressBar.setVisibility(View.VISIBLE);
			tvState.setText("����ˢ����..");
			break;
		default:
			break;
		}
	}

	/**
	 * ������ʱ�ص��˷��� firstVisibleItem ��ǰ��Ļ��һ����ʾ��item������ visibleItemCount
	 * ��ǰ��Ļ��ʾ����Ŀ���ܸ��� totalItemCount ListView���ܳ���
	 */
	@Override
	public void onScroll(AbsListView view, int firstVisibleItem,
			int visibleItemCount, int totalItemCount) {
		this.firstVisibleItem = firstVisibleItem;

		int lastVisiblePosition = this.getLastVisiblePosition();
		if (lastVisiblePosition == (getCount() - 1)) {
			isScroll2Bottom = true;
		} else {
			isScroll2Bottom = false;
		}
	}

	/**
	 * ������״̬�ı�ʱ�Ļص����� SCROLL_STATE_IDLE ֹͣ״̬ SCROLL_STATE_TOUCH_SCROLL
	 * ��ָ������Ļȥ�ƶ�ListView�Ĺ���״̬ SCROLL_STATE_FLING ���ٵĻ���(�͵�һ��)
	 */
	@Override
	public void onScrollStateChanged(AbsListView view, int scrollState) {
		// ����ǰ��״̬�Ǵ���ͣ��״̬����ٻ�����״̬ʱ, �ж�isScroll2Bottom�Ƿ�������ײ�
		if (scrollState == SCROLL_STATE_IDLE
				|| scrollState == SCROLL_STATE_FLING) {
			if (isScroll2Bottom && !isLoadingMore) {
				isLoadingMore = true;

				// ��ǰ�������ײ���. �ѽŲ�����ʾ����
				System.out.println("��ǰ��ʾ�˽Ų���");
				footerView.setPadding(0, 0, 0, 0);
				// �ѽŲ�����ʾ����, ��ʵ�ѵ�ǰListView���������һ��item
				setSelection(getCount());

				// �����û��Ļص�ˢ���¼�
				if (mOnRefreshListener != null) {
					mOnRefreshListener.onLoadingMore();
				}
			}
		}

	}

	/**
	 * ����ˢ�µ��¼�
	 * 
	 * @param listener
	 */
	public void setOnRefreshListener(OnRefreshListener listener) {
		this.mOnRefreshListener = listener;
	}

	/**
	 * ����ͷ����
	 */
	public void hideHeaderView() {
		headerView.setPadding(0, -headerViewHeight, 0, 0);
		headerViewCurrentState = DOWN_PULL;
		ivArrow.setVisibility(View.VISIBLE);
		mProgressBar.setVisibility(View.INVISIBLE);
		tvState.setText("����ˢ��");
		tvLastUpdateTime.setText("���ˢ��ʱ��: " + getLastUpdateTime());
	}

	/**
	 * ���ؽŲ���
	 */
	public void hideFooterView() {
		footerView.setPadding(0, -footerViewHeight, 0, 0);
		isLoadingMore = false; // ���Ƿ����ڼ��ظ�����, ��Ϊfalse
	}

	/**
	 * �������µ�ʱ�� 1990-09-09 09:09:09
	 * 
	 * @return
	 */
	private String getLastUpdateTime() {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		return sdf.format(new Date());
	}
}
