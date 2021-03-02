using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyShop.Infrastructure
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(ShoppingContext context) : base(context)
        {
           
        }
        public override Order Update(Order orderToUpdate)
        {
            var updatedOrder = context.Orders
                 .Include(orders => orders.LineItems)
                    .ThenInclude(lineItems => lineItems.Product)
                 .Single(order => order.OrderId == orderToUpdate.OrderId);

            updatedOrder.OrderDate = orderToUpdate.OrderDate;
            updatedOrder.LineItems = orderToUpdate.LineItems;
            
            return base.Update(updatedOrder);
        }

        public override IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return context.Orders
                .Include(orders => orders.LineItems)
                    .ThenInclude(lineItems => lineItems.Product)
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }

        public override IEnumerable<Order> All()
        {
            return context.Orders
                .Include(orders => orders.LineItems)
                    .ThenInclude(lineItems => lineItems.Product)
                    .ToList();
        }
    }
}
