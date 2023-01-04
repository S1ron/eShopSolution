using eShopData.EF;
using eShopData.Entities;
using eShopData.Enums;
using eShopViewModels.Common;
using eShopViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopApplication.Catalog.Orders
{
    public class OrderService : IOrderService
    {
        private readonly EShopDBContext _context;
        public OrderService(EShopDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Guid id,CheckoutRequest request)
        {
            var order = new Order()
            {
                OrderDate = DateTime.Now,
                UserId = id,
                ShipName = request.Name,
                ShipAddress = request.Address,
                ShipEmail = request.Email,
                ShipPhoneNumber = request.PhoneNumber,
                Status = OrderStatus.InProgress
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            var orderdetail = new List<OrderDetail>();
            foreach(var item in request.OrderDetails)
            {
                orderdetail.Add(new OrderDetail()
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = _context.Products.FirstOrDefault(x => x.Id == item.ProductId).Price * item.Quantity,
                    Product = _context.Products.FirstOrDefault(x => x.Id == item.ProductId)
                });
            }
            _context.OrderDetails.AddRange(orderdetail);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
