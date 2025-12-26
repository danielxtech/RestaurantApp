using RestaurantApp.Models;
using RestaurantApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantApp.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        private readonly OrderService _orderService;
        public ObservableCollection<Order> Orders { get; } = new ObservableCollection<Order>();
        public ICommand RefreshCommand { get; }

        public AdminViewModel(OrderService orderService)
        {
            _orderService = orderService;
            RefreshCommand = new RelayCommand(_ => Load());
            Load();
        }

        public void Load()
        {
            Orders.Clear();
            foreach (var o in _orderService.GetOrders()) Orders.Add(o);
        }
    }
}
