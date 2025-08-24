using Holisticus2._0.Application.Interfaces;
using Holisticus2._0.Controllers;
using Holisticus2._0.Entities.Models;
using Holisticus2._0.Entities.Response;
using Holisticus2._0.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Holisticus2._0.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<UsersModel>>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<OperationResult<UsersModel>> LoginUserAsync(string email, string password)
        {
            var result = new OperationResult<UsersModel>();
            var loginUser = _context.Users.Where(u => u.Email == email).FirstOrDefault();

            if (loginUser == null)
            {
                return result.Fail("Login não encontrado.", "400");
            }

            bool passwordLogin = BCrypt.Net.BCrypt.Verify(password, loginUser.Password);

            if (!passwordLogin)
            {
                return result.Fail("Senha incorreta.", "400");
            }

            return result.Ok(loginUser);
        }

        public async Task<ActionResult<UsersModel>> AddUserAsync(UsersModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<UsersModel>> DeleteUserAync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<UsersModel>> EditUserEmailAsync(int id, string userEmail)
        {
            throw new NotImplementedException();
        }

    }
}
