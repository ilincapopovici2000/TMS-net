using TMS_API.Models;

namespace TMS_API.Repository
{
    public interface ITicketCategoryRepository
    {
        IEnumerable<TicketCategory> GetAll();
        Task<TicketCategory> GetById(long id);
        void Add(TicketCategory @ticketCategory);
        void Update(TicketCategory @ticketCategory);
        void Delete(TicketCategory @ticketCategory);
    }
}
