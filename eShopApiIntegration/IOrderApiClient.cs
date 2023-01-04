using eShopViewModels.Common;
using eShopViewModels.Sales;
using eShopViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopApiIntegration
{
    public interface IOrderApiClient
    {
        Task<string> CreateOrder(CheckoutRequest request);
    }
}
