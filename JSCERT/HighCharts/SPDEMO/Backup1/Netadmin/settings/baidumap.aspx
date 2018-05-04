<html>
<head>
    <script src="../../scripts/jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <style type="text/css">
        body, html, #allmap
        {
            width: 100%;
            height: 100%;
            overflow: hidden;
            margin: 0;
        }
    </style>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=D7c335ada291ee0506f36d4ba10a7a88"></script>
    <title>地址解析</title>
</head>
<body>
    <div id="allmap">
    </div>
</body>
</html>
<script type="text/javascript">
    var adds = "";
    var names = "";
    $.post("../../tools/admin_ajax.ashx?action=get_baidu_map", {}, function (data, status) {
        if (data != "error") {
           
            var datavalue = data.split('|');
            adds = datavalue[0];
            names = datavalue[1];
            // 百度地图API功能
            var map = new BMap.Map("allmap");
            var point = new BMap.Point(116.404, 39.915);
            map.centerAndZoom(point, 5);
            map.enableScrollWheelZoom();    //启用滚轮放大缩小，默认禁用
            map.enableContinuousZoom(); 
            // 创建地址解析器实例
            var myGeo = new BMap.Geocoder();
            // 将地址解析结果显示在地图上,并调整地图视野
            myGeo.getPoint(adds, function (point) {
                if (point) {
                    map.centerAndZoom(point, 16);
                    map.addOverlay(new BMap.Marker(point));
                    var opts = {
                        width: 200,     // 信息窗口宽度
                        height: 60,     // 信息窗口高度
                        title: names, // 信息窗口标题
                        enableMessage: true, //设置允许信息窗发送短息
                        message: "亲耐滴~"
                    }
                    var infoWindow = new BMap.InfoWindow(adds, opts);  // 创建信息窗口对象
                    map.openInfoWindow(infoWindow, point); //开启信息窗口
                }
            }, "南京市");
        }
        else {
        
            alert("暂无企业展示！");
        }
    });
   
  
</script>
