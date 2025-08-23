using Holisticus2._0.Controllers;
using Holisticus2._0.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Holisticus2._0.Application.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<List<UsersModel>>> GetAllUsersAsync();
        Task<ActionResult<UsersModel>> LoginUserAsync(string email, string password);
        Task<ActionResult<UsersModel>> AddUserAsync(UsersModel user);
        Task<ActionResult<UsersModel>> DeleteUserAync(int id);
        Task<ActionResult<UsersModel>> EditUserEmailAsync(int id, string userEmail);
    }
}
