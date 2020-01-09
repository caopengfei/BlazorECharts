
window.echartsFunctions = {
    liChart : new Array(),
    getChart: function (id) {
        for (var i = 0; i < echartsFunctions.liChart.length; i++) {
            if (echartsFunctions.liChart[i].Id === id) {
                return echartsFunctions.liChart[i].Chart; 
            }
        }
        return null;
    },
    addChart: function (id, chart) {
        echartsFunctions.liChart.push({ Id: id, Chart: chart });
    },
    removeChart: function (id) {
        var index = -1;
        for (var i = 0; i < echartsFunctions.liChart.length; i++) {
            if (echartsFunctions.liChart[i].Id === id) {
                index = i;
                break;
            }
        }
        if (index >= 0) {
            echartsFunctions.liChart.splice(index, 1);
        }
    },
    initChart: function (id) {
        var chart = echartsFunctions.getChart(id);
        if (chart === null) {
            //chart = echarts.init(document.getElementById(id), null, { renderer: 'svg' });
            chart = echarts.init(document.getElementById(id));
            chart.showLoading();
            echartsFunctions.addChart(id, chart);
        }
    },
    setupChart: function (id, option, notMerge) {
        console.log('参数：');
        console.log(option);
        var opt = eval('(' + option + ')');
        var chart = echartsFunctions.getChart(id);
        if (chart === null) {
            //chart = echarts.init(document.getElementById(id), null, { renderer: 'svg' });
            chart = echarts.init(document.getElementById(id));
            echartsFunctions.addChart(id, chart);
        }
        chart.hideLoading();
        console.log(opt);
        chart.setOption(opt, notMerge);
        //echarts.init(document.getElementById(id)).setOption(opt);
    },
    execFunc: function (id, func) {
        var chart = echartsFunctions.getChart(id);
        if (chart === null) {
            chart = echarts.init(document.getElementById(id));
            echartsFunctions.addChart(id, chart);
        }
        eval('chart.' + func);
    }
};