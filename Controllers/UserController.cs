using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Holisticus2._0.Entities.Models;
using Holisticus2._0.Infrastructure.Data;
using Holisticus2._0.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

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

        /// <summary>
        /// Busca os usuarios.
        /// </summary>
        /// <returns>Retorna os usuarios.</returns>
        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<List<UsersModel>>> GetAllUsers()
        {
            var getUser = await _userService.GetAllUsersAsync();
            return Ok(getUser);
        }

        [HttpPost]
        [Route("{email}/{password}/LoginUser")]
        public async Task<ActionResult<UsersModel>> LoginUser(string email, string password)
        {
            try
            {
                var login = _userService.LoginUserAsync(email, password);

            }
            catch
            {
                return BadRequest("Erro no serviço.");
            }
        }

        //[HttpPost]
        //[Route("AddUsers")]
        //public async Task<ActionResult<UsersModel>> AddUser(UserController user)
        //{
        //    var password = user.Password;
        //    var ecryptPassword = BCrypt.Net.BCrypt.HashPassword(password);
        //    user.Password = ecryptPassword;

        //    _context.Users.Add(user);
        //    _context.SaveChanges();

        //    return Ok(user);
        //}

        //[HttpDelete]
        //[Route("{id}/DeleteUser")]
        //public async Task<ActionResult<UsersModel>> DeleteUser(int id)
        //{
        //    var delete = _context.Users.Where(u => u.Id == id).FirstOrDefault();

        //    if(delete != null)
        //    {
        //        _context.Remove(delete);
        //        _context.SaveChanges();
        //    }
        //    else
        //    {
        //        return BadRequest("Não foi localizado o usuario.");
        //    }

        //    return Ok(delete);
        //}

        //[HttpPost]
        //[Route("{id}/{newEmail}/UpdateUserEmail")]
        //public async Task<ActionResult<UsersModel>> UpdateUserEmail(int id, string newEmail)
        //{
        //    var update = _context.Users.Where(u => u.Id == id).FirstOrDefault();

        //    if(update != null)
        //    {
        //        update.Name = name;
        //        _context.SaveChanges();
        //    }
        //    else
        //    {
        //        return BadRequest("Usuario não encontrado");
        //    }

        //    return Ok(update);
        //}

    }
}
