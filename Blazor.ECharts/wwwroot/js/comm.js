
//window.setupChart = (id, option) => echarts.init(document.getElementById(id)).setOption(JSON.parse(option));
window.setupChart = function (id, option) {
    console.log(option);
    echarts.init(document.getElementById(id)).setOption(JSON.parse(option));
};

//class EChartsJsInterop {
//    SetupChart(id, option) {
//        echarts.init(document.getElementById(id)).setOption(option);
//    }
//}