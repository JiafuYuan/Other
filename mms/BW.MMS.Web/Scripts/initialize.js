/**
* initialize - Home Page
* -----------------------------
* Copyright (c) 2013 Chan.
* chenqian@outlook.com.cn
* -----------------------------
* Date: 2013-11-12
* Revision: 1.0
*/
//初始化菜单、tab 面板右键菜单、菜单点击添加 tab 面板
function initialize(options) {
    if (options.menutype == 'tree') {
        //初始化 tree 菜单
        $(options.menu).tree({
            animate: true,
            lines: true,
            url: options.url,
            onClick: function (node) {
                if (node.attributes) {
                    if ($(options.menu).tree('isLeaf', node.target)) {
                        addtabs(options.tabs, node.text, node.attributes.url, node.iconCls);
                    }
                    else {
                        if (node.state == "open") {
                            $(tree).tree('collapse', node.target);
                        }
                        else {
                            $(tree).tree('expand', node.target);
                        }
                    }
                }
            }
        });
    }
    if (options.menutype == 'accordion') {
        //初始化 accordionmenu 菜单
        $(options.menu).accordionmenu({
            url: options.url,
            data: options.data,
            onClick: function (item) {
                addtabs(options.tabs, item.text, item.url, item.iconCls);
            }
        });
    }
    //tabs添加右键菜单
    $(options.tabs).tabs({
        onContextMenu: function (e, title) {
            e.preventDefault();
            $(options.tabsmenu).menu('show', {
                left: e.pageX,
                top: e.pageY
            }).data("tabTitle", title);
        }
    });
    //tabs右键菜单绑定点击事件
    $(options.tabsmenu).menu({
        onClick: function (item) {
            var title = $(this).data("tabTitle");
            if (item.name === "close") {
                $(options.tabs).tabs("close", title);
                return;
            }
            var tabs = $(options.tabs).tabs("tabs");
            var closetabs = [];
            $.each(tabs, function () {
                var opt = $(this).panel("options");
                if (opt.closable && opt.title != title && item.name === "Other") {
                    closetabs.push(opt.title);
                } else if (opt.closable && item.name === "All") {
                    closetabs.push(opt.title);
                }
            });
            for (var i = 0; i < closetabs.length; i++) {
                $(options.tabs).tabs("close", closetabs[i]);
            }
        }
    });
}
//添加tab面板
function addtabs(tabs, text, url, icon) {
    /// <summary>
    /// 添加选项卡面板
    /// </summary>
    /// <param name="tabs">选项卡面板</param>
    /// <param name="text">面板标题</param>
    /// <param name="url">面板URL地址</param>
    if ($(tabs).tabs('exists', text)) {
        $(tabs).tabs('select', text);
    } else {
        var paramrandom = RndNum(10);
        url += "?_" + paramrandom;
        $(tabs).tabs('add', {
            title: text,
            iconCls: icon,
            cache: false,
            closable: true,
            bodyCls: 'panel-noscroll',
            style: { padding: '2px' },
            content: '<iframe id="iframe_' + paramrandom + '" name="iframe_' + paramrandom + '" scrolling="no" frameborder="0" height="100%"  src="' + url + '" style="width:100%;height:100%;"></iframe>'
        });
    }
}
//随机数
function RndNum(n) {
    var rnd = "";
    for (var i = 0; i < n; i++)
        rnd += Math.floor(Math.random() * 10);
    return rnd;
}