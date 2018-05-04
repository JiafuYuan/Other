package com.bestway.kj915.custom.refreshlistview.interf;

public interface OnRefreshListener {

	/**
	 * 下拉刷新回调此方法
	 */
	void onDownPullRefresh();
	
	/**
	 * 加载更多的回调事件
	 */
	void onLoadingMore();
}
