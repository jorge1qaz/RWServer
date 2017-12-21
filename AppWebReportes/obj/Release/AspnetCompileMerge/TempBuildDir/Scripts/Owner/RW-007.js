$(document).ready(function () {
    $('table.highchart').highchartTable();
});


foo = {
    myAwesomeCallback: function (value) {
        //return value + '$'
        return value;
    }
}