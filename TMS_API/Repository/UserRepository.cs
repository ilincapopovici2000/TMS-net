using Microsoft.EntityFrameworkCore;
using TMS_API.Models;

namespace TMS_API.Repository
{
    public class UserRepository : IUserRepository
    {

        private TicketManagementContext dbContext;

        public UserRepository()
        {
            dbContext = new TicketManagementContext();
        }

        public void Add(User @User)
        {
            dbContext.Add(@User);
            dbContext.SaveChanges();
        }

        public void Delete(User @User)
        {
            dbContext.Remove(@User);
            dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            var User = dbContext.Users;
            return User;
        }

        public async Task<User> GetById(long id)
        {
            var @user = await dbContext.Users.Where(e => e.Userid == id).FirstOrDefaultAsync();
            return @user;
        }

        public void Update(User @user)
        {
            dbContext.Entry(@user).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
