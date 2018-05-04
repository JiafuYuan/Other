package com.bestway.kj915.domain;

import java.io.Serializable;

public class User implements Serializable {

	
	public User(String username, String password) {
		super();
		this.username = username;
		this.password = password;
	}
	private String username;
	private String password;
	private String userID;
	public String getUserID() {
		return userID;
	}
	public void setUserID(String userID) {
		this.userID = userID;
	}
	public String getUsername() {
		return username;
	}
	public void setUsername(String username) {
		this.username = username;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	
}
