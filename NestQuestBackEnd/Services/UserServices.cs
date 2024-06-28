using NestQuestBackEnd.Domain.Models.Contracts;
using NestQuestBackEnd.Domain.Models.Entities;
using NestQuestBackEnd.Utility;

namespace NestQuestBackEnd.Services
{
    public class UserServices : IUsers
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                return await _userRepository.GetAllUsersAsync();
            }
            catch
            {
                throw;

            }

        }

        public async Task<int> AddUserInfo(User user)
        {
            try
            {
                return await _userRepository.AddUser(user);
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> VerifyUser(string email, string password)
        {
            // Retrieve the user from the repository
            var user = await _userRepository.GetUserByEmail(email);

            // Check if the user exists and the password is correct
            if (user != null && VerifyPassword(password, user.Password))
            {
                return user;
            }

            return null;
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            string hashedInputPassword = Utilities.HashPassword(inputPassword);
            return storedPassword == hashedInputPassword;
        }

        public async Task<int> AddUserFavorite(int userId, int propertyId)
        {
            try
            {
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
