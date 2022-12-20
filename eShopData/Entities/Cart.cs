using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Entities
{
    public class Cart
    {
        public int ID { set; get;}
        public int ProductID { set; get;}
        public int Quantity { set; get;}
        public decimal Price { set; get; }
        public Guid UserId { get; set; }
        public Product Product { set; get; }
        public DateTime DateCreated { set; get; }
    }
}
