function ShowSearch(options) {
    if (options.type == 'complex') {
        ComplexSearch(options);
    }
    else {
        AdvancedSearch(options);
    }
}

function ComplexSearch(options) {
    $.dialogwindow({
        iconCls: 'icon-search',
        title: '复合查询',
        width: 540,
        height: 350,
        url: options.url,
        onComplete: function (dialog, jq) {
            var table = $('#complexSearch');
            var flag = 0;
            var row;
            for (var i = 0; i < options.columns.length; i++) {
                if (options.columns[i].field != 'cbk') {
                    var th = $("<th></th>");
                    th.append(options.columns[i].title);
                    var td = $("<td></td>");
                    td.append('<input id="' + options.columns[i].field + '" style="width: 120px;" />');
                    if (flag % 2 == 0) {
                        row = $("<tr></tr>");
                    }
                    row.append(th);
                    row.append(td);
                    if (flag % 2 != 0) {

                        table.append(row);
                    }
                    flag++;
                }
            }

        },
        buttons: [{
            text: '确定',
            iconCls: 'icon-ok',
            handler: function () {
                var table = $('#complexSearch');
                var inputs = $('#complexSearch input');
                var condition = '';
                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].value != '') {
                        if (condition.length > 0) {
                            condition += ' and ';
                        }
                        condition += inputs[i].id + "='" + inputs[i].value + "'";
                    }
                }
                options.onComplete(condition);
            }
        }]
    });
}

function AdvancedSearch(options) {
    debugger;
    var fields = [];
    for (var i = 0; i < options.columns.length; i++) {
        if (options.columns[i].field != 'cbk') {
            if (fields.length == 0) {
                fields.push({ text: options.columns[i].title, value: options.columns[i].field, selected: true });
            }
            else {
                fields.push({ text: options.columns[i].title, value: options.columns[i].field });
            }
        }
    }
    var operator = [];
    operator.push({ text: '大于', value: '>' });
    operator.push({ text: '等于', value: '=', selected: true });
    operator.push({ text: '小于', value: '<' });
    operator.push({ text: '不等于', value: '<>' });
    operator.push({ text: '大于等于', value: '>=' });
    operator.push({ text: '小于等于', value: '<=' });
    operator.push({ text: '类似', value: 'like' });

    var mark = [];
    mark.push({ text: '并且', value: 'and' });
    mark.push({ text: '或者', value: 'or' });
    mark.push({ text: '结束', value: 'end', selected: true });

    $.dialogwindow({
        iconCls: 'icon-search',
        title: '高级查询',
        width: 540,
        height: 350,
        url: options.url,
        onComplete: function (dialog, jq) {
            $('#field').combobox('loadData', fields);
            $('#operator').combobox('loadData', operator);
            $('#mark').combobox('loadData', mark);
        },
        buttons: [{
            text: '确定',
            iconCls: 'icon-ok',
            handler: function () {
                var data = $('#grid-condition').datagrid('getData').rows;
                var condition = '';
                for (var i = 0; i < data.length; i++) {
                    for (var j = 0; j < fields.length; j++) {
                        if (fields[j].text == data[i].field) {
                            condition += fields[j].value;
                            condition += ' ';
                            break;
                        }
                    }
                    for (var j = 0; j < operator.length; j++) {
                        if (operator[j].text == data[i].operator) {
                            condition += operator[j].value;
                            condition += ' ';
                            if (operator[j].value == 'like') {
                                condition += "'%" + data[i].value + "%' ";
                            }
                            else {
                                condition += "'" + data[i].value + "' ";
                            }
                            break;
                        }
                    }
                    for (var j = 0; j < mark.length; j++) {
                        if (mark[j].text == data[i].mark) {
                            if (mark[j].value != 'end') {
                                condition += mark[j].value;
                                condition += ' ';
                            }
                            break;
                        }
                    }
                }
                options.onComplete(condition);
            }
        }]
    });
}


function addCondition() {
    if ($("#form-Search").form('validate')) {
        var rows = $('#grid-condition').datagrid('getRows');
        if (rows.length > 0) {
            for (var i = 0; i < rows.length; i++) {
                if (rows[i].mark == '结束') {
                    $.messager.alert('提示', "条件语句已经包含结束，无法添加条件！", 'warning');
                    return;
                }
            }
        }
        $('#grid-condition').datagrid('appendRow', {
            field: $("#field").combobox('getText'),
            operator: $("#operator").combobox('getText'),
            value: $("#value").val(),
            mark: $("#mark").combobox('getText')
        });
    }
}

function deleteCondition() {
    var rows = $('#grid-condition').datagrid('getSelections');
    if (rows.length == 0) {
        $.messager.alert('提示', "请选择数据！", 'warning');
        return;
    }
    var index = $('#grid-condition').datagrid("getRowIndex", rows[0]);
    $('#grid-condition').datagrid("deleteRow", index);
}