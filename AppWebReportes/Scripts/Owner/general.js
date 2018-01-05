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
$(function () {
    $('[type=search]').addClass("col-7");
});