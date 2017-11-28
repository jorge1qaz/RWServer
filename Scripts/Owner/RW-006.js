$(document).ready(function () {
    var idEmpresa = "01";
    var idAnio = "2016";
    var idCliente = "jricra@contasis.net";
    var $tipoMoneda;
    var mesProcesamiento;
    var fecha = new Date();
    var anio = fecha.getFullYear();
    var mes = fecha.getMonth() + 1;
    var dia = fecha.getDate();

    $("#monthHeader").text("");
    $("#monthtitle").text("");
    $("#blockFiltrosAvanzados").hide();

    if (mes < 10) {
        mes = '0' + mes;
    }
    if (dia < 10) {
        dia = '0' + dia;
    }
    var fechaCompleto = anio + "." + mes + "." + dia;
    var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];

    $("#MainContent_lstTipoMoneda").on("change", function () {
        $tipoMoneda = $(this).val();
        return $tipoMoneda;
    });
    $("#MainContent_lstMes").on("change", function () {
        mesProcesamiento = $(this).val();
        return mesProcesamiento;
    });
    $("#btnFiltrosAvanzados").on("click", function () {
        $("#blockFiltrosAvanzados").show().fade(300);
    });
    
    var idioma = {
        "sProcessing": "Procesando...",
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "Ningún dato disponible en esta tabla",
        "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
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
    var listarReporte = function (mes, moneda) {
        var simboloMoneda = "";
        if (moneda == true) {
            simboloMoneda = "S/ ";
        } else {
            simboloMoneda = "$ ";
        }
        var tblReportes = $('#tablaReporte').DataTable({
            "destroy": true,
            "processing": true,
            responsive: true,
            data: dataSet.data,
            "columns": [
                { "data": "C" },
                { "data": "D" },
                { "data": "M" },
                { "data": "U" },
                {
                    "data": "PV",
                    "render": function (precioVenta) {
                        return simboloMoneda + precioVenta
                    }
                },
                {
                    "data": "PC",
                    "render": function (precioCosto) {
                        return simboloMoneda + precioCosto
                    }
                },
                { "data": "MUU" },
                {
                    "data": "MV",
                    "render": function (montoVentas) {
                        return simboloMoneda + montoVentas
                    }
                },
                {
                    "data": "MC",
                    "render": function (montoCosto) {
                        return simboloMoneda + montoCosto
                    }
                },
                {
                    "data": "MU",
                    "render": function (margenUtil) {
                        return simboloMoneda + margenUtil
                    }
                }
            ],
            "language": idioma,
            dom: 'Bfrtip',
            buttons: [
                'copy', 'csv', {
                    extend: 'excel',
                    text: 'Excel',
                    title: 'Reporte: Margen de utilidad por producto - Para el mes de ' + meses[mes - 1],
                    filename: 'Margen de utilidad por producto ' + fechaCompleto,
                }, {
                    extend: 'pdf',
                    text: 'PDF',
                    orientation: 'landscape',
                    title: 'Reporte: Margen de utilidad por producto - Para el mes de ' + meses[mes - 1],
                    filename: 'Margen de utilidad por producto ' + fechaCompleto,
                }, {
                    extend: 'print',
                    text: 'Imprimir',
                    title: 'Reporte:  Margen de utilidad por producto',
                    exportOptions: {
                        modifier: {
                            page: 'current'
                        }
                    },
                }
            ],
            "order": [[3, "desc"]]
        });
        $(".buttons-html5").addClass("btn btn-primary");
        $(".buttons-print").addClass("btn btn-primary").css("margin-bottom", "5px");
        $(".buttons-copy span:first").text("Copiar");

        $("#monthtitle").text(" para el mes de ");
        $("#monthHeader").text(meses[localStorage.getItem("mesAlmacenado")]);
    }
    
    $("#MainContent_btnGenerarReporte").on("click", function () {
        if (typeof (Storage) !== "undefined") {
            localStorage.setItem("mesAlmacenado", parseInt($("#MainContent_lstMes").val()) - 1);
        } else {
            alert("Lo sentimos, su navegador no es compatible con almacenamiento web ...");
        }
    });

    if (localStorage.getItem("mesAlmacenado") != null) {
        listarReporte(parseInt(localStorage.getItem("mesAlmacenado")) + 1, Boolean($("#MainContent_lstTipoMoneda").val()));
        $("#MainContent_lstMes").val(parseInt(localStorage.getItem("mesAlmacenado")) + 1).attr("selected");
    }
});