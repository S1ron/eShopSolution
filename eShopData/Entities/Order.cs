using eShopData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Entities
{
    public class Order
    {
        public int Id { set; get;}
        public DateTime OrderDate { set; get;}
        public Guid UserId { set; get;}
        public string ShipName { set; get;}
        public string ShipAddress { set; get;}
        public string ShipEmail { set; get;}
        public string ShipPhoneNumber { set; get;}
        public OrderStatus Status { set; get; }
        public List<OrderDetail> OrderDetails { set; get; }
        public AppUser AppUser { set; get; }

    }
}
