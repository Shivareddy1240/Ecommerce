using OrderService.Models;

namespace OrderService.Repository
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Add(Order order);
        void Save();
    }
}
