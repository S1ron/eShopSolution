using eShopData.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Entities
{
    public class Promotion
    {
        public int ID {set; get;}
        public DateTime FromDate {set; get;}
        public DateTime ToDate {set; get;}
        public bool ApplyForAll {set; get;}
        public int? DiscountPercent {set; get;}
        public decimal? DiscountAmount {set; get;}
        public string ProductIDs {set; get;}
        public string ProductCategoryIDs {set; get;}
        public Status Status {set; get;}
        public string Name { set; get; }

    }
}
