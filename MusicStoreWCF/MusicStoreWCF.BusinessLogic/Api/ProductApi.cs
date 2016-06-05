using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStoreWCF.BusinessLogic.Api.Interface;
using MusicStoreWCF.BusinessLogic.Extensions;
using MusicStoreWCF.BusinessLogic.Type.DTO;
using MusicStoreWCF.Db;

namespace MusicStoreWCF.BusinessLogic.Api
{
    public class ProductApi : IProductApi
    {
        private readonly MusicStoreContext _dbContext = new MusicStoreContext();

        public List<ProductDTO> GetAllProducts()
        {
            var allDbProducts = _dbContext.Products.ToList();

            return allDbProducts.Select(product => new ProductDTO()
            {
                ProductId = product.ProductId, Name = product.Name, Description = product.Description, Price = product.Price, CategoryId = product.CategoryId
            }).ToList();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            var allDbCategories = _dbContext.Categories.ToList();

            List<CategoryDTO> allCategories = new List<CategoryDTO>();

            foreach (var category in allDbCategories)
            {
                var add = new CategoryDTO()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Products = category.Products?.Select(x => x.MapTopProductDto()).Where(x => x.CategoryId == category.CategoryId).ToList() ?? new List<ProductDTO>() 
                };
                
                allCategories.Add(add);
            }
            return allCategories;
        }

        public void AddProduct(string name, string description, decimal price, int categoryId)
        {
            var addProduct = new Product()
            {
                Name = name,
                Description = description,
                Price = price,
                CategoryId = categoryId
            };
            _dbContext.Products.Add(addProduct);
            _dbContext.SaveChanges();
        }

        public void EditProduct(int productId, string name, string description, decimal price, int categoryId)
        {
            var existProduct = _dbContext.Products.Single(x => x.ProductId == productId);

            existProduct.Name = name;
            existProduct.Description = description;
            existProduct.Price = price;
            existProduct.CategoryId = categoryId;

            _dbContext.SaveChanges();
        }

        public void RemoveProduct(int productId)
        {
            var existProduct = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(existProduct);
            _dbContext.SaveChanges();
        }


    }
}
