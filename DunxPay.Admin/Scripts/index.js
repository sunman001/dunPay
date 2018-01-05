$(document).ready(function () {
    //隐藏展示
    $(".top-btn").click(function () {
        $(this).toggleClass('active');
        $(this).parent().find('.dropdown-menu').toggle();
    });

    //左导航
    $('.nav > li > a').on('click', function () {
        var item = $(this).parent().find('.submenu');
        if (item) {
            $('.submenu').hide(200);
            var ds = $(this).parent().find('.submenu').css("display");
            if (ds == "block") {
                $('.nav > li').removeClass('active');
            } else {
                $(this).parent().find('.submenu').show(200);
            }
        }
        $('.nav > li').removeClass('active');
        $(this).parent().addClass('active');
    });

    //二级导航
    $(".submenu > li").on('click', function () {
        $('.submenu > li').removeClass('active');
        $(this).addClass('active');
        $('.container').removeClass('nav-small');
        $('.nav-small .nav > li').unbind('hover');
    });

    //隐藏左导航
    $('.header-nav .btn-bars').click(function () {
        $('.container').toggleClass('nav-small');
    });

    //左导航缩小
    $('.nav-small .nav > li').hover(function () {
        var wh = parseInt($(".nav-small .nav").width());
        if (wh == 64) {
            $(this).addClass('active');
            $(this).find('.submenu').show(200);
        }
    }, function () {
        var wh = parseInt($(".nav-small .nav").width());
        if (wh == 64) {
            $(this).removeClass('active');
            $(this).find('.submenu').hide(200);
        }
    });

    //换主题
    var user = 0;
    $(".head-btn-user").click(function () {
        alert("1111");
        if (user == 0) {
            $(" .dropdown-menu").show(200);
            $(this).addClass("active");
            user = 1;
        } else {
            $(" .dropdown-menu").hide(200);
            $(this).removeClass("active");
            user = 0;
        }
    });

});