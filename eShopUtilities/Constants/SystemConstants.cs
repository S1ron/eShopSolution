using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopUtilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "eShopDb";
        public class AppSettings
        {
            public const string DefautLanguageId = "DefautLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }
        public class ProductSettings
        {
            public const int NumberOfFeatureProducts = 4;
            public const int NumberOfLatestProducts = 6;
        }
    }
}
