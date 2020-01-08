using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using Rakor.Blazor.ECharts.Option;

namespace Rakor.Blazor.ECharts
{
    public class ComponentBase<T> : ComponentBase
    {
        protected string Id = "div" + DateTime.Now.Ticks;

        [Parameter]
        public EChartsOption<T> Option { get; set; }

        /// <summary>
        /// 默认是否呈现组件
        /// </summary>
        [Parameter]
        public bool AutoShow { get; set; } = true;

        protected bool RequireRender { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public Func<object, Task> OnRenderCompleted { get; set; }

        /// <summary>
        /// 设置自定义样式
        /// </summary>
        [Parameter]
        public string Style { get; set; } //= "min-width:300px;min-height:300px;";

        /// <summary>
        /// 设置class样式
        /// </summary>
        [Parameter]
        public string Class { get; set; }

        /// <summary>
        /// 默认情况下所有复杂组件都只进行一次渲染，该方法将组件置为需要再次渲染
        /// </summary>
        public void MarkAsRequireRender()
        {
            RequireRender = true;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (string.IsNullOrEmpty(Id)) Id = "div" + DateTime.Now.Ticks;
        }
        //protected override void OnInitialized()
        //{
        //    base.OnInitialized();
        //    try
        //    {
        //        JSRuntime.InitChart(Id);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.Error.WriteLine($"Error while init the chart. Message:{e.Message} \n {e.StackTrace}");
        //    }
        //}
        protected override void OnAfterRender(bool firstRender)
        {
            RequireRender = false;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (AutoShow == false) return;
            try
            {
                if (firstRender)
                {
                    await JSRuntime.SetupChart(Id, Option).AsTask();
                    if (OnRenderCompleted != null)
                    {
                        await OnRenderCompleted(this);
                    }
                }
                //else
                //{
                //    await JSRuntime.UpdateChart(Id, UpdateOption).AsTask();
                //}
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"初始化ECharts参数失败. 错误:{e.Message} \n {e.StackTrace}");
            }
            RequireRender = false;
        }

        public async Task SetupOptionAsync(EChartsOption<object> opt, bool notMerge = false)  
        {
            try
            {
                await JSRuntime.SetupChart(Id, opt, notMerge).AsTask();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"设置ECharts参数失败. 错误:{e.Message} \n {e.StackTrace}");
            }
        }
        public async Task ExecFuncAsync(string func) 
        {
            await JSRuntime.ExecFuncAsync(Id,func);
        }

        public void Refresh()
        {
            StateHasChanged();
        }

        protected override bool ShouldRender()
        {
            return RequireRender;
        }
    }
}