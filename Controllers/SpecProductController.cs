using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecProductController : ControllerBase
    {
        public BaseForMityaProDuctionContext Context { get; }
        public SpecProductController(BaseForMityaProDuctionContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GettAll()
        {
            List<SpecProduct> specProducts = Context.SpecProducts.ToList();
            return Ok(specProducts);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            SpecProduct? specProduct = Context.SpecProducts.Where(x => x.SpecProdId == id).FirstOrDefault();
            if (specProduct == null)
            {
                return BadRequest("Не найдено!");
            }
            return Ok(specProduct);
        }
        [HttpPost]
        public IActionResult Add(SpecProduct specProduct)
        {
            Context.SpecProducts.Add(specProduct);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(SpecProduct specProduct)
        {
            Context.SpecProducts.Update(specProduct);
            Context.SaveChanges();
            return Ok(specProduct);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            SpecProduct? specProduct = Context.SpecProducts.Where(x => x.SpecProdId == id).FirstOrDefault();
            if (specProduct == null)
            {
                return BadRequest("Не найдено!");
            }
            Context.SpecProducts.Remove(specProduct);
            Context.SaveChanges();
            return Ok();
        }
    }
}
