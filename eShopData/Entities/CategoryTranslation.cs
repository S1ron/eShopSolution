using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Entities
{
    public class CategoryTranslation
    {
        public int ID { set; get; }
        public int CategoryID { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageID { set; get; }
        public string SeoAlias { set; get; }
        public Category Category { get; set; }
        public Language Language { get; set; }
    }
}
