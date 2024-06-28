using Microsoft.AspNetCore.Mvc;
using NestQuestBackEnd.Domain.Models.Contracts;
using NestQuestBackEnd.Domain.Models.Entities;
using NestQuestBackEnd.Domain.Models.ResponseWrapper;

namespace NestQuestBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsers _usersService;
        public UsersController(IUsers usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseWrapper<List<User>>>> GetUsers()
        {

            try
            {
                var res = new ResponseWrapper<List<User>>();
                var users = await _usersService.GetAllUsersAsync();
                if (users != null)
                {
                    res.Data = users;
                    res.SuccessMessage = "Succefully Fetched Data";
                    res.IsSuccess = true;
                }
                else
                {
                    res.IsSuccess = false;
                    res.ErrorMessage = "User Data Not Found";
                }
                return Ok(res);

            }
            catch
            {
                throw;

            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseWrapper<string>>> RegisterUser(User userInfo)
        {
            var response = new ResponseWrapper<string>();

            try
            {
                // Validation logic can be added here if needed
                if (userInfo == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = "User information is required.";
                    return BadRequest(response);
                }

                // Call UserRepository to register user
                var registeredUser = await _usersService.AddUserInfo(userInfo);

                response.IsSuccess = true;
                response.SuccessMessage = "User registered successfully.";
                response.Data = "User ID: " + registeredUser; 

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "An error occurred while registering the user: " + ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseWrapper<User>>> LoginUser(string email, string password)
        {
            var response = new ResponseWrapper<User>();

            try
            {
                // Verify user credentials using the service
                var user = await _usersService.VerifyUser(email, password);

                if (user != null)
                {
                    // Login successful
                    response.IsSuccess = true;
                    response.SuccessMessage = "Login successful.";
                    response.Data = user;

                    return Ok(response);
                }
                else
                {
                    // Invalid credentials
                    response.IsSuccess = false;
                    response.ErrorMessage = "Invalid email or password.";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "An error occurred while logging in: " + ex.Message;
                return StatusCode(500, response);
            }
        }

        [HttpPost("AddUserFavorite")]
        public async Task<ActionResult<ResponseWrapper<string>>> AddUserFavorite(int userId, int propertyId)
        {
            try
            {
                var result = await _usersService.AddUserFavorite(userId, propertyId);
                var message = result > 0 ? "Successfully Added" : "Failed to Add";

                return Ok(new ResponseWrapper<string>
                {
                    IsSuccess = result > 0,
                    SuccessMessage = message,
                    Data = result.ToString()
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseWrapper<string> { IsSuccess = false, ErrorMessage = ex.Message });
            }
        }

    }
}
