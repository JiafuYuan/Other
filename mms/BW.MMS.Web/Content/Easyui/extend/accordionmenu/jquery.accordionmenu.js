/**
* accordionmenu - jQuery EasyUI
* -----------------------------
* Copyright (c) 2013 Chan.
* chenqian@outlook.com.cn
* -----------------------------
* Date: 2013-11-11
* Revision: 1.0
*/
(function ($) {
    $.fn.accordionmenu = function (options, param) {
        if (typeof options == 'string') {
            return $.fn.accordionmenu.methods[options](this);
        }
        var accordion = this;
        $(accordion).accordion({ animate: false, fit: true, border: false });
        var panels = $(accordion).accordion('panels');
        $.each(panels, function (i, n) {
            $(accordion).accordion('remove', 0);
        });
        options = $.extend({}, $.fn.accordionmenu.defaults, options || {});
        if (options.url != null) {
            $.ajax({
                url: options.url,
                type: options.method,
                async: false,
                dataType: options.dataType,
                data: options.param || {},
                success: function (data) {
                    if (options.data) {
                        options.data = data;
                    }
                    else {
                        options['data'] = data;
                    }
                }
            });
        }
        if (options.data && options.data.length > 0) {
            $.each(options.data, function (i, n) {
                var menu = $('<ul/>').addClass("accordionmenu");
                $.each(n.children, function (j, o) {
                    var menuitem = $('<li/>');
                    var d = $('<div/>');
                    var a = $('<a/>').attr('id', o.id).attr('rel', o.attributes.url);
                    var icon = $('<span/>').addClass("accordionmenu-item").addClass(o.iconCls).text(o.text);
                    icon.appendTo(a);
                    a.appendTo(d);
                    d.appendTo(menuitem);
                    menuitem.appendTo(menu);
                })
                $(accordion).accordion('add', {
                    title: n.text,
                    content: menu,
                    border: false,
                    tools: n.tools,
                    iconCls: n.iconCls || ''
                });
            });
        }
        if ($(accordion).accordion('panels').length > 1) {
            $(accordion).accordion('select', 0);
        }
        $('.accordionmenu li a').click(function () {
            var item = {};
            item["id"] = $(this).attr("id");
            item["text"] = $(this).children('.accordionmenu-item').text();
            item["url"] = $(this).attr("rel");
            item["iconCls"] = $(this).children('.accordionmenu-item').attr('class').replace('accordionmenu-item ', '');
            $('.accordionmenu li div').removeClass("selected");
            $(this).parent().addClass("selected");
            return options.onClick(item);
        }).hover(function () {
            $(this).parent().addClass("hover");
        }, function () {
            $(this).parent().removeClass("hover");
        });
    }
    $.fn.accordionmenu.methods = {
        getSelected: function (jq) {
            var item = {};
            var selectitem = jq.find('.accordionmenu li div[class=selected] a')[0];
            item["id"] = $(selectitem).attr("id");
            item["text"] = $(selectitem).children('.accordionmenu-item').text();
            item["url"] = $(selectitem).attr("rel");
            item["iconCls"] = $(selectitem).children('.accordionmenu-item').attr('class').replace('accordionmenu-item ', '');
            return item;
        }
    };
    $.fn.accordionmenu.defaults = {
        method: 'POST',
        dataType: 'json',
        url: null,
        param: null,
        onClick: function (item) { }
    };
})(jQuery);