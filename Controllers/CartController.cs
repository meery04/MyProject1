using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public BaseForMityaProDuctionContext Context { get; }
        public CartController(BaseForMityaProDuctionContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GettAll()
        {
            List<Cart> cart = Context.Carts.ToList();
            return Ok(cart);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Cart? cart = Context.Carts.Where(x => x.CartId == id).FirstOrDefault();
            if (cart == null)
            {
                return BadRequest("Не найдено!");
            }
            return Ok(cart);
        }
        [HttpPost]
        public IActionResult Add(Cart cart )
        {
            Context.Carts.Add(cart);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Cart cart)
        {
            Context.Carts.Update(cart);
            Context.SaveChanges();
            return Ok(cart);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Cart? cart = Context.Carts.Where(x => x.CartId == id).FirstOrDefault();
            if (cart == null)
            {
                return BadRequest("Не найдено!");
            }
            Context.Carts.Remove(cart);
            Context.SaveChanges();
            return Ok();
        }
    }
}

