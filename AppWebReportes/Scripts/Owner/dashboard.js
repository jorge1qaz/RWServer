$(document).ready(function () {
    var mesProcesamiento;
    var fecha = new Date();
    var anio = fecha.getFullYear();
    var mes = fecha.getMonth() + 1;
    var dia = fecha.getDate();
    if (mes < 10) {
        mes = '0' + mes;
    }
    if (dia < 10) {
        dia = '0' + dia;
    }
    var fechaCompleto = anio + "." + mes + "." + dia;
    var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];

    $('[data-toggle="tooltip"]').tooltip();
    var statusRCP = 0;
    var statusRMUP = 0;
    var statusRMNA = 0;
    var statusREDRPMS = 0;
    var statusRFCD = 0;
    var statusHoverIcons = 1;
    // Inicialización de cajas
    $("#blockCompanyDetailsForRCP").toggle();
    $("#blockCompanyDetailsForRMU").toggle();
    $("#blockCompanyDetailsForRMND").toggle();
    $("#blockCompanyDetailsForREDRPMS").toggle();
    $("#btnTriggerModalREDRPMS").toggle();
    $("#blockCompanyDetailsForEFNT").toggle();
    $("#btnTriggerModalEFNT").toggle();
    $("#blockCompanyDetailsForFCD").toggle();
    $("#btnTriggerModalFCD").toggle();
    // buttons movile
    $("#btnMovil_TriggerModalREDRPMS").toggle();
    $("#btnMovil_TriggerModalEFNT").toggle();
    $("#btnMovil_TriggerModalFCD").toggle();
    //Cuentas pendientes
    $("#btnCuentasPendientes").on("click", function () {
        if (statusRCP === 0) {
            $("#btnCuentasPendientes").text("Ocultar detalles");
            $("#blockCuentasPendientes").removeClass("col-lg-4 col-md-6").addClass("col-md-12");
            $("#blockFlujoCajaDetallado").hide("200");
            $("#blockMargenUtilidad").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            $("#blockEstadoResultadoPMS").hide("200");
            $("#blockEstadosFinancierosNT").hide("200");
            $("#img_cuentas_pendientes").addClass("align-icons");
            statusRCP = 1;
            statusHoverIcons = 0;
        } else {
            $("#btnCuentasPendientes").text("Ver detalles");
            $("#blockCuentasPendientes").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockFlujoCajaDetallado").show("200");
            $("#blockMargenUtilidad").show("200");
            $("#blockMinegocioAlDia").show("200");
            $("#blockEstadoResultadoPMS").show("200");
            $("#blockEstadosFinancierosNT").show("200");
            $("#img_cuentas_pendientes").removeClass("align-icons");
            statusRCP = 0;
            statusHoverIcons = 1;
        }
        $("#blockCompanyDetailsForRCP").toggle("slow");
    });
    //Margen de utilidad
    $("#btnMargenUtilidad").on("click", function () {
        if (statusRMUP === 0) {
            $("#btnMargenUtilidad").text("Ocultar detalles");
            $("#blockMargenUtilidad").removeClass("col-lg-4 col-md-6").addClass("col-md-12");
            $("#blockFlujoCajaDetallado").hide("200");
            $("#blockCuentasPendientes").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            $("#blockEstadoResultadoPMS").hide("200");
            $("#blockEstadosFinancierosNT").hide("200");
            $("#img_margen_de_utilidad").addClass("align-icons");
            statusRMUP = 1;
            statusHoverIcons = 0;
        } else {
            $("#btnMargenUtilidad").text("Ver detalles");
            $("#blockMargenUtilidad").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockFlujoCajaDetallado").show("200");
            $("#blockCuentasPendientes").show("200");
            $("#blockMinegocioAlDia").show("200");
            $("#blockEstadoResultadoPMS").show("200");
            $("#blockEstadosFinancierosNT").show("200");
            $("#img_margen_de_utilidad").removeClass("align-icons");
            statusRMUP = 0;
            statusHoverIcons = 1;
        }
        $("#blockCompanyDetailsForRMU").toggle("slow");
    });
    //Mi negocio al día
    $("#btnMinegocioAlDia").on("click", function () {
        if (statusRMNA === 0) {
            $("#btnMinegocioAlDia").text("Ocultar detalles");
            $("#blockMinegocioAlDia").removeClass("col-lg-4 col-md-6").addClass("col-md-12");
            $("#blockFlujoCajaDetallado").hide("200");
            $("#blockCuentasPendientes").hide("200");
            $("#blockMargenUtilidad").hide("200");
            $("#blockEstadoResultadoPMS").hide("200");
            $("#blockEstadosFinancierosNT").hide("200");
            $("#img_mi_negocio_al_dia").addClass("align-icons");
            statusRMNA = 1;
            statusHoverIcons = 0;
        } else {
            $("#btnMinegocioAlDia").text("Ver detalles");
            $("#blockMinegocioAlDia").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockFlujoCajaDetallado").show("200");
            $("#blockCuentasPendientes").show("200");
            $("#blockMargenUtilidad").show("200");
            $("#blockEstadoResultadoPMS").show("200");
            $("#blockEstadosFinancierosNT").show("200");
            $("#img_mi_negocio_al_dia").removeClass("align-icons");
            statusRMNA = 0;
            statusHoverIcons = 1;
        }
        $("#blockCompanyDetailsForRMND").toggle("slow");
    });
    // Estado de resultado por mes separado
    $("#btnEstadoResultadoPMS").on("click", function () {
        if (statusREDRPMS === 0) {
            $("#btnEstadoResultadoPMS").text("Ocultar detalles");
            $("#blockEstadoResultadoPMS").removeClass("col-lg-4 col-md-6").addClass("col-md-12");
            $("#blockFlujoCajaDetallado").hide("200");
            $("#blockCuentasPendientes").hide("200");
            $("#blockMargenUtilidad").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            $("#blockEstadosFinancierosNT").hide("200");
            $('#modalREDRPMS').modal('show');
            $("#img_estado_de_resultado").addClass("align-icons");
            statusREDRPMS = 1;
            statusHoverIcons = 0;
        } else {
            $("#btnEstadoResultadoPMS").text("Ver detalles");
            $("#blockEstadoResultadoPMS").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockFlujoCajaDetallado").show("200");
            $("#blockCuentasPendientes").show("200");
            $("#blockMargenUtilidad").show("200");
            $("#blockMinegocioAlDia").show("200");
            $("#blockEstadosFinancierosNT").show("200");
            $("#img_estado_de_resultado").removeClass("align-icons");
            statusREDRPMS = 0;
            statusHoverIcons = 1;
        }
        switch (device) {
            case "desktop":
                $("#btnTriggerModalREDRPMS").toggle("slow");
                break;
            case "movil":
                $("#btnMovil_TriggerModalREDRPMS").toggle("slow");
                break;
        }
        $("#blockCompanyDetailsForREDRPMS").toggle("slow");
    });
    // Estados financieros NIIF y tributario
    $("#btnEFNT").on("click", function () {
        if (statusREDRPMS === 0) {
            $("#btnEFNT").text("Ocultar detalles");
            $("#blockEstadosFinancierosNT").removeClass("col-lg-4 col-md-6").addClass("col-md-12");
            $("#blockFlujoCajaDetallado").hide("200");
            $("#blockCuentasPendientes").hide("200");
            $("#blockMargenUtilidad").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            $("#blockEstadoResultadoPMS").hide("200");
            $('#modalEFNT').modal('show'); //Id Modal
            $("#img_estados_financieros").addClass("align-icons");
            statusREDRPMS = 1;
            statusHoverIcons = 0;
        } else {
            $("#btnEFNT").text("Ver detalles");
            $("#blockEstadosFinancierosNT").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockFlujoCajaDetallado").show("200");
            $("#blockCuentasPendientes").show("200");
            $("#blockMargenUtilidad").show("200");
            $("#blockMinegocioAlDia").show("200");
            $("#blockEstadoResultadoPMS").show("200");
            $("#img_estados_financieros").removeClass("align-icons");
            statusREDRPMS = 0;
            statusHoverIcons = 1;
        }
        switch (device) {
            case "desktop":
                $("#btnTriggerModalEFNT").toggle("slow");
                break;
            case "movil":
                $("#btnMovil_TriggerModalEFNT").toggle("slow");
                break;
        }
        $("#blockCompanyDetailsForEFNT").toggle("slow");
    });
    $("#btnTriggerModalEFNT").on("click", function () {
        $('#modalEFNT').modal('show');
    });
    $("#btnTriggerModalEFNT").on("click", function () {
        $('#modalEFNT').modal('show');
    });
    //Flujo de caja detallado
    $("#btnFCD").on("click", function () {
        if (statusRFCD === 0) {
            $("#btnFCD").text("Ocultar detalles");
            $("#blockFlujoCajaDetallado").removeClass("col-lg-4 col-md-6").addClass("col-md-12");
            $("#blockEstadosFinancierosNT").hide("200");
            $("#blockCuentasPendientes").hide("200");
            $("#blockMargenUtilidad").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            $("#blockEstadoResultadoPMS").hide("200");
            $('#modalFCD').modal('show'); //Id Modal
            $("#img_flujo_de_caja").addClass("align-icons");
            statusRFCD = 1;
            statusHoverIcons = 0;
        } else {
            $("#btnFCD").text("Ver detalles");
            $("#blockFlujoCajaDetallado").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockEstadosFinancierosNT").show("200");
            $("#blockCuentasPendientes").show("200");
            $("#blockMargenUtilidad").show("200");
            $("#blockMinegocioAlDia").show("200");
            $("#blockEstadoResultadoPMS").show("200");
            $("#img_flujo_de_caja").removeClass("align-icons");
            statusRFCD = 0;
            statusHoverIcons = 1;
        }
        $("#blockCompanyDetailsForFCD").toggle("slow");
        switch (device) {
            case "desktop":
                $("#btnTriggerModalFCD").toggle("slow");
                break;
            case "movil":
                $("#btnMovil_TriggerModalFCD").toggle("slow");
                break;
        }
    });
    $("#btnTriggerModalFCD").on("click", function () {
        $('#modalFCD').modal('show');
    });
    $(".card").css("margin-bottom", "15px");
    // Progress bar
    $("form").on("submit", function (event) {
        $('#modalProgress').modal('show');
        var porcentajeAvance = 0;
        var id = setInterval(frame, 80);
        function frame() {
            if (porcentajeAvance >= 100) {
                porcentajeAvance = 0;
            } else {
                porcentajeAvance++;
                progressBar.style.width = porcentajeAvance + '%';
            }
        }
    });
    //Picker
    $(function () {
        $('#MainContent_txtFechaInicio').datepicker({
            autoHide: true,
            zIndex: 2048,
            format: 'dd/mm/yyyy',
            language: 'es-ES',
        });
        $('#MainContent_txtFechaInicio').keypress(function (event) {
            if (event.keyCode === 10 || event.keyCode === 13)
                event.preventDefault();
        });
    });
    // Validaciones
    var formulario = $("#Formulario");
    $(formulario).validate({
        rules: {
            ctl00$MainContent$txtFrecuenciaPerdiodoFCD: {
                required: true,
                integer: true,
                minlength: 1,
                maxlength: 2
            },
            ctl00$MainContent$txtNumeroPeriodosFCD: {
                required: true,
                integer: true,
                minlength: 1,
                maxlength: 2
            }
        },
        messages: {
            ctl00$MainContent$txtFrecuenciaPerdiodoFCD: {
                required: "Este campo es obligatorio",
                integer: "Sólo se admiten números enteros",
                minlength: "El número mínimo de carácteres es 1",
                maxlength: "El número máximo de carácteres es 2"
            },
            ctl00$MainContent$txtNumeroPeriodosFCD: {
                required: "Este campo es obligatorio",
                integer: "Sólo se admiten números enteros",
                minlength: "El número mínimo de carácteres es 1",
                maxlength: "El número máximo de carácteres es 2"
            }
        },
        errorElement: "em",
        errorPlacement: function (error, element) {
            error.addClass("text-muted text-danger");
            if (element.prop("type") === "checkbox") {
                error.insertAfter(element.parent("label"));
            } else {
                error.insertAfter(element);
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).parents("input").addClass("text-danger").removeClass("text-sucess");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents("input").addClass("text-sucess").removeClass("text-danger");
        }
    });
    // hover iconos
   
    function hoverIconos() {
        if (statusHoverIcons === 1) {
            $("#blockCuentasPendientes").hover(function () {
                if (statusHoverIcons === 1) {
                    $("#img_cuentas_pendientes").attr("src", "../Images/cuentas_pendientes_activated.png");
                }
            }, function () {
                if (statusHoverIcons === 1) {
                    $("#img_cuentas_pendientes").attr("src", "../Images/cuentas_pendientes_default.png");
                }
            });
            $("#blockMargenUtilidad").hover(function () {
                if (statusHoverIcons === 1) {
                    $("#img_margen_de_utilidad").attr("src", "../Images/margen_de_utilidad_activated.png");
                }
            }, function () {
                if (statusHoverIcons === 1) {
                    $("#img_margen_de_utilidad").attr("src", "../Images/margen_de_utilidad_default.png");
                }
            });    
            $("#blockMinegocioAlDia").hover(function () {
                if (statusHoverIcons === 1) {
                    $("#img_mi_negocio_al_dia").attr("src", "../Images/mi_negocio_al_dia_activated.png");
                }
            }, function () {
                if (statusHoverIcons === 1) {
                    $("#img_mi_negocio_al_dia").attr("src", "../Images/mi_negocio_al_dia_default.png");
                }
            });    
            $("#blockEstadoResultadoPMS").hover(function () {
                if (statusHoverIcons === 1) {
                    $("#img_estado_de_resultado").attr("src", "../Images/estado_de_resultado_activated.png");
                }
            }, function () {
                if (statusHoverIcons === 1) {
                    $("#img_estado_de_resultado").attr("src", "../Images/estado_de_resultado_default.png");
                }
                });
            $("#blockEstadosFinancierosNT").hover(function () {
                if (statusHoverIcons === 1) {
                    $("#img_estados_financieros").attr("src", "../Images/estados_financieros_activated.png");
                }
            }, function () {
                if (statusHoverIcons === 1) {
                    $("#img_estados_financieros").attr("src", "../Images/estados_financieros_default.png");
                }
                });
            $("#blockFlujoCajaDetallado").hover(function () {
                if (statusHoverIcons === 1) {
                    $("#img_flujo_de_caja").attr("src", "../Images/flujo_de_caja_activated.png");
                }
            }, function () {
                if (statusHoverIcons === 1) {
                    $("#img_flujo_de_caja").attr("src", "../Images/flujo_de_caja_default.png");
                }
            });
        }
    }
    hoverIconos();
});
