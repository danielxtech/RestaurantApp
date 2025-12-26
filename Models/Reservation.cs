using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class Reservation
    {
        public string ReservationId { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Guests { get; set; }
        public DateTime DateTime { get; set; }
        public string TableNumber { get; set; }
        public string Notes { get; set; }
    }
}
