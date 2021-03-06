$(document).ready(function () {
    var idCliente = "jricra@contasis.net";
    var $tipoMoneda;
    var mesProcesamiento;
    var fecha = new Date();
    var anio = fecha.getFullYear();
    var mes = fecha.getMonth() + 1;
    var dia = fecha.getDate();

    $("#monthHeader").text("");
    $("#monthtitle").text("");
    //$("#blockFiltrosAvanzados").hide();

    if (mes < 10) {
        mes = '0' + mes;
    }
    if (dia < 10) {
        dia = '0' + dia;
    }
    var fechaCompleto = anio + "." + mes + "." + dia;
    var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre"];

    $("#triggerCostumer").on("click", function () {
        $('#modalListCostumer').modal('show');
        $("tr").find(".material-icons").hover(function () {
            $(this).addClass("text-info")
                    .css("cursor", "pointer");
        }, function () {
            $(this).removeClass("text-info")
                    .css("cursor", "initial");
        }).on("click", function () {
            $('#modalListCostumer').modal('hide');
        });
    });
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
    var listarReporte = function (mes) {
        var moneda = localStorage.getItem("monedaAlmacenada");
        var simboloMoneda = "";
        if (moneda == "true") {
            simboloMoneda = "S/ ";
        } else {
            simboloMoneda = "$ ";
        }
        var tblReportes = $('#tablaReporte').DataTable({
            "destroy": true,
            "processing": true,
            responsive: false, // cambiar si todo se va a la v..
            "ordering": false,
            scrollCollapse: true,
            info: true,
            data: dataSet.data,
            "columnDefs": [
                { "className": "text-right", targets: [4, 5, 6, 7, 8, 9] },
            ],
            "columns": [
                { "data": "C" },
                { "data": "D" },
                { "data": "M" },
                { "data": "U" },
                {
                    "data": "PV",
                    "render": function (precioVenta) {
                        return simboloMoneda + numeral(precioVenta).format('0,0.00');
                    }
                },
                {
                    "data": "PC",
                    "render": function (precioCosto) {
                        return simboloMoneda + numeral(precioCosto).format('0,0.00');
                    }
                },
                {
                    "data": "MUU",
                    "render": function (MUU) {
                        return simboloMoneda + numeral(MUU).format('0,0.00');
                    }
                },
                {
                    "data": "MV",
                    "render": function (montoVentas) {
                        return simboloMoneda + numeral(montoVentas).format('0,0.00');
                    }
                },
                {
                    "data": "MC",
                    "render": function (montoCosto) {
                        return simboloMoneda + numeral(montoCosto).format('0,0.00');
                    }
                },
                {
                    "data": "MU",
                    "render": function (margenUtil) {
                        return simboloMoneda + numeral(margenUtil).format('0,0.00');
                    }
                }
            ],
            "language": idioma,
            dom: 'Bfrtip',
            buttons: [
                'copy', {
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

    
    var listarCostumer = function () {
        var tblCostumer = $('#tablaCostumer').DataTable({
            "destroy": true,
            "processing": true,
            responsive: true,
            data: listCostumer.data,
            "columns": [
                { "data": "a" },
                { "data": "b" },
                { "defaultContent": "<i class='material-icons'>check_circle</i>" }
            ],
            "language": idioma
        });
        GetIdCostumer("#tablaCostumer", tblCostumer);
    }

    var GetIdCostumer = function (tbody, table) {
        $(tbody).on("click", "i.material-icons", function () {
            var data = table.row($(this).parents("tr")).data();
            var idCostumer = $("#MainContent_txtClienteRUC").val(data.a.trim());
        });
    }
    listarCostumer();
    $("#MainContent_btnGenerarReporte").on("click", function () {
        if (typeof (Storage) !== "undefined") {
            localStorage.setItem("mesAlmacenado", parseInt($("#MainContent_lstMes").val()) - 1);
            localStorage.setItem("monedaAlmacenada", $("#MainContent_lstTipoMoneda").val());
            Console.log("Estado actual de moneda: " + localStorage.getItem("monedaAlmacenada"));
        } else {
            alert("Lo sentimos, su navegador no es compatible con almacenamiento web ...");
        }
    });

    if (localStorage.getItem("mesAlmacenado") != null) {
        listarReporte(parseInt(localStorage.getItem("mesAlmacenado")) + 1);
        $("#MainContent_lstMes").val(parseInt(localStorage.getItem("mesAlmacenado")) + 1).attr("selected");
    }

    var stateBotonExpand = 0;
    $("#blockbtnFullScreen").on("click", function () {
        if (stateBotonExpand == 0) {
            $("#codigo").css("min-width", "80px");
            $("#descripcion").css("min-width", "180px");
            $("#medida").css("min-width", "70px");
            $("#unidades").css("min-width", "70px");
            $("#precioVenta").css("min-width", "110px");
            $("#precioCosto").css("min-width", "110px");
            $("#margenUtilidadUnitario").css("min-width", "110px");
            $("#montoVentas").css("min-width", "110px");
            $("#montoCosto").css("min-width", "110px");
            $("#margenUtilidad").css("min-width", "110px");
            $("#contenedor").removeClass("container");
            stateBotonExpand = 1;
        } else {
            $("th").css("min-width", "100px");
            $("#contenedor").addClass("container");
            stateBotonExpand = 0;
        }
    });
});