$(document).ready(function () {
    var meses = ["Apertura", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre"];
    Highcharts.setOptions({
        lang: {
            decimalPoint: ',',
            thousandsSep: ' '
        }
    });
    var mesProceso = parseInt($("#MainContent_lstMes").val());
    var chart = new Highcharts.Chart({

        chart: {
            renderTo: 'container',
            type: 'column',
            options3d: {
                enabled: true,
                alpha: 0,
                beta: 6,
                depth: 52,
                viewDistance: 25
            }
        },

        xAxis: {
            className: 'highcharts-color-0',
            categories: ['Resultado', 'Ventas', 'Caja y bancos', 'Deben', 'Debo']
        },
        title: {
            text: 'Reporte: Mi negocio al día'
        },
        subtitle: {
            text: 'Para el mes de ' + meses[mesProceso] + ' - Expresado en ' + tipoMoneda
        },
        yAxis: [{
            title: {
                text: 'Resultado en ' + tipoMoneda
            }
        }],

        colors: ['rgb(69, 114, 167)', 'rgb(170, 70, 67)', 'rgb(137, 165, 78)', 'rgb(128, 105, 155)', 'rgb(61, 150, 174)'],

        plotOptions: {
            series: {
                dataLabels: {
                    enabled: true,
                    style: {
                        fontWeight: 'bold'
                    },
                    lang: {
                        decimalPoint: ',',
                        thousandsSep: ' '
                    },
                    format: simboloMoneda + " {point.y:,.2f}"
                }
            }
        },

        tooltip: {
            pointFormat: simboloMoneda + " {point.y:,.2f} " + tipoMoneda
        },


        series: [{
            data: [valor1, valor2, valor3, valor4, valor5],
            colorByPoint: true
        }]
    });
    function showValues() {
        $('#messageAlpha').html(chart.options.chart.options3d.alpha);
        $('#messageBeta').html(chart.options.chart.options3d.beta);
        $('#messageDepth').html(chart.options.chart.options3d.depth);
    }
    $('#sliders input').on('input change', function () {
        chart.options.chart.options3d[this.id] = parseFloat(this.value);
        showValues();
        chart.redraw(false);
    });

    var stateBotonExpand = 0;
    $("#blockbtnFullScreen").on("click", function () {
        if (stateBotonExpand == 0) {
            chart.reflow();
            stateBotonExpand = 1;
        } else {
            chart.reflow();
            stateBotonExpand = 0;
        }
    });


    $("#alpha").text($("#messageAlpha").val());
    $("#alpha").on("input", function () {
        $("#messageAlpha").text($(this).val());
    });

    $("#beta").text($("#messageBeta").val());
    $("#beta").on("input", function () {
        $("#messageBeta").text($(this).val());
    });

    $("#depth").text($("#messageDepth").val());
    $("#depth").on("input", function () {
        $("#messageDepth").text($(this).val());
    });

    $(".highcharts-title").addClass("card-title");
    $(".highcharts-credits").hide();
    $(".highcharts-legend-item").hide();

    $("#blockImageOptions").toggle();
    $("#btnShowOptions").on("click", function () {
        $("#blockImageOptions").toggle("slow");
    });
});