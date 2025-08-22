using Holisticus2._0.Application.Interfaces;
using Holisticus2._0.Controllers;
using Holisticus2._0.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Holisticus2._0.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public Task<ActionResult<List<UserController>>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
        public Task<ActionResult<UserController>> LoginUserAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<UserController>> AddUserAsync(UserController user)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<UserController>> DeleteUserAync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<UserController>> EditUserNameAsync(int id, string userName)
        {
            throw new NotImplementedException();
        }

    }
}
