using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS_API.Models;

namespace TMS_API.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private TicketManagementContext dbContext;

        public OrderRepository()
        {
            dbContext = new TicketManagementContext();
        }

        public void Add(Order @order)
        {
            dbContext.Add(@order);
            dbContext.SaveChanges();
        }

        public void Delete(Order @order)
        {
            dbContext.Remove(@order);
            dbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = dbContext.Orders;
            return orders;
        }

        public async Task<Order> GetById(long id)
        {
            var @order = await dbContext.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
            return @order;
        }

        public void Update(Order @order)
        {
            dbContext.Entry(@order).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
