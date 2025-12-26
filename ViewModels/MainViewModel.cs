using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MenuViewModel MenuVM { get; }
        public CartViewModel CartVM { get; }
        public ReservationViewModel ReservationVM { get; }
        public PaymentViewModel PaymentVM { get; }
        public AdminViewModel AdminVM { get; }

        public ICommand ShowMenuCommand { get; }
        public ICommand ShowCartCommand { get; }
        public ICommand ShowReservationCommand { get; }
        public ICommand ShowPaymentCommand { get; }
        public ICommand ShowAdminCommand { get; }

        private object _currentView;
        public object CurrentView { get => _currentView; set { _currentView = value; Raise(); } }

        public MainViewModel (MenuViewModel menu, CartViewModel cart, ReservationViewModel res, PaymentViewModel pay, AdminViewModel admin)
        {
            MenuVM = menu; CartVM = cart; ReservationVM = res; PaymentVM = pay; AdminVM = admin;

            ShowMenuCommand = new RelayCommand(_ => CurrentView = MenuVM);
            ShowCartCommand = new RelayCommand(_ => CurrentView = CartVM);
            ShowReservationCommand = new RelayCommand(_ => CurrentView = ReservationVM);
            ShowPaymentCommand = new RelayCommand(_ => CurrentView = PaymentVM);
            ShowAdminCommand = new RelayCommand(_ => CurrentView = AdminVM);

            CurrentView = MenuVM; 
        }
    }
}
