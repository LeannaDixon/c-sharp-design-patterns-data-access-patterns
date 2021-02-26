using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingContext _context;
        private IRepository<Order> _orderRepository;
        private IRepository<Product> _productRepository;
        private IRepository<Customer> _customerRepository;

        public IRepository<Product> ProductRepository 
        { 
            get
            {
                return _productRepository == null ? _productRepository = new ProductRepository(_context) 
                    : _productRepository;
            }
        }

        public IRepository<Order> OrderRepository
        {
            get
            {
                return _orderRepository == null ? _orderRepository = new OrderRepository(_context) : _orderRepository;
            }
        }

        public IRepository<Customer> CustomerRepository
        {
            get
            {
                return _customerRepository == null ? _customerRepository = new CustomerRepository(_context) : _customerRepository;
            }
        }

        public UnitOfWork(ShoppingContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
