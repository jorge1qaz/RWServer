$(document).ready(function () {
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
        }
    }
    var meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre"];
    var listarReporte = function (mes) {
        var simboloMoneda = "";
        
        var tblReportes = $('#example').DataTable({
            "destroy": true,
            "processing": true,
            responsive: true,
            "columns": [
                { "data": "Codigo" },
                { "data": "Descripcion" },
                { "data": meses[0] },
                { "data": meses[1] },
                { "data": meses[2] },
                { "data": meses[3] },
                { "data": meses[4] },
                { "data": meses[5] },
                { "data": meses[6] },
                { "data": meses[7] },
                { "data": meses[8] },
                { "data": meses[9] },
                { "data": meses[10] },
                { "data": meses[11] }
            ],
            "language": idioma,
            dom: '<lf<t>ip>',
            buttons: [
                'copy', 'csv', {
                    extend: 'excel',
                    text: 'Excel',
                    title: 'Reporte: Margen de utilidad por producto - Para el mes de ',
                    filename: 'Margen de utilidad por producto ',
                }, {
                    extend: 'pdf',
                    text: 'PDF',
                    orientation: 'landscape',
                    title: 'Reporte: Margen de utilidad por producto - Para el mes de ',
                    filename: 'Margen de utilidad por producto ',
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
    }
    listarReporte();
});