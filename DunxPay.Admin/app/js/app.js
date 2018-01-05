
//处理选择不同的平台不同的逻辑
$('#platformids').combobox({
    onChange: function (vaule) {
        if (vaule == 3) {
            document.getElementById("tbhddz").style.display = "";
            isH5("3");
        } else {
            IsSdk(vaule);
            document.getElementById("tbhddz").style.display = "none";
        }
    }
});

//判断是否为h5平台
function isH5(obj) {
    document.getElementById("paytype_5").checked = false;
    if (obj == 3) {
        if ($("#paytype_6").data("stat") == 1) {
            document.getElementById("paytype_6").disabled = false;
        }
        if ($("#paytype_7").data("stat") == 1) {
            document.getElementById("paytype_7").disabled = false;
        }
        var state = $("#paytype_5").data("stat");
        if (state == 1) {
            document.getElementById("paytype_5").disabled = true;
        }
    }
}
//判断是否为sdk时调用
function IsSdk(obj) {
    if (obj == 1 || obj == 2) {

        document.getElementById("paytype_6").checked = false;
        document.getElementById("paytype_7").checked = false;
        if ($("#paytype_5").data("stat") == 1) {
            document.getElementById("paytype_5").disabled = false;
        }
        if ($("#paytype_6").data("stat") == 1) {
            document.getElementById("paytype_6").disabled = true;
        }
        if ($("#paytype_7").data("stat") == 1) {
            document.getElementById("paytype_7").disabled = true;
        }
    }
}
//保存
function yzdata( url ) {

    var form = $("#dx-form");
    if (!form.form("validate")) {
        $.messager.alert('警告', '必填项没有填写完整！');
        return false;
    } else {
        var name = $.trim($("#name").textbox("getValue"));
        var platformids = $.trim($("#platformids").combobox("getValue"));
        debugger;
        var valArr = new Array;
        $('input[name="zflx"]:checked').each(function (i) {
            valArr[i] = $(this).val();
        });
        var vals = valArr.join(',');
        if (vals == "") {
            $.messager.alert('警告', '必须选择支付类型！');
            return false;
        }
        var paytypeParentId = $.trim($("#paytypeParentId").combobox("getValue"));
        if (paytypeParentId <= 0) {
            $.messager.alert('警告', '请选择应用类型！');
            return false;
        }
        var paytypeId = $.trim($("#paytypeId").combobox("getValue"));
        if (paytypeId <= 0) {
            $.messager.alert('警告', '请选择应用类型！');
            return false;
        }
        var notifyurl = $.trim($("#notifyurl").textbox("getValue"));
        var showurl = $.trim($("#showurl").textbox("getValue"));
        var userid = $.trim($("#userid").combogrid("getValue"));
        var appurl = $.trim($("#appurl").textbox("getValue"));
        var appsynopsis = $.trim($("#appsynopsis").textbox("getValue"));
        var id = $("#id").val();
        if (platformids == 3) {
            var testurl = /^((https|http)?:\/\/)[^\s]+/;
            if (!testurl.test($.trim(showurl))) {
                $.messager.alert('警告', '请正确填写回调地址(必须以http://或者https://开头)！');
                return false;
            }
        }
        var a_paymode_id = vals;
        var data = {
            a_id: id,
            a_user_id: userid,
            a_name: name,
            a_platform_id: platformids,
            a_paymode_id: a_paymode_id,
            a_apptype_id: paytypeId,
            a_notifyurl: notifyurl,
            a_showurl: showurl,
            a_appurl: appurl,
            a_appsynopsis: appsynopsis
        };
        $.ajax({
            url: G.http.buildUrl(""+url+""),
            dataType: 'json',
            type: 'post',
            data: data,
            success: function (response) {
                if (response.isSuccess) {
                    dialog.closePopup("提示", response.message, "addApp", "tableAPP");
                }
                else {
                    $.messager.alert('提示', response.message);
                }
            }
        });
    }
}
function save() {
    yzdata("App/Create");
}

//修改
function Edits() {
    yzdata("App/Edit");
}