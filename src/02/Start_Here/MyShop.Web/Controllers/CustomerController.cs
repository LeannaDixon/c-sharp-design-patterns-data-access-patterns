using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private IRepository<Customer> CustomerRepository;

        public CustomerController(IRepository<Customer> CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;
        }

        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                var customers = CustomerRepository.All();
                return View(customers);
            }
            else
            {
                var customer = CustomerRepository.Get(id.Value);
                return View(new[] { customer });
            }
        }
    }
}
