using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Holisticus2._0.Entities.Models;
using Holisticus2._0.Infrastructure.Data;
using Holisticus2._0.Application.Interfaces;

namespace Holisticus2._0.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<List<UserController>>> GetAllUsers()
        {
            var user = _context.Users.ToList();
            return Ok(user);
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task <ActionResult<UserController>> LoginUser(string email, string password)
        {
            var loginUser = _context.Users.Where(u => u.Email == email).FirstOrDefault();

            if (loginUser == null)
            {
                return Unauthorized("Usuario não encontrado.");
            }

            bool passwordLogin = BCrypt.Net.BCrypt.Verify(password, loginUser.Password);

            if (!passwordLogin)
            {
                return Unauthorized("Senha errada.");
            }
            
            return Ok(loginUser);
        }

        [HttpPost]
        [Route("AddUsers")]
        public async Task<ActionResult<UserController>> AddUser(UserController user)
        {
            var password = user.Password;
            var ecryptPassword = BCrypt.Net.BCrypt.HashPassword(password);
            user.Password = ecryptPassword;

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult<UserController>> DeleteUser(int id)
        {
            var delete = _context.Users.Where(u => u.Id == id).FirstOrDefault();

            if(delete != null)
            {
                _context.Remove(delete);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest("Não foi localizado o usuario.");
            }

            return Ok(delete);
        }

        [HttpPost]
        [Route("UpdateUserName")]
        public async Task<ActionResult<UserController>> UpdateNameUser(int id, string userName)
        {
            var update = _context.Users.Where(u => u.Id == id).FirstOrDefault();

            if(update != null)
            {
                update.Name = name;
                _context.SaveChanges();
            }
            else
            {
                return BadRequest("Usuario não encontrado");
            }

            return Ok(update);
        }

    }
}
