using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Holisticus2._0.Entities.Models;
using Holisticus2._0.Infrastructure.Data;
using Holisticus2._0.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Holisticus2._0.Entities.Response;

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
                var login = await _userService.LoginUserAsync(email, password);

                if(login.Success == true)
                {
                    return Ok(login.Data);
                }

                return BadRequest(new
                {
                    Message = login.ErrorMessage,
                    ErrorType = login.ErrorType
                });

            }
            catch
            {
                return BadRequest("Erro no serviço.");
            }
        }

        [HttpPost]
        [Route("AddUsers")]
        public async Task<ActionResult<UsersModel>> AddUser(UsersModel user)
        {
            try
            {
                var addUser = await _userService.AddUserAsync(user);

                if (addUser.Success == true)
                {
                    return Ok(addUser.Data);
                }

                return BadRequest(new
                {
                    Message = addUser.ErrorMessage,
                    ErrorType = addUser.ErrorType
                });
            }
            catch
            {
                return BadRequest("Erro no serviço.");
            }
            
        }

        [HttpDelete]
        [Route("{id}/DeleteUser")]
        public async Task<ActionResult<UsersModel>> DeleteUser(int id)
        {
            try
            {
                var idUser = await _userService.DeleteUserAync(id);

                if (idUser.Success == true)
                {
                    return Ok($"O usuário de Id:{id}, foi deletado.");
                }

                return BadRequest(new
                {
                    Message = idUser.ErrorMessage,
                    ErrorType = idUser.ErrorType
                });
            }
            catch
            {
                return BadRequest("Erro no serviço.");
            }
        }

        //[HttpPost]
        //[Route("{id}/{newPassword}/UpdatePasswordUser")]
        //public async Task<ActionResult<UsersModel>> UpdatePasswordUser(int id, string password)
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
