using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public int StatusId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Status Status { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
