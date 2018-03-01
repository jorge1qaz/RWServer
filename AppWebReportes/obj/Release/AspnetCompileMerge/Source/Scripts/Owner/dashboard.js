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
    $("#blockCompanyDetailsForRCP").toggle();
    $("#blockCompanyDetailsForRMU").toggle();
    $("#blockCompanyDetailsForRMND").toggle();
    $("#blockCompanyDetailsForREDRPMS").toggle();
    $("#btnTriggerModalREDRPMS").toggle();
    $("#blockCompanyDetailsForEFNT").toggle();
    $("#btnTriggerModalEFNT").toggle();
    $("#blockCompanyDetailsForFCD").toggle();
    $("#btnTriggerModalFCD").toggle();
    $("#btnCuentasPendientes").on("click", function () {
        if (statusRCP === 0) {
            $("#btnCuentasPendientes").text("Ocultar detalles");
            $("#blockCuentasPendientes").removeClass("col-lg-4 col-md-6").addClass("col-md-12");
            $("#blockFlujoCajaDetallado").hide("200");
            $("#blockMargenUtilidad").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            $("#blockEstadoResultadoPMS").hide("200");
            $("#blockEstadosFinancierosNT").hide("200");
            statusRCP = 1;
        } else {
            $("#btnCuentasPendientes").text("Ver detalles");
            $("#blockCuentasPendientes").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockFlujoCajaDetallado").show("200");
            $("#blockMargenUtilidad").show("200");
            $("#blockMinegocioAlDia").show("200");
            $("#blockEstadoResultadoPMS").show("200");
            $("#blockEstadosFinancierosNT").show("200");
            statusRCP = 0;
        }
        $("#blockCompanyDetailsForRCP").toggle("slow");
    });
    $("#btnMargenUtilidad").on("click", function () {
        if (statusRMUP === 0) {
            $("#btnMargenUtilidad").text("Ocultar detalles");
            $("#blockMargenUtilidad").removeClass("col-lg-4 col-md-6").addClass("col-md-12");
            $("#blockFlujoCajaDetallado").hide("200");
            $("#blockCuentasPendientes").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            $("#blockEstadoResultadoPMS").hide("200");
            $("#blockEstadosFinancierosNT").hide("200");
            statusRMUP = 1;
        } else {
            $("#btnMargenUtilidad").text("Ver detalles");
            $("#blockMargenUtilidad").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockFlujoCajaDetallado").show("200");
            $("#blockCuentasPendientes").show("200");
            $("#blockMinegocioAlDia").show("200");
            $("#blockEstadoResultadoPMS").show("200");
            $("#blockEstadosFinancierosNT").show("200");
            statusRMUP = 0;
        }
        $("#blockCompanyDetailsForRMU").toggle("slow");
    });
    $("#btnMinegocioAlDia").on("click", function () {
        if (statusRMNA === 0) {
            $("#btnMinegocioAlDia").text("Ocultar detalles");
            $("#blockMinegocioAlDia").removeClass("col-lg-4 col-md-6").addClass("col-md-12");
            $("#blockFlujoCajaDetallado").hide("200");
            $("#blockCuentasPendientes").hide("200");
            $("#blockMargenUtilidad").hide("200");
            $("#blockEstadoResultadoPMS").hide("200");
            $("#blockEstadosFinancierosNT").hide("200");
            statusRMNA = 1;
        } else {
            $("#btnMinegocioAlDia").text("Ver detalles");
            $("#blockMinegocioAlDia").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockFlujoCajaDetallado").show("200");
            $("#blockCuentasPendientes").show("200");
            $("#blockMargenUtilidad").show("200");
            $("#blockEstadoResultadoPMS").show("200");
            $("#blockEstadosFinancierosNT").show("200");
            statusRMNA = 0;
        }
        $("#blockCompanyDetailsForRMND").toggle("slow");
    });
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
            statusREDRPMS = 1;
        } else {
            $("#btnEstadoResultadoPMS").text("Ver detalles");
            $("#blockEstadoResultadoPMS").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockFlujoCajaDetallado").show("200");
            $("#blockCuentasPendientes").show("200");
            $("#blockMargenUtilidad").show("200");
            $("#blockMinegocioAlDia").show("200");
            $("#blockEstadosFinancierosNT").show("200");
            statusREDRPMS = 0;
        }
        $("#blockCompanyDetailsForREDRPMS").toggle("slow");
        $("#btnTriggerModalREDRPMS").toggle("slow");
    });
    $("#btnEFNT").on("click", function () {
        if (statusREDRPMS === 0) {
            $("#btnEFNT").text("Ocultar detalles");
            $("#blockEstadosFinancierosNT").removeClass("col-lg-4 col-md-6").addClass("col-md-12");
            $("#blockFlujoCajaDetallado").hide("200");
            $("#blockCuentasPendientes").hide("200");
            $("#blockMargenUtilidad").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            $("#blockEstadoResultadoPMS").hide("200");
            $('#modalEFNT').modal('show'); //Id Modal
            statusREDRPMS = 1;
        } else {
            $("#btnEFNT").text("Ver detalles");
            $("#blockEstadosFinancierosNT").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockFlujoCajaDetallado").show("200");
            $("#blockCuentasPendientes").show("200");
            $("#blockMargenUtilidad").show("200");
            $("#blockMinegocioAlDia").show("200");
            $("#blockEstadoResultadoPMS").show("200");
            statusREDRPMS = 0;
        }
        $("#blockCompanyDetailsForEFNT").toggle("slow");
        $("#btnTriggerModalEFNT").toggle("slow");
    });
    $("#btnTriggerModalEFNT").on("click", function () {
        $('#modalEFNT').modal('show');
    });
    $("#btnTriggerModalEFNT").on("click", function () {
        $('#modalEFNT').modal('show');
    });
    $("#btnFCD").on("click", function () {
        if (statusRFCD === 0) {
            $("#btnFCD").text("Ocultar detalles");
            $("#blockFlujoCajaDetallado").removeClass("col-lg-4 col-md-6").addClass("col-md-12");
            $("#blockEstadosFinancierosNT").hide("200");
            $("#blockCuentasPendientes").hide("200");
            $("#blockMargenUtilidad").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            $("#blockEstadoResultadoPMS").hide("200");
            $('#modalFCD').modal('show'); //Id Modal
            statusRFCD = 1;
        } else {
            $("#btnFCD").text("Ver detalles");
            $("#blockFlujoCajaDetallado").removeClass("col-md-12").addClass("col-lg-4 col-md-6");
            $("#blockEstadosFinancierosNT").show("200");
            $("#blockCuentasPendientes").show("200");
            $("#blockMargenUtilidad").show("200");
            $("#blockMinegocioAlDia").show("200");
            $("#blockEstadoResultadoPMS").show("200");
            statusRFCD = 0;
        }
        $("#blockCompanyDetailsForFCD").toggle("slow");
        $("#btnTriggerModalFCD").toggle("slow");
    });
    $("#btnTriggerModalFCD").on("click", function () {
        $('#modalFCD').modal('show');
    });
    $(".card").css("margin-bottom", "15px");

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
});