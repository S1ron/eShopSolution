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
        public List<int>? CategoryIds { set; get; }
        public string LanguageId { set; get; }
    }
}
