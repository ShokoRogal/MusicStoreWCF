using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MusicStoreWCF.Web.Extensions;
using MusicStoreWCF.Web.Models;
using MusicStoreWCF.Web.ProductService;

namespace MusicStoreWCF.Web.Wrappers
{
    public class ProductWrapper
    {
        private readonly ProductServiceClient prdClient = new ProductServiceClient();

        public List<Product> GetAllProducts()
        {
            var allDbProducts = prdClient.GetAllProducts();

            return allDbProducts.Select(product => new Product()
            {
                ProductId = product.ProductId, Name = product.Name, Description = product.Description, Price = product.Price, CategoryId = product.CategoryId
            }).ToList();
        }

        public List<Category> GetAllCategories()
        {
            var allDbCategories = prdClient.GetAllCategories();

            List<Category> allCategoriesList = new List<Category>();

            foreach (var category in allDbCategories)
            {
                var add = new Category()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Products = category.Products == null ? new List<Product>() : category.Products.Select(x => x.MapTopProduct()).Where(x => x.CategoryId == category.CategoryId).ToList() 
                };
                allCategoriesList.Add(add);
            }
            return allCategoriesList;
        }
    }
}
