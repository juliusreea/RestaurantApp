
using System.Collections.Generic;

namespace RestaurantOrderingApp.Models
{
    public interface ICheck
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<string> Orders { get; set; }

        public void PrintCheck(Table table);
    }
}
