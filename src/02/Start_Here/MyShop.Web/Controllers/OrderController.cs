using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Web.Models;

namespace MyShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private ShoppingContext context;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;
        private CustomerRepository customerRepository;

        public OrderController(OrderRepository orderRepository, 
            ProductRepository productRepository,
            CustomerRepository customerRepository)
        {
            context = new ShoppingContext();
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            //var orders = context.Orders
            //    .Include(order => order.LineItems)
            //    .ThenInclude(lineItem => lineItem.Product)
            //    .Where(order => order.OrderDate > DateTime.UtcNow.AddDays(-1)).ToList();

            var orders = orderRepository.All()
                .Where(order => order.OrderDate > DateTime.UtcNow.AddDays(-1)).ToList());

            return View(orders);
        }

        public IActionResult Create()
        {
            //var products = context.Products.ToList();
            var products = productRepository.All();

            return View(products);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            var customer = new Customer
            {
                Name = model.Customer.Name,
                ShippingAddress = model.Customer.ShippingAddress,
                City = model.Customer.City,
                PostalCode = model.Customer.PostalCode,
                Country = model.Customer.Country
            };
            customerRepository.Add(customer);
            customerRepository.SaveChanges();

            var order = new Order
            {
                LineItems = model.LineItems
                    .Select(line => new LineItem { ProductId = line.ProductId, Quantity = line.Quantity })
                    .ToList(),

                Customer = customer
            };

            orderRepository.Add(order);
            orderRepository.SaveChanges();

            //context.Orders.Add(order);
            //context.SaveChanges();

            return Ok("Order Created");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
