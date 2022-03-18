using System;
using System.Collections.Generic;
using RestaurantOrderingApp.Models;
using RestaurantOrderingApp.Functionality;

namespace RestaurantOrderingApp.Repositories
{
    internal class FoodRepo
    {
        FileService _FileService = new FileService();
        public List<Food> Foods { get; set; }

        public FoodRepo()
        {
            Foods = _FileService.ReadFoodsFromFile("Foods");
        }
        public void DisplayFoods()
        {
            int counter = 0;
            foreach (Food food in Foods)
            {
                Console.WriteLine($"[{1 + counter++}] {food}");
            }
        }
        public List<Food> FoodsList()
        {
            return _FileService.ReadFoodsFromFile("Foods");
        }
    }
}
