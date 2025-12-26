using RestaurantApp.Services;
using RestaurantApp.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestaurantApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var data = new DataService();
            var orderService = new OrderService(data);
            var reservationService = new ReservationService(data);

            var cartVM = new CartViewModel(orderService);
            var menuVM = new MenuViewModel(orderService) { CartVM = cartVM };
            var reservationVM = new ReservationViewModel(reservationService);
            var paymentVM = new PaymentViewModel();
            var adminVM = new AdminViewModel(orderService);

            var main = new MainViewModel(menuVM, cartVM, reservationVM, paymentVM, adminVM);

            cartVM.PaymentVM = paymentVM;
            cartVM.NavigateToPayment = () => { main.CurrentView = paymentVM; };

            DataContext = main;
        }
    }
}