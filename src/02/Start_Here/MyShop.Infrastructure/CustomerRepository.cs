using MyShop.Domain.Models;
using MyShop.Infrastructure.LazyPattern;
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
            return base.All().Select(MapToProxy);
            //return base.All().Select(customer =>
           //return context.Customers.Select(customer =>
           // {
                // ***********For every customer loaded,
                // we initialise the ValueHolder and pass in the fucntion.
                //customer.ProfilePictureValueHolder = new Lazy<byte[]>(() =>
                //{
                //    return ProfilePictureService.GetFor(customer.Name.ToString());
                //});
                //return customer;
            //});
        }

        public override IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            return base.
                Find(predicate)
                .Select(MapToProxy);
                //.Select(customer =>
                //{
                //    customer.ProfilePictureValueHolder = new Lazy<byte[]>(() =>
                //    {
                //          return ProfilePictureService.GetFor(customer.Name.ToString());
                //    });
                //    return customer;
                //});
        }

        public override Customer Get(Guid id)
        {
             return MapToProxy(base.Get(id));
            
            //var customer = base.Get(id)
            //customer.ProfilePictureValueHolder = new Lazy<byte[]>(() =>
            //{
            //    return ProfilePictureService.GetFor(customer.Name.ToString());
            //});
            //return customer;
        }

        public override Customer Update(Customer customerToUpdate)
        {
            var updatedCustomer = Get(customerToUpdate.CustomerId);
            updatedCustomer = MapToProxy(updatedCustomer);
                
                

            //var updatedCustomer = context.Customers
            //    .Single(customer => customer.CustomerId == customerToUpdate.CustomerId);

            updatedCustomer.City = customerToUpdate.City;
            updatedCustomer.Country = customerToUpdate.Country;
            updatedCustomer.Name = customerToUpdate.Country;
            updatedCustomer.PostalCode = customerToUpdate.PostalCode;
            updatedCustomer.ShippingAddress = customerToUpdate.ShippingAddress;

            return base.Update(updatedCustomer);
        }

        private CustomerProxy MapToProxy(Customer customerToMap)
        {
            return new CustomerProxy()
            {
                Name = customerToMap.Name,
                CustomerId = customerToMap.CustomerId,
                City = customerToMap.City,
                Country = customerToMap.Country,
                PostalCode = customerToMap.PostalCode,
                ShippingAddress = customerToMap.ShippingAddress
            };     
        }
    }
}
