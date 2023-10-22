using ApplicationAPI.Data.Abstract;
using ApplicationAPI.Entity;

namespace ApplicationAPI.Data.Concrete.EfCore
{
    public class EfUserRepository : IUserRepository
    {
        private ApplicationContext _context;
        public EfUserRepository(ApplicationContext context)
        {
            _context = context;
            
        }
        public IQueryable<User> Users => _context.Users;

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}