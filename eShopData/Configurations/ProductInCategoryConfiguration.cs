using eShopData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.ToTable("ProductInCategories");
            builder.HasKey(x => new { x.CategoryID, x.ProductID });
            builder.HasOne(x => x.Product).WithMany(i => i.ProductInCategories).HasForeignKey(i => i.ProductID);
            builder.HasOne(x => x.Category).WithMany(i => i.ProductInCategories).HasForeignKey(i => i.CategoryID);
        }
    }
}
