var widthScreen = $(window).width();
var widthScreenUpdate = 0;
var screen = 0;
$(window).resize(function () {
    widthScreenUpdate = $(window).width();
    screen = Math.abs(widthScreenUpdate - widthScreen);
    if (screen > 60) {
        location.reload(true);
    }
});
$(".card-block").css("border-radius", "6px");
var statusBtnFullScreen = 0;
$("#btnFullScreen").on("click", function () {
    if (statusBtnFullScreen == 0) {
        $("#blockOptions").hide();
        $("#blockReportContent").removeClass("col-md-9").slideUp(100).addClass("col-md-12").fadeIn(400);
        $("#btnFullScreen").text("fullscreen_exit");
        statusBtnFullScreen = 1;
    } else {
        $("#btnFullScreen").text("fullscreen");
        $("#blockReportContent").removeClass("col-md-12").slideUp(100).addClass("col-md-9").fadeIn(400);
        $("#blockOptions").fadeIn(400);
        statusBtnFullScreen = 0;
    }
});
$(function () {
    $('[type=search]').addClass("col-7");
    $('[data-toggle="tooltip"]').tooltip();
});