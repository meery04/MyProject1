using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       

        public BaseForMityaProDuctionContext Context { get; }
        public UsersController(BaseForMityaProDuctionContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GettAll()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            User? user = Context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if(user == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(User user) 
        {
            Context.Users.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Не найдено");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok();
        }
    }
  
}
