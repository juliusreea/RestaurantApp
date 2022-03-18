using System;

namespace RestaurantOrderingApp.Models
{
    public class ConsoleInfo
    {
        public void TableInfo()
        {
            Console.WriteLine("[1] Seat customers to table");
            Console.WriteLine("[2] Place Food Order");
            Console.WriteLine("[3] Place Drink Order");
            Console.WriteLine("[4] View Order");
            Console.WriteLine("[5] Check out (free table)");
            Console.WriteLine("[6] Return to table list");
        }
        public void WrongInput()
        {
            Console.WriteLine("Wrong input, check your input");
            Console.ReadKey();
        }
    }
}
