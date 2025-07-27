using Holisticus2._0.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Holisticus2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Holisticus2._0.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetUsers")]
        public ActionResult<List<Users>> GetUser()
        {
            var user = _context.Users.ToList();
            return Ok(user);
        }

        [HttpPost]
        [Route("AddUsers")]
        public ActionResult<Users> AddUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult DeleteUser(int id)
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
        public ActionResult UpdateNameUser(int id, string name)
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
