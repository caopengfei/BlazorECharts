using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using Blazor.ECharts.Option;

namespace Blazor.ECharts
{
    public class ComponentBase<T> : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public EChartsOption<T> Option { get; set; }

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
        protected override void OnAfterRender(bool firstRender)
        {
            RequireRender = false;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
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
                else
                {
                    await JSRuntime.UpdateChart(Id, Option).AsTask();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error while {(firstRender ? "setting up" : "updating")} the chart. Message:{e.Message} \n {e.StackTrace}");
            }
            RequireRender = false;
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