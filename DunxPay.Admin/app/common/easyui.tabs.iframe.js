var matched, browser;

jQuery.uaMatch = function (ua) {
    ua = ua.toLowerCase();

    var match = /(chrome)[ \/]([\w.]+)/.exec(ua) ||
        /(webkit)[ \/]([\w.]+)/.exec(ua) ||
        /(opera)(?:.*version|)[ \/]([\w.]+)/.exec(ua) ||
        /(msie) ([\w.]+)/.exec(ua) ||
        ua.indexOf("compatible") < 0 && /(mozilla)(?:.*? rv:([\w.]+)|)/.exec(ua) ||
        [];

    return {
        browser: match[1] || "",
        version: match[2] || "0"
    };
};

matched = jQuery.uaMatch(navigator.userAgent);
browser = {};

if (matched.browser) {
    browser[matched.browser] = true;
    browser.version = matched.version;
}

// Chrome is Webkit, but Webkit is also Safari.
if (browser.chrome) {
    browser.webkit = true;
} else if (browser.webkit) {
    browser.safari = true;
}

jQuery.browser = browser;

$.extend($.fn.tabs.methods, {
	/**
     * tabs组件每个tab panel对应的小工具条绑定的事件没有传递事件参数
     * 本函数修正这个问题
     * @param {[type]} jq [description]
     */
	addEventParam: function (jq) {
		return jq.each(function () {
			var that = this;
			var headers = $(this).find('>div.tabs-header>div.tabs-wrap>ul.tabs>li');
			headers.each(function (i) {
				var tools = $(that).tabs('getTab', i).panel('options').tools;
				if (typeof tools != "string") {
					$(this).find('>span.tabs-p-tool a').each(function (j) {
						$(this).unbind('click').bind("click", {
							handler: tools[j].handler
						}, function (e) {
							if ($(this).parents("li").hasClass("tabs-disabled")) {
								return;
							}
							e.data.handler.call(this, e);
						});
					});
				}
			})
		});
	},
	/**
     * 加载iframe内容
     * @param  {jq Object} jq     [description]
     * @param  {Object} params    params.which:tab的标题或者index;params.iframe:iframe的相关参数
     * @return {jq Object}        [description]
     */
	loadTabIframe: function (jq, params) {
	    console.info("params:", params);
		return jq.each(function () {
		    var $tab = $(this).tabs('getTab', params.which);
		    console.info("loadTabIframe $tab:", $tab);
			if ($tab == null) return;

			var $tabBody = $tab.panel('body');
		    G.progress.loading();
			//销毁已有的iframe
			var $frame = $('iframe', $tabBody);
			if ($frame.length > 0) {
				try {//跨域会拒绝访问，这里处理掉该异常
					$frame[0].contentWindow.document.write('');
					$frame[0].contentWindow.close();
				} catch (e) {
					//Do nothing
				}
				$frame.remove();
				if ((navigator.userAgent.toLowerCase().indexOf('msie') !== -1)) {
					CollectGarbage();
				}
			}
			$tabBody.html("");
			var $containter = $tabBody;

			var iframe = document.createElement("iframe");
			iframe.src = params.iframe.src;
			iframe.frameBorder = params.iframe.frameBorder || 0;
			iframe.height = params.iframe.height || '100%';
			iframe.width = params.iframe.width || '100%';
			if (iframe.attachEvent) {
				iframe.attachEvent("onload", function () {
				    G.progress.loaded();
				});
			} else {
				iframe.onload = function () {
				    G.progress.loaded();
				};
			}
			$containter[0].appendChild(iframe);
		});
	},
	/**
     * 增加iframe模式的标签页
     * @param {[type]} jq     [description]
     * @param {[type]} params [description]
     */
	addIframeTab: function (jq, params) {
	    console.info("params add:", params);
		return jq.each(function () {
			if (params.tab.href) {
				delete params.tab.href;
			}
			$(this).tabs('add', params.tab);
			$(this).tabs('loadTabIframe', { 'which': params.tab.title, 'iframe': params.iframe });
		});
	},
	/**
     * 更新tab的iframe内容
     * @param  {jq Object} jq     [description]
     * @param  {Object} params [description]
     * @return {jq Object}        [description]
     */
	updateIframeTab: function (jq, params) {
		return jq.each(function () {
			params.iframe = params.iframe || {};
			if (!params.iframe.src) {
				var $tab = $(this).tabs('getTab', params.which);
				if ($tab == null) return;
				var $tabBody = $tab.panel('body');
				var $iframe = $tabBody.find('iframe');
				if ($iframe.length === 0) return;
				$.extend(params.iframe, { 'src': $iframe.attr('src') });
			}
			$(this).tabs('loadTabIframe', params);
		});
	}
});