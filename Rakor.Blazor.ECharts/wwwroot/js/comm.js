
var liChart = new Array();

function getChart(id) {
    for (var i = 0; i < liChart.length; i++) {
        if (liChart[i].Id === id) {
            return liChart[i].Chart;
        }
    }
    return null;
}
function addChart(id, chart) {
    liChart.push({ Id:id, Chart:chart });
}
function removeChart(id){
    var index = -1;
    for (var i = 0; i < liChart.length; i++) {
        if (liChart[i].Id === id) {
            index = i;
            break;
        }
    }
    if (index >= 0) {
        liChart.splice(index, 1);
    }
}

window.setupChart = function (id, option) {
    console.log('参数：');
    console.log(option);
    var opt = eval('(' + option + ')');
    var chart = getChart(id);
    if (chart === null) {
        //chart = echarts.init(document.getElementById(id), null, { renderer: 'svg' });
        chart = echarts.init(document.getElementById(id));
        addChart(id, chart);
    }
    chart.setOption(opt);
};