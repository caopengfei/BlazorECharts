
//window.setupChart = function (id, option, tooltip_position) {
//    console.log(option);
//    var opt = JSON.parse(option);
//    console.log(tooltip_position);
//    if (tooltip_position !== null)
//        opt.tooltip.position = convertToFun(tooltip_position);
//    //console.log(opt);
//    echarts.init(document.getElementById(id)).setOption(opt);
//};
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

window.setupChart = function (id, option, funs) {
    console.log('参数：');
    console.log(option);
    var opt = JSON.parse(option);
    //console.log(funs);
    if (funs !== null && funs.length > 0) {
        console.log('javascript方法：');
        var name = '', action = '';
        for (i = 0; i < funs.length; i++) {
            name = funs[i].name;
            action = funs[i].action;
            console.log(name + '：' + action);
            eval('opt.' + name + '=' + convertToFun(action));
        }
        console.log('处理后的参数：');
        console.log(opt);
    }
    //echarts.init(document.getElementById(id)).setOption(opt);
    //getChart(id).setOption(opt);
    var chart = getChart(id);
    if (chart === null) {
        chart = echarts.init(document.getElementById(id));
        addChart(id, chart);
    }
    chart.setOption(opt);
};

function convertToFuns(funs) {
    return eval(funs);
}
function convertToFun(fun) {
    return eval('(' + fun + ')');
}

//class EChartsJsInterop {
//    SetupChart(id, option) {
//        echarts.init(document.getElementById(id)).setOption(option);
//    }
//}