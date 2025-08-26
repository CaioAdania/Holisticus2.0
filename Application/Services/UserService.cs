using Holisticus2._0.Application.Interfaces;
using Holisticus2._0.Controllers;
using Holisticus2._0.Entities.Models;
using Holisticus2._0.Entities.Response;
using Holisticus2._0.Infrastructure.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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

            loginUser.Password = null; 
            return result.Ok(loginUser);
        }

        public async Task<OperationResult<UsersModel>> AddUserAsync(UsersModel user)
        {
            var result = new OperationResult<UsersModel>();

            if (!ValidPassword(user.Password))
            {
                return result.Fail("A senha deve conter: mínimo 8 caracteres, 1 letra maiúscula, 1 letra minúscula, 1 número e 1 caractere especial (@$!%*?&)", "400");
            }

            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return result.Fail("Usuário ou email já cadastrado", "400");
            }
            try
            {
                var password = user.Password;
                var ecryptPassword = BCrypt.Net.BCrypt.HashPassword(password);
                user.Password = ecryptPassword;

                _context.Users.Add(user);
                _context.SaveChangesAsync();

                user.Password = null;
                return result.Ok(user);
            }
            catch
            {
                return result.Fail("Erro ao cadastrar o usuário.", "404");
            }
        }

        public async Task<OperationResult<UsersModel>> DeleteUserAync(int id)
        {
            var result = new OperationResult<UsersModel>();

            try
            {    
                var delete = _context.Users.Where(u => u.Id == id).FirstOrDefault();

                if (delete == null)
                {
                    return result.Fail("Não foi localizado o usuario.", "400");
                }

                _context.Remove(delete);
                _context.SaveChanges();

                return result.Ok(delete);
            }
            catch
            {
                return result.Fail("Erro ao deletar o usuário.", "400");
            }
        }

        public async Task<ActionResult<UsersModel>> EditUserPasswordAsync(int id, string password)
        {
            throw new NotImplementedException();
        }

        private bool ValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            return Regex.IsMatch(password, pattern);
        }
    }
}