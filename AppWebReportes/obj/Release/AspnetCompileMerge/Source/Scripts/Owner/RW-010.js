var arrayPeriordosColumnas = [];
function DoArrayColumns(cantidadDeElementos) {
    for (var i = 2; i <= cantidadDeElementos + 2; i++) {
        arrayPeriordosColumnas.push(parseInt(i));
    }
}
DoArrayColumns(cantidadDeperiodos);

var temporalCell;
function AddFormatMiles(filas, columnToChange) {
    for (var i = 1; i <= cantidadFilas; i++) { // la primera fila de tbody empieza en 1 

        temporalCell = parseFloat($("#MainContent_grdTableReport tr:eq(" + i + ") td:eq(" + columnToChange + ")").html());
        temporalCell = numeral(temporalCell).format('0,0.00');
        $("#MainContent_grdTableReport tr:eq(" + i + ") td:eq(" + columnToChange + ")").html(temporalCell);
    }
}

for (var i = 2; i <= cantidadDeperiodos + 2; i++) {
    AddFormatMiles(cantidadFilas, i);
}

$(document).ready(function () {
    $("th").addClass("text-center");
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
    var idioma = {
        "sProcessing": "Procesando...",
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "Ningún dato disponible en esta tabla",
        "sInfo": "Mostrando _START_ al _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando _START_ al _END_ de _TOTAL_ registros",
        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
        "sInfoPostFix": "",
        "sSearch": "Filtrar por:",
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
        },
        "decimal": "-",
        "thousands": "."
    }
    var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre"];

    var listarReporte = function () {
        var tblReportes = $('#MainContent_grdTableReport').DataTable({
            "destroy": true,
            "processing": true,
            "ordering": false,
            "scrollX": false,
            paging: false,
            "language": idioma,
            dom: 'Bfrtip',
            info: false,
            fixedColumns: {
                rightColumns: 1
            },
            buttons: [
                'copy', {
                    extend: 'excel',
                    text: 'Excel',
                    title: 'Flujo de caja detallado - ' + tipoReporte + ' - Expresado en ' + moneda + " - " + fechaCompleto,
                    filename: 'Flujo de caja detallado - ' + tipoReporte + ' - Expresado en ' + moneda + " - " + fechaCompletoFile,
                }, {
                    extend: 'print',
                    text: 'Imprimir',
                    title: 'Flujo de caja detallado - ' + tipoReporte + ' - Expresado en ' + moneda + " - " + fechaCompleto,
                    exportOptions: {
                        modifier: {
                            page: 'current'
                        }
                    },
                }
            ],
            "columnDefs": [{
                "targets": arrayPeriordosColumnas,
                "className": "text-right"
            }, {
                "targets": 1,
                "className": "text-left"
            }]
        });
        $(".buttons-html5").addClass("btn btn-primary");
        $(".buttons-print").addClass("btn btn-primary").css("margin-top", "5px");
        $(".btn-primary").addClass("btn btn-primary").css("margin-top", "5px");
        $("input[type='search']").css("margin-top", "5px");
        $(".buttons-copy span:first").text("Copiar");
    }
    listarReporte();
}); 