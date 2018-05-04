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

	private int downY; // 按下时y轴的值
	private int firstVisibleItem; // 当易董事当前屏幕显示在最上面的item的索引
	private View headerView; // 头布局对象
	private int headerViewHeight; // 头布局的高度

	private final int DOWN_PULL = 0; // 下拉刷新
	private final int RELEASE_REFRESH = 1; // 释放刷新
	private final int REFRESHING = 2; // 正在刷新

	public int headerViewCurrentState = DOWN_PULL; // 当前头布局的状态, 默认为: 下拉刷新
	private RotateAnimation upAnimation; // 向上旋转的动画
	private RotateAnimation downAnimation; // 向下旋转的动画
	private ImageView ivArrow; // 头布局的箭头
	private ProgressBar mProgressBar; // 头布局的进度条
	private TextView tvState; // 头布局的状态
	private TextView tvLastUpdateTime; // 头布局的刷新时间

	private OnRefreshListener mOnRefreshListener; // 用户刷新的回调事件
	private boolean isScroll2Bottom; // 当前是否滚动到底部
	private View footerView; // 脚布局对象
	private boolean isLoadingMore = false; // 是否正在加载更多中, 默认为: false
	private int footerViewHeight; // 脚布局的高度
	public int diff;

	public RefreshListView(Context context, AttributeSet attrs) {
		super(context, attrs);

		initHeader();
		initFooter();

		setOnScrollListener(this);
	}

	/**
	 * 初始化脚布局
	 */
	private void initFooter() {
		footerView = View.inflate(getContext(), R.layout.listview_footer, null);

		// 首先得得到脚布局的高度, 手动调用脚布局的测量方法measure
		footerView.measure(0, 0);

		footerViewHeight = footerView.getMeasuredHeight();

		footerView.setPadding(0, -footerViewHeight, 0, 0);

		this.addFooterView(footerView);
	}

	/**
	 * 给ListView添加头布局
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

		// TODO 需要给tvLastUpdateTime设置一下当前是时间
		tvLastUpdateTime.setText("最后刷新时间: " + getLastUpdateTime());

		// 让框架帮我们去测量头布局的高度和宽度.
		headerView.measure(0, 0);

		// getHeight()方法只可以在布局显示(在屏幕上展示)之后获得高度.
		// int height = headerView.getHeight();

		headerViewHeight = headerView.getMeasuredHeight();

		System.out.println("头布局高度:" + headerViewHeight);

		headerView.setPadding(0, -headerViewHeight, 0, 0);

		this.addHeaderView(headerView); // 向ListView的顶部加一个布局

		initAnimation();
	}

	/**
	 * 初始化动画
	 */
	private void initAnimation() {
		upAnimation = new RotateAnimation(0, -180, Animation.RELATIVE_TO_SELF,
				0.5f, Animation.RELATIVE_TO_SELF, 0.5f);
		upAnimation.setDuration(500);
		upAnimation.setFillAfter(true); // 设置动画停留在结束的位置上

		downAnimation = new RotateAnimation(-180, -360,
				Animation.RELATIVE_TO_SELF, 0.5f, Animation.RELATIVE_TO_SELF,
				0.5f);
		downAnimation.setDuration(500);
		downAnimation.setFillAfter(true); // 设置动画停留在结束的位置上
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
					&& headerViewCurrentState != REFRESHING) { // 当前是向下移动,
																// 并且当前是在顶部,
																// 并且当前不是正在刷新中的状态
				// 把头布局下拉出来

				// -头布局的高度 + 移动的距离 = 最新的paddingTop
				int paddingTop = -headerViewHeight + diff;

				if (paddingTop > 0 && headerViewCurrentState == DOWN_PULL) {
					System.out.println("进入了释放刷新状态");
					headerViewCurrentState = RELEASE_REFRESH;
					refreshHeaderViewState();
				} else if (paddingTop < 0
						&& headerViewCurrentState == RELEASE_REFRESH) {
					System.out.println("进入了下拉刷新状态");
					headerViewCurrentState = DOWN_PULL;
					refreshHeaderViewState();
				}

				headerView.setPadding(0, paddingTop, 0, 0);
				return true; // 自己处理的当前事件
			}
			break;
		case MotionEvent.ACTION_UP:
			// 判断当前是状态, 如果是: 下拉刷新, 隐藏头布局, 如果是: 释放刷新, 进入到正在刷新状态
			if (headerViewCurrentState == DOWN_PULL) {
				// 当前下拉刷新, 隐藏头布局
				headerView.setPadding(0, -headerViewHeight, 0, 0);
			} else if (headerViewCurrentState == RELEASE_REFRESH) {
				// 当前释放刷新, 进入到正在刷新状态
				headerViewCurrentState = REFRESHING;
				refreshHeaderViewState();
				headerView.setPadding(0, 0, 0, 0); // 完全显示头布局.

				// 调用用户的回调事件, 让使用者去刷新数据去.
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
	 * 根据headerViewCurrentState来刷新头布局的状态
	 */
	private void refreshHeaderViewState() {
		switch (headerViewCurrentState) {
		case DOWN_PULL: // 下拉刷新
			ivArrow.startAnimation(downAnimation);
			tvState.setText("下拉刷新");
			break;
		case RELEASE_REFRESH: // 释放刷新
			ivArrow.startAnimation(upAnimation);
			tvState.setText("释放刷新");
			break;
		case REFRESHING: // 正在刷新中
			ivArrow.setVisibility(View.INVISIBLE);
			ivArrow.clearAnimation();
			mProgressBar.setVisibility(View.VISIBLE);
			tvState.setText("正在刷新中..");
			break;
		default:
			break;
		}
	}

	/**
	 * 当滚动时回调此方法 firstVisibleItem 当前屏幕第一个显示的item的索引 visibleItemCount
	 * 当前屏幕显示的条目的总个数 totalItemCount ListView的总长度
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
	 * 当滚动状态改变时的回调方法 SCROLL_STATE_IDLE 停止状态 SCROLL_STATE_TOUCH_SCROLL
	 * 手指触摸屏幕去移动ListView的滚动状态 SCROLL_STATE_FLING 快速的滑动(猛地一滑)
	 */
	@Override
	public void onScrollStateChanged(AbsListView view, int scrollState) {
		// 当当前的状态是处于停滞状态或快速滑动的状态时, 判断isScroll2Bottom是否滚动到底部
		if (scrollState == SCROLL_STATE_IDLE
				|| scrollState == SCROLL_STATE_FLING) {
			if (isScroll2Bottom && !isLoadingMore) {
				isLoadingMore = true;

				// 当前滚动到底部了. 把脚布局显示出来
				System.out.println("当前显示了脚布局");
				footerView.setPadding(0, 0, 0, 0);
				// 把脚布局显示出来, 其实把当前ListView滚动到最后一个item
				setSelection(getCount());

				// 调用用户的回调刷新事件
				if (mOnRefreshListener != null) {
					mOnRefreshListener.onLoadingMore();
				}
			}
		}

	}

	/**
	 * 设置刷新的事件
	 * 
	 * @param listener
	 */
	public void setOnRefreshListener(OnRefreshListener listener) {
		this.mOnRefreshListener = listener;
	}

	/**
	 * 隐藏头布局
	 */
	public void hideHeaderView() {
		headerView.setPadding(0, -headerViewHeight, 0, 0);
		headerViewCurrentState = DOWN_PULL;
		ivArrow.setVisibility(View.VISIBLE);
		mProgressBar.setVisibility(View.INVISIBLE);
		tvState.setText("下拉刷新");
		tvLastUpdateTime.setText("最后刷新时间: " + getLastUpdateTime());
	}

	/**
	 * 隐藏脚布局
	 */
	public void hideFooterView() {
		footerView.setPadding(0, -footerViewHeight, 0, 0);
		isLoadingMore = false; // 把是否正在加载更多中, 置为false
	}

	/**
	 * 返回最新的时间 1990-09-09 09:09:09
	 * 
	 * @return
	 */
	private String getLastUpdateTime() {
		SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		return sdf.format(new Date());
	}
}
