(function ($) {
    function setEmptyText(target, text) {
        var options = $.data(target, 'combo').options;
        var opts = $.extend(true, {}, $.fn.combo.defaults, options);
        if (!text) return;
        if (options.required) {
            var validType = ['unequal["' + text + '"]'];
            if (options.validType) {
                if (typeof options.validType == 'string') {
                    validType.push(options.validType);
                    options.validType = validType;
                }
                if ($.isArray(options.validType)) {
                    $.merge(options.validType, validType)
                }
            } else {
                $.extend(options, { validType: validType });
            }
        }
        $(target).combo('textbox')
            .val(text)
            .attr('prompt', text)
            .focus(function () {
                if ($(this).val() == text) $(this).val('');
            })
            .blur(function () {
                if ($.trim($(this).val()) == '') $(this).val(text);
                $(target).combo('validate');
            });
        $(target).combo('validate');
    }

    $.extend($.fn.combo.methods, {
        emptyText: function (jq, text) {
            return jq.each(function () {
                setEmptyText(this, text);
            });
        },
        selectedIndex: function (jq, index) {
            if (index >= 0) {
                var data = $(jq).combobox('options').data;
                var field = $(jq).combobox('options').valueField;
                $(jq).combobox('setValue', eval('data[index].' + field));
            }
        }
    });
    $.extend($.fn.validatebox.defaults.rules, {
        unequal: {
            validator: function (value, param) {
                return value != param;
            },
            message: $.fn.validatebox.defaults.missingMessage
        }
    });
})(jQuery);