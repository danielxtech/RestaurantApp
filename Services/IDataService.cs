using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    public interface IDataService
    {
        List<MenuItem> GetMenu();
        void SaveOrder(Order order);
        List<Order> GetOrders();
        void SaveReservation(Reservation res);
        List<Reservation> GetReservations();
    }
}
