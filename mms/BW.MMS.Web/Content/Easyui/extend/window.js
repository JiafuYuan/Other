/**
*创建人   ：孙军
*创建时间 ：2013.07.31
*功能描述 ：自动创建弹出框
*/
(function ($) {
    function S4() {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    }
    function CreateIndentityWindowId() {
        return "UUID-" + (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
    }
    function destroy(target) {
        //        if (dialog.iframe) {
        //            dialog.iframe.src = null;
        //            dialog.iframe.removeNode(true);
        //        }
        $(target).dialog("destroy");
    }
    function getEasyWindowdow(target) {
        if (typeof target == "string") {
            return document.getElementById(target);
        } else {
            return $(target).closest(".window-body");
        }
    }
    $.EasyWindow = function (options) {
        if (!options.url && !options.html) {
            $.messager.alert("提示", "缺少必要参数!(url or html)");
            return false;
        }
        var windowId = CreateIndentityWindowId();
        if (options.id) {
            windowId = options.id;
        } else {
            options.id = windowId;
        }
        var defaultBtn = [{
            text: '关闭',
            iconCls: 'icon-cancel',
            handler: function () {
                $("#" + windowId).dialog("close");
            }
        }
		];
        $.merge(options.buttons || [], defaultBtn);
        options = $.extend({}, $.EasyWindow.defaults, options || {});
        if (options.isMax) {
            options.draggable = false;
            options.closed = true;
        }
        var dialog = $('<div style="padding:5px;" />');
        if (options.target != 'body') {
            options.inline = true;
        }
        dialog.appendTo($(options.target));
        dialog.dialog($.extend({}, options, {
            onClose: function () {
                if (typeof options.onClose == "function") {
                    options.onClose.call(dialog, $);
                }
                destroy(this);
            },
            onMove: function (left, top) {
                if (typeof options.onMove == "function") {
                    options.onMove.call(dialog, $);
                }
                var o = $.data(this, 'panel').options;
                if (top < 0) {
                    $(this).dialog("move", {
                        "left": left,
                        "top": 0
                    });
                } else if (o.maximized) {
                    $(this).dialog("restore");
                    $(this).dialog("move", {
                        "left": left + 100,
                        "top": top
                    });
                }
                if (top > ($(o.target).height() - 20)) {
                    $(this).dialog("move", {
                        "left": left,
                        "top": ($(o.target).height() - 25)
                    });
                }
            }
        }));
        if (options.align) {
            var w = dialog.closest(".window");
            switch (options.align) {
                case "right":
                    dialog.dialog("move", {
                        left: w.parent().width() - w.width() - 10
                    });
                    break;
                case "tright":
                    dialog.dialog("move", {
                        left: w.parent().width() - w.width() - 10,
                        top: 0
                    });
                    break;
                case "bright":
                    dialog.dialog("move", {
                        left: w.parent().width() - w.width() - 10,
                        top: w.parent().height() - w.height() - 10
                    });
                    break;
                case "left":
                    dialog.dialog("move", {
                        left: 0
                    });
                    break;
                case "tleft":
                    dialog.dialog("move", {
                        left: 0,
                        top: 0
                    });
                    break;
                case "bleft":
                    dialog.dialog("move", {
                        left: 0,
                        top: w.parent().height() - w.height() - 10
                    });
                    break;
                case "top":
                    dialog.dialog("move", {
                        top: 0
                    });
                    break;
                case "bottom":
                    dialog.dialog("move", {
                        top: w.parent().height() - w.height() - 10
                    });
                    break;
            }
        }
        if (options.isMax) {
            dialog.dialog("maximize");
            dialog.dialog("open");
        }
        if ($.fn.mask && options.mask)
            if (options.maskconfig) {
                dialog.mask(options.maskconfig);
            }
            else {
                dialog.mask();
            }
        if (options.html) {
            ajaxSuccess(options.html);
        } else {
            if (!options.isIframe) {
                $.ajax({
                    url: options.url,
                    type: options.ajaxType || "POST",
                    //dataType: "html",
                    cache: false,
                    data: options.data == null ? "" : options.data,
                    success: function (date) {
                        var _216 = /<body[^>]*>((.|[\n\r])*)<\/body>/im;
                        var _217 = _216.exec(date);
                        if (_217) {
                            ajaxSuccess(_217[1]);
                        } else {
                            ajaxSuccess(date);
                        }
                    },
                    error: function () {
                        $.messager.alert("提示", "加载失败！");
                        if ($.fn.mask && options.mask)
                            dialog.mask("hide");
                    }
                });
            } else {
                ajaxSuccess();
            }
        }
        dialog.attr("id", windowId);
        return dialog;
        function ajaxSuccess(date) {
            if (options.isIframe && !date) {
                //dialog.find("div.dialog-content").html('<iframe id="iFrame' + windowId + '" border="none" width="100%" height="100%" frameborder="0" scrolling="no" src="' + options.url + '" ></iframe>');
                var IframeObj = document.createElement("iframe");
                IframeObj.id = "iFrame_" + windowId;
                IframeObj.name = "iFrame_" + windowId;
                IframeObj.width = "100%";
                IframeObj.height = "100%";
                IframeObj.src = options.url;
                IframeObj.scrolling = "no";
                IframeObj.marginwidth = "0";
                IframeObj.allowTransparency = true;
                IframeObj.marginheight = "0";
                IframeObj.framespacing = "0";
                IframeObj.border = "0px";
                IframeObj.style.border = "0px";
                IframeObj.style.borderBottom = "0px";
                IframeObj.style.borderLeft = "0px";
                IframeObj.style.borderTop = "0px";
                IframeObj.style.borderRight = "0px";
                IframeObj.setAttribute('frameborder', '0', 0);
                if (window.addEventListener) { // Mozilla, Netscape, Firefox
                    IframeObj.addEventListener('load', function () {
                        if (IframeObj) {
                            options.onComplete.call(this, dialog, $);
                            if ($.fn.mask && options.mask)
                                dialog.mask("hide");
                        }
                    }, false);
                } else { // IE
                    IframeObj.attachEvent('onreadystatechange', function () {
                        if (arguments[0] && arguments[0].srcElement && arguments[0].srcElement.readyState == "complete") {
                            options.onComplete.call(this, dialog, $);
                            if ($.fn.mask && options.mask)
                                dialog.mask("hide");
                        }
                    });
                }
                dialog.find("div.dialog-content").append(IframeObj);
                dialog.iframe = IframeObj;
            } else {
                dialog.find("div.dialog-content").html(date);
                if ($.parser) {
                    $.parser.parse(dialog);
                }
                options.onComplete.call(this, dialog, $);
                if ($.fn.mask && options.mask) {
                    dialog.mask("hide");
                }
            }
        }
    };
    window.getEasyWindowdow = getEasyWindowdow;
    $.EasyWindow.defaults = $.extend({}, $.fn.dialog.defaults, {
        url: '',
        data: '',
        ajaxType: "GET",
        target: 'body',
        height: 200,
        width: 400,
        collapsible: false,
        minimizable: false,
        maximizable: false,
        closable: true,
        modal: true,
        shadow: false,
        isIframe: false,
        mask: true,
        //        maskconfig: {
        //            maskMsg: '\u52a0\u8f7d……',
        //            zIndex: 100000,
        //            timeout: 30000,
        //            opacity: 0.6
        //        },
        onComplete: function (dialog, jq) { }
    });
})(jQuery);
