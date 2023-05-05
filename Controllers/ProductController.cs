using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public BaseForMityaProDuctionContext Context { get; }
        public ProductController(BaseForMityaProDuctionContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GettAll()
        {
            List<Product> products = Context.Products.ToList();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Product? products = Context.Products.Where(x => x.ProductsId == id).FirstOrDefault();
            if (products == null)
            {
                return BadRequest("Не найдено!");
            }
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Add(Product products)
        {
            Context.Products.Add(products);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Product products)
        {
            Context.Products.Update(products);
            Context.SaveChanges();
            return Ok(products);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Product? products = Context.Products.Where(x => x.ProductsId == id).FirstOrDefault();
            if (products == null)
            {
                return BadRequest("Не найдено!");
            }
            Context.Products.Remove(products);
            Context.SaveChanges();
            return Ok();
        }
    }
}