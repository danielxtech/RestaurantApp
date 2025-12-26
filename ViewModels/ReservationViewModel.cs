using RestaurantApp.Models;
using RestaurantApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantApp.ViewModels
{
    public class ReservationViewModel : BaseViewModel
    {
        private readonly ReservationService _reservationService;
        public Reservation Current { get; set; } = new Reservation { DateTime = DateTime.Now.AddHours(1-1), Guests = 2 };
        public ICommand SaveReservationCommand { get; }

        public ReservationViewModel(ReservationService rs)
        {
            _reservationService = rs;
            SaveReservationCommand = new RelayCommand(_ =>
            {
                _reservationService.AddReservation(Current);
                Current = new Reservation { DateTime = DateTime.Now.AddHours(1), Guests = 2 };
                Raise(nameof(Current));
            });
        }
    }
}
