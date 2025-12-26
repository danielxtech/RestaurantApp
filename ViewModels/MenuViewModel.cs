using RestaurantApp.Models;
using RestaurantApp.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace RestaurantApp.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly OrderService _orderService;

        public ObservableCollection<MenuItem> Menu { get; set; }
        public ObservableCollection<MenuItem> FilteredMenu { get; set; }

        public ICommand FilterCommand { get; }
        public ICommand AddToCartCommand { get; }

        public MenuItem SelectedMenuItem { get; set; }

        public MenuViewModel(OrderService service)
        {
            _orderService = service;

            Menu = new ObservableCollection<MenuItem>(_orderService.GetMenu());

            FilteredMenu = new ObservableCollection<MenuItem>(Menu);

            AddToCartCommand = new RelayCommand(item =>
            {
                CartVM?.AddItem(item as MenuItem);
            });

            FilterCommand = new RelayCommand(category =>
            {
                ApplyFilter(category?.ToString());
            });
        }

        private void ApplyFilter(string category)
        {
            FilteredMenu.Clear();

            if (category == "All")
            {
                foreach (var item in Menu)
                    FilteredMenu.Add(item);
            }
            else
            {
                foreach (var item in Menu.Where(m => m.Category == category))
                    FilteredMenu.Add(item);
            }
        }

        public CartViewModel CartVM { get; set; }
    }
}
