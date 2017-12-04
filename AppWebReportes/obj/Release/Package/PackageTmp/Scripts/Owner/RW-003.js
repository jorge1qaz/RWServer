google.charts.load('current', {'packages':['corechart']});
google.charts.setOnLoadCallback(DibujarGraficoBarras);

function DibujarGraficoBarras () {
    var data = google.visualization.arrayToDataTable([
        ['Mes', 'Total'],
        ['Enero', 817500],
        ['Febrero', 379200],
        ['Marzo', 2695000],
        ['Abril', 2099000],
        ['Mayo', 1526000],
        ['Junio', 1526000],
        ['Julio', 817500],
        ['Agosto', 1645000],
        ['Septiembre', 1526000],
        ['Octubre', 485000],
        ['Noviembre', 1526000],
        ['Diciembre', 817500]
    ]);

    /*var jsonDataJS = $.ajax({
				url: "RW-003-datos-soles.json",
				dataType: "json",
				async: false
			}).responseText;
    var data = new google.visualization.DataTable(jsonDataJS);*/

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
                     { calc: "stringify",
                       sourceColumn: 1,
                       type: "string",
                       role: "annotation" }
                     ]);
    var options = {
        bars: 'horizontal', // Required for Material Bar Charts.
        hAxis: { format: 'decimal' },
        height: 400,
        colors: ['rgb(33, 142, 202)', '#1b9e77', '#7570b3'],
        bar: {groupWidth: "85%"},
        legend: { position: "none" },
    };

    //var chart = new google.charts.Bar(document.getElementById('chart_div3'));
    //chart.draw(data, google.charts.Bar.convertOptions(options));

    var chart = new google.visualization.BarChart(document.getElementById("chart_div3"));
    chart.draw(view, options);
}
