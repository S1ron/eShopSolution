﻿using eShopViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopWebApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
