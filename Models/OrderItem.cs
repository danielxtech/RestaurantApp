using RestaurantApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantApp.Models
{
    public class OrderItem : INotifyPropertyChanged
    {
        private int _quantity = 1;
        public MenuItem Item { get; set; }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity == value) return;
                _quantity = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Total));
            }
        }

        public decimal Total => Item != null ? Item.Price * Quantity : 0m;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}

