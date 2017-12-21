$( window ).resize(function() {
    if($(window).width() < 481) //Celulares
    {
        $("#chart_div").hide();
        $("#lblNombre").hide();
        $("#imgPerfil").hide();
        $("#btnCerrarSesion").hide();
    } else {
        if($(window).width() < 769) //Tabletas 
        {
            $("#chart_div").show();
            $("#lblNombre").show();
            $("#imgPerfil").show();
            $("#btnCerrarSesion").show();
        } else {
            if($(window).width() < 1200) // laptops, PCs 
            {
                $("#chart_div").show();
                $("#lblNombre").show();
                $("#imgPerfil").show();
                $("#btnCerrarSesion").show();
            }
        }
    }
});