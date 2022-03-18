using System;

namespace RestaurantOrderingApp.Functionality.Extensions
{
    internal static class Extensions
    {
        public static void Printer(this string text)
        {
            Console.WriteLine(text);
        }
        public static int Validation(this string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return 0;
            }
        }
    }
}
