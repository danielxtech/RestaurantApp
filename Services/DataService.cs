using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RestaurantApp.Services
{
    public class DataService : IDataService
    {
        private readonly List<MenuItem> _menu;
        private readonly List<Order> _orders = new List<Order>();
        private readonly List<Reservation> _reservations = new List<Reservation>();

        public DataService()
        {
            _menu = new List<MenuItem>
            {
                new MenuItem{Id= 1, Name="Margherita Pizza", Description="San Marzano Tomato Sauce, Fresh Mozzarella, Basil", Price=8.50m, Category="Pizza", ImagePath="https://uk.ooni.com/cdn/shop/articles/20220211142645-margherita-9920_e41233d5-dcec-461c-b07e-03245f031dfe.jpg?v=1737105431&width=1080"},
                new MenuItem{Id= 2, Name="Pepperoni Pizza", Description="Tomato Sauce, Mozzarella, Spicy Pepperoni, Parmesan", Price=9.50m, Category="Pizza", ImagePath="https://assets-us-01.kc-usercontent.com/4353bced-f940-00d0-8c6e-13a0a4a7f5c2/2ac60829-5178-4a6e-80cf-6ca43d862cee/Quick-and-Easy-Pepperoni-Pizza-700x700.jpeg?w=1280&auto=format"},
                new MenuItem{Id= 3, Name="Caesar Salad", Description="Romaine Lettuce, Caesar Dressing, Croutons, Shaved Parmesan", Price=6.00m, Category="Appetizers", ImagePath="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRV5Yp0uPt-uqJ5udVjAL71-ArAIvCzE84nYQ&s"},
                new MenuItem{Id= 4, Name="Spaghetti Bolognese", Description="Spaghetti, Slow-Simmered Beef & Tomato Sauce, Parmesan", Price=10.00m, Category="Pasta", ImagePath="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQOW_rMHgSOi4IhmfR8AiWo2bwLV7WdK3uoUA&s"},
                new MenuItem{Id= 5, Name="Tiramisu", Description="Espresso-Soaked Ladyfingers, Mascarpone Cream, Cocoa", Price=4.50m, Category="Dessert", ImagePath="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSyAQCkdnW9YYv7bcmHmsjsF_d-lK2iJYXHnw&s"},
                new MenuItem{Id= 6,Category= "Burgers", Name= "Classic Beef Burger",Description= "Angus beef patty, lettuce, tomato, onion, special sauce, brioche bun",Price= 8,ImagePath= "https://images.unsplash.com/photo-1550547660-d9450f859349?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxnb3VybWV0JTIwYnVyZ2VyfGVufDF8fHx8MTc2NjY2MDIyMHww&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
                new MenuItem{Id= 7, Category= "Burgers", Name= "Bacon Cheeseburger", Description= "Double beef patty, crispy bacon, cheddar cheese, pickles, BBQ sauce", Price= 10, ImagePath= "https://images.unsplash.com/photo-1625813506062-0aeb1d7a094b?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxjaGVlc2VidXJnZXIlMjBkZWx1eGV8ZW58MXx8fHwxNzY2NzQ4NzYyfDA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
                new MenuItem{Id= 8, Category= "Burgers", Name= "Grilled Chicken Burger",Description= "Grilled chicken breast, avocado, Swiss cheese, honey mustard", Price= 9, ImagePath= "https://images.unsplash.com/photo-1606755962773-d324e0a13086?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxjaGlja2VuJTIwYnVyZ2VyfGVufDF8fHx8MTc2NjY2OTI4Mnww&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
                new MenuItem{Id= 9, Category= "Burgers", Name= "Veggie Burger", Description= "Plant-based patty, caramelized onions, arugula, chipotle aioli", Price= 10,ImagePath= "https://images.unsplash.com/photo-1571091718767-18b5b1457add?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHx2ZWdnaWUlMjBidXJnZXJ8ZW58MXx8fHwxNzY2NjczODc2fDA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
                new MenuItem{Id= 10, Category= "Wraps",Name= "Grilled Chicken Wrap", Description= "Grilled chicken, mixed greens, tomato, Caesar dressing, tortilla",Price= 6, ImagePath= "https://images.unsplash.com/photo-1626700051175-6818013e1d4f?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxjaGlja2VuJTIwd3JhcHxlbnwxfHx8fDE3NjY3NDg3NjN8MA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
                new MenuItem{Id= 11, Category= "Wraps", Name= "Falafel Wrap", Description= "Crispy falafel, hummus, cucumber, tomato, tahini sauce", Price= 6, ImagePath= "https://images.unsplash.com/photo-1681072530653-db8fe2538631?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxmYWxhZmVsJTIwd3JhcHxlbnwxfHx8fDE3NjY3MzUyMzF8MA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
                new MenuItem{Id= 12, Category= "Wraps", Name= "Steak & Cheese Wrap", Description= "Sliced sirloin, peppers, onions, melted provolone, garlic aioli", Price= 6, ImagePath= "https://images.unsplash.com/photo-1682159173065-2b49ffd61adb?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxzdGVhayUyMHdyYXB8ZW58MXx8fHwxNzY2NzQ4NzY0fDA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral" },
                new MenuItem{Id= 13, Category= "Pizza", Name= "Garden Veggie Pizza", Description= "Bell peppers, mushrooms, olives, onions, fresh tomatoes, mozzarella", Price= 9,ImagePath= "https://images.unsplash.com/photo-1617343251257-b5d709934ddd?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHx2ZWdldGFyaWFuJTIwcGl6emF8ZW58MXx8fHwxNzY2NjkxOTM3fDA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral" },
                new MenuItem{Id= 14, Category= "Pizza", Name= "Meat Lovers", Description= "Pepperoni, sausage, bacon, ham, mozzarella, tomato sauce", Price= 10, ImagePath= "https://images.unsplash.com/photo-1705286324371-d6a6d9519dc2?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxtZWF0JTIwbG92ZXJzJTIwcGl6emF8ZW58MXx8fHwxNzY2NjkxOTM3fDA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral" },
                new MenuItem{Id= 15, Category= "Drinks", Name= "Craft Cocktails", Description= "Chef's signature cocktails, seasonal ingredients", Price= 3, ImagePath= "https://images.unsplash.com/photo-1600988718520-3f5814892d5b?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxjcmFmdCUyMGNvY2t0YWlsfGVufDF8fHx8MTc2NjcyMTg5MHww&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral" },
                new MenuItem{Id= 16, Category= "Drinks", Name= "Fresh Squeezed Juice", Description= "Orange, grapefruit, or mixed berry juice", Price= 2, ImagePath= "https://images.unsplash.com/photo-1497534446932-c925b458314e?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxmcmVzaCUyMGp1aWNlfGVufDF8fHx8MTc2NjY2Mjg0N3ww&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral" },
                new MenuItem{Id= 17, Category= "Drinks", Name= "Ice Coffee", Description= "Cold brew coffee, choice of milk, vanilla or caramel", Price= 3, ImagePath= "https://images.unsplash.com/photo-1517701550927-30cf4ba1dba5?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxpY2VkJTIwY29mZmVlfGVufDF8fHx8MTc2NjY3OTIzMXww&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
                new MenuItem{Id= 18,Category= "Dessert", Name= "Chocolate Lava Cake", Description= "Warm chocolate cake, molten center, vanilla ice cream", Price= 6,ImagePath= "https://images.unsplash.com/photo-1673551490812-eaee2e9bf0ef?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxjaG9jb2xhdGUlMjBsYXZhJTIwY2FrZXxlbnwxfHx8fDE3NjY3MTUzMDF8MA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
                new MenuItem{Id= 19,Category= "Dessert", Name= "Crème Brûlée", Description= "Classic vanilla custard, caramelized sugar, fresh berries", Price= 7, ImagePath= "https://images.unsplash.com/photo-1676300184943-09b2a08319a3?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxjcmVtZSUyMGJydWxlZXxlbnwxfHx8fDE3NjY3NDc5MzB8MA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral" },
                new MenuItem{Id= 20, Category= "Appetizers", Name= "Seared Scallops", Description= "Pan-seared scallops with cauliflower puree and crispy pancetta",  Price= 6, ImagePath= "https://images.unsplash.com/photo-1605759758891-430e7885631b?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxzZWFyZWQlMjBzY2FsbG9wc3xlbnwxfHx8fDE3NjY3NDc5Mjd8MA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
                new MenuItem{Id= 21, Category= "Appetizers",Name= "Burrata & Heirloom Tomatoes", Description= "Fresh burrata, heirloom tomatoes, basil, aged balsamic", Price= 8,ImagePath= "https://images.unsplash.com/photo-1636743714639-9407ec7b4946?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxidXJyYXRhJTIwdG9tYXRvZXN8ZW58MXx8fHwxNzY2NzQ3OTI4fDA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral" },
                new MenuItem{Id= 22, Category= "Appetizers", Name= "Tuna Tartare", Description= "Fresh tuna, avocado, sesame, wonton crisps", Price= 12, ImagePath= "https://images.unsplash.com/photo-1656106577512-0259bf5b9fd6?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHx0dW5hJTIwdGFydGFyZXxlbnwxfHx8fDE3NjY3NDc5Mjh8MA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
                new MenuItem{Id= 23,Category= "Pasta", Name= "Spaghetti Carbonara", Description= "Classic Roman pasta, pancetta, egg yolk, pecorino, black pepper", Price= 11, ImagePath= "https://images.unsplash.com/photo-1633337474564-1d9478ca4e2e?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxzcGFnaGV0dGklMjBjYXJib25hcmF8ZW58MXx8fHwxNzY2NzEyNzc1fDA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
                new MenuItem{Id= 24, Category= "Pasta", Name= "Fettuccine Alfredo", Description= "Creamy parmesan sauce, butter, garlic, fresh cracked pepper", Price= 10, ImagePath= "https://images.unsplash.com/photo-1645112411341-6c4fd023714a?crop=entropy&cs=tinysrgb&fit=max&fm=jpg&ixid=M3w3Nzg4Nzd8MHwxfHNlYXJjaHwxfHxmZXR0dWNjaW5lJTIwYWxmcmVkb3xlbnwxfHx8fDE3NjY3NjA5OTh8MA&ixlib=rb-4.1.0&q=80&w=1080&utm_source=figma&utm_medium=referral"},
            };
        }

        public List<MenuItem> GetMenu() => _menu.Select(m => m).ToList();

        public void SaveOrder(Order order)
        {
            order.CreatedAt = DateTime.Now;
            _orders.Add(order);
        }

        public List<Order> GetOrders() => _orders.ToList();

        public void SaveReservation(Reservation res)
        {
            _reservations.Add(res);
        }

        public List<Reservation> GetReservations() => _reservations.ToList();
    }
}
