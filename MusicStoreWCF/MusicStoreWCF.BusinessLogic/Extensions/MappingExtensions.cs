using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStoreWCF.BusinessLogic.Type.DTO;
using MusicStoreWCF.Db;

namespace MusicStoreWCF.BusinessLogic.Extensions
{
    internal static class MappingExtensions
    {
        public static ProductDTO MapTopProductDto(this Product productDTO)
        {
            return new ProductDTO
            {
                ProductId = productDTO.ProductId,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                CategoryId = productDTO.CategoryId
            };
        }
    }
}
