using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStoreWCF.Web.Models;
using MusicStoreWCF.Web.ProductService;

namespace MusicStoreWCF.Web.Extensions
{
    internal static class MappingExtensions
    {
        public static Product MapTopProduct(this ProductDTO product)
        {
            return new Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
        }
    }
}
