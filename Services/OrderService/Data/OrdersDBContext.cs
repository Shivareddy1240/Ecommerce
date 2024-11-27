using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data
{
    public class OrdersDBContext:DbContext
    {
        public OrdersDBContext(DbContextOptions<OrdersDBContext> options) : base(options) { }
            public DbSet<Order> Orders { get; set; }
    }
}
