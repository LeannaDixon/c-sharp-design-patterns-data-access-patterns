using MyShop.Domain.LazyPattern;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyShop.Infrastructure
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext context) : base(context)
        {
        }

        public override Customer Add(Customer entity)
        {
            return base.Add(entity);
        }

        public override IEnumerable<Customer> All()
        {
            return base.All().Select(customer =>
            {
                customer.ProfilePictureValueHolder = new ValueHolder<byte[]>((parameter) =>
                {
                    return ProfilePictureService.GetFor(parameter.ToString());
                });
                return customer;
            });
        }

        public override IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            return base.Find(predicate);
        }

        public override Customer Get(Guid id)
        {
            return base.Get(id);
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
