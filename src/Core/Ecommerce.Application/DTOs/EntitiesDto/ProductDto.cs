using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.EntitiesDto
{
    public class ProductDto:BaseDto<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
