using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MusicStoreWCF.BusinessLogic.Api;
using MusicStoreWCF.BusinessLogic.Api.Interface;
using MusicStoreWCF.BusinessLogic.Type.DTO;

namespace MusicStoreWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        public List<ProductDTO> GetAllProducts()
        {
            IProductApi product = new ProductApi();

            return product.GetAllProducts();
        }

        public List<CategoryDTO> GetAllCategories()
        {
            IProductApi category = new ProductApi();
            return category.GetAllCategories();
        }

        public void AddProduct(string name, string description, decimal price, int categoryId)
        {
            IProductApi api = new ProductApi();
            api.AddProduct(name, description, price, categoryId);
        }

        public void EditProduct(int productId, string name, string description, decimal price, int categoryId)
        {
            IProductApi api = new ProductApi();
            api.EditProduct(productId, name, description, price, categoryId);
        }

        public void RemoveProduct(int productId)
        {
            IProductApi api = new ProductApi();
            api.RemoveProduct(productId);
        }
    }
}
