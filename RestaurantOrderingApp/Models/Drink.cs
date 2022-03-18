

namespace RestaurantOrderingApp.Models
{
    public class Drink
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Drink(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public Drink()
        {
        }

        public override string ToString()
        {
            return $"{Name}, Price: {Price}";
        }
    }
}
