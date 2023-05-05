using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationController : ControllerBase
    {
        public BaseForMityaProDuctionContext Context { get; }
        public SpecificationController(BaseForMityaProDuctionContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GettAll()
        {
            List<Specification> specifications = Context.Specifications.ToList();
            return Ok(specifications);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Specification? specification = Context.Specifications.Where(x => x.SpecId == id).FirstOrDefault();
            if (specification == null)
            {
                return BadRequest("Не найдено!");
            }
            return Ok(specification);
        }
        [HttpPost]
        public IActionResult Add(Specification specification)
        {
            Context.Specifications.Add(specification);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Specification specification)
        {
            Context.Specifications.Update(specification);
            Context.SaveChanges();
            return Ok(specification);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Specification? specification = Context.Specifications.Where(x => x.SpecId == id).FirstOrDefault();
            if (specification == null)
            {
                return BadRequest("Не найдено!");
            }
            Context.Specifications.Remove(specification);
            Context.SaveChanges();
            return Ok();
        }
    }
}
