using MyShop.Domain.Models;

namespace MyShop.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Customer> CustomerRepository { get; }

        void SaveChanges();
    }
}
