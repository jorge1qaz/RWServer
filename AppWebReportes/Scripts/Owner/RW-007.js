$(document).ready(function () {
    Highcharts.setOptions({
        lang: {
            decimalPoint: ',',
            thousandsSep: ' '
        }
    });
    $('table.highchart').highchartTable();

});

foo = {
    myAwesomeCallback: function (value) {
        //return value + '$'
        return value;
    }
}