using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStoreWCF.BusinessLogic.Type.DTO;

namespace MusicStoreWCF.BusinessLogic.Api.Interface
{
    public interface IProductApi
    {
        List<ProductDTO> GetAllProducts();
        List<CategoryDTO> GetAllCategories();
        void AddProduct(string name, string description, decimal price, int categoryId);
        void EditProduct(int productId, string name, string description, decimal price, int categoryId);
        void RemoveProduct(int productId);
    }
}
