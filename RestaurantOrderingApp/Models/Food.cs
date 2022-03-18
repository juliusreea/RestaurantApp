

namespace RestaurantOrderingApp.Models
{
    public class Food
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Food(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public Food()
        {
        }

        public override string ToString()
        {
            return $"{Name}, Price: {Price}";
        }
    }
}
