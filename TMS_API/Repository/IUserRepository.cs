using TMS_API.Models;

namespace TMS_API.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        Task<User> GetById(long id);
        void Add(User @user);
        void Update(User @user);
        void Delete(User @user);
    }
}
