using Holisticus2._0.Application.Interfaces;
using Holisticus2._0.Controllers;
using Holisticus2._0.Entities.Models;
using Holisticus2._0.Infrastructure.Data;
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
        public async Task<ActionResult<UsersModel>> LoginUserAsync(string email, string password)
        {
            throw new NotImplementedException();
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
