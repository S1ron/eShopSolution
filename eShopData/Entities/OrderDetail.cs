using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Entities
{
    public class OrderDetail
    {
        public int OrderID { set; get; }
        public int ProductID { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public Order Order { set; get; }
        public Product Product { set; get; }

    }
}
