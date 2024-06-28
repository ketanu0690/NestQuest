using NestQuestBackEnd.Domain.Models.Entities;

namespace NestQuestBackEnd.Domain.Models.Contracts
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserById(int userId);
        Task<int> AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
        Task<User> GetUserByEmail(string email);
    }
}
