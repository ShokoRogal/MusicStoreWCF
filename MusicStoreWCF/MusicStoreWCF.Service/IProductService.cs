using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MusicStoreWCF.BusinessLogic.Type.DTO;

namespace MusicStoreWCF.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<ProductDTO> GetAllProducts();

        [OperationContract]
        List<CategoryDTO> GetAllCategories();

        [OperationContract]
        void AddProduct(string name, string description, decimal price, int categoryId);

        [OperationContract]
        void EditProduct(int productId, string name, string description, decimal price, int categoryId);

        [OperationContract]
        void RemoveProduct(int productId);
    }
}
