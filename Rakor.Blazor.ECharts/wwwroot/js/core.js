
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
window.initChart = function (id) {
    var chart = getChart(id);
    if (chart === null) {
        //chart = echarts.init(document.getElementById(id), null, { renderer: 'svg' });
        chart = echarts.init(document.getElementById(id));
        chart.showLoading();
        addChart(id, chart);
    }
};
window.setupChart = function (id, option, notMerge) {
    console.log('参数：');
    console.log(option);
    var opt = eval('(' + option + ')');
    var chart = getChart(id);
    if (chart === null) {
        //chart = echarts.init(document.getElementById(id), null, { renderer: 'svg' });
        chart = echarts.init(document.getElementById(id));
        addChart(id, chart);
    }
    chart.hideLoading();
    console.log(opt);
    chart.setOption(opt, notMerge);
    //echarts.init(document.getElementById(id)).setOption(opt);
};
window.execFunc = function (id,func) {
    var chart = getChart(id);
    if (chart === null) {
        chart = echarts.init(document.getElementById(id));
        addChart(id, chart);
    }
    eval('chart.' + func);
};