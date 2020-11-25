/// <reference path="jquery-3.4.1.js" />

window.echartsFunctions = {
    liChart: new Array(),
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
    initChart: function (id, theme = 'light') {
        var chart = echartsFunctions.getChart(id);
        if (chart === null) {
            //chart = echarts.init(document.getElementById(id), null, { renderer: 'svg' });
            chart = echarts.init(document.getElementById(id), theme, { renderer: 'svg' });
            chart.showLoading();
            echartsFunctions.addChart(id, chart);
        }
        return chart;
    },
    showLoading: function (id) {
        var chart = echartsFunctions.getChart(id);
        if (chart === null) {
            echartsFunctions.initChart(id);
        }
        else
            chart.showLoading();
    },
    hideLoding: function (id) {
        var chart = echartsFunctions.getChart(id);
        if (chart !== null)
            chart.hideLoading();
    },
    setupChart: function (id, option, notMerge) {
        console.log('参数：');
        console.log(option);
        var opt = eval('(' + option + ')');
        console.log(opt);
        var chart = echartsFunctions.getChart(id);
        if (chart === null) {
            chart = echartsFunctions.initChart(id);
        }
        chart.hideLoading();
        chart.setOption(opt, notMerge);
        //echarts.init(document.getElementById(id)).setOption(opt);
    },
    execFunc: function (id, func, prefix) {
        var chart = echartsFunctions.getChart(id);
        if (chart === null) {
            chart = echartsFunctions.initChart(id);
        }
        if (prefix)
            eval('chart.' + func);
        else
            eval(func);
        console.log('已执行：' + func);
    },
    execInvokeMethod: function (className, methodName) {
        return DotNet.invokeMethodAsync(className, methodName);
    },
    registerMap: function (id, name, url, _callback) {
        $.getJSON(url)
            .done(function (data) {
                echarts.registerMap(name, data);
                console.log('已执行：registerMap');
                if (_callback !== null)
                    eval(_callback);
            })
            .fail(function (jqxhr, textStatus, error) {
                console.log("获取json数据（" + url + "）失败: " + textStatus + "（" + error + "）");
            });
    }
};