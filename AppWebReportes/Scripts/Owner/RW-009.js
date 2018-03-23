$(document).ready(function () {
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
    var fechaCompletoFile = dia + "." + mes + "." + anio;
    var fechaCompleto = dia + "/" + mes + "/" + anio;
    var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre"];
    var listarReporte = function () {
        var tblReportes = $('#MainContent_tableReport').DataTable({
            "destroy": true,
            "processing": true,
            "ordering": false,
            "scrollX": false,
            paging: false,
            "language": idioma,
            dom: 'Bfrtip',
            info: false,
            "columnDefs": [
                { "className": "text-right", targets: [columnA, columnB] }, //2, 5
                { "className": "text-left",  targets: [columnLeftA, columnLeftB] },
                { "targets": [0, 3], "visible": false }
            ],
            buttons: [
                'copy', {
                    extend: 'excel',
                    text: 'Excel',
                    title: 'Estados financieros NIIF y tributario - ' + tipoReporte + ' - Expresado en ' + moneda + " - " + fechaCompleto,
                    filename: 'Estados financieros NIIF y tributario - ' + tipoReporte + ' - Expresado en ' + moneda + " - " + fechaCompletoFile,
                }, {
                    extend: 'pdf',
                    text: 'PDF',
                    orientation: 'landscape',
                    title: 'Estados financieros NIIF y tributario - ' + tipoReporte + ' - Expresado en ' + moneda + " - " + fechaCompleto,
                    filename: 'Estados financieros NIIF y tributario - ' + tipoReporte + ' - Expresado en ' + moneda + " - " + fechaCompletoFile,
                }, {
                    extend: 'print',
                    text: 'Imprimir',
                    title: 'Estados financieros NIIF y tributario - ' + tipoReporte + ' - Expresado en ' + moneda + " - " + fechaCompleto,
                    exportOptions: {
                        modifier: {
                            page: 'current'
                        }
                    },
                }
            ]
        });
        $(".buttons-html5").addClass("btn btn-primary");
        $(".buttons-print").addClass("btn btn-primary").css("margin-top", "5px");
        $(".btn-primary").addClass("btn btn-primary").css("margin-top", "5px");
        $("input[type='search']").css("margin-top", "5px");
        $(".buttons-copy span:first").text("Copiar");
    }
    listarReporte();

    $('a.toggle-vis').on('click', function (e) {
        e.preventDefault();

        // Get the column API object
        var column = tblReportes.column($(this).attr('data-column'));

        // Toggle the visibility
        column.visible(!column.visible());
    });

    var stateBotonExpand = 0;
        $("#blockbtnFullScreen").on("click", function () {
            if (stateBotonExpand == 0) {
                $("#tittleActivo").css("min-width", "290px");
                $("#tittleMonto1").css("min-width", "120px");
                $("#tittlePasivoPatrimonio").css("min-width", "290px");
                $("#tittleMonto2").css("min-width", "120px");
                stateBotonExpand = 1;
            } else {
                $("#tittleActivo").css("min-width", "100px");
                $("#tittleMonto1").css("min-width", "80px");
                $("#tittlePasivoPatrimonio").css("min-width", "100px");
                $("#tittleMonto2").css("min-width", "80px");
                stateBotonExpand = 0;
            }
        }); 
});