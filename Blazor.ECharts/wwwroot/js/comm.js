
window.setupChart = function (id, option, tooltip_position) {
    console.log(option);
    var opt = JSON.parse(option);
    console.log(tooltip_position);
    if (tooltip_position !== null)
        opt.tooltip.position = convertToFun(tooltip_position);
    //console.log(opt);
    echarts.init(document.getElementById(id)).setOption(opt);
};

function convertToFun(fun) {
    return eval('(' + fun + ')');
}

//class EChartsJsInterop {
//    SetupChart(id, option) {
//        echarts.init(document.getElementById(id)).setOption(option);
//    }
//}