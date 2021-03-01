using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Domain.Models
{
    public class Product
    {
        public Guid ProductId { get; private set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public Product()
        {
            ProductId = Guid.NewGuid();
        }
    }
}
