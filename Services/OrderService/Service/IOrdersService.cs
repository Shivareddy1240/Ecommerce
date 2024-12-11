using OrderService.Models;

namespace OrderService.Service
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetAllOrders();
        Order AddOrder(Order order);
    }
}
