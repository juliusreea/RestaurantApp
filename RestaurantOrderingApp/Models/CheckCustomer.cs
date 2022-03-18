using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantOrderingApp.Models
{
    public class CheckCustomer : ICheck
    {
        public List<string> Orders { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public CheckCustomer()
        {
            Orders = new List<string>();
        }
        FilePath filePath = new FilePath("CustomerCheck.txt");
        public void PrintCheck(Table table)
        {
            foreach (var order in table.Orders)
            {
                Orders.Add($"{order.Name}, price: {order.Price}, items ordered: {order.Quantity}");
            }
            File.WriteAllLines(filePath.Path, Orders);
            File.AppendAllText(filePath.Path, $"\n{DateTime.Now.ToString()}");
            File.AppendAllText(filePath.Path, $"\ntotal amount of {table.TotalAmount()} euro");
        }
    }
}
