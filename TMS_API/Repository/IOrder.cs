using TMS_API.Models;

namespace TMS_API.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Task<Order> GetById(long id);
        void Add(Order @order);
        void Update(Order @order);
        void Delete(Order @order);
    }
}
