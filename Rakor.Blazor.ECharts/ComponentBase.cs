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
        public bool AutoRender { get; set; } = true;

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
        protected override void OnAfterRender(bool firstRender)
        {
            RequireRender = false;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (AutoRender == false) return;
            if (firstRender)
            {
                if (Option == null) return;
                await JSRuntime.SetupChart(Id, Option);
                if (OnRenderCompleted != null)
                {
                    await OnRenderCompleted(this);
                }
            }
            //else
            //{
            //    await JSRuntime.UpdateChart(Id, UpdateOption).AsTask();
            //}
            RequireRender = false;
        }
        public async Task ShowLoadingAsync()
        {
            await JSRuntime.ShowLoadingChart(Id);
        }
        public async Task HideLoadingAsync()
        {
            await JSRuntime.HideLoadingChart(Id);
        }
        public async Task SetupOptionAsync(EChartsOption<object> opt, bool notMerge = false)  
        {
            await JSRuntime.SetupChart(Id, opt, notMerge);
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