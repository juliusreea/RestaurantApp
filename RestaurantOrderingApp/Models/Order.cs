

namespace RestaurantOrderingApp.Models
{
    public class Order
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public Order()
        {
        }
        public decimal ReturnTotal()
        {
            return Price * Quantity;
        }
        public override string ToString()
        {
            return $"---{Name}, Price: {Price}, Quantity: {Quantity}---";    
        }
    }
}
