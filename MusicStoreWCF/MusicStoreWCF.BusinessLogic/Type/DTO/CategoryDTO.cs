using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreWCF.BusinessLogic.Type.DTO
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProductDTO> Products { get; set; }
    }
}
