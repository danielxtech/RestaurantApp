using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    public class ReservationService
    {
        private readonly IDataService _dataService;
        public ReservationService(IDataService dataService) { _dataService = dataService; }

        public void AddReservation(Reservation r) => _dataService.SaveReservation(r);
        public List<Reservation> GetReservations() => _dataService.GetReservations();
    }
}
