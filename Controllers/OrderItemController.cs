using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        public BaseForMityaProDuctionContext Context { get; }
        public OrderItemController(BaseForMityaProDuctionContext context)
        {
            Context = context;
        }

    }
}