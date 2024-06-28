using Microsoft.EntityFrameworkCore;
using NestQuestBackEnd.DAL.DBContext;
using NestQuestBackEnd.Domain.Models.Contracts;
using NestQuestBackEnd.Domain.Models.Entities;
using NestQuestBackEnd.Utility;

namespace NestQuestBackEnd.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DbServiceContext _context;

        public UserRepository(DbServiceContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch
            {
                throw;
            }

        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<int> AddUser(User user)
        {
            user.Password = Utilities.HashPassword(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

    }
}
