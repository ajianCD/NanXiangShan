var posX;
var posY;
var layerID;
var NowX;
var NowY;
$(function () {
    //alert(getCookieValue("LoginWay1Y") + ":" + getCookieValue("LoginWay1X"));
    $("#LoginWay1").css({ "top": getCookieValue("LoginWay1Y") + "px", "left": getCookieValue("LoginWay1X") + "px" });
    $("#LoginWay2").css({ "top": getCookieValue("LoginWay2Y") + "px", "left": getCookieValue("LoginWay2X") + "px" });
    $("#LoginWay2").hide();
});
//鼠标点击
function MoveLayer(id, e) {
    if (!e) e = window.event;//如果是IE
    //alert("width:" + $("#" + id).width() + ": height:" + $("#" + id).height());
    posX = e.clientX - parseInt($("#" + id).position().left);
    posY = e.clientY - parseInt($("#" + id).position().top);
    layerID = id;
    //鼠标移动
    document.onmousemove = function (ev) {
        if (ev === null) ev = window.event;//如果是IE

        //设置不超出浏览器
        var MaxLeft = $(window).width() - $("#" + id).width() - 10;
        var MaxTop = $(window).height() - $("#" + id).height() - 10;
        NowX = (ev.clientX - posX) >= 0 ? (ev.clientX - posX) : 0;
        NowY = (ev.clientY - posY) >= 0 ? (ev.clientY - posY) : 0;
        if ((ev.clientX - posX) > MaxLeft)
            NowX = MaxLeft;
        if ((ev.clientY - posY) > MaxTop)
            NowY = MaxTop;

        $("#" + id).css({ "top": NowY, "left": NowX });
    }
}
//鼠标离开
document.onmouseup = function (e) {
    document.onmousemove = null;
    console.log("鼠标离开时坐标X：" + NowX + " Y:" + NowY);
    var path = location.href;
    addCookie(layerID + "X", NowX, 10, path);
    addCookie(layerID + "Y", NowY, 10, path);
    //alert(getCookieValue(layerID+"Y") + ":" + getCookieValue(layerID+"X"));
}
//切换验证码
function ChangeCode() {
    $("#img_validation").attr("src", "/ValidationCode/CreatImage?" + Math.random());
}

//得到客户端IP
function GetIp() {
    $.ajax({
        url: '@Url.Action("GetUserIp")',
        type: 'post',
        success: function (data) {
            if (data.Success) {
                //alert(data.UserIp);
            }
        },
        error: function (xhr) {
            alert("服务器发生异常，请稍后再试！");
        }
    });
}

function ChangeImg() {
    $("#LoginImg").attr("src", "/Images/btnLogin3.jpg");
}

function dot() {
    $("#LoginImg").attr("src", "/Images/btnLogin1.jpg");
}

function Login() {
    var vName = $('#Name').val();
    var vPwd = $('#Password').val();
    if (vName === '' || vPwd === '') {
        layer.alert("用户名/密码不能为空！", { icon: 2, title: "温馨提示" });
        return;
    }
    //layer.alert("Name:" + vName + "; Pwd:" + vPwd);
    $.ajax({
        type: 'post',
        data: { Name: vName, Password: vPwd },
        url: '/Admin/Login',
        success: function (db) {
            if (db.result) {
                location.href = "/Admin/Family";
            } else {
                //alert(db.Message);
                layer.alert(db.message);
                //$("#LoginWay1").hide();
                //$("#LoginWay2").show();
            }
        },
        error: function (e) {
            alert(e);
        }
    });
    return;

}

