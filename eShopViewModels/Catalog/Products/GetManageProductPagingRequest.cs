using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShopViewModels.Common;

namespace eShopViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string? Keyword { set; get; }
        public string LanguageId { set; get; }
        public int? CategoryId { set; get; }
    }
}
