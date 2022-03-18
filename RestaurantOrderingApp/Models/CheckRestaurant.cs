using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantOrderingApp.Models
{
    public class CheckRestaurant : ICheck
    {
        public List<string> Orders { get; set; }
        public string Name { get; set; }    
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Customer { get; set; }

        public CheckRestaurant()
        {
            Orders = new List<string>();
        }
        FilePath _filePath = new FilePath("RestaurantCheck.txt");
        public void PrintCheck(Table table)
        {
            foreach (var order in table.Orders)
            {
                Orders.Add($"{order.Name}, price: {order.Price}, items ordered: {order.Quantity}");
            }
            File.WriteAllLines(_filePath.Path, Orders);
            File.AppendAllText(_filePath.Path, $"\n{DateTime.Now}");
            File.AppendAllText(_filePath.Path, $"\ntotal amount of {table.TotalAmount()} euro");
            File.AppendAllText(_filePath.Path, $"\n{table.Customers} persons were seated at {table}");
        }
    }
}