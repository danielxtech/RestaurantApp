using System.Linq;
using System.Windows;
using System.Windows.Input;
using RestaurantApp.Models;

namespace RestaurantApp.ViewModels
{
    public class PaymentViewModel : BaseViewModel
    {
        public Order CurrentOrder { get; set; } = null;
        public ICommand PayCommand { get; }

        public PaymentViewModel()
        {
            PayCommand = new RelayCommand(_ =>
            {
                if (CurrentOrder == null) return;

                CurrentOrder.Status = "Paid";

                var invoice =
                    $"Order #: {CurrentOrder.OrderId}\n" +
                    $"Date: {CurrentOrder.CreatedAt}\n" +
                    $"Table: {CurrentOrder.TableNumber}\n\n" +
                    "Items:\n";

                invoice += string.Join("\n", CurrentOrder.Items.Select(i =>
                    $"{i.Item.Name} x{i.Quantity} = {i.Total:C}"));

                invoice += $"\n\nSubtotal: {CurrentOrder.SubTotal:C}\nTax: {CurrentOrder.Tax:C}\nTotal: {CurrentOrder.Total:C}";

                MessageBox.Show(invoice, "Purchase Invoice");

                Raise(nameof(CurrentOrder));
            });
        }

        public void LoadOrder(Order order)
        {
            CurrentOrder = order;
            Raise(nameof(CurrentOrder));
        }
    }
}
