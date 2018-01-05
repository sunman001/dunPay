window.G = {
    lsKeys: {
        access_token: "access_token"
    },
    auth: {
        isLogin: function () {
            var access_token = G.auth.getAccessToken();
            var is_login = false;
            if (access_token) {
                is_login = true;
            }
            return is_login;
        },
        login: function (access_token) {
            localStorage.setItem(G.lsKeys.access_token, access_token);
            window.top.location.href = "/home/index";
        },
        logout: function () {
            localStorage.removeItem(G.lsKeys.access_token);
        },
        getAccessToken: function () {
            var access_token = localStorage.getItem(G.lsKeys.access_token);
            return access_token;
        },
        oauthGrantUrl: "", //用户授权地址
        redirect: function () {
            window.top.location.href = G.auth.oauthGrantUrl;
        },
        permissions: function (requestUrl) {
            $.ajax({
                url: G.consts.apiPublicUrl + "account/permissions?req=" + requestUrl,
                type: "GET",
                dataType: "JSON",
                success: function (response) {
                    if (!response.isAuthenticated) {
                        if (window.top !== window.self) {
                            window.top.G.message.alert(response.message);
                        } else {
                            G.message.alert(response.message);
                        }
                        return null;
                    }
                    return response.permissions;
                }
            });
        }
    },
    consts: {
        apiBaseUrl: "http://localhost:57288/api/",  //API请求基地址
        apiUrl: "http://localhost:57288/api/admin/v1/",  //API请求地址
        apiPublicUrl: "http://localhost:57288/api/public/v1/" //通用API请求地址
    },
    http: {
        //创建完整的API请求地址
        buildUrl: function (resourceUrl) {
            return G.consts.apiBaseUrl + "admin/v1/" + resourceUrl;
        },
        buildPublicUrl: function (resourceUrl) {
            return G.consts.apiPublicUrl + resourceUrl;
        }
    },
    progress: {
        loading: function () {
            $(".load-bar-wrap").show();
        },
        loaded: function () {
            $(".load-bar-wrap").hide();
        }
    },
    message: {
        alert: function (message) {
            $.messager.alert("提示信息", message, "error");
        },
        warning: function (message, callback) {
            $.messager.alert("提示信息", message, "error", callback);
        },
        confirm: function (message, callback) {
            $.messager.confirm("确认提示", message, function (r) {
                if (r) {
                    if (callback) {
                        callback();
                    }
                }
            });
        }
    },
    config: {
        grid: {
            pageList: [10, 20, 30, 40, 50, 60, 70, 80]
        }
    }
}

$.ajaxSetup({
    global: true,
    //headers: { Authorization: "bearer " + G.auth.getAccessToken() },
    beforeSend: function (xhr) {
        xhr.setRequestHeader("Authorization", "bearer " + G.auth.getAccessToken());
        //xhr.setRequestHeader("custom", "dxpay");
        if (window.top !== window.self) {
            window.top.G.progress.loading();
        } else {
            G.progress.loading();
        }
    },
    complete: function (xhr, textStatus) {
        if (window.top !== window.self) {
            window.top.G.progress.loaded();
        } else {
            G.progress.loaded();
        }
    }
});

$(document).ajaxError(function (event, jqxhr, settings, exception) {
    var message = "出错啦,请稍候重试";
    var unauthorized = false;
    switch (jqxhr.status) {
        case 401:
            unauthorized = true;
            message = "登录已失效,请重新登录";
            break;
        case 403:
            message = jqxhr.responseJSON.message;
            break;
        case 404:
            message = "[404]请求的服务器资源不存在";
            break;
        case 0:
            message = "服务器连接失败,请稍候再试";
            break;
        default:
            break;
    }
    if (unauthorized) {
        if (window.top !== window.self) {
            window.top.G.message.warning(message, function () {
                G.auth.redirect();
            });
        } else {
            G.message.warning(message, function () {
                G.auth.redirect();
            });
        }
    } else {
        if (window.top !== window.self) {
            window.top.G.message.alert(message);
        } else {
            G.message.alert(message);
        }
    }

});

//打开窗口
var dialog = {
    openPopup: function (target, title, href, buttons, toolbar, width, height) {
        var _width = width || 800;
        var _height = height || 600;
        var _buttons = buttons || [];
        _buttons.push({
            text: '关闭',
            iconCls: 'icon-remove',
            handler: function () {
                $(target).dialog('close');
            }
        });
        var _toolbar = toolbar || [];
        $(target).dialog({
            title: title,
            width: _width,
            height: _height,
            collapsible: true,
            minimizable: true,
            maximizable: true,
            resizable: true,
            closed: false,
            modal: true,
            toolbar: _toolbar,
            buttons: _buttons,
            href: href
        });
    },
    //操作成功后提示后并刷新grid后关闭消息框
    closeMessager: function (title, message, grid, type) {
        var _type = type || 0;
        $.messager.alert(title, message, "info");
        setTimeout(function () {
            $(".messager-body").window('close');
            if (_type == 0) {
                $("#" + grid).datagrid('reload');
            } else {
                $("#" + grid).treegrid('reload');
            }
        }, 1000);
    },

    //操作成功后提示并关闭窗口以及消息框
    closePopup: function (title, message, target, grid, type) {
        var _type = type || 0;
        $.messager.alert(title, message, "info");
        setTimeout(function () {
            $(".messager-body").window('close');
            $("#"+target).dialog('close');
            if (_type == 0) {
                $("#" + grid).datagrid('reload');
            } else {
                $("#" + grid).treegrid('reload');
            }

           
        }, 1000);
    }
}

//表格控件
var dxgrid = {
    config: {
        pageList: [10, 20, 30, 40, 50, 60, 70, 80]
    },
    /*
        * grid:表格控件对象,如:$("#grid")
        * options:datagrid的配置选项,url为必填项
    */
    datagrid: function (grid, options) {
        var _default = {
            //url: G.http.buildUrl("Module/List"), //后台加载地址
            url: "",
            method: "post", //请求类型(get/post)
            border: true, //边框
            autoRowHeight: false, //自动行高
            fitColumns: true, //自适应网格(如果是 false 则显示横向滚动条)
            striped: true, //奇偶行不同背景
            nowrap: true,
            pagination: true, ////True 就会在 datagrid 的底部显示分页栏
            rownumbers: true, //显示行号
            idField: "id", //主键列
            sortName: "createdOn", //默认排序字段
            sortOrder: "desc", //默认排序(asc/desc)
            scrollbarSize: 0,
            pageNumber: 1, //初始化页码
            remoteSort: true, //是否数据源排序
            pageSize: 20, //初始化分页大小
            pageList: dxgrid.config.pageList, //初始化页面尺寸的选择列表
            loadMsg: "正在查询数据..." //加载提示
        };
        //var _newGrid = {};
        $.extend(true, _default, options);
      //  console.info("_default datagrid:", _default);
        if (_default.url) {
            _default.url = G.http.buildUrl(_default.url);
            grid.datagrid(_default);
        }
        //return _default;
    },
    getSelectedRows:function(grid,idField) {
        var ids = [];
        var rows = grid.datagrid("getSelections");
        for (var i = 0; i < rows.length; i++) {
            ids.push(rows[i][idField]);
        }
        return ids;
    }
};