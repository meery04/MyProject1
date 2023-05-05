using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public BaseForMityaProDuctionContext Context { get; }
        public RoleController(BaseForMityaProDuctionContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GettAll()
        {
            List<Role> roles = Context.Roles.ToList();
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Role? roles = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Не найдено!");
            }
            return Ok(roles);
        }
        [HttpPost]
        public IActionResult Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Role roles)
        {
            Context.Roles.Update(roles);
            Context.SaveChanges();
            return Ok(roles);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Role? roles = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Не найдено!");
            }
            Context.Roles.Remove(roles);
            Context.SaveChanges();
            return Ok();
        }
    }
}
