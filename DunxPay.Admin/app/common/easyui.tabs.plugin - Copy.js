(function(){//扩展easyui中tabs的部分方法，实现根据唯一标识id的进行相应操作；技巧：使用一个自执行的函数，激发作用域，避免这里定义的变量与系统全局变量冲突  
    var _methods = $.fn.tabs.methods;  
    var _exists = _methods.exists;//保存原方法  
    var _getTab = _methods.getTab;//保存原方法</span>  
        $.extend($.fn.tabs.methods, {  
            getTab : function(jq, which) {//重写getTab方法，增加根据id获取tab（注意：这里我们可以定义任意的获取方式，不必一定使用id）  
                if(!which) return null;  
                var tabs = jq.data('tabs').tabs;  
                for (var i = 0; i < tabs.length; i++) {  
                    var tab = tabs[i];  
                    if (tab.panel("options").id===which) {  
                        return tab;  
                    }  
                }  
                return _getTab(jq, which);//如果根据id无法获取，则通过easyui默认的getTab进行获取  
            },  
            exists : function(jq, which) {//重写exists方法，增加id判断  
                return this.getTab(jq,which)!=null;//调用重写后的getTab方法  
            }  
        });  
})()  

$.extend($.fn.tabs.methods, {
    getTabById: function (jq, id) {
        console.info("current id:", id);
        var tabs = jq.data('tabs').tabs;
        console.info("tabs:", tabs);
        
        for (var i = 0; i < tabs.length; i++) {
            var tab = tabs[i];
            if (tab.panel('options').id == id) {
                return tab;
            }
        }
        return null;
    },
    selectById: function (jq, id) {
        return jq.each(function () {
            var state = $.data(this, 'tabs');
            var opts = state.options;
            var tabs = state.tabs;
            var selectHis = state.selectHis;
            if (tabs.length == 0) { return; }
            var panel = $(this).tabs('getTabById', id); // get the panel to be activated 
            if (!panel) { return }
            var selected = $(this).tabs('getSelected');
            if (selected) {
                if (panel[0] == selected[0]) { return }
                $(this).tabs('unselect', $(this).tabs('getTabIndex', selected));
                if (!selected.panel('options').closed) { return }
            }
            panel.panel('open');
            var title = panel.panel('options').title;        // the panel title 
            selectHis.push(title);        // push select history 
            var tab = panel.panel('options').tab;        // get the tab object 
            tab.addClass('tabs-selected');
            // scroll the tab to center position if required. 
            var wrap = $(this).find('>div.tabs-header>div.tabs-wrap');
            var left = tab.position().left;
            var right = left + tab.outerWidth();
            if (left < 0 || right > wrap.width()) {
                var deltaX = left - (wrap.width() - tab.width()) / 2;
                $(this).tabs('scrollBy', deltaX);
            } else {
                $(this).tabs('scrollBy', 0);
            }
            $(this).tabs('resize');
            opts.onSelect.call(this, title, $(this).tabs('getTabIndex', panel));
        });
    },
    existsById: function (jq, id) {
        return $(jq[0]).tabs('getTabById', id) != null;
    }
});