using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Infrastructure
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext context) : base(context)
        {
        }

        public override Customer Update(Customer customerToUpdate)
        {
            var updatedCustomer = context.Customers
                .Single(customer => customer.CustomerId == customerToUpdate.CustomerId);

            updatedCustomer.City = customerToUpdate.City;
            updatedCustomer.Country = customerToUpdate.Country;
            updatedCustomer.Name = customerToUpdate.Country;
            updatedCustomer.PostalCode = customerToUpdate.PostalCode;
            updatedCustomer.ShippingAddress = customerToUpdate.ShippingAddress;

            return base.Update(updatedCustomer);
        }
    }
}
