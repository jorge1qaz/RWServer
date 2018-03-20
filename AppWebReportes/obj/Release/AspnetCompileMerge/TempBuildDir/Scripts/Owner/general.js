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
var ruta = "../..";
var msgPageError = false;
try {
    console.log(dash);
    ruta = dash;
} catch (e) {
    ruta = "../..";
}
try {
    console.log(msgError);
    msgPageError = msgError;
} catch (e) {
    msgPageError = false;
}
function ValidateAsynchronousAccess() {
    $.ajax({
        type: "POST",
        url: ruta + "/Acceso.aspx/ValidateAsynchronousAccess",
        data: "{idCliente: '" + localStorage.getItem("IdUser").trim() + "',  privateIP: '" + localStorage.getItem("privateIP").trim() + "', publicIP: '" + localStorage.getItem("ipPublic").trim() + "' }",
        contentType: "application/json",
        dataType: "json",
        async: true,
        success: function (msg, data) {
            switch (msg.d) {
                case 0: // Todo ok
                    break;
                case 1: // Ip privada
                    if (data) {
                        window.location.href = localStorage.getItem("pageTruncate1").trim().replace("tipoReporte=5", "tipoReporte=8");
                        return false;
                    }
                    break;
                case 2: // Ip privada y publica
                    if (data) {
                        window.location.href = localStorage.getItem("pageTruncate2").trim().replace("tipoReporte=6", "tipoReporte=9");
                        return false;
                    }
                    break;
                    //tipoReporte=5
                case 3: // Cuando no existe nada
                    break;
                case 4: // Cuando ha caducado la sesión
                    if (data) {
                        window.location.href = localStorage.getItem("pageTruncate1").trim().replace("tipoReporte=5", "tipoReporte=7");
                        return false;
                    }
                    break;
                default:
                    break;
            }
        }, error: function (msg) {
            window.location.href = localStorage.getItem("pageTruncate1").trim().replace("tipoReporte=5", "tipoReporte=7");
            return false;
        }
    });
}

function timedCount() {
    if (msgPageError == false) {
        ValidateAsynchronousAccess();
    }
    t = setTimeout(function () { timedCount() }, 5000);
}

async function asynCall() {
    await timedCount();
}
asynCall();


$(document).ready(function () {
    $('[type=search]').addClass("col-7");
    $('[data-toggle="tooltip"]').tooltip();
    $("th").addClass("text-center");
    $("#blockOptions").find("label").addClass("text-white");
    switch (device) {
        case "desktop":
            $("#MainContent_imageDashboardBlock").removeClass("kill");
            break;
        case "movil":
            $("#MainContent_imageDashboardBlock").addClass("kill");
            break;
    }
});