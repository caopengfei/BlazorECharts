using System.Collections.Generic;
using Demo.WASM.Models;
using Microsoft.AspNetCore.Components;

namespace Demo.WASM.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}