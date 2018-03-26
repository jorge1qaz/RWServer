$(document).ready(function () {
    $("th").addClass("text-center").css("min-width", "79px");
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
        var tblReportes = $('#tableNaturaleza').DataTable({
            "destroy": true,
            "processing": true,
            "ordering": false,
            responsive: false,
            paging: false,
            "language": idioma,
            dom: 'Bfrtip',
            info: false,
            "columnDefs": [
                { "className": "text-right", targets: [2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13] },
                {
                    "targets": [0],
                    "visible": false
                },
                {
                    "targets": [1],
                    "className": "text-left"
                }
            ],
            buttons: [
                'copy', {
                    extend: 'excel',
                    text: 'Excel',
                    title: 'Estados financieros comparativos - Estado de resultado - EGP por ' + tipoReporte + ' - ' + moneda + " - " + fechaCompleto,
                    filename: 'Estados financieros comparativos - Estado de resultado - EGP por ' + tipoReporte + ' - ' + moneda + " - " + fechaCompletoFile,
                }, {
                    extend: 'pdf',
                    text: 'PDF',
                    orientation: 'landscape',
                    title: 'Estados financieros comparativos - Estado de resultado - EGP por ' + tipoReporte + ' - ' + moneda + " - " + fechaCompleto,
                    filename: 'Estados financieros comparativos - Estado de resultado - EGP por ' + tipoReporte + ' - ' + moneda + " - " + fechaCompletoFile,
                }, {
                    extend: 'print',
                    text: 'Imprimir',
                    title: 'Estados financieros comparativos - Estado de resultado - EGP por ' + tipoReporte + ' - ' + moneda + " - " + fechaCompleto,
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
        $(".buttons-copy span:first").text("Copiar");
    }
    listarReporte();
    $("th").css("min-width", "85px");
    $("#labelTittle").css("min-width", "226px");
});

function AddNumeral(number) {
    var numeral = numeral(number).format('0,0.00');
    return numeral;
}