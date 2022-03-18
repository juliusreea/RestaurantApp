using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingApp.Models
{
    public class Table
    {
        public string Number { get; set; }
        public List<Order> Orders { get; set; }
        public bool IsOccupied { get; set; }
        public int Customers { get; set; }

        public Table(string number, bool isVacant)
        {
            Number = number;
            Orders = new List<Order>();
            IsOccupied = isVacant;
        }
        public string TableInfo()
        {
            if (Orders.Count == 0 && Customers==0)
                return "free";
            else
                return $"Is occupied // {Customers} seated // {Orders.Select(x => x.Quantity).Sum()} items ordered";
        }
        public decimal TotalAmount()
        {
            decimal tableTotal = Orders.Select(x => x.ReturnTotal()).Sum();
            return tableTotal;
        }
        public override string ToString()
        {
            return $"{Number}";
        }
    }
}
