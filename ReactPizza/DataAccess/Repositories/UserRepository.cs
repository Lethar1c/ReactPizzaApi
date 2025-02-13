using Microsoft.EntityFrameworkCore;
using ReactPizza.DataAccess.Models;

namespace ReactPizza.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _context.Users.Include(u => u.Role).OrderBy(u => u.Id).Last();
        }

        public async Task Delete(int id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> Get(int id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<User?> Update(int id, User newUser)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return null;
            user.Email = newUser.Email;
            user.Role = newUser.Role;
            user.Name = newUser.Name;
            user.HashedPassword = newUser.HashedPassword;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
