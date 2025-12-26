using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Order
    {
        public string OrderId { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string TableNumber { get; set; }
        public decimal SubTotal => Items.Sum(i => i.Total);
        public decimal Tax => SubTotal * 0.10m; 
        public decimal Total => SubTotal + Tax;
        public string Status { get; set; } = "Pending";
    }
}
