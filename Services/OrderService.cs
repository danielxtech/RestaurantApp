using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    public class OrderService
    {
        private readonly IDataService _dataService;
        public OrderService(IDataService dataService) { _dataService = dataService; }

        public IEnumerable<MenuItem> GetMenu() => _dataService.GetMenu();
        public void SubmitOrder(Order order) => _dataService.SaveOrder(order);
        public List<Order> GetOrders() => _dataService.GetOrders();
    }
}
