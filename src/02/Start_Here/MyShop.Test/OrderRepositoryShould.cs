using AutoFixture;
using AutoFixture.AutoMoq;
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
            var fixture = new Fixture()
                .Customize(new AutoMoqCustomization());

            var sut = fixture.Freeze<Mock<IUnitOfWork>>();
         
            var orderController = new OrderController(sut.Object);

            
            var createOrderModel = fixture.Create<CreateOrderModel>();

            orderController.Create(createOrderModel);
            sut.Verify(repo => repo.OrderRepository.Add(It.IsAny<Order>()));
        }
    }
}