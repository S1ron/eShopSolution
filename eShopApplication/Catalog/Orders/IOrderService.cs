using eShopViewModels.Common;
using eShopViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopApplication.Catalog.Orders
{
    public interface IOrderService
    {
        Task<bool> Create(Guid id, CheckoutRequest request);
    }
}
