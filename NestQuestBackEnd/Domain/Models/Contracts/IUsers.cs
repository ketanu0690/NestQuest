using NestQuestBackEnd.Domain.Models.Entities;

namespace NestQuestBackEnd.Domain.Models.Contracts
{
    public interface IUsers
    {
        Task<List<User>> GetAllUsersAsync();
        Task<int> AddUserInfo(User user);
        Task<User> VerifyUser(string email, string password);
        Task<int> AddUserFavorite(int userId, int propertyId);
    }
}
