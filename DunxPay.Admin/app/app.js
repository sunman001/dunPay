//官方平滑树  
function convert(rows) {
    function exists(rows, parentId) {
        for (var i = 0; i < rows.length; i++) {
            if (rows[i].id == parentId) return true;
        }
        return false;
    }

    var nodes = [];
    // get the top level nodes  
    for (var i = 0; i < rows.length; i++) {
        var row = rows[i];
        if (!exists(rows, row.parentId)) {
            nodes.push({
                id: row.id,
                text: row.name,
                memo: row.memo
            });
        }
    }

    var toDo = [];
    for (var i = 0; i < nodes.length; i++) {
        toDo.push(nodes[i]);
    }
    while (toDo.length) {
        var node = toDo.shift();    // the parent node  
        // get the children nodes  
        for (var i = 0; i < rows.length; i++) {
            var row = rows[i];
            if (row.parentId == node.id) {
                var child = { id: row.id, text: row.name, memo: row.memo };
                if (node.children) {
                    node.children.push(child);
                } else {
                    node.children = [child];
                }
                toDo.push(child);
            }
        }
    }
    return nodes;
}
//http://blog.csdn.net/programmer_sir/article/details/44840075
function addIframeTab(tabname, tabId, url, closable) {
    var isExist = $("#mainTabs").tabs("existsById", tabId);
    if (!isExist) {
        //G.progress.loading();
        $('#mainTabs').tabs('addIframeTab',
            {
                //tab参数为一对象，其属性同于原生add方法参数
                tab: {
                    id: tabId,
                    title: tabname,
                    selected: true,
                    closable: closable
                    //tools: [
                    //    {
                    //        iconCls: "icon-mini-refresh",
                    //        handler: function (e) {
                    //            $("#mainTabs").tabs('updateIframeTab', { 'which': tabId });
                    //        }
                    //    }
                    //]
                },
                //iframe参数用于设置iframe信息，包含：
                //src[iframe地址],frameBorder[iframe边框,，默认值为0],delay[淡入淡出效果时间]
                //height[iframe高度，默认值为100%],width[iframe宽度，默认值为100%]
                iframe: { src: url }
            });
        $("#mainTabs").tabs("addEventParam");
    }
    else {
        //$("#mainTabs").tabs("select", tabname + url);
        $("#mainTabs").tabs("selectById", tabId);
    }
}

function addNewTab(tabname, tabId, url, closable) {
    var isExist = $("#mainTabs").tabs("existsById", tabId);
    //创建一个新的窗口，在mainlayout上  
    if (!isExist) {
        G.progress.loading();
        $("#mainTabs").tabs("add", {
            id: tabId,
            title: tabname,
            selected: true,
            closable: closable,
            height: 50,
            content: "<iframe src='" + url + "' style='width:100%;height:100%'  frameborder='no' border='0' marginwidth='0' marginheight='0' />"
        });
        var frames = $("#mainTabs").tabs("getSelected").find("iframe");
        if (frames.length > 0) {
            var fram = $("#mainTabs").tabs("getSelected").find("iframe")[0];
            $(fram).on("load",//等待iframe加载完成
                function () {
                    G.progress.loaded();
                }
            );
        }
    }
    else {
        $("#mainTabs").tabs("selectById", tabId);
    }
}

//check user loged in
function isLogin() {
    //var isLogin = G.auth.isLogin();
    //console.info("is login:",isLogin);
    return G.auth.isLogin();;
}

//redirect to login page
function redirect() {
    //alert(G.auth.oauthGrantUrl);
    window.top.location.href = G.auth.oauthGrantUrl;
}

if (!isLogin()) {
    redirect();
}


$(function () {
    var menuApiUrl = G.consts.apiPublicUrl + "account/menu";
    $.ajax({
        url: menuApiUrl,
        type: "GET",
        dataType: "JSON",
        success: function (response) {
            if (!response.isAuthenticated) {
                redirect();
            }
            $("#mytree").tree({
                data: response.menu,
                onLoadSuccess: function (node, data) {
                    $("#mytree").tree("collapseAll");
                    $("#mytree").fadeIn(100);
                    var target = data[0];
                    //addIframeTab(target.text, target.identifyCode, target.requestUrl, false);
                    addNewTab(target.text, target.identifyCode, target.requestUrl, false);
                },
                onBeforeSelect: function (node) {
                    // 判断是否是叶子节点  
                    var isLeaf = $(this).tree("isLeaf", node.target);
                    if (isLeaf) {
                        //addIframeTab(node.text, node.identifyCode, node.requestUrl, true);
                        addNewTab(node.text, node.identifyCode, node.requestUrl, true);
                    }
                }
            });
        }
    });

    //点击事件  
    $("#mytree").tree({
        onClick: function (node) {
            if ($("#mytree").tree("isLeaf", node.target)) {
            } else {
                $(this).tree("toggle", node.target);
                $(".tree li").removeClass("active");
                $(node.target).closest("li").addClass("active");
            }

        }
    });
});