using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        public BaseForMityaProDuctionContext Context { get; }
        public StatusController(BaseForMityaProDuctionContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GettAll()
        {
            List<Status> statuses = Context.Statuses.ToList();
            return Ok(statuses);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Status? statuses = Context.Statuses.Where(x => x.StatusId == id).FirstOrDefault();
            if (statuses == null)
            {
                return BadRequest("Не найдено!");
            }
            return Ok(statuses);
        }
        [HttpPost]
        public IActionResult Add(Status statuses)
        {
            Context.Statuses.Add(statuses);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Status statuses)
        {
            Context.Statuses.Update(statuses);
            Context.SaveChanges();
            return Ok(statuses);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Status? statuses = Context.Statuses.Where(x => x.StatusId == id).FirstOrDefault();
            if (statuses == null)
            {
                return BadRequest("Не найдено!");
            }
            Context.Statuses.Remove(statuses);
            Context.SaveChanges();
            return Ok();
        }
    }
}
