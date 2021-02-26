using AutoFixture;
using Moq;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Web.Controllers;
using MyShop.Web.Models;
using NUnit.Framework;
using System;

namespace MyShop.Test
{
    public class OrderRepositoryShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CallAddMethod()
        {
            var sut = new Mock<IRepository<Order>>();
            var mockedProductRepository = new Mock<IRepository<Product>>();
            var mockedCustomerRepository = new Mock<IRepository<Customer>>();

            var orderController = new OrderController(sut.Object, 
                mockedProductRepository.Object,
                mockedCustomerRepository.Object);

            var fixture = new Fixture();
            var createOrderModel = fixture.Create<CreateOrderModel>();

            orderController.Create(createOrderModel);

            sut.Verify(method => method.Add(It.IsAny<Order>()));
        }
    }
}