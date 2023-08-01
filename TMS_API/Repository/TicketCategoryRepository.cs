using Microsoft.EntityFrameworkCore;
using TMS_API.Models;

namespace TMS_API.Repository
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {

        private TicketManagementContext dbContext;

        public TicketCategoryRepository()
        {
            dbContext = new TicketManagementContext();
        }

        public void Add(TicketCategory @ticketCategory)
        {
            dbContext.Add(@ticketCategory);
            dbContext.SaveChanges();
        }

        public void Delete(TicketCategory @ticketCategory)
        {
            dbContext.Remove(@ticketCategory);
            dbContext.SaveChanges();
        }

        public IEnumerable<TicketCategory> GetAll()
        {
            var ticketCategory = dbContext.TicketCategories;
            return ticketCategory;
        }

        public async Task<TicketCategory> GetById(long id)
        {
            var @ticketCategory = await dbContext.TicketCategories.Where(e => e.TicketCategoryId == id).FirstOrDefaultAsync();
            return @ticketCategory;
        }

        public void Update(TicketCategory @ticketCategory)
        {
            dbContext.Entry(@ticketCategory).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
