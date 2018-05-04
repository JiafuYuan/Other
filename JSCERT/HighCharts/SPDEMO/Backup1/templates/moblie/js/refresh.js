

(function($, undefined) {
    $.ui.define('refresh', {
        _data: {
            ready: null,
            statechange: null
        },

        _setup: function () {
            var me = this,
                data = me._data,
                $el = me.root();

            data.$upElem = $el.find('.ui-refresh-up');
            data.$downElem = $el.find('.ui-refresh-down');
            $el.addClass('ui-refresh');
            return me;
        },

        _init: function() {
            var me = this,
                data = me._data;
            $.each(['up', 'down'], function (i, dir) {
                var $elem = data['$' + dir + 'Elem'],
                    elem = $elem.get(0);
                if ($elem.length) {
                    me._status(dir, true);    
                    if (!elem.childNodes.length || ($elem.find('.ui-refresh-icon').length && $elem.find('.ui-refresh-label').length)) {    
                        !elem.childNodes.length && me._createBtn(dir);
                        data.refreshInfo || (data.refreshInfo = {});
                        data.refreshInfo[dir] = {
                            $icon: $elem.find('.ui-refresh-icon'),
                            $label: $elem.find('.ui-refresh-label'),
                            text: $elem.find('.ui-refresh-label').html()
                        }
                    }
                    $elem.on('click', function () {
                        if (!me._status(dir) || data._actDir) return;         
                        me._setStyle(dir, 'loading');
                        me._loadingAction(dir, 'click');
                    });
                }
            });
            return me;
        },

        _createBtn: function (dir) {
            this._data['$' + dir + 'Elem'].html('<span class="ui-refresh-icon"></span><span class="ui-refresh-label">加载更多</span>');
            return this;
        },

        _setStyle: function (dir, state) {
            var me = this,
                stateChange = $.Event('statechange');

            me.trigger(stateChange, [me._data['$' + dir + 'Elem'], state, dir]);
            if (stateChange.defaultPrevented) return me;

            return me._changeStyle(dir, state);
        },

        _changeStyle: function (dir, state) {
            var data = this._data,
                refreshInfo = data.refreshInfo[dir];

            switch (state) {
                case 'loaded':
                    refreshInfo['$label'].html(refreshInfo['text']);
                    refreshInfo['$icon'].removeClass();
                    data._actDir = '';
                    break;
                case 'loading':
                    refreshInfo['$label'].html('加载中...');
                    refreshInfo['$icon'].addClass('ui-loading');
                    data._actDir = dir;
                    break;
                case 'disable':
                    refreshInfo['$label'].html('娌℃湁鏇村鍐呭浜�');
                    break;
            }
            return this;
        },

        _loadingAction: function (dir, type) {
            var me = this,
                data = me._data,
                readyFn = data.ready;

            $.isFunction(readyFn) && readyFn.call(me, dir, type);
            me._status(dir, false);
            return me;
        },

        afterDataLoading: function (dir) {
            var me = this,
                dir = dir || me._data._actDir;
            me._setStyle(dir, 'loaded');
            me._status(dir, true);
            return me;
        },

        _status: function(dir, status) {
            var data = this._data;
            return status === undefined ? data['_' + dir + 'Open'] : data['_' + dir + 'Open'] = !!status;
        },

        _setable: function (able, dir, hide) {
            var me = this,
                data = me._data,
                dirArr = dir ? [dir] : ['up', 'down'];
            $.each(dirArr, function (i, dir) {
                var $elem = data['$' + dir + 'Elem'];
                if (!$elem.length) return;
                able ? $elem.show() : (hide ?  $elem.hide() : me._setStyle(dir, 'disable'));
                me._status(dir, able);
            });
            return me;
        },


        disable: function (dir, hide) {
            return this._setable(false, dir, hide);
        },


        enable: function (dir) {
            return this._setable(true, dir);
        }



    });
})(Zepto);