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

        /// <summary>
        /// Efetua o login.
        /// </summary>
        /// <returns>Retorna o usuário logado.</returns>
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

        /// <summary>
        /// Inclui novos usuários.
        /// </summary>
        /// <returns>Retorna os usuarios incluidos.</returns>
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

        /// <summary>
        /// Delete um usuario.
        /// </summary>
        /// <returns>Retorna o usuário excluido.</returns>
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

        [HttpPut]
        [Route("{id}/{newPassword}/UpdatePasswordUser")]
        public async Task<ActionResult<UsersModel>> UpdatePasswordUser(int id, string newPassword)
        {
            try
            {
                var password = await _userService.EditUserPasswordAsync(id, newPassword);

                if(password.Success == true)
                {
                    return Ok($"A senha do usuário de Id: {id}, foi atualizada.");
                }

                return BadRequest(new
                {
                    Message = password.ErrorMessage,
                    ErrorType = password.ErrorType
                });
            }
            catch
            {
                return BadRequest("Erro no serviço.");
            }
        }

    }
}
