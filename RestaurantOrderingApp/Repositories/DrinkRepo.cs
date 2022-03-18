using System;
using System.Collections.Generic;
using RestaurantOrderingApp.Models;
using RestaurantOrderingApp.Functionality;

namespace RestaurantOrderingApp.Repositories
{
    internal class DrinkRepo
    {
        FileService _FileService = new FileService();
        public List<Drink> Drinks { get; set; }

        public DrinkRepo()
        {
            Drinks = _FileService.ReadDrinksFromFile("Drinks");
        }
        public void DisplayDrinks()
        {
            int counter = 0;
            foreach (Drink drink in Drinks)
            {
                Console.WriteLine($"[{1+counter++}] {drink}");
            }
        }
    }
}
