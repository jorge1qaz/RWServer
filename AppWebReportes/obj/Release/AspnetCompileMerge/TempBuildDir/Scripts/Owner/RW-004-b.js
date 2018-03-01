$(document).ready(function () {
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
    var fechaCompletoFile = dia + "." + mes + "." + anio;
    var fechaCompleto = dia + "/" + mes + "/" + anio;
    var $btnTriggerModal = $("#triggerModal");
    $('#modalLeyenda').modal('show');
    $btnTriggerModal.on("click", function () {
        $('#modalBuscarCuenta').modal('show');
        $("tr").find(".material-icons").hover(function () {
            $(this).addClass("text-info")
                .css("cursor", "pointer");
        }, function () {
            $(this).removeClass("text-info")
                .css("cursor", "initial");
        }).on("click", function () {
            $('#modalBuscarCuenta').modal('hide');
        });
    });
    //listarCuentas();
    $(".buttons-html5").addClass("btn btn-primary");
    $(".buttons-print").addClass("btn btn-primary");
    $(".buttons-copy span:first").text("Copiar");
    $(".buttons-print span:first").text("Imprimir");

    //Validaciones
    var formulario = $("#Formulario");
    $(formulario).validate({
        rules: {
            txtCuentaName: {
                integer: true,
                required: true,
                number: true,
                maxlength: 10
            }
        },
        messages: {
            txtCuentaName: {
                integer: "Sólo números enteros",
                required: "Este campo es obligatorio",
                number: "Sólo se adminten números",
                maxlength: "El número máximo de caracteres es 10"
            }
        },
        errorElement: "em",
        errorPlacement: function (error, element) {
            error.addClass("help-block");
            if (element.prop("type") === "checkbox") {
                error.insertAfter(element.parent("label"));
            } else {
                error.insertAfter(element);
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).parents(".form-group").addClass("text-danger").removeClass("text-sucess");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents(".form-group").addClass("text-sucess").removeClass("text-danger");
        }
    });
    var $idMesProceso = 1;
    function GenerarReporte() {
        var txtCuenta = $("#txtCuenta").val();
        if (txtCuenta == "") {
            alert("Para proceder, primero debe elegir una cuenta.");
        } else {
            $.UrlExists = function (url) {
                var http = new XMLHttpRequest();
                http.open('HEAD', url, false);
                http.send();
                return http.status != 404;
            }
            if ($.UrlExists("../Cls/" + idCliente.trim() + "/" + "rptCntsPndts/" + idEmpresa.trim() + "/" + idAnio.trim() + "/" + $("#txtCuenta").val() + "ReporteCP" + $idMesProceso + ".json")) {
                listarReporte($("#txtCuenta").val(), $idMesProceso);
                $(".buttons-html5").addClass("btn blue lighten-1");
                $(".buttons-print").addClass("btn blue lighten-1");
                $(".buttons-copy span:first").text("Copiar");
                $(".buttons-print span:first").text("Imprimir");
                console.log($("#txtCuenta").val(), $idMesProceso);
            } else {
                alert("No encontramos ningún registro en su base de datos, para ésta consulta.");
            }
        }
    }
    var listarCuentas = function () {
        var tblCuentas = $('#tablaCuentas').DataTable({
            "ajax": "../Cls/" + idCliente.trim() + "/rptCntsPndts/" + idEmpresa.trim() + "/" + idAnio.trim() + "/listaCuentas.json",
            "columns": [
                { "data": "a" },
                { "data": "b" },
                { "defaultContent": "<i class='material-icons'>check_circle</i>" }
            ],
            "language": idioma,
            responsive: false
        });
        GetIdCuenta("#tablaCuentas", tblCuentas);
    }
    var GetIdCuenta = function (tbody, table) {
        $(tbody).on("click", "i.material-icons", function () {
            var data = table.row($(this).parents("tr")).data();
            var idCuenta = $("#txtCuenta").val(data.a.trim());
        });
    }
    function CambiarValorMes() {
        var select = document.getElementById("MainContent_lstMes");
        var options = document.getElementsByTagName("option");
        $idMesProceso = select.value;
    }
    $("#MainContent_lstMes").on("change", function () {
        CambiarValorMes();
    });
    $("#btnPruebas").on("click", function () {
        try {
            GenerarReporte();
        } catch (e) {
            alert(e);
        }
    });
    listarCuentas();
    var listarReporte = function (idCuenta, idMesProceso) {
        var debe = ""; //b
        var haber = ""; //c
        var saldo = ""; //d
        if ($("#MainContent_lstTipoMoneda").val() == "true") {
            debe = "b";
            haber = "c";
            saldo = "d";
        } else {
            debe = "f";
            haber = "g";
            saldo = "h";
        }
        var tblReportes = $('#tablaReporte').DataTable({
            "destroy": true,
            "processing": true,
            "scrollX": false,
            "ajax": "../Cls/" + idCliente.trim() + "/" + "rptCntsPndts/" + idEmpresa.trim() + "/" + idAnio.trim() + "/" + idCuenta + "ReporteCP" + idMesProceso + ".json",
            "columns": [
                { "data": "a" },
                {
                    "data": debe,
                    "render": function (debe) {
                        return simboloMonedaRCP + numeral(debe).format('0,0.00');
                    }
                },
                {
                    "data": haber,
                    "render": function (haber) {
                        return simboloMonedaRCP + numeral(haber).format('0,0.00');
                    }
                },
                {
                    "data": saldo,
                    "render": function (saldo) {
                        return simboloMonedaRCP + numeral(saldo).format('0,0.00');
                    }
                },
                { "data": "e" }
            ],
            "language": idioma,
            dom: 'Bfrtip',
            buttons: [
                'copy', {
                    extend: 'excel',
                    text: 'Excel',
                    title: 'Cuentas pendientes - ' + tipoMonedaRCP + " - " + fechaCompleto,
                    filename: 'Cuentas pendientes - ' + tipoMonedaRCP + " - " + fechaCompletoFile,
                }, {
                    extend: 'pdf',
                    text: 'PDF',
                    orientation: 'landscape',
                    title: 'Cuentas pendientes - ' + tipoMonedaRCP + " - " + fechaCompleto,
                    filename: 'Cuentas pendientes - ' + tipoMonedaRCP + " - " + fechaCompletoFile,
                }, {
                    extend: 'print',
                    text: 'Imprimir',
                    title: 'Cuentas pendientes - ' + tipoMonedaRCP + " - " + fechaCompleto,
                    exportOptions: {
                        modifier: {
                            page: 'current'
                        }
                    },
                }
            ],
            "order": [[3, "desc"]],
            "columnDefs": [
                { "className": "text-right", targets: [1, 2, 3] }
            ]
        });
        $(".buttons-html5").addClass("btn btn-primary");
        $(".buttons-print").addClass("btn btn-primary").css("margin-top", "5px");
        $(".btn-primary").addClass("btn btn-primary").css("margin-top", "5px");
        $("input[type='search']").css("margin-top", "5px");
        $(".buttons-copy span:first").text("Copiar");
        DetectarTipoCuenta();
        var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre"];
        $("#MainContent_lblMesProceso").text(meses[parseInt($("#MainContent_lstMes").val()) - 1]);
    }
    function DetectarTipoCuenta() {
        var $cuenta = $('#txtCuenta').val().substring(0, 1);
        var val1 = "Deuda";
        var val2 = "Amortización";
        switch ($cuenta) {
            case "1":
                $("#thDebe").html(val1);
                $("#thHaber").html(val2);
                break;
            case "4":
                $("#thDebe").html(val2);
                $("#thHaber").html(val1);
                break;
            default:
                break;
        }
    }

    var stateBotonExpand = 0;
    $("#blockbtnFullScreen").on("click", function () {
        if (stateBotonExpand == 0) {
            $("#ruc").css("min-width", "130px");
            $("#thDebe").css("min-width", "130px");
            $("#thHaber").css("min-width", "130px");
            $("#saldo").css("min-width", "130px");
            $("#razonSocial").css("min-width", "300px");
            stateBotonExpand = 1;
        } else {
            $("#ruc").css("min-width", "100px");
            $("#thDebe").css("min-width", "100px");
            $("#thHaber").css("min-width", "100px");
            $("#saldo").css("min-width", "100px");
            $("#razonSocial").css("min-width", "120px");
            stateBotonExpand = 0;
        }
    });
});