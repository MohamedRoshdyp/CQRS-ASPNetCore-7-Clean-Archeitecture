﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Product:BaseEntity<int>
    {
        public Product(string name,string descrptin,decimal price,int categoryId)
        {
            Name = name;    
            Description = descrptin;
            Price = price;
            CategoryId = categoryId;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //Navigational Property
        public virtual Category Category { get; set; }
        //[ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
    }
}
