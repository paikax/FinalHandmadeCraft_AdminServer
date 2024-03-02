using System.Collections.Generic;
using System.Threading.Tasks;
using HandMadeCraftAdminServer.DbContext;
using HandMadeCraftAdminServer.Models.User;
using Microsoft.EntityFrameworkCore;

namespace HandMadeCraftAdminServer.Services
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _db;

        public UserService(UserDbContext db)
        {
            _db = db;
        }
        
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task UpdateUser(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
        }
    }
}