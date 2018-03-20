var truncateAccess = 0;
function ComprobarUsuario() {
    var user = $("#Contenido_txtCorreo").val();
    $.ajax({
        type: "POST",
        url: "Acceso.aspx/ComprobarUsuarioKey",
        data: "{paramIdCliente: '" + user + "' }",
        contentType: "application/json",
        dataType: "json",
        success: function (msg) {
            if (msg.hasOwnProperty("d")) {
                if (msg.d == true) {
                    $("#Contenido_blockCorreo").css("display", "none");
                    $("#btnHtmlComprobarUsuario").css("display", "none");
                    $("#Contenido_txtCorreo").css("display", "none");
                    $("#Contenido_blockContrasenia").css("display", "block");
                    $("#Contenido_btnLinkCambiarContrasenia").css("display", "inline-block");
                    $("#btnHtmlAcceder").css("display", "inline-block");
                    $("#Contenido_txtContrasenia").focus();
                } else {
                    $("#Contenido_lblDoesNotExistUser").text("No pudimos encontrar su cuenta de SmartReport");
                }
            } else {
                if (msg == true) {
                    $("#Contenido_blockCorreo").css("display", "none");
                    $("#btnHtmlComprobarUsuario").css("display", "none");
                    $("#Contenido_txtCorreo").css("display", "none");
                    $("#Contenido_blockContrasenia").css("display", "block");
                    $("#Contenido_btnLinkCambiarContrasenia").css("display", "inline-block");
                    $("#btnHtmlAcceder").css("display", "inline-block");
                    $("#Contenido_txtContrasenia").focus();
                } else {
                    $("#Contenido_lblDoesNotExistUser").text("No pudimos encontrar su cuenta de SmartReport");
                }
            }
        }, error: function (msg) {
            alert("error " + msg.responseText);
        }
    });
}
function ComprobarUsuarioKey(e) {
    if (e.keyCode == 13) {
        ComprobarUsuario();
    }
}
function Acceder() {
    var user = $("#Contenido_txtCorreo").val();
    var contrasenia = $("#Contenido_txtContrasenia").val();
    $.ajax({
        type: "POST",
        url: "Acceso.aspx/AccederKey",
        data: "{paramIdCliente: '" + user + "', paramContrasenia: '" + contrasenia + "' }",
        contentType: "application/json",
        dataType: "json",
        async: true,
        success: function (msg, data) {
            switch (msg.d) {
                case "éxito":
                    if (data) {
                        trigger();
                        $("#Contenido_lblErrorPassword").text("");
                        window.location.href = decodeURIComponent(page);
                        return false;
                    }
                    break;
                case "comprobación de cuenta activada":
                    $("#Contenido_lblErrorPassword").text("Tu cuenta no esta activada, por favor revisa tu correo.");
                    break;
                case "comprobación de contraseña":
                    $("#Contenido_lblErrorPassword").text("La contraseña es incorrecta. Vuelve a intentarlo.");
                    break;
                default:
                    alert("Algo anda mal");
                    break;
            }
        }, error: function (msg) {
            alert("error " + msg.responseText);
        }
    });
}
// Desde aquí
var privateIP = ""
function timedCount() {
    privateIP = $("#hiddenLabel").text();
    t = setTimeout(function () { timedCount() }, 750);
}
timedCount();

function ValidateAccess() {
    var idCliente = $("#Contenido_txtCorreo").val();
    $.ajax({
        type: "POST",
        url: "Acceso.aspx/ValidateAccess",
        data: "{idCliente: '" + idCliente + "',  privateIP: '" + privateIP + "', publicIP: '" + publicIP + "' }",
        contentType: "application/json",
        dataType: "json",
        async: true,
        success: function (msg, data) {
            switch (msg.d) {
                case 0:
                    alert("exito");
                    Acceder();
                    break;
                case 1:
                    truncateAccess == 1;
                    alert("1");

                    if (data) {
                        window.location.href = decodeURIComponent(pageTruncate1);
                        return false;
                    }
                    break;
                case 2:
                    alert("2");
                    if (data) {
                        window.location.href = decodeURIComponent(pageTruncate2);
                        return false;
                    }
                    truncateAccess == 1
                    break;
                case 3:
                    alert("3");
                    truncateAccess == 0;
                    break;
                default:
                    alert("default");
                    truncateAccess == 0;
                    break;
            }
        }, error: function (msg) {
            alert("error " + msg.responseText);
        }
    });
}
function AccederKey(e) {
    if (e.keyCode == 13) {
        ValidateAccess();
    }
}
$(document).ready(function () {
    var $blockContrasenia = $("#blockContrasenia");
    var $btnAcceder = $("#btnAcceder");
    var $btnCerrarSesion = $("#btnCerrarSesion");
    var $linkCambiarContrasenia = $("#linkCambiarContrasenia") 
    $blockContrasenia.hide();
    $btnAcceder.on('click', function () {
        $("#blockCorreo").hide(1000);
        $blockContrasenia.show();
        $btnAcceder.text("Acceder");
    });
    $linkCambiarContrasenia.hover(function () {
        $(this).addClass("green-text");
            }, function () {
                    $(this).removeClass("green-text");
                }      
    );
    $btnCerrarSesion.hover(function () {
        $(this).addClass("green-text")
                .css("cursor","pointer");
            }, function () {
                    $(this).removeClass("green-text");
                }      
    );

    if (initialPage == 1) {
        $("#Contenido_blockCorreo").css(                "display", "block");
        $("#Contenido_blockContrasenia").css(           "display", "none");
        $("#Contenido_btnLinkCambiarContrasenia").css(  "display", "none");
        $("#btnHtmlAcceder").css(                       "display", "none");
    }
    $("#btnHtmlComprobarUsuario").on("click", function () {
        ComprobarUsuario();
    });
    $("#btnHtmlAcceder").on("click", function () {
        ValidateAccess();
    });
});