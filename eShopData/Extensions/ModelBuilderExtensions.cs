using eShopData.Entities;
using eShopData.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopData.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" }
               );
            modelBuilder.Entity<Language>().HasData(
                new Language() { ID = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { ID = "en-US", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID = 1,
                    IsShowOnHome = true,
                    ParentID = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     ID = 2,
                     IsShowOnHome = true,
                     ParentID = null,
                     SortOrder = 2,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { ID = 1, CategoryID = 1, Name = "Áo nam", LanguageID = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                  new CategoryTranslation() { ID = 2, CategoryID = 1, Name = "Men Shirt", LanguageID = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "The shirt products for men" },
                  new CategoryTranslation() { ID = 3, CategoryID = 2, Name = "Áo nữ", LanguageID = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang women" },
                  new CategoryTranslation() { ID = 4, CategoryID = 2, Name = "Women Shirt", LanguageID = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women", SeoTitle = "The shirt products for women" }
                    );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               ID = 1,
               DateCreated = DateTime.Now,
               OriginalPrice = 100000,
               Price = 200000,
               Stock = 0,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     ID = 1,
                     ProductID = 1,
                     Name = "Áo sơ mi nam trắng Việt Tiến",
                     LanguageID = "vi-VN",
                     SeoAlias = "ao-so-mi-nam-trang-viet-tien",
                     SeoDescription = "Áo sơ mi nam trắng Việt Tiến",
                     SeoTitle = "Áo sơ mi nam trắng Việt Tiến",
                     Details = "Áo sơ mi nam trắng Việt Tiến",
                     Description = "Áo sơ mi nam trắng Việt Tiến"
                 },
                    new ProductTranslation()
                    {
                        ID = 2,
                        ProductID = 1,
                        Name = "Viet Tien Men T-Shirt",
                        LanguageID = "en-US",
                        SeoAlias = "viet-tien-men-t-shirt",
                        SeoDescription = "Viet Tien Men T-Shirt",
                        SeoTitle = "Viet Tien Men T-Shirt",
                        Details = "Viet Tien Men T-Shirt",
                        Description = "Viet Tien Men T-Shirt"
                    });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductID = 1, CategoryID = 1 }
                );
        }   
    }
}
