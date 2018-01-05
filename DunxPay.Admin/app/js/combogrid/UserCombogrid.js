//加载开发者列表 
$('#userid').combogrid({
    panelWidth: 600,
    panelHeight: 300,
    mode: 'remote',
    url: G.http.buildUrl("User/comboList"),
    idField: 'uId',
    textField: 'uRealname',
    sortName: "uRealname", //默认排序字段
    sortOrder: "desc", //默认排序(asc/desc)
    striped: true, //奇偶行不同背景
    nowrap: true,
    pagination: true, ////True 就会在 datagrid 的底部显示分页栏
    rownumbers: true, //显示行号
    singleSelect: true,
    columns: [[
        { field: 'id', checkbox: true },
        { field: 'uEmail', title: '登录邮件地址', width: 200, sortable: true },
        { field: 'uRealname', title: '真实姓名', width: 200, sortable: true },
        { field: 'uPhone', title: '联系电话', width: 200, sortable: true },
        {
            field: 'uState', title: '账户状态', width: 100, formatter: function (value) {
                if (value == 0) {
                    return "<font style='color:red' >冻结 </font>";
                } else {
                    return "<font style='color:green' >正常</font>";
                }
            }
        },
        {
            field: 'uAuditstate', title: '审核状态', width: 100, formatter: function (value) {
                if (value == 0) {
                    return "<font style='color:orange' >等待审核 </font>";
                } else if (value == 1) {
                    return "<font style='color:green' >通过 </font>";
                } else {
                    return "<font style='color:red' >未通过 </font>";
                }
            }
        }
    ]],
    pageNumber: 1, //初始化页码
    remoteSort: true, //是否数据源排序
    pageSize: 20, //初始化分页大小
    pageList: [10, 20, 30, 40, 50, 60, 70, 80], //初始化页面尺寸的选择列表
    loadMsg: "正在查询数据..." //加载提示

});
//查询
window.searchs = function () {
    $("#userid").combogrid("grid").datagrid("reload",
        {
            searchType: $("#searchType").val(),
            keyword: $("#sea_names").val()

        });
};