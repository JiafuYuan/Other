<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mapmobile.aspx.cs" Inherits="SPcms.Web.Plugin.map.admin.mapmobile" %>

<%@ Import Namespace="SPcms.Common" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <script src="/scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        body, html
        {
            width: 100%;
            height: 100%;
            overflow: hidden;
            margin: 0;
        }
        #allmap
        {
            height: 100%;
            overflow: hidden;
            margin-right: 300px;
        }
        #result
        {
            border-left: 1px dotted #999;
            height: 100%;
            width: 295px;
            position: absolute;
            top: 0px;
            right: 0px;
            font-size: 12px;
            padding-left: 5px;
        }
        dl, dt, dd, ul, li
        {
            margin: 0;
            padding: 0;
            list-style: none;
        }
        dt
        {
            font-size: 14px;
            font-family: "微软雅黑";
            font-weight: bold;
            border-bottom: 1px dotted #000;
            padding: 5px 0 5px 5px;
            margin: 5px 0;
        }
        dd
        {
            padding: 5px 0 0 5px;
        }
        li
        {
            line-height: 28px;
        }
    </style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=D7c335ada291ee0506f36d4ba10a7a88"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/library/SearchInfoWindow/1.5/src/SearchInfoWindow_min.js"></script>
    <link rel="stylesheet" href="http://api.map.baidu.com/library/SearchInfoWindow/1.5/src/SearchInfoWindow_min.css" />
    <title>SearchInfoWindow</title>
</head>
<body>
    <div id="allmap" style="overflow: hidden; zoom: 1; position: relative;">
        <div id="map" style="height: 100%; -webkit-transition: all 0.5s ease-in-out; transition: all 0.5s ease-in-out;">
        </div>
        <div id="showPanelBtn" style="position: absolute; font-size: 14px; top: 50%; margin-top: -95px;
            right: 0px; width: 20px; padding: 10px 10px; color: #999; cursor: pointer; text-align: center;
            height: 170px; background: rgba(255,255,255,0.9); -webkit-transition: all 0.5s ease-in-out;
            transition: all 0.5s ease-in-out; font-family: '微软雅黑'; font-weight: bold;">
            显示检索结果面板<br />
            &lt;
        </div>
        <div id="panelWrap" style="width: 0px; position: absolute; top: 0px; right: 0px;
            height: 100%; overflow: auto; -webkit-transition: all 0.5s ease-in-out; transition: all 0.5s ease-in-out;">
            <div style="width: 20px; height: 200px; margin: -100px 0 0 -10px; color: #999; position: absolute;
                opacity: 0.5; top: 50%; left: 50%;">
                此处用于展示结果面板
            </div>
            <div id="panel" style="position: absolute;">
            </div>
        </div>
    </div>
    <div id="result">
        <dl>
            <dt>信息窗口参数</dt>
            <dd>
                <ul>
                    <li>地址：<br />
                        <input type="text" id="address" value="<%=address%>" style="width: 230px;" /></li>
                    <li>公司名称：<br />
                        <input type="text" id="cname" value="<%=cname%>" style="width: 230px;" /></li>
                    <li>公司电话：<br />
                        <input type="text" id="tel" value="<%=tel%>" style="width: 230px;" /></li>
                    <li>公司简介：<br />
                        <textarea type="text" id="content" style="width: 230px; height: 220px;"><div style="margin:0;line-height:20px;padding:2px;"><%=jj %></div></textarea>
                        <br />
                        <span style="color: red">*由seo描述提供</span></li>
                    <li>
                                 <li>宽度：<br />
                        <input type="text" id="mwidth" value="<%=mwidth%>" style="width: 30px;" /></li>
                                     <li>高度：<br />
                        <input type="text" id="mheight" value="<%=mheight%>" style="width: 30px;" /></li>
                        <button id="setValue">
                            设置</button><button id="saveValue">
                            保存</button></li>
                </ul>
            </dd>
        </dl>
    </div>
</body>
</html>
<script type="text/javascript">
    // 百度地图API功能
    init();
    function init() {
        var cname = $("#cname").val();
        var address = $("#address").val();
        var tel = $("#tel").val();
        var seojj = $("#content").val();
        var map = new BMap.Map('map');

        var myGeo = new BMap.Geocoder();
        // 将地址解析结果显示在地图上,并调整地图视野
        myGeo.getPoint(address, function (point) {
            if (point) {
                map.centerAndZoom(point, 16);
                map.addOverlay(new BMap.Marker(point));


                map.centerAndZoom(point, 16);
                map.enableScrollWheelZoom();

                var content = '<div style="margin:0;height:120px; overflow: scroll; ;padding:2px;">' +
                    '' +
                    '地址：' + address + '<br/>电话：' + tel + '<br/>简介：' + seojj + '' +
                  '</div>';

                //创建检索信息窗口对象
                var searchInfoWindow = null;
                searchInfoWindow = new BMapLib.SearchInfoWindow(map, content, {
                    title: cname,      //标题
                    width: 290,             //宽度
                    height: 105,              //高度
                    panel: "panel",         //检索结果面板
                    enableAutoPan: true,     //自动平移
                    searchTypes: [
				BMAPLIB_TAB_SEARCH,   //周边检索
				BMAPLIB_TAB_TO_HERE,  //到这里去
				BMAPLIB_TAB_FROM_HERE //从这里出发
			]
                });
                var marker = new BMap.Marker(point); //创建marker对象
                marker.enableDragging(); //marker可拖拽
                marker.addEventListener("click", function (e) {
                    searchInfoWindow.open(marker);
                })
                map.addOverlay(marker); //在地图中添加marker
                searchInfoWindow.open(marker); //在marker上打开检索信息串口
            }
        }, "南京市");
    }




    function $$(id) {
        return document.getElementById(id);
    }
    $$("setValue").onclick = function () {

        init();
    
       
    }
    $$("saveValue").onclick = function () {

       
        savedata();
    }

    var isPanelShow = false;
    //显示结果面板动作
    $$("showPanelBtn").onclick = function () {
        if (isPanelShow == false) {
            isPanelShow = true;
            $$("showPanelBtn").style.right = "300px";
            $$("panelWrap").style.width = "300px";
            $$("map").style.marginRight = "300px";
            $$("showPanelBtn").innerHTML = "隐藏检索结果面板<br/>>";
        } else {
            isPanelShow = false;
            $$("showPanelBtn").style.right = "0px";
            $$("panelWrap").style.width = "0px";
            $$("map").style.marginRight = "0px";
            $$("showPanelBtn").innerHTML = "显示检索结果面板<br/><";
        }
    }

    function savedata() {

        $.post("../ajax.ashx?action=edit_map2", { address: $("#address").val(), cname: $("#cname").val(), tel: $("#tel").val(), seojj: $("#content").val(), mwidth: $("#mwidth").val(), mheight: $("#mheight").val() }, function (data, textStatus) {

            alert(data);
        })

    }
</script>
