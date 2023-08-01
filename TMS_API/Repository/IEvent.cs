
using TMS_API.Models;

namespace TMS_API.Repository
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Task<Event> GetById(long id);
        void Add(Event @event);
        void Update(Event @event);
        void Delete(Event @event);
    }
}
