//------------------------------------------------------------------------------------------
// 通用AJAX错误处理
function onAjaxError(XMLHttpRequest, textStatus, errorThrown) {
    alert("异常情况：" + XMLHttpRequest.status)
}
// 通用AJAX JSON提取函数（有加载窗）
function ajaxJson(myurl, mydata, myasync, onsuccess) {
    var ajax_option = {
        url: myurl,
        dataType: "json",
        type: "POST",
        data: mydata,
        async: myasync,
        error: function (r, s, e) { onAjaxError(r, s, e); },
        success: function (s) {
            onsuccess(s);
        }
    };
    $.ajax(ajax_option);
}
// 通用AJAX数据投递函数（有加载窗）
function ajaxLoad(myurl, mydata, myasync, onsuccess, method) {
    if (!!!method) method = "POST";
    var ajax_option = {
        url: myurl,
        dataType: "html",
        type: method,
        data: mydata,
        async: myasync,
        error: function (r, s, e) { onAjaxError(r, s, e); },
        success: function (s) { onsuccess(s); }
    };
    $.ajax(ajax_option);
}

// 通用AJAX界面刷新函数（有加载窗）
function ajaxShow(myurl, mydata, mydiv) {
    ajaxLoad(myurl, mydata, true, function (s) {
        $(mydiv).html(s).scrollTop(0);
    });
}

// 通用AJAX界面刷新函数（有加载窗）---带回调函数的
function ajaxShowWithCallBack(myurl, mydata, mydiv,callback) {
    ajaxLoad(myurl, mydata, true, function (s) {
        $(mydiv).html(s).scrollTop(0);
        if (typeof(callback) == "function") {
            callback();
        }
    });
}