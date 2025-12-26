using RestaurantApp.Models;
using RestaurantApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace RestaurantApp.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private readonly OrderService _orderService;
        public ObservableCollection<OrderItem> Items { get; } = new ObservableCollection<OrderItem>();
        public ICommand RemoveCommand { get; }
        public ICommand IncreaseCommand { get; }
        public ICommand DecreaseCommand { get; }
        public ICommand PlaceOrderCommand { get; }

        private decimal _subtotal;
        public decimal SubTotal { get => _subtotal; set { _subtotal = value; Raise(); } }

        public PaymentViewModel PaymentVM { get; set; }
        public Action NavigateToPayment { get; set; }
        public CartViewModel(OrderService orderService)
        {
            _orderService = orderService;
            RemoveCommand = new RelayCommand(p =>
            {
                if (p is OrderItem oi) { Items.Remove(oi); RaiseTotals(); }
            });
            IncreaseCommand = new RelayCommand(p => { if (p is OrderItem oi) { oi.Quantity++; RaiseTotals(); } });
            DecreaseCommand = new RelayCommand(p => { if (p is OrderItem oi) { if (oi.Quantity>1) oi.Quantity--; else Items.Remove(oi); RaiseTotals(); } });
            PlaceOrderCommand = new RelayCommand(p =>
            {
                if (Items.Count == 0) return;

                var order = new Order
                {
                    Items = Items.Select(i => new OrderItem { Item = i.Item, Quantity = i.Quantity }).ToList(),
                    TableNumber = p as string
                };

                _orderService.SubmitOrder(order);

                PaymentVM?.LoadOrder(order);
                NavigateToPayment?.Invoke();

                Items.Clear();
                RaiseTotals();
            });
            RaiseTotals();
        }

        public void RaiseTotals()
        {
            SubTotal = Items.Sum(i => i.Total);
            Raise(nameof(SubTotal));
        }
        public void AddItem(MenuItem item)
        {
            if (item == null) return;

            var existing = Items.FirstOrDefault(i => i.Item.Id == item.Id);

            if (existing != null)
            {
                existing.Quantity++;  
            }
            else
            {
                Items.Add(new OrderItem
                {
                    Item = item,
                    Quantity = 1
                });
            }

            RaiseTotals();
        }

    }
}
