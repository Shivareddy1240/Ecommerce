using OrderService.Data;
using OrderService.Models;

namespace OrderService.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersDBContext _dbContext;
        public OrdersRepository(OrdersDBContext ordersDbContext)
        {
            _dbContext = ordersDbContext;
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }
        public Order GetById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Order order)
        {
            _dbContext.Orders.Add(order);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
