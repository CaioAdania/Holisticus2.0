using Holisticus2._0.Controllers;
using Holisticus2._0.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Holisticus2._0.Entities.Response;

namespace Holisticus2._0.Application.Interfaces
{
    public interface IUserService
    {
        Task<ActionResult<List<UsersModel>>> GetAllUsersAsync();
        Task<OperationResult<UsersModel>> LoginUserAsync(string email, string password);
        Task<OperationResult<UsersModel>> AddUserAsync(UsersModel user);
        Task<OperationResult<UsersModel>> DeleteUserAync(int id);
        Task<OperationResult<UsersModel>> EditUserPasswordAsync(int id, string password);
    }
}
