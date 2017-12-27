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

    var idioma = {
        "sProcessing": "Procesando...",
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "Ningún dato disponible en esta tabla",
        "sInfo": "Mostrando _START_ al _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando 0 al 0 de un total de 0 registros",
        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
        "sInfoPostFix": "",
        "sSearch": "Buscar:",
        "sUrl": "",
        "sInfoThousands": ",",
        "sLoadingRecords": "Cargando...",
        "oPaginate": {
            "sFirst": "Primero",
            "sLast": "Último",
            "sNext": "Siguiente",
            "sPrevious": "Anterior"
        },
        "oAria": {
            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
        },
        buttons: {
            copyTitle: 'Los datos fueron copiados',
            copyInfo: {
                _: 'Copiados %d filas al portapapeles',
                1: 'Copiado 1 fila al portapapeles',
            }
        }
    }
    var listarReporteRCP = function () {
        var dataTableRCP = $('#dataRCP').DataTable({
            "destroy": true,
            "processing": true,
            responsive: true,
            "ajax": "../Cls/" + idCliente.trim() + "/" + "GeneralInfoConta.json",
            "columns": [
                { "data": "a" },
                { "data": "b" },
                { "data": "c" },
                { "data": "d" },
                { "defaultContent": "<i class='material-icons' onclick='redireccionarRCP()' role='button' id='linkRCP' data-toggle='tooltip' data-placement='right' title='Seleccione'>check_circle</i>" }
            ],
            "language": idioma,
            dom: 'Bfrtip',
            "order": [[0, "desc"]]
        });
        GetIdsRCP("#dataRCP", dataTableRCP);
    };
    var listarReporteRMU = function () {
        var dataTableRMU = $('#dataRMU').DataTable({
            "destroy": true,
            "processing": true,
            responsive: true,
            "ajax": "../Cls/" + idCliente.trim() + "/" + "GeneralInfoStock.json",
            "columns": [
                { "data": "a" },
                { "data": "b" },
                { "data": "c" },
                { "data": "d" },
                { "defaultContent": "<i class='material-icons' role='button' id='linkRMU' data-toggle='tooltip' data-placement='right' title='Seleccione'>check_circle</i>" }
            ],
            "language": idioma,
            dom: 'Bfrtip',
            "order": [[0, "desc"]]
        });
        GetIdsRMU("#dataRMU", dataTableRMU);
    };
    var listarReporteRMND = function () {
        var dataTableRMND = $('#dataRMND').DataTable({
            "destroy": true,
            "processing": true,
            responsive: true,
            "ajax": "../Cls/" + idCliente.trim() + "/" + "GeneralInfoConta2.json",
            "columns": [
                { "data": "a" },
                { "data": "b" },
                { "data": "c" },
                { "data": "d" },
                { "defaultContent": "<i class='material-icons' role='button' id='linkRMND' data-toggle='tooltip' data-placement='right' title='Seleccione'>check_circle</i>" }
            ],
            "language": idioma,
            dom: 'Bfrtip',
            "order": [[0, "desc"]]
        });
        GetIdsRMND("#dataRMND", dataTableRMND);
    };
    var GetIdsRCP = function (tbody, table) {
        $(tbody).on("click", "i.material-icons", function () {
            var data = table.row($(this).parents("tr")).data();
            //var idCostumer = $("#MainContent_txtClienteRUC").val(data.a.trim());
            //alert(data.a.trim() + " " + data.c.trim());
            //window.location.href = "http://licenciacontasis.net/ReportWeb/Reportes/CuentasPendientes.aspx?idCompany=" + data.a.trim() + "&year=" + data.c.trim();
            window.location.href = "http://localhost:3243/Reportes/CuentasPendientes.aspx?idCompany=" + data.a.trim() + "&year=" + data.c.trim();
        });
    }
    var GetIdsRMU = function (tbody, table) {
        $(tbody).on("click", "i.material-icons", function () {
            var data = table.row($(this).parents("tr")).data();
            //var idCostumer = $("#MainContent_txtClienteRUC").val(data.a.trim());
            //alert(data.a.trim() + " " + data.c.trim());
            //window.location.href = "http://licenciacontasis.net/ReportWeb/Reportes/frmMargenUtilidad?idCompany=" + data.a.trim() + "&year=" + data.c.trim();
            window.location.href = "http://localhost:3243/reportes/frmMargenUtilidad?idCompany=" + data.a.trim() + "&year=" + data.c.trim();
        });
    }
    var GetIdsRMND = function (tbody, table) {
        $(tbody).on("click", "i.material-icons", function () {
            var data = table.row($(this).parents("tr")).data();
            //window.location.href = "http://licenciacontasis.net/ReportWeb/Reportes/MiNegocioAlDia?idCompany=" + data.a.trim() + "&year=" + data.c.trim();
            window.location.href = "http://localhost:3243/reportes/MiNegocioAlDia?idCompany=" + data.a.trim() + "&year=" + data.c.trim();
        });
    }

    listarReporteRCP();
    listarReporteRMU();
    listarReporteRMND();

    $("#navRMU").trigger("click");
    $("#navRMND").trigger("click");
    //dataRMND

    $('[data-toggle="tooltip"]').tooltip();
    var statusRCP = 0;
    var statusRMUP = 0;
    var statusRMNA = 0;
    //$("#dataRCP").toggle();
    //$("#dataRMU").toggle();
    //$("#dataRMND").toggle();
    $("#btnCuentasPendientes").on("click", function () {
        if(statusRCP == 0) {
            $("#btnCuentasPendientes").text("Ocultar detalles");
            $("#blockCuentasPendientes").removeClass("col-md-4").addClass("col-md-12");
            $("#blockMargenUtilidad").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            statusRCP = 1;
        } else {
            $("#btnCuentasPendientes").text("Ver detalles");
            $("#blockCuentasPendientes").removeClass("col-md-12").addClass("col-md-4");
            $("#blockMargenUtilidad").show("200");
            $("#blockMinegocioAlDia").show("200");
            statusRCP = 0;
        }
        $("#dataRCP").toggle("slow");
    });
    $("#btnMargenUtilidad").on("click", function () {
        if(statusRMUP == 0) {
            $("#btnMargenUtilidad").text("Ocultar detalles");
            $("#blockMargenUtilidad").removeClass("col-md-4").addClass("col-md-12");
            $("#blockCuentasPendientes").hide("200");
            $("#blockMinegocioAlDia").hide("200");
            statusRMUP = 1;
        } else {
            $("#btnMargenUtilidad").text("Ver detalles");
            $("#blockMargenUtilidad").removeClass("col-md-12").addClass("col-md-4");
            $("#blockCuentasPendientes").show("200");
            $("#blockMinegocioAlDia").show("200");
            statusRMUP = 0;
        }
        $("#dataRMU").toggle("slow");
    });
    $("#btnMinegocioAlDia").on("click", function () {
        if(statusRMNA == 0) {
            $("#btnMinegocioAlDia").text("Ocultar detalles");
            $("#blockMinegocioAlDia").removeClass("col-md-4").addClass("col-md-12");
            $("#blockCuentasPendientes").hide("200");
            $("#blockMargenUtilidad").hide("200");
            statusRMNA = 1;
        } else {
            $("#btnMinegocioAlDia").text("Ver detalles");
            $("#blockMinegocioAlDia").removeClass("col-md-12").addClass("col-md-4");
            $("#blockCuentasPendientes").show("200");
            $("#blockMargenUtilidad").show("200");
            statusRMNA = 0;
        }
        $("#dataRMND").toggle("slow");
    });
});