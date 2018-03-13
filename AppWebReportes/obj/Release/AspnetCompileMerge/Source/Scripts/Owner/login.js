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
        Acceder();
    });
});