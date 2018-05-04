//设置主题
function setTheme(id,themeName) {
    var easyuiTheme = $('#'+id);
    var url = easyuiTheme.attr('href');
    var href = url.substring(0, url.indexOf('themes')) + 'themes/' + themeName + '/easyui.css';
    easyuiTheme.attr('href', href);
    var $iframe = $('iframe');
    if ($iframe.length > 0) {
        for (var i = 0; i < $iframe.length; i++) {
            var ifr = $iframe[i];
            $(ifr).contents().find('#'+id).attr('href', href);
        }
    }
    $.cookie('easyui-skin', themeName, {
        expires: 7
    });
};

/**      
* 对Date的扩展，将 Date 转化为指定格式的String      
* 月(M)、日(d)、12小时(h)、24小时(H)、分(m)、秒(s)、周(E)、季度(q) 可以用 1-2 个占位符      
* 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)      
* eg:      
* yyyy-MM-dd hh:mm:ss.S ==> 2006-07-02 08:09:04.423      
* yyyy-MM-dd E HH:mm:ss ==> 2009-03-10 二 20:09:04      
* yyyy-MM-dd EE hh:mm:ss) ==> 2009-03-10 周二 08:09:04      
* yyyy-MM-dd EEE hh:mm:ss ==> 2009-03-10 星期二 08:09:04      
* yyyy-M-d h:m:s.S ==> 2006-7-2 8:9:4.18      
*/
function formatDate(str, fmt) {
    if (typeof str == 'string') {
        str = parseDate(str);
    }
    var o = {
        "M+": str.getMonth() + 1, //月份         
        "d+": str.getDate(), //日         
        "h+": str.getHours() % 12 == 0 ? 12 : str.getHours() % 12, //小时         
        "H+": str.getHours(), //小时         
        "m+": str.getMinutes(), //分         
        "s+": str.getSeconds(), //秒         
        "q+": Math.floor((str.getMonth() + 3) / 3), //季度         
        "S": str.getMilliseconds() //毫秒         
    };
    var week = {
        "0": "/u65e5",
        "1": "/u4e00",
        "2": "/u4e8c",
        "3": "/u4e09",
        "4": "/u56db",
        "5": "/u4e94",
        "6": "/u516d"
    };
    if (/(y+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, (str.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    if (/(E+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, ((RegExp.$1.length > 1) ? (RegExp.$1.length > 2 ? "/u661f/u671f" : "/u5468") : "") + week[str.getDay() + ""]);
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(fmt)) {
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        }
    }
    return fmt;
}

function parseDate(str) {
    var results = str.match(/^ *(\d{4})-(\d{1,2})-(\d{1,2}) *$/);
    if (results && results.length > 3)
        return new Date(parseInt(results[1]), parseInt(results[2]) - 1, parseInt(results[3]));
    results = str.match(/^ *(\d{4})-(\d{1,2})-(\d{1,2}) +(\d{1,2}):(\d{1,2}):(\d{1,2}) *$/);
    if (results && results.length > 6)
        return new Date(parseInt(results[1]), parseInt(results[2]) - 1, parseInt(results[3]), parseInt(results[4]), parseInt(results[5]), parseInt(results[6]));
    results = str.match(/^ *(\d{4})-(\d{1,2})-(\d{1,2})T+(\d{1,2}):(\d{1,2}):(\d{1,2}) *$/);
    if (results && results.length > 6)
        return new Date(parseInt(results[1]), parseInt(results[2]) - 1, parseInt(results[3]), parseInt(results[4]), parseInt(results[5]), parseInt(results[6]));
    results = str.match(/^ *(\d{4})-(\d{1,2})-(\d{1,2}) +(\d{1,2}):(\d{1,2}):(\d{1,2})\.(\d{1,9}) *$/);
    if (results && results.length > 7)
        return new Date(parseInt(results[1]), parseInt(results[2]) - 1, parseInt(results[3]), parseInt(results[4]), parseInt(results[5]), parseInt(results[6]), parseInt(results[7]));
    return null;
}

(function ($) {
    $.fn.serializeJson = function () {
        var serializeObj = {};
        var array = this.serializeArray();
        var str = this.serialize();
        $(array).each(function () {
            if (serializeObj[this.name]) {
                if ($.isArray(serializeObj[this.name])) {
                    serializeObj[this.name].push(this.value);
                } else {
                    serializeObj[this.name] = [serializeObj[this.name], this.value];
                }
            } else {
                serializeObj[this.name] = this.value;
            }
        });
        return serializeObj;
    };
})(jQuery);

(function ($) {
    $.fn.setform = function (jsonValue) {
        var obj = this;
        $.each(jsonValue, function (name, ival) {
            var $oinput = obj.find("input:[name=" + name + "]");
            if ($oinput.attr("type") == "radio" || $oinput.attr("type") == "checkbox") {
                $oinput.each(function () {
                    if ($(this).val() == ival)
                        $(this).attr("checked", "checked");
                });
            }
            else {
                obj.find("[name=" + name + "]").val(ival);
            }
        });
    };
})(jQuery);

function mergeCellsByField(tableID, colList) {
    var ColArray = colList.split(",");
    var tTable = $('#' + tableID);
    var TableRowCnts = tTable.datagrid("getRows").length;
    var tmpA;
    var tmpB;
    var PerTxt = "";
    var CurTxt = "";
    var alertStr = "";
    //for (j=0;j<=ColArray.length-1 ;j++ )  
    for (j = ColArray.length - 1; j >= 0; j--) {
        //当循环至某新的列时，变量复位。  
        PerTxt = "";
        tmpA = 1;
        tmpB = 0;

        //从第一行（表头为第0行）开始循环，循环至行尾(溢出一位)  
        for (i = 0; i <= TableRowCnts; i++) {
            if (i == TableRowCnts) {
                CurTxt = "";
            }
            else {
                CurTxt = tTable.datagrid("getRows")[i][ColArray[j]];
            }
            if (PerTxt == CurTxt) {
                tmpA += 1;
            }
            else {
                tmpB += tmpA;
                tTable.datagrid('mergeCells', {
                    index: i - tmpA,
                    field: ColArray[j],
                    rowspan: tmpA,
                    colspan: null
                });
                tmpA = 1;
            }
            PerTxt = CurTxt;
        }
    }
} 