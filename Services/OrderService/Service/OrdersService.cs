using OrderService.Models;
using OrderService.Repository;

namespace OrderService.Service
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return _ordersRepository.GetAll();
        }
        public Order AddOrder(Order order)
        {
            _ordersRepository.Add(order);
            _ordersRepository.Save();
            return order;
        }
    }
}
