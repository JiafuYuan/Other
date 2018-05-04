//注册 AcReport
$(function () {
    var engine = new ActiveXObject("AcReport.AcRptEngine");
    var RegCode = '3338495E46463540202341584C5894C7C7C24E351F08AB1FC7A44BFCFC7C6DC867594D85461F8BC9BC5F33BF38B47C14250ED3B7A64F698B7FD6DEDA479A71329980F2DF3085B46CF2F40FC34CCD0B99979568434117C78106ED170549997191AC111A4E';
    var ErrCode, ErrMsg;
    engine.SetRegisterInfo(RegCode, '南京北路自动化', 'c005', '南京市江宁开发区菲尼克斯路99号', 'hezison@126.com', '18913391800', '', ErrCode, ErrMsg);
});
var defaults = {
    type: 'design', //print
    datagrid: '',
    data: [],
    variant: [],
    aptPath: '',
    aptExists: false
}
function AcReport(options) {
    options = $.extend({}, defaults, options || {});
    var engine = new ActiveXObject("AcReport.AcRptEngine");
    //添加变量
    if (options.variant && options.variant.length > 0) {
        for (var i = 0; i < options.variant.length; i++) {
            engine.AddVariable(options.variant[i].name, options.variant[i].value);
        }
    }
    if (options.aptExists) {
        //加载模版
        var aptUrl = window.location.protocol + '//' + window.location.host + options.aptPath;
        engine.LoadFromURL(aptUrl);
        if (options.type == 'design') {
            engine.ShowDesigner();
        }
        else {
            //加载数据
            LoadAcReport(options, engine);
            engine.Preview();
        }
    }
    else {
        if (options.type == 'design') {
            //加载数据
            LoadAcReport(options, engine);
            engine.ShowDesigner();
        }
        else {
            alert('报表模板不存在！');
        }

    }
}
function LoadAcReport(options, engine) {
    if (options.data.length > 0) {
        for (var i = 0; i < options.data.length; i++) {
            var strJSON = JSON.stringify(options.data[i]);
            engine.AddOneDatasetFromJSON(options.data[i].name, strJSON);
        }
    }
    if (options.datagrid != '') {
        var strJSON = GridToReportJson(options.datagrid);
        nRet = engine.AddOneDatasetFromJSON(options.datagrid, strJSON);
        if (nRet != 0) {
            error = engine.GetLastErrorMessage();
            alert(error);
        }
    }
}
//DataGrid 转 AcReport Json 格式
function GridToReportJson(datagrid) {
    var columns = $('#' + datagrid).datagrid('options').columns;
    var rows = $('#' + datagrid).datagrid('getRows');
    var pagination = $('#' + datagrid).datagrid('options').pagination;
    if (pagination) {
        //如果 DataGrid 分页，重新取所有数据
    }
    var data = {};
    data['name'] = $('#' + datagrid).datagrid('options').id;
    var titles = [];
    for (var i = 0; i < columns.length; i++) {
        for (var j = 0; j < columns[i].length; j++) {
            if (columns[i][j].field) {
                titles.push({ name: columns[i][j].field, type: 'string', length: 500 });
            }
        }
    }
    data['titles'] = titles;
    var records = [];
    for (var i = 0; i < rows.length; i++) {
        var values = [];
        for (var j = 0; j < titles.length; j++) {
            values.push(rows[i][titles[j].name] == null ? '' : rows[i][titles[j].name].toString());
        }
        records.push({ values: values });
    }
    data['records'] = records;
    return JSON.stringify(data);
}
//报表设计
function ShowDesigner(datagrid, aptPath, variant, url) {
    var engine = new ActiveXObject("AcReport.AcRptEngine");
    $.post(url || 'ExistsReport', { path: aptPath }).success(function (exists) {
        if (exists) {
            var aptUrl = window.location.protocol + '//' + window.location.host + aptPath;
            engine.LoadFromURL(aptUrl);
            LoadReport(engine, datagrid, variant);
            engine.ShowDesigner();
        }
        else {
            LoadReport(engine, datagrid, variant);
            engine.ShowDesigner();
        }
    });
}
//打印预览
function PrintView(datagrid, aptPath, variant, url) {
    var engine = new ActiveXObject("AcReport.AcRptEngine");
    $.post(url || 'ExistsReport', { path: aptPath }).success(function (exists) {
        if (exists) {
            var aptUrl = window.location.protocol + '//' + window.location.host + aptPath;
            engine.LoadFromURL(aptUrl);
            LoadReport(engine, datagrid, variant);
            engine.Preview();
        }
        else {
            alert('报表模板不存在！');
        }
    });
}
//DataGrid转 AcReport JSON 数据
function AcReportJson(datagrid) {
    var columns = $('#' + datagrid).datagrid('options').columns;
    var rows = $('#' + datagrid).datagrid('getRows');
    var pagination = $('#' + datagrid).datagrid('options').pagination;
    if (pagination) {
        //如果 DataGrid 分页，重新取所有数据
    }
    var data = {};
    data['name'] = $('#' + datagrid).datagrid('options').id;
    var titles = [];
    for (var i = 0; i < columns.length; i++) {
        for (var j = 0; j < columns[i].length; j++) {
            if (columns[i][j].field) {
                titles.push({ name: columns[i][j].field, type: 'string', length: 500 });
            }
        }
    }
    data['titles'] = titles;
    var records = [];
    for (var i = 0; i < rows.length; i++) {
        var values = [];
        for (var j = 0; j < titles.length; j++) {
            values.push(rows[i][titles[j].name] == null ? '' : rows[i][titles[j].name].toString());
        }
        records.push({ values: values });
    }
    data['records'] = records;
    return JSON.stringify(data);
}
//加载 AcReport 数据
function LoadReport(engine, datagrid, variant) {
    if (typeof (datagrid) == 'string') {
        var strJSON = AcReportJson(datagrid);
        nRet = engine.AddOneDatasetFromJSON(datagrid, strJSON);
        if (nRet != 0) {
            strErrMsg = engine.GetLastErrorMessage();
            alert(strErrMsg);
        }
    }
    else {
        for (var i = 0; i < datagrid.length; i++) {
            var strJSON = JSON.stringify(datagrid[i]);
            engine.AddOneDatasetFromJSON(datagrid[i].name, strJSON);
        }
    }
    if (variant) {
        for (var i = 0; i < variant.length; i++) {
            engine.AddVariable(variant[i].name, variant[i].value);
        }
    }
}

//报表设计
function ReportShowDesigner(name, dataurl, aptPath, param, reporturl) {
    var engine = new ActiveXObject("AcReport.AcRptEngine");
    $.post(reporturl || 'ExistsReport', { path: aptPath }).success(function (exists) {
        if (exists) {
            var aptUrl = window.location.protocol + '//' + window.location.host + aptPath;
            engine.LoadFromURL(aptUrl);
            LoadReportUrl(engine, name, dataurl, param);
            engine.ShowDesigner();
        }
        else {
            LoadReportUrl(engine, name, dataurl, param);
            engine.ShowDesigner();
        }
    });
}

//DataGrid转 AcReport JSON 数据
function GetAcReportJson(name, dataurl, options) {
    var result;
    var param = {};
    for (var h = 0, k = options.length; h < k; h++) {
        param[options[h].name] = options[h].value;
    }
    $.ajax({
        url: dataurl,
        data: param,
        type: "POST",
        async: false,
        datatype: "json",
        success: function (d) {
            result = d;
        },
        error: function (a, b, c) {
        }
    });
    if (!result||result.length==0) {
        return null;
    }
    var data = {};
    var titles = [];
    var columns = result[0];
    //object类型未考虑，嵌套类型数据
    for (var key in columns) {
        titles.push({ name: key, type: 'string', length: 500 }); 
    }
    data['name'] = name;
    data['titles'] = titles;
    var records = [];
    for (var i = 0, u = result.length; i < u; i++) {
        var values = [];
        for (var j = 0; j < titles.length; j++) {
            values.push(result[i][titles[j].name] == null ? '' : result[i][titles[j].name].toString());
        }
        records.push({ values: values });
    }
    data['records'] = records;
    return JSON.stringify(data);
}

//加载 AcReport 数据
function LoadReportUrl(engine, name, dataurl, param) {
    debugger 
    var strJSON = GetAcReportJson(name, dataurl, param);
    nRet = engine.AddOneDatasetFromJSON(name, strJSON);
    if (nRet != 0) {
        strErrMsg = engine.GetLastErrorMessage();
        alert(strErrMsg);
    }
    if (param) {
        for (var i = 0; i < param.length; i++) {
            engine.AddVariable(param[i].name, param[i].value);
        }
    }
}

//打印预览
function ReportPrintView(name, dataurl, aptPath, param, reporturl) {
    var engine = new ActiveXObject("AcReport.AcRptEngine");
    $.post(reporturl || 'ExistsReport', { path: aptPath }).success(function (exists) {
        if (exists) {
            var aptUrl = window.location.protocol + '//' + window.location.host + aptPath;
            engine.LoadFromURL(aptUrl);
            LoadReportUrl(engine, name, dataurl, param);
            engine.Preview();
        }
        else {
            alert('报表模板不存在！');
        }
    });
}