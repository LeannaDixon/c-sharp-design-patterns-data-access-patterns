using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Infrastructure
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ShoppingContext context) : base(context)
        {

        }
        public override Product Update(Product productToUpdate)
        {
            var updatedProduct = context.Products
                .SingleOrDefault(product => product.ProductId == productToUpdate.ProductId);

            updatedProduct.Name = productToUpdate.Name;
            updatedProduct.Price = productToUpdate.Price;
            
            return base.Update(updatedProduct);
        }
    }
}
