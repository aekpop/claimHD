// The script that draws the chart
var chartData; // globar variable for hold chart data
// Load the Visualization API and the corechart package.
google.charts.load('current', { packages: ['corechart'] });
// Here We will fill chartData from the database using ajax HTTP request
$(document).ready(function () {
    $.ajax({
        url: "GoogleChart.aspx/GetData",
        data: "",
        dataType: "json",
        type: "POST",
        contentType: "application/json; chartset=utf-8",
        success: function (data) {
            chartData = data.d;
        },
        error: function () {
            alert("Error loading data! Please try again.");
        }
    }).done(function () {
        // after complete loading data by calling drawChart
        google.charts.setOnLoadCallback(drawChart);
    });
});
// Callback that creates and populates a data table
function drawChart() {
    // Create the dataset (DataTable)
    var data = new google.visualization.DataTable();
    // add the columns
    data.addColumn('string', 'Cpoint');
    data.addColumn('string', 'Budget');
    data.addColumn('string', 'Mount');
    // add rows
    for (i = 0; i < chartData.length; i++) {
        // avoid the first row which is the column name
        if (i != 0) {
            console.log(chartData[i]);
            data.addRows([chartData[i]]);
        }
    }
    // set options for the chart
    var options = {
        'title': "Cpoint Revenue",
        'pointSize': 3,
        'is3D': true,
        'width': 400,
        'height': 300
    };
    // Instantiate and draw Line chart, passing in some options.
    var chart4 = new google.visualization.LineChart(document.getElementById('chart_div_4'));
    chart4.draw(data, options);
    // Instantiate and draw Column chart, passing in some options.
    var chart6 = new google.visualization.ColumnChart(document.getElementById('chart_div_5'));
    chart6.draw(data, options);
    // Instantiate and draw Pie chart, passing in some options.
    var chart5 = new google.visualization.PieChart(document.getElementById('chart_div_6'));
    chart5.draw(data, options);
}