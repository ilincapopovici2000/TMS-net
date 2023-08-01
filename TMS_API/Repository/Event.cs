using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS_API.Models;

namespace TMS_API.Repository
{
    public class EventRepository : IEventRepository
    {

        private TicketManagementContext dbContext;

        public EventRepository()
        {
            dbContext = new TicketManagementContext();
        }

        public void Add(Event @event)
        {
            dbContext.Add(@event);
            dbContext.SaveChanges();
        }

        public void Delete(Event @event)
        {
            dbContext.Remove(@event);
            dbContext.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = dbContext.Events;
            return events;
        }

        public async Task<Event> GetById(long id)
        {
            var @event = await dbContext.Events.Where(e => e.EventId == id).FirstOrDefaultAsync();
            return @event;
        }

        public void Update(Event @event)
        {
            dbContext.Entry(@event).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
