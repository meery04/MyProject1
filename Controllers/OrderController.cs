using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public BaseForMityaProDuctionContext Context { get; }
        public OrderController(BaseForMityaProDuctionContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GettAll()
        {
            List<Order> orders = Context.Orders.ToList();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Order? order = Context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            if (order == null)
            {
                return BadRequest("Не найдено!");
            }
            return Ok(order);
        }
        [HttpPost]
        public IActionResult Add(Order order)
        {
            Context.Orders.Add(order);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Order order)
        {
            Context.Orders.Update(order);
            Context.SaveChanges();
            return Ok(order);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Order? order = Context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
            if (order == null)
            {
                return BadRequest("Не найдено!");
            }
            Context.Orders.Remove(order);
            Context.SaveChanges();
            return Ok();
        }
    }
}