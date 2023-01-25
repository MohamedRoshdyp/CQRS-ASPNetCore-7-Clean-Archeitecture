using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Product:BaseEntity<int>
    {
        public Product(string name,string descrptin,decimal price)
        {
            Name = name;    
            Description = descrptin;
            Price = price;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
