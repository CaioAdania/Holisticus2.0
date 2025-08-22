using Holisticus2._0.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Holisticus2._0.Application.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<List<UserController>>> GetAllUsersAsync();
        Task<ActionResult<UserController>> LoginUserAsync(string email, string password);
        Task<ActionResult<UserController>> AddUserAsync(UserController user);
        Task<ActionResult<UserController>> DeleteUserAync(int id);
        Task<ActionResult<UserController>> EditUserNameAsync(int id, string userName);
    }
}
